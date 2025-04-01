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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl dollar gesture event
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct DollarGestureEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public uint timestamp;

        /// <summary>
        ///     The touch id
        /// </summary>
        public long touchId;

        /// <summary>
        ///     The gesture id
        /// </summary>
        public long gestureId;

        /// <summary>
        ///     The num fingers
        /// </summary>
        public uint numFingers;

        /// <summary>
        ///     The error
        /// </summary>
        public float error;

        /// <summary>
        ///     The
        /// </summary>
        public float x;

        /// <summary>
        ///     The
        /// </summary>
        public float y;
    }
}