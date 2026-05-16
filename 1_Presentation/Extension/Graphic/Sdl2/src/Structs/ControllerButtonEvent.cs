// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerButtonEvent.cs
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
    ///     Represents an SDL controller button event, fired when a game controller button is pressed or released.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerButtonEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.ControllerButtonDown"/> or <see cref="EventType.ControllerButtonUp"/>.
        /// </summary>
        public EventType type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The SDL joystick instance ID for the controller that generated the event.
        /// </summary>
        public int which;

        /// <summary>
        ///     The controller button index (e.g. SDL_CONTROLLER_BUTTON_A, SDL_CONTROLLER_BUTTON_B).
        /// </summary>
        public byte button;

        /// <summary>
        ///     The button state: SDL_PRESSED (1) or SDL_RELEASED (0).
        /// </summary>
        public byte state;
    }
}