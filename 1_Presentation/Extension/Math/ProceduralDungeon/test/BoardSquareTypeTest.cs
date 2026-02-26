// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareTypeTest.cs
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
    ///     Test class for <see cref="BoardSquareType"/> enum.
    /// </summary>
    public class BoardSquareTypeTest
    {
        /// <summary>
        ///     Tests that empty has value 0.
        /// </summary>
        [Fact]
        public void Empty_ShouldHaveValue0()
        {
            // Assert
            Assert.Equal(0, (int)BoardSquareType.Empty);
        }

        /// <summary>
        ///     Tests that floor has value 1.
        /// </summary>
        [Fact]
        public void Floor_ShouldHaveValue1()
        {
            // Assert
            Assert.Equal(1, (int)BoardSquareType.Floor);
        }

        /// <summary>
        ///     Tests that all wall types have distinct values.
        /// </summary>
        [Fact]
        public void WallTypes_ShouldHaveDistinctValues()
        {
            // Arrange
            BoardSquareType[] wallTypes = new[]
            {
                BoardSquareType.WallTop,
                BoardSquareType.WallDown,
                BoardSquareType.WallLeft,
                BoardSquareType.WallRight
            };

            // Act & Assert
            for (int i = 0; i < wallTypes.Length; i++)
            {
                for (int j = i + 1; j < wallTypes.Length; j++)
                {
                    Assert.NotEqual(wallTypes[i], wallTypes[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all corner types have distinct values.
        /// </summary>
        [Fact]
        public void CornerTypes_ShouldHaveDistinctValues()
        {
            // Arrange
            BoardSquareType[] cornerTypes = new[]
            {
                BoardSquareType.CornerLeftUp,
                BoardSquareType.CornerLeftDown,
                BoardSquareType.CornerRightUp,
                BoardSquareType.CornerRightDown,
                BoardSquareType.CornerInternalLeftUp,
                BoardSquareType.CornerInternalLeftDown,
                BoardSquareType.CornerInternalRightUp,
                BoardSquareType.CornerInternalRightDown
            };

            // Act & Assert
            for (int i = 0; i < cornerTypes.Length; i++)
            {
                for (int j = i + 1; j < cornerTypes.Length; j++)
                {
                    Assert.NotEqual(cornerTypes[i], cornerTypes[j]);
                }
            }
        }

        /// <summary>
        ///     Tests that all enum values are defined.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.Empty)]
        [InlineData(BoardSquareType.Floor)]
        [InlineData(BoardSquareType.WallTop)]
        [InlineData(BoardSquareType.WallDown)]
        [InlineData(BoardSquareType.WallLeft)]
        [InlineData(BoardSquareType.WallRight)]
        [InlineData(BoardSquareType.CornerLeftUp)]
        [InlineData(BoardSquareType.CornerLeftDown)]
        [InlineData(BoardSquareType.CornerRightUp)]
        [InlineData(BoardSquareType.CornerRightDown)]
        [InlineData(BoardSquareType.CornerInternalLeftUp)]
        [InlineData(BoardSquareType.CornerInternalLeftDown)]
        [InlineData(BoardSquareType.CornerInternalRightUp)]
        [InlineData(BoardSquareType.CornerInternalRightDown)]
        public void EnumValue_ShouldBeDefined(BoardSquareType type)
        {
            // Assert
            Assert.True(Enum.IsDefined(typeof(BoardSquareType), type));
        }

        /// <summary>
        ///     Tests that enum can be converted to string.
        /// </summary>
        [Fact]
        public void ToString_ShouldReturnName()
        {
            // Arrange
            BoardSquareType type = BoardSquareType.Floor;

            // Act
            string result = type.ToString();

            // Assert
            Assert.Equal("Floor", result);
        }

        /// <summary>
        ///     Tests that enum values can be compared.
        /// </summary>
        [Fact]
        public void Comparison_ShouldWork()
        {
            // Arrange
            BoardSquareType empty = BoardSquareType.Empty;
            BoardSquareType floor = BoardSquareType.Floor;

            // Act & Assert
            Assert.True(empty == BoardSquareType.Empty);
            Assert.True(floor == BoardSquareType.Floor);
            Assert.False(empty == floor);
        }

        /// <summary>
        ///     Tests that all wall types are distinct from floor and empty.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.WallTop)]
        [InlineData(BoardSquareType.WallDown)]
        [InlineData(BoardSquareType.WallLeft)]
        [InlineData(BoardSquareType.WallRight)]
        public void WallTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType wallType)
        {
            // Assert
            Assert.NotEqual(BoardSquareType.Empty, wallType);
            Assert.NotEqual(BoardSquareType.Floor, wallType);
        }

        /// <summary>
        ///     Tests that all corner types are distinct from floor and empty.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.CornerLeftUp)]
        [InlineData(BoardSquareType.CornerLeftDown)]
        [InlineData(BoardSquareType.CornerRightUp)]
        [InlineData(BoardSquareType.CornerRightDown)]
        public void OuterCornerTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType cornerType)
        {
            // Assert
            Assert.NotEqual(BoardSquareType.Empty, cornerType);
            Assert.NotEqual(BoardSquareType.Floor, cornerType);
        }

        /// <summary>
        ///     Tests that all internal corner types are distinct from floor and empty.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.CornerInternalLeftUp)]
        [InlineData(BoardSquareType.CornerInternalLeftDown)]
        [InlineData(BoardSquareType.CornerInternalRightUp)]
        [InlineData(BoardSquareType.CornerInternalRightDown)]
        public void InternalCornerTypes_ShouldBeDistinctFromFloorAndEmpty(BoardSquareType cornerType)
        {
            // Assert
            Assert.NotEqual(BoardSquareType.Empty, cornerType);
            Assert.NotEqual(BoardSquareType.Floor, cornerType);
        }
    }
}

