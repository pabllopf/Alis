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
}