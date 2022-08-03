// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   VRUsagePage.cs
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
    public sealed class VRUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of VR Usage Page.
        /// </summary>
        public static readonly VRUsagePage Instance = new VRUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="VRUsagePage" /> class
        /// </summary>
        private VRUsagePage() : base(0x0003, "VR")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Belt", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Body Suit", UsageTypes.CA);
                case 0x0003: return new Usage(this, id, "Flexor", UsageTypes.CP);
                case 0x0004: return new Usage(this, id, "Glove", UsageTypes.CA);
                case 0x0005: return new Usage(this, id, "Head Tracker", UsageTypes.CP);
                case 0x0006: return new Usage(this, id, "Head Mounted Display", UsageTypes.CA);
                case 0x0007: return new Usage(this, id, "Hand Tracker", UsageTypes.CA);
                case 0x0008: return new Usage(this, id, "Oculometer", UsageTypes.CA);
                case 0x0009: return new Usage(this, id, "Vest", UsageTypes.CA);
                case 0x000a: return new Usage(this, id, "Animatronic Device", UsageTypes.CA);
                case 0x0020: return new Usage(this, id, "Stereo Enable", UsageTypes.OOC);
                case 0x0021: return new Usage(this, id, "Display Enable", UsageTypes.OOC);
            }

            return base.CreateUsage(id);
        }
    }
}