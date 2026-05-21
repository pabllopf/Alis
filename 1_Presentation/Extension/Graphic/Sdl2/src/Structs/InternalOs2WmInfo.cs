

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal os2 wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalOs2WmInfo
    {
        /// <summary>
        ///     Refers to window
        /// </summary>
        public IntPtr Hwnd { get; set; }

        /// <summary>
        ///     Refers to frame
        /// </summary>
        public IntPtr HwndFrame { get; set; }
    }
}