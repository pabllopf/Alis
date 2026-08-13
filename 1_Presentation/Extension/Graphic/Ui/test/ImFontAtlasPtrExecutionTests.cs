// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtrExecutionTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Executes every ImFontAtlasPtr wrapper against the real cimgui font atlas owned by a
    ///     headless context. Font rasterization is pure CPU so no frame or display is required.
    ///     Each test owns a fresh context destroyed in finally, and the atlas pointer is read
    ///     straight from the native io struct.
    /// </summary>
    public class ImFontAtlasPtrExecutionTests
    {
        /// <summary>
        ///     The native offset of the Fonts field inside the io struct
        /// </summary>
        private const int IoFontsOffset = 80;

        /// <summary>
        ///     Creates a raw ImGui context and binds it as the current context.
        /// </summary>
        /// <returns>The created context pointer</returns>
        private static IntPtr CreateContext()
        {
            IntPtr context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(context);
            return context;
        }

        /// <summary>
        ///     Reads the font atlas pointer from the io struct of the current context.
        /// </summary>
        /// <param name="context">The context pointer</param>
        /// <returns>The font atlas wrapper</returns>
        private static ImFontAtlasPtr GetFontAtlas(IntPtr context)
        {
            IntPtr io = ImGuiNative.igGetIO();
            return new ImFontAtlasPtr(Marshal.ReadIntPtr(io, IoFontsOffset));
        }

        /// <summary>
        ///     Creates a native default font config allocated by cimgui.
        /// </summary>
        /// <returns>The font config wrapper</returns>
        private static ImFontConfigPtr NewFontConfig() => ImGui.ImFontConfig();

        /// <summary>
        ///     Verifies the constructors and the implicit pointer conversions execute.
        /// </summary>
        [MacOsOnly]
        public void Constructors_And_ImplicitOperators_Execute()
        {
            ImFontAtlasPtr managed = new ImFontAtlasPtr(new ImFontAtlas());
            Assert.NotEqual(IntPtr.Zero, managed.NativePtr);
            IntPtr raw = managed;
            ImFontAtlasPtr converted = (ImFontAtlasPtr) raw;
            Assert.Equal(raw, converted.NativePtr);
            Marshal.FreeHGlobal(managed.NativePtr);
        }

        /// <summary>
        ///     Verifies every GetGlyphRanges accessor returns a non-zero pointer to a static range.
        /// </summary>
        [MacOsOnly]
        public void GlyphRanges_AllAccessors_ReturnNonZero()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesDefault());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesChineseFull());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesChineseSimplifiedCommon());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesCyrillic());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesGreek());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesJapanese());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesKorean());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesThai());
                Assert.NotEqual(IntPtr.Zero, atlas.GetGlyphRangesVietnamese());
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies AddFont with a config that carries font data and both AddFontDefault
        ///     overloads return valid font pointers. The native AddFont asserts on missing font
        ///     data, so a malloc backed buffer is referenced by the managed config.
        /// </summary>
        [MacOsOnly]
        public void AddFont_And_AddFontDefault_ReturnValidFonts()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                IntPtr fontData = Marshal.AllocHGlobal(16);
                for (int i = 0; i < 16; i++)
                {
                    Marshal.WriteByte(fontData, i, (byte) (i + 1));
                }

                ImFontConfigPtr config = new ImFontConfigPtr(new ImFontConfig { FontData = fontData, FontDataSize = 16, SizePixels = 13.0f });
                ImFontPtr custom = atlas.AddFont(config);
                Assert.NotEqual(IntPtr.Zero, custom.NativePtr);
                Marshal.FreeHGlobal(fontData);
                ImFontPtr plain = atlas.AddFontDefault();
                Assert.NotEqual(IntPtr.Zero, plain.NativePtr);
                ImFontPtr configured = atlas.AddFontDefault(NewFontConfig());
                Assert.NotEqual(IntPtr.Zero, configured.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies every AddFontFromFileTtf overload loads a real font file. The filename
        ///     carries a trailing null byte so the native strlen call terminates exactly at the
        ///     path, and the path is resolved from the test output directory up to the sample
        ///     fonts shipped with the Ui extension.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromFileTtf_ExistingFile_ReturnsValidFont()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                string fontPath = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../../sample/Assets/Fonts/Jetbrains/JetBrainsMonoNL-Regular.ttf"));
                string filename = fontPath + "\0";
                ImFontPtr plain = atlas.AddFontFromFileTtf(filename, 13.0f);
                Assert.NotEqual(IntPtr.Zero, plain.NativePtr);
                ImFontPtr configured = atlas.AddFontFromFileTtf(filename, 13.0f, new ImFontConfigPtr(IntPtr.Zero));
                Assert.NotEqual(IntPtr.Zero, configured.NativePtr);
                ImFontPtr ranged = atlas.AddFontFromFileTtf(filename, 13.0f, new ImFontConfigPtr(IntPtr.Zero), atlas.GetGlyphRangesDefault());
                Assert.NotEqual(IntPtr.Zero, ranged.NativePtr);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies every AddFontFromMemoryTtf overload accepts an invalid font buffer without
        ///     crashing. The buffer is malloc allocated so the atlas can release it on destroy.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromMemoryTtf_InvalidData_DoesNotCrash()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                IntPtr fontData = Marshal.AllocHGlobal(16);
                for (int i = 0; i < 16; i++)
                {
                    Marshal.WriteByte(fontData, i, (byte) (i + 1));
                }

                ImFontPtr plain = atlas.AddFontFromMemoryTtf(fontData, 16, 13.0f);
                Assert.True(plain.NativePtr != IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies the remaining AddFontFromMemoryTtf overloads accept an invalid font
        ///     buffer without crashing.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromMemoryTtf_InvalidData_ConfigOverloads_DoNotCrash()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                IntPtr fontData = Marshal.AllocHGlobal(16);
                for (int i = 0; i < 16; i++)
                {
                    Marshal.WriteByte(fontData, i, (byte) (i + 1));
                }

                ImFontPtr configured = atlas.AddFontFromMemoryTtf(fontData, 16, 13.0f, NewFontConfig());
                Assert.True(configured.NativePtr != IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies the glyph-ranged AddFontFromMemoryTtf overload accepts an invalid font
        ///     buffer without crashing.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromMemoryTtf_InvalidData_GlyphRangesOverload_DoesNotCrash()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                IntPtr fontData = Marshal.AllocHGlobal(16);
                for (int i = 0; i < 16; i++)
                {
                    Marshal.WriteByte(fontData, i, (byte) (i + 1));
                }

                ImFontPtr ranged = atlas.AddFontFromMemoryTtf(fontData, 16, 13.0f, NewFontConfig(), atlas.GetGlyphRangesDefault());
                Assert.True(ranged.NativePtr != IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies every AddFontFromMemoryCompressedTtf overload accepts an invalid compressed
        ///     buffer without crashing. The first four bytes of the header encode the decompressed
        ///     size, so a tiny size is written to keep the decompression work trivial.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromMemoryCompressedTtf_InvalidData_DoesNotCrash()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                IntPtr compressedData = Marshal.AllocHGlobal(16);
                for (int i = 0; i < 16; i++)
                {
                    Marshal.WriteByte(compressedData, i, (byte) (i + 1));
                }

                Marshal.WriteInt32(compressedData, 8, 4);
                ImFontPtr plain = atlas.AddFontFromMemoryCompressedTtf(compressedData, 16, 13.0f);
                ImFontPtr configured = atlas.AddFontFromMemoryCompressedTtf(compressedData, 16, 13.0f, NewFontConfig());
                ImFontPtr ranged = atlas.AddFontFromMemoryCompressedTtf(compressedData, 16, 13.0f, NewFontConfig(), atlas.GetGlyphRangesDefault());
                Assert.True(plain.NativePtr != IntPtr.Zero || configured.NativePtr != IntPtr.Zero || ranged.NativePtr != IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies every AddFontFromMemoryCompressedBase85Ttf overload accepts an invalid
        ///     base85 payload without crashing. The third five-char block decodes into the header
        ///     bytes holding the decompressed size, so that block is crafted to decode to four.
        /// </summary>
        [MacOsOnly]
        public void AddFontFromMemoryCompressedBase85Ttf_InvalidData_DoesNotCrash()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                string payload = "##########" + "$;:G'" + "########";
                ImFontPtr plain = atlas.AddFontFromMemoryCompressedBase85Ttf(payload, 13.0f);
                ImFontPtr configured = atlas.AddFontFromMemoryCompressedBase85Ttf(payload, 13.0f, NewFontConfig());
                ImFontPtr ranged = atlas.AddFontFromMemoryCompressedBase85Ttf(payload, 13.0f, NewFontConfig(), atlas.GetGlyphRangesDefault());
                Assert.True(plain.NativePtr != IntPtr.Zero || configured.NativePtr != IntPtr.Zero || ranged.NativePtr != IntPtr.Zero);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies the custom rect API round trips: regular and font glyph rects are added,
        ///     the custom rects are looked up by index and the uv coordinates are calculated
        ///     after the atlas has been built.
        /// </summary>
        [MacOsOnly]
        public void CustomRects_And_CalcCustomRectUv_Execute()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                int regularIndex = atlas.AddCustomRectRegular(16, 16);
                Assert.True(regularIndex >= 0);
                ImFontPtr font = atlas.AddFontDefault();
                int glyphIndex = atlas.AddCustomRectFontGlyph(font, 65, 8, 8, 1.0f);
                Assert.True(glyphIndex >= 0);
                int offsetGlyphIndex = atlas.AddCustomRectFontGlyph(font, 66, 8, 8, 1.0f, new Vector2F(0.5f, 0.5f));
                Assert.True(offsetGlyphIndex >= 0);
                _ = atlas.GetCustomRectByIndex(regularIndex);
                Assert.True(atlas.Build());
                ImFontAtlasCustomRect packed = atlas.GetCustomRectByIndex(regularIndex);
                atlas.CalcCustomRectUv(packed, out Vector2F uvMin, out Vector2F uvMax);
                _ = uvMin;
                _ = uvMax;
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies Build, IsBuilt, SetTexId, the TexId setter and every IntPtr texture data
        ///     accessor execute against a built atlas.
        /// </summary>
        [MacOsOnly]
        public void Build_TextureData_And_MouseCursor_Execute()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                Assert.False(atlas.IsBuilt());
                atlas.AddFontDefault();
                Assert.True(atlas.Build());
                Assert.True(atlas.IsBuilt());
                atlas.GetTexDataAsRgba32(out IntPtr rgba, out int rgbaWidth, out int rgbaHeight);
                Assert.True(rgbaWidth > 0);
                Assert.True(rgbaHeight > 0);
                Assert.NotEqual(IntPtr.Zero, rgba);
                atlas.GetTexDataAsRgba32(out IntPtr rgba2, out int rgbaWidth2, out int rgbaHeight2, out int rgbaBpp);
                Assert.True(rgbaWidth2 > 0);
                Assert.Equal(4, rgbaBpp);
                atlas.GetTexDataAsAlpha8(out IntPtr alpha, out int alphaWidth, out int alphaHeight);
                Assert.True(alphaWidth > 0);
                Assert.True(alphaHeight > 0);
                Assert.NotEqual(IntPtr.Zero, alpha);
                atlas.GetTexDataAsAlpha8(out IntPtr alpha2, out int alphaWidth2, out int alphaHeight2, out int alphaBpp);
                Assert.True(alphaWidth2 > 0);
                Assert.Equal(1, alphaBpp);
                Assert.True(atlas.GetMouseCursorTexData(ImGuiMouseCursor.Arrow, out Vector2F cursorOffset, out Vector2F cursorSize, out Vector2F cursorUvBorder, out Vector2F cursorUvFill));
                _ = cursorOffset;
                _ = cursorSize;
                _ = cursorUvBorder;
                _ = cursorUvFill;
                atlas.SetTexId(IntPtr.Zero);
                Assert.Equal(IntPtr.Zero, atlas.TexId);
                atlas.TexId = new IntPtr(5);
                Assert.Equal(new IntPtr(5), atlas.TexId);
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies the whole clear family executes at the end of the atlas lifetime.
        /// </summary>
        [MacOsOnly]
        public void Clear_Operations_Execute()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                atlas.AddFontDefault();
                Assert.True(atlas.Build());
                atlas.ClearFonts();
                atlas.ClearInputData();
                atlas.ClearTexData();
                atlas.Clear();
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }

        /// <summary>
        ///     Verifies every pointer-backed field accessor executes against a live atlas.
        /// </summary>
        [MacOsOnly]
        public void PointerBackedProperties_Execute()
        {
            IntPtr context = CreateContext();
            try
            {
                ImFontAtlasPtr atlas = GetFontAtlas(context);
                _ = atlas.Flags;
                _ = atlas.TexDesiredWidth;
                _ = atlas.TexGlyphPadding;
                _ = atlas.Locked;
                _ = atlas.TexReady;
                _ = atlas.TexPixelsUseColors;
                _ = atlas.TexPixelsAlpha8;
                _ = atlas.TexPixelsRgba32;
                _ = atlas.TexWidth;
                _ = atlas.TexHeight;
                _ = atlas.TexUvScale;
                _ = atlas.TexUvWhitePixel;
                _ = atlas.Fonts;
                _ = atlas.CustomRects;
                _ = atlas.ConfigData;
                _ = atlas.FontBuilderIo;
                _ = atlas.FontBuilderFlags;
                _ = atlas.PackIdMouseCursors;
                _ = atlas.PackIdLines;
                Assert.Throws<ArgumentException>(() => atlas.TexPixelsAlpha8 = new IntPtr(0x1234));
                Assert.Throws<ArgumentException>(() => atlas.TexPixelsRgba32 = new IntPtr(0x5678));
                Assert.Throws<ArgumentException>(() => atlas.FontBuilderIo = new IntPtr(0x9ABC));
            }
            finally
            {
                ImGuiNative.igDestroyContext(context);
            }
        }
    }
}
