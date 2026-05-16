// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardEvent.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL keyboard event, fired when a key is pressed or released.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct KeyboardEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.KeyDown"/> or <see cref="EventType.KeyUp"/>.
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The ID of the window that had keyboard focus when the event occurred.
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The key state: SDL_PRESSED (1) or SDL_RELEASED (0).
        /// </summary>
        public readonly byte state;

        /// <summary>
        ///     Non-zero if this is a repeated key event from holding the key down.
        /// </summary>
        public readonly byte repeat;

        /// <summary>
        ///     The keysym structure containing the key code, scancode, and modifier flags.
        /// </summary>
        public KeySym KeySym { get; set; }
    }
}