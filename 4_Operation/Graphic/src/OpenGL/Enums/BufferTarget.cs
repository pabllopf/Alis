// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BufferTarget.cs
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
    /// Defines the binding target points for OpenGL buffer objects.
    /// Specifies how a buffer object will be used, determining which OpenGL operations can access it.
    /// </summary>
    public enum BufferTarget
    {
        /// <summary>Buffer for vertex attribute data (GL_ARRAY_BUFFER = 0x8892).</summary>
        ArrayBuffer = 0x8892,

        /// <summary>Buffer for element/ index data (GL_ELEMENT_ARRAY_BUFFER = 0x8893).</summary>
        ElementArrayBuffer = 0x8893,

        /// <summary>Buffer for reading pixel data from OpenGL (GL_PIXEL_PACK_BUFFER = 0x88EB).</summary>
        PackBuffer = 0x88EB,

        /// <summary>Buffer for writing pixel data to OpenGL (GL_PIXEL_UNPACK_BUFFER = 0x88EC).</summary>
        UnpackBuffer = 0x88EC,

        /// <summary>Buffer for uniform block data (GL_UNIFORM_BUFFER = 0x8A11).</summary>
        UniformBuffer = 0x8A11,

        /// <summary>Buffer used as a texture buffer (GL_TEXTURE_BUFFER = 0x8C2A).</summary>
        TextureBuffer = 0x8C2A,

        /// <summary>Buffer for transform feedback output (GL_TRANSFORM_FEEDBACK_BUFFER = 0x8C8E).</summary>
        TransformFeedbackBuffer = 0x8C8E,

        /// <summary>Buffer for copying data from (GL_COPY_READ_BUFFER = 0x8F36).</summary>
        CopyReadBuffer = 0x8F36,

        /// <summary>Buffer for copying data to (GL_COPY_WRITE_BUFFER = 0x8F37).</summary>
        CopyWriteBuffer = 0x8F37,

        /// <summary>Buffer for indirect draw commands (GL_DRAW_INDIRECT_BUFFER = 0x8F3F).</summary>
        DrawIndirectBuffer = 0x8F3F,

        /// <summary>Buffer for atomic counter data (GL_ATOMIC_COUNTER_BUFFER = 0x92C0).</summary>
        AtomicCounterBuffer = 0x92C0,

        /// <summary>Buffer for indirect dispatch commands (GL_DISPATCH_INDIRECT_BUFFER = 0x90EE).</summary>
        DispatchIndirectBuffer = 0x90EE,

        /// <summary>Buffer for query results (GL_QUERY_BUFFER = 0x9192).</summary>
        QueryBuffer = 0x9192,

        /// <summary>Buffer for shader storage blocks (GL_SHADER_STORAGE_BUFFER = 0x90D2).</summary>
        ShaderStorageBuffer = 0x90D2
    }
}
