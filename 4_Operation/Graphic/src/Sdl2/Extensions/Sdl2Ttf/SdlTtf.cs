// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlTtf.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Sdl2.Structs;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

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
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ByteSwappedUnicode([IsNotNull] int swapped)
        {
            Validator.Validate(swapped, nameof(swapped));
            NativeSdlTtf.InternalByteSwappedUnicode(swapped);
        }
        
        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <exception cref="Exception">InternalInit failed</exception>
        /// <returns>The result</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init()
        {
            int result = NativeSdlTtf.InternalInit();
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFontIndex([IsNotNull, IsNotEmpty] string file, [IsNotNull] int ptSize, [IsNotNull] long index)
        {
            Validator.Validate(file, nameof(file));
            Validator.Validate(ptSize, nameof(ptSize));
            Validator.Validate(index, nameof(index));
            IntPtr result = NativeSdlTtf.InternalOpenFontIndex(file, ptSize, index);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontStyle([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalGetFontStyle(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontStyle([IsNotNull] IntPtr font, [IsNotNull] int style)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(style, nameof(style));
            NativeSdlTtf.InternalSetFontStyle(font, style);
        }
        
        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontOutline([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalGetFontOutline(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontOutline([IsNotNull] IntPtr font, [IsNotNull] int outline)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(outline, nameof(outline));
            NativeSdlTtf.InternalSetFontOutline(font, outline);
        }
        
        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontHinting([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalGetFontHinting(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontHinting([IsNotNull] IntPtr font, [IsNotNull] int hinting)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(hinting, nameof(hinting));
            NativeSdlTtf.InternalSetFontHinting(font, hinting);
        }
        
        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontHeight([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalFontHeight(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontAscent([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalFontAscent(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontDescent([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalFontDescent(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontLineSkip([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalFontLineSkip(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerning([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalGetFontKerning(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontKerning([IsNotNull] IntPtr font, [IsNotNull] int allowed)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(allowed, nameof(allowed));
            NativeSdlTtf.InternalSetFontKerning(font, allowed);
        }
        
        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr FontFaces([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            IntPtr result = NativeSdlTtf.InternalFontFaces(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontFaceIsFixedWidth([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            int result = NativeSdlTtf.InternalFontFaceIsFixedWidth(font);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FontFaceStyleName([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            string result = Marshal.PtrToStringAnsi(NativeSdlTtf.InternalFontFaceStyleName(font));
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphIsProvided(IntPtr font, ushort ch)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(ch, nameof(ch));
            int result = NativeSdlTtf.InternalGlyphIsProvided(font, ch);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphMetrics([IsNotNull] IntPtr font, [IsNotNull] ushort ch, [IsNotNull] out int minx, [IsNotNull] out int max, [IsNotNull] out int miny, [IsNotNull] out int maxy, [IsNotNull] out int advance)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(ch, nameof(ch));
            int result = NativeSdlTtf.InternalGlyphMetrics(font, ch, out minx, out max, out miny, out maxy, out advance);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeText([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] out int w, [IsNotNull] out int h)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            int result = NativeSdlTtf.InternalSizeText(font, text, out w, out h);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUtf8([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] out int w, [IsNotNull] out int h)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            int result = NativeSdlTtf.InternalSizeUTF8(font, text, out w, out h);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUnicode([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] out int w, [IsNotNull] out int h)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            int result = NativeSdlTtf.InternalSizeUnicode(font, text, out w, out h);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextSolid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderTextSolid(font, text, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Solid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderUTF8Solid(font, text, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeSolid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeSolid(font, text, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphSolid([IsNotNull] IntPtr font, [IsNotNull] ushort ch, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(ch, nameof(ch));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderGlyphSolid(font, ch, fg);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextShaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg, [IsNotNull] Color bg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(bg, nameof(bg));
            IntPtr result = NativeSdlTtf.InternalRenderTextShaded(font, text, fg, bg);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Shaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg, [IsNotNull] Color bg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(bg, nameof(bg));
            IntPtr result = NativeSdlTtf.InternalRenderUtf8Shaded(font, text, fg, bg);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeShaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg, [IsNotNull] Color bg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(bg, nameof(bg));
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeShaded(font, text, fg, bg);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphShaded([IsNotNull] IntPtr font, [IsNotNull] ushort ch, [IsNotNull] Color fg, [IsNotNull] Color bg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(ch, nameof(ch));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(bg, nameof(bg));
            IntPtr result = NativeSdlTtf.InternalRenderGlyphShaded(font, ch, fg, bg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderTextBlended(font, text, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlended(font, text, fg);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg, [IsNotNull] uint wrapped)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(wrapped, nameof(wrapped));
            IntPtr result = NativeSdlTtf.InternalRenderTextBlendedWrapped(font, text, fg, wrapped);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8BlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color sdlColor, [IsNotNull] uint wrapped)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(sdlColor, nameof(sdlColor));
            Validator.Validate(wrapped, nameof(wrapped));
            IntPtr result = NativeSdlTtf.InternalRenderUtf8BlendedWrapped(font, text, sdlColor, wrapped);
            Validator.Validate(result, nameof(result));
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
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg, [IsNotNull] uint wrapped)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            Validator.Validate(wrapped, nameof(wrapped));
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlendedWrapped(font, text, fg, wrapped);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphBlended([IsNotNull] IntPtr font, [IsNotNull] ushort ch, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(ch, nameof(ch));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderGlyphBlended(font, ch, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseFont([IsNotNull] IntPtr font)
        {
            Validator.Validate(font, nameof(font));
            NativeSdlTtf.InternalCloseFont(font);
        }
        
        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit()
        {
            NativeSdlTtf.InternalQuit();
        }
        
        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WasInit()
        {
            int result = NativeSdlTtf.InternalWasInit();
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSize([IsNotNull] IntPtr font, [IsNotNull] int prevIndex, [IsNotNull] int index)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(prevIndex, nameof(prevIndex));
            Validator.Validate(index, nameof(index));
            int result = NativeSdlTtf.InternalGetFontKerningSize(font, prevIndex, index);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSizeGlyphs([IsNotNull] IntPtr font, [IsNotNull] ushort previousCh, [IsNotNull] ushort ch)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(previousCh, nameof(previousCh));
            Validator.Validate(ch, nameof(ch));
            int result = NativeSdlTtf.InternalGetFontKerningSizeGlyphs(font, previousCh, ch);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The handle</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFont([IsNotNull, IsNotEmpty] string file, [IsNotNull] int ptSize)
        {
            Validator.Validate(file, nameof(file));
            Validator.Validate(ptSize, nameof(ptSize));
            IntPtr result = NativeSdlTtf.InternalOpenFont(file, ptSize);
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: IsNotNull, IsNotEmpty]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Sdl.GetError();
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Ttf the set error using the specified fmt and arg
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg</param>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError([IsNotNull, IsNotEmpty] string fmtAndArgList)
        {
            Validator.Validate(fmtAndArgList, nameof(fmtAndArgList));
            Sdl.SetError(fmtAndArgList);
        }
        
        /// <summary>
        ///     Sdl the ttf version using the specified x
        /// </summary>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Version GetVersion()
        {
            Version result = NativeSdlTtf.InternalGetTtfVersion();
            Validator.Validate(result, nameof(result));
            return result;
        }
        
        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [return: IsNotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Blended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty] string text, [IsNotNull] Color fg)
        {
            Validator.Validate(font, nameof(font));
            Validator.Validate(text, nameof(text));
            Validator.Validate(fg, nameof(fg));
            IntPtr result = NativeSdlTtf.InternalRenderUtf8Blended(font, text, fg);
            Validator.Validate(result, nameof(result));
            return result;
        }
    }
}