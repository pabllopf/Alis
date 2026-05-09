using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
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
}