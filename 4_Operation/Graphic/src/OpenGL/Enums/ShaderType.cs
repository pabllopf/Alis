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
    /// Defines the types of shader objects that can be created in OpenGL.
    /// Used with glCreateShader to specify the shader stage.
    /// </summary>
    public enum ShaderType
    {
        /// <summary>Fragment (pixel) shader - processes rasterized fragments (GL_FRAGMENT_SHADER = 0x8B30).</summary>
        FragmentShader = 0x8B30,

        /// <summary>Vertex shader - processes vertex data (GL_VERTEX_SHADER = 0x8B31).</summary>
        VertexShader = 0x8B31,

        /// <summary>Geometry shader - processes primitive data (GL_GEOMETRY_SHADER = 0x8DD9).</summary>
        GeometryShader = 0x8DD9,

        /// <summary>Tessellation control shader (GL_TESS_CONTROL_SHADER = 0x8E88).</summary>
        TessControlShader = 0x8E88,

        /// <summary>Tessellation evaluation shader (GL_TESS_EVALUATION_SHADER = 0x8E87).</summary>
        TessEvaluationShader = 0x8E87,

        /// <summary>Compute shader - general purpose computation (GL_COMPUTE_SHADER = 0x91B9).</summary>
        ComputeShader = 0x91B9
    }
}
