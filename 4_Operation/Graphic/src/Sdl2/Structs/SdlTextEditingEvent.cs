// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlTextEditingEvent.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Sdl2.Enums;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl text editing event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public readonly struct SdlTextEditingEvent
    {
        /// <summary>
        ///     The type
        /// </summary>
        public readonly SdlEventType type;

        /// <summary>
        ///     The timestamp
        /// </summary>
        public readonly uint timestamp;

        /// <summary>
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The sdl text editing event text size
        /// </summary>
        private readonly IntPtr textPtr;

        /// <summary>
        ///     The start
        /// </summary>
        public readonly int start;

        /// <summary>
        ///     The length
        /// </summary>
        public readonly int length;
        
        /// <summary>
        /// Gets the value of the text
        /// </summary>
        public string Text => Marshal.PtrToStringAnsi(textPtr);
    }
}