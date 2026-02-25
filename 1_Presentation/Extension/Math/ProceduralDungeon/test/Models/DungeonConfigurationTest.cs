// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonConfigurationTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Models
{
    /// <summary>
    ///     Test class for <see cref="DungeonConfiguration" />.
    /// </summary>
    public class DungeonConfigurationTest
    {
        /// <summary>
        ///     Tests that default constructor should initialize with default values.
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldInitializeWithDefaultValues()
        {
            // Act
            DungeonConfiguration config = new DungeonConfiguration();

            // Assert
            Assert.Equal(150, config.BoardWidth);
            Assert.Equal(150, config.BoardHeight);
            Assert.Equal(4, config.NumberOfRooms);
            Assert.Equal(8, config.FirstRoomWidth);
            Assert.Equal(8, config.FirstRoomHeight);
            Assert.Equal(5, config.RoomWidth);
            Assert.Equal(5, config.RoomHeight);
            Assert.Equal(7, config.BossRoomWidth);
            Assert.Equal(7, config.BossRoomHeight);
            Assert.Equal(4, config.CorridorWidth);
            Assert.Equal(4, config.CorridorHeight);
        }

        /// <summary>
        ///     Tests that parameterized constructor should initialize with custom values.
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_ShouldInitializeWithCustomValues()
        {
            // Arrange & Act
            DungeonConfiguration config = new DungeonConfiguration(
                boardWidth: 200,
                boardHeight: 200,
                numberOfRooms: 6,
                firstRoomWidth: 10,
                firstRoomHeight: 10,
                roomWidth: 6,
                roomHeight: 6,
                bossRoomWidth: 8,
                bossRoomHeight: 8,
                corridorWidth: 5,
                corridorHeight: 5
            );

            // Assert
            Assert.Equal(200, config.BoardWidth);
            Assert.Equal(200, config.BoardHeight);
            Assert.Equal(6, config.NumberOfRooms);
            Assert.Equal(10, config.FirstRoomWidth);
            Assert.Equal(10, config.FirstRoomHeight);
            Assert.Equal(6, config.RoomWidth);
            Assert.Equal(6, config.RoomHeight);
            Assert.Equal(8, config.BossRoomWidth);
            Assert.Equal(8, config.BossRoomHeight);
            Assert.Equal(5, config.CorridorWidth);
            Assert.Equal(5, config.CorridorHeight);
        }

        /// <summary>
        ///     Tests that validate should throw exception when board width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardWidthIsZero()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { BoardWidth = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when board width is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardWidthIsNegative()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { BoardWidth = -10 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when board height is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardHeightIsZero()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { BoardHeight = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when number of rooms is less than two.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenNumberOfRoomsIsLessThanTwo()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { NumberOfRooms = 1 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when first room width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenFirstRoomWidthIsZero()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { FirstRoomWidth = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when first room height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenFirstRoomHeightIsNegative()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { FirstRoomHeight = -5 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when room width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenRoomWidthIsZero()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { RoomWidth = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when boss room width is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBossRoomWidthIsNegative()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { BossRoomWidth = -3 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when corridor width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenCorridorWidthIsZero()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { CorridorWidth = 0 };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should not throw exception for valid configuration.
        /// </summary>
        [Fact]
        public void Validate_ShouldNotThrowException_ForValidConfiguration()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();

            // Act & Assert
            var exception = Record.Exception(() => config.Validate());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that parameterized constructor should call validate.
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_ShouldCallValidate()
        {
            // Act & Assert
            Assert.Throws<ArgumentException>(() => new DungeonConfiguration(
                boardWidth: -1,
                boardHeight: 150,
                numberOfRooms: 4,
                firstRoomWidth: 8,
                firstRoomHeight: 8,
                roomWidth: 5,
                roomHeight: 5,
                bossRoomWidth: 7,
                bossRoomHeight: 7,
                corridorWidth: 4,
                corridorHeight: 4
            ));
        }

        /// <summary>
        ///     Tests that properties should be mutable.
        /// </summary>
        [Fact]
        public void Properties_ShouldBeMutable()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();

            // Act
            config.BoardWidth = 250;
            config.BoardHeight = 300;
            config.NumberOfRooms = 8;

            // Assert
            Assert.Equal(250, config.BoardWidth);
            Assert.Equal(300, config.BoardHeight);
            Assert.Equal(8, config.NumberOfRooms);
        }
    }
}

