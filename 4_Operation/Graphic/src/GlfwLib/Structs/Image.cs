using System;
using System.Runtime.InteropServices;

namespace Alis.Core.Graphic.GlfwLib.Structs
{
    /// <summary>
    ///     Describes a basic image structure.
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct Image
    {
        /// <summary>
        ///     The height, in pixels, of this image.
        /// </summary>
        public int Width;

        /// <summary>
        ///     The width, in pixels, of this image.
        /// </summary>
        public int Height;

        /// <summary>
        ///     Pointer to the RGBA pixel data of this image, arranged left-to-right, top-to-bottom.
        /// </summary>
        public IntPtr Pixels;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Image" /> struct.
        /// </summary>
        /// <param name="width">The height, in pixels, of this image.</param>
        /// <param name="height">The width, in pixels, of this image..</param>
        /// <param name="pixels">Pointer to the RGBA pixel data of this image, arranged left-to-right, top-to-bottom.</param>
        public Image(int width, int height, IntPtr pixels)
        {
            Width = width;
            Height = height;
            Pixels = pixels;
        }

        // TODO: Implement manual load of bmp
    }
}