// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DollarGestureEvent.cs
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
    ///     Represents an SDL dollar gesture event, fired when a dollar-template gesture is detected.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DollarGestureEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.DollarGesture"/> or <see cref="EventType.DollarRecord"/>.
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The touch device ID that registered the gesture.
        /// </summary>
        public long touchId;

        /// <summary>
        ///     The unique identifier of the matched dollar gesture template.
        /// </summary>
        public long gestureId;

        /// <summary>
        ///     The number of fingers used in the gesture.
        /// </summary>
        public uint numFingers;

        /// <summary>
        ///     The error value of the gesture match (lower is a better match).
        /// </summary>
        public float error;

        /// <summary>
        ///     The normalized X coordinate of the gesture centroid.
        /// </summary>
        public float x;

        /// <summary>
        ///     The normalized Y coordinate of the gesture centroid.
        /// </summary>
        public float y;
    }
}