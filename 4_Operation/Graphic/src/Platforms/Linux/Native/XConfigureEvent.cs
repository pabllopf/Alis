using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
    /// <summary>
    /// Native X11 window-configuration event.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    internal struct XConfigureEvent
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
        /// The event window
        /// </summary>
        public UIntPtr event_window;
        /// <summary>
        /// The window
        /// </summary>
        public UIntPtr window;
        /// <summary>
        /// The 
        /// </summary>
        public int x;
        /// <summary>
        /// The 
        /// </summary>
        public int y;
        /// <summary>
        /// The width
        /// </summary>
        public int width;
        /// <summary>
        /// The height
        /// </summary>
        public int height;
        /// <summary>
        /// The border width
        /// </summary>
        public int border_width;
        /// <summary>
        /// The above
        /// </summary>
        public UIntPtr above;
        /// <summary>
        /// The override redirect
        /// </summary>
        public int override_redirect;
    }
}