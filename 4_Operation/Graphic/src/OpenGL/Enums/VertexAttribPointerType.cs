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
    /// Defines the data types for vertex attribute components used with glVertexAttribPointer.
    /// Specifies the data type of each component in the vertex attribute array.
    /// </summary>
    public enum VertexAttribPointerType
    {
        /// <summary>Signed 8-bit byte (GL_BYTE = 0x1400).</summary>
        Byte = 0x1400,

        /// <summary>Unsigned 8-bit byte (GL_UNSIGNED_BYTE = 0x1401).</summary>
        UnsignedByte = 0x1401,

        /// <summary>Signed 16-bit short (GL_SHORT = 0x1402).</summary>
        Short = 0x1402,

        /// <summary>Unsigned 16-bit short (GL_UNSIGNED_SHORT = 0x1403).</summary>
        UnsignedShort = 0x1403,

        /// <summary>Signed 32-bit integer (GL_INT = 0x1404).</summary>
        Int = 0x1404,

        /// <summary>Unsigned 32-bit integer (GL_UNSIGNED_INT = 0x1405).</summary>
        UnsignedInt = 0x1405,

        /// <summary>32-bit single-precision float (GL_FLOAT = 0x1406).</summary>
        Float = 0x1406,

        /// <summary>64-bit double-precision float (GL_DOUBLE = 0x140A).</summary>
        Double = 0x140A,

        /// <summary>16-bit half-precision float (GL_HALF_FLOAT = 0x140B).</summary>
        HalfFloat = 0x140B,

        /// <summary>Unsigned 2-10-10-10 reversed packed (GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368).</summary>
        UnsignedUInt2101010Reversed = 0x8368,

        /// <summary>Unsigned 2-10-10-10 reversed packed (alternate constant) (GL_UNSIGNED_INT_10_10_10_2 = 0x8D9F).</summary>
        UnsignedInt2101010Reversed = 0x8D9F,

        /// <summary>Unsigned 10-11-11 reversed packed float (GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B).</summary>
        UnsignedUInt101111Reversed = 0x8C3B
    }
}
