// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChunkRemainingCoverageTests.cs
// 
//  Author:Pablo Domínguez Falcón
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
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Remaining coverage tests for the <see cref="Chunk{TData}" /> struct.
    /// </summary>
    public class ChunkRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that the constructor with a positive length returns a valid buffer.
        /// </summary>
        [Fact]
        public void Constructor_WithPositiveLength_ReturnsValidBuffer()
        {
            Chunk<int> chunk = new Chunk<int>(10);

            Assert.NotNull(chunk.Buffer);
            Assert.True(chunk.Buffer.Length >= 10);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that the indexer get and set round-trips values correctly.
        /// </summary>
        [Fact]
        public void Indexer_GetAndSet_RoundTripsValues()
        {
            Chunk<int> chunk = new Chunk<int>(10);

            chunk[0] = 42;
            chunk[5] = 99;

            Assert.Equal(42, chunk[0]);
            Assert.Equal(99, chunk[5]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that the indexer returns a reference allowing in-place modification.
        /// </summary>
        [Fact]
        public void Indexer_ReturnsRef_AllowsInPlaceModification()
        {
            Chunk<int> chunk = new Chunk<int>(10);

            ref int val = ref chunk[3];
            val = 100;

            Assert.Equal(100, chunk[3]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that the parameterless AsSpan returns the full buffer.
        /// </summary>
        [Fact]
        public void AsSpan_Parameterless_ReturnsFullBuffer()
        {
            Chunk<int> chunk = new Chunk<int>(10);
            Span<int> span = chunk.AsSpan();

            span[0] = 111;

            Assert.Equal(111, chunk[0]);
            chunk.Return();
        }
        

        /// <summary>
        ///     Tests that AsSpan with start and length returns the correct slice.
        /// </summary>
        [Fact]
        public void AsSpan_WithStartAndLength_ReturnsCorrectSlice()
        {
            Chunk<int> chunk = new Chunk<int>(20);

            chunk[5] = 100;
            chunk[6] = 200;
            chunk[7] = 300;

            Span<int> span = chunk.AsSpan(5, 3);

            Assert.Equal(3, span.Length);
            Assert.Equal(100, span[0]);
            Assert.Equal(200, span[1]);
            Assert.Equal(300, span[2]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that Return sets the buffer to null.
        /// </summary>
        [Fact]
        public void Return_SetsBufferToNull()
        {
            Chunk<int> chunk = new Chunk<int>(10);

            chunk.Return();

            Assert.Null(chunk.Buffer);
        }

        /// <summary>
        ///     Tests that Length returns the buffer length.
        /// </summary>
        [Fact]
        public void Length_ReturnsBufferLength()
        {
            Chunk<int> chunk = new Chunk<int>(10);

            Assert.Equal(chunk.Buffer.Length, chunk.Length);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that the chunk can store reference types.
        /// </summary>
        [Fact]
        public void CanStoreReferenceTypes()
        {
            Chunk<string> chunk = new Chunk<string>(5);

            chunk[0] = "Hello";
            chunk[1] = "World";

            Assert.Equal("Hello", chunk[0]);
            Assert.Equal("World", chunk[1]);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that the chunk can store struct types.
        /// </summary>
        [Fact]
        public void CanStoreStructTypes()
        {
            Chunk<double> chunk = new Chunk<double>(10);

            chunk[0] = 3.14;
            chunk[5] = 2.71;

            Assert.Equal(3.14, chunk[0], 5);
            Assert.Equal(2.71, chunk[5], 5);
            chunk.Return();
        }

        /// <summary>
        ///     Tests that NextChunk creates a new chunk when the index is within bounds.
        /// </summary>
        [Fact]
        public void NextChunk_WhenIndexWithinBounds_CreatesChunk()
        {
            Chunk<int>[] chunks = new Chunk<int>[2];
            chunks[0] = new Chunk<int>(10);

            Chunk<int>.NextChunk(ref chunks, 10, 1);

            Assert.NotNull(chunks[1].Buffer);

            chunks[0].Return();
            chunks[1].Return();
        }

        /// <summary>
        ///     Tests that NextChunk resizes the array when the index is at bounds.
        /// </summary>
        [Fact]
        public void NextChunk_WhenIndexAtBounds_ResizesArray()
        {
            Chunk<int>[] chunks = new Chunk<int>[1];
            chunks[0] = new Chunk<int>(10);

            Chunk<int>.NextChunk(ref chunks, 10, 1);

            Assert.True(chunks.Length > 1);

            chunks[0].Return();
            chunks[1].Return();
        }

        /// <summary>
        ///     Tests that multiple elements round-trip correctly through the indexer.
        /// </summary>
        [Fact]
        public void MultipleElements_RoundTrip()
        {
            Chunk<int> chunk = new Chunk<int>(100);

            for (int i = 0; i < 100; i++)
            {
                chunk[i] = i * 2;
            }

            for (int i = 0; i < 100; i++)
            {
                Assert.Equal(i * 2, chunk[i]);
            }

            chunk.Return();
        }
    }
}