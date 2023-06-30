// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtfExtern.cs
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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Memory;
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Graphic.SDL.Extern
{
    /// <summary>
    ///     The sdl ttf extern class
    /// </summary>
    public static class SdlTtfExtern
    {
        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfLinkedVersion() => INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_ByteSwappedUNICODE(int swapped);

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        public static void TtfByteSwappedUnicode([NotNull] int swapped) => TTF_ByteSwappedUNICODE(Check.NotNull(swapped, nameof(swapped)));

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_Init();

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <exception cref="Exception">TTF_Init failed</exception>
        /// <returns>The result</returns>
        public static int TtfInit()
        {
            int result = TTF_Init();
            if (result == -1)
            {
                throw new Exception("TTF_Init failed");
            }

            return result;
        }

        /// <summary>
        ///     Internals the ttf open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_OpenFont(byte[] file, int ptSize);

        /// <summary>
        ///     Internal ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfOpenFont(byte[] file, int ptSize) => INTERNAL_TTF_OpenFont(file, ptSize);

        /// <summary>
        ///     Ttf the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The freeSrc</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_OpenFontRW(IntPtr src, int freeSrc, int ptSize);

        /// <summary>
        ///     Ttf the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfOpenFontRw(IntPtr src, int freeSrc, int ptSize) => TTF_OpenFontRW(src, freeSrc, ptSize);

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">the size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_OpenFontIndex(byte[] file, int ptSize, long index);

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfOpenFontIndex(byte[] file, int ptSize, long index) => INTERNAL_TTF_OpenFontIndex(file, ptSize, index);

        /// <summary>
        ///     Ttf the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_OpenFontIndexRW(IntPtr src, int freeSrc, int ptSize, long index);

        /// <summary>
        ///     Ttf the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfOpenFontIndexRw(IntPtr src, int freeSrc, int ptSize, long index) => TTF_OpenFontIndexRW(src, freeSrc, ptSize, index);

        /// <summary>
        ///     Ttf the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptSize">The size</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_SetFontSize(IntPtr font, int ptSize);

        /// <summary>
        ///     Ttf the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int</returns>
        public static int TtfSetFontSize(IntPtr font, int ptSize) => TTF_SetFontSize(font, ptSize);

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontStyle(IntPtr font);

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfGetFontStyle(IntPtr font) => TTF_GetFontStyle(font);

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontStyle(IntPtr font, int style);

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        public static void TtfSetFontStyle(IntPtr font, int style) => TTF_SetFontStyle(font, style);

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontOutline(IntPtr font);

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfGetFontOutline(IntPtr font) => TTF_GetFontOutline(font);

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontOutline(IntPtr font, int outline);

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        public static void TtfSetFontOutline(IntPtr font, int outline) => TTF_SetFontOutline(font, outline);

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontHinting(IntPtr font);

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfGetFontHinting(IntPtr font) => TTF_GetFontHinting(font);

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontHinting(IntPtr font, int hinting);

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        public static void TtfSetFontHinting(IntPtr font, int hinting) => TTF_SetFontHinting(font, hinting);

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_FontHeight(IntPtr font);

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfFontHeight(IntPtr font) => TTF_FontHeight(font);

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_FontAscent(IntPtr font);

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfFontAscent(IntPtr font) => TTF_FontAscent(font);

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_FontDescent(IntPtr font);

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfFontDescent(IntPtr font) => TTF_FontDescent(font);

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_FontLineSkip(IntPtr font);

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfFontLineSkip(IntPtr font) => TTF_FontLineSkip(font);

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontKerning(IntPtr font);

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfGetFontKerning(IntPtr font) => TTF_GetFontKerning(font);

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontKerning(IntPtr font, int allowed);

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        public static void TtfSetFontKerning(IntPtr font, int allowed) => TTF_SetFontKerning(font, allowed);

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_FontFaces(IntPtr font);

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfFontFaces(IntPtr font) => TTF_FontFaces(font);

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        public static int TtfFontFaceIsFixedWidth(IntPtr font) => TTF_FontFaceIsFixedWidth(font);

        /// <summary>
        ///     Internals the ttf font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(IntPtr font);

        /// <summary>
        ///     Internals the ttf font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfFontFaceFamilyName(IntPtr font) => INTERNAL_TTF_FontFaceFamilyName(font);

        /// <summary>
        ///     Ttf the font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        public static string TtfFontFaceFamilyName(IntPtr font) => Sdl.UTF8_ToManaged(InternalTtfFontFaceFamilyName(font));

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(IntPtr font);

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfFontFaceStyleName(IntPtr font) => INTERNAL_TTF_FontFaceStyleName(font);

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        public static int TtfGlyphIsProvided(IntPtr font, ushort ch) => TTF_GlyphIsProvided(font, ch);

        /// <summary>
        ///     Ttf the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GlyphIsProvided32(IntPtr font, uint ch);

        /// <summary>
        ///     Ttf the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        public static int TtfGlyphIsProvided32(IntPtr font, uint ch) => TTF_GlyphIsProvided32(font, ch);

        /// <summary>
        ///     Ttf the glyph metrics using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="max">The max</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GlyphMetrics(IntPtr font, ushort ch, out int minx, out int max, out int miny, out int maxy, out int advance);

        /// <summary>
        ///     Ttf the glyph metrics using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="max">The max</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        public static int TtfGlyphMetrics(IntPtr font, ushort ch, out int minx, out int max, out int miny, out int maxy, out int advance) => TTF_GlyphMetrics(font, ch, out minx, out max, out miny, out maxy, out advance);

        /// <summary>
        ///     Ttf the glyph metrics 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="max">The max</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GlyphMetrics32(IntPtr font, uint ch, out int minx, out int max, out int miny, out int maxy, out int advance);

        /// <summary>
        ///     Ttf the glyph metrics 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="max">The max</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        public static int TtfGlyphMetrics32(IntPtr font, uint ch, out int minx, out int max, out int miny, out int maxy, out int advance) => TTF_GlyphMetrics32(font, ch, out minx, out max, out miny, out maxy, out advance);

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_SizeText(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, out int w, out int h);

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int TtfSizeText(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, out int w, out int h) => TTF_SizeText(font, text, out w, out h);

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_TTF_SizeUTF8(IntPtr font, byte[] text, out int w, out int h);

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int InternalTtfSizeUtf8(IntPtr font, byte[] text, out int w, out int h) => INTERNAL_TTF_SizeUTF8(font, text, out w, out h);

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_SizeUNICODE(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, out int w, out int h);

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        public static int TtfSizeUnicode(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, out int w, out int h) => TTF_SizeUNICODE(font, text, out w, out h);

        /// <summary>
        ///     Ttf the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_MeasureText(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, int measureWidth, out int extent, out int count);

        /// <summary>
        ///     Ttf the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int TtfMeasureText(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, int measureWidth, out int extent, out int count) => TTF_MeasureText(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Internals the ttf measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_MeasureUTF8", CallingConvention = CallingConvention.Cdecl)]
        private static extern int INTERNAL_TTF_MeasureUTF8(IntPtr font, byte[] text, int measureWidth, out int extent, out int count);

        /// <summary>
        ///     Internals the ttf measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int InternalTtfMeasureUtf8(IntPtr font, byte[] text, int measureWidth, out int extent, out int count) => INTERNAL_TTF_MeasureUTF8(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Ttf the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_MeasureUNICODE(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, int measureWidth, out int extent, out int count);

        /// <summary>
        ///     Ttf the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        public static int TtfMeasureUnicode(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, int measureWidth, out int extent, out int count) => TTF_MeasureUNICODE(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Solid(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg);

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextSolid(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg) => TTF_RenderText_Solid(font, text, fg);

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid(IntPtr font, byte[] text, SdlColor fg);

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8Solid(IntPtr font, byte[] text, SdlColor fg) => INTERNAL_TTF_RenderUTF8_Solid(font, text, fg);

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Solid(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg);

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeSolid(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg) => TTF_RenderUNICODE_Solid(font, text, fg);

        /// <summary>
        ///     Ttf the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Solid_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, uint wrapLength);

        /// <summary>
        ///     Ttf the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextSolidWrapped(IntPtr font, string text, SdlColor fg, uint wrapLength) => TTF_RenderText_Solid_Wrapped(font, text, fg, wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid_Wrapped(IntPtr font, byte[] text, SdlColor fg, uint wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8SolidWrapped(IntPtr font, byte[] text, SdlColor fg, uint wrapLength) => INTERNAL_TTF_RenderUTF8_Solid_Wrapped(font, text, fg, wrapLength);

        /// <summary>
        ///     Ttf the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Solid_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, uint wrapLength);

        /// <summary>
        ///     Ttf the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeSolidWrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, uint wrapLength) => TTF_RenderUNICODE_Solid_Wrapped(font, text, fg, wrapLength);

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph_Solid(IntPtr font, ushort ch, SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyphSolid(IntPtr font, ushort ch, SdlColor fg) => TTF_RenderGlyph_Solid(font, ch, fg);

        /// <summary>
        ///     Ttf the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph32_Solid(IntPtr font, uint ch, SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyph32Solid(IntPtr font, uint ch, SdlColor fg) => TTF_RenderGlyph32_Solid(font, ch, fg);

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Shaded(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, SdlColor bg);

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextShaded(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, SdlColor bg) => TTF_RenderText_Shaded(font, text, fg, bg);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded(IntPtr font, byte[] text, SdlColor fg, SdlColor bg);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8Shaded(IntPtr font, byte[] text, SdlColor fg, SdlColor bg) => INTERNAL_TTF_RenderUTF8_Shaded(font, text, fg, bg);

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Shaded(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, SdlColor bg);

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeShaded(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, SdlColor bg) => TTF_RenderUNICODE_Shaded(font, text, fg, bg);

        /// <summary>
        ///     Ttf the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Shaded_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, SdlColor bg, uint wrapLength);

        /// <summary>
        ///     Ttf the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextShadedWrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, SdlColor bg, uint wrapLength) => TTF_RenderText_Shaded_Wrapped(font, text, fg, bg, wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(IntPtr font, byte[] text, SdlColor fg, SdlColor bg, uint wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8ShadedWrapped(IntPtr font, byte[] text, SdlColor fg, SdlColor bg, uint wrapLength) => INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(font, text, fg, bg, wrapLength);

        /// <summary>
        ///     Ttf the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Shaded_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, SdlColor bg, uint wrapLength);

        /// <summary>
        ///     Ttf the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeShadedWrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, SdlColor bg, uint wrapLength) => TTF_RenderUNICODE_Shaded_Wrapped(font, text, fg, bg, wrapLength);

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph_Shaded(IntPtr font, ushort ch, SdlColor fg, SdlColor bg);

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyphShaded(IntPtr font, ushort ch, SdlColor fg, SdlColor bg) => TTF_RenderGlyph_Shaded(font, ch, fg, bg);

        /// <summary>
        ///     Ttf the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph32_Shaded(IntPtr font, uint ch, SdlColor fg, SdlColor bg);

        /// <summary>
        ///     Ttf the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyph32Shaded(IntPtr font, uint ch, SdlColor fg, SdlColor bg) => TTF_RenderGlyph32_Shaded(font, ch, fg, bg);

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Blended(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg);

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextBlended(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg) => TTF_RenderText_Blended(font, text, fg);

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended(IntPtr font, byte[] text, SdlColor fg);

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8Blended(IntPtr font, byte[] text, SdlColor fg) => INTERNAL_TTF_RenderUTF8_Blended(font, text, fg);

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Blended(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg);

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeBlended(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg) => TTF_RenderUNICODE_Blended(font, text, fg);

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderText_Blended_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPStr)] string text, SdlColor fg, uint wrapped);

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderTextBlendedWrapped(IntPtr font, string text, SdlColor fg, uint wrapped) => TTF_RenderText_Blended_Wrapped(font, text, fg, wrapped);

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(IntPtr font, byte[] text, SdlColor fg, uint wrapped);

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="sdlColor">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        public static IntPtr InternalTtfRenderUtf8BlendedWrapped([NotNull] IntPtr font, [NotNull] byte[] text, [NotNull] SdlColor sdlColor, [NotNull] uint wrapped)
        {
            return INTERNAL_TTF_RenderUTF8_Blended_Wrapped(font, text, sdlColor, wrapped);
        }
        
        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(IntPtr font, [In, MarshalAs(UnmanagedType.LPWStr)] string text, SdlColor fg, uint wrapped);

        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderUnicodeBlendedWrapped(IntPtr font, string text, SdlColor fg, uint wrapped) => TTF_RenderUNICODE_Blended_Wrapped(font, text, fg, wrapped);

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph_Blended(IntPtr font, ushort ch, SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyphBlended(IntPtr font, ushort ch, SdlColor fg) => TTF_RenderGlyph_Blended(font, ch, fg);

        /// <summary>
        ///     Ttf the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr TTF_RenderGlyph32_Blended(IntPtr font, uint ch, SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        public static IntPtr TtfRenderGlyph32Blended(IntPtr font, uint ch, SdlColor fg) => TTF_RenderGlyph32_Blended(font, ch, fg);

        /// <summary>
        ///     Ttf the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_SetDirection(int direction);

        /// <summary>
        ///     Ttf the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        public static int TtfSetDirection(int direction) => TTF_SetDirection(direction);

        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_SetScript(int script);

        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        public static int TtfSetScript(int script) => TTF_SetScript(script);

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_CloseFont(IntPtr font);

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        public static void TtfCloseFont(IntPtr font) => TTF_CloseFont(font);

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_Quit();

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        public static void TtfQuit() => TTF_Quit();

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_WasInit();

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        public static int TtfWasInit() => TTF_WasInit();

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int SDL_GetFontKerningSize(IntPtr font, int prevIndex, int index);

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        public static int SdlGetFontKerningSize(IntPtr font, int prevIndex, int index) => SDL_GetFontKerningSize(font, prevIndex, index);

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontKerningSizeGlyphs(IntPtr font, ushort previousCh, ushort ch);

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        public static int TtfGetFontKerningSizeGlyphs(IntPtr font, ushort previousCh, ushort ch) => TTF_GetFontKerningSizeGlyphs(font, previousCh, ch);

        /// <summary>
        ///     Ttf the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int TTF_GetFontKerningSizeGlyphs32(IntPtr font, ushort previousCh, ushort ch);

        /// <summary>
        ///     Ttf the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        public static int TtfGetFontKerningSizeGlyphs32(IntPtr font, ushort previousCh, ushort ch)
        {
            return TTF_GetFontKerningSizeGlyphs32(font, previousCh, ch);
        }
    }
}