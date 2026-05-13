// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DrawElementsType.cs
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
    /// Defines the data types for index values used with glDrawElements and related indexed drawing commands.
    /// Specifies the size (byte-width) of each index in the element array buffer.
    /// </summary>
    public enum DrawElementsType
    {
        /// <summary>Unsigned 8-bit byte index (GL_UNSIGNED_BYTE = 0x1401).</summary>
        UnsignedByte = 0x1401,

        /// <summary>Unsigned 16-bit short index (GL_UNSIGNED_SHORT = 0x1403).</summary>
        UnsignedShort = 0x1403,

        /// <summary>Unsigned 32-bit integer index (GL_UNSIGNED_INT = 0x1405).</summary>
        UnsignedInt = 0x1405
    }
}
