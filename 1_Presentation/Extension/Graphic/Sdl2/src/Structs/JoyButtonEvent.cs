// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:JoyButtonEvent.cs
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
    ///     Represents an SDL joystick button event, fired when a joystick button is pressed or released.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct JoyButtonEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.JoyButtonDown"/> or <see cref="EventType.JoyButtonUp"/>.
        /// </summary>
        public readonly EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The SDL joystick instance ID that generated the event.
        /// </summary>
        public readonly int which;

        /// <summary>
        ///     The index of the joystick button that changed state.
        /// </summary>
        public readonly byte button;

        /// <summary>
        ///     The new state of the button: SDL_PRESSED (1) or SDL_RELEASED (0).
        /// </summary>
        public readonly byte state;
    }
}