// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RendererInfo.cs
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

namespace Alis.Extension.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     Represents an SDL renderer info structure, describing the capabilities and properties of a rendering driver.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct RendererInfo
    {
        /// <summary>
        ///     A pointer to the null-terminated name string of the renderer (e.g. "opengl", "direct3d").
        /// </summary>
        public IntPtr Name { get; set; }

        /// <summary>
        ///     A bitmask of supported renderer flags (e.g. SDL_RENDERER_SOFTWARE, SDL_RENDERER_ACCELERATED, SDL_RENDERER_VSYNC).
        /// </summary>
        public uint flags;

        /// <summary>
        ///     The number of available texture formats in the textureFormats array.
        /// </summary>
        public uint num_texture_formats;

        /// <summary>
        ///     The first supported texture pixel format (SDL_PixelFormatEnum).
        /// </summary>
        public int textureFormats0;

        /// <summary>
        ///     The second supported texture pixel format.
        /// </summary>
        public int textureFormats1;

        /// <summary>
        ///     The third supported texture pixel format.
        /// </summary>
        public int textureFormats2;

        /// <summary>
        ///     The fourth supported texture pixel format.
        /// </summary>
        public int textureFormats3;

        /// <summary>
        ///     The fifth supported texture pixel format.
        /// </summary>
        public int textureFormats4;

        /// <summary>
        ///     The sixth supported texture pixel format.
        /// </summary>
        public int textureFormats5;

        /// <summary>
        ///     The seventh supported texture pixel format.
        /// </summary>
        public int textureFormats6;

        /// <summary>
        ///     The eighth supported texture pixel format.
        /// </summary>
        public int textureFormats7;

        /// <summary>
        ///     The ninth supported texture pixel format.
        /// </summary>
        public int textureFormats8;

        /// <summary>
        ///     The tenth supported texture pixel format.
        /// </summary>
        public int textureFormats9;

        /// <summary>
        ///     The eleventh supported texture pixel format.
        /// </summary>
        public int textureFormats10;

        /// <summary>
        ///     The twelfth supported texture pixel format.
        /// </summary>
        public int textureFormats11;

        /// <summary>
        ///     The thirteenth supported texture pixel format.
        /// </summary>
        public int textureFormats12;

        /// <summary>
        ///     The fourteenth supported texture pixel format.
        /// </summary>
        public int textureFormats13;

        /// <summary>
        ///     The fifteenth supported texture pixel format.
        /// </summary>
        public int textureFormats14;

        /// <summary>
        ///     The sixteenth supported texture pixel format.
        /// </summary>
        public int textureFormats15;

        /// <summary>
        ///     The maximum texture width supported by the renderer.
        /// </summary>
        public int maxTextureWidth;

        /// <summary>
        ///     The maximum texture height supported by the renderer.
        /// </summary>
        public int maxTextureHeight;

        /// <summary>
        ///     Converts the native renderer name pointer to a managed string.
        /// </summary>
        /// <returns>The renderer name as a managed string, or null if the pointer is invalid.</returns>
        public string GetName() => Marshal.PtrToStringAnsi(Name);
    }
}