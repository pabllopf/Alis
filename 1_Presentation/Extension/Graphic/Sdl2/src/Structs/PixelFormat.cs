

using System;
using System.Runtime.InteropServices;

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl pixel format
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct PixelFormat
    {
        /// <summary>
        ///     The format
        /// </summary>
        public readonly uint format;

        /// <summary>
        ///     The palette
        /// </summary>
        public IntPtr Palette { get; set; }

        /// <summary>
        ///     The bits per pixel
        /// </summary>
        public readonly byte BitsPerPixel;

        /// <summary>
        ///     The bytes per pixel
        /// </summary>
        public readonly byte BytesPerPixel;

        /// <summary>
        ///     The r mask
        /// </summary>
        public readonly uint RMask;

        /// <summary>
        ///     The g mask
        /// </summary>
        public readonly uint GMask;

        /// <summary>
        ///     The b mask
        /// </summary>
        public readonly uint BMask;

        /// <summary>
        ///     The a mask
        /// </summary>
        public readonly uint AMask;

        /// <summary>
        ///     The r loss
        /// </summary>
        public readonly byte RLoss;

        /// <summary>
        ///     The g loss
        /// </summary>
        public readonly byte Gloss;

        /// <summary>
        ///     The b loss
        /// </summary>
        public readonly byte BLoss;

        /// <summary>
        ///     The a loss
        /// </summary>
        public readonly byte ALoss;

        /// <summary>
        ///     The r shift
        /// </summary>
        public readonly byte RShift;

        /// <summary>
        ///     The g shift
        /// </summary>
        public readonly byte GShift;

        /// <summary>
        ///     The b shift
        /// </summary>
        public readonly byte BShift;

        /// <summary>
        ///     The a shift
        /// </summary>
        public readonly byte AShift;

        /// <summary>
        ///     The ref count
        /// </summary>
        public readonly int refCount;

        /// <summary>
        ///     The next
        /// </summary>
        public IntPtr Next { get; set; }
    }
}