// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   OrdinalUsagePage.cs
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
    public sealed class OrdinalUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of Ordinal Usage Page.
        /// </summary>
        public static readonly OrdinalUsagePage Instance = new OrdinalUsagePage();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdinalUsagePage"/> class
        /// </summary>
        private OrdinalUsagePage() : base(0x000a, "Ordinal")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id) 
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Instance 0", UsageTypes.UM);
                case 0x0002: return new Usage(this, id, "Instance 1", UsageTypes.UM);
                case 0x0003: return new Usage(this, id, "Instance 2", UsageTypes.UM);
                case 0x0004: return new Usage(this, id, "Instance 3", UsageTypes.UM);
                case 0x0005: return new Usage(this, id, "Instance 4", UsageTypes.UM);
                case 0x0006: return new Usage(this, id, "Instance 5", UsageTypes.UM);
                case 0x0007: return new Usage(this, id, "Instance 6", UsageTypes.UM);
                case 0x0008: return new Usage(this, id, "Instance 7", UsageTypes.UM);
                case 0x0009: return new Usage(this, id, "Instance 8", UsageTypes.UM);
                case 0x000a: return new Usage(this, id, "Instance 9", UsageTypes.UM);
                case 0x000b: return new Usage(this, id, "Instance 10", UsageTypes.UM);
                case 0x000c: return new Usage(this, id, "Instance 11", UsageTypes.UM);
                case 0x000d: return new Usage(this, id, "Instance 12", UsageTypes.UM);
                case 0x000e: return new Usage(this, id, "Instance 13", UsageTypes.UM);
                case 0x000f: return new Usage(this, id, "Instance 14", UsageTypes.UM);
                case 0x0010: return new Usage(this, id, "Instance 15", UsageTypes.UM);
            }

            // Create dynamic usages from ranges
            var n = (ushort)(id-0x0001);
            if (id >= 0x0001 || id < 0xffff) return new Usage(this, id, $"Instance {n}", UsageTypes.UM);

            return base.CreateUsage(id);
        }
    }
}