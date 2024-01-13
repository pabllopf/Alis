// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlTouchFingerEvent.cs
// 
//  Author: Pablo Perdomo Falcón
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

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl touch finger event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlTouchFingerEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly uint type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The touch id
        /// </summary>
        public readonly long touchId; 

        /// <summary>
        ///     The finger id
        /// </summary>
        public readonly long fingerId; 

        /// <summary>
        ///     The
        /// </summary>
        public readonly float x;

        /// <summary>
        ///     The
        /// </summary>
        public readonly float y;

        /// <summary>
        ///     The dx
        /// </summary>
        public readonly float dx;

        /// <summary>
        ///     The dy
        /// </summary>
        public readonly float dy;

        /// <summary>
        ///     The pressure
        /// </summary>
        public readonly float pressure;

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;
    }
}