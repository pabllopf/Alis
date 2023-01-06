// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlTouchFingerEvent.cs
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
        ///     The sdl touchfingerevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlTouchFingerEvent
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
            public long touchId; // SDL_TouchID

            /// <summary>
            ///     The finger id
            /// </summary>
            public long fingerId; // SDL_GestureID

            /// <summary>
            ///     The
            /// </summary>
            public float x;

            /// <summary>
            ///     The
            /// </summary>
            public float y;

            /// <summary>
            ///     The dx
            /// </summary>
            public float dx;

            /// <summary>
            ///     The dy
            /// </summary>
            public float dy;

            /// <summary>
            ///     The pressure
            /// </summary>
            public float pressure;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;
        }
    
}