using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal cocoa wminfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InternalCocoaWminfo
    {
        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr window; // Refers to an NSWindow*
    }
}