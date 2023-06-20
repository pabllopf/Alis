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
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Graphic.SDL.Extern
{
    /// <summary>
    ///     The sdl ttf extern class
    /// </summary>
    public class SdlTtfExtern
    {
        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_ByteSwappedUNICODE(int swapped);

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_Init();

        /// <summary>
        ///     Internals the ttf open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_TTF_OpenFont(
            byte[] file,
            int ptSize
        );

        /// <summary>
        ///     Ttf the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The freeSrc</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontRW(
            IntPtr src,
            int freeSrc,
            int ptSize
        );

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_OpenFontIndex(
            byte[] file,
            int ptsize,
            long index
        );

        /// <summary>
        ///     Ttfs the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontIndexRW(
            IntPtr src,
            int freesrc,
            int ptsize,
            long index
        );

        /// <summary>
        ///     Ttfs the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetFontSize(
            IntPtr font,
            int ptsize
        );

        /// <summary>
        ///     Ttfs the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontStyle(IntPtr font);

        /// <summary>
        ///     Ttfs the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontStyle(IntPtr font, int style);

        /// <summary>
        ///     Ttfs the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontOutline(IntPtr font);

        /// <summary>
        ///     Ttfs the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontOutline(IntPtr font, int outline);

        /// <summary>
        ///     Ttfs the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontHinting(IntPtr font);

        /// <summary>
        ///     Ttfs the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

        /// <summary>
        ///     Ttfs the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontHeight(IntPtr font);

        /// <summary>
        ///     Ttfs the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontAscent(IntPtr font);

        /// <summary>
        ///     Ttfs the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontDescent(IntPtr font);

        /// <summary>
        ///     Ttfs the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontLineSkip(IntPtr font);

        /// <summary>
        ///     Ttfs the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerning(IntPtr font);

        /// <summary>
        ///     Ttfs the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

        /// <summary>
        ///     Ttfs the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_FontFaces(IntPtr font);

        /// <summary>
        ///     Ttfs the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

        /// <summary>
        ///     Internals the ttf font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
            IntPtr font
        );

        /// <summary>
        ///     Ttfs the font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        public static string TTF_FontFaceFamilyName(IntPtr font) => Sdl.UTF8_ToManaged(INTERNAL_TTF_FontFaceFamilyName(font)
        );

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
            IntPtr font
        );

        /// <summary>
        ///     Ttfs the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

        /// <summary>
        ///     Ttfs the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphIsProvided32(IntPtr font, uint ch);

        /// <summary>
        ///     Ttfs the glyph metrics using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="maxx">The maxx</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics(
            IntPtr font,
            ushort ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );

        /// <summary>
        ///     Ttfs the glyph metrics 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="minx">The minx</param>
        /// <param name="maxx">The maxx</param>
        /// <param name="miny">The miny</param>
        /// <param name="maxy">The maxy</param>
        /// <param name="advance">The advance</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics32(
            IntPtr font,
            uint ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );

        /// <summary>
        ///     Ttfs the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeText(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            out int w,
            out int h
        );

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        public static extern int INTERNAL_TTF_SizeUTF8(
            IntPtr font,
            byte[] text,
            out int w,
            out int h
        );

        /// <summary>
        ///     Ttfs the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeUNICODE(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            out int w,
            out int h
        );

        /// <summary>
        ///     Ttfs the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_MeasureText(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            int measureWidth,
            out int extent,
            out int count
        );

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
        public static extern int INTERNAL_TTF_MeasureUTF8(
            IntPtr font,
            byte[] text,
            int measureWidth,
            out int extent,
            out int count
        );

        /// <summary>
        ///     Ttfs the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_MeasureUNICODE(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            int measureWidth,
            out int extent,
            out int count
        );

        /// <summary>
        ///     Ttfs the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg
        );

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid(
            IntPtr font,
            byte[] text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            uint wrapLength
        );

        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr INTERNAL_TTF_RenderUTF8_Solid_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Solid(
            IntPtr font,
            ushort ch,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Solid(
            IntPtr font,
            uint ch,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Ttfs the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Ttfs the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

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
        public static extern IntPtr INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Shaded(
            IntPtr font,
            ushort ch,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Ttfs the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Shaded(
            IntPtr font,
            uint ch,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Ttfs the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg
        );

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended(
            IntPtr font,
            byte[] text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            uint wrapped
        );

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        internal static extern IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            uint wrapped
        );

        /// <summary>
        ///     Ttfs the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            uint wrapped
        );

        /// <summary>
        ///     Ttfs the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Blended(
            IntPtr font,
            ushort ch,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Blended(
            IntPtr font,
            uint ch,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetDirection(int direction);

        /// <summary>
        ///     Ttfs the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetScript(int script);

        /// <summary>
        ///     Ttfs the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_CloseFont(IntPtr font);

        /// <summary>
        ///     Ttfs the quit
        /// </summary>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_Quit();

        /// <summary>
        ///     Ttfs the was init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_WasInit();

        /// <summary>
        ///     Sdls the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetFontKerningSize(
            IntPtr font,
            int prevIndex,
            int index
        );

        /// <summary>
        ///     Ttfs the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerningSizeGlyphs(
            IntPtr font,
            ushort previousCh,
            ushort ch
        );

        /// <summary>
        ///     Ttfs the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(SdlTtf.NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerningSizeGlyphs32(
            IntPtr font,
            ushort previousCh,
            ushort ch
        );
    }
}