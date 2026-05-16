// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ControllerTouchpadEvent.cs
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
    ///     Represents an SDL controller touchpad event, fired when a touchpad on a game controller (e.g. PS4/PS5) detects finger motion.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ControllerTouchpadEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.ControllerTouchpadDown"/>, <see cref="EventType.ControllerTouchpadUp"/>, or <see cref="EventType.ControllerTouchpadMotion"/>.
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The SDL joystick instance ID for the controller that generated the event.
        /// </summary>
        public int which;

        /// <summary>
        ///     The index of the touchpad on the controller (0-based, for controllers with multiple touchpads).
        /// </summary>
        public int touchpad;

        /// <summary>
        ///     The index of the finger on the touchpad (0-based).
        /// </summary>
        public int finger;

        /// <summary>
        ///     The normalized X position of the finger on the touchpad, ranging from 0.0 to 1.0.
        /// </summary>
        public float x;

        /// <summary>
        ///     The normalized Y position of the finger on the touchpad, ranging from 0.0 to 1.0.
        /// </summary>
        public float y;

        /// <summary>
        ///     The normalized pressure of the finger on the touchpad, ranging from 0.0 to 1.0.
        /// </summary>
        public float pressure;
    }
}