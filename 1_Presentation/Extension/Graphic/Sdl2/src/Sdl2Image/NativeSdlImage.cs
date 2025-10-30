// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:NativeSdlImage.cs
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
using System.Runtime.InteropServices;


namespace Alis.Extension.Graphic.Sdl2.Sdl2Image
{
    /// <summary>
    ///     The sdl image native class
    /// </summary>
    public static class NativeSdlImage
    {
        /// <summary>
        ///     The native lib name
        /// </summary>
        public const string NativeLibName = "sdl2_image";
        
        /// <summary>
        ///     Internals the img linked version
        /// </summary>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Linked_Version", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalVersion();

        /// <summary>
        ///     Imgs the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadAnimation", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadAnimation([In, MarshalAs(UnmanagedType.LPStr)] string file);

        /// <summary>
        ///     Imgs the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadAnimation_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadAnimationRW(IntPtr src, int freesrc);

        /// <summary>
        ///     Imgs the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadAnimationTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadAnimationTypedRW(IntPtr src, int freesrc, [In, MarshalAs(UnmanagedType.LPStr)] string type);

        /// <summary>
        ///     Imgs the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        [DllImport(NativeLibName, EntryPoint = "IMG_FreeAnimation", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalFreeAnimation(IntPtr anim);

        /// <summary>
        ///     Imgs the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadGIFAnimation_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadGIFAnimationRW(IntPtr src);

        /// <summary>
        ///     Imgs the init using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Init", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InternalInternalInit(ImgInitFlags flags);

        /// <summary>
        ///     Imgs the quit
        /// </summary>
        [DllImport(NativeLibName, EntryPoint = "IMG_Quit", CallingConvention = CallingConvention.Cdecl)]
        public static extern void InternalQuit();

        /// <summary>
        ///     Internals the img load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Load", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoad(IntPtr file);

        /// <summary>
        ///     Imgs the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_Load_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadRW(IntPtr src, int freesrc);

        /// <summary>
        ///     Internals the img load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternaloadTypedRW(IntPtr src, int freesrc, IntPtr type);

        /// <summary>
        ///     Internals the img load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTexture", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadTexture(IntPtr renderer, IntPtr file);

        /// <summary>
        ///     Imgs the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTexture_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadTextureRW(IntPtr renderer, IntPtr src, int freesrc);

        /// <summary>
        ///     Internals the img load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_LoadTextureTyped_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalLoadTextureTypedRW(IntPtr renderer, IntPtr src, int freesrc, IntPtr type);

        /// <summary>
        ///     Internals the img save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SaveJPG", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InternalSaveJPG(IntPtr surface, IntPtr file, int quality);

        /// <summary>
        ///     Imgs the save jpg rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SaveJPG_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InternalSaveJPGRW(IntPtr surface, IntPtr dst, int freedst, int quality);

        /// <summary>
        ///     Imgs the save png rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SavePNG_RW", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InternalSavePNGRW(IntPtr surface, IntPtr dst, int freedst);

        /// <summary>
        ///     Imgs the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_ReadXPMFromArray", CallingConvention = CallingConvention.Cdecl)]
        public static extern IntPtr InternalReadXPMFromArray([In, MarshalAs(UnmanagedType.LPArray, ArraySubType = UnmanagedType.LPStr)] string[] xpm);

        /// <summary>
        ///     Internals the img save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        [DllImport(NativeLibName, EntryPoint = "IMG_SavePNG", CallingConvention = CallingConvention.Cdecl)]
        public static extern int InternalSavePNG(IntPtr surface, IntPtr file);
    }
}