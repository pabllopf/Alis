// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareType.cs
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

namespace Alis.Extension.Math.ProceduralDungeon
{
    /// <summary>
    ///     The type cell box enum
    /// </summary>
    public enum BoardSquareType
    {
        /// <summary>The empty</summary>
        Empty,

        /// <summary>The floor</summary>
        Floor,

        /// <summary>The wall down</summary>
        WallDown,

        /// <summary>The wall left</summary>
        WallLeft,

        /// <summary>The wall right</summary>
        WallRight,

        /// <summary>The wall top</summary>
        WallTop,

        /// <summary>The corner left up</summary>
        CornerLeftUp,

        /// <summary>The corner right up</summary>
        CornerRightUp,

        /// <summary>The corner left down</summary>
        CornerLeftDown,

        /// <summary>The corner right down</summary>
        CornerRightDown,

        /// <summary>The corner internal left down</summary>
        CornerInternalLeftDown,

        /// <summary>The corner internal left up</summary>
        CornerInternalLeftUp,

        /// <summary>The corner internal right down</summary>
        CornerInternalRightDown,

        /// <summary>The corner internal right up</summary>
        CornerInternalRightUp
    }
}