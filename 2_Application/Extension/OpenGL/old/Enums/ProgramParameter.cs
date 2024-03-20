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

namespace Alis.Extension.OpenGL.Enums
{
    /// <summary>
    ///     The program parameter enum
    /// </summary>
    public enum ProgramParameter
    {
        /// <summary>
        ///     The active uniform block max name length program parameter
        /// </summary>
        ActiveUniformBlockMaxNameLength = 0x8A35,

        /// <summary>
        ///     The active uniform blocks program parameter
        /// </summary>
        ActiveUniformBlocks = 0x8A36,

        /// <summary>
        ///     The delete status program parameter
        /// </summary>
        DeleteStatus = 0x8B80,

        /// <summary>
        ///     The link status program parameter
        /// </summary>
        LinkStatus = 0x8B82,

        /// <summary>
        ///     The validate status program parameter
        /// </summary>
        ValidateStatus = 0x8B83,

        /// <summary>
        ///     The info log length program parameter
        /// </summary>
        InfoLogLength = 0x8B84,

        /// <summary>
        ///     The attached shaders program parameter
        /// </summary>
        AttachedShaders = 0x8B85,

        /// <summary>
        ///     The active uniforms program parameter
        /// </summary>
        ActiveUniforms = 0x8B86,

        /// <summary>
        ///     The active uniform max length program parameter
        /// </summary>
        ActiveUniformMaxLength = 0x8B87,

        /// <summary>
        ///     The active attributes program parameter
        /// </summary>
        ActiveAttributes = 0x8B89,

        /// <summary>
        ///     The active attribute max length program parameter
        /// </summary>
        ActiveAttributeMaxLength = 0x8B8A,

        /// <summary>
        ///     The transform feedback varying max length program parameter
        /// </summary>
        TransformFeedbackVaryingMaxLength = 0x8C76,

        /// <summary>
        ///     The transform feedback buffer mode program parameter
        /// </summary>
        TransformFeedbackBufferMode = 0x8C7F,

        /// <summary>
        ///     The transform feedback varyings program parameter
        /// </summary>
        TransformFeedbackVaryings = 0x8C83,

        /// <summary>
        ///     The geometry vertices out program parameter
        /// </summary>
        GeometryVerticesOut = 0x8DDA,

        /// <summary>
        ///     The geometry input type program parameter
        /// </summary>
        GeometryInputType = 0x8DDB,

        /// <summary>
        ///     The geometry output type program parameter
        /// </summary>
        GeometryOutputType = 0x8DDC
    }
}