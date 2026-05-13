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
    /// Defines the texture target binding points in OpenGL.
    /// Specifies the type of texture object being bound or operated on, including 1D, 2D, 3D, cube map, array, multisample, and rectangle textures.
    /// </summary>
    public enum TextureTarget
    {
        /// <summary>1D texture target (GL_TEXTURE_1D = 0x0DE0).</summary>
        Texture1D = 0x0DE0,

        /// <summary>2D texture target (GL_TEXTURE_2D = 0x0DE1).</summary>
        Texture2D = 0x0DE1,

        /// <summary>3D texture target (GL_TEXTURE_3D = 0x806F).</summary>
        Texture3D = 0x806F,

        /// <summary>1D array texture target (GL_TEXTURE_1D_ARRAY = 0x8C18).</summary>
        Texture1DArray = 0x8C18,

        /// <summary>2D array texture target (GL_TEXTURE_2D_ARRAY = 0x8C1A).</summary>
        Texture2DArray = 0x8C1A,

        /// <summary>Rectangle texture target (non-power-of-two) (GL_TEXTURE_RECTANGLE = 0x84F5).</summary>
        TextureRectangle = 0x84F5,

        /// <summary>Cube map texture target (GL_TEXTURE_CUBE_MAP = 0x8513).</summary>
        TextureCubeMap = 0x8513,

        /// <summary>Cube map positive X face (GL_TEXTURE_CUBE_MAP_POSITIVE_X = 0x8515).</summary>
        TextureCubeMapPositiveX = 0x8515,

        /// <summary>Cube map negative X face (GL_TEXTURE_CUBE_MAP_NEGATIVE_X = 0x8516).</summary>
        TextureCubeMapNegativeX = 0x8516,

        /// <summary>Cube map positive Y face (GL_TEXTURE_CUBE_MAP_POSITIVE_Y = 0x8517).</summary>
        TextureCubeMapPositiveY = 0x8517,

        /// <summary>Cube map negative Y face (GL_TEXTURE_CUBE_MAP_NEGATIVE_Y = 0x8518).</summary>
        TextureCubeMapNegativeY = 0x8518,

        /// <summary>Cube map positive Z face (GL_TEXTURE_CUBE_MAP_POSITIVE_Z = 0x8519).</summary>
        TextureCubeMapPositiveZ = 0x8519,

        /// <summary>Cube map negative Z face (GL_TEXTURE_CUBE_MAP_NEGATIVE_Z = 0x851A).</summary>
        TextureCubeMapNegativeZ = 0x851A,

        /// <summary>Cube map array texture target (GL_TEXTURE_CUBE_MAP_ARRAY = 0x9009).</summary>
        TextureCubeMapArray = 0x9009,

        /// <summary>2D multisample texture target (GL_TEXTURE_2D_MULTISAMPLE = 0x9100).</summary>
        Texture2DMultisample = 0x9100,

        /// <summary>2D multisample array texture target (GL_TEXTURE_2D_MULTISAMPLE_ARRAY = 0x9102).</summary>
        Texture2DMultisampleArray = 0x9102
    }
}
