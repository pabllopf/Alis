// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeSdlTtf.cs
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
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Data.Dll;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Properties;
using Alis.Core.Graphic.Sdl2.Structs;
using Version = Alis.Core.Graphic.Sdl2.Structs.Version;

namespace Alis.Core.Graphic.Sdl2.Extensions.Sdl2Ttf
{
    /// <summary>
    ///     The native sdl ttf class
    /// </summary>
    internal static class NativeSdlTtf
    {
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2_ttf";

        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlTtf" /> class
        /// </summary>
        static NativeSdlTtf() => new EmbeddedDllClass().ExtractEmbeddedDlls("sdl2_ttf", DllType.Lib, Sdl2Dlls.GlSdlTtfDllBytes, Assembly.GetAssembly(typeof(Sdl2Dlls)));

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
        [DllImport(NativeLibName, EntryPoint = "TTF_GlyphMetrics", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGlyphMetrics([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort ch, [IsNotNull, IsNotZero] out int minx, [IsNotNull, IsNotZero] out int max, [IsNotNull, IsNotZero] out int miny, [IsNotNull, IsNotZero] out int maxy, [IsNotNull, IsNotZero] out int advance);

        /// <summary>
        ///     Ttf the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SizeText", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalSizeText([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull, IsNotZero] out int w, [IsNotNull, IsNotZero] out int h);

        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SizeUTF8", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalSizeUTF8([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull, IsNotZero] out int w, [IsNotNull, IsNotZero] out int h);

        /// <summary>
        ///     Ttf the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SizeUNICODE", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalSizeUnicode([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull, IsNotZero] out int w, [IsNotNull, IsNotZero] out int h);

        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUtf8Shaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull] Color bg);

        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUtf8BlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull, IsNotZero] uint wrapped);

        /// <summary>
        ///     Ttf the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderText_Solid", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderTextSolid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUTF8Solid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Ttf the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUNICODE_Solid", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUnicodeSolid([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Ttf the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GlyphIsProvided", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGlyphIsProvided([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort ch);

        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalFontFaceStyleName([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceIsFixedWidth", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalFontFaceIsFixedWidth([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaces", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern IntPtr InternalFontFaces([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_SetFontKerning", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern void InternalSetFontKerning([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] int allowed);
        
        /// <summary>
        ///     Ttf the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderGlyph_Solid", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderGlyphSolid([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort ch, [IsNotNull] Color fg);

        /// <summary>
        ///     Ttf the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderText_Shaded", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderTextShaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull] Color bg);

        /// <summary>
        ///     Ttf the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUNICODE_Shaded", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUnicodeShaded([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull] Color bg);

        /// <summary>
        ///     Ttf the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderGlyph_Shaded", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderGlyphShaded([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort ch, [IsNotNull] Color fg, [IsNotNull] Color bg);

        /// <summary>
        ///     Ttf the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderText_Blended", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderTextBlended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUtf8Blended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Ttf the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUNICODE_Blended", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUnicodeBlended([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg);

        /// <summary>
        ///     Ttf the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderText_Blended_Wrapped", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderTextBlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull, IsNotZero] uint wrapped);

        /// <summary>
        ///     Ttf the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUNICODE_Blended_Wrapped", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderUnicodeBlendedWrapped([IsNotNull] IntPtr font, [IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string text, [IsNotNull] Color fg, [IsNotNull, IsNotZero] uint wrapped);

        /// <summary>
        ///     Ttf the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderGlyph_Blended", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalRenderGlyphBlended([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort ch, [IsNotNull] Color fg);
        
        /// <summary>
        ///     Ttf the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SetScript", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalSetScript([IsNotNull, IsNotZero] int script);

        /// <summary>
        ///     Ttf the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_CloseFont", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalCloseFont([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "TTF_Quit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern void InternalQuit();

        /// <summary>
        ///     Ttf the was init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_WasInit", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalWasInit();

        /// <summary>
        ///     Sdl the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontKerningSize", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontKerningSize([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] int prevIndex, [IsNotNull, IsNotZero] int index);

        /// <summary>
        ///     Ttf the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontKerningSizeGlyphs", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontKerningSizeGlyphs([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] ushort previousCh, [IsNotNull, IsNotZero] ushort ch);
        
        /// <summary>
        ///     Ttf the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_ByteSwappedUNICODE", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern void InternalByteSwappedUnicode([IsNotNull, IsNotZero] int swapped);

        /// <summary>
        ///     Ttf the init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_Init", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern int InternalInit();

        /// <summary>
        ///     Internals the ttf open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">The ptSize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFont", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalOpenFont([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string file, [IsNotNull, IsNotZero] int ptSize);

        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptSize">the size</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFontIndex", CharSet = CharSet.Ansi, BestFitMapping = false, ThrowOnUnmappableChar = true, CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull]
        internal static extern IntPtr InternalOpenFontIndex([IsNotNull, IsNotEmpty, MarshalAs(UnmanagedType.LPStr)] string file, [IsNotNull, IsNotZero] int ptSize, [IsNotNull, IsNotZero] long index);
        
        /// <summary>
        ///     Ttf the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontStyle", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontStyle([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_SetFontStyle", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetFontStyle([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] int style);

        /// <summary>
        ///     Ttf the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontOutline", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontOutline([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_SetFontOutline", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern void InternalSetFontOutline([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] int outline);

        /// <summary>
        ///     Ttf the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontHinting", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontHinting([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [DllImport(NativeLibName, EntryPoint = "TTF_SetFontHinting", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal static extern void InternalSetFontHinting([IsNotNull] IntPtr font, [IsNotNull, IsNotZero] int hinting);

        /// <summary>
        ///     Ttf the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontHeight", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalFontHeight([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontAscent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalFontAscent([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontDescent", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalFontDescent([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontLineSkip", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalFontLineSkip([IsNotNull] IntPtr font);

        /// <summary>
        ///     Ttf the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_GetFontKerning", CallingConvention = CallingConvention.Cdecl), MethodImpl(MethodImplOptions.AggressiveInlining)]
        [return: IsNotNull, IsNotZero]
        internal static extern int InternalGetFontKerning([IsNotNull] IntPtr font);

        /// <summary>
        ///     Internals the get ttf version
        /// </summary>
        /// <returns>The sdl version</returns>
        public static Version InternalGetTtfVersion() => new Version(2, 0, 16);
    }
}