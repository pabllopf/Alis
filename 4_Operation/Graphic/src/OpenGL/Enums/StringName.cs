// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StringName.cs
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
    ///     The string name enum
    /// </summary>
    public enum StringName
    {
        /// <summary>
        ///     Returns the OpenGL vendor string (GL_VENDOR)
        /// </summary>
        Vendor = 0x1F00,

        /// <summary>
        ///     Returns the OpenGL renderer string (GL_RENDERER)
        /// </summary>
        Renderer = 0x1F01,

        /// <summary>
        ///     Returns the OpenGL version string (GL_VERSION)
        /// </summary>
        Version = 0x1F02,

        /// <summary>
        ///     Returns the list of supported extensions (GL_EXTENSIONS)
        /// </summary>
        Extensions = 0x1F03,

        /// <summary>
        ///     Returns the GLSL shading language version (GL_SHADING_LANGUAGE_VERSION)
        /// </summary>
        ShadingLanguageVersion = 0x8B8C
    }
}