// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MultiGestureEvent.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL multi-finger gesture event, fired when a multi-touch gesture is detected.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct MultiGestureEvent
    {
        /// <summary>
        ///     The event type identifier, set to <see cref="EventType.MultiGesture"/>.
        /// </summary>
        public readonly uint type;

        /// <summary>
        ///     The timestamp of the event, in milliseconds, from the SDL event system.
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The touch device ID that registered the gesture.
        /// </summary>
        public readonly long touchId;

        /// <summary>
        ///     The angular rotation delta of the multi-finger gesture in radians.
        /// </summary>
        public readonly float dTheta;

        /// <summary>
        ///     The distance delta of the multi-finger gesture (pinch/spread).
        /// </summary>
        public readonly float dDist;

        /// <summary>
        ///     The normalized X coordinate of the gesture centroid.
        /// </summary>
        public readonly float x;

        /// <summary>
        ///     The normalized Y coordinate of the gesture centroid.
        /// </summary>
        public readonly float y;

        /// <summary>
        ///     The number of fingers involved in the gesture.
        /// </summary>
        public readonly ushort numFingers;

        /// <summary>
        ///     Padding bytes for struct alignment.
        /// </summary>
        public readonly ushort padding;
    }
}