// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Direction.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

namespace Alis.Core.Input.Converters
{
    /// <summary>
    ///     Enum Direction indicates the possible directions of a Hat control.
    /// </summary>
    public enum Direction : byte
    {
        /// <summary>
        ///     The north direction (or up).
        /// </summary>
        North = 0,

        /// <summary>
        ///     The north east direction.
        /// </summary>
        NorthEast = 1,

        /// <summary>
        ///     The east direction.
        /// </summary>
        East = 2,

        /// <summary>
        ///     The south east direction.
        /// </summary>
        SouthEast = 3,

        /// <summary>
        ///     The south direction.
        /// </summary>
        South = 4,

        /// <summary>
        ///     The south west direction.
        /// </summary>
        SouthWest = 5,

        /// <summary>
        ///     The west direction.
        /// </summary>
        West = 6,

        /// <summary>
        ///     The north west direction.
        /// </summary>
        NorthWest = 7,

        /// <summary>
        ///     The hat is not pressed.
        /// </summary>
        NotPressed = 255
    }
}