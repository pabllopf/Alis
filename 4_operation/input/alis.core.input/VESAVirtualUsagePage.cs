// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VESAVirtualUsagePage.cs
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

namespace Alis.Core.Input
{
#pragma warning disable CS0108
    /// <summary>
    ///     Base class for all usage pages.
    /// </summary>
    public sealed class VESAVirtualUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of VESAVirtual Usage Page.
        /// </summary>
        public static readonly VESAVirtualUsagePage Instance = new VESAVirtualUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="VESAVirtualUsagePage" /> class
        /// </summary>
        private VESAVirtualUsagePage() : base(0x0082, "VESAVirtual")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Degauss", UsageTypes.DF);
                case 0x0010: return new Usage(this, id, "Brightness", UsageTypes.DV);
                case 0x0012: return new Usage(this, id, "Contrast", UsageTypes.DV);
                case 0x0016: return new Usage(this, id, "Red Video Gain", UsageTypes.DV);
                case 0x0018: return new Usage(this, id, "Green Video Gain", UsageTypes.DV);
                case 0x001a: return new Usage(this, id, "Blue Video Gain", UsageTypes.DV);
                case 0x001c: return new Usage(this, id, "Focus", UsageTypes.DV);
                case 0x0020: return new Usage(this, id, "Horizontal Position", UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Horizontal Size", UsageTypes.DV);
                case 0x0024: return new Usage(this, id, "Horizontal Pincushion", UsageTypes.DV);
                case 0x0026: return new Usage(this, id, "Horizontal Pincushion Balance", UsageTypes.DV);
                case 0x0028: return new Usage(this, id, "Horizontal Misconvergence", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Horizontal Linearity", UsageTypes.DV);
                case 0x002c: return new Usage(this, id, "Horizontal Linearity Balance", UsageTypes.DV);
                case 0x0030: return new Usage(this, id, "Vertical Position", UsageTypes.DV);
                case 0x0032: return new Usage(this, id, "Vertical Size", UsageTypes.DV);
                case 0x0034: return new Usage(this, id, "Vertical Pincushion", UsageTypes.DV);
                case 0x0036: return new Usage(this, id, "Vertical Pincushion Balance", UsageTypes.DV);
                case 0x0038: return new Usage(this, id, "Vertical Misconvergence", UsageTypes.DV);
                case 0x003a: return new Usage(this, id, "Vertical Linearity", UsageTypes.DV);
                case 0x003c: return new Usage(this, id, "Vertical Linearity Balance", UsageTypes.DV);
                case 0x0040: return new Usage(this, id, "Parallelogram Distortion (Key Balance)", UsageTypes.DV);
                case 0x0042: return new Usage(this, id, "Trapezoidal Distortion (Key)", UsageTypes.DV);
                case 0x0044: return new Usage(this, id, "Tilt (Rotation)", UsageTypes.DV);
                case 0x0046: return new Usage(this, id, "Top Corner Distortion Control", UsageTypes.DV);
                case 0x0048: return new Usage(this, id, "Top Corner Distortion Balance", UsageTypes.DV);
                case 0x004a: return new Usage(this, id, "Bottom Corner Distortion Control", UsageTypes.DV);
                case 0x004c: return new Usage(this, id, "Bottom Corner Distortion Balance", UsageTypes.DV);
                case 0x0056: return new Usage(this, id, "Horizontal Moire", UsageTypes.DV);
                case 0x0058: return new Usage(this, id, "Vertical Moire", UsageTypes.DV);
                case 0x005e: return new Usage(this, id, "Input Level Select", UsageTypes.NAry);
                case 0x0060: return new Usage(this, id, "Input Source Select", UsageTypes.NAry);
                case 0x006c: return new Usage(this, id, "Red Video Black Level", UsageTypes.DV);
                case 0x006e: return new Usage(this, id, "Green Video Black Level", UsageTypes.DV);
                case 0x0070: return new Usage(this, id, "Blue Video Black Level", UsageTypes.DV);
                case 0x00a2: return new Usage(this, id, "Auto Size Center", UsageTypes.NAry);
                case 0x00a4: return new Usage(this, id, "Polarity Horizontal Synchronization", UsageTypes.NAry);
                case 0x00a6: return new Usage(this, id, "Polarity Vertical Synchronization", UsageTypes.NAry);
                case 0x00a8: return new Usage(this, id, "Synchronization Type", UsageTypes.NAry);
                case 0x00aa: return new Usage(this, id, "Screen Orientation", UsageTypes.NAry);
                case 0x00ac: return new Usage(this, id, "Horizontal Frequency", UsageTypes.SV);
                case 0x00ae: return new Usage(this, id, "Vertical Frequency", UsageTypes.SV);
                case 0x00b0: return new Usage(this, id, "Settings", UsageTypes.NAry);
                case 0x00ca: return new Usage(this, id, "On Screen Display", UsageTypes.NAry);
                case 0x00d4: return new Usage(this, id, "StereoMode", UsageTypes.NAry);
            }

            return base.CreateUsage(id);
        }
    }
}