// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkTest.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The chunk test class
    /// </summary>
    /// <remarks>
    ///     Tests the <see cref="Chunk{TData}"/> struct which provides
    ///     chunked memory storage for component data in the ECS system.
    /// </remarks>
    public class ChunkTest
    {

        /// <summary>
        ///     Tests that chunk can be created with length
        /// </summary>
        /// <remarks>
        ///     Verifies that a Chunk can be created with a specified length.
        /// </remarks>
        [Fact]
        public void Chunk_CanBeCreatedWithLength()
        {
            // Act
            Chunk<int> chunk = new Chunk<int>(10);

            // Assert
            Assert.NotNull(chunk.Buffer);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk buffer has correct minimum length
        /// </summary>
        /// <remarks>
        ///     Validates that the buffer has at least the requested length.
        /// </remarks>
        [Fact]
        public void Chunk_BufferHasCorrectMinimumLength()
        {
            // Arrange
            const int requestedLength = 10;

            // Act
            Chunk<int> chunk = new Chunk<int>(requestedLength);

            // Assert
            Assert.True(chunk.Buffer.Length >= requestedLength);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk indexer provides access to elements
        /// </summary>
        /// <remarks>
        ///     Tests that the indexer allows access to chunk elements.
        /// </remarks>
        [Fact]
        public void Chunk_IndexerProvidesAccessToElements()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(10);

            // Act
            chunk[0] = 42;
            chunk[5] = 99;

            // Assert
            Assert.Equal(42, chunk[0]);
            Assert.Equal(99, chunk[5]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk as span returns correct span
        /// </summary>
        /// <remarks>
        ///     Validates that AsSpan method returns a span of the buffer.
        /// </remarks>
        [Fact]
        public void Chunk_AsSpanReturnsCorrectSpan()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(5);

            // Act
            Span<int> span = chunk.AsSpan();

            // Assert
            Assert.True(span.Length >= 5);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk as span with range returns correct span
        /// </summary>
        /// <remarks>
        ///     Tests that AsSpan with start and length returns the correct span slice.
        /// </remarks>
        [Fact]
        public void Chunk_AsSpanWithRange_ReturnsCorrectSpan()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(20);
            chunk[5] = 100;
            chunk[6] = 200;
            chunk[7] = 300;

            // Act
            Span<int> span = chunk.AsSpan(5, 3);

            // Assert
            Assert.Equal(3, span.Length);
            Assert.Equal(100, span[0]);
            Assert.Equal(200, span[1]);
            Assert.Equal(300, span[2]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk can store reference types
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk works correctly with reference types.
        /// </remarks>
        [Fact]
        public void Chunk_CanStoreReferenceTypes()
        {
            // Arrange
            Chunk<string> chunk = new Chunk<string>(5);

            // Act
            chunk[0] = "Hello";
            chunk[1] = "World";

            // Assert
            Assert.Equal("Hello", chunk[0]);
            Assert.Equal("World", chunk[1]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk can store value types
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk works correctly with value types.
        /// </remarks>
        [Fact]
        public void Chunk_CanStoreValueTypes()
        {
            // Arrange
            Chunk<double> chunk = new Chunk<double>(10);

            // Act
            chunk[0] = 3.14;
            chunk[5] = 2.71;

            // Assert
            Assert.Equal(3.14, chunk[0]);
            Assert.Equal(2.71, chunk[5]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk can store structs
        /// </summary>
        /// <remarks>
        ///     Validates that Chunk works with custom struct types.
        /// </remarks>
        [Fact]
        public void Chunk_CanStoreStructs()
        {
            // Arrange
            Chunk<TestStruct> chunk = new Chunk<TestStruct>(5);

            // Act
            chunk[0] = new TestStruct { X = 10, Y = 20 };

            // Assert
            Assert.Equal(10, chunk[0].X);
            Assert.Equal(20, chunk[0].Y);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk return releases buffer
        /// </summary>
        /// <remarks>
        ///     Tests that Return method properly releases the buffer.
        /// </remarks>
        [Fact]
        public void Chunk_ReturnReleasesBuffer()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(10);

            // Act
            chunk.Return();

            // Assert
            Assert.Null(chunk.Buffer);
        }

        /// <summary>
        ///     Tests that chunk indexer returns reference
        /// </summary>
        /// <remarks>
        ///     Confirms that the indexer returns a reference that can be modified.
        /// </remarks>
        [Fact]
        public void Chunk_IndexerReturnsReference()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(10);
            chunk[3] = 50;

            // Act
            ref int value = ref chunk[3];
            value = 100;

            // Assert
            Assert.Equal(100, chunk[3]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk can be used with multiple elements
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk can handle multiple elements efficiently.
        /// </remarks>
        [Fact]
        public void Chunk_CanBeUsedWithMultipleElements()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(100);

            // Act
            for (int i = 0; i < 100; i++)
            {
                chunk[i] = i * 2;
            }

            // Assert
            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i * 2, chunk[i]);
            }
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk buffer is not null after creation
        /// </summary>
        /// <remarks>
        ///     Validates that the buffer is properly allocated after creation.
        /// </remarks>
        [Fact]
        public void Chunk_BufferIsNotNullAfterCreation()
        {
            // Act
            Chunk<int> chunk = new Chunk<int>(5);

            // Assert
            Assert.NotNull(chunk.Buffer);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk can handle large allocations
        /// </summary>
        /// <remarks>
        ///     Tests that Chunk can handle large buffer allocations.
        /// </remarks>
        [Fact]
        public void Chunk_CanHandleLargeAllocations()
        {
            // Act
            Chunk<int> chunk = new Chunk<int>(10000);

            // Assert
            Assert.NotNull(chunk.Buffer);
            Assert.True(chunk.Buffer.Length >= 10000);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that chunk as span can be modified
        /// </summary>
        /// <remarks>
        ///     Tests that the span returned by AsSpan can be modified.
        /// </remarks>
        [Fact]
        public void Chunk_AsSpanCanBeModified()
        {
            // Arrange
            Chunk<int> chunk = new Chunk<int>(10);
            Span<int> span = chunk.AsSpan();

            // Act
            span[0] = 111;
            span[1] = 222;

            // Assert
            Assert.Equal(111, chunk[0]);
            Assert.Equal(222, chunk[1]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that next chunk static method creates new chunk
        /// </summary>
        /// <remarks>
        ///     Tests the static NextChunk method properly creates and adds new chunks.
        /// </remarks>
        [Fact]
        public void NextChunk_StaticMethod_CreatesNewChunk()
        {
            // Arrange
            Chunk<int>[] chunks = new Chunk<int>[2];
            chunks[0] = new Chunk<int>(10);

            // Act
            Chunk<int>.NextChunk(ref chunks, 10, 1);

            // Assert
            Assert.NotNull(chunks[1].Buffer);
            
            // Cleanup
            chunks[0].Return();
            chunks[1].Return();
        }

        /// <summary>
        ///     Tests that next chunk resizes array when needed
        /// </summary>
        /// <remarks>
        ///     Tests that NextChunk resizes the chunks array when necessary.
        /// </remarks>
        [Fact]
        public void NextChunk_ResizesArray_WhenNeeded()
        {
            // Arrange
            Chunk<int>[] chunks = new Chunk<int>[1];
            chunks[0] = new Chunk<int>(10);
            int originalLength = chunks.Length;

            // Act
            Chunk<int>.NextChunk(ref chunks, 10, 1);

            // Assert
            Assert.True(chunks.Length > originalLength);
            
            // Cleanup
            chunks[0].Return();
            chunks[1].Return();
        }
    }
}

