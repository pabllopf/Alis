// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TouchFingerEvent.cs
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
    ///     Represents an SDL touch finger event, fired when a finger touches, moves, or lifts from a touch device.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct TouchFingerEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.FingerDown"/>, <see cref="EventType.FingerUp"/>, or <see cref="EventType.FingerMotion"/>.
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The touch device ID that generated the event.
        /// </summary>
        public long touchId;

        /// <summary>
        ///     The finger ID for this touch (unique per touch device).
        /// </summary>
        public long fingerId;

        /// <summary>
        ///     The normalized X position of the finger, ranging from 0.0 to 1.0.
        /// </summary>
        public float x;

        /// <summary>
        ///     The normalized Y position of the finger, ranging from 0.0 to 1.0.
        /// </summary>
        public float y;

        /// <summary>
        ///     The normalized X-axis motion delta of the finger since the last event.
        /// </summary>
        public float dx;

        /// <summary>
        ///     The normalized Y-axis motion delta of the finger since the last event.
        /// </summary>
        public float dy;

        /// <summary>
        ///     The normalized pressure of the finger, ranging from 0.0 to 1.0.
        /// </summary>
        public float pressure;

        /// <summary>
        ///     The ID of the window that received the touch event.
        /// </summary>
        public uint windowID;
    }
}