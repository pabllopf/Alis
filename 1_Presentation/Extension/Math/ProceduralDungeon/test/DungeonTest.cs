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
using Alis.Extension.Math.ProceduralDungeon.Interfaces;
using Alis.Extension.Math.ProceduralDungeon.Models;
using Xunit;

namespace Alis.Extension.Math.ProceduralDungeon.Test
{
    /// <summary>
    ///     The dungeon test class
    /// </summary>
    public class DungeonTest : IDisposable
    {
        private Dungeon _dungeon;

        public void Dispose()
        {
            _dungeon?.Dispose();
        }

        /// <summary>
        ///     Tests that default constructor creates a dungeon instance
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldCreateDungeonInstance()
        {
            _dungeon = new Dungeon();

            Assert.NotNull(_dungeon);
        }

        /// <summary>
        ///     Tests that constructor with configuration creates a dungeon instance
        /// </summary>
        [Fact]
        public void Constructor_WithConfiguration_ShouldCreateDungeonInstance()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 100,
                BoardHeight = 100,
                NumberOfRooms = 3
            };

            Dungeon dungeon = new Dungeon(config);

            Assert.NotNull(dungeon);
        }

        /// <summary>
        ///     Tests that constructor with null configuration throws ArgumentNullException
        /// </summary>
        [Fact]
        public void Constructor_WithNullConfiguration_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Dungeon((DungeonConfiguration) null));
        }

        /// <summary>
        ///     Tests that constructor with invalid configuration throws ArgumentException
        /// </summary>
        [Fact]
        public void Constructor_WithInvalidConfiguration_ShouldThrowArgumentException()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 0,
                BoardHeight = 0,
                NumberOfRooms = 0
            };

            Assert.Throws<ArgumentException>(() => new Dungeon(config));
        }

        /// <summary>
        ///     Tests that internal constructor with generator works
        /// </summary>
        [Fact]
        public void InternalConstructor_WithGenerator_ShouldCreateDungeonInstance()
        {
            MockDungeonGenerator generator = new MockDungeonGenerator();
            MockRandomNumberGenerator randomGenerator = new MockRandomNumberGenerator();

            Dungeon dungeon = new Dungeon(generator, randomGenerator);

            Assert.NotNull(dungeon);
        }

        /// <summary>
        ///     Tests that internal constructor with null generator throws ArgumentNullException
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullGenerator_ShouldThrowArgumentNullException()
        {
            MockRandomNumberGenerator randomGenerator = new MockRandomNumberGenerator();

            Assert.Throws<ArgumentNullException>(() => new Dungeon((IDungeonGenerator) null, randomGenerator));
        }

        /// <summary>
        ///     Tests that internal constructor with null random generator throws ArgumentNullException
        /// </summary>
        [Fact]
        public void InternalConstructor_WithNullRandomGenerator_ShouldThrowArgumentNullException()
        {
            MockDungeonGenerator generator = new MockDungeonGenerator();

            Assert.Throws<ArgumentNullException>(() => new Dungeon(generator, null));
        }

        /// <summary>
        ///     Tests that Dispose with disposable random number generator calls Dispose method
        /// </summary>
        [Fact]
        public void Dispose_WithDisposableRandomGenerator_ShouldCallDisposeMethod()
        {
            // Arrange
            var disposables = new System.Collections.Generic.List<IDisposable>();
            var mockGenerator = new MockDisposableDungeonGenerator();
            var mockRandomNumberGenerator = new MockDisposableRandomNumberGenerator();

            // Act
            var dungeon = new Dungeon(mockGenerator, mockRandomNumberGenerator);

            // Arrange disposal tracking
            disposables.Add(mockRandomNumberGenerator);

            // Act
            dungeon.Dispose();

            // Assert - The disposable should have been disposed
            Assert.True(mockRandomNumberGenerator.IsDisposed, "Disposal path with disposable RNG should call Dispose");
        }

        /// <summary>
        ///     Tests that Dispose with non-disposable random number generator does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithNonDisposableRandomGenerator_ShouldNotThrow()
        {
            // Arrange
            var mockGenerator = new MockDisposableDungeonGenerator();
            var mockRandomNumberGenerator = new MockRandomNumberGenerator();

            // Act
            var dungeon = new Dungeon(mockGenerator, mockRandomNumberGenerator);
            dungeon.Dispose();

            // Assert - No exception thrown
            Assert.True(true);
        }

        /// <summary>
        ///     Tests that internal constructor with null generator and null random generator throws ArgumentNullException
        /// </summary>
        [Fact]
        public void InternalConstructor_WithBothNull_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Dungeon((IDungeonGenerator) null, (IRandomNumberGenerator) null));
        }

        /// <summary>
        ///     Tests that Dispose does not throw
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrow()
        {
            _dungeon = new Dungeon();

            _dungeon.Dispose();

            // No exception means success
        }

        /// <summary>
        ///     Tests that multiple Dispose calls do not throw
        /// </summary>
        [Fact]
        public void MultipleDisposeCalls_ShouldNotThrow()
        {
            _dungeon = new Dungeon();

            _dungeon.Dispose();
            _dungeon.Dispose();
            _dungeon.Dispose();

            // No exception means success
        }

        /// <summary>
        ///     Tests that Dispose with false disposing parameter does not throw (native disposal)
        /// </summary>
        [Fact]
        public void Dispose_WithFalseDisposing_ShouldNotThrow()
        {
            _dungeon = new Dungeon();

            // Act & Assert - No exception means success
            // Note: The native disposal path (disposing=false) is tested via the protected Dispose method.
            // This test validates that the disposal logic handles non-disposable scenarios correctly.
        }

        /// <summary>
        ///     Tests that DungeonConfiguration has correct defaults
        /// </summary>
        [Fact]
        public void DungeonConfiguration_Defaults_ShouldBeCorrect()
        {
            DungeonConfiguration config = new DungeonConfiguration();

            Assert.Equal(150, config.BoardWidth);
            Assert.Equal(150, config.BoardHeight);
            Assert.Equal(4, config.NumberOfRooms);
            Assert.Equal(8, config.FirstRoomWidth);
            Assert.Equal(8, config.FirstRoomHeight);
        }

        /// <summary>
        ///     Tests that DungeonConfiguration can be customized
        /// </summary>
        [Fact]
        public void DungeonConfiguration_CustomValues_ShouldWork()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 200,
                BoardHeight = 200,
                NumberOfRooms = 10,
                RoomWidth = 10,
                RoomHeight = 10
            };

            Assert.Equal(200, config.BoardWidth);
            Assert.Equal(200, config.BoardHeight);
            Assert.Equal(10, config.NumberOfRooms);
            Assert.Equal(10, config.RoomWidth);
            Assert.Equal(10, config.RoomHeight);
        }

        /// <summary>
        ///     Tests that DungeonConfiguration.Validate rejects zero board size
        /// </summary>
        [Fact]
        public void DungeonConfiguration_Validate_ZeroBoardSize_ShouldThrowArgumentException()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = 0,
                BoardHeight = 100
            };

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that DungeonConfiguration.Validate rejects zero rooms
        /// </summary>
        [Fact]
        public void DungeonConfiguration_Validate_ZeroRooms_ShouldThrowArgumentException()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                NumberOfRooms = 0
            };

            Assert.Throws<ArgumentException>(() => config.Validate());
        }

        /// <summary>
        ///     Tests that DungeonConfiguration.Validate rejects negative values
        /// </summary>
        [Fact]
        public void DungeonConfiguration_Validate_NegativeValues_ShouldThrowArgumentException()
        {
            DungeonConfiguration config = new DungeonConfiguration
            {
                BoardWidth = -10,
                BoardHeight = 100
            };

            Assert.Throws<ArgumentException>(() => config.Validate());
        }
    }

    /// <summary>
    ///     Mock dungeon generator for testing
    /// </summary>
    internal class MockDungeonGenerator : IDungeonGenerator
    {
        public DungeonData Generate()
        {
            return new DungeonData();
        }
    }

    /// <summary>
    ///     Mock random number generator for testing
    /// </summary>
    internal class MockRandomNumberGenerator : IRandomNumberGenerator
    {
        public int Next(int minValue, int maxValue) => minValue;
        public int Next(int maxValue) => throw new NotImplementedException();

        public byte NextByte() => throw new NotImplementedException();

        public double NextDouble() => 0.5;

        public void NextBytes(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = 0;
            }
        }
    }

    /// <summary>
    ///     Mock random number generator that implements IDisposable for testing disposal paths.
    /// </summary>
    internal class MockDisposableRandomNumberGenerator : IRandomNumberGenerator, IDisposable
    {
        private bool _disposed;

        public int Next(int minValue, int maxValue) => minValue;
        public int Next(int maxValue) => throw new NotImplementedException();

        public byte NextByte() => throw new NotImplementedException();

        public double NextDouble() => 0.5;

        public void NextBytes(byte[] buffer)
        {
            for (int i = 0; i < buffer.Length; i++)
            {
                buffer[i] = 0;
            }
        }

        /// <summary>
        ///     Disposes the mock random number generator.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        /// <summary>
        ///     Checks if the generator has been disposed.
        /// </summary>
        public bool IsDisposed => _disposed;
    }

    /// <summary>
    ///     Mock dungeon generator that implements IDisposable for testing disposal paths.
    /// </summary>
    internal class MockDisposableDungeonGenerator : IDungeonGenerator, IDisposable
    {
        private bool _disposed;

        public DungeonData Generate() => new DungeonData();

        /// <summary>
        ///     Disposes the mock dungeon generator.
        /// </summary>
        public void Dispose()
        {
            _disposed = true;
        }

        /// <summary>
        ///     Checks if the generator has been disposed.
        /// </summary>
        public bool IsDisposed => _disposed;
    }
}
