// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SdlRendererInfo.cs
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

namespace Alis.Core.Graphic.Sdl2.Structs
{
    /// <summary>
    ///     The sdl renderer info
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct SdlRendererInfo
    {
        /// <summary>
        ///     The name
        /// </summary>
        public IntPtr name;

        /// <summary>
        ///     The flags
        /// </summary>
        public readonly uint flags;

        /// <summary>
        ///     The num texture formats
        /// </summary>
        public readonly uint num_texture_formats;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats0;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats1;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats2;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats3;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats4;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats5;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats6;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats7;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats8;

        /// <summary>
        ///     The texture formats
        /// </summary>
        public readonly int textureFormats9;

        /// <summary>
        ///     The texture formats 10
        /// </summary>
        public readonly int textureFormats10;

        /// <summary>
        ///     The texture formats 11
        /// </summary>
        public readonly int textureFormats11;

        /// <summary>
        ///     The texture formats 12
        /// </summary>
        public readonly int textureFormats12;

        /// <summary>
        ///     The texture formats 13
        /// </summary>
        public readonly int textureFormats13;

        /// <summary>
        ///     The texture formats 14
        /// </summary>
        public readonly int textureFormats14;

        /// <summary>
        ///     The texture formats 15
        /// </summary>
        public readonly int textureFormats15;

        /// <summary>
        ///     The max texture width
        /// </summary>
        public readonly int maxTextureWidth;

        /// <summary>
        ///     The max texture height
        /// </summary>
        public readonly int maxTextureHeight;

        /// <summary>
        ///     Gets the name
        /// </summary>
        /// <returns>The string</returns>
        public string GetName() => Marshal.PtrToStringAnsi(name);
    }
}