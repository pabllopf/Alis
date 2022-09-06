// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PhysicalInterfaceDeviceUsagePage.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class PhysicalInterfaceDeviceUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PhysicalInterfaceDeviceUsagePage" /> class
        /// </summary>
        private PhysicalInterfaceDeviceUsagePage() : base(0x000f, "PhysicalInterfaceDevice")
        {
        }

        /// <summary>
        ///     Singleton instance of PhysicalInterfaceDevice Usage Page.
        /// </summary>
        public static readonly PhysicalInterfaceDeviceUsagePage Instance = new PhysicalInterfaceDeviceUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Physical Interface Device", UsageTypes.Ca);
                case 0x0020: return new Usage(this, id, "Normal", UsageTypes.Dv);
                case 0x0021: return new Usage(this, id, "Set Effect Report", UsageTypes.Cl);
                case 0x0022: return new Usage(this, id, "Effect Block Index", UsageTypes.Dv);
                case 0x0023: return new Usage(this, id, "Parameter Block Offset", UsageTypes.Dv);
                case 0x0024: return new Usage(this, id, "ROM Flag", UsageTypes.Df);
                case 0x0025: return new Usage(this, id, "Effect Type", UsageTypes.NAry);
                case 0x0026: return new Usage(this, id, "ET Constant Force", UsageTypes.Sel);
                case 0x0027: return new Usage(this, id, "ET Ramp", UsageTypes.Sel);
                case 0x0028: return new Usage(this, id, "ET Custom Force Data", UsageTypes.Sel);
                case 0x0030: return new Usage(this, id, "ET Square", UsageTypes.Sel);
                case 0x0031: return new Usage(this, id, "ET Sine", UsageTypes.Sel);
                case 0x0032: return new Usage(this, id, "ET Triangle", UsageTypes.Sel);
                case 0x0033: return new Usage(this, id, "ET Sawtooth Up", UsageTypes.Sel);
                case 0x0034: return new Usage(this, id, "ET Sawtooth Down", UsageTypes.Sel);
                case 0x0040: return new Usage(this, id, "ET Spring", UsageTypes.Sel);
                case 0x0041: return new Usage(this, id, "ET Damper", UsageTypes.Sel);
                case 0x0042: return new Usage(this, id, "ET Inertia", UsageTypes.Sel);
                case 0x0043: return new Usage(this, id, "ET Friction", UsageTypes.Sel);
                case 0x0050: return new Usage(this, id, "Duration", UsageTypes.Dv);
                case 0x0051: return new Usage(this, id, "Sample Period", UsageTypes.Dv);
                case 0x0052: return new Usage(this, id, "Gain", UsageTypes.Dv);
                case 0x0053: return new Usage(this, id, "Trigger Button", UsageTypes.Dv);
                case 0x0054: return new Usage(this, id, "Trigger Repeat Interval", UsageTypes.Dv);
                case 0x0055: return new Usage(this, id, "Axes Enable", UsageTypes.Us);
                case 0x0056: return new Usage(this, id, "Direction Enable", UsageTypes.Df);
                case 0x0057: return new Usage(this, id, "Direction", UsageTypes.Cl);
                case 0x0058: return new Usage(this, id, "Type Specific Block Offset", UsageTypes.Cl);
                case 0x0059: return new Usage(this, id, "Block Type", UsageTypes.NAry);
                case 0x005a: return new Usage(this, id, "Set Envelope Report", UsageTypes.Cl);
                case 0x005b: return new Usage(this, id, "Attack Level", UsageTypes.Dv);
                case 0x005c: return new Usage(this, id, "Attack Time", UsageTypes.Dv);
                case 0x005d: return new Usage(this, id, "Fade Level", UsageTypes.Dv);
                case 0x005e: return new Usage(this, id, "Fade Time", UsageTypes.Dv);
                case 0x005f: return new Usage(this, id, "Set Condition Report", UsageTypes.Cl);
                case 0x0060: return new Usage(this, id, "CP Offset", UsageTypes.Dv);
                case 0x0061: return new Usage(this, id, "Positive Coefficient", UsageTypes.Dv);
                case 0x0062: return new Usage(this, id, "Negative Coefficient", UsageTypes.Dv);
                case 0x0063: return new Usage(this, id, "Positive Saturation", UsageTypes.Dv);
                case 0x0064: return new Usage(this, id, "Negative Saturation", UsageTypes.Dv);
                case 0x0065: return new Usage(this, id, "Dead Band", UsageTypes.Dv);
                case 0x0066: return new Usage(this, id, "Download Force Sample", UsageTypes.Cl);
                case 0x0067: return new Usage(this, id, "Isoch Custom Force Enable", UsageTypes.Df);
                case 0x0068: return new Usage(this, id, "Custom Force Data Report", UsageTypes.Cl);
                case 0x0069: return new Usage(this, id, "Custom Force Data", UsageTypes.Dv);
                case 0x006a: return new Usage(this, id, "Custom Force Vendor Defined Data", UsageTypes.Dv);
                case 0x006b: return new Usage(this, id, "Set Custom Force Report", UsageTypes.Cl);
                case 0x006c: return new Usage(this, id, "Custom Force Data Offset", UsageTypes.Dv);
                case 0x006d: return new Usage(this, id, "Sample Count", UsageTypes.Dv);
                case 0x006e: return new Usage(this, id, "Set Periodic Report", UsageTypes.Cl);
                case 0x006f: return new Usage(this, id, "Offset", UsageTypes.Dv);
                case 0x0070: return new Usage(this, id, "Magnitude", UsageTypes.Dv);
                case 0x0071: return new Usage(this, id, "Phase", UsageTypes.Dv);
                case 0x0072: return new Usage(this, id, "Period", UsageTypes.Dv);
                case 0x0073: return new Usage(this, id, "Set Constant Force Report", UsageTypes.Cl);
                case 0x0074: return new Usage(this, id, "Set Ramp Force Report", UsageTypes.Cl);
                case 0x0075: return new Usage(this, id, "Ramp Start", UsageTypes.Dv);
                case 0x0076: return new Usage(this, id, "Ramp End", UsageTypes.Dv);
                case 0x0077: return new Usage(this, id, "Effect Operation Report", UsageTypes.Cl);
                case 0x0078: return new Usage(this, id, "Effect Operation", UsageTypes.NAry);
                case 0x0079: return new Usage(this, id, "Op Effect Start", UsageTypes.Sel);
                case 0x007a: return new Usage(this, id, "Op Effect Start Solo", UsageTypes.Sel);
                case 0x007b: return new Usage(this, id, "Op Effect Stop", UsageTypes.Sel);
                case 0x007c: return new Usage(this, id, "Loop Count", UsageTypes.Dv);
                case 0x007d: return new Usage(this, id, "Device Gain Report", UsageTypes.Cl);
                case 0x007e: return new Usage(this, id, "Device Gain", UsageTypes.Dv);
                case 0x007f: return new Usage(this, id, "PID Pool Report", UsageTypes.Cl);
                case 0x0080: return new Usage(this, id, "RAM Pool Size", UsageTypes.Dv);
                case 0x0081: return new Usage(this, id, "ROM Pool Size", UsageTypes.Sv);
                case 0x0082: return new Usage(this, id, "ROM Effect Block Count", UsageTypes.Sv);
                case 0x0083: return new Usage(this, id, "Simultaneous Effects Max", UsageTypes.Sv);
                case 0x0084: return new Usage(this, id, "Pool Alignment", UsageTypes.Sv);
                case 0x0085: return new Usage(this, id, "PID Pool Move Report", UsageTypes.Cl);
                case 0x0086: return new Usage(this, id, "Move Source", UsageTypes.Dv);
                case 0x0087: return new Usage(this, id, "Move Destination", UsageTypes.Dv);
                case 0x0088: return new Usage(this, id, "Move Length", UsageTypes.Dv);
                case 0x0089: return new Usage(this, id, "PID Block Load Report", UsageTypes.Cl);
                case 0x008b: return new Usage(this, id, "Block Load Status", UsageTypes.NAry);
                case 0x008c: return new Usage(this, id, "Block Load Success", UsageTypes.Sel);
                case 0x008d: return new Usage(this, id, "Block Load Full", UsageTypes.Sel);
                case 0x008e: return new Usage(this, id, "Block Load Error", UsageTypes.Sel);
                case 0x008f: return new Usage(this, id, "Block Handle", UsageTypes.Dv);
                case 0x0090: return new Usage(this, id, "PID Block Free Report", UsageTypes.Cl);
                case 0x0091: return new Usage(this, id, "Type Specific Block Handle", UsageTypes.Cl);
                case 0x0092: return new Usage(this, id, "PID State Report", UsageTypes.Cl);
                case 0x0094: return new Usage(this, id, "Effect Playing", UsageTypes.Df);
                case 0x0095: return new Usage(this, id, "PID Device Control Report", UsageTypes.Cl);
                case 0x0096: return new Usage(this, id, "PID Device Control", UsageTypes.NAry);
                case 0x0097: return new Usage(this, id, "DC Enable Actuators", UsageTypes.Sel);
                case 0x0098: return new Usage(this, id, "DC Disable Actuators", UsageTypes.Sel);
                case 0x0099: return new Usage(this, id, "DC Stop All Effects", UsageTypes.Sel);
                case 0x009a: return new Usage(this, id, "DC Device Reset", UsageTypes.Sel);
                case 0x009b: return new Usage(this, id, "DC Device Pause", UsageTypes.Sel);
                case 0x009c: return new Usage(this, id, "DC Device Continue", UsageTypes.Sel);
                case 0x009f: return new Usage(this, id, "Device Paused", UsageTypes.Df);
                case 0x00a0: return new Usage(this, id, "Actuators Enabled", UsageTypes.Df);
                case 0x00a4: return new Usage(this, id, "Safety Switch", UsageTypes.Df);
                case 0x00a5: return new Usage(this, id, "Actuator Override Switch", UsageTypes.Df);
                case 0x00a6: return new Usage(this, id, "Actuator Power", UsageTypes.Ooc);
                case 0x00a7: return new Usage(this, id, "Start Delay", UsageTypes.Dv);
                case 0x00a8: return new Usage(this, id, "Parameter Block Size", UsageTypes.Cl);
                case 0x00a9: return new Usage(this, id, "Device Managed Pool", UsageTypes.Sf);
                case 0x00aa: return new Usage(this, id, "Shared Parameter Blocks", UsageTypes.Sf);
                case 0x00ab: return new Usage(this, id, "Create New Effect Report", UsageTypes.Cl);
                case 0x00ac: return new Usage(this, id, "RAM Pool Available", UsageTypes.Dv);
            }

            return base.CreateUsage(id);
        }
    }
}