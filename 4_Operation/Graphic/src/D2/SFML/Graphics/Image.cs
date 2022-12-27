// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Image.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Exceptions;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Math;
using Alis.Core.Aspect.Math.Figures.D2.Rectangle;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Aspect.Memory.Streams.SFML;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Image is the low-level class for loading and
    ///     manipulating images
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Image : ObjectBase
    {
        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image with black color
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height) : this(width, height, Color.Black)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image from a single color
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="color">Color to fill the image with</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height, Color color) : base(sfImage_createFromColor(width, height, color))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image from a file
        /// </summary>
        /// <param name="filename">Path of the image file to load</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(string filename) : base(sfImage_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image", filename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image from a file in a stream
        /// </summary>
        /// <param name="stream">Stream containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(Stream stream) :
            base(IntPtr.Zero)
        {
            using (StreamAdaptor adaptor = new StreamAdaptor(stream))
            {
                CPointer = sfImage_createFromStream(adaptor.InputStreamPtr);
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image from a file in memory
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(byte[] bytes) :
            base(IntPtr.Zero)
        {
            GCHandle pin = GCHandle.Alloc(bytes, GCHandleType.Pinned);
            try
            {
                CPointer = sfImage_createFromMemory(pin.AddrOfPinnedObject(), Convert.ToUInt64(bytes.Length));
            }
            finally
            {
                pin.Free();
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image directly from an array of pixels
        /// </summary>
        /// <param name="pixels">2 dimensions array containing the pixels</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(Color[,] pixels) :
            base(IntPtr.Zero)
        {
            uint width = (uint) pixels.GetLength(0);
            uint height = (uint) pixels.GetLength(1);

            // Transpose the array (.Net gives dimensions in reverse order of what SFML expects)
            Color[,] transposed = new Color[height, width];
            for (int x = 0; x < width; ++x)
            {
                for (int y = 0; y < height; ++y)
                {
                    transposed[y, x] = pixels[x, y];
                }
            }

            unsafe
            {
                fixed (Color* pixelsPtr = transposed)
                {
                    CPointer = sfImage_createFromPixels(width, height, (byte*) pixelsPtr);
                }
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image directly from an array of pixels
        /// </summary>
        /// <param name="width">Image width</param>
        /// <param name="height">Image height</param>
        /// <param name="pixels">array containing the pixels</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Image(uint width, uint height, byte[] pixels) :
            base(IntPtr.Zero)
        {
            unsafe
            {
                fixed (byte* pixelsPtr = pixels)
                {
                    CPointer = sfImage_createFromPixels(width, height, pixelsPtr);
                }
            }

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("image");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the image from another image
        /// </summary>
        /// <param name="copy">Image to copy</param>
        ////////////////////////////////////////////////////////////
        public Image(Image copy) :
            base(sfImage_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal constructor
        /// </summary>
        /// <param name="cPointer">Pointer to the object in C library</param>
        ////////////////////////////////////////////////////////////
        internal Image(IntPtr cPointer) : base(cPointer)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get a copy of the array of pixels (RGBA 8 bits integers components)
        ///     Array size is Width x Height x 4
        /// </summary>
        /// <returns>Array of pixels</returns>
        ////////////////////////////////////////////////////////////
        public byte[] Pixels
        {
            get
            {
                Vector2U size = Size;
                byte[] pixelsPtr = new byte[size.X * size.Y * 4];
                Marshal.Copy(sfImage_getPixelsPtr(CPointer), pixelsPtr, 0, pixelsPtr.Length);
                return pixelsPtr;
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Size of the image, in pixels
        /// </summary>
        ////////////////////////////////////////////////////////////
        public Vector2U Size => sfImage_getSize(CPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Save the contents of the image to a file
        /// </summary>
        /// <param name="filename">Path of the file to save (overwritten if already exist)</param>
        /// <returns>True if saving was successful</returns>
        ////////////////////////////////////////////////////////////
        public bool SaveToFile(string filename) => sfImage_saveToFile(CPointer, filename);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create a transparency mask from a specified colorkey
        /// </summary>
        /// <param name="color">Color to become transparent</param>
        ////////////////////////////////////////////////////////////
        public void CreateMaskFromColor(Color color)
        {
            CreateMaskFromColor(color, 0);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Create a transparency mask from a specified colorkey
        /// </summary>
        /// <param name="color">Color to become transparent</param>
        /// <param name="alpha">Alpha value to use for transparent pixels</param>
        ////////////////////////////////////////////////////////////
        public void CreateMaskFromColor(Color color, byte alpha)
        {
            sfImage_createMaskFromColor(CPointer, color, alpha);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Copy pixels from another image onto this one.
        ///     This function does a slow pixel copy and should only
        ///     be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY)
        {
            Copy(source, destX, destY, new RectangleI(0, 0, 0, 0));
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Copy pixels from another image onto this one.
        ///     This function does a slow pixel copy and should only
        ///     be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY, RectangleI sourceRect)
        {
            Copy(source, destX, destY, sourceRect, false);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Copy pixels from another image onto this one.
        ///     This function does a slow pixel copy and should only
        ///     be used at initialization time
        /// </summary>
        /// <param name="source">Source image to copy</param>
        /// <param name="destX">X coordinate of the destination position</param>
        /// <param name="destY">Y coordinate of the destination position</param>
        /// <param name="sourceRect">Sub-rectangle of the source image to copy</param>
        /// <param name="applyAlpha">Should the copy take in account the source transparency?</param>
        ////////////////////////////////////////////////////////////
        public void Copy(Image source, uint destX, uint destY, RectangleI sourceRect, bool applyAlpha)
        {
            sfImage_copyImage(CPointer, source.CPointer, destX, destY, sourceRect, applyAlpha);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get a pixel from the image
        /// </summary>
        /// <param name="x">X coordinate of pixel in the image</param>
        /// <param name="y">Y coordinate of pixel in the image</param>
        /// <returns>Color of pixel (x, y)</returns>
        ////////////////////////////////////////////////////////////
        public Color GetPixel(uint x, uint y) => sfImage_getPixel(CPointer, x, y);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Change the color of a pixel
        /// </summary>
        /// <param name="x">X coordinate of pixel in the image</param>
        /// <param name="y">Y coordinate of pixel in the image</param>
        /// <param name="color">New color for pixel (x, y)</param>
        ////////////////////////////////////////////////////////////
        public void SetPixel(uint x, uint y, Color color)
        {
            sfImage_setPixel(CPointer, x, y, color);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Flip the image horizontally
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void FlipHorizontally()
        {
            sfImage_flipHorizontally(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Flip the image vertically
        /// </summary>
        ////////////////////////////////////////////////////////////
        public void FlipVertically()
        {
            sfImage_flipVertically(CPointer);
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => $"[Image] Size({Size})";

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call ?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            sfImage_destroy(CPointer);
        }

        /// <summary>
        ///     Sfs the image create from color using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="col">The col</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromColor(uint width, uint height, Color col);

        /// <summary>
        ///     Sfs the image create from pixels using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="pixels">The pixels</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern unsafe IntPtr sfImage_createFromPixels(uint width, uint height, byte* pixels);

        /// <summary>
        ///     Sfs the image create from file using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromFile(string filename);

        /// <summary>
        ///     Sfs the image create from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromStream(IntPtr stream);

        /// <summary>
        ///     Sfs the image create from memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_createFromMemory(IntPtr data, ulong size);

        /// <summary>
        ///     Sfs the image copy using the specified image
        /// </summary>
        /// <param name="image">The image</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_copy(IntPtr image);

        /// <summary>
        ///     Sfs the image destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_destroy(IntPtr cPointer);

        /// <summary>
        ///     Describes whether sf image save to file
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="filename">The filename</param>
        /// <returns>The bool</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern bool sfImage_saveToFile(IntPtr cPointer, string filename);

        /// <summary>
        ///     Sfs the image create mask from color using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="col">The col</param>
        /// <param name="alpha">The alpha</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_createMaskFromColor(IntPtr cPointer, Color col, byte alpha);

        /// <summary>
        ///     Sfs the image copy image using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="source">The source</param>
        /// <param name="destX">The dest</param>
        /// <param name="destY">The dest</param>
        /// <param name="sourceRect">The source rect</param>
        /// <param name="applyAlpha">The apply alpha</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_copyImage(IntPtr cPointer, IntPtr source, uint destX, uint destY,
            RectangleI sourceRect, bool applyAlpha);

        /// <summary>
        ///     Sfs the image set pixel using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <param name="col">The col</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfImage_setPixel(IntPtr cPointer, uint x, uint y, Color col);

        /// <summary>
        ///     Sfs the image get pixel using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        /// <returns>The color</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Color sfImage_getPixel(IntPtr cPointer, uint x, uint y);

        /// <summary>
        ///     Sfs the image get pixels ptr using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfImage_getPixelsPtr(IntPtr cPointer);

        /// <summary>
        ///     Sfs the image get size using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The vector 2u</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Vector2U sfImage_getSize(IntPtr cPointer);

        /// <summary>
        ///     Sfs the image flip horizontally using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfImage_flipHorizontally(IntPtr cPointer);

        /// <summary>
        ///     Sfs the image flip vertically using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The uint</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern uint sfImage_flipVertically(IntPtr cPointer);
    }
}