// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ArcadeUsagePage.cs
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
    public sealed class ArcadeUsagePage : UsagePage
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ArcadeUsagePage" /> class
        /// </summary>
        private ArcadeUsagePage() : base(0x0091, "Arcade")
        {
        }

        /// <summary>
        ///     Singleton instance of Arcade Usage Page.
        /// </summary>
        public static readonly ArcadeUsagePage Instance = new ArcadeUsagePage();

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "General Purpose IO Card", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Coin Door", UsageTypes.CA);
                case 0x0003: return new Usage(this, id, "Watchdog Timer", UsageTypes.CA);
                case 0x0030: return new Usage(this, id, "General Purpose Analog Input State", UsageTypes.DV);
                case 0x0031: return new Usage(this, id, "General Purpose Digital Input State", UsageTypes.DV);
                case 0x0032: return new Usage(this, id, "General Purpose Optical Input State", UsageTypes.DV);
                case 0x0033: return new Usage(this, id, "General Purpose Digital Output State", UsageTypes.DV);
                case 0x0034: return new Usage(this, id, "Number of Coin Doors", UsageTypes.DV);
                case 0x0035: return new Usage(this, id, "Coin Drawer Drop Count", UsageTypes.DV);
                case 0x0036: return new Usage(this, id, "Coin Drawer Start", UsageTypes.OOC);
                case 0x0037: return new Usage(this, id, "Coin Drawer Service", UsageTypes.OOC);
                case 0x0038: return new Usage(this, id, "Coin Drawer Tilt", UsageTypes.OOC);
                case 0x0039: return new Usage(this, id, "Coin Door Test", UsageTypes.OOC);
                case 0x0040: return new Usage(this, id, "Coin Door Lockout", UsageTypes.OOC);
                case 0x0041: return new Usage(this, id, "Watchdog Timeout", UsageTypes.DV);
                case 0x0042: return new Usage(this, id, "Watchdog Action", UsageTypes.NAry);
                case 0x0043: return new Usage(this, id, "Watchdog Reboot", UsageTypes.Sel);
                case 0x0044: return new Usage(this, id, "Watchdog Restart", UsageTypes.Sel);
                case 0x0045: return new Usage(this, id, "Alarm Input", UsageTypes.DV);
                case 0x0046: return new Usage(this, id, "Coin Door Counter", UsageTypes.OOC);
                case 0x0047: return new Usage(this, id, "I/O Direction Mapping", UsageTypes.DV);
                case 0x0048: return new Usage(this, id, "Set I/O Direction", UsageTypes.OOC);
                case 0x0049: return new Usage(this, id, "Extended Optical Input State", UsageTypes.DV);
                case 0x004a: return new Usage(this, id, "Pin Pad Input State", UsageTypes.DV);
                case 0x004b: return new Usage(this, id, "Pin Pad Status", UsageTypes.DV);
                case 0x004c: return new Usage(this, id, "Pin Pad Output", UsageTypes.OOC);
                case 0x004d: return new Usage(this, id, "Pin Pad Command", UsageTypes.DV);
            }

            return base.CreateUsage(id);
        }
    }
}