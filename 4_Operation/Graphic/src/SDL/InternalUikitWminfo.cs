using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The internal uikit wminfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct InternalUikitWminfo
    {
        /// <summary>
        ///     The window
        /// </summary>
        public IntPtr window; // Refers to a UIWindow*

        /// <summary>
        ///     The framebuffer
        /// </summary>
        public uint framebuffer;

        /// <summary>
        ///     The colorbuffer
        /// </summary>
        public uint colorbuffer;

        /// <summary>
        ///     The resolve framebuffer
        /// </summary>
        public uint resolveFramebuffer;
    }
}