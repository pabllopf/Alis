// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:XEvent.cs
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

#if linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
    /// <summary>
    /// Represents the native X11 event union used by <c>XNextEvent</c>.
    /// </summary>
    [StructLayout(LayoutKind.Explicit, Size = 192)]
    internal struct XEvent
    {
        /// <summary>
        /// The event type.
        /// </summary>
        [FieldOffset(0)]
        public int type;

        /// <summary>
        /// Shared event header.
        /// </summary>
        [FieldOffset(0)]
        public XAnyEvent xany;

        /// <summary>
        /// Keyboard event payload.
        /// </summary>
        [FieldOffset(0)]
        public XKeyEvent xkey;

        /// <summary>
        /// Mouse button event payload.
        /// </summary>
        [FieldOffset(0)]
        public XButtonEvent xbutton;

        /// <summary>
        /// Mouse motion event payload.
        /// </summary>
        [FieldOffset(0)]
        public XMotionEvent xmotion;

        /// <summary>
        /// Window configuration event payload.
        /// </summary>
        [FieldOffset(0)]
        public XConfigureEvent xconfigure;

        /// <summary>
        /// Window focus event payload.
        /// </summary>
        [FieldOffset(0)]
        public XFocusChangeEvent xfocus;

        /// <summary>
        /// Window visibility event payload.
        /// </summary>
        [FieldOffset(0)]
        public XVisibilityEvent xvisibility;

        /// <summary>
        /// Client-message event payload.
        /// </summary>
        [FieldOffset(0)]
        public XClientMessageEvent xclient;
    }
}

#endif