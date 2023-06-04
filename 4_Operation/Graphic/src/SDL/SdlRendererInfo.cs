using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl rendererinfo
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlRendererInfo
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
        public uint[] texture_formats;

        /// <summary>
        ///     The max texture width
        /// </summary>
        public int max_texture_width;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public int max_texture_height;

        /// <summary>
        /// Initializes a new instance of the <see cref="SdlRendererInfo"/> class
        /// </summary>
        public SdlRendererInfo()
        {
            name = default;
            flags = 0;
            num_texture_formats = 0;
            max_texture_width = 0;
            max_texture_height = 0;
            texture_formats = new uint[16];
        }
    }
}