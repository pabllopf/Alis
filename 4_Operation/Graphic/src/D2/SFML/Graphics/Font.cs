// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Font.cs
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
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base;
using Alis.Core.Aspect.Base.Attributes;
using Alis.Core.Aspect.Base.Exceptions;
using Alis.Core.Aspect.Base.Settings;
using Alis.Core.Aspect.Memory.Streams.SFML;
using Alis.Core.Graphic.D2.SFML.Windows;

namespace Alis.Core.Graphic.D2.SFML.Graphics
{
    ////////////////////////////////////////////////////////////
    /// <summary>
    ///     Font is the low-level class for loading and
    ///     manipulating character fonts. This class is meant to
    ///     be used by String2D
    /// </summary>
    ////////////////////////////////////////////////////////////
    public class Font : ObjectBase
    {
        /// <summary>
        ///     The my stream
        /// </summary>
        private readonly StreamAdaptor myStream;

        /// <summary>
        ///     The texture
        /// </summary>
        private readonly Dictionary<uint, Texture> myTextures = new Dictionary<uint, Texture>();

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the font from a file
        /// </summary>
        /// <param name="filename">Font file to load</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Font(string filename) : base(sfFont_createFromFile(filename))
        {
            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("font", filename);
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the font from a custom stream
        /// </summary>
        /// <param name="stream">Source stream to read from</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Font(Stream stream) : base(IntPtr.Zero)
        {
            myStream = new StreamAdaptor(stream);
            CPointer = sfFont_createFromStream(myStream.InputStreamPtr);

            if (CPointer == IntPtr.Zero)
            {
                throw new LoadingFailedException("font");
            }
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the font from a file in memory
        /// </summary>
        /// <param name="bytes">Byte array containing the file contents</param>
        /// <exception cref="LoadingFailedException" />
        ////////////////////////////////////////////////////////////
        public Font(byte[] bytes) : this(new MemoryStream(bytes))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Construct the font from another font
        /// </summary>
        /// <param name="copy">Font to copy</param>
        ////////////////////////////////////////////////////////////
        public Font(Font copy) : base(sfFont_copy(copy.CPointer))
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal constructor
        /// </summary>
        /// <param name="cPointer">Pointer to the object in C library</param>
        ////////////////////////////////////////////////////////////
        private Font(IntPtr cPointer) : base(cPointer)
        {
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get a glyph in the font
        /// </summary>
        /// <param name="codePoint">Unicode code point of the character to get</param>
        /// <param name="characterSize">Character size</param>
        /// <param name="bold">Retrieve the bold version or the regular one?</param>
        /// <param name="outlineThickness">Thickness of outline (when != 0 the glyph will not be filled)</param>
        /// <returns>The glyph corresponding to the character</returns>
        ////////////////////////////////////////////////////////////
        public Glyph GetGlyph(uint codePoint, uint characterSize, bool bold, float outlineThickness) => sfFont_getGlyph(CPointer, codePoint, characterSize, bold, outlineThickness);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the kerning offset between two glyphs
        /// </summary>
        /// <param name="first">Unicode code point of the first character</param>
        /// <param name="second">Unicode code point of the second character</param>
        /// <param name="characterSize">Character size</param>
        /// <returns>Kerning offset, in pixels</returns>
        ////////////////////////////////////////////////////////////
        public float GetKerning(uint first, uint second, uint characterSize) => sfFont_getKerning(CPointer, first, second, characterSize);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get spacing between two consecutive lines
        /// </summary>
        /// <param name="characterSize">Character size</param>
        /// <returns>Line spacing, in pixels</returns>
        ////////////////////////////////////////////////////////////
        public float GetLineSpacing(uint characterSize) => sfFont_getLineSpacing(CPointer, characterSize);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the position of the underline
        /// </summary>
        /// <param name="characterSize">Character size</param>
        /// <returns>Underline position, in pixels</returns>
        ////////////////////////////////////////////////////////////
        public float GetUnderlinePosition(uint characterSize) => sfFont_getUnderlinePosition(CPointer, characterSize);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the thickness of the underline
        /// </summary>
        /// <param name="characterSize">Character size</param>
        /// <returns>Underline thickness, in pixels</returns>
        ////////////////////////////////////////////////////////////
        public float GetUnderlineThickness(uint characterSize) => sfFont_getUnderlineThickness(CPointer, characterSize);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the texture containing the glyphs of a given size
        /// </summary>
        /// <param name="characterSize">Character size</param>
        /// <returns>Texture storing the glyphs for the given size</returns>
        ////////////////////////////////////////////////////////////
        public Texture GetTexture(uint characterSize)
        {
            myTextures[characterSize] = new Texture(sfFont_getTexture(CPointer, characterSize));
            return myTextures[characterSize];
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Get the font information
        /// </summary>
        /// <returns>A structure that holds the font information</returns>
        ////////////////////////////////////////////////////////////
        public Info GetInfo()
        {
            InfoMarshalData data = sfFont_getInfo(CPointer);
            Info info = new Info();

            info.Family = Marshal.PtrToStringAnsi(data.Family);

            return info;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Provide a string describing the object
        /// </summary>
        /// <returns>String description of the object</returns>
        ////////////////////////////////////////////////////////////
        public override string ToString() => nameof(Font);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Handle the destruction of the object
        /// </summary>
        /// <param name="disposing">Is the GC disposing the object, or is it an explicit call?</param>
        ////////////////////////////////////////////////////////////
        protected override void Destroy(bool disposing)
        {
            if (!disposing)
            {
                Context.Global.SetActive(true);
            }

            sfFont_destroy(CPointer);

            if (disposing)
            {
                foreach (Texture texture in myTextures.Values)
                {
                    texture.Dispose();
                }

                if (myStream != null)
                {
                    myStream.Dispose();
                }
            }

            if (!disposing)
            {
                Context.Global.SetActive(false);
            }
        }

        /// <summary>
        ///     Sfs the font create from file using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfFont_createFromFile(string filename);

        /// <summary>
        ///     Sfs the font create from stream using the specified stream
        /// </summary>
        /// <param name="stream">The stream</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfFont_createFromStream(IntPtr stream);

        /// <summary>
        ///     Sfs the font create from memory using the specified data
        /// </summary>
        /// <param name="data">The data</param>
        /// <param name="size">The size</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfFont_createFromMemory(IntPtr data, ulong size);

        /// <summary>
        ///     Sfs the font copy using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfFont_copy(IntPtr font);

        /// <summary>
        ///     Sfs the font destroy using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern void sfFont_destroy(IntPtr cPointer);

        /// <summary>
        ///     Sfs the font get glyph using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="codePoint">The code point</param>
        /// <param name="characterSize">The character size</param>
        /// <param name="bold">The bold</param>
        /// <param name="outlineThickness">The outline thickness</param>
        /// <returns>The glyph</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern Glyph sfFont_getGlyph(IntPtr cPointer, uint codePoint, uint characterSize, bool bold,
            float outlineThickness);

        /// <summary>
        ///     Sfs the font get kerning using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="first">The first</param>
        /// <param name="second">The second</param>
        /// <param name="characterSize">The character size</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfFont_getKerning(IntPtr cPointer, uint first, uint second, uint characterSize);

        /// <summary>
        ///     Sfs the font get line spacing using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="characterSize">The character size</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfFont_getLineSpacing(IntPtr cPointer, uint characterSize);

        /// <summary>
        ///     Sfs the font get underline position using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="characterSize">The character size</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfFont_getUnderlinePosition(IntPtr cPointer, uint characterSize);

        /// <summary>
        ///     Sfs the font get underline thickness using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="characterSize">The character size</param>
        /// <returns>The float</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern float sfFont_getUnderlineThickness(IntPtr cPointer, uint characterSize);

        /// <summary>
        ///     Sfs the font get texture using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <param name="characterSize">The character size</param>
        /// <returns>The int ptr</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern IntPtr sfFont_getTexture(IntPtr cPointer, uint characterSize);

        /// <summary>
        ///     Sfs the font get info using the specified c pointer
        /// </summary>
        /// <param name="cPointer">The pointer</param>
        /// <returns>The info marshal data</returns>
        [DllImport(Csfml.Graphics, CallingConvention = CallingConvention.Cdecl), SuppressUnmanagedCodeSecurity]
        private static extern InfoMarshalData sfFont_getInfo(IntPtr cPointer);

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Info holds various information about a font
        /// </summary>
        ////////////////////////////////////////////////////////////
        public struct Info
        {
            /// <summary>The font family</summary>
            public string Family;
        }

        ////////////////////////////////////////////////////////////
        /// <summary>
        ///     Internal struct used for marshaling the font info
        ///     struct from unmanaged code.
        /// </summary>
        ////////////////////////////////////////////////////////////
        [StructLayout(LayoutKind.Sequential)]
        internal struct InfoMarshalData
        {
            /// <summary>
            ///     The family
            /// </summary>
            public IntPtr Family;
        }
    }
}