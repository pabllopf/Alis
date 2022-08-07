// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   MonitorEnumeratedValuesUsagePage.cs
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
    public sealed class MonitorEnumeratedValuesUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of MonitorEnumeratedValues Usage Page.
        /// </summary>
        public static readonly MonitorEnumeratedValuesUsagePage Instance = new MonitorEnumeratedValuesUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="MonitorEnumeratedValuesUsagePage" /> class
        /// </summary>
        private MonitorEnumeratedValuesUsagePage() : base(0x0081, "MonitorEnumeratedValues")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "ENUM_0", UsageTypes.Sel);
                case 0x0002: return new Usage(this, id, "ENUM_1", UsageTypes.Sel);
                case 0x0003: return new Usage(this, id, "ENUM_2", UsageTypes.Sel);
                case 0x0004: return new Usage(this, id, "ENUM_3", UsageTypes.Sel);
                case 0x0005: return new Usage(this, id, "ENUM_4", UsageTypes.Sel);
                case 0x0006: return new Usage(this, id, "ENUM_5", UsageTypes.Sel);
                case 0x0007: return new Usage(this, id, "ENUM_6", UsageTypes.Sel);
                case 0x0008: return new Usage(this, id, "ENUM_7", UsageTypes.Sel);
                case 0x0009: return new Usage(this, id, "ENUM_8", UsageTypes.Sel);
                case 0x000a: return new Usage(this, id, "ENUM_9", UsageTypes.Sel);
                case 0x000b: return new Usage(this, id, "ENUM_10", UsageTypes.Sel);
                case 0x000c: return new Usage(this, id, "ENUM_11", UsageTypes.Sel);
                case 0x000d: return new Usage(this, id, "ENUM_12", UsageTypes.Sel);
                case 0x000e: return new Usage(this, id, "ENUM_13", UsageTypes.Sel);
                case 0x000f: return new Usage(this, id, "ENUM_14", UsageTypes.Sel);
                case 0x0010: return new Usage(this, id, "ENUM_15", UsageTypes.Sel);
            }

            // Create dynamic usages from ranges
            var n = (ushort)(id - 0x0001);
            if (id >= 0x0001 || id < 0xffff) return new Usage(this, id, $"ENUM_{n}", UsageTypes.Sel);

            return base.CreateUsage(id);
        }
    }
}