// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtrNullLabelCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im font atlas ptr null label coverage tests class
    /// </summary>
    public class ImFontAtlasPtrNullLabelCoverageTests
    {
        /// <summary>
        ///     Tests the int ptr ctor stores the native pointer
        /// </summary>
        [Fact]
        public void IntPtrCtor_StoresNativePointer()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new IntPtr(0x4567));
            Assert.Equal(new IntPtr(0x4567), ptr.NativePtr);
        }

        /// <summary>
        ///     Tests the struct ctor allocates a native buffer
        /// </summary>
        [Fact]
        public void StructCtor_AllocatesNativeBuffer()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.NotEqual(IntPtr.Zero, ptr.NativePtr);
        }

        /// <summary>
        ///     Tests the implicit conversion to int ptr returns the native pointer
        /// </summary>
        [Fact]
        public void ImplicitToIntPtr_ReturnsNativePointer()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new IntPtr(0x4567));
            IntPtr raw = ptr;
            Assert.Equal(ptr.NativePtr, raw);
        }

        /// <summary>
        ///     Tests the implicit conversion from int ptr wraps the pointer
        /// </summary>
        [Fact]
        public void ImplicitFromIntPtr_WrapsPointer()
        {
            ImFontAtlasPtr ptr = new IntPtr(0x4567);
            Assert.Equal(new IntPtr(0x4567), ptr.NativePtr);
        }

        /// <summary>
        ///     Tests the flags getter reads the source struct
        /// </summary>
        [Fact]
        public void Flags_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal((ImFontAtlasFlags)0, ptr.Flags);
        }

        /// <summary>
        ///     Tests the tex id setter round trips through the pointer
        /// </summary>
        [Fact]
        public void TexId_Setter_RoundTrips()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            ptr.TexId = new IntPtr(9);
            Assert.Equal(new IntPtr(9), ptr.TexId);
        }

        /// <summary>
        ///     Tests the tex desired width getter reads the source struct
        /// </summary>
        [Fact]
        public void TexDesiredWidth_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.TexDesiredWidth);
        }

        /// <summary>
        ///     Tests the tex glyph padding getter reads the source struct
        /// </summary>
        [Fact]
        public void TexGlyphPadding_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.TexGlyphPadding);
        }

        /// <summary>
        ///     Tests the locked getter reads the source struct
        /// </summary>
        [Fact]
        public void Locked_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.False(ptr.Locked);
        }

        /// <summary>
        ///     Tests the tex ready getter reads the source struct
        /// </summary>
        [Fact]
        public void TexReady_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.False(ptr.TexReady);
        }

        /// <summary>
        ///     Tests the tex pixels use colors getter reads the source struct
        /// </summary>
        [Fact]
        public void TexPixelsUseColors_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.False(ptr.TexPixelsUseColors);
        }

        /// <summary>
        ///     Tests the tex width getter reads the source struct
        /// </summary>
        [Fact]
        public void TexWidth_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.TexWidth);
        }

        /// <summary>
        ///     Tests the tex height getter reads the source struct
        /// </summary>
        [Fact]
        public void TexHeight_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.TexHeight);
        }

        /// <summary>
        ///     Tests the tex uv scale getter reads the source struct
        /// </summary>
        [Fact]
        public void TexUvScale_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Vector2F scale = ptr.TexUvScale;
            Assert.Equal(0f, scale.X);
            Assert.Equal(0f, scale.Y);
        }

        /// <summary>
        ///     Tests the tex uv white pixel getter reads the source struct
        /// </summary>
        [Fact]
        public void TexUvWhitePixel_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Vector2F pixel = ptr.TexUvWhitePixel;
            Assert.Equal(0f, pixel.X);
            Assert.Equal(0f, pixel.Y);
        }

        /// <summary>
        ///     Tests the fonts getter returns a vector wrapper
        /// </summary>
        [Fact]
        public void Fonts_Getter_ReturnsVectorWrapper()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.NotNull(ptr.Fonts);
        }

        /// <summary>
        ///     Tests the custom rects getter returns a vector wrapper
        /// </summary>
        [Fact]
        public void CustomRects_Getter_ReturnsVectorWrapper()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.NotNull(ptr.CustomRects);
        }

        /// <summary>
        ///     Tests the config data getter returns a vector wrapper
        /// </summary>
        [Fact]
        public void ConfigData_Getter_ReturnsVectorWrapper()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.NotNull(ptr.ConfigData);
        }

        /// <summary>
        ///     Tests the font builder flags getter reads the source struct
        /// </summary>
        [Fact]
        public void FontBuilderFlags_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0u, ptr.FontBuilderFlags);
        }

        /// <summary>
        ///     Tests the pack id mouse cursors getter reads the source struct
        /// </summary>
        [Fact]
        public void PackIdMouseCursors_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.PackIdMouseCursors);
        }

        /// <summary>
        ///     Tests the pack id lines getter reads the source struct
        /// </summary>
        [Fact]
        public void PackIdLines_Getter_ReadsSource()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.Equal(0, ptr.PackIdLines);
        }

        /// <summary>
        ///     Tests add font from file ttf with null filename throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_0_NullFilename_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromFileTtf((string)null, 12f)));
        }

        /// <summary>
        ///     Tests add font from file ttf with null filename throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_1_NullFilename_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromFileTtf((string)null, 12f, (ImFontConfigPtr)IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests add font from file ttf with null filename throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromFileTtf_2_NullFilename_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromFileTtf((string)null, 12f, (ImFontConfigPtr)IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests add font from memory compressed base85 ttf with null data throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_0_NullData_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromMemoryCompressedBase85Ttf((string)null, 12f)));
        }

        /// <summary>
        ///     Tests add font from memory compressed base85 ttf with null data throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_1_NullData_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromMemoryCompressedBase85Ttf((string)null, 12f, (ImFontConfigPtr)IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests add font from memory compressed base85 ttf with null data throws argument null exception
        /// </summary>
        [Fact]
        public void AddFontFromMemoryCompressedBase85Ttf_2_NullData_ThrowsArgumentNullException()
        {
            ImFontAtlasPtr ptr = new ImFontAtlasPtr(IntPtr.Zero);
            Assert.Throws<ArgumentNullException>((Action)(() => ptr.AddFontFromMemoryCompressedBase85Ttf((string)null, 12f, (ImFontConfigPtr)IntPtr.Zero, IntPtr.Zero)));
        }
    }
}