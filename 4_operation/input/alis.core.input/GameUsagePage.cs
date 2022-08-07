// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   GameUsagePage.cs
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
    public sealed class GameUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of Game Usage Page.
        /// </summary>
        public static readonly GameUsagePage Instance = new GameUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameUsagePage" /> class
        /// </summary>
        private GameUsagePage() : base(0x0005, "Game")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "3D Game Controller", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Pinball Device", UsageTypes.CA);
                case 0x0003: return new Usage(this, id, "Gun Device", UsageTypes.CA);
                case 0x0020: return new Usage(this, id, "Point of View", UsageTypes.CP);
                case 0x0021: return new Usage(this, id, "Turn Right/Left", UsageTypes.DV);
                case 0x0022: return new Usage(this, id, "Pitch Right/Left", UsageTypes.DV);
                case 0x0023: return new Usage(this, id, "Roll Right/Left", UsageTypes.DV);
                case 0x0024: return new Usage(this, id, "Move Right/Left", UsageTypes.DV);
                case 0x0025: return new Usage(this, id, "Move Forward/Backward", UsageTypes.DV);
                case 0x0026: return new Usage(this, id, "Move Up/Down", UsageTypes.DV);
                case 0x0027: return new Usage(this, id, "Lean Right/Left", UsageTypes.DV);
                case 0x0028: return new Usage(this, id, "Lean Forward/Backward", UsageTypes.DV);
                case 0x0029: return new Usage(this, id, "Height of POV", UsageTypes.DV);
                case 0x002a: return new Usage(this, id, "Flipper", UsageTypes.MC);
                case 0x002b: return new Usage(this, id, "Secondary Flipper", UsageTypes.MC);
                case 0x002c: return new Usage(this, id, "Bump", UsageTypes.MC);
                case 0x002d: return new Usage(this, id, "New Game", UsageTypes.OSC);
                case 0x002e: return new Usage(this, id, "Shoot Ball", UsageTypes.OSC);
                case 0x002f: return new Usage(this, id, "Player", UsageTypes.OSC);
                case 0x0030: return new Usage(this, id, "Gun Bolt", UsageTypes.OOC);
                case 0x0031: return new Usage(this, id, "Gun Clip", UsageTypes.OOC);
                case 0x0032: return new Usage(this, id, "Gun Selector", UsageTypes.NAry);
                case 0x0033: return new Usage(this, id, "Gun Single Shot", UsageTypes.Sel);
                case 0x0034: return new Usage(this, id, "Gun Burst", UsageTypes.Sel);
                case 0x0035: return new Usage(this, id, "Gun Automatic", UsageTypes.Sel);
                case 0x0036: return new Usage(this, id, "Gun Safety", UsageTypes.OOC);
                case 0x0037: return new Usage(this, id, "Gamepad Fire/Jump", UsageTypes.CL);
                case 0x0039: return new Usage(this, id, "Gamepad Trigger", UsageTypes.CL);
                case 0x003a: return new Usage(this, id, "Form-fitting Gamepad", UsageTypes.SF);
            }

            return base.CreateUsage(id);
        }
    }
}