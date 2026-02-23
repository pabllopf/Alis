// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DungeonTest.cs
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

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     Test class for <see cref="Dungeon" />.
    ///     Verifies the main facade class functionality.
    /// </summary>
    public class DungeonTest
    {
        /// <summary>
        ///     Tests that default constructor creates a valid dungeon.
        /// </summary>
        [Fact]
        public void Constructor_Default_CreatesValidInstance()
        {
            // Act
            using Dungeon dungeon = new Dungeon();

            // Assert
            Assert.NotNull(dungeon);
        }

        /// <summary>
        ///     Tests that constructor with configuration creates a valid dungeon.
        /// </summary>
        [Fact]
        public void Constructor_WithConfiguration_CreatesValidInstance()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 100,
                BoardHeight = 100,
                NumberOfRooms = 5
            };

            // Act
            using Dungeon dungeon = new Dungeon(config);

            // Assert
            Assert.NotNull(dungeon);
        }

        /// <summary>
        ///     Tests that constructor throws exception with null configuration.
        /// </summary>
        [Fact]
        public void Constructor_WithNullConfiguration_ThrowsArgumentNullException()
        {
            // Arrange
            DungeonConfiguration config = null;

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new Dungeon(config));
        }

        /// <summary>
        ///     Tests that constructor throws exception with invalid configuration.
        /// </summary>
        [Fact]
        public void Constructor_WithInvalidConfiguration_ThrowsArgumentException()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = -100,
                BoardHeight = 100
            };

            // Act & Assert
            Assert.Throws<ArgumentException>(() => new Dungeon(config));
        }

        /// <summary>
        ///     Tests that Generate returns valid dungeon data.
        /// </summary>
        [Fact]
        public void Generate_ReturnsValidDungeonData()
        {
            // Arrange
            using Dungeon dungeon = new Dungeon();

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            Assert.NotNull(data);
            Assert.NotNull(data.Board);
            Assert.NotNull(data.Rooms);
            Assert.NotNull(data.Corridors);
            Assert.True(data.Width > 0);
            Assert.True(data.Height > 0);
        }

        /// <summary>
        ///     Tests that Generate creates expected number of rooms.
        /// </summary>
        [Fact]
        public void Generate_CreatesExpectedNumberOfRooms()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                NumberOfRooms = 5
            };
            using Dungeon dungeon = new Dungeon(config);

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            Assert.Equal(5, data.Rooms.Count);
        }

        /// <summary>
        ///     Tests that Generate creates expected number of corridors.
        /// </summary>
        [Fact]
        public void Generate_CreatesExpectedNumberOfCorridors()
        {
            // Arrange
            DungeonConfiguration config = new DungeonConfiguration
            {
                NumberOfRooms = 5
            };
            using Dungeon dungeon = new Dungeon(config);

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            Assert.Equal(5, data.Corridors.Count); // Number of rooms = number of corridors
        }

        /// <summary>
        ///     Tests that Generate creates a boss room.
        /// </summary>
        [Fact]
        public void Generate_CreatesBossRoom()
        {
            // Arrange
            using Dungeon dungeon = new Dungeon();

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            bool hasBossRoom = false;
            foreach (RoomData room in data.Rooms)
            {
                if (room.IsBossRoom)
                {
                    hasBossRoom = true;
                    break;
                }
            }
            Assert.True(hasBossRoom);
        }

        /// <summary>
        ///     Tests that Generate can be called multiple times.
        /// </summary>
        [Fact]
        public void Generate_CalledMultipleTimes_ReturnsNewDungeons()
        {
            // Arrange
            using Dungeon dungeon = new Dungeon();

            // Act
            DungeonData data1 = dungeon.Generate();
            DungeonData data2 = dungeon.Generate();

            // Assert
            Assert.NotSame(data1, data2);
            Assert.NotSame(data1.Rooms, data2.Rooms);
            Assert.NotSame(data1.Corridors, data2.Corridors);
        }
        

        /// <summary>
        ///     Tests that Dispose can be called multiple times safely.
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            // Arrange
            Dungeon dungeon = new Dungeon();

            // Act & Assert
            dungeon.Dispose();
            dungeon.Dispose(); // Should not throw
        }

        /// <summary>
        ///     Tests that dungeon generation respects board size configuration.
        /// </summary>
        [Fact]
        public void Generate_RespectsConfiguredBoardSize()
        {
            // Arrange
            int width = 200;
            int height = 250;
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = width,
                BoardHeight = height
            };
            using Dungeon dungeon = new Dungeon(config);

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            Assert.Equal(width, data.Width);
            Assert.Equal(height, data.Height);
        }

        /// <summary>
        ///     Tests that generated dungeon has valid board with all squares initialized.
        /// </summary>
        [Fact]
        public void Generate_CreatesValidBoardWithInitializedSquares()
        {
            // Arrange
            using Dungeon dungeon = new Dungeon();

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            for (int x = 0; x < data.Width; x++)
            {
                for (int y = 0; y < data.Height; y++)
                {
                    Assert.NotNull(data.Board[x, y]);
                }
            }
        }

        /// <summary>
        ///     Tests that generated dungeon has at least one floor tile.
        /// </summary>
        [Fact]
        public void Generate_CreatesAtLeastOneFloorTile()
        {
            // Arrange
            using Dungeon dungeon = new Dungeon();

            // Act
            DungeonData data = dungeon.Generate();

            // Assert
            bool hasFloor = false;
            for (int x = 0; x < data.Width; x++)
            {
                for (int y = 0; y < data.Height; y++)
                {
                    if (data.Board[x, y].Type == BoardSquareType.Floor)
                    {
                        hasFloor = true;
                        break;
                    }
                }
                if (hasFloor) break;
            }
            Assert.True(hasFloor);
        }
    }
}

