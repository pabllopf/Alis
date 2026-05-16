// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:VertexAttribPointerType.cs
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
    ///     The vertex attrib pointer type enum
    /// </summary>
    public enum VertexAttribPointerType
    {
        /// <summary>
        ///     Signed 8-bit integer attribute type (GL_BYTE)
        /// </summary>
        Byte = 0x1400,

        /// <summary>
        ///     Unsigned 8-bit integer attribute type (GL_UNSIGNED_BYTE)
        /// </summary>
        UnsignedByte = 0x1401,

        /// <summary>
        ///     Signed 16-bit integer attribute type (GL_SHORT)
        /// </summary>
        Short = 0x1402,

        /// <summary>
        ///     Unsigned 16-bit integer attribute type (GL_UNSIGNED_SHORT)
        /// </summary>
        UnsignedShort = 0x1403,

        /// <summary>
        ///     Signed 32-bit integer attribute type (GL_INT)
        /// </summary>
        Int = 0x1404,

        /// <summary>
        ///     Unsigned 32-bit integer attribute type (GL_UNSIGNED_INT)
        /// </summary>
        UnsignedInt = 0x1405,

        /// <summary>
        ///     32-bit floating-point attribute type (GL_FLOAT)
        /// </summary>
        Float = 0x1406,

        /// <summary>
        ///     64-bit double-precision attribute type (GL_DOUBLE)
        /// </summary>
        Double = 0x140A,

        /// <summary>
        ///     16-bit half-precision float attribute type (GL_HALF_FLOAT)
        /// </summary>
        HalfFloat = 0x140B,

        /// <summary>
        ///     Packed 2-10-10-10 reversed unsigned int attribute (GL_UNSIGNED_INT_2_10_10_10_REV)
        /// </summary>
        UnsignedUInt2101010Reversed = 0x8368,

        /// <summary>
        ///     Packed 2-10-10-10 reversed unsigned int attribute (core) (GL_UNSIGNED_INT_2_10_10_10_REV)
        /// </summary>
        UnsignedInt2101010Reversed = 0x8D9F,

        /// <summary>
        ///     Packed 10-11-11 reversed unsigned int attribute (GL_UNSIGNED_INT_10_11_11_REV)
        /// </summary>
        UnsignedUInt101111Reversed = 0x8C3B
    }
}