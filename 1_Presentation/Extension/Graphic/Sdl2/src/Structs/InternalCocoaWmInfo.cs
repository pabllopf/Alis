

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal cocoa wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalCocoaWmInfo
    {
        /// <summary>
        ///     Refers to an NSWindow*
        /// </summary>
        public IntPtr Window { get; set; }
    }
}