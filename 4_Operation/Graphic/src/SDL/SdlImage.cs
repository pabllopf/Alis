// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SdlImage.cs
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
using System.Reflection;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Base.Dll;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.SDL.Enums;
using Alis.Core.Graphic.SDL.Structs;

namespace Alis.Core.Graphic.SDL
{
    /// <summary>
    ///     The sdl image class
    /// </summary>
    public static class SdlImage
    {
        /// <summary>
        ///     The native lib name
        /// </summary>
        private const string NativeLibName = "sdl2_image";

        /// <summary>
        ///     The sdl image major version
        /// </summary>
        private const int SdlImageMajorVersion = 2;

        /// <summary>
        ///     The sdl image minor version
        /// </summary>
        private const int SdlImageMinorVersion = 0;

        /// <summary>
        ///     The sdl image patch level
        /// </summary>
        private const int SdlImagePatchLevel = 6;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlImage" /> class
        /// </summary>
        static SdlImage() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image", SdlDlls.SdlImageDllBytes, Assembly.GetExecutingAssembly());

        /// <summary>
        ///     Sdl the image version
        /// </summary>
        /// <returns>The sdl version</returns>
        [return: NotNull]
        public static SdlVersion SdlImageVersion() => new SdlVersion(SdlImageMajorVersion, SdlImageMinorVersion, SdlImagePatchLevel);

        /// <summary>
        ///     Internals the img linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Linked_Version", CallingConvention = CallingConvention.Cdecl), NotNull]
        private static extern IntPtr INTERNAL_IMG_Linked_Version();

        /// <summary>
        ///     Img the linked version
        /// </summary>
        /// <returns>The result</returns>
        [return: NotNull]
        public static SdlVersion IMG_Linked_Version() => (SdlVersion) Marshal.PtrToStructure(INTERNAL_IMG_Linked_Version(), typeof(SdlVersion));

        /// <summary>
        ///     Img the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int IMG_Init(ImgInitFlags flags);

        /// <summary>
        ///     Img the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ImgInit([NotNull] ImgInitFlags flags) => IMG_Init(flags.Validate());

        /// <summary>
        ///     Img the quit
        /// </summary>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void IMG_Quit();

        /// <summary>
        ///     Img the quit
        /// </summary>
        public static void ImgQuit() => IMG_Quit();

        /// <summary>
        ///     Internals the img load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Load", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_IMG_Load([NotNull] byte[] file);

        /// <summary>
        ///     Img the load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        public static IntPtr Img_Load([NotNull] string file) => INTERNAL_IMG_Load(Utf8Manager.Utf8EncodeHeap(file.Validate()));

        /// <summary>
        ///     Img the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_Load_RW([NotNull] IntPtr src, [NotNull, NotZero] int free);

        /// <summary>
        ///     Img the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadRw([NotNull] IntPtr src, [NotNull, NotZero] int free) => IMG_Load_RW(src.Validate(), free.Validate());

        /// <summary>
        ///     Internals the img load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_IMG_LoadTyped_RW([NotNull] IntPtr src, [NotNull] int free, [NotNull] byte[] type);

        /// <summary>
        ///     Img the load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadTypedRw([NotNull] IntPtr src, [NotNull] int free, [NotNull] string type) => INTERNAL_IMG_LoadTyped_RW(src.Validate(), free.Validate(), Utf8Manager.Utf8Encode(type.Validate(), new byte[Utf8Manager.Utf8Size(type)], Utf8Manager.Utf8Size(type)));

        /// <summary>
        ///     Internals the img load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_IMG_LoadTexture([NotNull] IntPtr renderer, [NotNull] byte[] file);

        /// <summary>
        ///     Img the load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        public static IntPtr ImgLoadTexture([NotNull] IntPtr renderer, [NotNull] string file) => INTERNAL_IMG_LoadTexture(renderer.Validate(), Utf8Manager.Utf8EncodeHeap(file.Validate()));

        /// <summary>
        ///     Img the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern IntPtr IMG_LoadTexture_RW([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free);

        /// <summary>
        ///     Img the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadTextureRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free) => IMG_LoadTexture_RW(renderer.Validate(), src.Validate(), free.Validate());

        /// <summary>
        ///     Internals the img load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTextureTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr INTERNAL_IMG_LoadTextureTyped_RW([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free, [NotNull] byte[] type);

