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
using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux
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

    /// <summary>
    /// Native X11 event header shared by all event types.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XAnyEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
    }

    /// <summary>
    /// Native X11 keyboard event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XKeyEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public UIntPtr root;
        public UIntPtr subwindow;
        public UIntPtr time;
        public int x;
        public int y;
        public int x_root;
        public int y_root;
        public uint state;
        public uint keycode;
        public int same_screen;
    }

    /// <summary>
    /// Native X11 mouse button event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XButtonEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public UIntPtr root;
        public UIntPtr subwindow;
        public UIntPtr time;
        public int x;
        public int y;
        public int x_root;
        public int y_root;
        public uint state;
        public uint button;
        public int same_screen;
    }

    /// <summary>
    /// Native X11 mouse motion event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XMotionEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public UIntPtr root;
        public UIntPtr subwindow;
        public UIntPtr time;
        public int x;
        public int y;
        public int x_root;
        public int y_root;
        public uint state;
        public byte is_hint;
        public int same_screen;
    }

    /// <summary>
    /// Native X11 window-configuration event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XConfigureEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr event_window;
        public UIntPtr window;
        public int x;
        public int y;
        public int width;
        public int height;
        public int border_width;
        public UIntPtr above;
        public int override_redirect;
    }

    /// <summary>
    /// Native X11 focus-change event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XFocusChangeEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public int mode;
        public int detail;
    }

    /// <summary>
    /// Native X11 visibility event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XVisibilityEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public int state;
    }

    /// <summary>
    /// Native X11 client-message event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XClientMessageEvent
    {
        public int type;
        public UIntPtr serial;
        public int send_event;
        public IntPtr display;
        public UIntPtr window;
        public UIntPtr message_type;
        public int format;
        public IntPtr data0;
        public IntPtr data1;
        public IntPtr data2;
        public IntPtr data3;
        public IntPtr data4;
    }
}

#endif