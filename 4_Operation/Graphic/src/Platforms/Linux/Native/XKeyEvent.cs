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