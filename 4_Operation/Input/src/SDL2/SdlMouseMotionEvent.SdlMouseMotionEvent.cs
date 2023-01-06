// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Sdl.SdlMouseMotionEvent.cs
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
        ///     The sdl mousemotionevent
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct SdlMouseMotionEvent
        {
            /// <summary>
            ///     The type
            /// </summary>
            public SdlEventType type;

            /// <summary>
            ///     The timestamp
            /// </summary>
            public uint timestamp;

            /// <summary>
            ///     The window id
            /// </summary>
            public uint windowID;

            /// <summary>
            ///     The which
            /// </summary>
            public uint which;

            /// <summary>
            ///     The state
            /// </summary>
            public byte state; /* bitmask of buttons */

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding1;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding2;

            /// <summary>
            ///     The padding
            /// </summary>
            private byte padding3;

            /// <summary>
            ///     The
            /// </summary>
            public int x;

            /// <summary>
            ///     The
            /// </summary>
            public int y;

            /// <summary>
            ///     The xrel
            /// </summary>
            public int xrel;

            /// <summary>
            ///     The yrel
            /// </summary>
            public int yrel;
        
    }
}