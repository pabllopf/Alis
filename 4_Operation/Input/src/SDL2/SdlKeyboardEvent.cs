// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlKeyboardEvent.SdlKeyboardEvent.cs
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

namespace Alis.Core.Input.SDL2
{
    /// <summary>
    ///     The sdl keyboardevent
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlKeyboardEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public uint windowID;

        /// <summary>
        ///     The state
        /// </summary>
        public byte state;

        /// <summary>
        ///     The repeat
        /// </summary>
        public byte repeat; /* non-zero if this is a repeat */

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding2;

        /// <summary>
        ///     The padding
        /// </summary>
        private byte padding3;

        /// <summary>
        ///     The keysym
        /// </summary>
        public SdlKeysym keysym;
    }
}