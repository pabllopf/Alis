// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   HapticsUsagePage.cs
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
    public sealed class HapticsUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of Haptics Usage Page.
        /// </summary>
        public static readonly HapticsUsagePage Instance = new HapticsUsagePage();

        /// <summary>
        /// Initializes a new instance of the <see cref="HapticsUsagePage"/> class
        /// </summary>
        private HapticsUsagePage() : base(0x000e, "Haptics")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id) 
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Simple Haptic Controller", UsageTypes.CA|UsageTypes.CL);
                case 0x0010: return new Usage(this, id, "Waveform List", UsageTypes.NAry);
                case 0x0011: return new Usage(this, id, "Duration List", UsageTypes.NAry);
                case 0x0020: return new Usage(this, id, "Auto Trigger", UsageTypes.DV);
                case 0x0021: return new Usage(this, id, "Manual Trigger", UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Auto Trigger Associated Control", UsageTypes.SV);
                case 0x0023: return new Usage(this, id, "Intensity", UsageTypes.DV);
                case 0x0024: return new Usage(this, id, "Repeat Count", UsageTypes.DV);
                case 0x0025: return new Usage(this, id, "Retrigger Period", UsageTypes.DV);
                case 0x0026: return new Usage(this, id, "Waveform Vendor Page", UsageTypes.SV);
                case 0x0027: return new Usage(this, id, "Waveform Vendor ID", UsageTypes.SV);
                case 0x0028: return new Usage(this, id, "Waveform Cutoff Time", UsageTypes.SV);
                case 0x1001: return new Usage(this, id, "Waveform None", UsageTypes.SV);
                case 0x1002: return new Usage(this, id, "Waveform Stop", UsageTypes.SV);
                case 0x1003: return new Usage(this, id, "Waveform Click", UsageTypes.SV);
                case 0x1004: return new Usage(this, id, "Waveform Buzz Continuous", UsageTypes.SV);
                case 0x1005: return new Usage(this, id, "Waveform Rumble Continuous", UsageTypes.SV);
                case 0x1006: return new Usage(this, id, "Waveform Press", UsageTypes.SV);
                case 0x1007: return new Usage(this, id, "Waveform Release", UsageTypes.SV);
                case 0x1008: return new Usage(this, id, "Waveform Hover", UsageTypes.SV);
                case 0x1009: return new Usage(this, id, "Waveform Success", UsageTypes.SV);
                case 0x100a: return new Usage(this, id, "Waveform Error", UsageTypes.SV);
                case 0x100b: return new Usage(this, id, "Waveform Ink Continuous", UsageTypes.SV);
                case 0x100c: return new Usage(this, id, "Waveform Pencil Continuous", UsageTypes.SV);
                case 0x100d: return new Usage(this, id, "Waveform Marker Continuous", UsageTypes.SV);
                case 0x100e: return new Usage(this, id, "Waveform Chisel Marker Continuous", UsageTypes.SV);
                case 0x100f: return new Usage(this, id, "Waveform Brush Continuous", UsageTypes.SV);
                case 0x1010: return new Usage(this, id, "Waveform Eraser Continuous", UsageTypes.SV);
                case 0x1011: return new Usage(this, id, "Waveform Sparkle Continuous", UsageTypes.SV);
            }

            return base.CreateUsage(id);
        }
    }
}