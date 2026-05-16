// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureParameter.cs
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
    ///     The texture parameter enum
    /// </summary>
    public enum TextureParameter
    {
        /// <summary>
        ///     Nearest neighbor texture filtering (GL_NEAREST)
        /// </summary>
        Nearest = 0x2600,

        /// <summary>
        ///     Linear interpolated texture filtering (GL_LINEAR)
        /// </summary>
        Linear = 0x2601,

        /// <summary>
        ///     Nearest mipmap selection with nearest filtering (GL_NEAREST_MIPMAP_NEAREST)
        /// </summary>
        NearestMipMapNearest = 0x2700,

        /// <summary>
        ///     Linear mipmap selection with nearest filtering (GL_LINEAR_MIPMAP_NEAREST)
        /// </summary>
        LinearMipMapNearest = 0x2701,

        /// <summary>
        ///     Nearest mipmap selection with linear interpolation (GL_NEAREST_MIPMAP_LINEAR)
        /// </summary>
        NearestMipMapLinear = 0x2702,

        /// <summary>
        ///     Linear mipmap selection with linear interpolation (trilinear) (GL_LINEAR_MIPMAP_LINEAR)
        /// </summary>
        LinearMipMapLinear = 0x2703,

        /// <summary>
        ///     Clamp texture coordinates to the edge (GL_CLAMP_TO_EDGE)
        /// </summary>
        ClampToEdge = 0x812F,

        /// <summary>
        ///     Clamp texture coordinates to the border color (GL_CLAMP_TO_BORDER)
        /// </summary>
        ClampToBorder = 0x812D,

        /// <summary>
        ///     Mirror and clamp texture coordinates to the edge (GL_MIRROR_CLAMP_TO_EDGE)
        /// </summary>
        MirrorClampToEdge = 0x8743,

        /// <summary>
        ///     Mirror texture coordinates at each integer boundary (GL_MIRRORED_REPEAT)
        /// </summary>
        MirroredRepeat = 0x8370,

        /// <summary>
        ///     Repeat texture by discarding integer portions (GL_REPEAT)
        /// </summary>
        Repeat = 0x2901,

        /// <summary>
        ///     Red component swizzle/texture format (GL_RED)
        /// </summary>
        Red = 0x1903,

        /// <summary>
        ///     Green component swizzle/texture format (GL_GREEN)
        /// </summary>
        Green = 0x1904,

        /// <summary>
        ///     Blue component swizzle/texture format (GL_BLUE)
        /// </summary>
        Blue = 0x1905,

        /// <summary>
        ///     Alpha component swizzle/texture format (GL_ALPHA)
        /// </summary>
        Alpha = 0x1906,

        /// <summary>
        ///     Value of zero (GL_ZERO)
        /// </summary>
        Zero = 0,

        /// <summary>
        ///     Value of one (GL_ONE)
        /// </summary>
        One = 1,

        /// <summary>
        ///     Compare reference value to texture for depth textures (GL_COMPARE_REF_TO_TEXTURE)
        /// </summary>
        CompareRefToTexture = 0x884E,

        /// <summary>
        ///     No texture (GL_NONE)
        /// </summary>
        None = 0,

        /// <summary>
        ///     Stencil index texture format (GL_STENCIL_INDEX)
        /// </summary>
        StencilIndex = 0x1901,

        /// <summary>
        ///     Depth component texture format (GL_DEPTH_COMPONENT)
        /// </summary>
        DepthComponent = 0x1902,

        /// <summary>
        ///     Maximum anisotropic filtering level, EXT (GL_MAX_ANISOTROPY_EXT)
        /// </summary>
        MaxAnisotropyExt = 0x84FE
    }
}