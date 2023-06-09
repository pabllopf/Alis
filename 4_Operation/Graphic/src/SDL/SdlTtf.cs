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

#region Using Statements

using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.Properties;

#endregion

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl ttf class
    /// </summary>
    public static class SdlTtf
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlTtf" /> class
        /// </summary>
        static SdlTtf()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.dylib", NativeGraphic.osx_arm64_sdl2_ttf);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.dylib", NativeGraphic.osx_x64_sdl2_ttf);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.dll", NativeGraphic.win_arm64_sdl2_ttf);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.dll", NativeGraphic.win_x86_sdl2_ttf);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.dll", NativeGraphic.win_x64_sdl2_ttf);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.so", NativeGraphic.linux_arm64_sdl2_ttf);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf.so", NativeGraphic.linux_x64_sdl2_ttf);
                        break;
                }
            }
        }

        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2_ttf";

        #endregion

        #region SDL_ttf.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        /// <summary>
        ///     The sdl ttf major version
        /// </summary>
        public const int SdlTtfMajorVersion = 2;

        /// <summary>
        ///     The sdl ttf minor version
        /// </summary>
        public const int SdlTtfMinorVersion = 0;

        /// <summary>
        ///     The sdl ttf patchlevel
        /// </summary>
        public const int SdlTtfPatchlevel = 16;

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
        public const int TtfHintingLightSubpixel = 4; /* >= 2.0.16 */

        /// <summary>
        ///     Sdls the ttf version using the specified x
        /// </summary>
        /// <param name="x">The </param>
        public static void SDL_TTF_VERSION(out SdlVersion x)
        {
            x.major = SdlTtfMajorVersion;
            x.minor = SdlTtfMinorVersion;
            x.patch = SdlTtfPatchlevel;
        }

        /// <summary>
        ///     Internals the ttf linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_LinkedVersion", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_LinkedVersion();

        /// <summary>
        ///     Ttfs the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static SdlVersion TTF_LinkedVersion()
        {
            SdlVersion result;
            IntPtr resultPtr = INTERNAL_TTF_LinkedVersion();
            result = (SdlVersion) Marshal.PtrToStructure(
                resultPtr,
                typeof(SdlVersion)
            );
            return result;
        }

        /// <summary>
        ///     Ttfs the byte swapped unicode using the specified swapped
        /// </summary>
        /// <param name="swapped">The swapped</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_ByteSwappedUNICODE(int swapped);

        /// <summary>
        ///     Ttfs the init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_Init();

        /* IntPtr refers to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFont", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_OpenFont(
            byte[] file,
            int ptsize
        );

        /// <summary>
        ///     Ttfs the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The handle</returns>
        public static  IntPtr TTF_OpenFont(string file, int ptsize)
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_TTF_OpenFont(
                utf8File,
                ptsize
            );
            
            return handle;
        }

        /* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Ttfs the open font rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontRW(
            IntPtr src,
            int freesrc,
            int ptsize
        );

        /* IntPtr refers to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_OpenFontIndex", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_OpenFontIndex(
            byte[] file,
            int ptsize,
            long index
        );

        /// <summary>
        ///     Ttfs the open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The handle</returns>
        public static  IntPtr TTF_OpenFontIndex(
            string file,
            int ptsize,
            long index
        )
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_TTF_OpenFontIndex(
                utf8File,
                ptsize,
                index
            );
            
            return handle;
        }

        /* src refers to an SDL_RWops*, IntPtr to a TTF_Font* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Ttfs the open font index rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_OpenFontIndexRW(
            IntPtr src,
            int freesrc,
            int ptsize,
            long index
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the set font size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetFontSize(
            IntPtr font,
            int ptsize
        );

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the get font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontStyle(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the set font style using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="style">The style</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontStyle(IntPtr font, int style);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the get font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontOutline(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the set font outline using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="outline">The outline</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontOutline(IntPtr font, int outline);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the get font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontHinting(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the set font hinting using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="hinting">The hinting</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontHinting(IntPtr font, int hinting);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the font height using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontHeight(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the font ascent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontAscent(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the font descent using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontDescent(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the font line skip using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontLineSkip(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the get font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerning(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the set font kerning using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="allowed">The allowed</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_SetFontKerning(IntPtr font, int allowed);

        /* font refers to a TTF_Font*.
         * IntPtr is actually a C long! This ignores Win64!
         */
        /// <summary>
        ///     Ttfs the font faces using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_FontFaces(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the font face is fixed width using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_FontFaceIsFixedWidth(IntPtr font);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceFamilyName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceFamilyName(
            IntPtr font
        );

        /// <summary>
        ///     Ttfs the font face family name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        public static string TTF_FontFaceFamilyName(IntPtr font) => Sdl.UTF8_ToManaged(
            INTERNAL_TTF_FontFaceFamilyName(font)
        );

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_FontFaceStyleName", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_TTF_FontFaceStyleName(
            IntPtr font
        );

        /// <summary>
        ///     Ttfs the font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        public static string TTF_FontFaceStyleName(IntPtr font) => Sdl.UTF8_ToManaged(
            INTERNAL_TTF_FontFaceStyleName(font)
        );

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the glyph is provided using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphIsProvided(IntPtr font, ushort ch);

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the glyph is provided 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphIsProvided32(IntPtr font, uint ch);

        /* font refers to a TTF_Font* */
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics(
            IntPtr font,
            ushort ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
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
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GlyphMetrics32(
            IntPtr font,
            uint ch,
            out int minx,
            out int maxx,
            out int miny,
            out int maxy,
            out int advance
        );

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the size text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeText(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            out int w,
            out int h
        );

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_SizeUTF8", CallingConvention = CallingConvention.Cdecl)]
        public static extern  int INTERNAL_TTF_SizeUTF8(
            IntPtr font,
            byte[] text,
            out int w,
            out int h
        );

        /// <summary>
        ///     Ttfs the size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The result</returns>
        public static  int TTF_SizeUTF8(
            IntPtr font,
            string text,
            out int w,
            out int h
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = INTERNAL_TTF_SizeUTF8(
                font,
                utf8Text,
                out w,
                out h
            );
            
            return result;
        }

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the size unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SizeUNICODE(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            out int w,
            out int h
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the measure text using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_MeasureText(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            int measureWidth,
            out int extent,
            out int count
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
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
        public static extern  int INTERNAL_TTF_MeasureUTF8(
            IntPtr font,
            byte[] text,
            int measureWidth,
            out int extent,
            out int count
        );

        /// <summary>
        ///     Ttfs the measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The result</returns>
        public static  int TTF_MeasureUTF8(
            IntPtr font,
            string text,
            int measureWidth,
            out int extent,
            out int count
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = INTERNAL_TTF_MeasureUTF8(
                font,
                utf8Text,
                measureWidth,
                out extent,
                out count
            );
           
            return result;
        }

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the measure unicode using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_MeasureUNICODE(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            int measureWidth,
            out int extent,
            out int count
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render text solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_RenderUTF8_Solid(
            IntPtr font,
            byte[] text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Solid(
            IntPtr font,
            string text,
            SdlColor fg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Solid(
                font,
                utf8Text,
                fg
            );
            
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render unicode solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the render text solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Solid_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            uint wrapLength
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Internals the ttf render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Solid_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        public static extern  IntPtr INTERNAL_TTF_RenderUTF8_Solid_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Solid_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            uint wrapLength
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Solid_Wrapped(
                font,
                utf8Text,
                fg,
                wrapLength
            );
            
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the render unicode solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Solid_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            uint wrapLength
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render glyph solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Solid(
            IntPtr font,
            ushort ch,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the render glyph 32 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Solid(
            IntPtr font,
            uint ch,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render text shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            SdlColor bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Shaded", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_RenderUTF8_Shaded(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            SdlColor bg
        );

        /// <summary>
        ///     Ttfs the render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Shaded(
            IntPtr font,
            string text,
            SdlColor fg,
            SdlColor bg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Shaded(
                font,
                utf8Text,
                fg,
                bg
            );
            
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render unicode shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            SdlColor bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render text shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Shaded_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
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
        public static extern  IntPtr INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

        /// <summary>
        ///     Ttfs the render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Shaded_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Shaded_Wrapped(
                font,
                utf8Text,
                fg,
                bg,
                wrapLength
            );
            
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render unicode shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Shaded_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render glyph shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Shaded(
            IntPtr font,
            ushort ch,
            SdlColor fg,
            SdlColor bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the render glyph 32 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Shaded(
            IntPtr font,
            uint ch,
            SdlColor fg,
            SdlColor bg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render text blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_RenderUTF8_Blended(
            IntPtr font,
            byte[] text,
            SdlColor fg
        );

        /// <summary>
        ///     Ttfs the render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Blended(
            IntPtr font,
            string text,
            SdlColor fg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Blended(
                font,
                utf8Text,
                fg
            );
           
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render unicode blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render text blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderText_Blended_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPStr)] string text,
            SdlColor fg,
            uint wrapped
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Internals the ttf render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "TTF_RenderUTF8_Blended_Wrapped", CallingConvention = CallingConvention.Cdecl)]
        private static extern  IntPtr INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
            IntPtr font,
            byte[] text,
            SdlColor fg,
            uint wrapped
        );

        /// <summary>
        ///     Ttfs the render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The result</returns>
        public static  IntPtr TTF_RenderUTF8_Blended_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            uint wrapped
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = INTERNAL_TTF_RenderUTF8_Blended_Wrapped(
                font,
                utf8Text,
                fg,
                wrapped
            );
            
            return result;
        }

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render unicode blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderUNICODE_Blended_Wrapped(
            IntPtr font,
            [In, MarshalAs(UnmanagedType.LPWStr)] string text,
            SdlColor fg,
            uint wrapped
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font* */
        /// <summary>
        ///     Ttfs the render glyph blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph_Blended(
            IntPtr font,
            ushort ch,
            SdlColor fg
        );

        /* IntPtr refers to an SDL_Surface*, font to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the render glyph 32 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="ch">The ch</param>
        /// <param name="fg">The fg</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr TTF_RenderGlyph32_Blended(
            IntPtr font,
            uint ch,
            SdlColor fg
        );

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     Ttfs the set direction using the specified direction
        /// </summary>
        /// <param name="direction">The direction</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetDirection(int direction);

        /* Only available in 2.0.16 or higher. */
        /// <summary>
        ///     Ttfs the set script using the specified script
        /// </summary>
        /// <param name="script">The script</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_SetScript(int script);

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Ttfs the close font using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_CloseFont(IntPtr font);

        /// <summary>
        ///     Ttfs the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void TTF_Quit();

        /// <summary>
        ///     Ttfs the was init
        /// </summary>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_WasInit();

        /* font refers to a TTF_Font* */
        /// <summary>
        ///     Sdls the get font kerning size using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="prevIndex">The prev index</param>
        /// <param name="index">The index</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int SDL_GetFontKerningSize(
            IntPtr font,
            int prevIndex,
            int index
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.15 or higher.
         */
        /// <summary>
        ///     Ttfs the get font kerning size glyphs using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerningSizeGlyphs(
            IntPtr font,
            ushort previousCh,
            ushort ch
        );

        /* font refers to a TTF_Font*
         * Only available in 2.0.16 or higher.
         */
        /// <summary>
        ///     Ttfs the get font kerning size glyphs 32 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="previousCh">The previous ch</param>
        /// <param name="ch">The ch</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int TTF_GetFontKerningSizeGlyphs32(
            IntPtr font,
            ushort previousCh,
            ushort ch
        );

        /// <summary>
        ///     Ttfs the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string TTF_GetError() => Sdl.SDL_GetError();

        /// <summary>
        ///     Ttfs the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static void TTF_SetError(string fmtAndArglist)
        {
            Sdl.SDL_SetError(fmtAndArglist);
        }

        #endregion
    }
}