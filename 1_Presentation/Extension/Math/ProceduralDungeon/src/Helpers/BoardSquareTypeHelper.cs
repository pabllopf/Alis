// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareTypeHelper.cs
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

namespace Alis.Extension.Math.ProceduralDungeon.Helpers
{
    /// <summary>
    ///     Helper class providing utility methods for working with board square types.
    ///     Contains methods for classifying and querying properties of board square types.
    /// </summary>
    /// <remarks>
    ///     This helper class encapsulates the logic for determining the category
    ///     of a board square (wall, corner, floor, etc.), improving code maintainability.
    /// </remarks>
    public static class BoardSquareTypeHelper
    {
        /// <summary>
        ///     Determines whether the specified square type is a wall.
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is any wall type; otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isWall = BoardSquareTypeHelper.IsWall(BoardSquareType.WallTop); // true
        ///     bool notWall = BoardSquareTypeHelper.IsWall(BoardSquareType.Floor); // false
        ///     </code>
        /// </example>
        public static bool IsWall(BoardSquareType type)
        {
            return type == BoardSquareType.WallDown ||
                   type == BoardSquareType.WallLeft ||
                   type == BoardSquareType.WallRight ||
                   type == BoardSquareType.WallTop;
        }

        /// <summary>
        ///     Determines whether the specified square type is a corner.
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is any corner type (internal or external); otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isCorner = BoardSquareTypeHelper.IsCorner(BoardSquareType.CornerLeftUp); // true
        ///     bool notCorner = BoardSquareTypeHelper.IsCorner(BoardSquareType.Floor); // false
        ///     </code>
        /// </example>
        public static bool IsCorner(BoardSquareType type)
        {
            return IsOuterCorner(type) || IsInnerCorner(type);
        }

        /// <summary>
        ///     Determines whether the specified square type is an outer corner.
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is an outer corner; otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isOuter = BoardSquareTypeHelper.IsOuterCorner(BoardSquareType.CornerLeftUp); // true
        ///     bool notOuter = BoardSquareTypeHelper.IsOuterCorner(BoardSquareType.CornerInternalLeftUp); // false
        ///     </code>
        /// </example>
        public static bool IsOuterCorner(BoardSquareType type)
        {
            return type == BoardSquareType.CornerLeftUp ||
                   type == BoardSquareType.CornerRightUp ||
                   type == BoardSquareType.CornerLeftDown ||
                   type == BoardSquareType.CornerRightDown;
        }

        /// <summary>
        ///     Determines whether the specified square type is an inner corner.
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is an inner corner; otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isInner = BoardSquareTypeHelper.IsInnerCorner(BoardSquareType.CornerInternalLeftUp); // true
        ///     bool notInner = BoardSquareTypeHelper.IsInnerCorner(BoardSquareType.CornerLeftUp); // false
        ///     </code>
        /// </example>
        public static bool IsInnerCorner(BoardSquareType type)
        {
            return type == BoardSquareType.CornerInternalLeftUp ||
                   type == BoardSquareType.CornerInternalRightUp ||
                   type == BoardSquareType.CornerInternalLeftDown ||
                   type == BoardSquareType.CornerInternalRightDown;
        }

        /// <summary>
        ///     Determines whether the specified square type is walkable (floor).
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is floor (walkable); otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool canWalk = BoardSquareTypeHelper.IsWalkable(BoardSquareType.Floor); // true
        ///     bool cantWalk = BoardSquareTypeHelper.IsWalkable(BoardSquareType.WallTop); // false
        ///     </code>
        /// </example>
        public static bool IsWalkable(BoardSquareType type)
        {
            return type == BoardSquareType.Floor;
        }

        /// <summary>
        ///     Determines whether the specified square type is empty (unoccupied).
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is empty; otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isEmpty = BoardSquareTypeHelper.IsEmpty(BoardSquareType.Empty); // true
        ///     bool notEmpty = BoardSquareTypeHelper.IsEmpty(BoardSquareType.Floor); // false
        ///     </code>
        /// </example>
        public static bool IsEmpty(BoardSquareType type)
        {
            return type == BoardSquareType.Empty;
        }

        /// <summary>
        ///     Determines whether the specified square type is solid (wall or corner).
        /// </summary>
        /// <param name="type">The board square type to check.</param>
        /// <returns>True if the type is solid; otherwise, false.</returns>
        /// <remarks>
        ///     Solid types include all walls and corners but not floor or empty spaces.
        /// </remarks>
        /// <example>
        ///     <code>
        ///     bool isSolid = BoardSquareTypeHelper.IsSolid(BoardSquareType.WallTop); // true
        ///     bool notSolid = BoardSquareTypeHelper.IsSolid(BoardSquareType.Floor); // false
        ///     </code>
        /// </example>
        public static bool IsSolid(BoardSquareType type)
        {
            return IsWall(type) || IsCorner(type);
        }

        /// <summary>
        ///     Gets a display character representation of the board square type.
        /// </summary>
        /// <param name="type">The board square type to get the character for.</param>
        /// <returns>A character representing the square type for display purposes.</returns>
        /// <remarks>
        ///     This method is useful for console visualization or debugging output.
        ///     Returns:
        ///     - '.' for Empty
        ///     - ' ' for Floor
        ///     - '#' for Walls
        ///     - '+' for Corners
        /// </remarks>
        /// <example>
        ///     <code>
        ///     char symbol = BoardSquareTypeHelper.GetDisplayCharacter(BoardSquareType.WallTop);
        ///     // symbol == '#'
        ///     </code>
        /// </example>
        public static char GetDisplayCharacter(BoardSquareType type)
        {
            return type switch
            {
                BoardSquareType.Empty => '.',
                BoardSquareType.Floor => ' ',
                BoardSquareType.WallDown => '#',
                BoardSquareType.WallLeft => '#',
                BoardSquareType.WallRight => '#',
                BoardSquareType.WallTop => '#',
                BoardSquareType.CornerLeftDown => '+',
                BoardSquareType.CornerRightDown => '+',
                BoardSquareType.CornerLeftUp => '+',
                BoardSquareType.CornerRightUp => '+',
                BoardSquareType.CornerInternalLeftDown => '+',
                BoardSquareType.CornerInternalRightDown => '+',
                BoardSquareType.CornerInternalLeftUp => '+',
                BoardSquareType.CornerInternalRightUp => '+',
                _ => '?'
            };
        }
    }
}