        /// <summary>
        ///     Img the load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The handle</returns>
        [return: NotNull]
        public static IntPtr ImgLoadTextureTypedRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int freeSrc, [NotNull] string type) => INTERNAL_IMG_LoadTextureTyped_RW(renderer, src, freeSrc, Utf8Manager.Utf8EncodeHeap(type));

        /// <summary>
        ///     Img the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_ReadXPMFromArray([NotNull] string[] xpm);

        /// <summary>
        ///     Img the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgReadXpmFromArray([NotNull] string[] xpm) => IMG_ReadXPMFromArray(xpm.Validate());

        /// <summary>
        ///     Internals the img save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SavePNG", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_IMG_SavePNG([NotNull] IntPtr surface, [NotNull] byte[] file);

        /// <summary>
        ///     Img the save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int ImgSavePng([NotNull] IntPtr surface, [NotNull] string file) => INTERNAL_IMG_SavePNG(surface, Utf8Manager.Utf8EncodeHeap(file));

        /// <summary>
        ///     Img the save png rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern int IMG_SavePNG_RW(IntPtr surface, IntPtr dst, int free);

        /// <summary>
        ///     Img the save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ImgSavePng([NotNull] IntPtr surface, [NotNull] IntPtr dst, [NotNull] int free) => IMG_SavePNG_RW(surface.Validate(), dst.Validate(), free.Validate());

        /// <summary>
        ///     Internals the img save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SaveJPG", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int INTERNAL_IMG_SaveJPG([NotNull] IntPtr surface, [NotNull] byte[] file, [NotNull] int quality);

        /// <summary>
        ///     Img the save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The result</returns>
        [return: NotNull]
        public static int ImgSaveJpg([NotNull] IntPtr surface, [NotNull, NotEmpty] string file, [NotNull, NotZero] int quality) => INTERNAL_IMG_SaveJPG(surface.Validate(), Utf8Manager.Utf8EncodeHeap(file.Validate()), quality.Validate());

        /// <summary>
        ///     Img the save jpg rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern int IMG_Save([NotNull] IntPtr surface, [NotNull] IntPtr dst, [NotNull] int free, [NotNull] int quality);

        /// <summary>
        ///     Img the save using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [return: NotNull]
        public static int ImgSave([NotNull] IntPtr surface, [NotNull] IntPtr dst, [NotNull] int free, [NotNull] int quality) => IMG_Save(surface.Validate(), dst.Validate(), free.Validate(), quality.Validate());

        /// <summary>
        ///     Img the get error
        /// </summary>
        /// <returns>The string</returns>
        [return: NotNull, NotEmpty]
        public static string ImgGetError() => Sdl.GetError();

        /// <summary>
        ///     Img the set error using the specified fmt and arg
        /// </summary>
        /// <param name="fmtAndArgList">The fmt and arg list</param>
        public static void ImgSetError([NotNull, NotEmpty] string fmtAndArgList) => Sdl.SetError(fmtAndArgList.Validate());

        /// <summary>
        ///     Img the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_LoadAnimation(string file);

        /// <summary>
        ///     Img the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadAnimation([NotNull, NotEmpty] string file) => IMG_LoadAnimation(file.Validate());

        /// <summary>
        ///     Img the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_LoadAnimation_RW(IntPtr src, int freeSrc);

        /// <summary>
        ///     Img the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadAnimationRw([NotNull] IntPtr src, [NotNull, NotZero] int freeSrc) => IMG_LoadAnimation_RW(src.Validate(), freeSrc.Validate());

        /// <summary>
        ///     Img the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_LoadAnimationTyped_RW(IntPtr src, int freeSrc, string type);

        /// <summary>
        ///     Img the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadAnimationTypedRw([NotNull] IntPtr src, [NotNull, NotZero] int freeSrc, [NotNull, NotEmpty] string type) => IMG_LoadAnimationTyped_RW(src.Validate(), freeSrc.Validate(), type.Validate());

        /// <summary>
        ///     Img the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        private static extern void IMG_FreeAnimation([NotNull] IntPtr anim);

        /// <summary>
        ///     Img the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        public static void ImgFreeAnimation([NotNull] IntPtr anim) => IMG_FreeAnimation(anim.Validate());

        /// <summary>
        ///     Img the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr IMG_LoadGIFAnimation_RW([NotNull] IntPtr src);

        /// <summary>
        ///     Img the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        [return: NotNull]
        public static IntPtr ImgLoadGifAnimationRw([NotNull] IntPtr src) => IMG_LoadGIFAnimation_RW(src.Validate());
    }
}