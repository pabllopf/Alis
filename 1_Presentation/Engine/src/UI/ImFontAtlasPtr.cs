// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImFontAtlasPtr.cs
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
using System.Text;
using Alis.App.Engine.UI.Utils;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.App.Engine.UI
{
    /// <summary>
    ///     The im font atlas ptr
    /// </summary>
    public unsafe struct ImFontAtlasPtr
    {
        /// <summary>
        ///     Gets the value of the native ptr
        /// </summary>
        public ImFontAtlas* NativePtr { get; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(ImFontAtlas* nativePtr) => NativePtr = nativePtr;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImFontAtlasPtr" /> class
        /// </summary>
        /// <param name="nativePtr">The native ptr</param>
        public ImFontAtlasPtr(IntPtr nativePtr) => NativePtr = (ImFontAtlas*) nativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasPtr(ImFontAtlas* nativePtr) => new ImFontAtlasPtr(nativePtr);

        /// <summary>
        /// </summary>
        /// <param name="wrappedPtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlas*(ImFontAtlasPtr wrappedPtr) => wrappedPtr.NativePtr;

        /// <summary>
        /// </summary>
        /// <param name="nativePtr"></param>
        /// <returns></returns>
        public static implicit operator ImFontAtlasPtr(IntPtr nativePtr) => new ImFontAtlasPtr(nativePtr);

        /// <summary>
        ///     Gets the value of the flags
        /// </summary>
        public ref ImFontAtlasFlags Flags => ref Unsafe.AsRef<ImFontAtlasFlags>(&NativePtr->Flags);

        /// <summary>
        ///     Gets the value of the tex id
        /// </summary>
        public ref IntPtr TexId => ref Unsafe.AsRef<IntPtr>(&NativePtr->TexId);

        /// <summary>
        ///     Gets the value of the tex desired width
        /// </summary>
        public ref int TexDesiredWidth => ref Unsafe.AsRef<int>(&NativePtr->TexDesiredWidth);

        /// <summary>
        ///     Gets the value of the tex glyph padding
        /// </summary>
        public ref int TexGlyphPadding => ref Unsafe.AsRef<int>(&NativePtr->TexGlyphPadding);

        /// <summary>
        ///     Gets the value of the locked
        /// </summary>
        public ref bool Locked => ref Unsafe.AsRef<bool>(&NativePtr->Locked);

        /// <summary>
        ///     Gets the value of the tex ready
        /// </summary>
        public ref bool TexReady => ref Unsafe.AsRef<bool>(&NativePtr->TexReady);

        /// <summary>
        ///     Gets the value of the tex pixels use colors
        /// </summary>
        public ref bool TexPixelsUseColors => ref Unsafe.AsRef<bool>(&NativePtr->TexPixelsUseColors);

        /// <summary>
        ///     Gets or sets the value of the tex pixels alpha 8
        /// </summary>
        public IntPtr TexPixelsAlpha8
        {
            get => (IntPtr) NativePtr->TexPixelsAlpha8;
            set => NativePtr->TexPixelsAlpha8 = (byte*) value;
        }

        /// <summary>
        ///     Gets or sets the value of the tex pixels rgba 32
        /// </summary>
        public IntPtr TexPixelsRgba32
        {
            get => (IntPtr) NativePtr->TexPixelsRgba32;
            set => NativePtr->TexPixelsRgba32 = (uint*) value;
        }

        /// <summary>
        ///     Gets the value of the tex width
        /// </summary>
        public ref int TexWidth => ref Unsafe.AsRef<int>(&NativePtr->TexWidth);

        /// <summary>
        ///     Gets the value of the tex height
        /// </summary>
        public ref int TexHeight => ref Unsafe.AsRef<int>(&NativePtr->TexHeight);

        /// <summary>
        ///     Gets the value of the tex uv scale
        /// </summary>
        public ref Vector2 TexUvScale => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvScale);

        /// <summary>
        ///     Gets the value of the tex uv white pixel
        /// </summary>
        public ref Vector2 TexUvWhitePixel => ref Unsafe.AsRef<Vector2>(&NativePtr->TexUvWhitePixel);

        /// <summary>
        ///     Gets the value of the fonts
        /// </summary>
        public ImVector<ImFontPtr> Fonts => new ImVector<ImFontPtr>(NativePtr->Fonts);

        /// <summary>
        ///     Gets the value of the custom rects
        /// </summary>
        public ImPtrVector<ImFontAtlasCustomRectPtr> CustomRects => new ImPtrVector<ImFontAtlasCustomRectPtr>(NativePtr->CustomRects, Unsafe.SizeOf<ImFontAtlasCustomRect>());

        /// <summary>
        ///     Gets the value of the config data
        /// </summary>
        public ImPtrVector<ImFontConfigPtr> ConfigData => new ImPtrVector<ImFontConfigPtr>(NativePtr->ConfigData, Unsafe.SizeOf<ImFontConfig>());

        /// <summary>
        ///     Gets the value of the tex uv lines
        /// </summary>
        public RangeAccessor<Vector4> TexUvLines => new RangeAccessor<Vector4>(&NativePtr->TexUvLines0, 64);

        /// <summary>
        ///     Gets or sets the value of the font builder io
        /// </summary>
        public IntPtr FontBuilderIo
        {
            get => (IntPtr) NativePtr->FontBuilderIo;
            set => NativePtr->FontBuilderIo = (IntPtr*) value;
        }

        /// <summary>
        ///     Gets the value of the font builder flags
        /// </summary>
        public ref uint FontBuilderFlags => ref Unsafe.AsRef<uint>(&NativePtr->FontBuilderFlags);

        /// <summary>
        ///     Gets the value of the pack id mouse cursors
        /// </summary>
        public ref int PackIdMouseCursors => ref Unsafe.AsRef<int>(&NativePtr->PackIdMouseCursors);

        /// <summary>
        ///     Gets the value of the pack id lines
        /// </summary>
        public ref int PackIdLines => ref Unsafe.AsRef<int>(&NativePtr->PackIdLines);

        /// <summary>
        ///     Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advanceX)
        {
            ImFont* nativeFont = font.NativePtr;
            Vector2 offset = new Vector2();
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, nativeFont, id, width, height, advanceX, offset);
            return ret;
        }

        /// <summary>
        ///     Adds the custom rect font glyph using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="id">The id</param>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <param name="advanceX">The advance</param>
        /// <param name="offset">The offset</param>
        /// <returns>The ret</returns>
        public int AddCustomRectFontGlyph(ImFontPtr font, ushort id, int width, int height, float advanceX, Vector2 offset)
        {
            ImFont* nativeFont = font.NativePtr;
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectFontGlyph(NativePtr, nativeFont, id, width, height, advanceX, offset);
            return ret;
        }

        /// <summary>
        ///     Adds the custom rect regular using the specified width
        /// </summary>
        /// <param name="width">The width</param>
        /// <param name="height">The height</param>
        /// <returns>The ret</returns>
        public int AddCustomRectRegular(int width, int height)
        {
            int ret = ImGuiNative.ImFontAtlas_AddCustomRectRegular(NativePtr, width, height);
            return ret;
        }

        /// <summary>
        ///     Adds the font using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFont(ImFontConfigPtr fontCfg)
        {
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFont(NativePtr, nativeFontCfg);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font default
        /// </summary>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault()
        {
            ImFontConfig* fontCfg = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, fontCfg);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font default using the specified font cfg
        /// </summary>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontDefault(ImFontConfigPtr fontCfg)
        {
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontDefault(NativePtr, nativeFontCfg);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels)
        {
            byte* nativeFilename;
            int filenameByteCount = 0;
            if (filename != null)
            {
                filenameByteCount = Encoding.UTF8.GetByteCount(filename);
                if (filenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFilename = Util.Allocate(filenameByteCount + 1);
                }
                else
                {
                    byte* nativeFilenameStackBytes = stackalloc byte[filenameByteCount + 1];
                    nativeFilename = nativeFilenameStackBytes;
                }

                int nativeFilenameOffset = Util.GetUtf8(filename, nativeFilename, filenameByteCount);
                nativeFilename[nativeFilenameOffset] = 0;
            }
            else
            {
                nativeFilename = null;
            }

            ImFontConfig* fontCfg = null;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, nativeFilename, sizePixels, fontCfg, glyphRanges);
            if (filenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFilename);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels, ImFontConfigPtr fontCfg)
        {
            byte* nativeFilename;
            int filenameByteCount = 0;
            if (filename != null)
            {
                filenameByteCount = Encoding.UTF8.GetByteCount(filename);
                if (filenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFilename = Util.Allocate(filenameByteCount + 1);
                }
                else
                {
                    byte* nativeFilenameStackBytes = stackalloc byte[filenameByteCount + 1];
                    nativeFilename = nativeFilenameStackBytes;
                }

                int nativeFilenameOffset = Util.GetUtf8(filename, nativeFilename, filenameByteCount);
                nativeFilename[nativeFilenameOffset] = 0;
            }
            else
            {
                nativeFilename = null;
            }

            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, nativeFilename, sizePixels, nativeFontCfg, glyphRanges);
            if (filenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFilename);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from file ttf using the specified filename
        /// </summary>
        /// <param name="filename">The filename</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromFileTtf(string filename, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            byte* nativeFilename;
            int filenameByteCount = 0;
            if (filename != null)
            {
                filenameByteCount = Encoding.UTF8.GetByteCount(filename);
                if (filenameByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeFilename = Util.Allocate(filenameByteCount + 1);
                }
                else
                {
                    byte* nativeFilenameStackBytes = stackalloc byte[filenameByteCount + 1];
                    nativeFilename = nativeFilenameStackBytes;
                }

                int nativeFilenameOffset = Util.GetUtf8(filename, nativeFilename, filenameByteCount);
                nativeFilename[nativeFilenameOffset] = 0;
            }
            else
            {
                nativeFilename = null;
            }

            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* nativeGlyphRanges = (ushort*) glyphRanges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromFileTTF(NativePtr, nativeFilename, sizePixels, nativeFontCfg, nativeGlyphRanges);
            if (filenameByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeFilename);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels)
        {
            byte* nativeCompressedFontDataBase85;
            int compressedFontDataBase85ByteCount = 0;
            if (compressedFontDataBase85 != null)
            {
                compressedFontDataBase85ByteCount = Encoding.UTF8.GetByteCount(compressedFontDataBase85);
                if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeCompressedFontDataBase85 = Util.Allocate(compressedFontDataBase85ByteCount + 1);
                }
                else
                {
                    byte* nativeCompressedFontDataBase85StackBytes = stackalloc byte[compressedFontDataBase85ByteCount + 1];
                    nativeCompressedFontDataBase85 = nativeCompressedFontDataBase85StackBytes;
                }

                int nativeCompressedFontDataBase85Offset = Util.GetUtf8(compressedFontDataBase85, nativeCompressedFontDataBase85, compressedFontDataBase85ByteCount);
                nativeCompressedFontDataBase85[nativeCompressedFontDataBase85Offset] = 0;
            }
            else
            {
                nativeCompressedFontDataBase85 = null;
            }

            ImFontConfig* fontCfg = null;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, nativeCompressedFontDataBase85, sizePixels, fontCfg, glyphRanges);
            if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeCompressedFontDataBase85);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfigPtr fontCfg)
        {
            byte* nativeCompressedFontDataBase85;
            int compressedFontDataBase85ByteCount = 0;
            if (compressedFontDataBase85 != null)
            {
                compressedFontDataBase85ByteCount = Encoding.UTF8.GetByteCount(compressedFontDataBase85);
                if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeCompressedFontDataBase85 = Util.Allocate(compressedFontDataBase85ByteCount + 1);
                }
                else
                {
                    byte* nativeCompressedFontDataBase85StackBytes = stackalloc byte[compressedFontDataBase85ByteCount + 1];
                    nativeCompressedFontDataBase85 = nativeCompressedFontDataBase85StackBytes;
                }

                int nativeCompressedFontDataBase85Offset = Util.GetUtf8(compressedFontDataBase85, nativeCompressedFontDataBase85, compressedFontDataBase85ByteCount);
                nativeCompressedFontDataBase85[nativeCompressedFontDataBase85Offset] = 0;
            }
            else
            {
                nativeCompressedFontDataBase85 = null;
            }

            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, nativeCompressedFontDataBase85, sizePixels, nativeFontCfg, glyphRanges);
            if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeCompressedFontDataBase85);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed base 85 ttf using the specified compressed font data base85
        /// </summary>
        /// <param name="compressedFontDataBase85">The compressed font data base85</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedBase85Ttf(string compressedFontDataBase85, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            byte* nativeCompressedFontDataBase85;
            int compressedFontDataBase85ByteCount = 0;
            if (compressedFontDataBase85 != null)
            {
                compressedFontDataBase85ByteCount = Encoding.UTF8.GetByteCount(compressedFontDataBase85);
                if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
                {
                    nativeCompressedFontDataBase85 = Util.Allocate(compressedFontDataBase85ByteCount + 1);
                }
                else
                {
                    byte* nativeCompressedFontDataBase85StackBytes = stackalloc byte[compressedFontDataBase85ByteCount + 1];
                    nativeCompressedFontDataBase85 = nativeCompressedFontDataBase85StackBytes;
                }

                int nativeCompressedFontDataBase85Offset = Util.GetUtf8(compressedFontDataBase85, nativeCompressedFontDataBase85, compressedFontDataBase85ByteCount);
                nativeCompressedFontDataBase85[nativeCompressedFontDataBase85Offset] = 0;
            }
            else
            {
                nativeCompressedFontDataBase85 = null;
            }

            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* nativeGlyphRanges = (ushort*) glyphRanges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedBase85TTF(NativePtr, nativeCompressedFontDataBase85, sizePixels, nativeFontCfg, nativeGlyphRanges);
            if (compressedFontDataBase85ByteCount > Util.StackAllocationSizeLimit)
            {
                Util.Free(nativeCompressedFontDataBase85);
            }

            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels)
        {
            void* nativeCompressedFontData = compressedFontData.ToPointer();
            ImFontConfig* fontCfg = null;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, nativeCompressedFontData, compressedFontSize, sizePixels, fontCfg, glyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfigPtr fontCfg)
        {
            void* nativeCompressedFontData = compressedFontData.ToPointer();
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, nativeCompressedFontData, compressedFontSize, sizePixels, nativeFontCfg, glyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory compressed ttf using the specified compressed font data
        /// </summary>
        /// <param name="compressedFontData">The compressed font data</param>
        /// <param name="compressedFontSize">The compressed font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryCompressedTtf(IntPtr compressedFontData, int compressedFontSize, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            void* nativeCompressedFontData = compressedFontData.ToPointer();
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* nativeGlyphRanges = (ushort*) glyphRanges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryCompressedTTF(NativePtr, nativeCompressedFontData, compressedFontSize, sizePixels, nativeFontCfg, nativeGlyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels)
        {
            void* nativeFontData = fontData.ToPointer();
            ImFontConfig* fontCfg = null;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, nativeFontData, fontSize, sizePixels, fontCfg, glyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfigPtr fontCfg)
        {
            void* nativeFontData = fontData.ToPointer();
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* glyphRanges = null;
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, nativeFontData, fontSize, sizePixels, nativeFontCfg, glyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Adds the font from memory ttf using the specified font data
        /// </summary>
        /// <param name="fontData">The font data</param>
        /// <param name="fontSize">The font size</param>
        /// <param name="sizePixels">The size pixels</param>
        /// <param name="fontCfg">The font cfg</param>
        /// <param name="glyphRanges">The glyph ranges</param>
        /// <returns>The im font ptr</returns>
        public ImFontPtr AddFontFromMemoryTtf(IntPtr fontData, int fontSize, float sizePixels, ImFontConfigPtr fontCfg, IntPtr glyphRanges)
        {
            void* nativeFontData = fontData.ToPointer();
            ImFontConfig* nativeFontCfg = fontCfg.NativePtr;
            ushort* nativeGlyphRanges = (ushort*) glyphRanges.ToPointer();
            ImFont* ret = ImGuiNative.ImFontAtlas_AddFontFromMemoryTTF(NativePtr, nativeFontData, fontSize, sizePixels, nativeFontCfg, nativeGlyphRanges);
            return new ImFontPtr(ret);
        }

        /// <summary>
        ///     Describes whether this instance build
        /// </summary>
        /// <returns>The bool</returns>
        public bool Build()
        {
            byte ret = ImGuiNative.ImFontAtlas_Build(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Calcs the custom rect uv using the specified rect
        /// </summary>
        /// <param name="rect">The rect</param>
        /// <param name="outUvMin">The out uv min</param>
        /// <param name="outUvMax">The out uv max</param>
        public void CalcCustomRectUv(ImFontAtlasCustomRectPtr rect, out Vector2 outUvMin, out Vector2 outUvMax)
        {
            ImFontAtlasCustomRect* nativeRect = rect.NativePtr;
            fixed (Vector2* nativeOutUvMin = &outUvMin)
            {
                fixed (Vector2* nativeOutUvMax = &outUvMax)
                {
                    ImGuiNative.ImFontAtlas_CalcCustomRectUV(NativePtr, nativeRect, nativeOutUvMin, nativeOutUvMax);
                }
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            ImGuiNative.ImFontAtlas_Clear(NativePtr);
        }

        /// <summary>
        ///     Clears the fonts
        /// </summary>
        public void ClearFonts()
        {
            ImGuiNative.ImFontAtlas_ClearFonts(NativePtr);
        }

        /// <summary>
        ///     Clears the input data
        /// </summary>
        public void ClearInputData()
        {
            ImGuiNative.ImFontAtlas_ClearInputData(NativePtr);
        }

        /// <summary>
        ///     Clears the tex data
        /// </summary>
        public void ClearTexData()
        {
            ImGuiNative.ImFontAtlas_ClearTexData(NativePtr);
        }

        /// <summary>
        ///     Destroys this instance
        /// </summary>
        public void Destroy()
        {
            ImGuiNative.ImFontAtlas_destroy(NativePtr);
        }

        /// <summary>
        ///     Gets the custom rect by index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The im font atlas custom rect ptr</returns>
        public ImFontAtlasCustomRectPtr GetCustomRectByIndex(int index)
        {
            ImFontAtlasCustomRect* ret = ImGuiNative.ImFontAtlas_GetCustomRectByIndex(NativePtr, index);
            return new ImFontAtlasCustomRectPtr(ret);
        }

        /// <summary>
        ///     Gets the glyph ranges chinese full
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseFull()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseFull(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges chinese simplified common
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesChineseSimplifiedCommon()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesChineseSimplifiedCommon(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges cyrillic
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesCyrillic()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesCyrillic(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges default
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesDefault()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesDefault(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges greek
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesGreek()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesGreek(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges japanese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesJapanese()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesJapanese(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges korean
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesKorean()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesKorean(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges thai
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesThai()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesThai(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Gets the glyph ranges vietnamese
        /// </summary>
        /// <returns>The int ptr</returns>
        public IntPtr GetGlyphRangesVietnamese()
        {
            ushort* ret = ImGuiNative.ImFontAtlas_GetGlyphRangesVietnamese(NativePtr);
            return (IntPtr) ret;
        }

        /// <summary>
        ///     Describes whether this instance get mouse cursor tex data
        /// </summary>
        /// <param name="cursor">The cursor</param>
        /// <param name="outOffset">The out offset</param>
        /// <param name="outSize">The out size</param>
        /// <param name="outUvBorder">The out uv border</param>
        /// <param name="outUvFill">The out uv fill</param>
        /// <returns>The bool</returns>
        public bool GetMouseCursorTexData(ImGuiMouseCursor cursor, out Vector2 outOffset, out Vector2 outSize, out Vector2 outUvBorder, out Vector2 outUvFill)
        {
            fixed (Vector2* nativeOutOffset = &outOffset)
            {
                fixed (Vector2* nativeOutSize = &outSize)
                {
                    fixed (Vector2* nativeOutUvBorder = &outUvBorder)
                    {
                        fixed (Vector2* nativeOutUvFill = &outUvFill)
                        {
                            byte ret = ImGuiNative.ImFontAtlas_GetMouseCursorTexData(NativePtr, cursor, nativeOutOffset, nativeOutSize, nativeOutUvBorder, nativeOutUvFill);
                            return ret != 0;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out byte* outPixels, out int outWidth, out int outHeight)
        {
            int* outBytesPerPixel = null;
            fixed (byte** nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, outBytesPerPixel);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out byte* outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            fixed (byte** nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        fixed (int* nativeOutBytesPerPixel = &outBytesPerPixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, nativeOutBytesPerPixel);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            int* outBytesPerPixel = null;
            fixed (IntPtr* nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, outBytesPerPixel);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as alpha 8 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsAlpha8(out IntPtr outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            fixed (IntPtr* nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        fixed (int* nativeOutBytesPerPixel = &outBytesPerPixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsAlpha8(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, nativeOutBytesPerPixel);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out byte* outPixels, out int outWidth, out int outHeight)
        {
            int* outBytesPerPixel = null;
            fixed (byte** nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, outBytesPerPixel);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsRgba32(out byte* outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            fixed (byte** nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        fixed (int* nativeOutBytesPerPixel = &outBytesPerPixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, nativeOutBytesPerPixel);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight)
        {
            int* outBytesPerPixel = null;
            fixed (IntPtr* nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, outBytesPerPixel);
                    }
                }
            }
        }

        /// <summary>
        ///     Gets the tex data as rgba 32 using the specified out pixels
        /// </summary>
        /// <param name="outPixels">The out pixels</param>
        /// <param name="outWidth">The out width</param>
        /// <param name="outHeight">The out height</param>
        /// <param name="outBytesPerPixel">The out bytes per pixel</param>
        public void GetTexDataAsRgba32(out IntPtr outPixels, out int outWidth, out int outHeight, out int outBytesPerPixel)
        {
            fixed (IntPtr* nativeOutPixels = &outPixels)
            {
                fixed (int* nativeOutWidth = &outWidth)
                {
                    fixed (int* nativeOutHeight = &outHeight)
                    {
                        fixed (int* nativeOutBytesPerPixel = &outBytesPerPixel)
                        {
                            ImGuiNative.ImFontAtlas_GetTexDataAsRGBA32(NativePtr, nativeOutPixels, nativeOutWidth, nativeOutHeight, nativeOutBytesPerPixel);
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Describes whether this instance is built
        /// </summary>
        /// <returns>The bool</returns>
        public bool IsBuilt()
        {
            byte ret = ImGuiNative.ImFontAtlas_IsBuilt(NativePtr);
            return ret != 0;
        }

        /// <summary>
        ///     Sets the tex id using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        public void SetTexId(IntPtr id)
        {
            ImGuiNative.ImFontAtlas_SetTexID(NativePtr, id);
        }
    }
}