// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XClientMessageEvent.cs
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
    /// Native X11 client-message event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XClientMessageEvent
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
        /// The message type
        /// </summary>
        public UIntPtr message_type;
        /// <summary>
        /// The format
        /// </summary>
        public int format;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr data0;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr data1;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr data2;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr data3;
        /// <summary>
        /// The data
        /// </summary>
        public IntPtr data4;
    }
}