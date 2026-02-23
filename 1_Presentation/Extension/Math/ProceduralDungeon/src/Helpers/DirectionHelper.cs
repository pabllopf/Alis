// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DirectionHelper.cs
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

using System;

namespace Alis.Extension.Math.ProceduralDungeon.Helpers
{
    /// <summary>
    ///     Helper class providing utility methods for working with directions.
    ///     Contains methods for calculating opposite directions, validating direction values,
    ///     and converting between different direction representations.
    /// </summary>
    /// <remarks>
    ///     This class follows the Single Responsibility Principle by focusing solely
    ///     on direction-related operations. All methods are static as they don't require state.
    /// </remarks>
    public static class DirectionHelper
    {
        /// <summary>
        ///     Gets the opposite direction of the given direction.
        /// </summary>
        /// <param name="direction">The direction to get the opposite of.</param>
        /// <returns>The opposite direction.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when direction is None or invalid.</exception>
        /// <example>
        ///     <code>
        ///     Direction opposite = DirectionHelper.GetOpposite(Direction.North);
        ///     // opposite == Direction.South
        ///     </code>
        /// </example>
        public static Direction GetOpposite(Direction direction)
        {
            if (direction == Direction.None)
                throw new ArgumentOutOfRangeException(nameof(direction), "Cannot get opposite of Direction.None");

            // Calculate opposite: North (1) -> South (3), East (2) -> West (4)
            // Formula: ((value + 2 - 1) % 4) + 1
            int value = (int)direction;
            int oppositeValue = ((value + 2 - 1) % 4) + 1;
            return (Direction)oppositeValue;
        }

        /// <summary>
        ///     Determines whether the specified direction is valid (not None).
        /// </summary>
        /// <param name="direction">The direction to validate.</param>
        /// <returns>True if the direction is valid; otherwise, false.</returns>
        /// <example>
        ///     <code>
        ///     bool isValid = DirectionHelper.IsValid(Direction.North); // true
        ///     bool isInvalid = DirectionHelper.IsValid(Direction.None); // false
        ///     </code>
        /// </example>
        public static bool IsValid(Direction direction)
        {
            return direction != Direction.None && Enum.IsDefined(typeof(Direction), direction);
        }

        /// <summary>
        ///     Determines whether two directions are opposite to each other.
        /// </summary>
        /// <param name="first">The first direction.</param>
        /// <param name="second">The second direction.</param>
        /// <returns>True if the directions are opposite; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when either direction is None.</exception>
        /// <example>
        ///     <code>
        ///     bool areOpposite = DirectionHelper.AreOpposite(Direction.North, Direction.South); // true
        ///     bool notOpposite = DirectionHelper.AreOpposite(Direction.North, Direction.East); // false
        ///     </code>
        /// </example>
        public static bool AreOpposite(Direction first, Direction second)
        {
            if (first == Direction.None || second == Direction.None)
                throw new ArgumentOutOfRangeException("Neither direction can be Direction.None");

            return GetOpposite(first) == second;
        }

        /// <summary>
        ///     Gets the directional offset as a coordinate pair.
        /// </summary>
        /// <param name="direction">The direction to get the offset for.</param>
        /// <returns>A tuple containing the x and y offset values.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when direction is None or invalid.</exception>
        /// <remarks>
        ///     Returns coordinate offsets where:
        ///     - North: (0, 1)
        ///     - South: (0, -1)
        ///     - East: (1, 0)
        ///     - West: (-1, 0)
        /// </remarks>
        /// <example>
        ///     <code>
        ///     var (x, y) = DirectionHelper.GetOffset(Direction.North);
        ///     // x == 0, y == 1
        ///     </code>
        /// </example>
        public static (int x, int y) GetOffset(Direction direction)
        {
            return direction switch
            {
                Direction.North => (0, 1),
                Direction.South => (0, -1),
                Direction.East => (1, 0),
                Direction.West => (-1, 0),
                _ => throw new ArgumentOutOfRangeException(nameof(direction), direction, "Invalid direction")
            };
        }

        /// <summary>
        ///     Determines whether the direction is horizontal (East or West).
        /// </summary>
        /// <param name="direction">The direction to check.</param>
        /// <returns>True if the direction is horizontal; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when direction is None.</exception>
        /// <example>
        ///     <code>
        ///     bool isHorizontal = DirectionHelper.IsHorizontal(Direction.East); // true
        ///     bool isNotHorizontal = DirectionHelper.IsHorizontal(Direction.North); // false
        ///     </code>
        /// </example>
        public static bool IsHorizontal(Direction direction)
        {
            if (direction == Direction.None)
                throw new ArgumentOutOfRangeException(nameof(direction), "Direction cannot be None");

            return direction == Direction.East || direction == Direction.West;
        }

        /// <summary>
        ///     Determines whether the direction is vertical (North or South).
        /// </summary>
        /// <param name="direction">The direction to check.</param>
        /// <returns>True if the direction is vertical; otherwise, false.</returns>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when direction is None.</exception>
        /// <example>
        ///     <code>
        ///     bool isVertical = DirectionHelper.IsVertical(Direction.North); // true
        ///     bool isNotVertical = DirectionHelper.IsVertical(Direction.East); // false
        ///     </code>
        /// </example>
        public static bool IsVertical(Direction direction)
        {
            if (direction == Direction.None)
                throw new ArgumentOutOfRangeException(nameof(direction), "Direction cannot be None");

            return direction == Direction.North || direction == Direction.South;
        }
    }
}

