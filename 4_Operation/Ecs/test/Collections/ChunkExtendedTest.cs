// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkExtendedTest.cs
// 
//  Author:GitHub Copilot
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

using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Extended tests for Chunk to validate data organization,
    ///     span slicing, and entity management within chunks.
    /// </summary>
    public class ChunkExtendedTest
    {
        /// <summary>
        ///     Test that Chunk can be created with initial capacity.
        /// </summary>
        [Fact]
        public void Constructor_WithCapacity_ChunkCreated()
        {
            // Arrange & Act
            var chunk = new Chunk<int>(100);

            // Assert
            Assert.NotNull(chunk);
            chunk.Return();
        }

        /// <summary>
        ///     Test that Chunk properly stores and retrieves data.
        /// </summary>
        [Fact]
        public void Indexer_SetAndGet_WorksCorrectly()
        {
            // Arrange
            var chunk = new Chunk<int>(50);

            // Act
            chunk[0] = 42;
            chunk[5] = 100;

            // Assert
            Assert.Equal(42, chunk[0]);
            Assert.Equal(100, chunk[5]);
            chunk.Return();
        }

        /// <summary>
        ///     Test that Chunk can store and manage component data.
        /// </summary>
        [Fact]
        public void Buffer_Property_ReturnsValidSpan()
        {
            // Arrange
            var chunk = new Chunk<int>(100);

            // Act
            var buffer = chunk.Buffer;

            // Assert
            Assert.NotNull(buffer);
            Assert.True(buffer.Length >= 100);
            chunk.Return();
        }

        /// <summary>
        ///     Test that Chunk properly handles multiple types.
        /// </summary>
        [Fact]
        public void Chunk_WithDoubleType_StoresAndRetrievesValues()
        {
            // Arrange
            var chunk = new Chunk<double>(50);

            // Act
            chunk[0] = 3.14;
            chunk[10] = 2.71;

            // Assert
            Assert.Equal(3.14, chunk[0]);
            Assert.Equal(2.71, chunk[10]);
            chunk.Return();
        }

        /// <summary>
        ///     Test that Chunk with string type works.
        /// </summary>
        [Fact]
        public void Chunk_WithStringType_StoresAndRetrievesValues()
        {
            // Arrange
            var chunk = new Chunk<string>(50);

            // Act
            chunk[0] = "Hello";
            chunk[1] = "World";

            // Assert
            Assert.Equal("Hello", chunk[0]);
            Assert.Equal("World", chunk[1]);
            chunk.Return();
        }

        /// <summary>
        ///     Test that multiple chunks can coexist independently.
        /// </summary>
        [Fact]
        public void MultipleChunks_Independent_SeparateData()
        {
            // Arrange
            var chunk1 = new Chunk<int>(50);
            var chunk2 = new Chunk<int>(100);

            // Act
            chunk1[0] = 25;
            chunk2[0] = 75;

            // Assert
            Assert.Equal(25, chunk1[0]);
            Assert.Equal(75, chunk2[0]);
            chunk1.Return();
            chunk2.Return();
        }

        /// <summary>
        ///     Test that Chunk properly initializes buffer.
        /// </summary>
        [Fact]
        public void Constructor_DefaultChunk_ValidState()
        {
            // Arrange & Act
            var chunk = new Chunk<int>(10);

            // Assert
            Assert.NotNull(chunk.Buffer);
            Assert.True(chunk.Buffer.Length >= 10);
            chunk.Return();
        }
    }
}

