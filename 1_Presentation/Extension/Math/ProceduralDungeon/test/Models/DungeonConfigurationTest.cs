

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
            DungeonConfiguration config = new DungeonConfiguration();

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
            DungeonConfiguration config = new DungeonConfiguration(
                200,
                200,
                6,
                10,
                10,
                6,
                6,
                8,
                8,
                5,
                5
            );

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
            DungeonConfiguration config = new DungeonConfiguration {BoardWidth = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when board width is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardWidthIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {BoardWidth = -10};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when board height is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardHeightIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {BoardHeight = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when number of rooms is less than two.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenNumberOfRoomsIsLessThanTwo()
        {
            DungeonConfiguration config = new DungeonConfiguration {NumberOfRooms = 1};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when first room width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenFirstRoomWidthIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {FirstRoomWidth = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when first room height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenFirstRoomHeightIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {FirstRoomHeight = -5};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when room width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenRoomWidthIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {RoomWidth = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when boss room width is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBossRoomWidthIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {BossRoomWidth = -3};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when corridor width is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenCorridorWidthIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {CorridorWidth = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should not throw exception for valid configuration.
        /// </summary>
        [Fact]
        public void Validate_ShouldNotThrowException_ForValidConfiguration()
        {
            DungeonConfiguration config = new DungeonConfiguration();

            Exception exception = Record.Exception(() => config.Validate());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests that parameterized constructor should call validate.
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_ShouldCallValidate()
        {
            Assert.Throws<ArgumentException>(() => new DungeonConfiguration(
                -1,
                150,
                4,
                8,
                8,
                5,
                5,
                7,
                7,
                4,
                4
            ));
        }

        /// <summary>
        ///     Tests that properties should be mutable.
        /// </summary>
        [Fact]
        public void Properties_ShouldBeMutable()
        {
            DungeonConfiguration config = new DungeonConfiguration();

            config.BoardWidth = 250;
            config.BoardHeight = 300;
            config.NumberOfRooms = 8;

            Assert.Equal(250, config.BoardWidth);
            Assert.Equal(300, config.BoardHeight);
            Assert.Equal(8, config.NumberOfRooms);
        }

        /// <summary>
        ///     Tests that validate should throw exception when board height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBoardHeightIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {BoardHeight = -5};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when number of rooms is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenNumberOfRoomsIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {NumberOfRooms = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when first room width is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenFirstRoomWidthIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {FirstRoomWidth = -3};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when room height is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenRoomHeightIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {RoomHeight = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when room height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenRoomHeightIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {RoomHeight = -2};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when boss room height is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBossRoomHeightIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {BossRoomHeight = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when boss room height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenBossRoomHeightIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {BossRoomHeight = -2};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when corridor height is zero.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenCorridorHeightIsZero()
        {
            DungeonConfiguration config = new DungeonConfiguration {CorridorHeight = 0};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that validate should throw exception when corridor height is negative.
        /// </summary>
        [Fact]
        public void Validate_ShouldThrowException_WhenCorridorHeightIsNegative()
        {
            DungeonConfiguration config = new DungeonConfiguration {CorridorHeight = -1};

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that all properties can be mutated independently.
        /// </summary>
        [Fact]
        public void AllProperties_ShouldBeMutableIndependently()
        {
            DungeonConfiguration config = new DungeonConfiguration();

            config.BoardWidth = 100;
            config.BoardHeight = 100;
            config.NumberOfRooms = 5;
            config.FirstRoomWidth = 10;
            config.FirstRoomHeight = 10;
            config.RoomWidth = 6;
            config.RoomHeight = 6;
            config.BossRoomWidth = 8;
            config.BossRoomHeight = 8;
            config.CorridorWidth = 3;
            config.CorridorHeight = 3;

            Assert.Equal(100, config.BoardWidth);
            Assert.Equal(100, config.BoardHeight);
            Assert.Equal(5, config.NumberOfRooms);
            Assert.Equal(10, config.FirstRoomWidth);
            Assert.Equal(10, config.FirstRoomHeight);
            Assert.Equal(6, config.RoomWidth);
            Assert.Equal(6, config.RoomHeight);
            Assert.Equal(8, config.BossRoomWidth);
            Assert.Equal(8, config.BossRoomHeight);
            Assert.Equal(3, config.CorridorWidth);
            Assert.Equal(3, config.CorridorHeight);
        }

        /// <summary>
        ///     Tests that validate called after each property modification works correctly.
        /// </summary>
        [Fact]
        public void Validate_WithMultiplePropertyChanges_WorksCorrectly()
        {
            DungeonConfiguration config = new DungeonConfiguration();

            config.CorridorWidth = 0;

            Assert.Throws<ArgumentException>(() => config.Validate());

            config.CorridorWidth = 4;

            Exception exception = Record.Exception(() => config.Validate());
            Assert.Null(exception);
        }

        /// <summary>
        ///     Tests with minimum valid values.
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_WithMinimumValidValues_ShouldWork()
        {
            DungeonConfiguration config = new DungeonConfiguration(1, 1, 2, 1, 1, 1, 1, 1, 1, 1, 1);

            Assert.Equal(1, config.BoardWidth);
            Assert.Equal(1, config.BoardHeight);
            Assert.Equal(2, config.NumberOfRooms);
        }
    }
}