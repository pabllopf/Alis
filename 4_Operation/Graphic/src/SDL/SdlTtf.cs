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
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl ttf extern class
    /// </summary>
    public static class SdlTtf
    {
         /// <summary>
        ///     Initializes a new instance of the <see cref="SdlTtf" /> class
        /// </summary>
        static SdlTtf()
        {
            EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf", SdlDlls.SdlTtfDllBytes);
        }

        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2_ttf";

        /// <summary>
        ///     The sdl ttf major version
        /// </summary>
        private const int SdlTtfMajorVersion = 2;

        /// <summary>
        ///     The sdl ttf minor version
        /// </summary>
        private const int SdlTtfMinorVersion = 0;

        /// <summary>
        ///     The sdl ttf patch level
        /// </summary>
        private const int SdlTtfPatchLevel = 16;

        /// <summary>
        ///     The unicode bom native
        /// </summary>
        public const int UnicodeBomNative = 0xFEFF;

        /// <summary>
        ///     The unicode bom swapped
        /// </summary>
        public const int UnicodeBomSwapped = 0xFFFE;

        /// <summary>
        ///     The ttf style normal
        /// </summary>
        public const int TtfStyleNormal = 0x00;

        /// <summary>
        ///     The ttf style bold
        /// </summary>
        public const int TtfStyleBold = 0x01;

        /// <summary>
        ///     The ttf style italic
        /// </summary>
        public const int TtfStyleItalic = 0x02;

        /// <summary>
        ///     The ttf style underline
        /// </summary>
        public const int TtfStyleUnderline = 0x04;

        /// <summary>
        ///     The ttf style strikethrough
        /// </summary>
        public const int TtfStyleStrikethrough = 0x08;

        /// <summary>
        ///     The ttf hinting normal
        /// </summary>
        public const int TtfHintingNormal = 0;

        /// <summary>
        ///     The ttf hinting light
        /// </summary>
        public const int TtfHintingLight = 1;

        /// <summary>
        ///     The ttf hinting mono
        /// </summary>
        public const int TtfHintingMono = 2;

        /// <summary>
        ///     The ttf hinting none
        /// </summary>
        public const int TtfHintingNone = 3;

        /// <summary>
        ///     The ttf hinting light subpixel
        /// </summary>
        public const int TtfHintingLightSubpixel = 4;
        
        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfLinkedVersion() => INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern void TTF_ByteSwappedUNICODE([NotNull, NotZero] int swapped);

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [return: NotNull]
        public static void TtfByteSwappedUnicode([NotNull, NotZero]  int swapped) => TTF_ByteSwappedUNICODE(swapped.Validate());

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int TTF_Init();

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <exception cref="Exception">TTF_Init failed</exception>
        /// <returns>The result</returns>
        [return: NotNull, NotZero]
        public static int TtfInit() => TTF_Init() == -1 ? throw new Exception("TTF_Init failed") : 0;

        /// <summary>
        ///     Internals the ttf open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_OpenFont([NotNull, NotEmpty] byte[] file, [NotNull, NotZero] int ptSize);

        /// <summary>
        ///     Internal ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr TtfOpenFont([NotNull, NotEmpty]  byte[] file, [NotNull, NotZero] int ptSize) => INTERNAL_TTF_OpenFont(file.Validate(), ptSize.Validate());

        /// <summary>
        ///     Ttf the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The freeSrc</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_OpenFontRW([NotNull] IntPtr src, [NotNull, NotZero] int freeSrc, [NotNull, NotZero] int ptSize);

        /// <summary>
        ///     Ttf the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfOpenFontRw([NotNull] IntPtr src, [NotNull, NotZero]  int freeSrc, [NotNull, NotZero] int ptSize) => TTF_OpenFontRW(src.Validate(), freeSrc.Validate(), ptSize.Validate());

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">the size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_OpenFontIndex([NotNull, NotEmpty] byte[] file, [NotNull, NotZero] int ptSize, [NotNull, NotZero] long index);

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfOpenFontIndex([NotNull, NotEmpty]  byte[] file, [NotNull, NotZero]  int ptSize, [NotNull, NotZero]  long index) => INTERNAL_TTF_OpenFontIndex(file.Validate(), ptSize.Validate(), index.Validate());

        /// <summary>
        ///     Ttf the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_OpenFontIndexRW([NotNull] IntPtr src, [NotNull, NotZero] int freeSrc, [NotNull, NotZero] int ptSize, [NotNull, NotZero] long index);

        /// <summary>
        ///     Ttf the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfOpenFontIndexRw([NotNull] IntPtr src, [NotNull, NotZero] int freeSrc, [NotNull, NotZero] int ptSize, [NotNull, NotZero]  long index) => TTF_OpenFontIndexRW(src.Validate(), freeSrc.Validate(), ptSize.Validate(), index.Validate());

        /// <summary>
        ///     Ttf the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptSize">The size</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_SetFontSize([NotNull] IntPtr font, [NotNull, NotZero] int ptSize);

        /// <summary>
        ///     Ttf the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfSetFontSize([NotNull] IntPtr font, [NotNull, NotZero] int ptSize) => TTF_SetFontSize(font.Validate(), ptSize.Validate());

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GetFontStyle([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGetFontStyle([NotNull] IntPtr font) => TTF_GetFontStyle(font.Validate());

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontStyle([NotNull] IntPtr font, [NotNull, NotZero] int style);

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        public static void TtfSetFontStyle([NotNull] IntPtr font, [NotNull, NotZero] int style) => TTF_SetFontStyle(font.Validate(), style.Validate());

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GetFontOutline([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGetFontOutline([NotNull] IntPtr font) => TTF_GetFontOutline(font.Validate());

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern void TTF_SetFontOutline([NotNull] IntPtr font, [NotNull, NotZero] int outline);

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [return: NotNull, NotZero]
        public static void TtfSetFontOutline([NotNull] IntPtr font, [NotNull, NotZero] int outline) => TTF_SetFontOutline(font.Validate(), outline.Validate());

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GetFontHinting([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGetFontHinting([NotNull] IntPtr font) => TTF_GetFontHinting(font.Validate());

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_SetFontHinting([NotNull] IntPtr font, [NotNull, NotZero] int hinting);

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        public static void TtfSetFontHinting([NotNull] IntPtr font, [NotNull, NotZero] int hinting) => TTF_SetFontHinting(font.Validate(), hinting.Validate());

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_FontHeight([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfFontHeight([NotNull] IntPtr font) => TTF_FontHeight(font.Validate());

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_FontAscent([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfFontAscent([NotNull] IntPtr font) => TTF_FontAscent(font.Validate());

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_FontDescent([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfFontDescent([NotNull] IntPtr font) => TTF_FontDescent(font.Validate());

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_FontLineSkip([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfFontLineSkip([NotNull] IntPtr font) => TTF_FontLineSkip(font.Validate());

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GetFontKerning([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGetFontKerning([NotNull] IntPtr font) => TTF_GetFontKerning(font.Validate());

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern void TTF_SetFontKerning([NotNull] IntPtr font, [NotNull, NotZero] int allowed);

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [return: NotNull, NotZero]
        public static void TtfSetFontKerning([NotNull] IntPtr font, [NotNull, NotZero] int allowed) => TTF_SetFontKerning(font.Validate(), allowed.Validate());

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern IntPtr TTF_FontFaces([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: NotNull, NotZero]
        public static IntPtr TtfFontFaces([NotNull] IntPtr font) => TTF_FontFaces(font.Validate());

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_FontFaceIsFixedWidth([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfFontFaceIsFixedWidth([NotNull] IntPtr font) => TTF_FontFaceIsFixedWidth(font.Validate());

        /// <summary>
        ///     Internals the ttf font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName([NotNull] IntPtr font);
        
        /// <summary>
        ///     Ttf the font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        [return: NotNull, NotEmpty]
        public static string TtfFontFaceFamilyName([NotNull] IntPtr font) => Sdl.UTF8_ToManaged(INTERNAL_TTF_FontFaceFamilyName(font.Validate()));

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_FontFaceStyleName([NotNull] IntPtr font);

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfFontFaceStyleName([NotNull] IntPtr font) => INTERNAL_TTF_FontFaceStyleName(font.Validate());

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GlyphIsProvided([NotNull] IntPtr font, [NotNull, NotZero] ushort ch);

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGlyphIsProvided(IntPtr font, ushort ch) => TTF_GlyphIsProvided(font.Validate(), ch.Validate());

        /// <summary>
        ///     Ttf the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GlyphIsProvided32([NotNull]IntPtr font, [NotNull, NotZero] uint ch);

        /// <summary>
        ///     Ttf the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfGlyphIsProvided32([NotNull]IntPtr font, [NotNull, NotZero]uint ch) => TTF_GlyphIsProvided32(font.Validate(), ch.Validate());

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GlyphMetrics([NotNull]IntPtr font, [NotNull, NotZero]ushort ch, [NotNull, NotZero] out int minx, [NotNull, NotZero] out int max, [NotNull, NotZero] out int miny, [NotNull, NotZero] out int maxy, [NotNull, NotZero] out int advance);

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
        [return: NotNull, NotZero]
        public static int TtfGlyphMetrics([NotNull]IntPtr font, [NotNull, NotZero] ushort ch, [NotNull, NotZero]out int minx, [NotNull, NotZero]out int max, [NotNull, NotZero]out int miny, [NotNull, NotZero]out int maxy, [NotNull, NotZero]out int advance) => TTF_GlyphMetrics(font, ch, out minx, out max, out miny, out maxy, out advance);

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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_GlyphMetrics32([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull, NotZero]out int minx, [NotNull, NotZero]out int max, [NotNull, NotZero]out int miny, [NotNull, NotZero]out int maxy, [NotNull, NotZero]out int advance);

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
        [return: NotNull, NotZero]
        public static int TtfGlyphMetrics32([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull, NotZero]out int minx, [NotNull, NotZero]out int max, [NotNull, NotZero]out int miny, [NotNull, NotZero]out int maxy, [NotNull, NotZero]out int advance) => TTF_GlyphMetrics32(font, ch, out minx, out max, out miny, out maxy, out advance);

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_SizeText([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero] out int w, [NotNull, NotZero] out int h);

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfSizeText([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]out int w, [NotNull, NotZero]out int h) => TTF_SizeText(font.Validate(), text.Validate(), out w, out h);

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int INTERNAL_TTF_SizeUTF8([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull, NotZero]out int w, [NotNull, NotZero]out int h);

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        private static int InternalTtfSizeUtf8([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull, NotZero]out int w, [NotNull, NotZero]out int h) => INTERNAL_TTF_SizeUTF8(font.Validate(), text.Validate(), out w, out h);

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_SizeUNICODE([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]out int w, [NotNull, NotZero]out int h);

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfSizeUnicode([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]out int w, [NotNull, NotZero]out int h) => TTF_SizeUNICODE(font, text, out w, out h);

        /// <summary>
        ///     Ttf the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_MeasureText([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count);

        /// <summary>
        ///     Ttf the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfMeasureText([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero] int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count) => TTF_MeasureText(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Internals the ttf measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_MeasureUTF8", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int INTERNAL_TTF_MeasureUTF8([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull, NotZero]int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count);

        /// <summary>
        ///     Internals the ttf measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        private static int InternalTtfMeasureUtf8([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull, NotZero]int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count) => INTERNAL_TTF_MeasureUTF8(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Ttf the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_MeasureUNICODE([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count);

        /// <summary>
        ///     Ttf the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfMeasureUnicode([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull, NotZero]int measureWidth, [NotNull, NotZero]out int extent, [NotNull, NotZero]out int count) => TTF_MeasureUNICODE(font, text, measureWidth, out extent, out count);

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Solid([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextSolid([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg) => TTF_RenderText_Solid(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8Solid([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg) => INTERNAL_TTF_RenderUTF8_Solid(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Solid([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeSolid([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg) => TTF_RenderUNICODE_Solid(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Solid_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty] string text, SdlColor fg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Ttf the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextSolidWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapLength) => TTF_RenderText_Solid_Wrapped(font.Validate(), text.Validate(), fg, wrapLength.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8SolidWrapped([NotNull]IntPtr font,[NotNull, NotEmpty] byte[] text, [NotNull]SdlColor fg,[NotNull, NotZero]uint wrapLength) => INTERNAL_TTF_RenderUTF8_Solid_Wrapped(font.Validate(), text.Validate(), fg.Validate(), wrapLength.Validate());

        /// <summary>
        ///     Ttf the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Solid_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Ttf the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeSolidWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg,[NotNull, NotZero] uint wrapLength) => TTF_RenderUNICODE_Solid_Wrapped(font.Validate(), text.Validate(), fg.Validate(), wrapLength.Validate());

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph_Solid([NotNull]IntPtr font, [NotNull, NotZero]ushort ch, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyphSolid([NotNull]IntPtr font, [NotNull, NotZero]ushort ch, [NotNull]SdlColor fg) => TTF_RenderGlyph_Solid(font.Validate(), ch.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph32_Solid([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyph32Solid([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull]SdlColor fg) => TTF_RenderGlyph32_Solid(font.Validate(), ch.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Shaded([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg);

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextShaded([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg) => TTF_RenderText_Shaded(font.Validate(), text.Validate(), fg.Validate(), bg.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg, [NotNull]SdlColor bg);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8Shaded([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg, [NotNull]SdlColor bg) => INTERNAL_TTF_RenderUTF8_Shaded(font.Validate(), text.Validate(), fg.Validate(), bg.Validate());

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Shaded([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg);

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeShaded([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg) => TTF_RenderUNICODE_Shaded(font.Validate(), text.Validate(), fg.Validate(), bg.Validate());

        /// <summary>
        ///     Ttf the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Shaded_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg, SdlColor bg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Ttf the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextShadedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg, [NotNull, NotZero]uint wrapLength) => TTF_RenderText_Shaded_Wrapped(font.Validate(), text.Validate(), fg.Validate(), bg.Validate(), wrapLength.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg, [NotNull]SdlColor bg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8ShadedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg,[NotNull] SdlColor bg, [NotNull, NotZero]uint wrapLength) => INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(font.Validate(), text.Validate(), fg.Validate(), bg.Validate(), wrapLength.Validate());

        /// <summary>
        ///     Ttf the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Shaded_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg,[NotNull] SdlColor bg, [NotNull, NotZero]uint wrapLength);

        /// <summary>
        ///     Ttf the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeShadedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg, [NotNull, NotZero]uint wrapLength) => TTF_RenderUNICODE_Shaded_Wrapped(font.Validate(), text.Validate(), fg.Validate(), bg.Validate(), wrapLength.Validate());

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph_Shaded([NotNull]IntPtr font, [NotNull, NotZero]ushort ch, [NotNull]SdlColor fg, [NotNull]SdlColor bg);

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyphShaded([NotNull]IntPtr font, [NotNull, NotZero]ushort ch, [NotNull]SdlColor fg,[NotNull] SdlColor bg) => TTF_RenderGlyph_Shaded(font.Validate(), ch.Validate(), fg.Validate(), bg.Validate());

        /// <summary>
        ///     Ttf the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph32_Shaded([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull]SdlColor fg, [NotNull]SdlColor bg);

        /// <summary>
        ///     Ttf the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyph32Shaded([NotNull]IntPtr font, [NotNull, NotZero]uint ch, [NotNull]SdlColor fg, [NotNull]SdlColor bg) => TTF_RenderGlyph32_Shaded(font.Validate(), ch.Validate(), fg.Validate(), bg.Validate());

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Blended([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextBlended([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg) => TTF_RenderText_Blended(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8Blended([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg) => INTERNAL_TTF_RenderUTF8_Blended(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Blended([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg);

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeBlended([NotNull]IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg) => TTF_RenderUNICODE_Blended(font.Validate(), text.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderText_Blended_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapped);

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderTextBlendedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapped) => TTF_RenderText_Blended_Wrapped(font.Validate(), text.Validate(), fg.Validate(), wrapped.Validate());

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]byte[] text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapped);

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="sdlColor">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        private static IntPtr InternalTtfRenderUtf8BlendedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty] byte[] text, [NotNull] SdlColor sdlColor, [NotNull, NotZero] uint wrapped) => INTERNAL_TTF_RenderUTF8_Blended_Wrapped(font.Validate(), text.Validate(), sdlColor.Validate(), wrapped.Validate());

        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapped);

        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUnicodeBlendedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapped) => TTF_RenderUNICODE_Blended_Wrapped(font.Validate(), text.Validate(), fg.Validate(), wrapped.Validate());

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph_Blended([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull] SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyphBlended([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull] SdlColor fg) => TTF_RenderGlyph_Blended(font.Validate(), ch.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr TTF_RenderGlyph32_Blended([NotNull] IntPtr font, [NotNull, NotZero] uint ch, [NotNull] SdlColor fg);

        /// <summary>
        ///     Ttf the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr TtfRenderGlyph32Blended([NotNull] IntPtr font, [NotNull] uint ch, [NotNull] SdlColor fg) => TTF_RenderGlyph32_Blended(font.Validate(), ch.Validate(), fg.Validate());

        /// <summary>
        ///     Ttf the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_SetDirection([NotNull, NotZero] int direction);

        /// <summary>
        ///     Ttf the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfSetDirection([NotNull, NotZero] int direction) => TTF_SetDirection(direction.Validate());

        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_SetScript([NotNull, NotZero] int script);

        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfSetScript([NotNull, NotZero] int script) => TTF_SetScript(script.Validate());

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void TTF_CloseFont([NotNull] IntPtr font);

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        public static void TtfCloseFont([NotNull] IntPtr font) => TTF_CloseFont(font.Validate());

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern void TTF_Quit();

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [return: NotNull, NotZero]
        public static void TtfQuit() => TTF_Quit();

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int TTF_WasInit();

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int TtfWasInit() => TTF_WasInit();

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero]
        private static extern int SDL_GetFontKerningSize([NotNull] IntPtr font, [NotNull, NotZero] int prevIndex, [NotNull, NotZero] int index);

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        public static int SdlGetFontKerningSize([NotNull] IntPtr font, [NotNull, NotZero] int prevIndex, [NotNull, NotZero] int index) => SDL_GetFontKerningSize(font.Validate(), prevIndex.Validate(), index.Validate());

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero] 
        private static extern int TTF_GetFontKerningSizeGlyphs([NotNull] IntPtr font, [NotNull, NotZero] ushort previousCh, [NotNull, NotZero] ushort ch);

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero] 
        public static int TtfGetFontKerningSizeGlyphs([NotNull] IntPtr font, [NotNull, NotZero]  ushort previousCh, [NotNull, NotZero] ushort ch) => TTF_GetFontKerningSizeGlyphs(font.Validate(), previousCh.Validate(), ch.Validate());

        /// <summary>
        ///     Ttf the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull, NotZero] 
        private static extern int TTF_GetFontKerningSizeGlyphs32([NotNull] IntPtr font, [NotNull, NotZero] ushort previousCh, [NotNull, NotZero] ushort ch);

        /// <summary>
        ///     Ttf the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero] 
        public static int TtfGetFontKerningSizeGlyphs32([NotNull] IntPtr font, [NotNull, NotZero] ushort previousCh, [NotNull, NotZero] ushort ch) => TTF_GetFontKerningSizeGlyphs32(font.Validate(), previousCh.Validate(), ch.Validate());
        
        /// <summary>
        ///     Ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        public static IntPtr TtfOpenFont([NotNull, NotEmpty]string file, [NotNull, NotZero]int ptSize)
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = TtfOpenFont(
                utf8File,
                ptSize
            );

            return handle;
        }

        /// <summary>
        ///     Ttf the render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUtf8BlendedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapped)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8BlendedWrapped(
                font,
                utf8Text,
                fg,
                wrapped
            );

            return result;
        }

        /// <summary>
        ///     Ttf the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull, NotEmpty]
        public static string TtfGetError() => Sdl.SDL_GetError();

        /// <summary>
        ///     Ttf the set error using the specified fmt and arg
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg</param>
        [return: NotNull]
        public static void TtfSetError([NotNull][NotEmpty]string fmtAndArgList) => Sdl.SDL_SetError(fmtAndArgList.Validate());

        /// <summary>
        ///     Ttf the render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUtf8Blended([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8Blended(
                font,
                utf8Text,
                fg
            );

            return result;
        }

        /// <summary>
        ///     Ttf the render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUtf8ShadedWrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg, [NotNull]uint wrapLength)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8ShadedWrapped(
                font,
                utf8Text,
                fg,
                bg,
                wrapLength
            );

            return result;
        }

        /// <summary>
        ///     Ttf the render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUtf8Shaded([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull]SdlColor bg)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8Shaded(
                font,
                utf8Text,
                fg,
                bg
            );

            return result;
        }

        /// <summary>
        ///     Ttf the render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TTF_RenderUTF8_Solid_Wrapped([NotNull]IntPtr font, [NotNull, NotEmpty]string text, [NotNull]SdlColor fg, [NotNull, NotZero]uint wrapLength)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8SolidWrapped(
                font,
                utf8Text,
                fg,
                wrapLength
            );

            return result;
        }

        /// <summary>
        ///     Ttf the render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static IntPtr TtfRenderUtf8Solid([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull]SdlColor fg)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = InternalTtfRenderUtf8Solid(
                font,
                utf8Text,
                fg
            );

            return result;
        }

        /// <summary>
        ///     Ttf the measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int TtfMeasureUtf8([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] int measureWidth, [NotNull] out int extent, [NotNull] out int count)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = InternalTtfMeasureUtf8(
                font,
                utf8Text,
                measureWidth,
                out extent,
                out count
            );

            return result;
        }

        /// <summary>
        ///     Ttf the size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int TtfSizeUtf8([NotNull] IntPtr font, [NotNull, NotEmpty]string text, [NotNull]out int w, [NotNull]out int h)
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = InternalTtfSizeUtf8(
                font,
                utf8Text,
                out w,
                out h
            );

            return result;
        }

        /// <summary>
        ///     Ttf the font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        [return: NotNull]
        public static string TtfFontFaceStyleName([NotNull]IntPtr font) => Sdl.UTF8_ToManaged(InternalTtfFontFaceStyleName(font.Validate()));

        /// <summary>
        ///     Ttf the open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        public static IntPtr TTF_OpenFontIndex(string file, int ptSize, long index)
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = InternalTtfOpenFontIndex(
                utf8File,
                ptSize,
                index
            );

            return handle;
        }

        /// <summary>
        ///     Ttf the linked version
        /// </summary>
        /// <returns>The result</returns>
        [return: NotNull]
        public static SdlVersion TtfLinkedVersion()
        {
            IntPtr resultPtr = InternalTtfLinkedVersion();
            SdlVersion result = (SdlVersion) Marshal.PtrToStructure(
                resultPtr,
                typeof(SdlVersion)
            );
            return result;
        }

        /// <summary>
        ///     Sdl the ttf version using the specified x
        /// </summary>
        [return: NotNull]
        public static SdlVersion SdlTtfVersion() => new SdlVersion(SdlTtfMajorVersion, SdlTtfMinorVersion, SdlTtfPatchLevel);
    }
}