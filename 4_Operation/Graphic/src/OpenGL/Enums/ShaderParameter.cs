// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderParameter.cs
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
    /// Defines the parameters that can be queried from OpenGL shader objects using glGetShaderiv.
    /// Provides information about the shader's type, compilation status, and source length.
    /// </summary>
    public enum ShaderParameter
    {
        /// <summary>The type of the shader (vertex, fragment, geometry, etc.) (GL_SHADER_TYPE = 0x8B4F).</summary>
        ShaderType = 0x8B4F,

        /// <summary>Whether the shader has been flagged for deletion (GL_DELETE_STATUS = 0x8B80).</summary>
        DeleteStatus = 0x8B80,

        /// <summary>Whether the shader was successfully compiled (GL_COMPILE_STATUS = 0x8B81).</summary>
        CompileStatus = 0x8B81,

        /// <summary>Length of the shader's info log (GL_INFO_LOG_LENGTH = 0x8B84).</summary>
        InfoLogLength = 0x8B84,

        /// <summary>Length of the shader source code (GL_SHADER_SOURCE_LENGTH = 0x8B88).</summary>
        ShaderSourceLength = 0x8B88
    }
}
