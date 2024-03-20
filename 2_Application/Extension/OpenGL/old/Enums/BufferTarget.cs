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

namespace Alis.Extension.OpenGL.Enums
{
    /// <summary>
    ///     The buffer target enum
    /// </summary>
    public enum BufferTarget
    {
        /// <summary>
        ///     The array buffer buffer target
        /// </summary>
        ArrayBuffer = 0x8892,

        /// <summary>
        ///     The element array buffer buffer target
        /// </summary>
        ElementArrayBuffer = 0x8893,

        /// <summary>
        ///     The pixel pack buffer buffer target
        /// </summary>
        PackBuffer = 0x88EB,

        /// <summary>
        ///     The pixel unpack buffer buffer target
        /// </summary>
        UnpackBuffer = 0x88EC,

        /// <summary>
        ///     The uniform buffer buffer target
        /// </summary>
        UniformBuffer = 0x8A11,

        /// <summary>
        ///     The texture buffer buffer target
        /// </summary>
        TextureBuffer = 0x8C2A,

        /// <summary>
        ///     The transform feedback buffer buffer target
        /// </summary>
        TransformFeedbackBuffer = 0x8C8E,

        /// <summary>
        ///     The copy read buffer buffer target
        /// </summary>
        CopyReadBuffer = 0x8F36,

        /// <summary>
        ///     The copy write buffer buffer target
        /// </summary>
        CopyWriteBuffer = 0x8F37,

        /// <summary>
        ///     The draw indirect buffer buffer target
        /// </summary>
        DrawIndirectBuffer = 0x8F3F,

        /// <summary>
        ///     The atomic counter buffer buffer target
        /// </summary>
        AtomicCounterBuffer = 0x92C0,

        /// <summary>
        ///     The dispatch indirect buffer buffer target
        /// </summary>
        DispatchIndirectBuffer = 0x90EE,

        /// <summary>
        ///     The query buffer buffer target
        /// </summary>
        QueryBuffer = 0x9192,

        /// <summary>
        ///     The shader storage buffer buffer target
        /// </summary>
        ShaderStorageBuffer = 0x90D2
    }
}