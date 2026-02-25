// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CorridorFactoryTest.cs
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
    ///     Test class for <see cref="CorridorFactory" />.
    /// </summary>
    public class CorridorFactoryTest
    {
        /// <summary>
        ///     Tests that constructor should throw exception when random number generator is null.
        /// </summary>
        [Fact]
        public void Constructor_ShouldThrowException_WhenRandomNumberGeneratorIsNull()
        {
            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new CorridorFactory(null));
        }

        /// <summary>
        ///     Tests that create first corridor should create corridor with north direction.
        /// </summary>
        [Fact]
        public void CreateFirstCorridor_ShouldCreateCorridorWithNorthDirection()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1); // Direction.North
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);
            int width = 4;
            int height = 4;

            // Act
            CorridorData corridor = factory.CreateFirstCorridor(width, height, room);

            // Assert
            Assert.Equal(12, corridor.XPos); // room.XPos + room.Width / 2 - width / 2
            Assert.Equal(18, corridor.YPos); // room.YPos + room.Height
            Assert.Equal(width, corridor.Width);
            Assert.Equal(height, corridor.Height);
            Assert.Equal(Direction.North, corridor.Direction);
        }




        /// <summary>
        ///     Tests that create first corridor should create corridor with west direction.
        /// </summary>
        [Fact]
        public void CreateFirstCorridor_ShouldCreateCorridorWithWestDirection()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(4); // Direction.West
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);
            int width = 4;
            int height = 4;

            // Act
            CorridorData corridor = factory.CreateFirstCorridor(width, height, room);

            // Assert
            Assert.Equal(18, corridor.XPos); // room.XPos + room.Width
            Assert.Equal(12, corridor.YPos);
            Assert.Equal(height, corridor.Width);
            Assert.Equal(width, corridor.Height);
            Assert.Equal(Direction.West, corridor.Direction);
        }



        /// <summary>
        ///     Tests that create first corridor should throw exception when width is zero.
        /// </summary>
        [Fact]
        public void CreateFirstCorridor_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstCorridor(0, 4, room));
        }

        /// <summary>
        ///     Tests that create first corridor should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateFirstCorridor_ShouldThrowException_WhenHeightIsNegative()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateFirstCorridor(4, -3, room));
        }

        /// <summary>
        ///     Tests that create corridor should throw exception when width is zero.
        /// </summary>
        [Fact]
        public void CreateCorridor_ShouldThrowException_WhenWidthIsZero()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCorridor(0, 4, room));
        }

        /// <summary>
        ///     Tests that create corridor should throw exception when height is negative.
        /// </summary>
        [Fact]
        public void CreateCorridor_ShouldThrowException_WhenHeightIsNegative()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator();
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);

            // Act & Assert
            Assert.Throws<ArgumentException>(() => factory.CreateCorridor(4, -5, room));
        }

        /// <summary>
        ///     Tests that create corridor should use room direction to avoid opposite.
        /// </summary>
        [Fact]
        public void CreateCorridor_ShouldUseRoomDirectionToAvoidOpposite()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(3); // Direction.East
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.East, false);

            // Act
            CorridorData corridor = factory.CreateCorridor(4, 4, room);

            // Assert - Should not be West (opposite of East)
            Assert.NotEqual(Direction.West, corridor.Direction);
        }

        /// <summary>
        ///     Tests that multiple corridors should potentially have different directions.
        /// </summary>
        [Fact]
        public void MultipleCalls_ShouldPotentiallyHaveDifferentDirections()
        {
            // Arrange
            MockRandomNumberGenerator mockRng = new MockRandomNumberGenerator(1);
            CorridorFactory factory = new CorridorFactory(mockRng);
            RoomData room = new RoomData(10, 10, 8, 8, Direction.North, false);

            // Act
            mockRng.SetValue(1);
            CorridorData corridor1 = factory.CreateFirstCorridor(4, 4, room);
            
            mockRng.SetValue(2);
            CorridorData corridor2 = factory.CreateFirstCorridor(4, 4, room);

            // Assert
            Assert.NotEqual(corridor1.Direction, corridor2.Direction);
        }
    }
}

