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
using Alis.Core.Aspect.Math.Definition;
using Version = Alis.Extension.Graphic.Sdl2.Structs.Version;

namespace Alis.Extension.Graphic.Sdl2.Sdl2Ttf
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void ByteSwappedUnicode( int swapped)
        {
            
            NativeSdlTtf.InternalByteSwappedUnicode(swapped);
        }

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <exception cref="Exception">InternalInit failed</exception>
        /// <returns>The result</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init()
        {
            int result = NativeSdlTtf.InternalInit();
            
            return result;
        }

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFontIndex( string file,  int ptSize,  long index)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalOpenFontIndex(file, ptSize, index);
            
            return result;
        }

        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontStyle( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalGetFontStyle(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontStyle( IntPtr font,  int style)
        {
            
            
            NativeSdlTtf.InternalSetFontStyle(font, style);
        }

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontOutline( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalGetFontOutline(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontOutline( IntPtr font,  int outline)
        {
            
            
            NativeSdlTtf.InternalSetFontOutline(font, outline);
        }

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontHinting( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalGetFontHinting(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontHinting( IntPtr font,  int hinting)
        {
            
            
            NativeSdlTtf.InternalSetFontHinting(font, hinting);
        }

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontHeight( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalFontHeight(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontAscent( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalFontAscent(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontDescent( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalFontDescent(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontLineSkip( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalFontLineSkip(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerning( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalGetFontKerning(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetFontKerning( IntPtr font,  int allowed)
        {
            
            
            NativeSdlTtf.InternalSetFontKerning(font, allowed);
        }

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr FontFaces( IntPtr font)
        {
            
            IntPtr result = NativeSdlTtf.InternalFontFaces(font);
            
            return result;
        }

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int FontFaceIsFixedWidth( IntPtr font)
        {
            
            int result = NativeSdlTtf.InternalFontFaceIsFixedWidth(font);
            
            return result;
        }

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string FontFaceStyleName( IntPtr font)
        {
            
            string result = Marshal.PtrToStringAnsi(NativeSdlTtf.InternalFontFaceStyleName(font));
            
            return result;
        }

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphIsProvided(IntPtr font, ushort ch)
        {
            
            
            int result = NativeSdlTtf.InternalGlyphIsProvided(font, ch);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GlyphMetrics( IntPtr font,  ushort ch,  out int minx,  out int max,  out int miny,  out int maxy,  out int advance)
        {
            
            
            int result = NativeSdlTtf.InternalGlyphMetrics(font, ch, out minx, out max, out miny, out maxy, out advance);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeText( IntPtr font,  string text,  out int w,  out int h)
        {
            
            
            int result = NativeSdlTtf.InternalSizeText(font, text, out w, out h);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUtf8( IntPtr font,  string text,  out int w,  out int h)
        {
            
            
            int result = NativeSdlTtf.InternalSizeUTF8(font, text, out w, out h);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SizeUnicode( IntPtr font,  string text,  out int w,  out int h)
        {
            
            
            int result = NativeSdlTtf.InternalSizeUnicode(font, text, out w, out h);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextSolid( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderTextSolid(font, text, fg);
            
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Solid( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUTF8Solid(font, text, fg);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeSolid( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeSolid(font, text, fg);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphSolid( IntPtr font,  ushort ch,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderGlyphSolid(font, ch, fg);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextShaded( IntPtr font,  string text,  Color fg,  Color bg)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderTextShaded(font, text, fg, bg);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Shaded( IntPtr font,  string text,  Color fg,  Color bg)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUtf8Shaded(font, text, fg, bg);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeShaded( IntPtr font,  string text,  Color fg,  Color bg)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeShaded(font, text, fg, bg);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphShaded( IntPtr font,  ushort ch,  Color fg,  Color bg)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderGlyphShaded(font, ch, fg, bg);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlended( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderTextBlended(font, text, fg);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlended( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlended(font, text, fg);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderTextBlendedWrapped( IntPtr font,  string text,  Color fg,  uint wrapped)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderTextBlendedWrapped(font, text, fg, wrapped);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8BlendedWrapped( IntPtr font,  string text,  Color sdlColor,  uint wrapped)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUtf8BlendedWrapped(font, text, sdlColor, wrapped);
            
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
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUnicodeBlendedWrapped( IntPtr font,  string text,  Color fg,  uint wrapped)
        {
            
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUnicodeBlendedWrapped(font, text, fg, wrapped);
            
            return result;
        }

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderGlyphBlended( IntPtr font,  ushort ch,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderGlyphBlended(font, ch, fg);
            
            return result;
        }

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void CloseFont( IntPtr font)
        {
            
            NativeSdlTtf.InternalCloseFont(font);
        }

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit()
        {
            NativeSdlTtf.InternalQuit();
        }

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int WasInit()
        {
            int result = NativeSdlTtf.InternalWasInit();
            
            return result;
        }

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSize( IntPtr font,  int prevIndex,  int index)
        {
            
            
            
            int result = NativeSdlTtf.InternalGetFontKerningSize(font, prevIndex, index);
            
            return result;
        }

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int GetFontKerningSizeGlyphs( IntPtr font,  ushort previousCh,  ushort ch)
        {
            
            
            
            int result = NativeSdlTtf.InternalGetFontKerningSizeGlyphs(font, previousCh, ch);
            
            return result;
        }

        /// <summary>
        ///     Ttf the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The pt size</param>
        /// <returns>The handle</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr OpenFont( string file,  int ptSize)
        {
            
            
            IntPtr result = NativeSdlTtf.InternalOpenFont(file, ptSize);
            
            return result;
        }

        /// <summary>
        ///     Ttf the get error
        /// </summary>
        /// <returns>The string</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static string GetError()
        {
            string result = Sdl.GetError();
            
            return result;
        }

        /// <summary>
        ///     Ttf the set error using the specified fmt and arg
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg</param>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void SetError( string fmtAndArgList)
        {
            
            Sdl.SetError(fmtAndArgList);
        }

        /// <summary>
        ///     Sdl the ttf version using the specified x
        /// </summary>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static Version GetVersion()
        {
            Version result = NativeSdlTtf.InternalGetTtfVersion();
            
            return result;
        }

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr RenderUtf8Blended( IntPtr font,  string text,  Color fg)
        {
            
            
            
            IntPtr result = NativeSdlTtf.InternalRenderUtf8Blended(font, text, fg);
            
            return result;
        }
    }
}