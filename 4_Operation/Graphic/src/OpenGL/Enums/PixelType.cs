// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PixelType.cs
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
    /// Defines the pixel data types used by OpenGL for specifying the format of pixel data.
    /// Used with glTexImage2D, glReadPixels, and other pixel transfer operations to describe
    /// the data type of each pixel component in client memory.
    /// </summary>
    public enum PixelType
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

        /// <summary>16-bit half-precision float (GL_HALF_FLOAT = 0x140B).</summary>
        HalfFloat = 0x140B,

        /// <summary>Single-bit bitmap (GL_BITMAP = 0x1A00).</summary>
        Bitmap = 0x1A00,

        /// <summary>Unsigned 3-3-2 packed RGB (GL_UNSIGNED_BYTE_3_3_2 = 0x8032).</summary>
        UnsignedByte332 = 0x8032,

        /// <summary>Extension alias for 3-3-2 packed (GL_UNSIGNED_BYTE_3_3_2_EXT = 0x8032).</summary>
        UnsignedByte332Ext = 0x8032,

        /// <summary>Unsigned 4-4-4-4 packed RGBA (GL_UNSIGNED_SHORT_4_4_4_4 = 0x8033).</summary>
        UnsignedShort4444 = 0x8033,

        /// <summary>Extension alias for 4-4-4-4 packed (GL_UNSIGNED_SHORT_4_4_4_4_EXT = 0x8033).</summary>
        UnsignedShort4444Ext = 0x8033,

        /// <summary>Unsigned 5-5-5-1 packed RGBA (GL_UNSIGNED_SHORT_5_5_5_1 = 0x8034).</summary>
        UnsignedShort5551 = 0x8034,

        /// <summary>Extension alias for 5-5-5-1 packed (GL_UNSIGNED_SHORT_5_5_5_1_EXT = 0x8034).</summary>
        UnsignedShort5551Ext = 0x8034,

        /// <summary>Unsigned 8-8-8-8 packed RGBA (GL_UNSIGNED_INT_8_8_8_8 = 0x8035).</summary>
        UnsignedInt8888 = 0x8035,

        /// <summary>Extension alias for 8-8-8-8 packed (GL_UNSIGNED_INT_8_8_8_8_EXT = 0x8035).</summary>
        UnsignedInt8888Ext = 0x8035,

        /// <summary>Unsigned 10-10-10-2 packed RGBA (GL_UNSIGNED_INT_10_10_10_2 = 0x8036).</summary>
        UnsignedInt1010102 = 0x8036,

        /// <summary>Extension alias for 10-10-10-2 packed (GL_UNSIGNED_INT_10_10_10_2_EXT = 0x8036).</summary>
        UnsignedInt1010102Ext = 0x8036,

        /// <summary>Unsigned 2-3-3 reversed packed (GL_UNSIGNED_BYTE_2_3_3_REV = 0x8362).</summary>
        UnsignedByte233Reversed = 0x8362,

        /// <summary>Unsigned 5-6-5 packed RGB (GL_UNSIGNED_SHORT_5_6_5 = 0x8363).</summary>
        UnsignedShort565 = 0x8363,

        /// <summary>Unsigned 5-6-5 reversed packed (GL_UNSIGNED_SHORT_5_6_5_REV = 0x8364).</summary>
        UnsignedShort565Reversed = 0x8364,

        /// <summary>Unsigned 4-4-4-4 reversed packed (GL_UNSIGNED_SHORT_4_4_4_4_REV = 0x8365).</summary>
        UnsignedShort4444Reversed = 0x8365,

        /// <summary>Unsigned 1-5-5-5 reversed packed (GL_UNSIGNED_SHORT_1_5_5_5_REV = 0x8366).</summary>
        UnsignedShort1555Reversed = 0x8366,

        /// <summary>Unsigned 8-8-8-8 reversed packed (GL_UNSIGNED_INT_8_8_8_8_REV = 0x8367).</summary>
        UnsignedInt8888Reversed = 0x8367,

        /// <summary>Unsigned 2-10-10-10 reversed packed (GL_UNSIGNED_INT_2_10_10_10_REV = 0x8368).</summary>
        UnsignedInt2101010Reversed = 0x8368,

        /// <summary>Unsigned 24-8 packed depth-stencil (GL_UNSIGNED_INT_24_8 = 0x84FA).</summary>
        UnsignedInt248 = 0x84FA,

        /// <summary>Unsigned 10-11-11 reversed packed float (GL_UNSIGNED_INT_10F_11F_11F_REV = 0x8C3B).</summary>
        UnsignedInt10F11F11FRev = 0x8C3B,

        /// <summary>Unsigned 5-9-9-9 reversed packed float (GL_UNSIGNED_INT_5_9_9_9_REV = 0x8C3E).</summary>
        UnsignedInt5999Rev = 0x8C3E,

        /// <summary>32-bit float and 24-8 packed depth-stencil (GL_FLOAT_32_UNSIGNED_INT_24_8_REV = 0x8DAD).</summary>
        Float32UnsignedInt248Rev = 0x8DAD
    }
}
