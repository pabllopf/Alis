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
    /// Defines the parameters that can be queried from OpenGL shader program objects using glGetProgramiv.
    /// Provides information about the program's status, attached shaders, active attributes, uniforms, and transform feedback state.
    /// </summary>
    public enum ProgramParameter
    {
        /// <summary>Maximum name length of active uniform blocks (GL_ACTIVE_UNIFORM_BLOCK_MAX_NAME_LENGTH = 0x8A35).</summary>
        ActiveUniformBlockMaxNameLength = 0x8A35,

        /// <summary>Number of active uniform blocks (GL_ACTIVE_UNIFORM_BLOCKS = 0x8A36).</summary>
        ActiveUniformBlocks = 0x8A36,

        /// <summary>Whether the program has been flagged for deletion (GL_DELETE_STATUS = 0x8B80).</summary>
        DeleteStatus = 0x8B80,

        /// <summary>Whether the program was successfully linked (GL_LINK_STATUS = 0x8B82).</summary>
        LinkStatus = 0x8B82,

        /// <summary>Whether the program is valid for current OpenGL state (GL_VALIDATE_STATUS = 0x8B83).</summary>
        ValidateStatus = 0x8B83,

        /// <summary>Length of the program's info log (GL_INFO_LOG_LENGTH = 0x8B84).</summary>
        InfoLogLength = 0x8B84,

        /// <summary>Number of shader objects attached to the program (GL_ATTACHED_SHADERS = 0x8B85).</summary>
        AttachedShaders = 0x8B85,

        /// <summary>Number of active uniform variables (GL_ACTIVE_UNIFORMS = 0x8B86).</summary>
        ActiveUniforms = 0x8B86,

        /// <summary>Maximum name length of active uniforms (GL_ACTIVE_UNIFORM_MAX_LENGTH = 0x8B87).</summary>
        ActiveUniformMaxLength = 0x8B87,

        /// <summary>Number of active vertex attributes (GL_ACTIVE_ATTRIBUTES = 0x8B89).</summary>
        ActiveAttributes = 0x8B89,

        /// <summary>Maximum name length of active attributes (GL_ACTIVE_ATTRIBUTE_MAX_LENGTH = 0x8B8A).</summary>
        ActiveAttributeMaxLength = 0x8B8A,

        /// <summary>Maximum name length of transform feedback varyings (GL_TRANSFORM_FEEDBACK_VARYING_MAX_LENGTH = 0x8C76).</summary>
        TransformFeedbackVaryingMaxLength = 0x8C76,

        /// <summary>Transform feedback buffer mode (GL_TRANSFORM_FEEDBACK_BUFFER_MODE = 0x8C7F).</summary>
        TransformFeedbackBufferMode = 0x8C7F,

        /// <summary>Number of transform feedback varyings (GL_TRANSFORM_FEEDBACK_VARYINGS = 0x8C83).</summary>
        TransformFeedbackVaryings = 0x8C83,

        /// <summary>Maximum number of vertices output by geometry shader (GL_GEOMETRY_VERTICES_OUT = 0x8DDA).</summary>
        GeometryVerticesOut = 0x8DDA,

        /// <summary>Input primitive type of geometry shader (GL_GEOMETRY_INPUT_TYPE = 0x8DDB).</summary>
        GeometryInputType = 0x8DDB,

        /// <summary>Output primitive type of geometry shader (GL_GEOMETRY_OUTPUT_TYPE = 0x8DDC).</summary>
        GeometryOutputType = 0x8DDC
    }
}
