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