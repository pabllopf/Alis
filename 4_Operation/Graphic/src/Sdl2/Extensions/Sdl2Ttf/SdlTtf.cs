// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlTtf.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    ///     The sdl ttf extern class
    /// </summary>
    public static class SdlTtf 
    {
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
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LinkedVersion()
        {
            IntPtr result = NativeSdlTtf.InternalLinkedVersion();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ByteSwappedUnicode([NotNull, NotZero] int swapped)
        {
            Validator.ValidateInput(swapped);
            NativeSdlTtf.InternalByteSwappedUnicode(swapped);
        }

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <exception cref="Exception">InternalInit failed</exception>
        /// <returns>The result</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init()
        {
            int result = NativeSdlTtf.InternalInit();
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFontIndex([NotNull, NotEmpty] string file, [NotNull, NotZero] int ptSize, [NotNull, NotZero] long index)
        {
            Validator.ValidateInput(file);
            Validator.ValidateInput(ptSize);
            Validator.ValidateInput(index);
            IntPtr result = NativeSdlTtf.InternalOpenFontIndex(file, ptSize, index);
            Validator.ValidateOutput(result);
            return result;
        }
        
        /// <summary>
        ///     Ttf the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetFontSize([NotNull] IntPtr font, [NotNull, NotZero] int ptSize)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ptSize);
            int result = NativeSdlTtf.InternalSetFontSize(font, ptSize);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontStyle([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalGetFontStyle(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontStyle([NotNull] IntPtr font, [NotNull, NotZero] int style)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(style);
            NativeSdlTtf.InternalSetFontStyle(font, style);
        }

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontOutline([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalGetFontOutline(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontOutline([NotNull] IntPtr font, [NotNull, NotZero] int outline)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(outline);
            NativeSdlTtf.InternalSetFontOutline(font, outline);
        }

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontHinting([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalGetFontHinting(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontHinting([NotNull] IntPtr font, [NotNull, NotZero] int hinting)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(hinting);
            NativeSdlTtf.InternalSetFontHinting(font, hinting);
        }

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontHeight([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalFontHeight(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontAscent([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalFontAscent(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontDescent([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalFontDescent(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontLineSkip([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalFontLineSkip(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerning([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalGetFontKerning(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontKerning([NotNull] IntPtr font, [NotNull, NotZero] int allowed)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(allowed);
            NativeSdlTtf.InternalSetFontKerning(font, allowed);
        }

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr FontFaces([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            IntPtr result = NativeSdlTtf.InternalFontFaces(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontFaceIsFixedWidth([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            int result = NativeSdlTtf.InternalFontFaceIsFixedWidth(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FontFaceStyleName([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            string result = NativeSdlTtf.InternalFontFaceStyleName(font);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphIsProvided(IntPtr font, ushort ch)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGlyphIsProvided(font, ch);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphIsProvided32([NotNull] IntPtr font, [NotNull, NotZero] uint ch)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGlyphIsProvided32(font, ch);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphMetrics([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull, NotZero] out int minx, [NotNull, NotZero] out int max, [NotNull, NotZero] out int miny, [NotNull, NotZero] out int maxy, [NotNull, NotZero] out int advance)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGlyphMetrics(font, ch, out minx, out max, out miny, out maxy, out advance);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphMetrics32([NotNull] IntPtr font, [NotNull, NotZero] uint ch, [NotNull, NotZero] out int minx, [NotNull, NotZero] out int max, [NotNull, NotZero] out int miny, [NotNull, NotZero] out int maxy, [NotNull, NotZero] out int advance)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGlyphMetrics32(font, ch, out minx, out max, out miny, out maxy, out advance);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeText([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] out int w, [NotNull, NotZero] out int h)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            int result = NativeSdlTtf.InternalSizeText(font, text, out w, out h);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUtf8([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] out int w, [NotNull, NotZero] out int h)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            int result = NativeSdlTtf.InternalSizeUTF8(font, text, out w, out h);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUnicode([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] out int w, [NotNull, NotZero] out int h)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            int result = NativeSdlTtf.InternalSizeUnicode(font, text, out w, out h);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MeasureText([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] int measureWidth, [NotNull, NotZero] out int extent, [NotNull, NotZero] out int count)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(measureWidth);
            int result = NativeSdlTtf.InternalMeasureText(font, text, measureWidth, out extent, out count);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MeasureUtf8([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] int measureWidth, [NotNull, NotZero] out int extent, [NotNull, NotZero] out int count)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(measureWidth);
            int result = NativeSdlTtf.InternalMeasureUTF8(font, text, measureWidth, out extent, out count);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int MeasureUnicode([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull, NotZero] int measureWidth, [NotNull, NotZero] out int extent, [NotNull, NotZero] out int count)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(measureWidth);
            int result = NativeSdlTtf.InternalMeasureUNICODE(font, text, measureWidth, out extent, out count);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextSolid([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderText_Solid(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Solid([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderUTF8_Solid(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeSolid([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderUNICODE_Solid(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextSolidWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderTextSolidWrapped(font, text, fg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeSolidWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeSolidWrapped(font, text, fg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphSolid([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph_Solid(font, ch, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyph32Solid([NotNull] IntPtr font, [NotNull, NotZero] uint ch, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph32_Solid(font, ch, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextShaded([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            IntPtr result = NativeSdlTtf.InternalRenderText_Shaded(font, text, fg, bg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Shaded([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            IntPtr result = NativeSdlTtf.InternalRenderUTF8_Shaded(font, text, fg, bg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeShaded([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            IntPtr result = NativeSdlTtf.InternalRenderUNICODE_Shaded(font, text, fg, bg);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextShadedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderText_Shaded_Wrapped(font, text, fg, bg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8ShadedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderUTF8_Shaded_Wrapped(font, text, fg, bg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeShadedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull] SdlColor bg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderUNICODE_Shaded_Wrapped(font, text, fg, bg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphShaded([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull] SdlColor fg, [NotNull] SdlColor bg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph_Shaded(font, ch, fg, bg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyph32Shaded([NotNull] IntPtr font, [NotNull, NotZero] uint ch, [NotNull] SdlColor fg, [NotNull] SdlColor bg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(bg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph32_Shaded(font, ch, fg, bg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlended([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderText_Blended(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlended([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlended(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlendedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapped)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(wrapped);
            IntPtr result = NativeSdlTtf.InternalRenderTextBlendedWrapped(font, text, fg, wrapped);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="sdlColor">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8BlendedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor sdlColor, [NotNull, NotZero] uint wrapped)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(sdlColor);
            Validator.ValidateInput(wrapped);
            IntPtr result = NativeSdlTtf.InternalRenderUTF8_Blended_Wrapped(font, text, sdlColor, wrapped);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlendedWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapped)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(wrapped);
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlendedWrapped(font, text, fg, wrapped);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphBlended([NotNull] IntPtr font, [NotNull, NotZero] ushort ch, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph_Blended(font, ch, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyph32Blended([NotNull] IntPtr font, [NotNull] uint ch, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(ch);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderGlyph32_Blended(font, ch, fg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetDirection([NotNull, NotZero] int direction)
        {
            Validator.ValidateInput(direction);
            int result = NativeSdlTtf.InternalSetDirection(direction);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SetScript([NotNull, NotZero] int script)
        {
            Validator.ValidateInput(script);
            int result = NativeSdlTtf.InternalSetScript(script);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseFont([NotNull] IntPtr font)
        {
            Validator.ValidateInput(font);
            NativeSdlTtf.InternalCloseFont(font);
        }

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit()
        {
            NativeSdlTtf.InternalQuit();
        }

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WasInit()
        {
            int result = NativeSdlTtf.InternalWasInit();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSize([NotNull] IntPtr font, [NotNull, NotZero] int prevIndex, [NotNull, NotZero] int index)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(prevIndex);
            Validator.ValidateInput(index);
            int result = NativeSdlTtf.InternalGetFontKerningSize(font, prevIndex, index);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSizeGlyphs([NotNull] IntPtr font, [NotNull, NotZero] ushort previousCh, [NotNull, NotZero] ushort ch)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(previousCh);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGetFontKerningSizeGlyphs(font, previousCh, ch);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: NotNull, NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSizeGlyphs32([NotNull] IntPtr font, [NotNull, NotZero] ushort previousCh, [NotNull, NotZero] ushort ch)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(previousCh);
            Validator.ValidateInput(ch);
            int result = NativeSdlTtf.InternalGetFontKerningSizeGlyphs32(font, previousCh, ch);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFont([NotNull, NotEmpty] string file, [NotNull, NotZero] int ptSize)
        {
            Validator.ValidateInput(file);
            Validator.ValidateInput(ptSize);
            IntPtr result = NativeSdlTtf.InternalOpenFont(file, ptSize);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull, NotEmpty]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Sdl.GetError();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Ttf the set error using the specified fmt and arg
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg</param>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError([NotNull, NotEmpty] string fmtAndArgList)
        {
            Validator.ValidateInput(fmtAndArgList);
            Sdl.SetError(fmtAndArgList);
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
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8SolidWrapped([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg, [NotNull, NotZero] uint wrapLength)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            Validator.ValidateInput(wrapLength);
            IntPtr result = NativeSdlTtf.InternalRenderUtf8SolidWrapped(font, text, fg, wrapLength);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Sdl the ttf version using the specified x
        /// </summary>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion GetTtfVersion()
        {
            SdlVersion result = NativeSdlTtf.InternalGetTtfVersion();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Blended([NotNull] IntPtr font, [NotNull, NotEmpty] string text, [NotNull] SdlColor fg)
        {
            Validator.ValidateInput(font);
            Validator.ValidateInput(text);
            Validator.ValidateInput(fg);
            IntPtr result = NativeSdlTtf.InternalRenderUtf8Blended(font, text, fg);
            Validator.ValidateOutput(result);
            return result;
        }
    }
}