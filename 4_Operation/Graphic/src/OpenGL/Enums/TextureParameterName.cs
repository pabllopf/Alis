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
    ///     The texture parameter name enum
    /// </summary>
    public enum TextureParameterName
    {
        /// <summary>
        ///     Base mipmap level for the texture (GL_TEXTURE_BASE_LEVEL)
        /// </summary>
        TextureBaseLevel = 0x813C,

        /// <summary>
        ///     Border color of the texture (GL_TEXTURE_BORDER_COLOR)
        /// </summary>
        TextureBorderColor = 0x1004,

        /// <summary>
        ///     Comparison mode for depth textures (GL_TEXTURE_COMPARE_MODE)
        /// </summary>
        TextureCompareMode = 0x884C,

        /// <summary>
        ///     Comparison function for depth textures (GL_TEXTURE_COMPARE_FUNC)
        /// </summary>
        TextureCompareFunc = 0x884D,

        /// <summary>
        ///     Level-of-detail bias for mipmapping (GL_TEXTURE_LOD_BIAS)
        /// </summary>
        TextureLodBias = 0x8501,

        /// <summary>
        ///     Magnification filter method (GL_TEXTURE_MAG_FILTER)
        /// </summary>
        TextureMagFilter = 0x2800,

        /// <summary>
        ///     Maximum mipmap array level (GL_TEXTURE_MAX_LEVEL)
        /// </summary>
        TextureMaxLevel = 0x813D,

        /// <summary>
        ///     Maximum level-of-detail value (GL_TEXTURE_MAX_LOD)
        /// </summary>
        TextureMaxLod = 0x813B,

        /// <summary>
        ///     Minification filter method (GL_TEXTURE_MIN_FILTER)
        /// </summary>
        TextureMinFilter = 0x2801,

        /// <summary>
        ///     Minimum level-of-detail value (GL_TEXTURE_MIN_LOD)
        /// </summary>
        TextureMinLod = 0x813A,

        /// <summary>
        ///     Swizzle mask for the red component (GL_TEXTURE_SWIZZLE_R)
        /// </summary>
        TextureSwizzleR = 0x8E42,

        /// <summary>
        ///     Swizzle mask for the green component (GL_TEXTURE_SWIZZLE_G)
        /// </summary>
        TextureSwizzleG = 0x8E43,

        /// <summary>
        ///     Swizzle mask for the blue component (GL_TEXTURE_SWIZZLE_B)
        /// </summary>
        TextureSwizzleB = 0x8E44,

        /// <summary>
        ///     Swizzle mask for the alpha component (GL_TEXTURE_SWIZZLE_A)
        /// </summary>
        TextureSwizzleA = 0x8E45,

        /// <summary>
        ///     Swizzle mask for all components combined (GL_TEXTURE_SWIZZLE_RGBA)
        /// </summary>
        TextureSwizzleRgba = 0x8E46,

        /// <summary>
        ///     Wrapping mode for the S (x) texture coordinate (GL_TEXTURE_WRAP_S)
        /// </summary>
        TextureWrapS = 0x2802,

        /// <summary>
        ///     Wrapping mode for the T (y) texture coordinate (GL_TEXTURE_WRAP_T)
        /// </summary>
        TextureWrapT = 0x2803,

        /// <summary>
        ///     Wrapping mode for the R (z) texture coordinate (GL_TEXTURE_WRAP_R)
        /// </summary>
        TextureWrapR = 0x8072,

        /// <summary>
        ///     Maximum level of anisotropic filtering, EXT (GL_MAX_ANISOTROPY_EXT)
        /// </summary>
        MaxAnisotropyExt = 0x84FE
    }
}