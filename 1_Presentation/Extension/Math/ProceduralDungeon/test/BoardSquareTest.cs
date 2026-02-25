// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareTest.cs
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

using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     Test class for <see cref="BoardSquare"/> struct.
    /// </summary>
    public class BoardSquareTest
    {

        /// <summary>
        ///     Tests that board square can be created with specific type.
        /// </summary>
        [Fact]
        public void Constructor_WithType_ShouldSetType()
        {
            // Arrange & Act
            BoardSquare square = new BoardSquare { Type = BoardSquareType.Floor };

            // Assert
            Assert.Equal(BoardSquareType.Floor, square.Type);
        }

        /// <summary>
        ///     Tests that board square type can be changed.
        /// </summary>
        [Fact]
        public void Type_CanBeModified()
        {
            // Arrange
            BoardSquare square = new BoardSquare { Type = BoardSquareType.Empty };

            // Act
            square.Type = BoardSquareType.WallTop;

            // Assert
            Assert.Equal(BoardSquareType.WallTop, square.Type);
        }

        /// <summary>
        ///     Tests that board square with floor type is walkable.
        /// </summary>
        [Fact]
        public void Floor_ShouldBeWalkable()
        {
            // Arrange
            BoardSquare square = new BoardSquare { Type = BoardSquareType.Floor };

            // Assert
            Assert.Equal(BoardSquareType.Floor, square.Type);
        }

        /// <summary>
        ///     Tests that board square with wall type is not floor.
        /// </summary>
        [Fact]
        public void Wall_ShouldNotBeFloor()
        {
            // Arrange
            BoardSquare square = new BoardSquare { Type = BoardSquareType.WallTop };

            // Assert
            Assert.NotEqual(BoardSquareType.Floor, square.Type);
        }

        /// <summary>
        ///     Tests that board square can be set to all corner types.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.CornerLeftUp)]
        [InlineData(BoardSquareType.CornerLeftDown)]
        [InlineData(BoardSquareType.CornerRightUp)]
        [InlineData(BoardSquareType.CornerRightDown)]
        [InlineData(BoardSquareType.CornerInternalLeftUp)]
        [InlineData(BoardSquareType.CornerInternalLeftDown)]
        [InlineData(BoardSquareType.CornerInternalRightUp)]
        [InlineData(BoardSquareType.CornerInternalRightDown)]
        public void CornerTypes_CanBeSet(BoardSquareType cornerType)
        {
            // Arrange & Act
            BoardSquare square = new BoardSquare { Type = cornerType };

            // Assert
            Assert.Equal(cornerType, square.Type);
        }

        /// <summary>
        ///     Tests that board square can be set to all wall types.
        /// </summary>
        [Theory]
        [InlineData(BoardSquareType.WallTop)]
        [InlineData(BoardSquareType.WallDown)]
        [InlineData(BoardSquareType.WallLeft)]
        [InlineData(BoardSquareType.WallRight)]
        public void WallTypes_CanBeSet(BoardSquareType wallType)
        {
            // Arrange & Act
            BoardSquare square = new BoardSquare { Type = wallType };

            // Assert
            Assert.Equal(wallType, square.Type);
        }

        /// <summary>
        ///     Tests that two board squares with same type are equal.
        /// </summary>
        [Fact]
        public void Equals_WithSameType_ShouldReturnTrue()
        {
            // Arrange
            BoardSquare square1 = new BoardSquare { Type = BoardSquareType.Floor };
            BoardSquare square2 = new BoardSquare { Type = BoardSquareType.Floor };

            // Act & Assert
            Assert.Equal(square1.Type, square2.Type);
        }

        /// <summary>
        ///     Tests that two board squares with different types are not equal.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentType_ShouldReturnFalse()
        {
            // Arrange
            BoardSquare square1 = new BoardSquare { Type = BoardSquareType.Floor };
            BoardSquare square2 = new BoardSquare { Type = BoardSquareType.Empty };

            // Act & Assert
            Assert.NotEqual(square1.Type, square2.Type);
        }

        /// <summary>
        ///     Tests that board square can change from empty to floor.
        /// </summary>
        [Fact]
        public void Type_CanChangeFromEmptyToFloor()
        {
            // Arrange
            BoardSquare square = new BoardSquare { Type = BoardSquareType.Empty };

            // Act
            square.Type = BoardSquareType.Floor;

            // Assert
            Assert.Equal(BoardSquareType.Floor, square.Type);
        }

        /// <summary>
        ///     Tests that board square can change from floor to wall.
        /// </summary>
        [Fact]
        public void Type_CanChangeFromFloorToWall()
        {
            // Arrange
            BoardSquare square = new BoardSquare { Type = BoardSquareType.Floor };

            // Act
            square.Type = BoardSquareType.WallTop;

            // Assert
            Assert.Equal(BoardSquareType.WallTop, square.Type);
        }
    }
}

