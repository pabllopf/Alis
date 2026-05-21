

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The internal uikit wm info
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct InternalUikitWmInfo
    {
        /// <summary>
        ///     Refers to a UIWindow*
        /// </summary>
        public IntPtr Window { get; set; }

        /// <summary>
        ///     The frame buffer
        /// </summary>
        public uint framebuffer;

        /// <summary>
        ///     The color buffer
        /// </summary>
        public uint colorBuffer;

        /// <summary>
        ///     The resolve frame buffer
        /// </summary>
        public uint resolveFramebuffer;
    }
}