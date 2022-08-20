// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DigitizerUsagePage.cs
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
    public sealed class DigitizerUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="DigitizerUsagePage" /> class
        /// </summary>
        private DigitizerUsagePage() : base(0x000d, "Digitizer")
        {
        }

        /// <summary>
        ///     Singleton instance of Digitizer Usage Page.
        /// </summary>
        public static readonly DigitizerUsagePage Instance = new DigitizerUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Digitizer", UsageTypes.Ca);
                case 0x0002: return new Usage(this, id, "Pen", UsageTypes.Ca);
                case 0x0003: return new Usage(this, id, "Light Pen", UsageTypes.Ca);
                case 0x0004: return new Usage(this, id, "Touch Screen", UsageTypes.Ca);
                case 0x0005: return new Usage(this, id, "Touch Pad", UsageTypes.Ca);
                case 0x0006: return new Usage(this, id, "White Board", UsageTypes.Ca);
                case 0x0007: return new Usage(this, id, "Coordinate Measuring Machine", UsageTypes.Ca);
                case 0x0008: return new Usage(this, id, "3D Digitizer", UsageTypes.Ca);
                case 0x0009: return new Usage(this, id, "Stereo Plotter", UsageTypes.Ca);
                case 0x000a: return new Usage(this, id, "Articulated Arm", UsageTypes.Ca);
                case 0x000b: return new Usage(this, id, "Armature", UsageTypes.Ca);
                case 0x000c: return new Usage(this, id, "Multiple Point Digitizer", UsageTypes.Ca);
                case 0x000d: return new Usage(this, id, "Free Space Wand", UsageTypes.Ca);
                case 0x000e: return new Usage(this, id, "Device Configuration", UsageTypes.Ca);
                case 0x000f: return new Usage(this, id, "Capacitive Heat Map Digitizer", UsageTypes.Ca);
                case 0x0020: return new Usage(this, id, "Stylus", UsageTypes.Ca | UsageTypes.Cl);
                case 0x0021: return new Usage(this, id, "Puck", UsageTypes.Cl);
                case 0x0022: return new Usage(this, id, "Finger", UsageTypes.Cl);
                case 0x0023: return new Usage(this, id, "Device Settings", UsageTypes.Cl);
                case 0x0024: return new Usage(this, id, "Character Gesture", UsageTypes.Cl);
                case 0x0030: return new Usage(this, id, "Tip Pressure", UsageTypes.Dv);
                case 0x0031: return new Usage(this, id, "Barrel Pressure", UsageTypes.Dv);
                case 0x0032: return new Usage(this, id, "In Range", UsageTypes.Mc);
                case 0x0033: return new Usage(this, id, "Touch", UsageTypes.Mc);
                case 0x0034: return new Usage(this, id, "Untouch", UsageTypes.Osc);
                case 0x0035: return new Usage(this, id, "Tap", UsageTypes.Osc);
                case 0x0036: return new Usage(this, id, "Quality", UsageTypes.Dv);
                case 0x0037: return new Usage(this, id, "Data Valid", UsageTypes.Mc);
                case 0x0038: return new Usage(this, id, "Transducer Index", UsageTypes.Dv);
                case 0x0039: return new Usage(this, id, "Tablet Function Keys", UsageTypes.Cl);
                case 0x003a: return new Usage(this, id, "Program Change Keys", UsageTypes.Cl);
                case 0x003b: return new Usage(this, id, "Battery Strength", UsageTypes.Dv);
                case 0x003c: return new Usage(this, id, "Invert", UsageTypes.Mc);
                case 0x003d: return new Usage(this, id, "X Tilt", UsageTypes.Dv);
                case 0x003e: return new Usage(this, id, "Y Tilt", UsageTypes.Dv);
                case 0x003f: return new Usage(this, id, "Azimuth", UsageTypes.Dv);
                case 0x0040: return new Usage(this, id, "Altitude", UsageTypes.Dv);
                case 0x0041: return new Usage(this, id, "Twist", UsageTypes.Dv);
                case 0x0042: return new Usage(this, id, "Tip Switch", UsageTypes.Mc);
                case 0x0043: return new Usage(this, id, "Secondary Tip Switch", UsageTypes.Mc);
                case 0x0044: return new Usage(this, id, "Barrel Switch", UsageTypes.Mc);
                case 0x0045: return new Usage(this, id, "Eraser", UsageTypes.Mc);
                case 0x0046: return new Usage(this, id, "Tablet Pick", UsageTypes.Mc);
                case 0x0047: return new Usage(this, id, "Touch Valid", UsageTypes.Mc);
                case 0x0048: return new Usage(this, id, "Width", UsageTypes.Dv);
                case 0x0049: return new Usage(this, id, "Height", UsageTypes.Dv);
                case 0x0051: return new Usage(this, id, "Contact Identifier", UsageTypes.Dv);
                case 0x0052: return new Usage(this, id, "Device Mode", UsageTypes.Dv);
                case 0x0053: return new Usage(this, id, "Device Identifier", UsageTypes.Dv);
                case 0x0054: return new Usage(this, id, "Contact Count", UsageTypes.Dv);
                case 0x0055: return new Usage(this, id, "Contact Count Maximum", UsageTypes.Sv);
                case 0x0056: return new Usage(this, id, "Scan Time", UsageTypes.Dv);
                case 0x0057: return new Usage(this, id, "Surface Width", UsageTypes.Df);
                case 0x0058: return new Usage(this, id, "Button Switch", UsageTypes.Df);
                case 0x0059: return new Usage(this, id, "Pad Type", UsageTypes.Sf);
                case 0x005a: return new Usage(this, id, "Secondary Barrel Switch", UsageTypes.Mc);
                case 0x005b: return new Usage(this, id, "Transducer Serial Number", UsageTypes.Sv);
                case 0x005c: return new Usage(this, id, "Preferred Color", UsageTypes.Dv);
                case 0x0060: return new Usage(this, id, "Latency Mode", UsageTypes.Df);
                case 0x0061: return new Usage(this, id, "Gesture Character Quality", UsageTypes.Dv);
                case 0x0062: return new Usage(this, id, "Character Gesture Data Length", UsageTypes.Dv);
                case 0x0063: return new Usage(this, id, "Character Gesture Data", UsageTypes.Dv);
                case 0x0064: return new Usage(this, id, "Gesture Character Encoding", UsageTypes.NAry);
                case 0x0065: return new Usage(this, id, "UTF8 Character Gesture Encoding", UsageTypes.Sel);
                case 0x0066:
                    return new Usage(this, id, "UTF16 Little Endian Character Gesture Encoding", UsageTypes.Sel);
                case 0x0067: return new Usage(this, id, "UTF16 Big Endian Character Gesture Encoding", UsageTypes.Sel);
                case 0x0068:
                    return new Usage(this, id, "UTF32 Little Endian Character Gesture Encoding", UsageTypes.Sel);
                case 0x0069: return new Usage(this, id, "UTF32 Big Endian Character Gesture Encoding", UsageTypes.Sel);
                case 0x006a: return new Usage(this, id, "Capacitive Heat Map Protocol Vendor ID", UsageTypes.Sv);
                case 0x006b: return new Usage(this, id, "Capacitive Heat Map Protocol Version", UsageTypes.Sv);
                case 0x006c: return new Usage(this, id, "Capacitive Heat Map Frame Data", UsageTypes.Dv);
                case 0x006d: return new Usage(this, id, "Gesture Character Enable", UsageTypes.Df);
                case 0x006e: return new Usage(this, id, "Transducer Serial Number Part 2", UsageTypes.Sv);
                case 0x006f: return new Usage(this, id, "No Preferred Color", UsageTypes.Df);
                case 0x0090: return new Usage(this, id, "Transducer Software Info", UsageTypes.Cl);
                case 0x0091: return new Usage(this, id, "Transducer Vendor ID", UsageTypes.Sv);
                case 0x0092: return new Usage(this, id, "Transducer Product ID", UsageTypes.Sv);
                case 0x0093: return new Usage(this, id, "Device Supported Protocols", UsageTypes.Cl | UsageTypes.NAry);
                case 0x0094:
                    return new Usage(this, id, "Transducer Supported Protocols", UsageTypes.Cl | UsageTypes.NAry);
                case 0x0095: return new Usage(this, id, "No Protocol", UsageTypes.Sel);
                case 0x0096: return new Usage(this, id, "Wacom AES Protocol", UsageTypes.Sel);
                case 0x0097: return new Usage(this, id, "USI Protocol", UsageTypes.Sel);
                case 0x0098: return new Usage(this, id, "Microsoft Pen Protocol", UsageTypes.Sel);
                case 0x00a0: return new Usage(this, id, "Supported Report Rates", UsageTypes.Cl | UsageTypes.Sv);
                case 0x00a1: return new Usage(this, id, "Report Rate", UsageTypes.Dv);
                case 0x00a2: return new Usage(this, id, "Transducer Connected", UsageTypes.Sf);
                case 0x00a3: return new Usage(this, id, "Switch Disabled", UsageTypes.Sel);
                case 0x00a4: return new Usage(this, id, "Switch Unimplemented", UsageTypes.Sel);
                case 0x00a5: return new Usage(this, id, "Transducer Switches", UsageTypes.Cl);
            }

            return base.CreateUsage(id);
        }
    }
}