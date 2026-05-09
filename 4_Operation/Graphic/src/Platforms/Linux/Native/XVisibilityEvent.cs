using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
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
}