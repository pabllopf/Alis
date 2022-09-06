// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:LEDsUsagePage.cs
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
    public sealed class LeDsUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="LeDsUsagePage" /> class
        /// </summary>
        private LeDsUsagePage() : base(0x0008, "LEDs")
        {
        }

        /// <summary>
        ///     Singleton instance of LEDs Usage Page.
        /// </summary>
        public static readonly LeDsUsagePage Instance = new LeDsUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Num Lock", UsageTypes.Ooc);
                case 0x0002: return new Usage(this, id, "Caps Lock", UsageTypes.Ooc);
                case 0x0003: return new Usage(this, id, "Scroll Lock", UsageTypes.Ooc);
                case 0x0004: return new Usage(this, id, "Compose", UsageTypes.Ooc);
                case 0x0005: return new Usage(this, id, "Kana", UsageTypes.Ooc);
                case 0x0006: return new Usage(this, id, "Power", UsageTypes.Ooc);
                case 0x0007: return new Usage(this, id, "Shift", UsageTypes.Ooc);
                case 0x0008: return new Usage(this, id, "Do Not Disturb", UsageTypes.Ooc);
                case 0x0009: return new Usage(this, id, "Mute", UsageTypes.Ooc);
                case 0x000a: return new Usage(this, id, "Tone Enable", UsageTypes.Ooc);
                case 0x000b: return new Usage(this, id, "High Cut Filter", UsageTypes.Ooc);
                case 0x000c: return new Usage(this, id, "Low Cut Filter", UsageTypes.Ooc);
                case 0x000d: return new Usage(this, id, "Equalizer Enable", UsageTypes.Ooc);
                case 0x000e: return new Usage(this, id, "Sound Field On", UsageTypes.Ooc);
                case 0x000f: return new Usage(this, id, "Surround On", UsageTypes.Ooc);
                case 0x0010: return new Usage(this, id, "Repeat", UsageTypes.Ooc);
                case 0x0011: return new Usage(this, id, "Stereo", UsageTypes.Ooc);
                case 0x0012: return new Usage(this, id, "Sampling Rate Detect", UsageTypes.Ooc);
                case 0x0013: return new Usage(this, id, "Spinning", UsageTypes.Ooc);
                case 0x0014: return new Usage(this, id, "CAV", UsageTypes.Ooc);
                case 0x0015: return new Usage(this, id, "CLV", UsageTypes.Ooc);
                case 0x0016: return new Usage(this, id, "Recording Format Detect", UsageTypes.Ooc);
                case 0x0017: return new Usage(this, id, "Off-Hook", UsageTypes.Ooc);
                case 0x0018: return new Usage(this, id, "Ring", UsageTypes.Ooc);
                case 0x0019: return new Usage(this, id, "Message Waiting", UsageTypes.Ooc);
                case 0x001a: return new Usage(this, id, "Data Mode", UsageTypes.Ooc);
                case 0x001b: return new Usage(this, id, "Battery Operation", UsageTypes.Ooc);
                case 0x001c: return new Usage(this, id, "Battery OK", UsageTypes.Ooc);
                case 0x001d: return new Usage(this, id, "Battery Low", UsageTypes.Ooc);
                case 0x001e: return new Usage(this, id, "Speaker", UsageTypes.Ooc);
                case 0x001f: return new Usage(this, id, "Head Set", UsageTypes.Ooc);
                case 0x0020: return new Usage(this, id, "Hold", UsageTypes.Ooc);
                case 0x0021: return new Usage(this, id, "Microphone", UsageTypes.Ooc);
                case 0x0022: return new Usage(this, id, "Coverage", UsageTypes.Ooc);
                case 0x0023: return new Usage(this, id, "Night Mode", UsageTypes.Ooc);
                case 0x0024: return new Usage(this, id, "Send Calls", UsageTypes.Ooc);
                case 0x0025: return new Usage(this, id, "Call Pickup", UsageTypes.Ooc);
                case 0x0026: return new Usage(this, id, "Conference", UsageTypes.Ooc);
                case 0x0027: return new Usage(this, id, "Stand-by", UsageTypes.Ooc);
                case 0x0028: return new Usage(this, id, "Camera On", UsageTypes.Ooc);
                case 0x0029: return new Usage(this, id, "Camera Off", UsageTypes.Ooc);
                case 0x002a: return new Usage(this, id, "On-Line", UsageTypes.Ooc);
                case 0x002b: return new Usage(this, id, "Off-Line", UsageTypes.Ooc);
                case 0x002c: return new Usage(this, id, "Busy", UsageTypes.Ooc);
                case 0x002d: return new Usage(this, id, "Ready", UsageTypes.Ooc);
                case 0x002e: return new Usage(this, id, "Paper-Out", UsageTypes.Ooc);
                case 0x002f: return new Usage(this, id, "Paper-Jam", UsageTypes.Ooc);
                case 0x0030: return new Usage(this, id, "Remote", UsageTypes.Ooc);
                case 0x0031: return new Usage(this, id, "Forward", UsageTypes.Ooc);
                case 0x0032: return new Usage(this, id, "Reverse", UsageTypes.Ooc);
                case 0x0033: return new Usage(this, id, "Stop", UsageTypes.Ooc);
                case 0x0034: return new Usage(this, id, "Rewind", UsageTypes.Ooc);
                case 0x0035: return new Usage(this, id, "Fast Forward", UsageTypes.Ooc);
                case 0x0036: return new Usage(this, id, "Play", UsageTypes.Ooc);
                case 0x0037: return new Usage(this, id, "Pause", UsageTypes.Ooc);
                case 0x0038: return new Usage(this, id, "Record", UsageTypes.Ooc);
                case 0x0039: return new Usage(this, id, "Error", UsageTypes.Ooc);
                case 0x003a: return new Usage(this, id, "Usage Selected Indicator", UsageTypes.Us);
                case 0x003b: return new Usage(this, id, "Usage In Use Indicator", UsageTypes.Us);
                case 0x003c: return new Usage(this, id, "Usage Multi Mode Indicator", UsageTypes.Um);
                case 0x003d: return new Usage(this, id, "Indicator On", UsageTypes.Sel);
                case 0x003e: return new Usage(this, id, "Indicator Flash", UsageTypes.Sel);
                case 0x003f: return new Usage(this, id, "Indicator Slow Blink", UsageTypes.Sel);
                case 0x0040: return new Usage(this, id, "Indicator Fast Blink", UsageTypes.Sel);
                case 0x0041: return new Usage(this, id, "Indicator Off", UsageTypes.Sel);
                case 0x0042: return new Usage(this, id, "Flash On Time", UsageTypes.Dv);
                case 0x0043: return new Usage(this, id, "Slow Blink On Time", UsageTypes.Dv);
                case 0x0044: return new Usage(this, id, "Slow Blink Off Time", UsageTypes.Dv);
                case 0x0045: return new Usage(this, id, "Fast Blink On Time", UsageTypes.Dv);
                case 0x0046: return new Usage(this, id, "Fast Blink Off Time", UsageTypes.Dv);
                case 0x0047: return new Usage(this, id, "Usage Indicator Color", UsageTypes.Um);
                case 0x0048: return new Usage(this, id, "Indicator Red", UsageTypes.Sel);
                case 0x0049: return new Usage(this, id, "Indicator Green", UsageTypes.Sel);
                case 0x004a: return new Usage(this, id, "Indicator Amber", UsageTypes.Sel);
                case 0x004b: return new Usage(this, id, "Generic Indicator", UsageTypes.Ooc);
                case 0x004c: return new Usage(this, id, "System Suspend", UsageTypes.Ooc);
                case 0x004d: return new Usage(this, id, "External Power Connected", UsageTypes.Ooc);
                case 0x004e: return new Usage(this, id, "Indicator Blue", UsageTypes.Sel);
                case 0x004f: return new Usage(this, id, "Indicator Orange", UsageTypes.Sel);
                case 0x0050: return new Usage(this, id, "Good Status", UsageTypes.Ooc);
                case 0x0051: return new Usage(this, id, "Warning Status", UsageTypes.Ooc);
                case 0x0052: return new Usage(this, id, "RGB LED", UsageTypes.Cl);
                case 0x0053: return new Usage(this, id, "Red LED Channel", UsageTypes.Dv);
                case 0x0054: return new Usage(this, id, "Green LED Channel", UsageTypes.Dv);
                case 0x0055: return new Usage(this, id, "Blue LED Channel", UsageTypes.Dv);
                case 0x0056: return new Usage(this, id, "LED Intensity", UsageTypes.Dv);
                case 0x0060: return new Usage(this, id, "Player Indicator", UsageTypes.NAry);
                case 0x0061: return new Usage(this, id, "Player 1", UsageTypes.Sel);
                case 0x0062: return new Usage(this, id, "Player 2", UsageTypes.Sel);
                case 0x0063: return new Usage(this, id, "Player 3", UsageTypes.Sel);
                case 0x0064: return new Usage(this, id, "Player 4", UsageTypes.Sel);
                case 0x0065: return new Usage(this, id, "Player 5", UsageTypes.Sel);
                case 0x0066: return new Usage(this, id, "Player 6", UsageTypes.Sel);
                case 0x0067: return new Usage(this, id, "Player 7", UsageTypes.Sel);
                case 0x0068: return new Usage(this, id, "Player 8", UsageTypes.Sel);
            }

            return base.CreateUsage(id);
        }
    }
}