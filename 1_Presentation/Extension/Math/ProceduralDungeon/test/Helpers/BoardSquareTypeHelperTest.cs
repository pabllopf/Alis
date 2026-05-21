// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoardSquareTypeHelperTest.cs
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

using Alis.Extension.Math.ProceduralDungeon.Helpers;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Helpers
{
    /// <summary>
    ///     Test class for <see cref="BoardSquareTypeHelper" />.
    ///     Verifies all board square type classification and utility methods.
    /// </summary>
    public class BoardSquareTypeHelperTest
    {
        /// <summary>
        ///     Tests that IsWall returns true for all wall types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.WallDown), InlineData(BoardSquareType.WallLeft), InlineData(BoardSquareType.WallRight), InlineData(BoardSquareType.WallTop)]
        public void IsWall_WithWallType_ReturnsTrue(BoardSquareType type)
        {
            bool isWall = BoardSquareTypeHelper.IsWall(type);

            Assert.True(isWall);
        }

        /// <summary>
        ///     Tests that IsWall returns false for non-wall types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerInternalLeftUp)]
        public void IsWall_WithNonWallType_ReturnsFalse(BoardSquareType type)
        {
            bool isWall = BoardSquareTypeHelper.IsWall(type);

            Assert.False(isWall);
        }

        /// <summary>
        ///     Tests that IsCorner returns true for all corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerRightUp), InlineData(BoardSquareType.CornerLeftDown), InlineData(BoardSquareType.CornerRightDown), InlineData(BoardSquareType.CornerInternalLeftUp), InlineData(BoardSquareType.CornerInternalRightUp), InlineData(BoardSquareType.CornerInternalLeftDown),
         InlineData(BoardSquareType.CornerInternalRightDown)]
        public void IsCorner_WithCornerType_ReturnsTrue(BoardSquareType type)
        {
            bool isCorner = BoardSquareTypeHelper.IsCorner(type);

            Assert.True(isCorner);
        }

        /// <summary>
        ///     Tests that IsCorner returns false for non-corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.WallTop)]
        public void IsCorner_WithNonCornerType_ReturnsFalse(BoardSquareType type)
        {
            bool isCorner = BoardSquareTypeHelper.IsCorner(type);

            Assert.False(isCorner);
        }

        /// <summary>
        ///     Tests that IsOuterCorner returns true for outer corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerRightUp), InlineData(BoardSquareType.CornerLeftDown), InlineData(BoardSquareType.CornerRightDown)]
        public void IsOuterCorner_WithOuterCornerType_ReturnsTrue(BoardSquareType type)
        {
            bool isOuterCorner = BoardSquareTypeHelper.IsOuterCorner(type);

            Assert.True(isOuterCorner);
        }

        /// <summary>
        ///     Tests that IsOuterCorner returns false for non-outer corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.CornerInternalLeftUp)]
        public void IsOuterCorner_WithNonOuterCornerType_ReturnsFalse(BoardSquareType type)
        {
            bool isOuterCorner = BoardSquareTypeHelper.IsOuterCorner(type);

            Assert.False(isOuterCorner);
        }

        /// <summary>
        ///     Tests that IsInnerCorner returns true for inner corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerInternalLeftUp), InlineData(BoardSquareType.CornerInternalRightUp), InlineData(BoardSquareType.CornerInternalLeftDown), InlineData(BoardSquareType.CornerInternalRightDown)]
        public void IsInnerCorner_WithInnerCornerType_ReturnsTrue(BoardSquareType type)
        {
            bool isInnerCorner = BoardSquareTypeHelper.IsInnerCorner(type);

            Assert.True(isInnerCorner);
        }

        /// <summary>
        ///     Tests that IsInnerCorner returns false for non-inner corner types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.CornerLeftUp)]
        public void IsInnerCorner_WithNonInnerCornerType_ReturnsFalse(BoardSquareType type)
        {
            bool isInnerCorner = BoardSquareTypeHelper.IsInnerCorner(type);

            Assert.False(isInnerCorner);
        }

        /// <summary>
        ///     Tests that IsWalkable returns true only for Floor type.
        /// </summary>
        [Fact]
        public void IsWalkable_WithFloor_ReturnsTrue()
        {
            BoardSquareType type = BoardSquareType.Floor;

            bool isWalkable = BoardSquareTypeHelper.IsWalkable(type);

            Assert.True(isWalkable);
        }

        /// <summary>
        ///     Tests that IsWalkable returns false for non-floor types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.CornerLeftUp)]
        public void IsWalkable_WithNonFloorType_ReturnsFalse(BoardSquareType type)
        {
            bool isWalkable = BoardSquareTypeHelper.IsWalkable(type);

            Assert.False(isWalkable);
        }

        /// <summary>
        ///     Tests that IsEmpty returns true only for Empty type.
        /// </summary>
        [Fact]
        public void IsEmpty_WithEmpty_ReturnsTrue()
        {
            BoardSquareType type = BoardSquareType.Empty;

            bool isEmpty = BoardSquareTypeHelper.IsEmpty(type);

            Assert.True(isEmpty);
        }

        /// <summary>
        ///     Tests that IsEmpty returns false for non-empty types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Floor), InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.CornerLeftUp)]
        public void IsEmpty_WithNonEmptyType_ReturnsFalse(BoardSquareType type)
        {
            bool isEmpty = BoardSquareTypeHelper.IsEmpty(type);

            Assert.False(isEmpty);
        }

        /// <summary>
        ///     Tests that IsSolid returns true for walls and corners.
        /// </summary>
        [Theory, InlineData(BoardSquareType.WallTop), InlineData(BoardSquareType.WallDown), InlineData(BoardSquareType.WallLeft), InlineData(BoardSquareType.WallRight), InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerInternalLeftUp)]
        public void IsSolid_WithSolidType_ReturnsTrue(BoardSquareType type)
        {
            bool isSolid = BoardSquareTypeHelper.IsSolid(type);

            Assert.True(isSolid);
        }

        /// <summary>
        ///     Tests that IsSolid returns false for non-solid types.
        /// </summary>
        [Theory, InlineData(BoardSquareType.Empty), InlineData(BoardSquareType.Floor)]
        public void IsSolid_WithNonSolidType_ReturnsFalse(BoardSquareType type)
        {
            bool isSolid = BoardSquareTypeHelper.IsSolid(type);

            Assert.False(isSolid);
        }

        /// <summary>
        ///     Tests that GetDisplayCharacter returns correct character for Empty.
        /// </summary>
        [Fact]
        public void GetDisplayCharacter_WithEmpty_ReturnsDot()
        {
            BoardSquareType type = BoardSquareType.Empty;

            char character = BoardSquareTypeHelper.GetDisplayCharacter(type);

            Assert.Equal('.', character);
        }

        /// <summary>
        ///     Tests that GetDisplayCharacter returns correct character for Floor.
        /// </summary>
        [Fact]
        public void GetDisplayCharacter_WithFloor_ReturnsSpace()
        {
            BoardSquareType type = BoardSquareType.Floor;

            char character = BoardSquareTypeHelper.GetDisplayCharacter(type);

            Assert.Equal(' ', character);
        }

        /// <summary>
        ///     Tests that GetDisplayCharacter returns correct character for walls.
        /// </summary>
        [Theory, InlineData(BoardSquareType.WallDown), InlineData(BoardSquareType.WallLeft), InlineData(BoardSquareType.WallRight), InlineData(BoardSquareType.WallTop)]
        public void GetDisplayCharacter_WithWall_ReturnsHash(BoardSquareType type)
        {
            char character = BoardSquareTypeHelper.GetDisplayCharacter(type);

            Assert.Equal('#', character);
        }

        /// <summary>
        ///     Tests that GetDisplayCharacter returns correct character for corners.
        /// </summary>
        [Theory, InlineData(BoardSquareType.CornerLeftUp), InlineData(BoardSquareType.CornerRightUp), InlineData(BoardSquareType.CornerLeftDown), InlineData(BoardSquareType.CornerRightDown), InlineData(BoardSquareType.CornerInternalLeftUp), InlineData(BoardSquareType.CornerInternalRightUp), InlineData(BoardSquareType.CornerInternalLeftDown),
         InlineData(BoardSquareType.CornerInternalRightDown)]
        public void GetDisplayCharacter_WithCorner_ReturnsPlus(BoardSquareType type)
        {
            char character = BoardSquareTypeHelper.GetDisplayCharacter(type);

            Assert.Equal('+', character);
        }

        /// <summary>
        ///     Tests that GetDisplayCharacter returns question mark for unknown type.
        /// </summary>
        [Fact]
        public void GetDisplayCharacter_WithUnknownType_ReturnsQuestionMark()
        {
            BoardSquareType type = (BoardSquareType) 999;

            char character = BoardSquareTypeHelper.GetDisplayCharacter(type);

            Assert.Equal('?', character);
        }
    }
}