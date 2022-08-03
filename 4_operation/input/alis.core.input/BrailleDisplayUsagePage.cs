// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   BrailleDisplayUsagePage.cs
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
    public sealed class BrailleDisplayUsagePage : UsagePage
    {
        /// <summary>
        ///     Singleton instance of BrailleDisplay Usage Page.
        /// </summary>
        public static readonly BrailleDisplayUsagePage Instance = new BrailleDisplayUsagePage();

        /// <summary>
        ///     Initializes a new instance of the <see cref="BrailleDisplayUsagePage" /> class
        /// </summary>
        private BrailleDisplayUsagePage() : base(0x0041, "BrailleDisplay")
        {
        }

        /// <inheritdoc />
        protected override Usage CreateUsage(ushort id)
        {
            switch (id)
            {
                case 0x0000: return new Usage(this, id, "Undefined", UsageTypes.None);
                case 0x0001: return new Usage(this, id, "Braille Display", UsageTypes.CA);
                case 0x0002: return new Usage(this, id, "Braille Row", UsageTypes.NAry);
                case 0x0003: return new Usage(this, id, "8 Dot Braille Cell", UsageTypes.DV);
                case 0x0004: return new Usage(this, id, "6 Dot Braille Cell", UsageTypes.DV);
                case 0x0005: return new Usage(this, id, "Number of Braille Cells", UsageTypes.DV);
                case 0x0006: return new Usage(this, id, "Screen Reader Control", UsageTypes.NAry);
                case 0x0007: return new Usage(this, id, "Screen Reader Identifier", UsageTypes.DV);
                case 0x00fa: return new Usage(this, id, "Router Set 1", UsageTypes.NAry);
                case 0x00fb: return new Usage(this, id, "Router Set 2", UsageTypes.NAry);
                case 0x00fc: return new Usage(this, id, "Router Set 3", UsageTypes.NAry);
                case 0x0100: return new Usage(this, id, "Braille Buttons", UsageTypes.NAry);
                case 0x0201: return new Usage(this, id, "Braille Keyboard Dot 1", UsageTypes.Sel);
                case 0x0202: return new Usage(this, id, "Braille Keyboard Dot 2", UsageTypes.Sel);
                case 0x0203: return new Usage(this, id, "Braille Keyboard Dot 3", UsageTypes.Sel);
                case 0x0204: return new Usage(this, id, "Braille Keyboard Dot 4", UsageTypes.Sel);
                case 0x0205: return new Usage(this, id, "Braille Keyboard Dot 5", UsageTypes.Sel);
                case 0x0206: return new Usage(this, id, "Braille Keyboard Dot 6", UsageTypes.Sel);
                case 0x0207: return new Usage(this, id, "Braille Keyboard Dot 7", UsageTypes.Sel);
                case 0x0208: return new Usage(this, id, "Braille Keyboard Dot 8", UsageTypes.Sel);
                case 0x0209: return new Usage(this, id, "Braille Keyboard Space", UsageTypes.Sel);
                case 0x020a: return new Usage(this, id, "Braille Keyboard Left Space", UsageTypes.Sel);
                case 0x020b: return new Usage(this, id, "Braille Keyboard Right Space", UsageTypes.Sel);
                case 0x020c: return new Usage(this, id, "Braille Face Controls", UsageTypes.NAry);
                case 0x020d: return new Usage(this, id, "Braille Left Controls", UsageTypes.NAry);
                case 0x020e: return new Usage(this, id, "Braille Right Controls", UsageTypes.NAry);
                case 0x020f: return new Usage(this, id, "Braille Top Controls", UsageTypes.NAry);
                case 0x0210: return new Usage(this, id, "Braille Joystick Center", UsageTypes.Sel);
                case 0x0211: return new Usage(this, id, "Braille Joystick Up", UsageTypes.Sel);
                case 0x0212: return new Usage(this, id, "Braille Joystick Down", UsageTypes.Sel);
                case 0x0213: return new Usage(this, id, "Braille Joystick Left", UsageTypes.Sel);
                case 0x0214: return new Usage(this, id, "Braille Joystick Right", UsageTypes.Sel);
                case 0x0215: return new Usage(this, id, "Braille D-pad Center", UsageTypes.Sel);
                case 0x0216: return new Usage(this, id, "Braille D-pad Up", UsageTypes.Sel);
                case 0x0217: return new Usage(this, id, "Braille D-pad Down", UsageTypes.Sel);
                case 0x0218: return new Usage(this, id, "Braille D-pad Left", UsageTypes.Sel);
                case 0x0219: return new Usage(this, id, "Braille D-pad Right", UsageTypes.Sel);
                case 0x021a: return new Usage(this, id, "Braille Pan Left", UsageTypes.Sel);
                case 0x021b: return new Usage(this, id, "Braille Pan Right", UsageTypes.Sel);
                case 0x021c: return new Usage(this, id, "Braille Rocker Up", UsageTypes.Sel);
                case 0x021d: return new Usage(this, id, "Braille Rocker Down", UsageTypes.Sel);
                case 0x021e: return new Usage(this, id, "Braille Rocker Press", UsageTypes.Sel);
            }

            return base.CreateUsage(id);
        }
    }
}