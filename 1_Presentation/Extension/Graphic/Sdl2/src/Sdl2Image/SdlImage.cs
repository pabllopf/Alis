// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlImage.cs
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

namespace Alis.Extension.Graphic.Sdl2.Sdl2Image
{
    /// <summary>
    ///     The sdl image class
    /// </summary>
    public static class SdlImage
    {
        /// <summary>
        ///     Versions
        /// </summary>
        /// <returns>The version</returns>
        public static Version Version() => new Version(2, 0, 6);

        /// <summary>
        ///     Linkeds the version
        /// </summary>
        /// <returns>The version</returns>
        public static Version LinkedVersion() => Marshal.PtrToStructure<Version>(NativeSdlImage.InternalVersion());

        /// <summary>
        ///     Loads the img using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadImg(string file) => NativeSdlImage.InternalLoad(Marshal.StringToHGlobalAnsi(file));

        /// <summary>
        ///     Loads the typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadTypedRw(IntPtr src, int freesrc, string type) => NativeSdlImage.InternaloadTypedRW(src, freesrc, Marshal.StringToHGlobalAnsi(type));

        /// <summary>
        ///     Loads the texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadTexture(IntPtr renderer, string file) => NativeSdlImage.InternalLoadTexture(renderer, Marshal.StringToHGlobalAnsi(file));

        /// <summary>
        ///     Loads the texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadTextureTypedRw(IntPtr renderer, IntPtr src, int freesrc, string type) => NativeSdlImage.InternalLoadTextureTypedRW(renderer, src, freesrc, Marshal.StringToHGlobalAnsi(type));

        /// <summary>
        ///     Saves the png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The int</returns>
        public static int SavePng(IntPtr surface, string file) => NativeSdlImage.InternalSavePNG(surface, Marshal.StringToHGlobalAnsi(file));

        /// <summary>
        ///     Saves the jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        public static int SaveJpg(IntPtr surface, string file, int quality) => NativeSdlImage.InternalSaveJPG(surface, Marshal.StringToHGlobalAnsi(file), quality);

        /// <summary>
        ///     Gets the error
        /// </summary>
        /// <returns>The string</returns>
        public static string GetError() => Sdl.GetError();

        /// <summary>
        ///     Sets the error using the specified fmt and arglist
        /// </summary>
        /// <param name="fmtAndArglist">The fmt and arglist</param>
        public static void SetError(string fmtAndArglist) => Sdl.SetError(fmtAndArglist);

        // New methods
        /// <summary>
        ///     Loads the animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadAnimation(string file) => NativeSdlImage.InternalLoadAnimation(file);

        /// <summary>
        ///     Loads the animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadAnimationRw(IntPtr src, int freesrc) => NativeSdlImage.InternalLoadAnimationRW(src, freesrc);

        /// <summary>
        ///     Loads the animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <param name="type">The type</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadAnimationTypedRw(IntPtr src, int freesrc, string type) => NativeSdlImage.InternalLoadAnimationTypedRW(src, freesrc, type);

        /// <summary>
        ///     Frees the animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        public static void FreeAnimation(IntPtr anim) => NativeSdlImage.InternalFreeAnimation(anim);

        /// <summary>
        ///     Loads the gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadGifAnimationRw(IntPtr src) => NativeSdlImage.InternalLoadGIFAnimationRW(src);

        /// <summary>
        ///     Inits the flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <returns>The int</returns>
        public static int Init(ImgInitFlags flags) => NativeSdlImage.InternalInternalInit(flags);

        /// <summary>
        ///     Quits
        /// </summary>
        public static void Quit() => NativeSdlImage.InternalQuit();

        /// <summary>
        ///     Loads the rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freesrc">The freesrc</param>
        /// <returns>The int ptr</returns>
        public static IntPtr LoadRw(IntPtr src, int freesrc) => NativeSdlImage.InternalLoadRW(src, freesrc);

        /// <summary>
        ///     Saves the jpgrw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <param name="quality">The quality</param>
        /// <returns>The int</returns>
        public static int SaveJpgRw(IntPtr surface, IntPtr dst, int freedst, int quality) => NativeSdlImage.InternalSaveJPGRW(surface, dst, freedst, quality);

        /// <summary>
        ///     Saves the pngrw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="freedst">The freedst</param>
        /// <returns>The int</returns>
        public static int SavePngRw(IntPtr surface, IntPtr dst, int freedst) => NativeSdlImage.InternalSavePNGRW(surface, dst, freedst);

        /// <summary>
        ///     Reads the xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The int ptr</returns>
        public static IntPtr ReadXpmFromArray(string[] xpm) => NativeSdlImage.InternalReadXPMFromArray(xpm);
    }
}