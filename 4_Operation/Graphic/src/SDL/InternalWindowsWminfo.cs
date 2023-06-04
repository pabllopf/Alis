using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal windows wminfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InternalWindowsWminfo
    {
        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr window; // Refers to an HWND

        /// <summary>
        ///     The hdc
        /// </summary>
        public IntPtr hdc; // Refers to an HDC

        /// <summary>
        ///     The hinstance
        /// </summary>
        public IntPtr hinstance; // Refers to an HINSTANCE
    }
}