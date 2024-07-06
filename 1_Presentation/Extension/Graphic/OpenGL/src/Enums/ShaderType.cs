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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The shader type enum
    /// </summary>
    public enum ShaderType
    {
        /// <summary>
        ///     The fragment shader shader type
        /// </summary>
        FragmentShader = 0x8B30,

        /// <summary>
        ///     The vertex shader shader type
        /// </summary>
        VertexShader = 0x8B31,

        /// <summary>
        ///     The geometry shader shader type
        /// </summary>
        GeometryShader = 0x8DD9,

        /// <summary>
        ///     The tess control shader shader type
        /// </summary>
        TessControlShader = 0x8E88,

        /// <summary>
        ///     The tess evaluation shader shader type
        /// </summary>
        TessEvaluationShader = 0x8E87,

        /// <summary>
        ///     The compute shader shader type
        /// </summary>
        ComputeShader = 0x91B9
    }
}