// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XKeyEvent.cs
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

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
    /// <summary>
    /// Native X11 keyboard event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XKeyEvent
    {
        /// <summary>
        /// The type
        /// </summary>
        public int type;
        /// <summary>
        /// The serial
        /// </summary>
        public UIntPtr serial;
        /// <summary>
        /// The send event
        /// </summary>
        public int send_event;
        /// <summary>
        /// The display
        /// </summary>
        public IntPtr display;
        /// <summary>
        /// The window
        /// </summary>
        public UIntPtr window;
        /// <summary>
        /// The root
        /// </summary>
        public UIntPtr root;
        /// <summary>
        /// The subwindow
        /// </summary>
        public UIntPtr subwindow;
        /// <summary>
        /// The time
        /// </summary>
        public UIntPtr time;
        /// <summary>
        /// The 
        /// </summary>
        public int x;
        /// <summary>
        /// The 
        /// </summary>
        public int y;
        /// <summary>
        /// The root
        /// </summary>
        public int x_root;
        /// <summary>
        /// The root
        /// </summary>
        public int y_root;
        /// <summary>
        /// The state
        /// </summary>
        public uint state;
        /// <summary>
        /// The keycode
        /// </summary>
        public uint keycode;
        /// <summary>
        /// The same screen
        /// </summary>
        public int same_screen;
    }
}