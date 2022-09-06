// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericDesktopUsagePage.cs
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
    public sealed class GenericDesktopUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GenericDesktopUsagePage" /> class
        /// </summary>
        private GenericDesktopUsagePage() : base(0x0001, "GenericDesktop")
        {
        }

        /// <summary>
        ///     Singleton instance of GenericDesktop Usage Page.
        /// </summary>
        public static readonly GenericDesktopUsagePage Instance = new GenericDesktopUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Pointer", UsageTypes.Cp);
                case 0x0002: return new Usage(this, id, "Mouse", UsageTypes.Ca);
                case 0x0004: return new Usage(this, id, "Joystick", UsageTypes.Ca);
                case 0x0005: return new Usage(this, id, "Game Pad", UsageTypes.Ca);
                case 0x0006: return new Usage(this, id, "Keyboard", UsageTypes.Ca);
                case 0x0007: return new Usage(this, id, "Keypad", UsageTypes.Ca);
                case 0x0008: return new Usage(this, id, "Multi-axis Controller", UsageTypes.Ca);
                case 0x0009: return new Usage(this, id, "Tablet PC System Controls", UsageTypes.Ca);
                case 0x000a: return new Usage(this, id, "Water Cooling Device", UsageTypes.Ca);
                case 0x000b: return new Usage(this, id, "Computer Chassis Device", UsageTypes.Ca);
                case 0x000c: return new Usage(this, id, "Wireless Radio Controls", UsageTypes.Ca);
                case 0x000d: return new Usage(this, id, "Portable Device Control", UsageTypes.Ca);
                case 0x000e: return new Usage(this, id, "System Multi-axis Controller", UsageTypes.Ca);
                case 0x000f: return new Usage(this, id, "Spatial Controller", UsageTypes.Ca);
                case 0x0010: return new Usage(this, id, "Assistive Control", UsageTypes.Ca);
                case 0x0011: return new Usage(this, id, "Device Dock", UsageTypes.Ca);
                case 0x0012: return new Usage(this, id, "Dockable Device", UsageTypes.Ca);
                case 0x0013: return new Usage(this, id, "Call State Management Control", UsageTypes.Ca);
                case 0x0030: return new Usage(this, id, "X", UsageTypes.Dv);
                case 0x0031: return new Usage(this, id, "Y", UsageTypes.Dv);
                case 0x0032: return new Usage(this, id, "Z", UsageTypes.Dv);
                case 0x0033: return new Usage(this, id, "Rx", UsageTypes.Dv);
                case 0x0034: return new Usage(this, id, "Ry", UsageTypes.Dv);
                case 0x0035: return new Usage(this, id, "Rz", UsageTypes.Dv);
                case 0x0036: return new Usage(this, id, "Slider", UsageTypes.Dv);
                case 0x0037: return new Usage(this, id, "Dial", UsageTypes.Dv);
                case 0x0038: return new Usage(this, id, "Wheel", UsageTypes.Dv);
                case 0x0039: return new Usage(this, id, "Hat switch", UsageTypes.Dv);
                case 0x003a: return new Usage(this, id, "Counter Buffer", UsageTypes.Cl);
                case 0x003b: return new Usage(this, id, "Byte Count", UsageTypes.Dv);
                case 0x003c: return new Usage(this, id, "Motion Wakeup", UsageTypes.Osc);
                case 0x003d: return new Usage(this, id, "Start", UsageTypes.Ooc);
                case 0x003e: return new Usage(this, id, "Select", UsageTypes.Ooc);
                case 0x0040: return new Usage(this, id, "Vx", UsageTypes.Dv);
                case 0x0041: return new Usage(this, id, "Vy", UsageTypes.Dv);
                case 0x0042: return new Usage(this, id, "Vz", UsageTypes.Dv);
                case 0x0043: return new Usage(this, id, "Vbrx", UsageTypes.Dv);
                case 0x0044: return new Usage(this, id, "Vbry", UsageTypes.Dv);
                case 0x0045: return new Usage(this, id, "Vbrz", UsageTypes.Dv);
                case 0x0046: return new Usage(this, id, "Vno", UsageTypes.Dv);
                case 0x0047: return new Usage(this, id, "Feature Notification", UsageTypes.Dv | UsageTypes.Df);
                case 0x0048: return new Usage(this, id, "Resolution Multiplier", UsageTypes.Dv);
                case 0x0049: return new Usage(this, id, "Qx", UsageTypes.Dv);
                case 0x004a: return new Usage(this, id, "Qy", UsageTypes.Dv);
                case 0x004b: return new Usage(this, id, "Qz", UsageTypes.Dv);
                case 0x004c: return new Usage(this, id, "Qw", UsageTypes.Dv);
                case 0x0080: return new Usage(this, id, "System Control", UsageTypes.Ca);
                case 0x0081: return new Usage(this, id, "System Power Down", UsageTypes.Osc);
                case 0x0082: return new Usage(this, id, "System Sleep", UsageTypes.Osc);
                case 0x0083: return new Usage(this, id, "System Wake up", UsageTypes.Osc);
                case 0x0084: return new Usage(this, id, "System Context Menu", UsageTypes.Osc);
                case 0x0085: return new Usage(this, id, "System Main Menu", UsageTypes.Osc);
                case 0x0086: return new Usage(this, id, "System App Menu", UsageTypes.Osc);
                case 0x0087: return new Usage(this, id, "System Menu Help", UsageTypes.Osc);
                case 0x0088: return new Usage(this, id, "System Menu Exit", UsageTypes.Osc);
                case 0x0089: return new Usage(this, id, "System Menu Select", UsageTypes.Osc);
                case 0x008a: return new Usage(this, id, "System Menu Right", UsageTypes.Rtc);
                case 0x008b: return new Usage(this, id, "System Menu Left", UsageTypes.Rtc);
                case 0x008c: return new Usage(this, id, "System Menu Up", UsageTypes.Rtc);
                case 0x008d: return new Usage(this, id, "System Menu Down", UsageTypes.Rtc);
                case 0x008e: return new Usage(this, id, "System Cold Restart", UsageTypes.Osc);
                case 0x008f: return new Usage(this, id, "System Warm Restart", UsageTypes.Osc);
                case 0x0090: return new Usage(this, id, "D-pad Up", UsageTypes.Ooc);
                case 0x0091: return new Usage(this, id, "D-pad Down", UsageTypes.Ooc);
                case 0x0092: return new Usage(this, id, "D-pad Right", UsageTypes.Ooc);
                case 0x0093: return new Usage(this, id, "D-pad Left", UsageTypes.Ooc);
                case 0x0094: return new Usage(this, id, "Index Trigger", UsageTypes.Mc | UsageTypes.Dv);
                case 0x0095: return new Usage(this, id, "Palm Trigger", UsageTypes.Mc | UsageTypes.Dv);
                case 0x0096: return new Usage(this, id, "Thumbstick", UsageTypes.Cp);
                case 0x0097: return new Usage(this, id, "System Function Shift", UsageTypes.Mc);
                case 0x0098: return new Usage(this, id, "System Function Shift Lock", UsageTypes.Ooc);
                case 0x0099: return new Usage(this, id, "System Function Shift Lock Indicator", UsageTypes.Dv);
                case 0x009a: return new Usage(this, id, "System Dismiss Notification", UsageTypes.Osc);
                case 0x009b: return new Usage(this, id, "System Do Not Disturb", UsageTypes.Ooc);
                case 0x00a0: return new Usage(this, id, "System Dock", UsageTypes.Osc);
                case 0x00a1: return new Usage(this, id, "System Undock", UsageTypes.Osc);
                case 0x00a2: return new Usage(this, id, "System Setup", UsageTypes.Osc);
                case 0x00a3: return new Usage(this, id, "System Break", UsageTypes.Osc);
                case 0x00a4: return new Usage(this, id, "System Debugger Break", UsageTypes.Osc);
                case 0x00a5: return new Usage(this, id, "Application Break", UsageTypes.Osc);
                case 0x00a6: return new Usage(this, id, "Application Debugger Break", UsageTypes.Osc);
                case 0x00a7: return new Usage(this, id, "System Speaker Mute", UsageTypes.Osc);
                case 0x00a8: return new Usage(this, id, "System Hibernate", UsageTypes.Osc);
                case 0x00b0: return new Usage(this, id, "System Display Invert", UsageTypes.Osc);
                case 0x00b1: return new Usage(this, id, "System Display Internal", UsageTypes.Osc);
                case 0x00b2: return new Usage(this, id, "System Display External", UsageTypes.Osc);
                case 0x00b3: return new Usage(this, id, "System Display Both", UsageTypes.Osc);
                case 0x00b4: return new Usage(this, id, "System Display Dual", UsageTypes.Osc);
                case 0x00b5: return new Usage(this, id, "System Display Toggle Int/Ext", UsageTypes.Osc);
                case 0x00b6: return new Usage(this, id, "System Display Swap Primary/Secondary", UsageTypes.Osc);
                case 0x00b7: return new Usage(this, id, "System Display LCD Autoscale", UsageTypes.Osc);
                case 0x00c0: return new Usage(this, id, "Sensor Zone", UsageTypes.Cl);
                case 0x00c1: return new Usage(this, id, "RPM", UsageTypes.Dv);
                case 0x00c2: return new Usage(this, id, "Coolant Level", UsageTypes.Dv);
                case 0x00c3: return new Usage(this, id, "Coolant Critical Level", UsageTypes.Sv);
                case 0x00c4: return new Usage(this, id, "Coolant Pump", UsageTypes.Us);
                case 0x00c5: return new Usage(this, id, "Chassis Enclosure", UsageTypes.Cl);
                case 0x00c6: return new Usage(this, id, "Wireless Radio Button", UsageTypes.Ooc);
                case 0x00c7: return new Usage(this, id, "Wireless Radio LED", UsageTypes.Ooc);
                case 0x00c8: return new Usage(this, id, "Wireless Radio Slider Switch", UsageTypes.Ooc);
                case 0x00c9: return new Usage(this, id, "System Display Rotation Lock Button", UsageTypes.Ooc);
                case 0x00ca: return new Usage(this, id, "System Display Rotation Lock Slider Switch", UsageTypes.Ooc);
                case 0x00cb: return new Usage(this, id, "Control Enable", UsageTypes.Df);
                case 0x00d0: return new Usage(this, id, "Dockable Device Unique ID", UsageTypes.Dv);
                case 0x00d1: return new Usage(this, id, "Dockable Device Vendor ID", UsageTypes.Dv);
                case 0x00d2: return new Usage(this, id, "Dockable Device Primary Usage Page", UsageTypes.Dv);
                case 0x00d3: return new Usage(this, id, "Dockable Device Primary Usage ID", UsageTypes.Dv);
                case 0x00d4: return new Usage(this, id, "Dockable Device Docking State", UsageTypes.Df);
                case 0x00d5: return new Usage(this, id, "Dockable Device Display Occlusion", UsageTypes.Cl);
                case 0x00d6: return new Usage(this, id, "Dockable Device Object Type", UsageTypes.Dv);
                case 0x00e0: return new Usage(this, id, "Call Active LED", UsageTypes.Ooc);
                case 0x00e1: return new Usage(this, id, "Call Mute Toggle", UsageTypes.Osc);
                case 0x00e2: return new Usage(this, id, "Call Mute LED", UsageTypes.Ooc);
            }

            return base.CreateUsage(id);
        }
    }
}