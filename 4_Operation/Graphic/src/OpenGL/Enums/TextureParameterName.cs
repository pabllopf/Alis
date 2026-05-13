// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureParameterName.cs
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

namespace Alis.Core.Graphic.OpenGL.Enums
{
    /// <summary>
    /// Defines the texture parameter names used with glTexParameter to query and set texture properties.
    /// Controls filtering modes, wrapping behavior, swizzle masks, and comparison parameters.
    /// </summary>
    public enum TextureParameterName
    {
        /// <summary>Base mipmap level (GL_TEXTURE_BASE_LEVEL = 0x813C).</summary>
        TextureBaseLevel = 0x813C,

        /// <summary>Border color of the texture (GL_TEXTURE_BORDER_COLOR = 0x1004).</summary>
        TextureBorderColor = 0x1004,

        /// <summary>Texture comparison mode (GL_TEXTURE_COMPARE_MODE = 0x884C).</summary>
        TextureCompareMode = 0x884C,

        /// <summary>Texture comparison function (GL_TEXTURE_COMPARE_FUNC = 0x884D).</summary>
        TextureCompareFunc = 0x884D,

        /// <summary>Level of detail bias (GL_TEXTURE_LOD_BIAS = 0x8501).</summary>
        TextureLodBias = 0x8501,

        /// <summary>Magnification filter (GL_TEXTURE_MAG_FILTER = 0x2800).</summary>
        TextureMagFilter = 0x2800,

        /// <summary>Maximum mipmap level (GL_TEXTURE_MAX_LEVEL = 0x813D).</summary>
        TextureMaxLevel = 0x813D,

        /// <summary>Maximum level of detail (GL_TEXTURE_MAX_LOD = 0x813B).</summary>
        TextureMaxLod = 0x813B,

        /// <summary>Minification filter (GL_TEXTURE_MIN_FILTER = 0x2801).</summary>
        TextureMinFilter = 0x2801,

        /// <summary>Minimum level of detail (GL_TEXTURE_MIN_LOD = 0x813A).</summary>
        TextureMinLod = 0x813A,

        /// <summary>Red component swizzle (GL_TEXTURE_SWIZZLE_R = 0x8E42).</summary>
        TextureSwizzleR = 0x8E42,

        /// <summary>Green component swizzle (GL_TEXTURE_SWIZZLE_G = 0x8E43).</summary>
        TextureSwizzleG = 0x8E43,

        /// <summary>Blue component swizzle (GL_TEXTURE_SWIZZLE_B = 0x8E44).</summary>
        TextureSwizzleB = 0x8E44,

        /// <summary>Alpha component swizzle (GL_TEXTURE_SWIZZLE_A = 0x8E45).</summary>
        TextureSwizzleA = 0x8E45,

        /// <summary>RGBA swizzle mask combined (GL_TEXTURE_SWIZZLE_RGBA = 0x8E46).</summary>
        TextureSwizzleRgba = 0x8E46,

        /// <summary>Wrap mode for S coordinate (GL_TEXTURE_WRAP_S = 0x2802).</summary>
        TextureWrapS = 0x2802,

        /// <summary>Wrap mode for T coordinate (GL_TEXTURE_WRAP_T = 0x2803).</summary>
        TextureWrapT = 0x2803,

        /// <summary>Wrap mode for R coordinate (GL_TEXTURE_WRAP_R = 0x8072).</summary>
        TextureWrapR = 0x8072,

        /// <summary>Maximum anisotropy level (GL_MAX_ANISOTROPY_EXT = 0x84FE).</summary>
        MaxAnisotropyExt = 0x84FE
    }
}
