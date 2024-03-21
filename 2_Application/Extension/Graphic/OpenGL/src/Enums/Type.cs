// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Type.cs
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
    ///     The pixel type enum
    /// </summary>
    public enum Type
    {
        /// <summary>
        ///     The byte pixel type
        /// </summary>
        Byte = 0x1400,

        /// <summary>
        ///     The unsigned byte pixel type
        /// </summary>
        UnsignedByte = 0x1401,

        /// <summary>
        ///     The short pixel type
        /// </summary>
        Short = 0x1402,

        /// <summary>
        ///     The unsigned short pixel type
        /// </summary>
        UnsignedShort = 0x1403,

        /// <summary>
        ///     The int pixel type
        /// </summary>
        Int = 0x1404,

        /// <summary>
        ///     The unsigned int pixel type
        /// </summary>
        UnsignedInt = 0x1405,

        /// <summary>
        ///     The float pixel type
        /// </summary>
        Float = 0x1406,

        /// <summary>
        ///     The half float pixel type
        /// </summary>
        HalfFloat = 0x140B,

        /// <summary>
        ///     The bitmap pixel type
        /// </summary>
        Bitmap = 0x1A00,

        /// <summary>
        ///     The unsigned byte 332 pixel type
        /// </summary>
        UnsignedByte332 = 0x8032,

        /// <summary>
        ///     The unsigned byte 332 ext pixel type
        /// </summary>
        UnsignedByte332Ext = 0x8032,

        /// <summary>
        ///     The unsigned short 4444 pixel type
        /// </summary>
        UnsignedShort4444 = 0x8033,

        /// <summary>
        ///     The unsigned short 4444 ext pixel type
        /// </summary>
        UnsignedShort4444Ext = 0x8033,

        /// <summary>
        ///     The unsigned short 5551 pixel type
        /// </summary>
        UnsignedShort5551 = 0x8034,

        /// <summary>
        ///     The unsigned short 5551 ext pixel type
        /// </summary>
        UnsignedShort5551Ext = 0x8034,

        /// <summary>
        ///     The unsigned int 8888 pixel type
        /// </summary>
        UnsignedInt8888 = 0x8035,

        /// <summary>
        ///     The unsigned int 8888 ext pixel type
        /// </summary>
        UnsignedInt8888Ext = 0x8035,

        /// <summary>
        ///     The unsigned int 1010102 pixel type
        /// </summary>
        UnsignedInt1010102 = 0x8036,

        /// <summary>
        ///     The unsigned int 1010102 ext pixel type
        /// </summary>
        UnsignedInt1010102Ext = 0x8036,

        /// <summary>
        ///     The unsigned byte 233 reversed pixel type
        /// </summary>
        UnsignedByte233Reversed = 0x8362,

        /// <summary>
        ///     The unsigned short 565 pixel type
        /// </summary>
        UnsignedShort565 = 0x8363,

        /// <summary>
        ///     The unsigned short 565 reversed pixel type
        /// </summary>
        UnsignedShort565Reversed = 0x8364,

        /// <summary>
        ///     The unsigned short 4444 reversed pixel type
        /// </summary>
        UnsignedShort4444Reversed = 0x8365,

        /// <summary>
        ///     The unsigned short 1555 reversed pixel type
        /// </summary>
        UnsignedShort1555Reversed = 0x8366,

        /// <summary>
        ///     The unsigned int 8888 reversed pixel type
        /// </summary>
        UnsignedInt8888Reversed = 0x8367,

        /// <summary>
        ///     The unsigned int 2101010 reversed pixel type
        /// </summary>
        UnsignedInt2101010Reversed = 0x8368,

        /// <summary>
        ///     The unsigned int 248 pixel type
        /// </summary>
        UnsignedInt248 = 0x84FA,

        /// <summary>
        ///     The unsigned int 10 11 11 rev pixel type
        /// </summary>
        UnsignedInt10F11F11FRev = 0x8C3B,

        /// <summary>
        ///     The unsigned int 5999 rev pixel type
        /// </summary>
        UnsignedInt5999Rev = 0x8C3E,

        /// <summary>
        ///     The float 32 unsigned int 248 rev pixel type
        /// </summary>
        Float32UnsignedInt248Rev = 0x8DAD
    }
}