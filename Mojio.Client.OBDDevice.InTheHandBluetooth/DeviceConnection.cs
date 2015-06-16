using InTheHand.Net.Sockets;
using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice.InTheHandBluetooth
{
    public class DeviceConnection : IDeviceConnection
    {
        public DeviceConnection()
        {
            Connected = false;
        }

        public BluetoothClient Client { get; set; }

        private static object _lock = new object();

        internal const char MESSAGE_TERMINATOR_CHAR = '\r';
        private const int RECEIVE_BUFFER_SIZE = 1024;
        private const char CHIP_READY_PROMPT_CHAR = '>';
        private const string MESSAGE_NO_DATA = "NO DATA";
        private const string MESSAGE_NO_CONNECTION = "UNABLE TO CONNECT";
        private const string MESSAGE_CAN_ERROR = "CAN ERROR";
        private static string MESSAGE_SEARCHING = "SEARCHING..." + MESSAGE_TERMINATOR_CHAR;
        private const int MAX_WAIT_RECEIVE_SECONDS = 10;

        /// <summary>
        /// Returns a message received from the ELM.  Note that this call
        /// waits until the ready prompt character is received from the ELM
        /// before returning control.
        /// </summary>
        /// <returns>The received message.  If a null value is returned, it means
        /// either an error occurred during the read attempt or a timeout
        /// occurred while waiting for the ELM to respond.</returns>
        private IOBDParsedResult ReceiveMessage()
        {
            lock (_lock)
            {
                var result = new OBDParsedResult();
                result.StartReceive = DateTimeOffset.UtcNow;

                try
                {
                    // Keep reading from the serial connection until the ELM sends the
                    // ready prompt character or we time out.  We wait for the ready prompt
                    // because while most responses from the ELM will be only one line,
                    // some will be multiline, so we need to keep reading lines until we
                    // receive the ready prompt.

                    int i = 0;
                    var stream = Client.GetStream();
                    byte[] receiveBuffer = new byte[RECEIVE_BUFFER_SIZE];

                    do
                    {
                        if (stream.CanRead && stream.Read(receiveBuffer, i, 1) > 0)
                        {
                            if (receiveBuffer[i] == CHIP_READY_PROMPT_CHAR)
                            {
                                string message = new string(Encoding.UTF8.GetChars(receiveBuffer), 0, i);

                                // Trim the message to the point just before the last EOL terminator

                                if (!message.Contains(MESSAGE_TERMINATOR_CHAR)) break;

                                message =
                                    message.Substring(0, message.LastIndexOf(MESSAGE_TERMINATOR_CHAR) - 1).Trim();

                                if (message.IndexOf(MESSAGE_NO_DATA) > -1)
                                {
                                    result.Error = "A request timed out or a PID not supported by an ECU was requested";
                                    result.EndReceive = DateTimeOffset.UtcNow;
                                    return result;
                                }
                                else if (message.IndexOf(MESSAGE_NO_CONNECTION) > -1)
                                {
                                    //if (this.ObdConnectionLost != null)
                                    //    this.ObdConnectionLost();
                                    result.Error =
                                        "Connection Lost.  The ELM is unable to connect to the vehicle's OBD system for some reason.";
                                    result.EndReceive = DateTimeOffset.UtcNow;
                                    return result;
                                }
                                else if (message.IndexOf(MESSAGE_CAN_ERROR) > -1)
                                {
                                    //if (this.CanBusError != null)
                                    //    this.CanBusError();

                                    result.Error = "CanBus Error";
                                    result.EndReceive = DateTimeOffset.UtcNow;
                                    return result;
                                }
                                else if (message.IndexOf(MESSAGE_SEARCHING) > -1)
                                {
                                    // If the ELM returned a "SEARCHING..." message, trim it
                                    // out before returning to the caller

                                    var m =
                                        message.Length > MESSAGE_SEARCHING.Length
                                            ? message.Substring(MESSAGE_SEARCHING.Length)
                                            : string.Empty;

                                    result.Raw = m;
                                    result.EndReceive = DateTimeOffset.UtcNow;
                                    return result;
                                }
                                else
                                {
                                    result.Raw = message;
                                    result.EndReceive = DateTimeOffset.UtcNow;
                                    return result;
                                }
                            }
                            i++;
                        }

                        Task.Delay(1).Wait();
                    } while (result.StartReceive.AddSeconds(MAX_WAIT_RECEIVE_SECONDS) > DateTime.UtcNow);

                    // Reaching this point means we've waited too long for the chip to send us a response
                    result.EndReceive = DateTimeOffset.UtcNow;
                    return result;
                }
                catch (Exception ex)
                {
                    result.EndReceive = DateTimeOffset.UtcNow;
                    result.Error = ex.ToString();
                    return result;
                }
            }
        }

        public bool Connected { get; set; }

        private NetworkStream _socket;

        public IOBDParsedResult SendAndReceive(string message)
        {
            lock (_lock)
            {
                var bytes = Encoding.UTF8.GetBytes(message + MESSAGE_TERMINATOR_CHAR);

                if (_socket == null)
                {
                    try
                    {
                        _socket = Client.GetStream();
                        _socket.Flush();
                    }
                    catch (Exception)
                    {
                    }
                    Connected = _socket.CanWrite && _socket.CanRead;
                }

                // if all is ok to send
                if (Client.Connected && _socket != null)
                {
                    // write the data in the stream
                    _socket.Write(bytes, 0, bytes.Length);

                    Task.Delay(100).Wait();

                    var m = ReceiveMessage();
                    if (!string.IsNullOrEmpty(m.Raw)) m.Raw = m.Raw.Replace("\n", "");
                    m.Request = message;
                    return m;
                }
            }

            return null;
        }
    }
}