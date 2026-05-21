

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Shapes.Rectangle;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl surface
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Surface
    {
        /// <summary>
        ///     The flags
        /// </summary>
        public readonly uint flags;

        /// <summary>
        ///     The format
        /// </summary>
        public IntPtr Format { get; set; }

        /// <summary>
        ///     The
        /// </summary>
        public readonly int w;

        /// <summary>
        ///     The
        /// </summary>
        public readonly int h;

        /// <summary>
        ///     The pitch
        /// </summary>
        public readonly int pitch;

        /// <summary>
        ///     The pixels
        /// </summary>
        public IntPtr Pixels { get; set; }

        /// <summary>
        ///     The userdata
        /// </summary>
        public IntPtr Userdata { get; set; }

        /// <summary>
        ///     The locked
        /// </summary>
        public readonly int locked;

        /// <summary>
        ///     The list blit map
        /// </summary>
        public IntPtr ListBlitMap { get; set; }

        /// <summary>
        ///     The clip rect
        /// </summary>
        public RectangleI ClipRect { get; set; }

        /// <summary>
        ///     The map
        /// </summary>
        public IntPtr Map { get; set; }

        /// <summary>
        ///     The ref count
        /// </summary>
        public readonly int refCount;
    }
}