// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeySym.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sdl2.Enums;
using Alis.Extension.Graphic.Sdl2.Mapping;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL keysym structure, containing the key code, scancode, and modifier flags for a keyboard event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KeySym
    {
        /// <summary>
        ///     The physical key scancode (hardware-based, independent of keyboard layout).
        /// </summary>
        public SdlScancode scancode;

        /// <summary>
        ///     The virtual key code, dependent on the keyboard layout.
        /// </summary>
        public KeyCodes sym;

        /// <summary>
        ///     The current key modifiers (e.g. Ctrl, Shift, Alt) at the time of the event.
        /// </summary>
        public KeyMods mod;

        /// <summary>
        ///     The Unicode character code associated with the key press, or 0 if not applicable.
        /// </summary>
        public uint unicode;
    }
}