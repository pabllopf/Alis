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

namespace Alis.Extension.OpenGL.Enums
{
    /// <summary>
    ///     The texture target enum
    /// </summary>
    public enum TextureTarget
    {
        /// <summary>
        ///     The texture texture target
        /// </summary>
        Texture1D = 0x0DE0,

        /// <summary>
        ///     The texture texture target
        /// </summary>
        Texture2D = 0x0DE1,

        /// <summary>
        ///     The texture texture target
        /// </summary>
        Texture3D = 0x806F,

        /// <summary>
        ///     The texture array texture target
        /// </summary>
        Texture1DArray = 0x8C18,

        /// <summary>
        ///     The texture array texture target
        /// </summary>
        Texture2DArray = 0x8C1A,

        /// <summary>
        ///     The texture rectangle texture target
        /// </summary>
        TextureRectangle = 0x84F5,

        /// <summary>
        ///     The texture cube map texture target
        /// </summary>
        TextureCubeMap = 0x8513,

        /// <summary>
        ///     The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveX = 0x8515,

        /// <summary>
        ///     The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeX = 0x8516,

        /// <summary>
        ///     The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveY = 0x8517,

        /// <summary>
        ///     The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeY = 0x8518,

        /// <summary>
        ///     The texture cube map positive texture target
        /// </summary>
        TextureCubeMapPositiveZ = 0x8519,

        /// <summary>
        ///     The texture cube map negative texture target
        /// </summary>
        TextureCubeMapNegativeZ = 0x851A,

        /// <summary>
        ///     The texture cube map array texture target
        /// </summary>
        TextureCubeMapArray = 0x9009,

        /// <summary>
        ///     The texture multisample texture target
        /// </summary>
        Texture2DMultisample = 0x9100,

        /// <summary>
        ///     The texture multisample array texture target
        /// </summary>
        Texture2DMultisampleArray = 0x9102
    }
}