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
using System.Runtime.CompilerServices;
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
        /// The sdl version
        /// </summary>
        private static readonly SdlVersion SdlVersion = new SdlVersion(2, 0, 6);

        /// <summary>
        ///     Initializes a new instance of the <see cref="SdlImage" /> class
        /// </summary>
        static SdlImage() => EmbeddedDllClass.ExtractEmbeddedDlls("sdl2_image", SdlDlls.SdlImageDllBytes, Assembly.GetExecutingAssembly());

        /// <summary>
        ///     Sdl the image version
        /// </summary>
        /// <returns>The sdl version</returns>
        [return: NotNull]
        public static SdlVersion SdlImageVersion() => SdlVersion;

        /// <summary>
        ///     Internals the img linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Linked_Version", CallingConvention = CallingConvention.Cdecl), NotNull]
        public static extern SdlVersion IMGLinkedVersion();
        
        /// <summary>
        ///     Img the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Init", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern int ImgInit(ImgInitFlags flags);

        /// <summary>
        ///     Img the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "IMG_Quit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImgQuit();

        /// <summary>
        ///     Internals the img load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Load", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoad([NotNull] string file);
        
        /// <summary>
        ///     Img the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Load_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadRw([NotNull] IntPtr src, [NotNull, NotZero] int free);
        
        /// <summary>
        ///     Internals the img load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadTypedRw([NotNull] IntPtr src, [NotNull] int free, [NotNull] byte[] type);
        
        /// <summary>
        ///     Internals the img load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTexture", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadTexture([NotNull] IntPtr renderer, [NotNull] string file);
        
        /// <summary>
        ///     Img the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTexture_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr ImgLoadTextureRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free);

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
        public static extern IntPtr ImgLoadTextureTypedRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free, [NotNull] byte[] type);
        
        /// <summary>
        ///     Img the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_ReadXPMFromArray", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgReadXpmFromArray([NotNull] string[] xpm);
        
        /// <summary>
        ///     Internals the img save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SavePNG", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern int ImgSavePng([NotNull] IntPtr surface, [NotNull] byte[] file);
        
        /// <summary>
        ///     Img the save png rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SavePNG_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern int ImgSavePngRw(IntPtr surface, IntPtr dst, int free);
        
        /// <summary>
        ///     Internals the img save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SaveJPG", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern int ImgSaveJpg([NotNull] IntPtr surface, [NotNull] byte[] file, [NotNull] int quality);
        
        /// <summary>
        ///     Img the save jpg rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Save", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern int ImgSave([NotNull] IntPtr surface, [NotNull] IntPtr dst, [NotNull] int free, [NotNull] int quality);
        
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
        public static void ImgSetError([NotNull, NotEmpty] string fmtAndArgList) => Sdl.SetError(fmtAndArgList);

        /// <summary>
        ///     Img the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName,EntryPoint = "IMG_LoadAnimation", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadAnimation(string file);
        
        /// <summary>
        ///     Img the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadAnimation_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadAnimationRw(IntPtr src, int freeSrc);
        
        /// <summary>
        ///     Img the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadAnimationTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        public static extern IntPtr ImgLoadAnimationTypedRw(IntPtr src, int freeSrc, string type);
        
        /// <summary>
        ///     Img the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        [DllImport(NativeLibName,EntryPoint = "IMG_FreeAnimation" ,CallingConvention = CallingConvention.Cdecl)]
        public static extern void ImgFreeAnimation([NotNull] IntPtr anim);

        /// <summary>
        ///     Img the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadGIFAnimation_RW" ,CallingConvention = CallingConvention.Cdecl)]
        [return: NotNull]
        private static extern IntPtr InternalImgLoadGifAnimationRw([NotNull] IntPtr src);
        
        /// <summary>
        /// Img the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ImgLoadGifAnimationRw([NotNull] IntPtr src)
        {
            Validator.ValidateInput(src);
            IntPtr result = InternalImgLoadGifAnimationRw(src);
            Validator.ValidateOutput(result);
            return result;
        }
    }
}