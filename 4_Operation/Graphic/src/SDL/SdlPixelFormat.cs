using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl pixelformat
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlPixelFormat
    {
        /// <summary>
        ///     The format
        /// </summary>
        public uint format;

        /// <summary>
        ///     The palette
        /// </summary>
        public IntPtr palette; // SDL_Palette*

        /// <summary>
        ///     The bits per pixel
        /// </summary>
        public byte BitsPerPixel;

        /// <summary>
        ///     The bytes per pixel
        /// </summary>
        public byte BytesPerPixel;

        /// <summary>
        ///     The rmask
        /// </summary>
        public uint Rmask;

        /// <summary>
        ///     The gmask
        /// </summary>
        public uint Gmask;

        /// <summary>
        ///     The bmask
        /// </summary>
        public uint Bmask;

        /// <summary>
        ///     The amask
        /// </summary>
        public uint Amask;

        /// <summary>
        ///     The rloss
        /// </summary>
        public byte Rloss;

        /// <summary>
        ///     The gloss
        /// </summary>
        public byte Gloss;

        /// <summary>
        ///     The bloss
        /// </summary>
        public byte Bloss;

        /// <summary>
        ///     The aloss
        /// </summary>
        public byte Aloss;

        /// <summary>
        ///     The rshift
        /// </summary>
        public byte Rshift;

        /// <summary>
        ///     The gshift
        /// </summary>
        public byte Gshift;

        /// <summary>
        ///     The bshift
        /// </summary>
        public byte Bshift;

        /// <summary>
        ///     The ashift
        /// </summary>
        public byte Ashift;

        /// <summary>
        ///     The refcount
        /// </summary>
        public int refcount;

        /// <summary>
        ///     The next
        /// </summary>
        public IntPtr next; // SDL_PixelFormat*
    }
}