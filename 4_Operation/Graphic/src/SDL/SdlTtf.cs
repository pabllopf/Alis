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
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Graphic.SDL.Extern;
using Alis.Core.Graphic.SDL.Structs;

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
            EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_ttf", SdlDlls.SdlTtfDllBytes);
        }

        /// <summary>
        ///     The native lib name
        /// </summary>
        internal const string NativeLibName = "sdl2_ttf";

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
        public const int TtfHintingLightSubpixel = 4; 
        
        /// <summary>
        ///     Ttfs the open font using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <returns>The handle</returns>
        public static IntPtr TTF_OpenFont(string file, int ptsize)
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = SdlTtfExtern.TtfOpenFont(
                utf8File,
                ptsize
            );

            return handle;
        }

        /// <summary>
        ///     Ttfs the render utf 8 blended wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapped">The wrapped</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Blended_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            uint wrapped
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8BlendedWrapped(
                font,
                utf8Text,
                fg,
                wrapped
            );

            return result;
        }

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

        /// <summary>
        ///     Ttfs the render utf 8 blended using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Blended(
            IntPtr font,
            string text,
            SdlColor fg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8Blended(
                font,
                utf8Text,
                fg
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the render utf 8 shaded wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Shaded_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            SdlColor bg,
            uint wrapLength
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8ShadedWrapped(
                font,
                utf8Text,
                fg,
                bg,
                wrapLength
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the render utf 8 shaded using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="bg">The bg</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Shaded(
            IntPtr font,
            string text,
            SdlColor fg,
            SdlColor bg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8Shaded(
                font,
                utf8Text,
                fg,
                bg
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the render utf 8 solid wrapped using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <param name="wrapLength">The wrap length</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Solid_Wrapped(
            IntPtr font,
            string text,
            SdlColor fg,
            uint wrapLength
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8SolidWrapped(
                font,
                utf8Text,
                fg,
                wrapLength
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the render utf 8 solid using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="fg">The fg</param>
        /// <returns>The result</returns>
        public static IntPtr TTF_RenderUTF8_Solid(
            IntPtr font,
            string text,
            SdlColor fg
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            IntPtr result = SdlTtfExtern.InternalTtfRenderUtf8Solid(
                font,
                utf8Text,
                fg
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the measure utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="measureWidth">The measure width</param>
        /// <param name="extent">The extent</param>
        /// <param name="count">The count</param>
        /// <returns>The result</returns>
        public static int TTF_MeasureUTF8(
            IntPtr font,
            string text,
            int measureWidth,
            out int extent,
            out int count
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = SdlTtfExtern.InternalTtfMeasureUtf8(
                font,
                utf8Text,
                measureWidth,
                out extent,
                out count
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the size utf 8 using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <param name="text">The text</param>
        /// <param name="w">The </param>
        /// <param name="h">The </param>
        /// <returns>The result</returns>
        public static int TTF_SizeUTF8(
            IntPtr font,
            string text,
            out int w,
            out int h
        )
        {
            byte[] utf8Text = Sdl.Utf8EncodeHeap(text);
            int result = SdlTtfExtern.InternalTtfSizeUtf8(
                font,
                utf8Text,
                out w,
                out h
            );

            return result;
        }

        /// <summary>
        ///     Ttfs the font face style name using the specified font
        /// </summary>
        /// <param name="font">The font</param>
        /// <returns>The string</returns>
        public static string TTF_FontFaceStyleName(IntPtr font) => Sdl.UTF8_ToManaged(SdlTtfExtern.InternalTtfFontFaceStyleName(font));

        /// <summary>
        ///     Ttfs the open font index using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <param name="ptsize">The ptsize</param>
        /// <param name="index">The index</param>
        /// <returns>The handle</returns>
        public static IntPtr TTF_OpenFontIndex(
            string file,
            int ptsize,
            long index
        )
        {
            byte[] utf8File = Sdl.Utf8EncodeHeap(file);
            IntPtr handle = SdlTtfExtern.InternalTtfOpenFontIndex(
                utf8File,
                ptsize,
                index
            );

            return handle;
        }

        /// <summary>
        ///     Ttfs the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static SdlVersion TTF_LinkedVersion()
        {
            SdlVersion result;
            IntPtr resultPtr = SdlTtfExtern.InternalTtfLinkedVersion();
            result = (SdlVersion) Marshal.PtrToStructure(
                resultPtr,
                typeof(SdlVersion)
            );
            return result;
        }

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
    }
}