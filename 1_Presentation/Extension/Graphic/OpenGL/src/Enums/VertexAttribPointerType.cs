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

namespace Alis.Extension.Graphic.OpenGL.Enums
{
    /// <summary>
    ///     The vertex attrib pointer type enum
    /// </summary>
    public enum VertexAttribPointerType
    {
        /// <summary>
        ///     The byte vertex attrib pointer type
        /// </summary>
        Byte = 0x1400,
        
        /// <summary>
        ///     The unsigned byte vertex attrib pointer type
        /// </summary>
        UnsignedByte = 0x1401,
        
        /// <summary>
        ///     The short vertex attrib pointer type
        /// </summary>
        Short = 0x1402,
        
        /// <summary>
        ///     The unsigned short vertex attrib pointer type
        /// </summary>
        UnsignedShort = 0x1403,
        
        /// <summary>
        ///     The int vertex attrib pointer type
        /// </summary>
        Int = 0x1404,
        
        /// <summary>
        ///     The unsigned int vertex attrib pointer type
        /// </summary>
        UnsignedInt = 0x1405,
        
        /// <summary>
        ///     The float vertex attrib pointer type
        /// </summary>
        Float = 0x1406,
        
        /// <summary>
        ///     The double vertex attrib pointer type
        /// </summary>
        Double = 0x140A,
        
        /// <summary>
        ///     The half float vertex attrib pointer type
        /// </summary>
        HalfFloat = 0x140B,
        
        /// <summary>
        ///     The unsigned int 2101010 reversed vertex attrib pointer type
        /// </summary>
        UnsignedUInt2101010Reversed = 0x8368,
        
        /// <summary>
        ///     The unsigned int 2101010 reversed vertex attrib pointer type
        /// </summary>
        UnsignedInt2101010Reversed = 0x8D9F,
        
        /// <summary>
        ///     The unsigned int 101111 reversed vertex attrib pointer type
        /// </summary>
        UnsignedUInt101111Reversed = 0x8C3B
    }
}