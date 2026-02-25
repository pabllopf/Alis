// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DirectionTest.cs
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
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     Test class for <see cref="Direction"/> enum.
    /// </summary>
    public class DirectionTest
    {
        /// <summary>
        ///     Tests that north has value 0.
        /// </summary>
        [Fact]
        public void North_ShouldHaveValue0()
        {
            // Assert
            Assert.Equal(1, (int)Direction.North);
        }

        /// <summary>
        ///     Tests that east has value 1.
        /// </summary>
        [Fact]
        public void East_ShouldHaveValue1()
        {
            // Assert
            Assert.Equal(2, (int)Direction.East);
        }

        /// <summary>
        ///     Tests that south has value 2.
        /// </summary>
        [Fact]
        public void South_ShouldHaveValue2()
        {
            // Assert
            Assert.Equal(3, (int)Direction.South);
        }

        /// <summary>
        ///     Tests that west has value 3.
        /// </summary>
        [Fact]
        public void West_ShouldHaveValue3()
        {
            // Assert
            Assert.Equal(4, (int)Direction.West);
        }

        /// <summary>
        ///     Tests that all directions have distinct values.
        /// </summary>
        [Fact]
        public void AllDirections_ShouldHaveDistinctValues()
        {
            // Arrange
            var directions = new[]
            {
                Direction.North,
                Direction.East,
                Direction.South,
                Direction.West
            };

            // Act & Assert
            for (int i = 0; i < directions.Length; i++)
            {
                for (int j = i + 1; j < directions.Length; j++)
                {
                    Assert.NotEqual(directions[i], directions[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all enum values are defined.
        /// </summary>
        [Theory]
        [InlineData(Direction.North)]
        [InlineData(Direction.East)]
        [InlineData(Direction.South)]
        [InlineData(Direction.West)]
        public void EnumValue_ShouldBeDefined(Direction direction)
        {
            // Assert
            Assert.True(Enum.IsDefined(typeof(Direction), direction));
        }

        /// <summary>
        ///     Tests that direction can be converted to string.
        /// </summary>
        [Theory]
        [InlineData(Direction.North, "North")]
        [InlineData(Direction.East, "East")]
        [InlineData(Direction.South, "South")]
        [InlineData(Direction.West, "West")]
        public void ToString_ShouldReturnName(Direction direction, string expected)
        {
            // Act
            string result = direction.ToString();

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that direction values can be compared.
        /// </summary>
        [Fact]
        public void Comparison_ShouldWork()
        {
            // Arrange
            Direction north = Direction.North;
            Direction east = Direction.East;

            // Act & Assert
            Assert.True(north == Direction.North);
            Assert.True(east == Direction.East);
            Assert.False(north == east);
        }

        /// <summary>
        ///     Tests that there are exactly 4 directions.
        /// </summary>
        [Fact]
        public void EnumValues_ShouldHaveExactly4Directions()
        {
            // Act
            var directions = Enum.GetValues(typeof(Direction));

            // Assert
            Assert.Equal(5, directions.Length);
        }

        /// <summary>
        ///     Tests that direction can be parsed from string.
        /// </summary>
        [Theory]
        [InlineData("North", Direction.North)]
        [InlineData("East", Direction.East)]
        [InlineData("South", Direction.South)]
        [InlineData("West", Direction.West)]
        public void Parse_WithValidString_ShouldReturnDirection(string value, Direction expected)
        {
            // Act
            Direction result = Enum.Parse<Direction>(value);

            // Assert
            Assert.Equal(expected, result);
        }

        /// <summary>
        ///     Tests that parsing invalid string throws exception.
        /// </summary>
        [Fact]
        public void Parse_WithInvalidString_ShouldThrowException()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => Enum.Parse<Direction>("Invalid"));
        }
    }
}

