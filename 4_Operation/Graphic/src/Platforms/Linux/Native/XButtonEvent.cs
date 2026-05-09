using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
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
}