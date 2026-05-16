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
    ///     The draw elements type enum
    /// </summary>
    public enum DrawElementsType
    {
        /// <summary>
        ///     8-bit unsigned integer index type (GL_UNSIGNED_BYTE)
        /// </summary>
        UnsignedByte = 0x1401,

        /// <summary>
        ///     16-bit unsigned integer index type (GL_UNSIGNED_SHORT)
        /// </summary>
        UnsignedShort = 0x1403,

        /// <summary>
        ///     32-bit unsigned integer index type (GL_UNSIGNED_INT)
        /// </summary>
        UnsignedInt = 0x1405
    }
}