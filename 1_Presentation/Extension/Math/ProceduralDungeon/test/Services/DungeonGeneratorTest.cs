// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonGeneratorTest.cs
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
using Alis.Extension.Math.ProceduralDungeon.Services;
using Alis.Extension.Math.ProceduralDungeon.Test.Mocks;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test.Services
{
    /// <summary>
    ///     Test class for <see cref="DungeonGenerator" />.
    /// </summary>
    public class DungeonGeneratorTest
    {
        /// <summary>
        ///     Tests that constructor should throw exception when configuration is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowException_WhenConfigurationIsNull()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonGenerator(null, roomFactory, corridorFactory, boardBuilder));
        }

        /// <summary>
        ///     Tests that constructor should throw exception when room factory is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowException_WhenRoomFactoryIsNull()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonGenerator(config, null, corridorFactory, boardBuilder));
        }

        /// <summary>
        ///     Tests that constructor should throw exception when corridor factory is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowException_WhenCorridorFactoryIsNull()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            RoomFactory roomFactory = new RoomFactory();
            BoardBuilder boardBuilder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonGenerator(config, roomFactory, null, boardBuilder));
        }

        /// <summary>
        ///     Tests that constructor should throw exception when board builder is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowException_WhenBoardBuilderIsNull()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new DungeonGenerator(config, roomFactory, corridorFactory, null));
        }

        /// <summary>
        ///     Tests that constructor should validate configuration.
        /// </summary>
        [Fact]
        public void Constructor_ShouldValidateConfiguration()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { BoardWidth = -1 };
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder));
        }

        /// <summary>
        ///     Tests that generate should return dungeon data.
        /// </summary>
        [Fact]
        public void Generate_ShouldReturnDungeonData()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert
            Assert.NotNull(dungeon);
            Assert.NotNull(dungeon.Board);
            Assert.NotNull(dungeon.Rooms);
            Assert.NotNull(dungeon.Corridors);
        }

        /// <summary>
        ///     Tests that generate should create correct number of rooms.
        /// </summary>
        [Fact]
        public void Generate_ShouldCreateCorrectNumberOfRooms()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { NumberOfRooms = 5 };
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert
            Assert.Equal(5, dungeon.Rooms.Count);
        }

        /// <summary>
        ///     Tests that generate should create board with correct dimensions.
        /// </summary>
        [Fact]
        public void Generate_ShouldCreateBoardWithCorrectDimensions()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 100,
                BoardHeight = 120
            };
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert
            Assert.Equal(100, dungeon.Width);
            Assert.Equal(120, dungeon.Height);
        }

        /// <summary>
        ///     Tests that generate should create first room at center.
        /// </summary>
        [Fact]
        public void Generate_ShouldCreateFirstRoomAtCenter()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 150,
                BoardHeight = 150,
                FirstRoomWidth = 8,
                FirstRoomHeight = 8
            };
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert
            RoomData firstRoom = dungeon.Rooms[0];
            Assert.Equal(75, firstRoom.XPos); // BoardWidth / 2
            Assert.Equal(75, firstRoom.YPos); // BoardHeight / 2
        }

        /// <summary>
        ///     Tests that generate should create boss room as last room.
        /// </summary>
        [Fact]
        public void Generate_ShouldCreateBossRoomAsLastRoom()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration { NumberOfRooms = 4 };
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert
            RoomData lastRoom = dungeon.Rooms[dungeon.Rooms.Count - 1];
            Assert.True(lastRoom.IsBossRoom);
        }

        /// <summary>
        ///     Tests that generate should place rooms on board.
        /// </summary>
        [Fact]
        public void Generate_ShouldPlaceRoomsOnBoard()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert - Check that some floor squares exist
            bool hasFloorSquares = false;
            for (int x = 0; x < dungeon.Width && !hasFloorSquares; x++)
            {
                for (int y = 0; y < dungeon.Height && !hasFloorSquares; y++)
                {
                    if (dungeon.Board[x, y].Type == BoardSquareType.Floor)
                    {
                        hasFloorSquares = true;
                    }
                }
            }
            Assert.True(hasFloorSquares);
        }

        /// <summary>
        ///     Tests that generate should generate walls and corners.
        /// </summary>
        [Fact]
        public void Generate_ShouldGenerateWallsAndCorners()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory = new CorridorFactory(mockRng);
            BoardBuilder boardBuilder = new BoardBuilder();
            DungeonGenerator generator = new DungeonGenerator(config, roomFactory, corridorFactory, boardBuilder);

            // Act
            DungeonData dungeon = generator.Generate();

            // Assert - Check that wall types exist
            bool hasWalls = false;
            for (int x = 0; x < dungeon.Width && !hasWalls; x++)
            {
                for (int y = 0; y < dungeon.Height && !hasWalls; y++)
                {
                    BoardSquareType type = dungeon.Board[x, y].Type;
                    if (type != BoardSquareType.Empty && type != BoardSquareType.Floor)
                    {
                        hasWalls = true;
                    }
                }
            }
            Assert.True(hasWalls);
        }

        /// <summary>
        ///     Tests that multiple generate calls should produce different dungeons.
        /// </summary>
        [Fact]
        public void MultipleGenerateCalls_ShouldProduceDifferentDungeons()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration();
            MockRandomNumberGenerator mockRng1 = new MockRandomNumberGenerator(1);
            MockRandomNumberGenerator mockRng2 = new MockRandomNumberGenerator(2);
            
            RoomFactory roomFactory = new RoomFactory();
            CorridorFactory corridorFactory1 = new CorridorFactory(mockRng1);
            CorridorFactory corridorFactory2 = new CorridorFactory(mockRng2);
            BoardBuilder boardBuilder = new BoardBuilder();
            
            DungeonGenerator generator1 = new DungeonGenerator(config, roomFactory, corridorFactory1, boardBuilder);
            DungeonGenerator generator2 = new DungeonGenerator(config, roomFactory, corridorFactory2, boardBuilder);

            // Act
            DungeonData dungeon1 = generator1.Generate();
            DungeonData dungeon2 = generator2.Generate();

            // Assert - At least one corridor should have a different direction
            bool hasDifference = false;
            for (int i = 0; i < dungeon1.Corridors.Count; i++)
            {
                if (dungeon1.Corridors[i].Direction != dungeon2.Corridors[i].Direction)
                {
                    hasDifference = true;
                    break;
                }
            }
            Assert.True(hasDifference);
        }
    }
}

