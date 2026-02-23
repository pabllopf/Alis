// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DimensionsValidator.cs
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

namespace Alis.Extension.Math.ProceduralDungeon.Validators
{
    /// <summary>
    ///     Validator class for dimension-related values.
    ///     Provides centralized validation logic for width, height, and position values.
    /// </summary>
    /// <remarks>
    ///     This class follows the Single Responsibility Principle by focusing solely
    ///     on dimension validation. Centralizing validation logic improves consistency
    ///     and makes it easier to maintain validation rules.
    /// </remarks>
    public static class DimensionsValidator
    {
        /// <summary>
        ///     Validates that width and height are positive values.
        /// </summary>
        /// <param name="width">The width to validate.</param>
        /// <param name="height">The height to validate.</param>
        /// <param name="widthParamName">The parameter name for width (for exception messages).</param>
        /// <param name="heightParamName">The parameter name for height (for exception messages).</param>
        /// <exception cref="ArgumentException">Thrown when width or height is not positive.</exception>
        /// <example>
        ///     <code>
        ///     DimensionsValidator.ValidateDimensions(10, 20, nameof(width), nameof(height));
        ///     </code>
        /// </example>
        public static void ValidateDimensions(int width, int height, string widthParamName = "width", string heightParamName = "height")
        {
            if (width <= 0)
                throw new ArgumentException("Width must be greater than 0.", widthParamName);
            
            if (height <= 0)
                throw new ArgumentException("Height must be greater than 0.", heightParamName);
        }

        /// <summary>
        ///     Validates that a position is non-negative.
        /// </summary>
        /// <param name="x">The x coordinate to validate.</param>
        /// <param name="y">The y coordinate to validate.</param>
        /// <param name="xParamName">The parameter name for x (for exception messages).</param>
        /// <param name="yParamName">The parameter name for y (for exception messages).</param>
        /// <exception cref="ArgumentException">Thrown when x or y is negative.</exception>
        /// <example>
        ///     <code>
        ///     DimensionsValidator.ValidatePosition(5, 10, nameof(x), nameof(y));
        ///     </code>
        /// </example>
        public static void ValidatePosition(int x, int y, string xParamName = "x", string yParamName = "y")
        {
            if (x < 0)
                throw new ArgumentException("X position must be non-negative.", xParamName);
            
            if (y < 0)
                throw new ArgumentException("Y position must be non-negative.", yParamName);
        }

        /// <summary>
        ///     Validates that a value is positive.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="paramName">The parameter name (for exception messages).</param>
        /// <exception cref="ArgumentException">Thrown when value is not positive.</exception>
        /// <example>
        ///     <code>
        ///     DimensionsValidator.ValidatePositive(5, nameof(count));
        ///     </code>
        /// </example>
        public static void ValidatePositive(int value, string paramName)
        {
            if (value <= 0)
                throw new ArgumentException($"{paramName} must be greater than 0.", paramName);
        }

        /// <summary>
        ///     Validates that a value is within a specified range.
        /// </summary>
        /// <param name="value">The value to validate.</param>
        /// <param name="min">The minimum allowed value (inclusive).</param>
        /// <param name="max">The maximum allowed value (inclusive).</param>
        /// <param name="paramName">The parameter name (for exception messages).</param>
        /// <exception cref="ArgumentOutOfRangeException">Thrown when value is outside the range.</exception>
        /// <example>
        ///     <code>
        ///     DimensionsValidator.ValidateRange(5, 1, 10, nameof(roomCount));
        ///     </code>
        /// </example>
        public static void ValidateRange(int value, int min, int max, string paramName)
        {
            if (value < min || value > max)
                throw new ArgumentOutOfRangeException(paramName, value, 
                    $"{paramName} must be between {min} and {max}.");
        }

        /// <summary>
        ///     Validates that dimensions fit within board bounds.
        /// </summary>
        /// <param name="x">The x position.</param>
        /// <param name="y">The y position.</param>
        /// <param name="width">The width of the element.</param>
        /// <param name="height">The height of the element.</param>
        /// <param name="boardWidth">The width of the board.</param>
        /// <param name="boardHeight">The height of the board.</param>
        /// <exception cref="ArgumentException">Thrown when element would exceed board bounds.</exception>
        /// <example>
        ///     <code>
        ///     DimensionsValidator.ValidateWithinBounds(10, 10, 5, 5, 50, 50);
        ///     </code>
        /// </example>
        public static void ValidateWithinBounds(int x, int y, int width, int height, int boardWidth, int boardHeight)
        {
            if (x < 0 || y < 0)
                throw new ArgumentException("Position must be non-negative.");

            if (x + width > boardWidth)
                throw new ArgumentException($"Element exceeds board width. Position: {x}, Width: {width}, Board Width: {boardWidth}");

            if (y + height > boardHeight)
                throw new ArgumentException($"Element exceeds board height. Position: {y}, Height: {height}, Board Height: {boardHeight}");
        }
    }
}

