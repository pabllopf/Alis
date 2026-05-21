

#if linuxx64 || linuxx86 || linuxarm64 || linuxarm || linux
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.Platforms.Linux.Native
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
}

#endif