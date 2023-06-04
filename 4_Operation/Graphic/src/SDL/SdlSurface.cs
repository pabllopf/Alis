using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl surface
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlSurface
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public uint flags;

        /// <summary>
        ///     The format
        /// </summary>
        public IntPtr format; // SDL_PixelFormat*

        /// <summary>
        ///     The
        /// </summary>
        public int w;

        /// <summary>
        ///     The
        /// </summary>
        public int h;

        /// <summary>
        ///     The pitch
        /// </summary>
        public int pitch;

        /// <summary>
        ///     The pixels
        /// </summary>
        public IntPtr pixels; // void*

        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr userdata; // void*

        /// <summary>
        ///     The locked
        /// </summary>
        public int locked;

        /// <summary>
        ///     The list blitmap
        /// </summary>
        public IntPtr list_blitmap; // void*

        /// <summary>
        ///     The clip rect
        /// </summary>
        public SdlRect clip_rect;

        /// <summary>
        ///     The map
        /// </summary>
        public IntPtr map; // SDL_BlitMap*

        /// <summary>
        ///     The refcount
        /// </summary>
        public int refcount;
    }
}