// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ProgramParameter.cs
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
    ///     The program parameter enum
    /// </summary>
    public enum ProgramParameter
    {
        /// <summary>
        ///     Maximum length of active uniform block names (GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH)
        /// </summary>
        ActiveUniformBlockMaxNameLength = 0x8A35,

        /// <summary>
        ///     Number of active uniform blocks (GL_ACTIVE_UNIFORM_BLOCKS)
        /// </summary>
        ActiveUniformBlocks = 0x8A36,

        /// <summary>
        ///     Whether the program has been marked for deletion (GL_DELETE_STATUS)
        /// </summary>
        DeleteStatus = 0x8B80,

        /// <summary>
        ///     Whether the program link was successful (GL_LINK_STATUS)
        /// </summary>
        LinkStatus = 0x8B82,

        /// <summary>
        ///     Whether the program validation succeeded (GL_VALIDATE_STATUS)
        /// </summary>
        ValidateStatus = 0x8B83,

        /// <summary>
        ///     Length of the program info log (GL_INFO_LOG_LENGTH)
        /// </summary>
        InfoLogLength = 0x8B84,

        /// <summary>
        ///     Number of attached shader objects (GL_ATTACHED_SHADERS)
        /// </summary>
        AttachedShaders = 0x8B85,

        /// <summary>
        ///     Number of active uniform variables (GL_ACTIVE_UNIFORMS)
        /// </summary>
        ActiveUniforms = 0x8B86,

        /// <summary>
        ///     Maximum length of active uniform names (GL_ACTIVE_UNIFORM_MAX_LENGTH)
        /// </summary>
        ActiveUniformMaxLength = 0x8B87,

        /// <summary>
        ///     Number of active vertex attributes (GL_ACTIVE_ATTRIBUTES)
        /// </summary>
        ActiveAttributes = 0x8B89,

        /// <summary>
        ///     Maximum length of active attribute names (GL_ACTIVE_ATTRIBUTE_MAX_LENGTH)
        /// </summary>
        ActiveAttributeMaxLength = 0x8B8A,

        /// <summary>
        ///     Maximum length of transform feedback varying names (GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH)
        /// </summary>
        TransformFeedbackVaryingMaxLength = 0x8C76,

        /// <summary>
        ///     Transform feedback buffer capture mode (GL_TRANSFORM_FEEDBACK_BUFFER_MODE)
        /// </summary>
        TransformFeedbackBufferMode = 0x8C7F,

        /// <summary>
        ///     Number of transform feedback varying variables (GL_TRANSFORM_FEEDBACK_VARYINGS)
        /// </summary>
        TransformFeedbackVaryings = 0x8C83,

        /// <summary>
        ///     Maximum number of vertices output by geometry shader (GL_GEOMETRY_VERTICES_OUT)
        /// </summary>
        GeometryVerticesOut = 0x8DDA,

        /// <summary>
        ///     Input primitive type accepted by geometry shader (GL_GEOMETRY_INPUT_TYPE)
        /// </summary>
        GeometryInputType = 0x8DDB,

        /// <summary>
        ///     Output primitive type produced by geometry shader (GL_GEOMETRY_OUTPUT_TYPE)
        /// </summary>
        GeometryOutputType = 0x8DDC
    }
}