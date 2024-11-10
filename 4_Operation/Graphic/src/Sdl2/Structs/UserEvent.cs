// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:UserEvent.cs
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

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl user event
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct UserEvent
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
        ///     The window id
        /// </summary>
        public readonly uint windowID;

        /// <summary>
        ///     The code
        /// </summary>
        public readonly int code;

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data1 { get; set; }

        /// <summary>
        ///     The data
        /// </summary>
        public IntPtr Data2 { get; set; }
    }
}