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
    /// Defines the string name parameters that can be queried from OpenGL using glGetString.
    /// Returns information about the OpenGL implementation, including vendor, renderer, version, and extensions.
    /// </summary>
    public enum StringName
    {
        /// <summary>Returns the name of the OpenGL vendor (GL_VENDOR = 0x1F00).</summary>
        Vendor = 0x1F00,

        /// <summary>Returns the name of the OpenGL renderer (GL_RENDERER = 0x1F01).</summary>
        Renderer = 0x1F01,

        /// <summary>Returns the OpenGL version string (GL_VERSION = 0x1F02).</summary>
        Version = 0x1F02,

        /// <summary>Returns the list of OpenGL extensions (GL_EXTENSIONS = 0x1F03).</summary>
        Extensions = 0x1F03,

        /// <summary>Returns the shading language version (GL_SHADING_LANGUAGE_VERSION = 0x8B8C).</summary>
        ShadingLanguageVersion = 0x8B8C
    }
}
