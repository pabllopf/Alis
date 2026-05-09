using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
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
}