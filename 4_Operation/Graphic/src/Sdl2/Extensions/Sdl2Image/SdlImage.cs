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
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Memory;
using Alis.Core.Aspect.Memory.Attributes;
using Alis.Core.Graphic.Sdl2.Enums;
using Alis.Core.Graphic.Sdl2.Structs;

namespace Alis.Core.Graphic.Sdl2.Extensions.Sdl2Image
{
    /// <summary>
    ///     The sdl image class
    /// </summary>
    public static class SdlImage
    {
        /// <summary>
        ///     Gets the sdl image version
        /// </summary>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static SdlVersion GetVersion()
        {
            SdlVersion result = NativeSdlImage.InternalGetVersion();
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the init using the specified flags
        /// </summary>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Init()
        {
            int result = NativeSdlImage.InternalImgInit(ImgInitFlags.ImgInitPng | ImgInitFlags.ImgInitJpg);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the quit
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void Quit() => NativeSdlImage.InternalImgQuit();

        /// <summary>
        ///     Img the load using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr Load([NotNull] string file)
        {
            Validator.ValidateInput(file);
            IntPtr result = NativeSdlImage.InternalImgLoad(file);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadRw([NotNull] IntPtr src, [NotNull, NotZero] int free)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(free);
            IntPtr result = NativeSdlImage.InternalImgLoadRw(src, free);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadTypedRw([NotNull] IntPtr src, [NotNull] int free, [NotNull] string type)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(free);
            Validator.ValidateInput(type);
            IntPtr result = NativeSdlImage.InternalImgLoadTypedRw(src, free, type);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load texture using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadTexture([NotNull] IntPtr renderer, [NotNull] string file)
        {
            Validator.ValidateInput(renderer);
            Validator.ValidateInput(file);
            IntPtr result = NativeSdlImage.InternalImgLoadTexture(renderer, file);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load texture rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadTextureRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free)
        {
            Validator.ValidateInput(renderer);
            Validator.ValidateInput(src);
            Validator.ValidateInput(free);
            IntPtr result = NativeSdlImage.InternalImgLoadTextureRw(renderer, src, free);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load texture typed rw using the specified renderer
        /// </summary>
        /// <param name="renderer">The renderer</param>
        /// <param name="src">The src</param>
        /// <param name="free">The free</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadTextureTypedRw([NotNull] IntPtr renderer, [NotNull] IntPtr src, [NotNull] int free, [NotNull] byte[] type)
        {
            Validator.ValidateInput(renderer);
            Validator.ValidateInput(src);
            Validator.ValidateInput(free);
            Validator.ValidateInput(type);
            IntPtr result = NativeSdlImage.InternalImgLoadTextureTypedRw(renderer, src, free, type);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the read xpm from array using the specified xpm
        /// </summary>
        /// <param name="xpm">The xpm</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr ReadXpmFromArray([NotNull] string[] xpm)
        {
            Validator.ValidateInput(xpm);
            IntPtr result = NativeSdlImage.InternalImgReadXpmFromArray(xpm);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the save png using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SavePng([NotNull] IntPtr surface, [NotNull] byte[] file)
        {
            Validator.ValidateInput(surface);
            Validator.ValidateInput(file);
            int result = NativeSdlImage.InternalImgSavePng(surface, file);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the save png rw using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <returns>The result</returns>
        [return: NotZero]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SavePngRw(IntPtr surface, IntPtr dst, int free)
        {
            Validator.ValidateInput(surface);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(free);
            int result = NativeSdlImage.InternalImgSavePngRw(surface, dst, free);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the save jpg using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="file">The file</param>
        /// <param name="quality">The quality</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int SaveJpg([NotNull] IntPtr surface, [NotNull] byte[] file, [NotNull] int quality)
        {
            Validator.ValidateInput(surface);
            Validator.ValidateInput(file);
            Validator.ValidateInput(quality);
            int result = NativeSdlImage.InternalImgSaveJpg(surface, file, quality);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the save using the specified surface
        /// </summary>
        /// <param name="surface">The surface</param>
        /// <param name="dst">The dst</param>
        /// <param name="free">The free</param>
        /// <param name="quality">The quality</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static int Save([NotNull] IntPtr surface, [NotNull] IntPtr dst, [NotNull] int free, [NotNull] int quality)
        {
            Validator.ValidateInput(surface);
            Validator.ValidateInput(dst);
            Validator.ValidateInput(free);
            Validator.ValidateInput(quality);
            int result = NativeSdlImage.InternalImgSave(surface, dst, free, quality);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load animation using the specified file
        /// </summary>
        /// <param name="file">The file</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadAnimation(string file)
        {
            Validator.ValidateInput(file);
            IntPtr result = NativeSdlImage.InternalImgLoadAnimation(file);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadAnimationRw(IntPtr src, int freeSrc)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(freeSrc);
            IntPtr result = NativeSdlImage.InternalImgLoadAnimationRw(src, freeSrc);
            Validator.ValidateOutput(result);
            return result;
        }

        /// <summary>
        ///     Img the load animation typed rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <param name="freeSrc">The free src</param>
        /// <param name="type">The type</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadAnimationTypedRw(IntPtr src, int freeSrc, string type)
        {
            Validator.ValidateInput(src);
            Validator.ValidateInput(freeSrc);
            Validator.ValidateInput(type);
            IntPtr result = NativeSdlImage.InternalImgLoadAnimationTypedRw(src, freeSrc, type);
            Validator.ValidateOutput(result);
            return result;
        }


        /// <summary>
        ///     Img the free animation using the specified anim
        /// </summary>
        /// <param name="anim">The anim</param>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static void FreeAnimation([NotNull] IntPtr anim)
        {
            Validator.ValidateInput(anim);
            NativeSdlImage.InternalImgFreeAnimation(anim);
        }

        /// <summary>
        ///     Img the load gif animation rw using the specified src
        /// </summary>
        /// <param name="src">The src</param>
        /// <returns>The result</returns>
        [return: NotNull]
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        public static IntPtr LoadGifAnimationRw([NotNull] IntPtr src)
        {
            Validator.ValidateInput(src);
            IntPtr result = NativeSdlImage.InternalImgLoadGifAnimationRw(src);
            Validator.ValidateOutput(result);
            return result;
        }
    }
}