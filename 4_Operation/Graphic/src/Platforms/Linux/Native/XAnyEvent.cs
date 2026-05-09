using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
{
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
}