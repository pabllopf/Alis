// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TextureTarget.cs
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
    ///     The texture target enum
    /// </summary>
    public enum TextureTarget
    {
        /// <summary>
        ///     1D texture target (GL_TEXTURE_1D)
        /// </summary>
        Texture1D = 0x0DE0,

        /// <summary>
        ///     2D texture target (GL_TEXTURE_2D)
        /// </summary>
        Texture2D = 0x0DE1,

        /// <summary>
        ///     3D texture target (GL_TEXTURE_3D)
        /// </summary>
        Texture3D = 0x806F,

        /// <summary>
        ///     1D texture array target (GL_TEXTURE_1D_ARRAY)
        /// </summary>
        Texture1DArray = 0x8C18,

        /// <summary>
        ///     2D texture array target (GL_TEXTURE_2D_ARRAY)
        /// </summary>
        Texture2DArray = 0x8C1A,

        /// <summary>
        ///     Rectangle texture target (non-power-of-two) (GL_TEXTURE_RECTANGLE)
        /// </summary>
        TextureRectangle = 0x84F5,

        /// <summary>
        ///     Cube map texture target (GL_TEXTURE_CUBE_MAP)
        /// </summary>
        TextureCubeMap = 0x8513,

        /// <summary>
        ///     Cube map positive X face (GL_TEXTURE_CUBE_MAP_POSITIVE_X)
        /// </summary>
        TextureCubeMapPositiveX = 0x8515,

        /// <summary>
        ///     Cube map negative X face (GL_TEXTURE_CUBE_MAP_NEGATIVE_X)
        /// </summary>
        TextureCubeMapNegativeX = 0x8516,

        /// <summary>
        ///     Cube map positive Y face (GL_TEXTURE_CUBE_MAP_POSITIVE_Y)
        /// </summary>
        TextureCubeMapPositiveY = 0x8517,

        /// <summary>
        ///     Cube map negative Y face (GL_TEXTURE_CUBE_MAP_NEGATIVE_Y)
        /// </summary>
        TextureCubeMapNegativeY = 0x8518,

        /// <summary>
        ///     Cube map positive Z face (GL_TEXTURE_CUBE_MAP_POSITIVE_Z)
        /// </summary>
        TextureCubeMapPositiveZ = 0x8519,

        /// <summary>
        ///     Cube map negative Z face (GL_TEXTURE_CUBE_MAP_NEGATIVE_Z)
        /// </summary>
        TextureCubeMapNegativeZ = 0x851A,

        /// <summary>
        ///     Cube map array texture target (GL_TEXTURE_CUBE_MAP_ARRAY)
        /// </summary>
        TextureCubeMapArray = 0x9009,

        /// <summary>
        ///     2D multisample texture target (GL_TEXTURE_2D_MULTISAMPLE)
        /// </summary>
        Texture2DMultisample = 0x9100,

        /// <summary>
        ///     2D multisample array texture target (GL_TEXTURE_2D_MULTISAMPLE_ARRAY)
        /// </summary>
        Texture2DMultisampleArray = 0x9102
    }
}