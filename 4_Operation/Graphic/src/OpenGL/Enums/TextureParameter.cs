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
    /// Defines the texture parameter values used with glTexParameter to control texture filtering, wrapping, and swizzling.
    /// Includes filter modes (nearest, linear, mipmap), wrap modes (clamp, repeat, mirror), and comparison modes.
    /// </summary>
    public enum TextureParameter
    {
        /// <summary>Nearest neighbor filtering (GL_NEAREST = 0x2600).</summary>
        Nearest = 0x2600,

        /// <summary>Linear (bilinear) filtering (GL_LINEAR = 0x2601).</summary>
        Linear = 0x2601,

        /// <summary>Nearest mipmap nearest filtering (GL_NEAREST_MIPMAP_NEAREST = 0x2700).</summary>
        NearestMipMapNearest = 0x2700,

        /// <summary>Linear mipmap nearest filtering (GL_LINEAR_MIPMAP_NEAREST = 0x2701).</summary>
        LinearMipMapNearest = 0x2701,

        /// <summary>Nearest mipmap linear filtering (GL_NEAREST_MIPMAP_LINEAR = 0x2702).</summary>
        NearestMipMapLinear = 0x2702,

        /// <summary>Linear mipmap linear (trilinear) filtering (GL_LINEAR_MIPMAP_LINEAR = 0x2703).</summary>
        LinearMipMapLinear = 0x2703,

        /// <summary>Clamp texture coordinates to the edge (GL_CLAMP_TO_EDGE = 0x812F).</summary>
        ClampToEdge = 0x812F,

        /// <summary>Clamp texture coordinates to the border color (GL_CLAMP_TO_BORDER = 0x812D).</summary>
        ClampToBorder = 0x812D,

        /// <summary>Mirror clamp to edge wrapping (GL_MIRROR_CLAMP_TO_EDGE = 0x8743).</summary>
        MirrorClampToEdge = 0x8743,

        /// <summary>Mirrored repeat wrapping (GL_MIRRORED_REPEAT = 0x8370).</summary>
        MirroredRepeat = 0x8370,

        /// <summary>Repeat texture coordinates (GL_REPEAT = 0x2901).</summary>
        Repeat = 0x2901,

        /// <summary>Red component swizzle (GL_RED = 0x1903).</summary>
        Red = 0x1903,

        /// <summary>Green component swizzle (GL_GREEN = 0x1904).</summary>
        Green = 0x1904,

        /// <summary>Blue component swizzle (GL_BLUE = 0x1905).</summary>
        Blue = 0x1905,

        /// <summary>Alpha component swizzle (GL_ALPHA = 0x1906).</summary>
        Alpha = 0x1906,

        /// <summary>Zero value (GL_ZERO = 0).</summary>
        Zero = 0,

        /// <summary>One value (GL_ONE = 1).</summary>
        One = 1,

        /// <summary>Compare ref to texture for depth textures (GL_COMPARE_REF_TO_TEXTURE = 0x884E).</summary>
        CompareRefToTexture = 0x884E,

        /// <summary>None value (GL_NONE = 0).</summary>
        None = 0,

        /// <summary>Stencil index (GL_STENCIL_INDEX = 0x1901).</summary>
        StencilIndex = 0x1901,

        /// <summary>Depth component (GL_DEPTH_COMPONENT = 0x1902).</summary>
        DepthComponent = 0x1902,

        /// <summary>Maximum anisotropy level (GL_MAX_ANISOTROPY_EXT = 0x84FE).</summary>
        MaxAnisotropyExt = 0x84FE
    }
}
