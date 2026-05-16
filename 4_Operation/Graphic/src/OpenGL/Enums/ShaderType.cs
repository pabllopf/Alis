// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ShaderType.cs
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
    ///     The shader type enum
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        ///     Fragment (pixel) shader type (GL_FRAGMENT_SHADER)
        /// </summary>
        FragmentShader = 0x8B30,

        /// <summary>
        ///     Vertex shader type (GL_VERTEX_SHADER)
        /// </summary>
        VertexShader = 0x8B31,

        /// <summary>
        ///     Geometry shader type (GL_GEOMETRY_SHADER)
        /// </summary>
        GeometryShader = 0x8DD9,

        /// <summary>
        ///     Tessellation control shader type (GL_TESS_CONTROL_SHADER)
        /// </summary>
        TessControlShader = 0x8E88,

        /// <summary>
        ///     Tessellation evaluation shader type (GL_TESS_EVALUATION_SHADER)
        /// </summary>
        TessEvaluationShader = 0x8E87,

        /// <summary>
        ///     Compute shader type for general-purpose GPU work (GL_COMPUTE_SHADER)
        /// </summary>
        ComputeShader = 0x91B9
    }
}