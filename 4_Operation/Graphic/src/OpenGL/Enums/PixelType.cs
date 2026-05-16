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
    ///     The pixel type enum
    /// </summary>
    public enum PixelType
    {
        /// <summary>
        ///     Signed 8-bit integer pixel type (GL_BYTE)
        /// </summary>
        Byte = 0x1400,

        /// <summary>
        ///     Unsigned 8-bit integer pixel type (GL_UNSIGNED_BYTE)
        /// </summary>
        UnsignedByte = 0x1401,

        /// <summary>
        ///     Signed 16-bit integer pixel type (GL_SHORT)
        /// </summary>
        Short = 0x1402,

        /// <summary>
        ///     Unsigned 16-bit integer pixel type (GL_UNSIGNED_SHORT)
        /// </summary>
        UnsignedShort = 0x1403,

        /// <summary>
        ///     Signed 32-bit integer pixel type (GL_INT)
        /// </summary>
        Int = 0x1404,

        /// <summary>
        ///     Unsigned 32-bit integer pixel type (GL_UNSIGNED_INT)
        /// </summary>
        UnsignedInt = 0x1405,

        /// <summary>
        ///     32-bit floating-point pixel type (GL_FLOAT)
        /// </summary>
        Float = 0x1406,

        /// <summary>
        ///     16-bit floating-point pixel type (GL_HALF_FLOAT)
        /// </summary>
        HalfFloat = 0x140B,

        /// <summary>
        ///     Single-bit bitmap pixel type (GL_BITMAP)
        /// </summary>
        Bitmap = 0x1A00,

        /// <summary>
        ///     Packed 3-3-2 RGB unsigned byte (GL_UNSIGNED_BYTE_3_3_2)
        /// </summary>
        UnsignedByte332 = 0x8032,

        /// <summary>
        ///     Packed 3-3-2 RGB unsigned byte, EXT version (GL_UNSIGNED_BYTE_3_3_2_EXT)
        /// </summary>
        UnsignedByte332Ext = 0x8032,

        /// <summary>
        ///     Packed 4-4-4-4 RGBA unsigned short (GL_UNSIGNED_SHORT_4_4_4_4)
        /// </summary>
        UnsignedShort4444 = 0x8033,

        /// <summary>
        ///     Packed 4-4-4-4 RGBA unsigned short, EXT version (GL_UNSIGNED_SHORT_4_4_4_4_EXT)
        /// </summary>
        UnsignedShort4444Ext = 0x8033,

        /// <summary>
        ///     Packed 5-5-5-1 RGBA unsigned short (GL_UNSIGNED_SHORT_5_5_5_1)
        /// </summary>
        UnsignedShort5551 = 0x8034,

        /// <summary>
        ///     Packed 5-5-5-1 RGBA unsigned short, EXT version (GL_UNSIGNED_SHORT_5_5_5_1_EXT)
        /// </summary>
        UnsignedShort5551Ext = 0x8034,

        /// <summary>
        ///     Packed 8-8-8-8 RGBA unsigned int (GL_UNSIGNED_INT_8_8_8_8)
        /// </summary>
        UnsignedInt8888 = 0x8035,

        /// <summary>
        ///     Packed 8-8-8-8 RGBA unsigned int, EXT version (GL_UNSIGNED_INT_8_8_8_8_EXT)
        /// </summary>
        UnsignedInt8888Ext = 0x8035,

        /// <summary>
        ///     Packed 10-10-10-2 RGBA unsigned int (GL_UNSIGNED_INT_10_10_10_2)
        /// </summary>
        UnsignedInt1010102 = 0x8036,

        /// <summary>
        ///     Packed 10-10-10-2 RGBA unsigned int, EXT version (GL_UNSIGNED_INT_10_10_10_2_EXT)
        /// </summary>
        UnsignedInt1010102Ext = 0x8036,

        /// <summary>
        ///     Packed reversed 2-3-3 RGB unsigned byte (GL_UNSIGNED_BYTE_2_3_3_REV)
        /// </summary>
        UnsignedByte233Reversed = 0x8362,

        /// <summary>
        ///     Packed 5-6-5 RGB unsigned short (GL_UNSIGNED_SHORT_5_6_5)
        /// </summary>
        UnsignedShort565 = 0x8363,

        /// <summary>
        ///     Packed reversed 5-6-5 RGB unsigned short (GL_UNSIGNED_SHORT_5_6_5_REV)
        /// </summary>
        UnsignedShort565Reversed = 0x8364,

        /// <summary>
        ///     Packed reversed 4-4-4-4 RGBA unsigned short (GL_UNSIGNED_SHORT_4_4_4_4_REV)
        /// </summary>
        UnsignedShort4444Reversed = 0x8365,

        /// <summary>
        ///     Packed reversed 1-5-5-5 RGBA unsigned short (GL_UNSIGNED_SHORT_1_5_5_5_REV)
        /// </summary>
        UnsignedShort1555Reversed = 0x8366,

        /// <summary>
        ///     Packed reversed 8-8-8-8 RGBA unsigned int (GL_UNSIGNED_INT_8_8_8_8_REV)
        /// </summary>
        UnsignedInt8888Reversed = 0x8367,

        /// <summary>
        ///     Packed reversed 2-10-10-10 RGBA unsigned int (GL_UNSIGNED_INT_2_10_10_10_REV)
        /// </summary>
        UnsignedInt2101010Reversed = 0x8368,

        /// <summary>
        ///     Packed 2-4-8 depth-stencil unsigned int (GL_UNSIGNED_INT_24_8)
        /// </summary>
        UnsignedInt248 = 0x84FA,

        /// <summary>
        ///     Packed floating-point 10-11-11 unsigned int reversed (GL_UNSIGNED_INT_10F_11F_11F_REV)
        /// </summary>
        UnsignedInt10F11F11FRev = 0x8C3B,

        /// <summary>
        ///     Packed sRGB 5-9-9-9 unsigned int reversed (GL_UNSIGNED_INT_5_9_9_9_REV)
        /// </summary>
        UnsignedInt5999Rev = 0x8C3E,

        /// <summary>
        ///     32-bit float with 24-8 depth-stencil packed (GL_FLOAT_32_UNSIGNED_INT_24_8_REV)
        /// </summary>
        Float32UnsignedInt248Rev = 0x8DAD
    }
}