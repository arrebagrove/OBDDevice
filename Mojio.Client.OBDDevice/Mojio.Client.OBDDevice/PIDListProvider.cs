﻿using Mojio.Client.OBDDevice.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mojio.Client.OBDDevice
{
    public class PIDListProvider : IPIDListProvider
    {
        public PIDListProvider()
        {
            PIDs = new List<IPID>();

            AddMeasure("ATRV", "Battery");

            AddMeasure("0100", "List of PIDs supported (range 01 to 32)");
            AddMeasure("0101", "Status since the last clearing of fault codes");
            AddMeasure("0102", "Fault code that caused the recording of 'freeze frame' data");
            AddMeasure("0103", "Fuel system status");
            AddMeasure("0104", "Engine load calculated in %");
            AddMeasure("0105", "Temperature of the engine coolant in Â°C");
            AddMeasure("0106", "Short-term fuel % trim bank 1");
            AddMeasure("0107", "Long-term fuel % trim bank 1 ");
            AddMeasure("0108", "Short-term fuel % trim bank 2 ");
            AddMeasure("0109", "Long-term fuel % trim bank 2 ");
            AddMeasure("010A", "Fuel pressure in kPa");
            AddMeasure("010B", "Intake manifold absolute pressure in kPa");
            AddMeasure("010C", "Engine speed in rpm");
            AddMeasure("010D", "Vehicle speed in kph");
            AddMeasure("010E", "Timing advance on cylinder 1 in degrees");
            AddMeasure("010F", "Intake air temperature in Â°C");
            AddMeasure("0110", "Air flow measured by the flowmeter in g/s");
            AddMeasure("0111", "Throttle position in %");
            AddMeasure("0112", "Status of the secondary intake circuit");
            AddMeasure("0113", "O2 sensor positions bank/sensor");
            AddMeasure("0114", "Oxygen sensor volts bank 1 sensor 1/td&gt;");
            AddMeasure("0115", "Oxygen sensor volts bank 1 sensor 2");
            AddMeasure("0116", "Oxygen sensor volts bank 1 sensor 3");
            AddMeasure("0117", "Oxygen sensor volts bank 1 sensor 4");
            AddMeasure("0118", "Oxygen sensor volts bank 2 sensor 1");
            AddMeasure("0119", "Oxygen sensor volts bank 2 sensor 2");
            AddMeasure("011A", "Oxygen sensor volts bank 2 sensor 3");
            AddMeasure("011B", "Oxygen sensor volts bank 2 sensor 4");
            AddMeasure("011C", "OBD computer specification");
            AddMeasure("011D", "O2 sensor positions bank/sensor");
            AddMeasure("011E", "Auxiliary input status");
            AddMeasure("011F", "Run time since engine start");
            AddMeasure("0120", "List of PIDs supported (range 33 to 64)");
            AddMeasure("0121", "Distance travelled with MIL on in kms");
            AddMeasure("0122", "Relative fuel rail pressure in kPa");
            AddMeasure("0123", "Fuel rail pressure in kPa");
            AddMeasure("0124", "O2 sensor (extended range) bank 1, sensor 1 (lambda and volts)");
            AddMeasure("0125", "O2 sensor (extended range) bank 1, sensor 2 (lambda and volts)");
            AddMeasure("0126", "O2 sensor (extended range) bank 1, sensor 3 (lambda and volts)");
            AddMeasure("0127", "O2 sensor (extended range) bank 1, sensor 4 (lambda and volts)");
            AddMeasure("0128", "O2 sensor (extended range) bank 2, sensor 1 (lambda and volts)");
            AddMeasure("0129", "O2 sensor (extended range) bank 2, sensor 2 (lambda and volts)");
            AddMeasure("012A", "O2 sensor (extended range) bank 2, sensor 3 (lambda and volts)");
            AddMeasure("012B", "O2 sensor (extended range) bank 2, sensor 4 (lambda and volts)");
            AddMeasure("012C", "EGR in %");
            AddMeasure("012D", "EGR error in %");
            AddMeasure("012E", "Evaporation purge in %");
            AddMeasure("012F", "Fuel level in %");
            AddMeasure("0130", "Number of warning(s) since faults (DTC) were cleared");
            AddMeasure("0131", "Distance since faults (DTC) were cleared.");
            AddMeasure("0132", "Evaporation system vapour pressure in Pa");
            AddMeasure("0133", "Barometic pressure in kPa");
            AddMeasure("0134", "O2 sensor (extended range) bank 1, sensor 1 (lambda and volts)");
            AddMeasure("0135", "O2 sensor (extended range) bank 1, sensor 2 (lambda and volts)");
            AddMeasure("0136", "O2 sensor (extended range) bank 1, sensor 3 (lambda and volts)");
            AddMeasure("0137", "O2 sensor (extended range) bank 1, sensor 4 (lambda and volts)");
            AddMeasure("0138", "O2 sensor (extended range) bank 2, sensor 1 (lambda and volts)");
            AddMeasure("0139", "O2 sensor (extended range) bank 2, sensor 2 (lambda and volts)");
            AddMeasure("013A", "O2 sensor (extended range) bank 2, sensor 3 (lambda and volts)");
            AddMeasure("013B", "O2 sensor (extended range) bank 2, sensor 4 (lambda and volts)");
            AddMeasure("013C", "Catalyst temperature in Â°C bank 1, sensor 1");
            AddMeasure("013D", "Catalyst temperature in Â°C bank 2, sensor 1");
            AddMeasure("013E", "Catalyst temperature in Â°C bank 1, sensor 2");
            AddMeasure("013F", "Catalyst temperature in Â°C bank 2, sensor 1");
            AddMeasure("0140", "List of PIDs supported (range 65 to 96)");
            AddMeasure("0141", "Monitor status this drive cycle");
            AddMeasure("0142", "Control module voltage in V");
            AddMeasure("0143", "Absolute engine load");
            AddMeasure("0144", "Equivalent fuel/air mixture request");
            AddMeasure("0145", "Relative throttle position in %");
            AddMeasure("0146", "Ambient air temperature in Â°C");
            AddMeasure("0147", "Absolute throttle position B in %");
            AddMeasure("0148", "Absolute throttle position C in %");
            AddMeasure("0149", "Accelerator pedal position D in %");
            AddMeasure("014A", "Accelerator pedal position E in %");
            AddMeasure("014B", "Accelerator pedal position F in %");
            AddMeasure("014C", "Commanded throttle actuator in %");
            AddMeasure("014D", "Engine run time since MIL on in min");
            AddMeasure("014E", "Engine run time since faults cleared in min ");
            AddMeasure("014F", "Exteral test equipment no. 1 configuration information");
            AddMeasure("0150", "Exteral test equipment no. 2 configuration information");
            AddMeasure("0151", "Fuel type used by the vehicle");
            AddMeasure("0152", "Ethanol fuel %");
            AddMeasure("0153", "Absolute evaporation system vapour pressure in kPa");
            AddMeasure("0154", "Evaporation system vapour pressure in Pa");
            AddMeasure("0155", "Short-term O2 sensor trim bank 1 and 3");
            AddMeasure("0156", "Long-term O2 sensor trim bank 1 and 3");
            AddMeasure("0157", "Short-term O2 sensor trim bank 2 and 4");
            AddMeasure("0158", "Long-term O2 sensor trim bank 2 and 4");
            AddMeasure("0159", "Absolute fuel rail pressure in kPa");
            AddMeasure("015A", "Relative accelerator pedal position in %");
            AddMeasure("015B", "Battery unit remaining life (hybrid) in %");
            AddMeasure("015C", "Engine oil temperature in Â°C");
            AddMeasure("015D", "Fuel injection timing in Â°");
            AddMeasure("015E", "Fuel consumption in litre/hr");
            AddMeasure("015F", "Fuel consumption in litre/hr");
            AddMeasure("0160", "List of PIDs supported (range 97 to 128)");
            AddMeasure("0161", "Driver demand: torque percentage (%)");
            AddMeasure("0162", "Final engine torque percentage (%)");
            AddMeasure("0163", "Engine torque reference in Nm");
            AddMeasure("0164", "Engine torque data in %");
            AddMeasure("0165", "Auxiliary inputs / outputs");
            AddMeasure("0166", "Flowmeter sensor");
            AddMeasure("0167", "Engine water temperature in Â°C");
            AddMeasure("0168", "Air temperature sensor in Â°C");
            AddMeasure("0169", "Commanded EGR and EGR error");
            AddMeasure("016A", "Commanded Diesel intake air flow control and relative intake air flow position ");
            AddMeasure("016B", "Recirculation gas temperature in Â°C");
            AddMeasure("016C", "Commanded throttle actuator control and relative throttle position ");
            AddMeasure("016D", "Fuel pressure control system");
            AddMeasure("016E", "Injection pressure control system");
            AddMeasure("016F", "Turbocharger compressor inlet pressure in kPa");
            AddMeasure("0170", "Boost pressure control in kPa");
            AddMeasure("0171", "Variable Geometry turbo (VGT) control");
            AddMeasure("0172", "Wastegate control");
            AddMeasure("0173", "Exhaust pressure in kPa");
            AddMeasure("0174", "Turbocharger RPM");
            AddMeasure("0175", "Turbocharger A temperature in Â°C");
            AddMeasure("0176", "Turbocharger B temperature in Â°C");
            AddMeasure("0177", "Charge air cooler temperature in Â°C");
            AddMeasure("0178", "Exhaust Gas temperature (EGT) Bank 1");
            AddMeasure("0179", "Exhaust Gas temperature (EGT) Bank 2");
            AddMeasure("017A", "Diesel particulate filter (DPF) bank 1");
            AddMeasure("017B", "Diesel particulate filter (DPF) bank 2");
            AddMeasure("017C", "Diesel Particulate filter (DPF) temperature");
            AddMeasure("017D", "NOx NTE control area status");
            AddMeasure("017E", "PM NTE control area status");
            AddMeasure("017F", "Engine run time");
            AddMeasure("0180", "List of PIDs supported (range 129 to 160)");

            AddMeasure("010C", "Engine speed in rpm (mode 2)");
            AddMeasure("010D", "Vehicle speed in kph (mode 2)");
            AddMeasure("010E", "Timing advance on cylinder 1 in degrees (mode 2)");
            AddMeasure("010F", "Intake air temperature in Â°C (mode 2)");
            AddMeasure("0110", "Air flow measured by the flowmeter in g/s (mode 2)");
            AddMeasure("0111", "Throttle position in % (mode 2)");
            AddMeasure("0112", "Status of the secondary intake circuit (mode 2)");
            AddMeasure("0113", "O2 sensor positions bank/sensor (mode 2)");
            AddMeasure("0114", "Oxygen sensor volts bank 1 sensor 1/td&gt; (mode 2)");
            AddMeasure("0115", "Oxygen sensor volts bank 1 sensor 2 (mode 2)");
            AddMeasure("0116", "Oxygen sensor volts bank 1 sensor 3 (mode 2)");
            AddMeasure("0117", "Oxygen sensor volts bank 1 sensor 4 (mode 2)");
            AddMeasure("0118", "Oxygen sensor volts bank 2 sensor 1 (mode 2)");
            AddMeasure("0119", "Oxygen sensor volts bank 2 sensor 2 (mode 2)");
            AddMeasure("011A", "Oxygen sensor volts bank 2 sensor 3 (mode 2)");
            AddMeasure("011B", "Oxygen sensor volts bank 2 sensor 4 (mode 2)");
            AddMeasure("011C", "OBD computer specification (mode 2)");
            AddMeasure("011D", "O2 sensor positions bank/sensor (mode 2)");
            AddMeasure("011E", "Auxiliary input status (mode 2)");
            AddMeasure("011F", "Run time since engine start (mode 2)");
            AddMeasure("0120", "List of PIDs supported (range 33 to 64) (mode 2)");
            AddMeasure("0121", "Distance travelled with MIL on in kms (mode 2)");
            AddMeasure("0122", "Relative fuel rail pressure in kPa (mode 2)");
            AddMeasure("0123", "Fuel rail pressure in kPa (mode 2)");
            AddMeasure("0124", "O2 sensor (extended range) bank 1, sensor 1 (lambda and volts) (mode 2)");
            AddMeasure("0125", "O2 sensor (extended range) bank 1, sensor 2 (lambda and volts) (mode 2)");
            AddMeasure("0126", "O2 sensor (extended range) bank 1, sensor 3 (lambda and volts) (mode 2)");
            AddMeasure("0127", "O2 sensor (extended range) bank 1, sensor 4 (lambda and volts) (mode 2)");
            AddMeasure("0128", "O2 sensor (extended range) bank 2, sensor 1 (lambda and volts) (mode 2)");
            AddMeasure("0129", "O2 sensor (extended range) bank 2, sensor 2 (lambda and volts) (mode 2)");
            AddMeasure("012A", "O2 sensor (extended range) bank 2, sensor 3 (lambda and volts) (mode 2)");
            AddMeasure("012B", "O2 sensor (extended range) bank 2, sensor 4 (lambda and volts) (mode 2)");
            AddMeasure("012C", "EGR in % (mode 2)");
            AddMeasure("012D", "EGR error in % (mode 2)");
            AddMeasure("012E", "Evaporation purge in % (mode 2)");
            AddMeasure("012F", "Fuel level in % (mode 2)");
            AddMeasure("0130", "Number of warning(s) since faults (DTC) were cleared (mode 2)");
            AddMeasure("0131", "Distance since faults (DTC) were cleared. (mode 2)");
            AddMeasure("0132", "Evaporation system vapour pressure in Pa (mode 2)");
            AddMeasure("0133", "Barometic pressure in kPa (mode 2)");
            AddMeasure("0134", "O2 sensor (extended range) bank 1, sensor 1 (lambda and volts) (mode 2)");
            AddMeasure("0135", "O2 sensor (extended range) bank 1, sensor 2 (lambda and volts) (mode 2)");
            AddMeasure("0136", "O2 sensor (extended range) bank 1, sensor 3 (lambda and volts) (mode 2)");
            AddMeasure("0137", "O2 sensor (extended range) bank 1, sensor 4 (lambda and volts) (mode 2)");
            AddMeasure("0138", "O2 sensor (extended range) bank 2, sensor 1 (lambda and volts) (mode 2)");
            AddMeasure("0139", "O2 sensor (extended range) bank 2, sensor 2 (lambda and volts) (mode 2)");
            AddMeasure("013A", "O2 sensor (extended range) bank 2, sensor 3 (lambda and volts) (mode 2)");
            AddMeasure("013B", "O2 sensor (extended range) bank 2, sensor 4 (lambda and volts) (mode 2)");
            AddMeasure("013C", "Catalyst temperature in Â°C bank 1, sensor 1 (mode 2)");
            AddMeasure("013D", "Catalyst temperature in Â°C bank 2, sensor 1 (mode 2)");
            AddMeasure("013E", "Catalyst temperature in Â°C bank 1, sensor 2 (mode 2)");
            AddMeasure("013F", "Catalyst temperature in Â°C bank 2, sensor 1 (mode 2)");
            AddMeasure("0140", "List of PIDs supported (range 65 to 96) (mode 2)");
            AddMeasure("0141", "Monitor status this drive cycle (mode 2)");
            AddMeasure("0142", "Control module voltage in V (mode 2)");
            AddMeasure("0143", "Absolute engine load (mode 2)");
            AddMeasure("0144", "Equivalent fuel/air mixture request (mode 2)");
            AddMeasure("0145", "Relative throttle position in % (mode 2)");
            AddMeasure("0146", "Ambient air temperature in Â°C (mode 2)");
            AddMeasure("0147", "Absolute throttle position B in % (mode 2)");
            AddMeasure("0148", "Absolute throttle position C in % (mode 2)");
            AddMeasure("0149", "Accelerator pedal position D in % (mode 2)");
            AddMeasure("014A", "Accelerator pedal position E in % (mode 2)");
            AddMeasure("014B", "Accelerator pedal position F in % (mode 2)");
            AddMeasure("014C", "Commanded throttle actuator in % (mode 2)");
            AddMeasure("014D", "Engine run time since MIL on in min (mode 2)");
            AddMeasure("014E", "Engine run time since faults cleared in min  (mode 2)");
            AddMeasure("014F", "Exteral test equipment no. 1 configuration information (mode 2)");
            AddMeasure("0150", "Exteral test equipment no. 2 configuration information (mode 2)");
            AddMeasure("0151", "Fuel type used by the vehicle (mode 2)");
            AddMeasure("0152", "Ethanol fuel % (mode 2)");
            AddMeasure("0153", "Absolute evaporation system vapour pressure in kPa (mode 2)");
            AddMeasure("0154", "Evaporation system vapour pressure in Pa (mode 2)");
            AddMeasure("0155", "Short-term O2 sensor trim bank 1 and 3 (mode 2)");
            AddMeasure("0156", "Long-term O2 sensor trim bank 1 and 3 (mode 2)");
            AddMeasure("0157", "Short-term O2 sensor trim bank 2 and 4 (mode 2)");
            AddMeasure("0158", "Long-term O2 sensor trim bank 2 and 4 (mode 2)");
            AddMeasure("0159", "Absolute fuel rail pressure in kPa (mode 2)");
            AddMeasure("015A", "Relative accelerator pedal position in % (mode 2)");
            AddMeasure("015B", "Battery unit remaining life (hybrid) in % (mode 2)");
            AddMeasure("015C", "Engine oil temperature in Â°C (mode 2)");
            AddMeasure("015D", "Fuel injection timing in Â° (mode 2)");
            AddMeasure("015E", "Fuel consumption in litre/hr (mode 2)");
            AddMeasure("015F", "Fuel consumption in litre/hr (mode 2)");
            AddMeasure("0160", "List of PIDs supported (range 97 to 128) (mode 2)");
            AddMeasure("0161", "Driver demand: torque percentage (%) (mode 2)");
            AddMeasure("0162", "Final engine torque percentage (%) (mode 2)");
            AddMeasure("0163", "Engine torque reference in Nm (mode 2)");
            AddMeasure("0164", "Engine torque data in % (mode 2)");
            AddMeasure("0165", "Auxiliary inputs / outputs (mode 2)");
            AddMeasure("0166", "Flowmeter sensor (mode 2)");
            AddMeasure("0167", "Engine water temperature in Â°C (mode 2)");
            AddMeasure("0168", "Air temperature sensor in Â°C (mode 2)");
            AddMeasure("0169", "Commanded EGR and EGR error (mode 2)");
            AddMeasure("016A", "Commanded Diesel intake air flow control and relative intake air flow position  (mode 2)");
            AddMeasure("016B", "Recirculation gas temperature in Â°C (mode 2)");
            AddMeasure("016C", "Commanded throttle actuator control and relative throttle position  (mode 2)");
            AddMeasure("016D", "Fuel pressure control system (mode 2)");
            AddMeasure("016E", "Injection pressure control system (mode 2)");
            AddMeasure("016F", "Turbocharger compressor inlet pressure in kPa (mode 2)");
            AddMeasure("0170", "Boost pressure control in kPa (mode 2)");
            AddMeasure("0171", "Variable Geometry turbo (VGT) control (mode 2)");
            AddMeasure("0172", "Wastegate control (mode 2)");
            AddMeasure("0173", "Exhaust pressure in kPa (mode 2)");
            AddMeasure("0174", "Turbocharger RPM (mode 2)");
            AddMeasure("0175", "Turbocharger A temperature in Â°C (mode 2)");
            AddMeasure("0176", "Turbocharger B temperature in Â°C (mode 2)");
            AddMeasure("0177", "Charge air cooler temperature in Â°C (mode 2)");
            AddMeasure("0178", "Exhaust Gas temperature (EGT) Bank 1 (mode 2)");
            AddMeasure("0179", "Exhaust Gas temperature (EGT) Bank 2 (mode 2)");
            AddMeasure("017A", "Diesel particulate filter (DPF) bank 1 (mode 2)");
            AddMeasure("017B", "Diesel particulate filter (DPF) bank 2 (mode 2)");
            AddMeasure("017C", "Diesel Particulate filter (DPF) temperature (mode 2)");
            AddMeasure("017D", "NOx NTE control area status (mode 2)");
            AddMeasure("017E", "PM NTE control area status (mode 2)");
            AddMeasure("017F", "Engine run time (mode 2)");
            AddMeasure("0180", "List of PIDs supported (range 129 to 160) (mode 2)");

            AddMeasure("0500", "List of PIDs supported (range 01 to 32) (mode 5)");
            AddMeasure("0501", "Rich to lean sensor threshold voltage (mode 5)");
            AddMeasure("0502", "Lean to rich sensor threshold voltage (mode 5)");
            AddMeasure("0503", "Low voltage used to calculated passage time (mode 5)");
            AddMeasure("0504", "High voltage used to calculated passage time (mode 5)");
            AddMeasure("0505", "Rich to lean calculated passage time (mode 5)");
            AddMeasure("0506", "Lean to rich calculated passage time (mode 5)");
            AddMeasure("0507", "Minimum sensor voltage during test cycle (mode 5)");
            AddMeasure("0508", "Maximum sensor voltage during test cycle (mode 5)");
            AddMeasure("0509", "Time between sensor transitions (mode 5)");
            AddMeasure("050A", "Sensor period (mode 5)");
            //AddMeasure("050B", "Reserved for future use (mode 5)");
            AddMeasure("060", "List of PIDs supported (range 01h to 20h) (mode 6)");
            AddMeasure("061", "Exhaust gas sensor bank 1 - sensor 1 (mode 6)");
            AddMeasure("062", "Exhaust gas sensor bank 1 - sensor 2 (mode 6)");
            AddMeasure("063", "Exhaust gas sensor bank 1 - sensor 3 (mode 6)");
            AddMeasure("064", "Exhaust gas sensor bank 1 - sensor 4 (mode 6)");
            AddMeasure("065", "Exhaust gas sensor bank 2 - sensor 1 (mode 6)");
            AddMeasure("066", "Exhaust gas sensor bank 2 - sensor 2 (mode 6)");
            AddMeasure("067", "Exhaust gas sensor bank 2 - sensor 3 (mode 6)");
            AddMeasure("068", "Exhaust gas sensor bank 2 - sensor 4 (mode 6)");
            AddMeasure("069", "Exhaust gas sensor bank 3 - sensor 1 (mode 6)");
            AddMeasure("060A", "Exhaust gas sensor bank 3 - sensor 2 (mode 6)");
            AddMeasure("060B", "Exhaust gas sensor bank 3 - sensor 3 (mode 6)");
            AddMeasure("060C", "Exhaust gas sensor bank 3 - sensor 4 (mode 6)");
            AddMeasure("060D", "Exhaust gas sensor bank 4 - sensor 1 (mode 6)");
            AddMeasure("060E", "Exhaust gas sensor bank 4 - sensor 2 (mode 6)");
            AddMeasure("060F", "Exhaust gas sensor bank 4 - sensor 3 (mode 6)");
            AddMeasure("0610", "Exhaust gas sensor bank 4 - sensor 4 (mode 6)");
            AddMeasure("0620", "List of PIDs supported (range 21h to 40h) (mode 6)");
            AddMeasure("0621", "Catalytic bank 1 (mode 6)");
            AddMeasure("0622", "Catalytic bank 2 (mode 6)");
            AddMeasure("0623", "Catalytic bank 3 (mode 6)");
            AddMeasure("0624", "Catalytic bank 4 (mode 6)");
            AddMeasure("0631", "EGR bank 1 (mode 6)");
            AddMeasure("0632", "EGR bank 2 (mode 6)");
            AddMeasure("0633", "EGR bank 3 (mode 6)");
            AddMeasure("0634", "EGR bank 4 (mode 6)");
            AddMeasure("0635", "VVT bank 1 (mode 6)");
            AddMeasure("0636", "VVT bank 2 (mode 6)");
            AddMeasure("0637", "VVT bank 3 (mode 6)");
            AddMeasure("0638", "VVT bank 4 (mode 6)");
            AddMeasure("0639", "EVAP (Cap Off / 0.150) (mode 6)");
            AddMeasure("063A", "EVAP (0.090)(mode 6)");
            AddMeasure("063B", "EVAP (0.040)(mode 6)");
            AddMeasure("063C", "EVAP (0.020)(mode 6)");
            AddMeasure("063D", "Flux de purge (mode 6)");
            AddMeasure("0640", "List of PIDs supported (range 41h to 60h) (mode 6)");
            AddMeasure("0641", "Heated exhaust gas sensor bank 1 - sensor 1 (mode 6)");
            AddMeasure("0642", "Heated exhaust gas sensor bank 1 - sensor 2 (mode 6)");
            AddMeasure("0643", "Heated exhaust gas sensor bank 1 - sensor 3 (mode 6)");
            AddMeasure("0644", "Heated exhaust gas sensor bank 1 - sensor 4 (mode 6)");
            AddMeasure("0645", "Heated exhaust gas sensor bank 2 - sensor 1 (mode 6)");
            AddMeasure("0646", "Heated exhaust gas sensor bank 2 - sensor 2 (mode 6)");
            AddMeasure("0647", "Heated exhaust gas sensor bank 2 - sensor 3 (mode 6)");
            AddMeasure("0648", "Heated exhaust gas sensor bank 2 - sensor 4 (mode 6)");
            AddMeasure("0649", "Heated exhaust gas sensor bank 3 - sensor 1 (mode 6)");
            AddMeasure("064A", "Heated exhaust gas sensor bank 3 - sensor 2 (mode 6)");
            AddMeasure("064B", "Heated exhaust gas sensor bank 3 - sensor 3 (mode 6)");
            AddMeasure("064C", "Heated exhaust gas sensor bank 3 - sensor 4 (mode 6)");
            AddMeasure("064D", "Heated exhaust gas sensor bank 4 - sensor 1 (mode 6)");
            AddMeasure("064E", "Heated exhaust gas sensor bank 4 - sensor 2 (mode 6)");
            AddMeasure("064F", "Heated exhaust gas sensor bank 4 - sensor 3 (mode 6)");
            AddMeasure("0650", "Heated exhaust gas sensor bank 4 - sensor 4 (mode 6)");
            AddMeasure("0660", "List of PIDs supported (range 61h to 80h) (mode 6)");
            AddMeasure("0661", "Heated catalyst bank 1 (mode 6)");
            AddMeasure("0662", "Heated catalyst bank 2 (mode 6)");
            AddMeasure("0663", "Heated catalyst bank 3 (mode 6)");
            AddMeasure("0664", "Heated catalyst bank 4 (mode 6)");
            AddMeasure("0671", "Secondary air 1 (mode 6)");
            AddMeasure("0672", "Secondary air 2 (mode 6)");
            AddMeasure("0673", "Secondary air 3 (mode 6)");
            AddMeasure("0674", "Secondary air 4 (mode 6)");
            AddMeasure("0680", "List of PIDs supported (range 81h to A0h) (mode 6)");
            AddMeasure("0681", "Fuel system bank 1 (mode 6)");
            AddMeasure("0682", "Fuel system bank 2 (mode 6)");
            AddMeasure("0683", "Fuel system bank 3 (mode 6)");
            AddMeasure("0684", "Fuel system bank 4 (mode 6)");
            AddMeasure("0685", "Turbo pressure bank 1 (mode 6)");
            AddMeasure("0686", "Turbo pressure bank 2 (mode 6)");
            AddMeasure("0690", "Nox Absorber bank 1 (mode 6)");
            AddMeasure("0691", "Nox Absorber bank 2 (mode 6)");
            AddMeasure("0698", "Catalytic NOx bank 1 (mode 6)");
            AddMeasure("0699", "Catalytic NOx bank 2 (mode 6)");
            AddMeasure("06A0", "List of PIDs supported (range A1h to C0h) (mode 6)");
            AddMeasure("06A1", "General misfire monitoring data (mode 6)");
            AddMeasure("06A2", "Misfire data cylinder 1 (mode 6)");
            AddMeasure("06A3", "Misfire data cylinder 2 (mode 6)");
            AddMeasure("06A4", "Misfire data cylinder 3 (mode 6)");
            AddMeasure("06A5", "Misfire data cylinder 4 (mode 6)");
            AddMeasure("06A6", "Misfire data cylinder 5 (mode 6)");
            AddMeasure("06A7", "Misfire data cylinder 6 (mode 6)");
            AddMeasure("06A8", "Misfire data cylinder 7 (mode 6)");
            AddMeasure("06A9", "Misfire data cylinder 8 (mode 6)");
            AddMeasure("06AA", "Misfire data cylinder 9 (mode 6)");
            AddMeasure("06AB", "Misfire data cylinder 10 (mode 6)");
            AddMeasure("06AC", "Misfire data cylinder 11 (mode 6)");
            AddMeasure("06AD", "Misfire data cylinder 12 (mode 6)");
            AddMeasure("06AE", "Misfire data cylinder 13 (mode 6)");
            AddMeasure("06AF", "Misfire data cylinder 14 (mode 6)");
            AddMeasure("06B0", "Misfire data cylinder 15 (mode 6)");
            AddMeasure("06B1", "Misfire data cylinder 16 (mode 6)");
            AddMeasure("06B2", "PM filter bank 1 (mode 6)");
            AddMeasure("06B3", "PM filter bank 2 (mode 6)");
            AddMeasure("06C0", "List of PIDs supported (range C1h to E0h) (mode 6)");
            AddMeasure("06E0", "List of PIDs supported (range E1h to FFh) (mode 6)");
            AddMeasure("06E1-FF", "Manufacturer specific (mode 6)");
            AddMeasure("0900", "List of PIDs supported (range 01h to 20h) (mode 9)");
            AddMeasure("0901", "VIN message count (mode 9)");
            AddMeasure("0902", "VIN (vehicle identification number) (mode 9)");
            AddMeasure("0903", "Calibration ID message count (mode 9)");
            AddMeasure("0904", "Calibration IDs (mode 9)");
            AddMeasure("0905", "CALIB verification numbers message count (mode 9)");
            AddMeasure("0906", "Calibration verification number (mode 9)");
            AddMeasure("0907", "IPT message count (mode 9)");
            AddMeasure("0908", "In-use performance tracking (IPT) (mode 9)");
            AddMeasure("0909", "ECU name message count (mode 9)");
            AddMeasure("090A", "ECU name  (mode 9)");
            AddMeasure("090B", "In-use performance tracking   (mode 9)");
            //AddMeasure("090C-FF", "ISO/SAE reserved (mode 9)");
        }

        private void AddMeasure(string pid, string name)
        {
            PIDs.Add(new PID() { IsMeasure = true, PIDValue = pid, PidName = name });
        }

        public List<IPID> PIDs { get; set; }
    }
}