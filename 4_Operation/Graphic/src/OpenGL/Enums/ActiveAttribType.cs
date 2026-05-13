// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ActiveAttribType.cs
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
    /// Defines the possible data types for active vertex attributes in an OpenGL shader program.
    /// Used with glGetActiveAttrib to determine the GLSL type of each active attribute.
    /// </summary>
    public enum ActiveAttribType
    {
        /// <summary>Single-precision float attribute (GL_FLOAT = 0x1406).</summary>
        Float = 0x1406,

        /// <summary>Two-component float vector attribute (GL_FLOAT_VEC2 = 0x8B50).</summary>
        FloatVec2 = 0x8B50,

        /// <summary>Three-component float vector attribute (GL_FLOAT_VEC3 = 0x8B51).</summary>
        FloatVec3 = 0x8B51,

        /// <summary>Four-component float vector attribute (GL_FLOAT_VEC4 = 0x8B52).</summary>
        FloatVec4 = 0x8B52,

        /// <summary>2x2 float matrix attribute (GL_FLOAT_MAT2 = 0x8B5A).</summary>
        FloatMat2 = 0x8B5A,

        /// <summary>3x3 float matrix attribute (GL_FLOAT_MAT3 = 0x8B5B).</summary>
        FloatMat3 = 0x8B5B,

        /// <summary>4x4 float matrix attribute (GL_FLOAT_MAT4 = 0x8B5C).</summary>
        FloatMat4 = 0x8B5C
    }
}
