// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: TextureParameterName.cs
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

namespace Alis.App.Engine.OpenGL.Enums
{
    /// <summary>
    ///     The texture parameter name enum
    /// </summary>
    public enum TextureParameterName
    {
        /// <summary>
        ///     The texture base level texture parameter name
        /// </summary>
        TextureBaseLevel = 0x813C,

        /// <summary>
        ///     The texture border color texture parameter name
        /// </summary>
        TextureBorderColor = 0x1004,

        /// <summary>
        ///     The texture compare mode texture parameter name
        /// </summary>
        TextureCompareMode = 0x884C,

        /// <summary>
        ///     The texture compare func texture parameter name
        /// </summary>
        TextureCompareFunc = 0x884D,

        /// <summary>
        ///     The texture lod bias texture parameter name
        /// </summary>
        TextureLodBias = 0x8501,

        /// <summary>
        ///     The texture mag filter texture parameter name
        /// </summary>
        TextureMagFilter = 0x2800,

        /// <summary>
        ///     The texture max level texture parameter name
        /// </summary>
        TextureMaxLevel = 0x813D,

        /// <summary>
        ///     The texture max lod texture parameter name
        /// </summary>
        TextureMaxLod = 0x813B,

        /// <summary>
        ///     The texture min filter texture parameter name
        /// </summary>
        TextureMinFilter = 0x2801,

        /// <summary>
        ///     The texture min lod texture parameter name
        /// </summary>
        TextureMinLod = 0x813A,

        /// <summary>
        ///     The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleR = 0x8E42,

        /// <summary>
        ///     The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleG = 0x8E43,

        /// <summary>
        ///     The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleB = 0x8E44,

        /// <summary>
        ///     The texture swizzle texture parameter name
        /// </summary>
        TextureSwizzleA = 0x8E45,

        /// <summary>
        ///     The texture swizzle rgba texture parameter name
        /// </summary>
        TextureSwizzleRgba = 0x8E46,

        /// <summary>
        ///     The texture wrap texture parameter name
        /// </summary>
        TextureWrapS = 0x2802,

        /// <summary>
        ///     The texture wrap texture parameter name
        /// </summary>
        TextureWrapT = 0x2803,

        /// <summary>
        ///     The texture wrap texture parameter name
        /// </summary>
        TextureWrapR = 0x8072,

        /// <summary>
        ///     The max anisotropy ext texture parameter name
        /// </summary>
        MaxAnisotropyExt = 0x84FE
    }
}