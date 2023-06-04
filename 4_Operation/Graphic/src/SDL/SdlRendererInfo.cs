using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rendererinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct SdlRendererInfo
    {
        /// <summary>
        ///     The name
        /// </summary>
        public IntPtr name; // const char*

        /// <summary>
        ///     The flags
        /// </summary>
        public uint flags;

        /// <summary>
        ///     The num texture formats
        /// </summary>
        public uint num_texture_formats;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public fixed uint texture_formats[16];

        /// <summary>
        ///     The max texture width
        /// </summary>
        public int max_texture_width;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public int max_texture_height;
    }
}