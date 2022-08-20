// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SportUsagePage.cs
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
    public sealed class SportUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SportUsagePage" /> class
        /// </summary>
        private SportUsagePage() : base(0x0004, "Sport")
        {
        }

        /// <summary>
        ///     Singleton instance of Sport Usage Page.
        /// </summary>
        public static readonly SportUsagePage Instance = new SportUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Baseball Bat", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Golf Club", UsageTypes.CA);
                case 0x0003: return new Usage(this, id, "Rowing Machine", UsageTypes.CA);
                case 0x0004: return new Usage(this, id, "Treadmill", UsageTypes.CA);
                case 0x0030: return new Usage(this, id, "Oar", UsageTypes.DV);
                case 0x0031: return new Usage(this, id, "Slope", UsageTypes.DV);
                case 0x0032: return new Usage(this, id, "Rate", UsageTypes.DV);
                case 0x0033: return new Usage(this, id, "Stick Speed", UsageTypes.DV);
                case 0x0034: return new Usage(this, id, "Stick Face Angle", UsageTypes.DV);
                case 0x0035: return new Usage(this, id, "Stick Heel/Toe", UsageTypes.DV);
                case 0x0036: return new Usage(this, id, "Stick Follow Through", UsageTypes.DV);
                case 0x0037: return new Usage(this, id, "Stick Tempo", UsageTypes.DV);
                case 0x0038: return new Usage(this, id, "Stick Type", UsageTypes.NAry);
                case 0x0039: return new Usage(this, id, "Stick Height", UsageTypes.DV);
                case 0x0050: return new Usage(this, id, "Putter", UsageTypes.Sel);
                case 0x0051: return new Usage(this, id, "1 Iron", UsageTypes.Sel);
                case 0x0052: return new Usage(this, id, "2 Iron", UsageTypes.Sel);
                case 0x0053: return new Usage(this, id, "3 Iron", UsageTypes.Sel);
                case 0x0054: return new Usage(this, id, "4 Iron", UsageTypes.Sel);
                case 0x0055: return new Usage(this, id, "5 Iron", UsageTypes.Sel);
                case 0x0056: return new Usage(this, id, "6 Iron", UsageTypes.Sel);
                case 0x0057: return new Usage(this, id, "7 Iron", UsageTypes.Sel);
                case 0x0058: return new Usage(this, id, "8 Iron", UsageTypes.Sel);
                case 0x0059: return new Usage(this, id, "9 Iron", UsageTypes.Sel);
                case 0x005a: return new Usage(this, id, "10 Iron", UsageTypes.Sel);
                case 0x005b: return new Usage(this, id, "11 Iron", UsageTypes.Sel);
                case 0x005c: return new Usage(this, id, "Sand Wedge", UsageTypes.Sel);
                case 0x005d: return new Usage(this, id, "Loft Wedge", UsageTypes.Sel);
                case 0x005e: return new Usage(this, id, "Power Wedge", UsageTypes.Sel);
                case 0x005f: return new Usage(this, id, "1 Wood", UsageTypes.Sel);
                case 0x0060: return new Usage(this, id, "3 Wood", UsageTypes.Sel);
                case 0x0061: return new Usage(this, id, "5 Wood", UsageTypes.Sel);
                case 0x0062: return new Usage(this, id, "7 Wood", UsageTypes.Sel);
                case 0x0063: return new Usage(this, id, "9 Wood", UsageTypes.Sel);
            }

            return base.CreateUsage(id);
        }
    }
}