// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   LightingAndIlluminationUsagePage.cs
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
    public sealed class LightingAndIlluminationUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of LightingAndIllumination Usage Page.
        /// </summary>
        public static readonly LightingAndIlluminationUsagePage Instance = new LightingAndIlluminationUsagePage();

        /// <summary>
        /// Initializes a new instance of the <see cref="LightingAndIlluminationUsagePage"/> class
        /// </summary>
        private LightingAndIlluminationUsagePage() : base(0x0059, "LightingAndIllumination")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id) 
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Lamp Array", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Lamp Array Attributes Report", UsageTypes.CL);
                case 0x0003: return new Usage(this, id, "Lamp Count", UsageTypes.SV|UsageTypes.DV);
                case 0x0004: return new Usage(this, id, "Bounding Box Width (um)", UsageTypes.SV);
                case 0x0005: return new Usage(this, id, "Bounding Box Height (um)", UsageTypes.SV);
                case 0x0006: return new Usage(this, id, "Bounding Box Depth (um)", UsageTypes.SV);
                case 0x0007: return new Usage(this, id, "Lamp Array Kind", UsageTypes.NAry);
                case 0x0008: return new Usage(this, id, "Minimal Update Interval (us)", UsageTypes.SV);
                case 0x0020: return new Usage(this, id, "Lamp Attributes Request Report", UsageTypes.CL);
                case 0x0021: return new Usage(this, id, "Lamp ID", UsageTypes.SV|UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Lamp Attributes Response Report", UsageTypes.CL);
                case 0x0023: return new Usage(this, id, "Position X (um)", UsageTypes.DV);
                case 0x0024: return new Usage(this, id, "Position Y (um)", UsageTypes.DV);
                case 0x0025: return new Usage(this, id, "Position Z (um)", UsageTypes.DV);
                case 0x0026: return new Usage(this, id, "Lamp Purposes", UsageTypes.NAry);
                case 0x0027: return new Usage(this, id, "Update Latency (us)", UsageTypes.DV);
                case 0x0028: return new Usage(this, id, "Red Level Count", UsageTypes.DV);
                case 0x0029: return new Usage(this, id, "Green Level Count", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Blue Level Count", UsageTypes.DV);
                case 0x002b: return new Usage(this, id, "Intensity Level Count", UsageTypes.DV);
                case 0x002c: return new Usage(this, id, "Programmable", UsageTypes.SF|UsageTypes.DF);
                case 0x002d: return new Usage(this, id, "Input Binding", UsageTypes.NAry);
                case 0x0050: return new Usage(this, id, "Lamp Multi Update Report", UsageTypes.CL);
                case 0x0051: return new Usage(this, id, "Red Update Channel", UsageTypes.DV);
                case 0x0052: return new Usage(this, id, "Green Update Channel", UsageTypes.DV);
                case 0x0053: return new Usage(this, id, "Blue Update Channel", UsageTypes.DV);
                case 0x0054: return new Usage(this, id, "Intensity Update Channel", UsageTypes.DV);
                case 0x0055: return new Usage(this, id, "Lamp Update Flags", UsageTypes.DV);
                case 0x0060: return new Usage(this, id, "Lamp Range Update Report", UsageTypes.CL);
                case 0x0061: return new Usage(this, id, "Lamp ID Start", UsageTypes.DV);
                case 0x0062: return new Usage(this, id, "Lamp ID End", UsageTypes.DV);
                case 0x0070: return new Usage(this, id, "Lamp Array Control Report", UsageTypes.CL);
                case 0x0071: return new Usage(this, id, "Autonomous Mode", UsageTypes.DF);
                case 0x1000: return new Usage(this, id, "Lamp Array Kind Keyboard", UsageTypes.Sel);
                case 0x2000: return new Usage(this, id, "Lamp Purpose Control", UsageTypes.Sel);
            }

            return base.CreateUsage(id);
        }
    }
}