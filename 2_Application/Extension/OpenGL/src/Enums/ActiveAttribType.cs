// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ActiveAttribType.cs
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
    ///     The active attrib type enum
    /// </summary>
    public enum ActiveAttribType
    {
        /// <summary>
        ///     The float active attrib type
        /// </summary>
        Float = 0x1406,

        /// <summary>
        ///     The float vec active attrib type
        /// </summary>
        FloatVec2 = 0x8B50,

        /// <summary>
        ///     The float vec active attrib type
        /// </summary>
        FloatVec3 = 0x8B51,

        /// <summary>
        ///     The float vec active attrib type
        /// </summary>
        FloatVec4 = 0x8B52,

        /// <summary>
        ///     The float mat active attrib type
        /// </summary>
        FloatMat2 = 0x8B5A,

        /// <summary>
        ///     The float mat active attrib type
        /// </summary>
        FloatMat3 = 0x8B5B,

        /// <summary>
        ///     The float mat active attrib type
        /// </summary>
        FloatMat4 = 0x8B5C
    }
}