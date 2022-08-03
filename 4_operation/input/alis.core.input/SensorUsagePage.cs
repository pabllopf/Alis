// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   SensorUsagePage.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Input;

namespace DevDecoder.HIDDevices.Pages
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class SensorUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of Sensor Usage Page.
        /// </summary>
        public static readonly SensorUsagePage Instance = new SensorUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="SensorUsagePage" /> class
        /// </summary>
        private SensorUsagePage() : base(0x0020, "Sensor")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Sensor", UsageTypes.CA | UsageTypes.CP);
                case 0x0010: return new Usage(this, id, "Biometric", UsageTypes.CA | UsageTypes.CP);
                case 0x0011: return new Usage(this, id, "Biometric: Human Presence", UsageTypes.CA | UsageTypes.CP);
                case 0x0012: return new Usage(this, id, "Biometric: Human Proximity", UsageTypes.CA | UsageTypes.CP);
                case 0x0013: return new Usage(this, id, "Biometric: Human Touch", UsageTypes.CA | UsageTypes.CP);
                case 0x0014: return new Usage(this, id, "Biometric: Blood Pressure", UsageTypes.CA | UsageTypes.CP);
                case 0x0015: return new Usage(this, id, "Biometric: Body Temperature", UsageTypes.CA | UsageTypes.CP);
                case 0x0016: return new Usage(this, id, "Biometric: Heart Rate", UsageTypes.CA | UsageTypes.CP);
                case 0x0017:
                    return new Usage(this, id, "Biometric: Heart Rate Variability", UsageTypes.CA | UsageTypes.CP);
                case 0x0018:
                    return new Usage(this, id, "Biometric: Peripheral Oxygen Saturation",
                        UsageTypes.CA | UsageTypes.CP);
                case 0x0019: return new Usage(this, id, "Biometric: Respiratory Rate", UsageTypes.CA | UsageTypes.CP);
                case 0x0020: return new Usage(this, id, "Electrical", UsageTypes.CA | UsageTypes.CP);
                case 0x0021: return new Usage(this, id, "Electrical: Capacitance", UsageTypes.CA | UsageTypes.CP);
                case 0x0022: return new Usage(this, id, "Electrical: Current", UsageTypes.CA | UsageTypes.CP);
                case 0x0023: return new Usage(this, id, "Electrical: Power", UsageTypes.CA | UsageTypes.CP);
                case 0x0024: return new Usage(this, id, "Electrical: Inductance", UsageTypes.CA | UsageTypes.CP);
                case 0x0025: return new Usage(this, id, "Electrical: Resistance", UsageTypes.CA | UsageTypes.CP);
                case 0x0026: return new Usage(this, id, "Electrical: Voltage", UsageTypes.CA | UsageTypes.CP);
                case 0x0027: return new Usage(this, id, "Electrical: Potentiometer", UsageTypes.CA | UsageTypes.CP);
                case 0x0028: return new Usage(this, id, "Electrical: Frequency", UsageTypes.CA | UsageTypes.CP);
                case 0x0029: return new Usage(this, id, "Electrical: Period", UsageTypes.CA | UsageTypes.CP);
                case 0x0030: return new Usage(this, id, "Environmental", UsageTypes.CA | UsageTypes.CP);
                case 0x0031:
                    return new Usage(this, id, "Environmental: Atmospheric Pressure", UsageTypes.CA | UsageTypes.CP);
                case 0x0032: return new Usage(this, id, "Environmental: Humidity", UsageTypes.CA | UsageTypes.CP);
                case 0x0033: return new Usage(this, id, "Environmental: Temperature", UsageTypes.CA | UsageTypes.CP);
                case 0x0034: return new Usage(this, id, "Environmental: Wind Direction", UsageTypes.CA | UsageTypes.CP);
                case 0x0035: return new Usage(this, id, "Environmental: Wind Speed", UsageTypes.CA | UsageTypes.CP);
                case 0x0036: return new Usage(this, id, "Environmental: Air Quality", UsageTypes.CA | UsageTypes.CP);
                case 0x0037: return new Usage(this, id, "Environmental: Heat Index", UsageTypes.CA | UsageTypes.CP);
                case 0x0038:
                    return new Usage(this, id, "Environmental: Surface Temperature", UsageTypes.CA | UsageTypes.CP);
                case 0x0039:
                    return new Usage(this, id, "Environmental: Volatile Organic Compounds",
                        UsageTypes.CA | UsageTypes.CP);
                case 0x003a:
                    return new Usage(this, id, "Environmental: Object Presence", UsageTypes.CA | UsageTypes.CP);
                case 0x003b:
                    return new Usage(this, id, "Environmental: Object Proximity", UsageTypes.CA | UsageTypes.CP);
                case 0x0040: return new Usage(this, id, "Light", UsageTypes.CA | UsageTypes.CP);
                case 0x0041: return new Usage(this, id, "Light: Ambient Light", UsageTypes.CA | UsageTypes.CP);
                case 0x0042: return new Usage(this, id, "Light: Consumer Infrared", UsageTypes.CA | UsageTypes.CP);
                case 0x0043: return new Usage(this, id, "Light: Infrared Light", UsageTypes.CA | UsageTypes.CP);
                case 0x0044: return new Usage(this, id, "Light: Visible Light", UsageTypes.CA | UsageTypes.CP);
                case 0x0045: return new Usage(this, id, "Light: Ultraviolet Light", UsageTypes.CA | UsageTypes.CP);
                case 0x0050: return new Usage(this, id, "Location", UsageTypes.CA | UsageTypes.CP);
                case 0x0051: return new Usage(this, id, "Location: Broadcast", UsageTypes.CA | UsageTypes.CP);
                case 0x0052: return new Usage(this, id, "Location: Dead Reckoning", UsageTypes.CA | UsageTypes.CP);
                case 0x0053: return new Usage(this, id, "Location: GPS", UsageTypes.CA | UsageTypes.CP);
                case 0x0054: return new Usage(this, id, "Location: Lookup", UsageTypes.CA | UsageTypes.CP);
                case 0x0055: return new Usage(this, id, "Location: Other", UsageTypes.CA | UsageTypes.CP);
                case 0x0056: return new Usage(this, id, "Location: Static", UsageTypes.CA | UsageTypes.CP);
                case 0x0057: return new Usage(this, id, "Location: Triangulation", UsageTypes.CA | UsageTypes.CP);
                case 0x0060: return new Usage(this, id, "Mechanical", UsageTypes.CA | UsageTypes.CP);
                case 0x0061: return new Usage(this, id, "Mechanical: Boolean Switch", UsageTypes.CA | UsageTypes.CP);
                case 0x0062:
                    return new Usage(this, id, "Mechanical: Boolean Switch Array", UsageTypes.CA | UsageTypes.CP);
                case 0x0063: return new Usage(this, id, "Mechanical: Multivalue Switch", UsageTypes.CA | UsageTypes.CP);
                case 0x0064: return new Usage(this, id, "Mechanical: Force", UsageTypes.CA | UsageTypes.CP);
                case 0x0065: return new Usage(this, id, "Mechanical: Pressure", UsageTypes.CA | UsageTypes.CP);
                case 0x0066: return new Usage(this, id, "Mechanical: Strain", UsageTypes.CA | UsageTypes.CP);
                case 0x0067: return new Usage(this, id, "Mechanical: Weight", UsageTypes.CA | UsageTypes.CP);
                case 0x0068: return new Usage(this, id, "Mechanical: Haptic Vibrator", UsageTypes.CA | UsageTypes.CP);
                case 0x0069:
                    return new Usage(this, id, "Mechanical: Hall Effect Switch", UsageTypes.CA | UsageTypes.CP);
                case 0x0070: return new Usage(this, id, "Motion", UsageTypes.CA | UsageTypes.CP);
                case 0x0071: return new Usage(this, id, "Motion: Accelerometer 1D", UsageTypes.CA | UsageTypes.CP);
                case 0x0072: return new Usage(this, id, "Motion: Accelerometer 2D", UsageTypes.CA | UsageTypes.CP);
                case 0x0073: return new Usage(this, id, "Motion: Accelerometer 3D", UsageTypes.CA | UsageTypes.CP);
                case 0x0074: return new Usage(this, id, "Motion: Gyrometer 1D", UsageTypes.CA | UsageTypes.CP);
                case 0x0075: return new Usage(this, id, "Motion: Gyrometer 2D", UsageTypes.CA | UsageTypes.CP);
                case 0x0076: return new Usage(this, id, "Motion: Gyrometer 3D", UsageTypes.CA | UsageTypes.CP);
                case 0x0077: return new Usage(this, id, "Motion: Motion Detector", UsageTypes.CA | UsageTypes.CP);
                case 0x0078: return new Usage(this, id, "Motion: Speedometer", UsageTypes.CA | UsageTypes.CP);
                case 0x0079: return new Usage(this, id, "Motion: Accelerometer", UsageTypes.CA | UsageTypes.CP);
                case 0x007a: return new Usage(this, id, "Motion: Gyrometer", UsageTypes.CA | UsageTypes.CP);
                case 0x007b: return new Usage(this, id, "Motion: Gravity Vector", UsageTypes.CA | UsageTypes.CP);
                case 0x007c: return new Usage(this, id, "Motion: Linear Accelerometer", UsageTypes.CA | UsageTypes.CP);
                case 0x0080: return new Usage(this, id, "Orientation", UsageTypes.CA | UsageTypes.CP);
                case 0x0081: return new Usage(this, id, "Orientation: Compass 1D", UsageTypes.CA | UsageTypes.CP);
                case 0x0082: return new Usage(this, id, "Orientation: Compass 2D", UsageTypes.CA | UsageTypes.CP);
                case 0x0083: return new Usage(this, id, "Orientation: Compass 3D", UsageTypes.CA | UsageTypes.CP);
                case 0x0084: return new Usage(this, id, "Orientation: Inclinometer 1D", UsageTypes.CA | UsageTypes.CP);
                case 0x0085: return new Usage(this, id, "Orientation: Inclinometer 2D", UsageTypes.CA | UsageTypes.CP);
                case 0x0086: return new Usage(this, id, "Orientation: Inclinometer 3D", UsageTypes.CA | UsageTypes.CP);
                case 0x0087: return new Usage(this, id, "Orientation: Distance 1D", UsageTypes.CA | UsageTypes.CP);
                case 0x0088: return new Usage(this, id, "Orientation: Distance 2D", UsageTypes.CA | UsageTypes.CP);
                case 0x0089: return new Usage(this, id, "Orientation: Distance 3D", UsageTypes.CA | UsageTypes.CP);
                case 0x008a:
                    return new Usage(this, id, "Orientation: Device Orientation", UsageTypes.CA | UsageTypes.CP);
                case 0x008b: return new Usage(this, id, "Orientation: Compass", UsageTypes.CA | UsageTypes.CP);
                case 0x008c: return new Usage(this, id, "Orientation: Inclinometer", UsageTypes.CA | UsageTypes.CP);
                case 0x008d: return new Usage(this, id, "Orientation: Distance", UsageTypes.CA | UsageTypes.CP);
                case 0x008e:
                    return new Usage(this, id, "Orientation: Relative Orientation", UsageTypes.CA | UsageTypes.CP);
                case 0x008f:
                    return new Usage(this, id, "Orientation: Simple Orientation", UsageTypes.CA | UsageTypes.CP);
                case 0x0090: return new Usage(this, id, "Scanner", UsageTypes.CA | UsageTypes.CP);
                case 0x0091: return new Usage(this, id, "Scanner: Barcode", UsageTypes.CA | UsageTypes.CP);
                case 0x0092: return new Usage(this, id, "Scanner: RFID", UsageTypes.CA | UsageTypes.CP);
                case 0x0093: return new Usage(this, id, "Scanner: NFC", UsageTypes.CA | UsageTypes.CP);
                case 0x00a0: return new Usage(this, id, "Time", UsageTypes.CA | UsageTypes.CP);
                case 0x00a1: return new Usage(this, id, "Time: Alarm Timer", UsageTypes.CA | UsageTypes.CP);
                case 0x00a2: return new Usage(this, id, "Time: Real Time Clock", UsageTypes.CA | UsageTypes.CP);
                case 0x00b0: return new Usage(this, id, "Personal Activity", UsageTypes.CA | UsageTypes.CP);
                case 0x00b1:
                    return new Usage(this, id, "Personal Activity: Activity Detection", UsageTypes.CA | UsageTypes.CP);
                case 0x00b2:
                    return new Usage(this, id, "Personal Activity: Device Position", UsageTypes.CA | UsageTypes.CP);
                case 0x00b3: return new Usage(this, id, "Personal Activity: Pedometer", UsageTypes.CA | UsageTypes.CP);
                case 0x00b4:
                    return new Usage(this, id, "Personal Activity: Step Detection", UsageTypes.CA | UsageTypes.CP);
                case 0x00c0: return new Usage(this, id, "Orientation Extended", UsageTypes.CA | UsageTypes.CP);
                case 0x00c1:
                    return new Usage(this, id, "Orientation Extended: Geomagnetic Orientation",
                        UsageTypes.CA | UsageTypes.CP);
                case 0x00c2:
                    return new Usage(this, id, "Orientation Extended: Magnetometer", UsageTypes.CA | UsageTypes.CP);
                case 0x00d0: return new Usage(this, id, "Gesture", UsageTypes.CA | UsageTypes.CP);
                case 0x00d1: return new Usage(this, id, "Gesture: Chassis Flip Gesture", UsageTypes.CA | UsageTypes.CP);
                case 0x00d2: return new Usage(this, id, "Gesture: Hinge Fold Gesture", UsageTypes.CA | UsageTypes.CP);
                case 0x00e0: return new Usage(this, id, "Other", UsageTypes.CA | UsageTypes.CP);
                case 0x00e1: return new Usage(this, id, "Other: Custom", UsageTypes.CA | UsageTypes.CP);
                case 0x00e2: return new Usage(this, id, "Other: Generic", UsageTypes.CA | UsageTypes.CP);
                case 0x00e3: return new Usage(this, id, "Other: Generic Enumerator", UsageTypes.CA | UsageTypes.CP);
                case 0x00e4: return new Usage(this, id, "Other: Hinge Angle", UsageTypes.CA | UsageTypes.CP);
                case 0x00f0: return new Usage(this, id, "Vendor Reserved 1", UsageTypes.CA | UsageTypes.CP);
                case 0x00f1: return new Usage(this, id, "Vendor Reserved 2", UsageTypes.CA | UsageTypes.CP);
                case 0x00f2: return new Usage(this, id, "Vendor Reserved 3", UsageTypes.CA | UsageTypes.CP);
                case 0x00f3: return new Usage(this, id, "Vendor Reserved 4", UsageTypes.CA | UsageTypes.CP);
                case 0x00f4: return new Usage(this, id, "Vendor Reserved 5", UsageTypes.CA | UsageTypes.CP);
                case 0x00f5: return new Usage(this, id, "Vendor Reserved 6", UsageTypes.CA | UsageTypes.CP);
                case 0x00f6: return new Usage(this, id, "Vendor Reserved 7", UsageTypes.CA | UsageTypes.CP);
                case 0x00f7: return new Usage(this, id, "Vendor Reserved 8", UsageTypes.CA | UsageTypes.CP);
                case 0x00f8: return new Usage(this, id, "Vendor Reserved 9", UsageTypes.CA | UsageTypes.CP);
                case 0x00f9: return new Usage(this, id, "Vendor Reserved 10", UsageTypes.CA | UsageTypes.CP);
                case 0x00fa: return new Usage(this, id, "Vendor Reserved 11", UsageTypes.CA | UsageTypes.CP);
                case 0x00fb: return new Usage(this, id, "Vendor Reserved 12", UsageTypes.CA | UsageTypes.CP);
                case 0x00fc: return new Usage(this, id, "Vendor Reserved 13", UsageTypes.CA | UsageTypes.CP);
                case 0x00fd: return new Usage(this, id, "Vendor Reserved 14", UsageTypes.CA | UsageTypes.CP);
                case 0x00fe: return new Usage(this, id, "Vendor Reserved 15", UsageTypes.CA | UsageTypes.CP);
                case 0x00ff: return new Usage(this, id, "Vendor Reserved 16", UsageTypes.CA | UsageTypes.CP);
                case 0x0201: return new Usage(this, id, "Event: Sensor State", UsageTypes.NAry);
                case 0x0202: return new Usage(this, id, "Event: Sensor Event", UsageTypes.NAry);
                case 0x0300: return new Usage(this, id, "Property", UsageTypes.DV);
                case 0x0301: return new Usage(this, id, "Property: Friendly Name", UsageTypes.SV);
                case 0x0302: return new Usage(this, id, "Property: Persistent Unique ID", UsageTypes.DV);
                case 0x0303: return new Usage(this, id, "Property: Sensor Status", UsageTypes.DV);
                case 0x0304: return new Usage(this, id, "Property: Minimum Report Interval", UsageTypes.SV);
                case 0x0305: return new Usage(this, id, "Property: Sensor Manufacturer", UsageTypes.SV);
                case 0x0306: return new Usage(this, id, "Property: Sensor Model", UsageTypes.SV);
                case 0x0307: return new Usage(this, id, "Property: Sensor Serial Number", UsageTypes.SV);
                case 0x0308: return new Usage(this, id, "Property: Sensor Description", UsageTypes.SV);
                case 0x0309: return new Usage(this, id, "Property: Sensor Connection Type", UsageTypes.NAry);
                case 0x030a: return new Usage(this, id, "Property: Sensor Device Path", UsageTypes.DV);
                case 0x030b: return new Usage(this, id, "Property: Sensor Hardware Revision", UsageTypes.SV);
                case 0x030c: return new Usage(this, id, "Property: Sensor Firmware Revision", UsageTypes.SV);
                case 0x030d: return new Usage(this, id, "Property: Release Date", UsageTypes.SV);
                case 0x030e: return new Usage(this, id, "Property: Report Interval", UsageTypes.DV);
                case 0x030f: return new Usage(this, id, "Property: Change Sensitivity Absolute", UsageTypes.DV);
                case 0x0310: return new Usage(this, id, "Property: Change Sensitivity Percent of Range", UsageTypes.DV);
                case 0x0311: return new Usage(this, id, "Property: Change Sensitivity Percent Relative", UsageTypes.DV);
                case 0x0312: return new Usage(this, id, "Property: Accuracy", UsageTypes.DV);
                case 0x0313: return new Usage(this, id, "Property: Resolution", UsageTypes.DV);
                case 0x0314: return new Usage(this, id, "Property: Maximum", UsageTypes.DV);
                case 0x0315: return new Usage(this, id, "Property: Minimum", UsageTypes.DV);
                case 0x0316: return new Usage(this, id, "Property: Reporting State", UsageTypes.NAry);
                case 0x0317: return new Usage(this, id, "Property: Sampling Rate", UsageTypes.DV);
                case 0x0318: return new Usage(this, id, "Property: Response Curve", UsageTypes.DV);
                case 0x0319: return new Usage(this, id, "Property: Power State", UsageTypes.NAry);
                case 0x031a: return new Usage(this, id, "Property: Maximum FIFO Events", UsageTypes.SV);
                case 0x031b: return new Usage(this, id, "Property: Report Latency", UsageTypes.DV);
                case 0x031c: return new Usage(this, id, "Property: Flush FIFO Events", UsageTypes.DF);
                case 0x031d: return new Usage(this, id, "Property: Maximum Power Consumption", UsageTypes.DV);
                case 0x031e: return new Usage(this, id, "Property: Is Primary", UsageTypes.DF);
                case 0x031f: return new Usage(this, id, "Property: Human Presence Detection Type", UsageTypes.NAry);
                case 0x0400: return new Usage(this, id, "Data Field: Location", UsageTypes.SV);
                case 0x0402: return new Usage(this, id, "Data Field: Altitude Antenna Sea Level", UsageTypes.SV);
                case 0x0403: return new Usage(this, id, "Data Field: Differential Reference Station ID", UsageTypes.SV);
                case 0x0404: return new Usage(this, id, "Data Field: Altitude Ellipsoid Error", UsageTypes.SV);
                case 0x0405: return new Usage(this, id, "Data Field: Altitude Ellipsoid", UsageTypes.SV);
                case 0x0406: return new Usage(this, id, "Data Field: Altitude Sea Level Error", UsageTypes.SV);
                case 0x0407: return new Usage(this, id, "Data Field: Altitude Sea Level", UsageTypes.SV);
                case 0x0408: return new Usage(this, id, "Data Field: Differential GPS Data Age", UsageTypes.SV);
                case 0x0409: return new Usage(this, id, "Data Field: Error Radius", UsageTypes.SV);
                case 0x040a: return new Usage(this, id, "Data Field: Fix Quality", UsageTypes.NAry);
                case 0x040b: return new Usage(this, id, "Data Field: Fix Type", UsageTypes.NAry);
                case 0x040c: return new Usage(this, id, "Data Field: Geoidal Separation", UsageTypes.SV);
                case 0x040d: return new Usage(this, id, "Data Field: GPS Operation Mode", UsageTypes.NAry);
                case 0x040e: return new Usage(this, id, "Data Field: GPS Selection Mode", UsageTypes.NAry);
                case 0x040f: return new Usage(this, id, "Data Field: GPS Status", UsageTypes.NAry);
                case 0x0410: return new Usage(this, id, "Data Field: Position Dilution of Precision", UsageTypes.SV);
                case 0x0411: return new Usage(this, id, "Data Field: Horizontal Dilution of Precision", UsageTypes.SV);
                case 0x0412: return new Usage(this, id, "Data Field: Vertical Dilution of Precision", UsageTypes.SV);
                case 0x0413: return new Usage(this, id, "Data Field: Latitude", UsageTypes.SV);
                case 0x0414: return new Usage(this, id, "Data Field: Longitude", UsageTypes.SV);
                case 0x0415: return new Usage(this, id, "Data Field: True Heading", UsageTypes.SV);
                case 0x0416: return new Usage(this, id, "Data Field: Magnetic Heading", UsageTypes.SV);
                case 0x0417: return new Usage(this, id, "Data Field: Magnetic Variation", UsageTypes.SV);
                case 0x0418: return new Usage(this, id, "Data Field: Speed", UsageTypes.SV);
                case 0x0419: return new Usage(this, id, "Data Field: Satellites in View", UsageTypes.SV);
                case 0x041a: return new Usage(this, id, "Data Field: Satellites in View Azimuth", UsageTypes.SV);
                case 0x041b: return new Usage(this, id, "Data Field: Satellites in View Elevation", UsageTypes.SV);
                case 0x041c: return new Usage(this, id, "Data Field: Satellites in View IDs", UsageTypes.SV);
                case 0x041d: return new Usage(this, id, "Data Field: Satellites in View PRNs", UsageTypes.SV);
                case 0x041e: return new Usage(this, id, "Data Field: Satellites in View S/N Ratios", UsageTypes.SV);
                case 0x041f: return new Usage(this, id, "Data Field: Satellites Used Count", UsageTypes.SV);
                case 0x0420: return new Usage(this, id, "Data Field: Satellites Used PRNs", UsageTypes.SV);
                case 0x0421: return new Usage(this, id, "Data Field: NMEA Sentence", UsageTypes.SV);
                case 0x0422: return new Usage(this, id, "Data Field: Address Line 1", UsageTypes.SV);
                case 0x0423: return new Usage(this, id, "Data Field: Address Line 2", UsageTypes.SV);
                case 0x0424: return new Usage(this, id, "Data Field: City", UsageTypes.SV);
                case 0x0425: return new Usage(this, id, "Data Field: State or Province", UsageTypes.SV);
                case 0x0426: return new Usage(this, id, "Data Field: Country or Region (ISO 3166)", UsageTypes.SV);
                case 0x0427: return new Usage(this, id, "Data Field: Postal Code", UsageTypes.SV);
                case 0x042b: return new Usage(this, id, "Property: Location Desired Accuracy", UsageTypes.NAry);
                case 0x0430: return new Usage(this, id, "Data Field: Environmental", UsageTypes.SV);
                case 0x0431: return new Usage(this, id, "Data Field: Atmospheric Pressure", UsageTypes.SV);
                case 0x0433: return new Usage(this, id, "Data Field: Relative Humidity", UsageTypes.SV);
                case 0x0434: return new Usage(this, id, "Data Field: Temperature", UsageTypes.SV);
                case 0x0435: return new Usage(this, id, "Data Field: Wind Direction", UsageTypes.SV);
                case 0x0436: return new Usage(this, id, "Data Field: Wind Speed", UsageTypes.SV);
                case 0x0437: return new Usage(this, id, "Data Field: Air Quality Index", UsageTypes.SV);
                case 0x0438: return new Usage(this, id, "Data Field: Equivalent CO2", UsageTypes.SV);
                case 0x0439:
                    return new Usage(this, id, "Data Field: Volatile Organic Compound Concentration", UsageTypes.SV);
                case 0x043a: return new Usage(this, id, "Data Field: Object Presence", UsageTypes.SF);
                case 0x043b: return new Usage(this, id, "Data Field: Object Proximity Range", UsageTypes.SV);
                case 0x043c: return new Usage(this, id, "Data Field: Object Proximity Out of Range", UsageTypes.SF);
                case 0x0440: return new Usage(this, id, "Property: Environmental", UsageTypes.SV);
                case 0x0441:
                    return new Usage(this, id, "Property: Reference Pressure (default Sel \"Unit: bars)",
                        UsageTypes.SV);
                case 0x0450: return new Usage(this, id, "Data Field: Motion", UsageTypes.SV);
                case 0x0451: return new Usage(this, id, "Data Field: Motion State", UsageTypes.SF);
                case 0x0452: return new Usage(this, id, "Data Field: Acceleration", UsageTypes.SV);
                case 0x0453: return new Usage(this, id, "Data Field: Acceleration Axis X", UsageTypes.SV);
                case 0x0454: return new Usage(this, id, "Data Field: Acceleration Axis Y", UsageTypes.SV);
                case 0x0455: return new Usage(this, id, "Data Field: Acceleration Axis Z", UsageTypes.SV);
                case 0x0456: return new Usage(this, id, "Data Field: Angular Velocity", UsageTypes.SV);
                case 0x0457: return new Usage(this, id, "Data Field: Angular Velocity X about Axis", UsageTypes.SV);
                case 0x0458: return new Usage(this, id, "Data Field: Angular Velocity Y about Axis", UsageTypes.SV);
                case 0x0459: return new Usage(this, id, "Data Field: Angular Velocity Z about Axis", UsageTypes.SV);
                case 0x045a: return new Usage(this, id, "Data Field: Angular Position", UsageTypes.SV);
                case 0x045b: return new Usage(this, id, "Data Field: Angular Position about X Axis", UsageTypes.SV);
                case 0x045c: return new Usage(this, id, "Data Field: Angular Position about Y Axis", UsageTypes.SV);
                case 0x045d: return new Usage(this, id, "Data Field: Angular Position about Z Axis", UsageTypes.SV);
                case 0x045e: return new Usage(this, id, "Data Field: Motion Speed", UsageTypes.SV);
                case 0x045f: return new Usage(this, id, "Data Field: Motion Intensity (percent)", UsageTypes.SV);
                case 0x0470: return new Usage(this, id, "Data Field: Orientation", UsageTypes.SV);
                case 0x0471: return new Usage(this, id, "Data Field: Heading", UsageTypes.SV);
                case 0x0472: return new Usage(this, id, "Data Field: Heading X Axis", UsageTypes.SV);
                case 0x0473: return new Usage(this, id, "Data Field: Heading Y Axis", UsageTypes.SV);
                case 0x0474: return new Usage(this, id, "Data Field: Heading Z Axis", UsageTypes.SV);
                case 0x0475:
                    return new Usage(this, id, "Data Field: Heading Compensated Magnetic North", UsageTypes.SV);
                case 0x0476: return new Usage(this, id, "Data Field: Heading Compensated True North", UsageTypes.SV);
                case 0x0477: return new Usage(this, id, "Data Field: Heading Magnetic North", UsageTypes.SV);
                case 0x0478: return new Usage(this, id, "Data Field: Heading True North", UsageTypes.SV);
                case 0x0479: return new Usage(this, id, "Data Field: Distance", UsageTypes.SV);
                case 0x047a: return new Usage(this, id, "Data Field: Distance X Axis", UsageTypes.SV);
                case 0x047b: return new Usage(this, id, "Data Field: Distance Y Axis", UsageTypes.SV);
                case 0x047c: return new Usage(this, id, "Data Field: Distance Z Axis", UsageTypes.SV);
                case 0x047d: return new Usage(this, id, "Data Field: Distance Out-of-Range", UsageTypes.SV);
                case 0x047e: return new Usage(this, id, "Data Field: Tilt", UsageTypes.SV);
                case 0x047f: return new Usage(this, id, "Data Field: Tilt X Axis", UsageTypes.SV);
                case 0x0480: return new Usage(this, id, "Data Field: Tilt Y Axis", UsageTypes.SV);
                case 0x0481: return new Usage(this, id, "Data Field: Tilt Z Axis", UsageTypes.SV);
                case 0x0482: return new Usage(this, id, "Data Field: Rotation Matrix", UsageTypes.SV);
                case 0x0483: return new Usage(this, id, "Data Field: Quaternion", UsageTypes.SV);
                case 0x0484: return new Usage(this, id, "Data Field: Magnetic Flux", UsageTypes.SV);
                case 0x0485: return new Usage(this, id, "Data Field: Magnetic Flux X Axis", UsageTypes.SV);
                case 0x0486: return new Usage(this, id, "Data Field: Magnetic Flux Y Axis", UsageTypes.SV);
                case 0x0487: return new Usage(this, id, "Data Field: Magnetic Flux Z Axis", UsageTypes.SV);
                case 0x0488: return new Usage(this, id, "Data Field: Magnetometer Accuracy", UsageTypes.NAry);
                case 0x0489: return new Usage(this, id, "Data Field: Simple Orientation Direction", UsageTypes.NAry);
                case 0x0490: return new Usage(this, id, "Data Field: Mechanical", UsageTypes.SV);
                case 0x0491: return new Usage(this, id, "Data Field: Boolean Switch State", UsageTypes.SF);
                case 0x0492: return new Usage(this, id, "Data Field: Boolean Switch Array States", UsageTypes.SV);
                case 0x0493: return new Usage(this, id, "Data Field: Multivalue Switch Value", UsageTypes.SV);
                case 0x0494: return new Usage(this, id, "Data Field: Force", UsageTypes.SV);
                case 0x0495: return new Usage(this, id, "Data Field: Absolute Pressure", UsageTypes.SV);
                case 0x0496: return new Usage(this, id, "Data Field: Gauge Pressure", UsageTypes.SV);
                case 0x0497: return new Usage(this, id, "Data Field: Strain", UsageTypes.SV);
                case 0x0498: return new Usage(this, id, "Data Field: Weight", UsageTypes.SV);
                case 0x04a0: return new Usage(this, id, "Property: Mechanical", UsageTypes.SV);
                case 0x04a1: return new Usage(this, id, "Property: Vibration State", UsageTypes.SV);
                case 0x04a2: return new Usage(this, id, "Property: Forward Vibration Speed (percent)", UsageTypes.SV);
                case 0x04a3: return new Usage(this, id, "Property: Backward Vibration Speed (percent)", UsageTypes.SV);
                case 0x04b0: return new Usage(this, id, "Data Field: Biometric", UsageTypes.SV);
                case 0x04b1: return new Usage(this, id, "Data Field: Human Presence", UsageTypes.SF);
                case 0x04b2: return new Usage(this, id, "Data Field: Human Proximity Range", UsageTypes.SV);
                case 0x04b3: return new Usage(this, id, "Data Field: Human Proximity Out of Range", UsageTypes.SF);
                case 0x04b4: return new Usage(this, id, "Data Field: Human Touch State", UsageTypes.SF);
                case 0x04b5: return new Usage(this, id, "Data Field: Blood Pressure", UsageTypes.SV);
                case 0x04b6: return new Usage(this, id, "Data Field: Blood Pressure Diastolic", UsageTypes.SV);
                case 0x04b7: return new Usage(this, id, "Data Field: Blood Pressure Systolic", UsageTypes.SV);
                case 0x04b8: return new Usage(this, id, "Data Field: Heart Rate (HeartbeatsPM)", UsageTypes.SV);
                case 0x04b9: return new Usage(this, id, "Data Field: Resting Heart Rate (HeartbeatsPM)", UsageTypes.SV);
                case 0x04ba: return new Usage(this, id, "Data Field: Heartbeat Interval", UsageTypes.SV);
                case 0x04bb: return new Usage(this, id, "Data Field: Respiratory Rate", UsageTypes.SV);
                case 0x04bc: return new Usage(this, id, "Data Field: SpO2 (percent)", UsageTypes.SV);
                case 0x04bd: return new Usage(this, id, "Data Field: Human Attention Detected", UsageTypes.MC);
                case 0x04d0: return new Usage(this, id, "Data Field: Light", UsageTypes.SV);
                case 0x04d1: return new Usage(this, id, "Data Field: Illuminance", UsageTypes.SV);
                case 0x04d2: return new Usage(this, id, "Data Field: Color Temperature", UsageTypes.SV);
                case 0x04d3: return new Usage(this, id, "Data Field: Chromaticity", UsageTypes.SV);
                case 0x04d4: return new Usage(this, id, "Data Field: Chromaticity X", UsageTypes.SV);
                case 0x04d5: return new Usage(this, id, "Data Field: Chromaticity Y", UsageTypes.SV);
                case 0x04d6: return new Usage(this, id, "Data Field: Consumer IR Sentence Receive", UsageTypes.SV);
                case 0x04d7: return new Usage(this, id, "Data Field: Infrared Light", UsageTypes.SV);
                case 0x04d8: return new Usage(this, id, "Data Field: Red Light", UsageTypes.SV);
                case 0x04d9: return new Usage(this, id, "Data Field: Green Light", UsageTypes.SV);
                case 0x04da: return new Usage(this, id, "Data Field: Blue Light", UsageTypes.SV);
                case 0x04db: return new Usage(this, id, "Data Field: Ultraviolet A Light", UsageTypes.SV);
                case 0x04dc: return new Usage(this, id, "Data Field: Ultraviolet B Light", UsageTypes.SV);
                case 0x04dd: return new Usage(this, id, "Data Field: Ultraviolet Index", UsageTypes.SV);
                case 0x04de: return new Usage(this, id, "Data Field: Near Infrared Light", UsageTypes.SV);
                case 0x04e0: return new Usage(this, id, "Property: Light", UsageTypes.DV);
                case 0x04e1: return new Usage(this, id, "Property: Consumer IR Sentence Send", UsageTypes.DV);
                case 0x04e2: return new Usage(this, id, "Property: Auto Brightness Preferred", UsageTypes.DF);
                case 0x04e3: return new Usage(this, id, "Property: Auto Color Preferred", UsageTypes.DF);
                case 0x04f0: return new Usage(this, id, "Data Field: Scanner", UsageTypes.SV);
                case 0x04f1: return new Usage(this, id, "Data Field: RFID Tag 40 Bit", UsageTypes.SV);
                case 0x04f2: return new Usage(this, id, "Data Field: NFC Sentence Receive", UsageTypes.SV);
                case 0x04f8: return new Usage(this, id, "Property: Scanner", UsageTypes.SV);
                case 0x04f9: return new Usage(this, id, "Property: NFC Sentence Send", UsageTypes.SV);
                case 0x0500: return new Usage(this, id, "Data Field: Electrical", UsageTypes.SV);
                case 0x0501: return new Usage(this, id, "Data Field: Capacitance", UsageTypes.SV);
                case 0x0502: return new Usage(this, id, "Data Field: Current", UsageTypes.SV);
                case 0x0503: return new Usage(this, id, "Data Field: Electrical Power", UsageTypes.SV);
                case 0x0504: return new Usage(this, id, "Data Field: Inductance", UsageTypes.SV);
                case 0x0505: return new Usage(this, id, "Data Field: Resistance", UsageTypes.SV);
                case 0x0506: return new Usage(this, id, "Data Field: Voltage", UsageTypes.SV);
                case 0x0507: return new Usage(this, id, "Data Field: Frequency", UsageTypes.SV);
                case 0x0508: return new Usage(this, id, "Data Field: Period", UsageTypes.SV);
                case 0x0509: return new Usage(this, id, "Data Field: Percent of Range", UsageTypes.SV);
                case 0x0520: return new Usage(this, id, "Data Field: Time", UsageTypes.SV);
                case 0x0521: return new Usage(this, id, "Data Field: Year", UsageTypes.SV);
                case 0x0522: return new Usage(this, id, "Data Field: Month", UsageTypes.SV);
                case 0x0523: return new Usage(this, id, "Data Field: Day", UsageTypes.SV);
                case 0x0524: return new Usage(this, id, "Data Field: Day of Week", UsageTypes.NAry);
                case 0x0526: return new Usage(this, id, "Data Field: Minute", UsageTypes.SV);
                case 0x0527: return new Usage(this, id, "Data Field: Second", UsageTypes.SV);
                case 0x0528: return new Usage(this, id, "Data Field: Millisecond", UsageTypes.SV);
                case 0x0529: return new Usage(this, id, "Data Field: Timestamp", UsageTypes.SV);
                case 0x052a: return new Usage(this, id, "Data Field: Julian Day of Year", UsageTypes.SV);
                case 0x052b: return new Usage(this, id, "Data Field: Time Since System Boot", UsageTypes.SV);
                case 0x0530: return new Usage(this, id, "Property: Time", UsageTypes.DV);
                case 0x0531: return new Usage(this, id, "Property: Time Zone Offset from UTC", UsageTypes.DV);
                case 0x0532: return new Usage(this, id, "Property: Time Zone Name", UsageTypes.DV);
                case 0x0533: return new Usage(this, id, "Property: Daylight Savings Time Observed", UsageTypes.DF);
                case 0x0534: return new Usage(this, id, "Property: Time Trim Adjustment", UsageTypes.DV);
                case 0x0535: return new Usage(this, id, "Property: Arm Alarm", UsageTypes.DF);
                case 0x0540: return new Usage(this, id, "Data Field: Custom", UsageTypes.SV);
                case 0x0541: return new Usage(this, id, "Data Field: Custom Usage", UsageTypes.SV);
                case 0x0542: return new Usage(this, id, "Data Field: Custom Boolean Array", UsageTypes.SV);
                case 0x0543: return new Usage(this, id, "Data Field: Custom Value", UsageTypes.SV);
                case 0x0544: return new Usage(this, id, "Data Field: Custom Value 1", UsageTypes.SV);
                case 0x0545: return new Usage(this, id, "Data Field: Custom Value 2", UsageTypes.SV);
                case 0x0546: return new Usage(this, id, "Data Field: Custom Value 3", UsageTypes.SV);
                case 0x0547: return new Usage(this, id, "Data Field: Custom Value 4", UsageTypes.SV);
                case 0x0548: return new Usage(this, id, "Data Field: Custom Value 5", UsageTypes.SV);
                case 0x0549: return new Usage(this, id, "Data Field: Custom Value 6", UsageTypes.SV);
                case 0x054a: return new Usage(this, id, "Data Field: Custom Value 7", UsageTypes.SV);
                case 0x054b: return new Usage(this, id, "Data Field: Custom Value 8", UsageTypes.SV);
                case 0x054c: return new Usage(this, id, "Data Field: Custom Value 9", UsageTypes.SV);
                case 0x054d: return new Usage(this, id, "Data Field: Custom Value 10", UsageTypes.SV);
                case 0x054e: return new Usage(this, id, "Data Field: Custom Value 11", UsageTypes.SV);
                case 0x054f: return new Usage(this, id, "Data Field: Custom Value 12", UsageTypes.SV);
                case 0x0550: return new Usage(this, id, "Data Field: Custom Value 13", UsageTypes.SV);
                case 0x0551: return new Usage(this, id, "Data Field: Custom Value 14", UsageTypes.SV);
                case 0x0552: return new Usage(this, id, "Data Field: Custom Value 15", UsageTypes.SV);
                case 0x0553: return new Usage(this, id, "Data Field: Custom Value 16", UsageTypes.SV);
                case 0x0560: return new Usage(this, id, "Data Field: Generic", UsageTypes.SV);
                case 0x0561: return new Usage(this, id, "Data Field: Generic GUID or PROPERTYKEY", UsageTypes.SV);
                case 0x0562: return new Usage(this, id, "Data Field: Generic Category GUID", UsageTypes.SV);
                case 0x0563: return new Usage(this, id, "Data Field: Generic Type GUID", UsageTypes.SV);
                case 0x0564: return new Usage(this, id, "Data Field: Generic Event PROPERTYKEY", UsageTypes.SV);
                case 0x0565: return new Usage(this, id, "Data Field: Generic Property PROPERTYKEY", UsageTypes.SV);
                case 0x0566: return new Usage(this, id, "Data Field: Generic Data Field PROPERTYKEY", UsageTypes.SV);
                case 0x0567: return new Usage(this, id, "Data Field: Generic Event", UsageTypes.SV);
                case 0x0568: return new Usage(this, id, "Data Field: Generic Property", UsageTypes.SV);
                case 0x0569: return new Usage(this, id, "Data Field: Generic Data Field", UsageTypes.SV);
                case 0x056a: return new Usage(this, id, "Data Field: Enumerator Table Row Index", UsageTypes.SV);
                case 0x056b: return new Usage(this, id, "Data Field: Enumerator Table Row Count", UsageTypes.SV);
                case 0x056c:
                    return new Usage(this, id, "Data Field: Generic GUID or PROPERTYKEY kind", UsageTypes.NAry);
                case 0x056d: return new Usage(this, id, "Data Field: Generic GUID", UsageTypes.SV);
                case 0x056e: return new Usage(this, id, "Data Field: Generic PROPERTYKEY", UsageTypes.SV);
                case 0x056f: return new Usage(this, id, "Data Field: Generic Top Level Collection ID", UsageTypes.SV);
                case 0x0570: return new Usage(this, id, "Data Field: Generic Report ID", UsageTypes.SV);
                case 0x0571:
                    return new Usage(this, id, "Data Field: Generic Report Item Position Index", UsageTypes.SV);
                case 0x0572: return new Usage(this, id, "Data Field: Generic Firmware VARTYPE", UsageTypes.NAry);
                case 0x0573: return new Usage(this, id, "Data Field: Generic Unit of Measure", UsageTypes.NAry);
                case 0x0574: return new Usage(this, id, "Data Field: Generic Unit Exponent", UsageTypes.NAry);
                case 0x0575: return new Usage(this, id, "Data Field: Generic Report Size", UsageTypes.SV);
                case 0x0576: return new Usage(this, id, "Data Field: Generic Report Count", UsageTypes.SV);
                case 0x0580: return new Usage(this, id, "Property: Generic", UsageTypes.DV);
                case 0x0581: return new Usage(this, id, "Property: Enumerator Table Row Index", UsageTypes.DV);
                case 0x0582: return new Usage(this, id, "Property: Enumerator Table Row Count", UsageTypes.SV);
                case 0x0590: return new Usage(this, id, "Data Field: Personal Activity", UsageTypes.SV);
                case 0x0591: return new Usage(this, id, "Data Field: Activity Type", UsageTypes.NAry);
                case 0x0592: return new Usage(this, id, "Data Field: Activity State", UsageTypes.NAry);
                case 0x0593: return new Usage(this, id, "Data Field: Device Position", UsageTypes.NAry);
                case 0x0594: return new Usage(this, id, "Data Field: Step Count", UsageTypes.SV);
                case 0x0595: return new Usage(this, id, "Data Field: Step Count Reset", UsageTypes.DF);
                case 0x0596: return new Usage(this, id, "Data Field: Step Duration", UsageTypes.SV);
                case 0x0597: return new Usage(this, id, "Data Field: Step Type", UsageTypes.NAry);
                case 0x05a0: return new Usage(this, id, "Property: Minimum Activity Detection Interval", UsageTypes.DV);
                case 0x05a1: return new Usage(this, id, "Property: Supported Activity Types", UsageTypes.NAry);
                case 0x05a2: return new Usage(this, id, "Property: Subscribed Activity Types", UsageTypes.NAry);
                case 0x05a3: return new Usage(this, id, "Property: Supported Step Types", UsageTypes.NAry);
                case 0x05a4: return new Usage(this, id, "Property: Subscribed Step Types", UsageTypes.NAry);
                case 0x05a5: return new Usage(this, id, "Property: Floor Height", UsageTypes.DV);
                case 0x05b0: return new Usage(this, id, "Data Field: Custom Type ID", UsageTypes.SV);
                case 0x05c0: return new Usage(this, id, "Property: Custom", UsageTypes.DF | UsageTypes.DV);
                case 0x05c1: return new Usage(this, id, "Property: Custom Value 1", UsageTypes.DF | UsageTypes.DV);
                case 0x05c2: return new Usage(this, id, "Property: Custom Value 2", UsageTypes.DF | UsageTypes.DV);
                case 0x05c3: return new Usage(this, id, "Property: Custom Value 3", UsageTypes.DF | UsageTypes.DV);
                case 0x05c4: return new Usage(this, id, "Property: Custom Value 4", UsageTypes.DF | UsageTypes.DV);
                case 0x05c5: return new Usage(this, id, "Property: Custom Value 5", UsageTypes.DF | UsageTypes.DV);
                case 0x05c6: return new Usage(this, id, "Property: Custom Value 6", UsageTypes.DF | UsageTypes.DV);
                case 0x05c7: return new Usage(this, id, "Property: Custom Value 7", UsageTypes.DF | UsageTypes.DV);
                case 0x05c8: return new Usage(this, id, "Property: Custom Value 8", UsageTypes.DF | UsageTypes.DV);
                case 0x05c9: return new Usage(this, id, "Property: Custom Value 9", UsageTypes.DF | UsageTypes.DV);
                case 0x05ca: return new Usage(this, id, "Property: Custom Value 10", UsageTypes.DF | UsageTypes.DV);
                case 0x05cb: return new Usage(this, id, "Property: Custom Value 11", UsageTypes.DF | UsageTypes.DV);
                case 0x05cc: return new Usage(this, id, "Property: Custom Value 12", UsageTypes.DF | UsageTypes.DV);
                case 0x05cd: return new Usage(this, id, "Property: Custom Value 13", UsageTypes.DF | UsageTypes.DV);
                case 0x05ce: return new Usage(this, id, "Property: Custom Value 14", UsageTypes.DF | UsageTypes.DV);
                case 0x05cf: return new Usage(this, id, "Property: Custom Value 15", UsageTypes.DF | UsageTypes.DV);
                case 0x05d0: return new Usage(this, id, "Property: Custom Value 16", UsageTypes.DF | UsageTypes.DV);
                case 0x05d1: return new Usage(this, id, "Property: Custom Reserved 1", UsageTypes.DF | UsageTypes.DV);
                case 0x05d2: return new Usage(this, id, "Property: Custom Reserved 2", UsageTypes.DF | UsageTypes.DV);
                case 0x05d3: return new Usage(this, id, "Property: Custom Reserved 3", UsageTypes.DF | UsageTypes.DV);
                case 0x05d4: return new Usage(this, id, "Property: Custom Reserved 4", UsageTypes.DF | UsageTypes.DV);
                case 0x05d5: return new Usage(this, id, "Property: Custom Reserved 5", UsageTypes.DF | UsageTypes.DV);
                case 0x05d6: return new Usage(this, id, "Property: Custom Reserved 6", UsageTypes.DF | UsageTypes.DV);
                case 0x05d7: return new Usage(this, id, "Property: Custom Reserved 7", UsageTypes.DF | UsageTypes.DV);
                case 0x05d8: return new Usage(this, id, "Property: Custom Reserved 8", UsageTypes.DF | UsageTypes.DV);
                case 0x05d9: return new Usage(this, id, "Property: Custom Reserved 9", UsageTypes.DF | UsageTypes.DV);
                case 0x05da: return new Usage(this, id, "Property: Custom Reserved 10", UsageTypes.DF | UsageTypes.DV);
                case 0x05db: return new Usage(this, id, "Property: Custom Reserved 11", UsageTypes.DF | UsageTypes.DV);
                case 0x05dc: return new Usage(this, id, "Property: Custom Reserved 12", UsageTypes.DF | UsageTypes.DV);
                case 0x05dd: return new Usage(this, id, "Property: Custom Reserved 13", UsageTypes.DF | UsageTypes.DV);
                case 0x05de: return new Usage(this, id, "Property: Custom Reserved 14", UsageTypes.DF | UsageTypes.DV);
                case 0x05df: return new Usage(this, id, "Property: Custom Reserved 15", UsageTypes.DF | UsageTypes.DV);
                case 0x05e0: return new Usage(this, id, "Data Field: Hinge", UsageTypes.SV | UsageTypes.DV);
                case 0x05e1: return new Usage(this, id, "Data Field: Hinge Angle", UsageTypes.SV | UsageTypes.DV);
                case 0x05f0: return new Usage(this, id, "Data Field: Gesture Sensor", UsageTypes.SV);
                case 0x05f1: return new Usage(this, id, "Data Field: Gesture State", UsageTypes.NAry);
                case 0x05f2: return new Usage(this, id, "Data Field: Hinge Fold Initial Angle", UsageTypes.SV);
                case 0x05f3: return new Usage(this, id, "Data Field: Hinge Fold Final Angle", UsageTypes.SV);
                case 0x05f4: return new Usage(this, id, "Data Field: Hinge Fold Contributing Panel", UsageTypes.NAry);
                case 0x05f5: return new Usage(this, id, "Data Field: Hinge Fold Type", UsageTypes.NAry);
                case 0x0800: return new Usage(this, id, "Sensor State: Undefined", UsageTypes.Sel);
                case 0x0801: return new Usage(this, id, "Sensor State: Ready", UsageTypes.Sel);
                case 0x0802: return new Usage(this, id, "Sensor State: Not Available", UsageTypes.Sel);
                case 0x0803: return new Usage(this, id, "Sensor State: No Data", UsageTypes.Sel);
                case 0x0804: return new Usage(this, id, "Sensor State: Initializing", UsageTypes.Sel);
                case 0x0805: return new Usage(this, id, "Sensor State: Access Denied", UsageTypes.Sel);
                case 0x0806: return new Usage(this, id, "Sensor State: Error", UsageTypes.Sel);
                case 0x0810: return new Usage(this, id, "Sensor Event: Unknown", UsageTypes.Sel);
                case 0x0811: return new Usage(this, id, "Sensor Event: State Changed", UsageTypes.Sel);
                case 0x0812: return new Usage(this, id, "Sensor Event: Property Changed", UsageTypes.Sel);
                case 0x0813: return new Usage(this, id, "Sensor Event: Data Updated", UsageTypes.Sel);
                case 0x0814: return new Usage(this, id, "Sensor Event: Poll Response", UsageTypes.Sel);
                case 0x0815: return new Usage(this, id, "Sensor Event: Change Sensitivity", UsageTypes.Sel);
                case 0x0816: return new Usage(this, id, "Sensor Event: Range Maximum Reached", UsageTypes.Sel);
                case 0x0817: return new Usage(this, id, "Sensor Event: Range Minimum Reached", UsageTypes.Sel);
                case 0x0818: return new Usage(this, id, "Sensor Event: High Threshold Cross Upward", UsageTypes.Sel);
                case 0x0819: return new Usage(this, id, "Sensor Event: High Threshold Cross Downward", UsageTypes.Sel);
                case 0x081a: return new Usage(this, id, "Sensor Event: Low Threshold Cross Upward", UsageTypes.Sel);
                case 0x081b: return new Usage(this, id, "Sensor Event: Low Threshold Cross Downward", UsageTypes.Sel);
                case 0x081c: return new Usage(this, id, "Sensor Event: Zero Threshold Cross Upward", UsageTypes.Sel);
                case 0x081d: return new Usage(this, id, "Sensor Event: Zero Threshold Cross Downward", UsageTypes.Sel);
                case 0x081e: return new Usage(this, id, "Sensor Event: Period Exceeded", UsageTypes.Sel);
                case 0x081f: return new Usage(this, id, "Sensor Event: Frequency Exceeded", UsageTypes.Sel);
                case 0x0820: return new Usage(this, id, "Sensor Event: Complex Trigger", UsageTypes.Sel);
                case 0x0830: return new Usage(this, id, "Connection Type: Integrated", UsageTypes.Sel);
                case 0x0831: return new Usage(this, id, "Connection Type: Attached", UsageTypes.Sel);
                case 0x0832: return new Usage(this, id, "Connection Type: External", UsageTypes.Sel);
                case 0x0840: return new Usage(this, id, "Reporting State: Report No Events", UsageTypes.Sel);
                case 0x0841: return new Usage(this, id, "Reporting State: Report All Events", UsageTypes.Sel);
                case 0x0842: return new Usage(this, id, "Reporting State: Report Threshold Events", UsageTypes.Sel);
                case 0x0843: return new Usage(this, id, "Reporting State: Wake On No Events", UsageTypes.Sel);
                case 0x0844: return new Usage(this, id, "Reporting State: Wake On All Events", UsageTypes.Sel);
                case 0x0845: return new Usage(this, id, "Reporting State: Wake On Threshold Events", UsageTypes.Sel);
                case 0x0850: return new Usage(this, id, "Power State: Undefined", UsageTypes.Sel);
                case 0x0851: return new Usage(this, id, "Power State: D0 Full Power", UsageTypes.Sel);
                case 0x0852: return new Usage(this, id, "Power State: D1 Low Power", UsageTypes.Sel);
                case 0x0853: return new Usage(this, id, "Power State: D2 Standby Power with Wakeup", UsageTypes.Sel);
                case 0x0854: return new Usage(this, id, "Power State: D3 Sleep with Wakeup", UsageTypes.Sel);
                case 0x0855: return new Usage(this, id, "Power State: D4 Power Off", UsageTypes.Sel);
                case 0x0860: return new Usage(this, id, "Accuracy: Default", UsageTypes.Sel);
                case 0x0861: return new Usage(this, id, "Accuracy: High", UsageTypes.Sel);
                case 0x0862: return new Usage(this, id, "Accuracy: Medium", UsageTypes.Sel);
                case 0x0863: return new Usage(this, id, "Accuracy: Low", UsageTypes.Sel);
                case 0x0870: return new Usage(this, id, "Fix Quality: No Fix", UsageTypes.Sel);
                case 0x0871: return new Usage(this, id, "Fix Quality: GPS", UsageTypes.Sel);
                case 0x0872: return new Usage(this, id, "Fix Quality: DGPS", UsageTypes.Sel);
                case 0x0880: return new Usage(this, id, "Fix Type: No Fix", UsageTypes.Sel);
                case 0x0881: return new Usage(this, id, "Fix Type: GPS SPS Mode, Fix Valid", UsageTypes.Sel);
                case 0x0882: return new Usage(this, id, "Fix Type: DGPS SPS Mode, Fix Valid", UsageTypes.Sel);
                case 0x0883: return new Usage(this, id, "Fix Type: GPS PPS Mode, Fix Valid", UsageTypes.Sel);
                case 0x0884: return new Usage(this, id, "Fix Type: Real Time Kinematic", UsageTypes.Sel);
                case 0x0885: return new Usage(this, id, "Fix Type: Float RTK", UsageTypes.Sel);
                case 0x0886: return new Usage(this, id, "Fix Type: Estimated (dead reckoned)", UsageTypes.Sel);
                case 0x0887: return new Usage(this, id, "Fix Type: Manual Input Mode", UsageTypes.Sel);
                case 0x0888: return new Usage(this, id, "Fix Type: Simulator Mode", UsageTypes.Sel);
                case 0x0890: return new Usage(this, id, "GPS Operation Mode: Manual", UsageTypes.Sel);
                case 0x0891: return new Usage(this, id, "GPS Operation Mode: Automatic", UsageTypes.Sel);
                case 0x08a0: return new Usage(this, id, "GPS Selection Mode: Autonomous", UsageTypes.Sel);
                case 0x08a1: return new Usage(this, id, "GPS Selection Mode: DGPS", UsageTypes.Sel);
                case 0x08a2:
                    return new Usage(this, id, "GPS Selection Mode: Estimated (dead reckoned)", UsageTypes.Sel);
                case 0x08a3: return new Usage(this, id, "GPS Selection Mode: Manual Input", UsageTypes.Sel);
                case 0x08a4: return new Usage(this, id, "GPS Selection Mode: Simulator", UsageTypes.Sel);
                case 0x08a5: return new Usage(this, id, "GPS Selection Mode: Data Not Valid", UsageTypes.Sel);
                case 0x08b0: return new Usage(this, id, "GPS Status: Data Valid", UsageTypes.Sel);
                case 0x08b1: return new Usage(this, id, "GPS Status: Data Not Valid", UsageTypes.Sel);
                case 0x08c0: return new Usage(this, id, "Day of Week: Sunday", UsageTypes.Sel);
                case 0x08c1: return new Usage(this, id, "Day of Week: Monday", UsageTypes.Sel);
                case 0x08c2: return new Usage(this, id, "Day of Week: Tuesday", UsageTypes.Sel);
                case 0x08c3: return new Usage(this, id, "Day of Week: Wednesday", UsageTypes.Sel);
                case 0x08c4: return new Usage(this, id, "Day of Week: Thursday", UsageTypes.Sel);
                case 0x08c5: return new Usage(this, id, "Day of Week: Friday", UsageTypes.Sel);
                case 0x08c6: return new Usage(this, id, "Day of Week: Saturday", UsageTypes.Sel);
                case 0x08d0: return new Usage(this, id, "Kind: Category", UsageTypes.Sel);
                case 0x08d1: return new Usage(this, id, "Kind: Type", UsageTypes.Sel);
                case 0x08d2: return new Usage(this, id, "Kind: Event", UsageTypes.Sel);
                case 0x08d3: return new Usage(this, id, "Kind: Property", UsageTypes.Sel);
                case 0x08d4: return new Usage(this, id, "Kind: Data Field", UsageTypes.Sel);
                case 0x08e0: return new Usage(this, id, "Magnetometer Accuracy: Low", UsageTypes.Sel);
                case 0x08e1: return new Usage(this, id, "Magnetometer Accuracy: Medium", UsageTypes.Sel);
                case 0x08e2: return new Usage(this, id, "Magnetometer Accuracy: High", UsageTypes.Sel);
                case 0x08f0: return new Usage(this, id, "Simple Orientation Direction: Not Rotated", UsageTypes.Sel);
                case 0x08f1:
                    return new Usage(this, id, "Simple Orientation Direction: Rotated 90 Degrees CCW", UsageTypes.Sel);
                case 0x08f2:
                    return new Usage(this, id, "Simple Orientation Direction: Rotated 180 Degrees CCW", UsageTypes.Sel);
                case 0x08f3:
                    return new Usage(this, id, "Simple Orientation Direction: Rotated 270 Degrees CCW", UsageTypes.Sel);
                case 0x08f4: return new Usage(this, id, "Simple Orientation Direction: Face Up", UsageTypes.Sel);
                case 0x08f5: return new Usage(this, id, "Simple Orientation Direction: Face Down", UsageTypes.Sel);
                case 0x0900: return new Usage(this, id, "VT_NULL: Empty", UsageTypes.Sel);
                case 0x0901: return new Usage(this, id, "VT_BOOL: Boolean", UsageTypes.Sel);
                case 0x0902: return new Usage(this, id, "VT_UI1: Byte", UsageTypes.Sel);
                case 0x0903: return new Usage(this, id, "VT_I1: Character", UsageTypes.Sel);
                case 0x0904: return new Usage(this, id, "VT_UI2: Unsigned Short", UsageTypes.Sel);
                case 0x0905: return new Usage(this, id, "VT_I2: Short", UsageTypes.Sel);
                case 0x0906: return new Usage(this, id, "VT_UI4: Unsigned Long", UsageTypes.Sel);
                case 0x0907: return new Usage(this, id, "VT_I4: Long", UsageTypes.Sel);
                case 0x0908: return new Usage(this, id, "VT_UI8: Unsigned Long Long", UsageTypes.Sel);
                case 0x0909: return new Usage(this, id, "VT_I8: Long Long", UsageTypes.Sel);
                case 0x090a: return new Usage(this, id, "VT_R4: Float", UsageTypes.Sel);
                case 0x090b: return new Usage(this, id, "VT_R8: Double", UsageTypes.Sel);
                case 0x090c: return new Usage(this, id, "VT_WSTR: Wide String", UsageTypes.Sel);
                case 0x090d: return new Usage(this, id, "VT_STR: Narrow String", UsageTypes.Sel);
                case 0x090e: return new Usage(this, id, "VT_CLSID: Guid", UsageTypes.Sel);
                case 0x090f: return new Usage(this, id, "VT_VECTOR|VT_UI1: Opaque Structure", UsageTypes.Sel);
                case 0x0910: return new Usage(this, id, "VT_F16E0: HID 16-bit Float e0", UsageTypes.Sel);
                case 0x0911: return new Usage(this, id, "VT_F16E1: HID 16-bit Float e1", UsageTypes.Sel);
                case 0x0912: return new Usage(this, id, "VT_F16E2: HID 16-bit Float e2", UsageTypes.Sel);
                case 0x0913: return new Usage(this, id, "VT_F16E3: HID 16-bit Float e3", UsageTypes.Sel);
                case 0x0914: return new Usage(this, id, "VT_F16E4: HID 16-bit Float e4", UsageTypes.Sel);
                case 0x0915: return new Usage(this, id, "VT_F16E5: HID 16-bit Float e5", UsageTypes.Sel);
                case 0x0916: return new Usage(this, id, "VT_F16E6: HID 16-bit Float e6", UsageTypes.Sel);
                case 0x0917: return new Usage(this, id, "VT_F16E7: HID 16-bit Float e7", UsageTypes.Sel);
                case 0x0918: return new Usage(this, id, "VT_F16E8: HID 16-bit Float e-8", UsageTypes.Sel);
                case 0x0919: return new Usage(this, id, "VT_F16E9: HID 16-bit Float e-7", UsageTypes.Sel);
                case 0x091a: return new Usage(this, id, "VT_F16EA: HID 16-bit Float e-6", UsageTypes.Sel);
                case 0x091b: return new Usage(this, id, "VT_F16EB: HID 16-bit Float e-5", UsageTypes.Sel);
                case 0x091c: return new Usage(this, id, "VT_F16EC: HID 16-bit Float e-4", UsageTypes.Sel);
                case 0x091d: return new Usage(this, id, "VT_F16ED: HID 16-bit Float e-3", UsageTypes.Sel);
                case 0x091e: return new Usage(this, id, "VT_F16EE: HID 16-bit Float e-2", UsageTypes.Sel);
                case 0x091f: return new Usage(this, id, "VT_F16EF: HID 16-bit Float e-1", UsageTypes.Sel);
                case 0x0920: return new Usage(this, id, "VT_F32E0: HID 32-bit Float e0", UsageTypes.Sel);
                case 0x0921: return new Usage(this, id, "VT_F32E1: HID 32-bit Float e1", UsageTypes.Sel);
                case 0x0922: return new Usage(this, id, "VT_F32E2: HID 32-bit Float e2", UsageTypes.Sel);
                case 0x0923: return new Usage(this, id, "VT_F32E3: HID 32-bit Float e3", UsageTypes.Sel);
                case 0x0924: return new Usage(this, id, "VT_F32E4: HID 32-bit Float e4", UsageTypes.Sel);
                case 0x0925: return new Usage(this, id, "VT_F32E5: HID 32-bit Float e5", UsageTypes.Sel);
                case 0x0926: return new Usage(this, id, "VT_F32E6: HID 32-bit Float e6", UsageTypes.Sel);
                case 0x0927: return new Usage(this, id, "VT_F32E7: HID 32-bit Float e7", UsageTypes.Sel);
                case 0x0928: return new Usage(this, id, "VT_F32E8: HID 32-bit Float e-8", UsageTypes.Sel);
                case 0x0929: return new Usage(this, id, "VT_F32E9: HID 32-bit Float e-7", UsageTypes.Sel);
                case 0x092a: return new Usage(this, id, "VT_F32EA: HID 32-bit Float e-6", UsageTypes.Sel);
                case 0x092b: return new Usage(this, id, "VT_F32EB: HID 32-bit Float e-5", UsageTypes.Sel);
                case 0x092c: return new Usage(this, id, "VT_F32EC: HID 32-bit Float e-4", UsageTypes.Sel);
                case 0x092d: return new Usage(this, id, "VT_F32ED: HID 32-bit Float e-3", UsageTypes.Sel);
                case 0x092e: return new Usage(this, id, "VT_F32EE: HID 32-bit Float e-2", UsageTypes.Sel);
                case 0x092f: return new Usage(this, id, "VT_F32EF: HID 32-bit Float e-1", UsageTypes.Sel);
                case 0x0930: return new Usage(this, id, "Activity Type: Unknown", UsageTypes.Sel);
                case 0x0931: return new Usage(this, id, "Activity Type: Stationary", UsageTypes.Sel);
                case 0x0932: return new Usage(this, id, "Activity Type: Fidgeting", UsageTypes.Sel);
                case 0x0933: return new Usage(this, id, "Activity Type: Walking", UsageTypes.Sel);
                case 0x0934: return new Usage(this, id, "Activity Type: Running", UsageTypes.Sel);
                case 0x0935: return new Usage(this, id, "Activity Type: In Vehicle", UsageTypes.Sel);
                case 0x0936: return new Usage(this, id, "Activity Type: Biking", UsageTypes.Sel);
                case 0x0937: return new Usage(this, id, "Activity Type: Idle", UsageTypes.Sel);
                case 0x0940: return new Usage(this, id, "Unit: Not Specified", UsageTypes.Sel);
                case 0x0941: return new Usage(this, id, "Unit: Lux", UsageTypes.Sel);
                case 0x0942: return new Usage(this, id, "Unit: Degrees Kelvin", UsageTypes.Sel);
                case 0x0943: return new Usage(this, id, "Unit: Degrees Celsius", UsageTypes.Sel);
                case 0x0944: return new Usage(this, id, "Unit: Pascal", UsageTypes.Sel);
                case 0x0945: return new Usage(this, id, "Unit: Newton", UsageTypes.Sel);
                case 0x0946: return new Usage(this, id, "Unit: Meters/Second", UsageTypes.Sel);
                case 0x0947: return new Usage(this, id, "Unit: Kilogram", UsageTypes.Sel);
                case 0x0948: return new Usage(this, id, "Unit: Meter", UsageTypes.Sel);
                case 0x0949: return new Usage(this, id, "Unit: Meters/Second/Second", UsageTypes.Sel);
                case 0x094a: return new Usage(this, id, "Unit: Farad", UsageTypes.Sel);
                case 0x094b: return new Usage(this, id, "Unit: Ampere", UsageTypes.Sel);
                case 0x094c: return new Usage(this, id, "Unit: Watt", UsageTypes.Sel);
                case 0x094d: return new Usage(this, id, "Unit: Henry", UsageTypes.Sel);
                case 0x094e: return new Usage(this, id, "Unit: Ohm", UsageTypes.Sel);
                case 0x094f: return new Usage(this, id, "Unit: Volt", UsageTypes.Sel);
                case 0x0950: return new Usage(this, id, "Unit: Hertz", UsageTypes.Sel);
                case 0x0951: return new Usage(this, id, "Unit: Bar", UsageTypes.Sel);
                case 0x0952: return new Usage(this, id, "Unit: Degrees Anti-clockwise", UsageTypes.Sel);
                case 0x0953: return new Usage(this, id, "Unit: Degrees Clockwise", UsageTypes.Sel);
                case 0x0954: return new Usage(this, id, "Unit: Degrees", UsageTypes.Sel);
                case 0x0955: return new Usage(this, id, "Unit: Degrees/Second", UsageTypes.Sel);
                case 0x0956: return new Usage(this, id, "Unit: Degrees/Second/Second", UsageTypes.Sel);
                case 0x0957: return new Usage(this, id, "Unit: Knot", UsageTypes.Sel);
                case 0x0958: return new Usage(this, id, "Unit: Percent", UsageTypes.Sel);
                case 0x0959: return new Usage(this, id, "Unit: Second", UsageTypes.Sel);
                case 0x095a: return new Usage(this, id, "Unit: Millisecond", UsageTypes.Sel);
                case 0x095b: return new Usage(this, id, "Unit: G", UsageTypes.Sel);
                case 0x095c: return new Usage(this, id, "Unit: Bytes", UsageTypes.Sel);
                case 0x095d: return new Usage(this, id, "Unit: Milligauss", UsageTypes.Sel);
                case 0x095e: return new Usage(this, id, "Unit: Bits", UsageTypes.Sel);
                case 0x0960: return new Usage(this, id, "Activity State: No State Change", UsageTypes.Sel);
                case 0x0961: return new Usage(this, id, "Activity State: Start Activity", UsageTypes.Sel);
                case 0x0962: return new Usage(this, id, "Activity State: End Activity", UsageTypes.Sel);
                case 0x0970: return new Usage(this, id, "Exponent 0: 1", UsageTypes.Sel);
                case 0x0971: return new Usage(this, id, "Exponent 1: 10", UsageTypes.Sel);
                case 0x0972: return new Usage(this, id, "Exponent 2: 100", UsageTypes.Sel);
                case 0x0973: return new Usage(this, id, "Exponent 3: 1 000", UsageTypes.Sel);
                case 0x0974: return new Usage(this, id, "Exponent 4: 10 000", UsageTypes.Sel);
                case 0x0975: return new Usage(this, id, "Exponent 5: 100 000", UsageTypes.Sel);
                case 0x0976: return new Usage(this, id, "Exponent 6: 1 000 000", UsageTypes.Sel);
                case 0x0977: return new Usage(this, id, "Exponent 7: 10 000 000", UsageTypes.Sel);
                case 0x0978: return new Usage(this, id, "Exponent 8: 0.00 000 001", UsageTypes.Sel);
                case 0x0979: return new Usage(this, id, "Exponent 9: 0.0 000 001", UsageTypes.Sel);
                case 0x097a: return new Usage(this, id, "Exponent A: 0.000 001", UsageTypes.Sel);
                case 0x097b: return new Usage(this, id, "Exponent B: 0.00 001", UsageTypes.Sel);
                case 0x097c: return new Usage(this, id, "Exponent C: 0.0 001", UsageTypes.Sel);
                case 0x097d: return new Usage(this, id, "Exponent D: 0.001", UsageTypes.Sel);
                case 0x097e: return new Usage(this, id, "Exponent E: 0.01", UsageTypes.Sel);
                case 0x097f: return new Usage(this, id, "Exponent F: 0.1", UsageTypes.Sel);
                case 0x0980: return new Usage(this, id, "Device Position: Unknown", UsageTypes.Sel);
                case 0x0981: return new Usage(this, id, "Device Position: Unchanged", UsageTypes.Sel);
                case 0x0982: return new Usage(this, id, "Device Position: On Desk", UsageTypes.Sel);
                case 0x0983: return new Usage(this, id, "Device Position: In Hand", UsageTypes.Sel);
                case 0x0984: return new Usage(this, id, "Device Position: Moving in Bag", UsageTypes.Sel);
                case 0x0985: return new Usage(this, id, "Device Position: Stationary in Bag", UsageTypes.Sel);
                case 0x0990: return new Usage(this, id, "Step Type: Unknown", UsageTypes.Sel);
                case 0x0991: return new Usage(this, id, "Step Type: Running", UsageTypes.Sel);
                case 0x0992: return new Usage(this, id, "Step Type: Walking", UsageTypes.Sel);
                case 0x09a0: return new Usage(this, id, "Gesture State: Unknown", UsageTypes.Sel);
                case 0x09a1: return new Usage(this, id, "Gesture State: Started", UsageTypes.Sel);
                case 0x09a2: return new Usage(this, id, "Gesture State: Completed", UsageTypes.Sel);
                case 0x09a3: return new Usage(this, id, "Gesture State: Cancelled", UsageTypes.Sel);
                case 0x09b0: return new Usage(this, id, "Contributing Panel: Unknown", UsageTypes.Sel);
                case 0x09b1: return new Usage(this, id, "Contributing Panel: Panel1", UsageTypes.Sel);
                case 0x09b2: return new Usage(this, id, "Contributing Panel: Panel2", UsageTypes.Sel);
                case 0x09b3: return new Usage(this, id, "Contributing Panel: Both", UsageTypes.Sel);
                case 0x09b4: return new Usage(this, id, "Fold Type: Unknown", UsageTypes.Sel);
                case 0x09b5: return new Usage(this, id, "Fold Type: Increasing", UsageTypes.Sel);
                case 0x09b6: return new Usage(this, id, "Fold Type: Decreasing", UsageTypes.Sel);
                case 0x09c0:
                    return new Usage(this, id, "Human Presence Detection Type: Vendor-Defined Non-Biometric",
                        UsageTypes.Sel);
                case 0x09c1:
                    return new Usage(this, id, "Human Presence Detection Type: Vendor-Defined Biometric",
                        UsageTypes.Sel);
                case 0x09c2:
                    return new Usage(this, id, "Human Presence Detection Type: Facial Biometric", UsageTypes.Sel);
                case 0x09c3:
                    return new Usage(this, id, "Human Presence Detection Type: Audio Biometric", UsageTypes.Sel);
                case 0x1000: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1001: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1002: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1003: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1004: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1005: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1006: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1007: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1008: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x1009: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100a: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100b: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100c: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100d: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100e: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x100f: return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
                case 0x2000: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2001: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2002: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2003: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2004: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2005: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2006: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2007: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2008: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x2009: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200a: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200b: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200c: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200d: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200e: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x200f: return new Usage(this, id, "Maximum", UsageTypes.US);
                case 0x3000: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3001: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3002: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3003: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3004: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3005: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3006: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3007: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3008: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x3009: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300a: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300b: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300c: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300d: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300e: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x300f: return new Usage(this, id, "Minimum", UsageTypes.US);
                case 0x4000: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4001: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4002: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4003: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4004: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4005: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4006: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4007: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4008: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x4009: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400a: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400b: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400c: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400d: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400e: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x400f: return new Usage(this, id, "Accuracy", UsageTypes.US);
                case 0x5000: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5001: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5002: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5003: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5004: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5005: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5006: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5007: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5008: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x5009: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500a: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500b: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500c: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500d: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500e: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x500f: return new Usage(this, id, "Resolution", UsageTypes.US);
                case 0x6000: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6001: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6002: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6003: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6004: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6005: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6006: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6007: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6008: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x6009: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600a: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600b: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600c: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600d: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600e: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x600f: return new Usage(this, id, "Threshold High", UsageTypes.US);
                case 0x7000: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7001: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7002: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7003: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7004: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7005: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7006: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7007: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7008: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x7009: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700a: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700b: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700c: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700d: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700e: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x700f: return new Usage(this, id, "Threshold Low", UsageTypes.US);
                case 0x8000: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8001: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8002: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8003: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8004: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8005: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8006: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8007: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8008: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x8009: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800a: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800b: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800c: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800d: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800e: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x800f: return new Usage(this, id, "Calibration Offset", UsageTypes.US);
                case 0x9000: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9001: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9002: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9003: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9004: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9005: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9006: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9007: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9008: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x9009: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900a: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900b: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900c: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900d: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900e: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0x900f: return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
                case 0xa000: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa001: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa002: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa003: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa004: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa005: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa006: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa007: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa008: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa009: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00a: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00b: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00c: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00d: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00e: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xa00f: return new Usage(this, id, "Report Interval", UsageTypes.US);
                case 0xb000: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb001: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb002: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb003: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb004: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb005: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb006: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb007: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb008: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb009: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00a: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00b: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00c: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00d: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00e: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xb00f: return new Usage(this, id, "Frequency Max", UsageTypes.US);
                case 0xc000: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc001: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc002: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc003: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc004: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc005: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc006: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc007: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc008: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc009: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00a: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00b: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00c: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00d: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00e: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xc00f: return new Usage(this, id, "Period Max", UsageTypes.US);
                case 0xd000: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd001: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd002: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd003: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd004: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd005: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd006: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd007: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd008: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd009: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00a: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00b: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00c: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00d: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00e: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xd00f: return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
                case 0xe000: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe001: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe002: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe003: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe004: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe005: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe006: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe007: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe008: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe009: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00a: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00b: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00c: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00d: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00e: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
                case 0xe00f: return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);
            }

            // Create dynamic usages from ranges
            var n = (ushort)(id - 0x00f0);
            if (id >= 0x00f0 || id < 0x00ff)
                return new Usage(this, id, $"Vendor Reserved {n + 1}", UsageTypes.CA | UsageTypes.CP);
            n = (ushort)(id - 0x0544);
            if (id >= 0x0544 || id < 0x055f)
                return new Usage(this, id, $"Data Field: Custom Value {n + 1}", UsageTypes.SV);
            n = (ushort)(id - 0x05c1);
            if (id >= 0x05c1 || id < 0x05d0)
                return new Usage(this, id, $"Property: Custom Value {n + 1}", UsageTypes.DF | UsageTypes.DV);
            if (id >= 0x1000 || id < 0x1fff) return new Usage(this, id, "Change Sensitivity Absolute", UsageTypes.US);
            if (id >= 0x2000 || id < 0x2fff) return new Usage(this, id, "Maximum", UsageTypes.US);
            if (id >= 0x3000 || id < 0x3fff) return new Usage(this, id, "Minimum", UsageTypes.US);
            if (id >= 0x4000 || id < 0x4fff) return new Usage(this, id, "Accuracy", UsageTypes.US);
            if (id >= 0x5000 || id < 0x5fff) return new Usage(this, id, "Resolution", UsageTypes.US);
            if (id >= 0x6000 || id < 0x6fff) return new Usage(this, id, "Threshold High", UsageTypes.US);
            if (id >= 0x7000 || id < 0x7fff) return new Usage(this, id, "Threshold Low", UsageTypes.US);
            if (id >= 0x8000 || id < 0x8fff) return new Usage(this, id, "Calibration Offset", UsageTypes.US);
            if (id >= 0x9000 || id < 0x9fff) return new Usage(this, id, "Calibration Multiplier", UsageTypes.US);
            if (id >= 0xa000 || id < 0xafff) return new Usage(this, id, "Report Interval", UsageTypes.US);
            if (id >= 0xb000 || id < 0xbfff) return new Usage(this, id, "Frequency Max", UsageTypes.US);
            if (id >= 0xc000 || id < 0xcfff) return new Usage(this, id, "Period Max", UsageTypes.US);
            if (id >= 0xd000 || id < 0xdfff)
                return new Usage(this, id, "Change Sensitivity Percent of Range", UsageTypes.US);
            if (id >= 0xe000 || id < 0xefff)
                return new Usage(this, id, "Change Sensitivity Percent Relative", UsageTypes.US);

            return base.CreateUsage(id);
        }
    }
}