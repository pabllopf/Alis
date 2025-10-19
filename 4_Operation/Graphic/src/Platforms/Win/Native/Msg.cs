// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Msg.cs
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

#if winx64 || winx86 || winarm64 || winarm || win

using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Win.Native
{
    /// <summary>
    /// 
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct Msg
    {
        /// <summary>
        /// The hwnd
        /// </summary>
        public IntPtr hwnd;
        /// <summary>
        /// The message
        /// </summary>
        public uint message;
        /// <summary>
        /// The param
        /// </summary>
        public IntPtr wParam;
        /// <summary>
        /// The param
        /// </summary>
        public IntPtr lParam;
        /// <summary>
        /// The time
        /// </summary>
        public uint time;
        /// <summary>
        /// The pt
        /// </summary>
        public int pt_x;
        /// <summary>
        /// The pt
        /// </summary>
        public int pt_y;
    }
}

#endif