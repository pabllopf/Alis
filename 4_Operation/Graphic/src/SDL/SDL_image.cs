// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SDL_image.cs
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
    ///     The sdl image class
    /// </summary>
    public static class SDL_image
    {
        static SDL_image()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.dylib", NativeGraphic.osx_arm64_sdl2_image);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.dylib", NativeGraphic.osx_x64_sdl2_image);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.dll", NativeGraphic.win_arm64_sdl2_image);
                        break;
                    case Architecture.X86:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.dll", NativeGraphic.win_x86_sdl2_image);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.dll", NativeGraphic.win_x64_sdl2_image);
                        break;
                }
            }

            if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
            {
                switch (RuntimeInformation.ProcessArchitecture)
                {
                    case Architecture.Arm64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.so", NativeGraphic.linux_arm64_sdl2_image);
                        break;
                    case Architecture.X64:
                        EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image.so", NativeGraphic.linux_x64_sdl2_image);
                        break;
                }
            }
        }

        #region SDL2# Variables

        /* Used by DllImport to load the native library. */
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string nativeLibName = "sdl2_image";

        #endregion

        #region SDL_image.h

        /* Similar to the headers, this is the version we're expecting to be
         * running with. You will likely want to check this somewhere in your
         * program!
         */
        /// <summary>
        ///     The sdl image major version
        /// </summary>
        public const int SDL_IMAGE_MAJOR_VERSION = 2;

        /// <summary>
        ///     The sdl image minor version
        /// </summary>
        public const int SDL_IMAGE_MINOR_VERSION = 0;

        /// <summary>
        ///     The sdl image patchlevel
        /// </summary>
        public const int SDL_IMAGE_PATCHLEVEL = 6;

        /// <summary>
        ///     The img initflags enum
        /// </summary>
        [Flags]
        public enum IMG_InitFlags
        {
            /// <summary>
            ///     The img init jpg img initflags
            /// </summary>
            IMG_INIT_JPG = 0x00000001,

            /// <summary>
            ///     The img init png img initflags
            /// </summary>
            IMG_INIT_PNG = 0x00000002,

            /// <summary>
            ///     The img init tif img initflags
            /// </summary>
            IMG_INIT_TIF = 0x00000004,

            /// <summary>
            ///     The img init webp img initflags
            /// </summary>
            IMG_INIT_WEBP = 0x00000008
        }

        /// <summary>
        ///     Sdls the image version using the specified x
        /// </summary>
        /// <param name="X">The </param>
        public static void SDL_IMAGE_VERSION(out SDL.SDL_version X)
        {
            X.major = SDL_IMAGE_MAJOR_VERSION;
            X.minor = SDL_IMAGE_MINOR_VERSION;
            X.patch = SDL_IMAGE_PATCHLEVEL;
        }

        /// <summary>
        ///     Internals the img linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr INTERNAL_IMG_Linked_Version();

        /// <summary>
        ///     Imgs the linked version
        /// </summary>
        /// <returns>The result</returns>
        public static SDL.SDL_version IMG_Linked_Version()
        {
            SDL.SDL_version result;
            IntPtr result_ptr = INTERNAL_IMG_Linked_Version();
            result = (SDL.SDL_version) Marshal.PtrToStructure(
                result_ptr,
                typeof(SDL.SDL_version)
            );
            return result;
        }

        /// <summary>
        ///     Imgs the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int IMG_Init(IMG_InitFlags flags);

        /// <summary>
        ///     Imgs the quit
        /// </summary>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void IMG_Quit();

        /* IntPtr refers to an SDL_Surface* */
        /// <summary>
        ///     Internals the img load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_Load", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_IMG_Load(
            byte* file
        );

        /// <summary>
        ///     Imgs the load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The handle</returns>
        public static unsafe IntPtr IMG_Load(string file)
        {
            byte* utf8File = SDL.Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_IMG_Load(
                utf8File
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return handle;
        }

        /* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_Load_RW(
            IntPtr src,
            int freesrc
        );

        /* src refers to an SDL_RWops*, IntPtr to an SDL_Surface* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Internals the img load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_LoadTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_IMG_LoadTyped_RW(
            IntPtr src,
            int freesrc,
            byte* type
        );

        /// <summary>
        ///     Imgs the load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        public static unsafe IntPtr IMG_LoadTyped_RW(
            IntPtr src,
            int freesrc,
            string type
        )
        {
            int utf8TypeBufSize = SDL.Utf8Size(type);
            byte* utf8Type = stackalloc byte[utf8TypeBufSize];
            return INTERNAL_IMG_LoadTyped_RW(
                src,
                freesrc,
                SDL.Utf8Encode(type, utf8Type, utf8TypeBufSize)
            );
        }

        /* IntPtr refers to an SDL_Texture*, renderer to an SDL_Renderer* */
        /// <summary>
        ///     Internals the img load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_LoadTexture", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_IMG_LoadTexture(
            IntPtr renderer,
            byte* file
        );

        /// <summary>
        ///     Imgs the load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The handle</returns>
        public static unsafe IntPtr IMG_LoadTexture(
            IntPtr renderer,
            string file
        )
        {
            byte* utf8File = SDL.Utf8EncodeHeap(file);
            IntPtr handle = INTERNAL_IMG_LoadTexture(
                renderer,
                utf8File
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return handle;
        }

        /* renderer refers to an SDL_Renderer*.
         * src refers to an SDL_RWops*.
         * IntPtr to an SDL_Texture*.
         */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadTexture_RW(
            IntPtr renderer,
            IntPtr src,
            int freesrc
        );

        /* renderer refers to an SDL_Renderer*.
         * src refers to an SDL_RWops*.
         * IntPtr to an SDL_Texture*.
         */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Internals the img load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_LoadTextureTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe IntPtr INTERNAL_IMG_LoadTextureTyped_RW(
            IntPtr renderer,
            IntPtr src,
            int freesrc,
            byte* type
        );

        /// <summary>
        ///     Imgs the load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The handle</returns>
        public static unsafe IntPtr IMG_LoadTextureTyped_RW(
            IntPtr renderer,
            IntPtr src,
            int freesrc,
            string type
        )
        {
            byte* utf8Type = SDL.Utf8EncodeHeap(type);
            IntPtr handle = INTERNAL_IMG_LoadTextureTyped_RW(
                renderer,
                src,
                freesrc,
                utf8Type
            );
            Marshal.FreeHGlobal((IntPtr) utf8Type);
            return handle;
        }

        /* IntPtr refers to an SDL_Surface* */
        /// <summary>
        ///     Imgs the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_ReadXPMFromArray(
            [In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)]
            string[] xpm
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Internals the img save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_SavePNG", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_IMG_SavePNG(
            IntPtr surface,
            byte* file
        );

        /// <summary>
        ///     Imgs the save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        public static unsafe int IMG_SavePNG(IntPtr surface, string file)
        {
            byte* utf8File = SDL.Utf8EncodeHeap(file);
            int result = INTERNAL_IMG_SavePNG(
                surface,
                utf8File
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return result;
        }

        /* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the save png rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int IMG_SavePNG_RW(
            IntPtr surface,
            IntPtr dst,
            int freedst
        );

        /* surface refers to an SDL_Surface* */
        /// <summary>
        ///     Internals the img save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, EntryPoint = "IMG_SaveJPG", CallingConvention = CallingConvention.Cdecl)]
        private static extern unsafe int INTERNAL_IMG_SaveJPG(
            IntPtr surface,
            byte* file,
            int quality
        );

        /// <summary>
        ///     Imgs the save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The result</returns>
        public static unsafe int IMG_SaveJPG(IntPtr surface, string file, int quality)
        {
            byte* utf8File = SDL.Utf8EncodeHeap(file);
            int result = INTERNAL_IMG_SaveJPG(
                surface,
                utf8File,
                quality
            );
            Marshal.FreeHGlobal((IntPtr) utf8File);
            return result;
        }

        /* surface refers to an SDL_Surface*, dst to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the save jpg rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern int IMG_SaveJPG_RW(
            IntPtr surface,
            IntPtr dst,
            int freedst,
            int quality
        );

        /// <summary>
        ///     Imgs the get error
        /// </summary>
        /// <returns>The string</returns>
        public static string IMG_GetError() => SDL.SDL_GetError();

        /// <summary>
        ///     Imgs the set error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static void IMG_SetError(string fmtAndArglist)
        {
            SDL.SDL_SetError(fmtAndArglist);
        }

        #region Animated Image Support

        /* This region is only available in 2.0.6 or higher. */

        /// <summary>
        ///     The img animation
        /// </summary>
        public struct IMG_Animation
        {
            /// <summary>
            ///     The
            /// </summary>
            public int w;

            /// <summary>
            ///     The
            /// </summary>
            public int h;

            /// <summary>
            ///     The frames
            /// </summary>
            public IntPtr frames; /* SDL_Surface** */

            /// <summary>
            ///     The delays
            /// </summary>
            public IntPtr delays; /* int* */
        }

        /* IntPtr refers to an IMG_Animation* */
        /// <summary>
        ///     Imgs the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadAnimation(
            [In, MarshalAs(UnmanagedType.LPStr)] string file
        );

        /* IntPtr refers to an IMG_Animation*, src to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadAnimation_RW(
            IntPtr src,
            int freesrc
        );

        /* IntPtr refers to an IMG_Animation*, src to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadAnimationTyped_RW(
            IntPtr src,
            int freesrc,
            [In, MarshalAs(UnmanagedType.LPStr)] string type
        );

        /* anim refers to an IMG_Animation* */
        /// <summary>
        ///     Imgs the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern void IMG_FreeAnimation(IntPtr anim);

        /* IntPtr refers to an IMG_Animation*, src to an SDL_RWops* */
        /* THIS IS A PUBLIC RWops FUNCTION! */
        /// <summary>
        ///     Imgs the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        [DllImport(nativeLibName, CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr IMG_LoadGIFAnimation_RW(IntPtr src);

        #endregion

        #endregion
    }
}