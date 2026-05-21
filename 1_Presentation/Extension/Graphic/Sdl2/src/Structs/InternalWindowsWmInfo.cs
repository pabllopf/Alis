

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal windows wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalWindowsWmInfo
    {
        /// <summary>
        ///     Refers to an HWND
        /// </summary>
        public IntPtr Window { get; set; }

        /// <summary>
        ///     Refers to an HDC
        /// </summary>
        public IntPtr Hdc { get; set; }

        /// <summary>
        ///     Refers to an H INSTANCE
        /// </summary>
        public IntPtr HInstance { get; set; }
    }
}