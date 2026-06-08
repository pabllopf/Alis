// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageTest.cs
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
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The component storage test class
    /// </summary>
    public class ComponentStorageTest
    {
        /// <summary>
        ///     Tests that indexer returns correct value after assignment
        /// </summary>
        [Fact]
        public void ShouldReturnValueWhenIndexerSetAndRetrieved()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 42;

            Assert.Equal(42, storage[0]);
        }

        /// <summary>
        ///     Tests that multiple indices work correctly
        /// </summary>
        [Fact]
        public void ShouldReturnCorrectValuesAtMultipleIndices()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 10;
            storage[1] = 20;
            storage[2] = 30;
            storage[3] = 40;

            Assert.Equal(10, storage[0]);
            Assert.Equal(20, storage[1]);
            Assert.Equal(30, storage[2]);
            Assert.Equal(40, storage[3]);
        }

        /// <summary>
        ///     Tests that AsSpan returns correct length
        /// </summary>
        [Fact]
        public void ShouldReturnCorrectLengthWhenAsSpanCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            Span<int> span = storage.AsSpan();

            Assert.Equal(8, span.Length);
        }

        /// <summary>
        ///     Tests that AsSpanLength returns correct length
        /// </summary>
        [Fact]
        public void ShouldReturnCorrectLengthWhenAsSpanLengthCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            Span<int> span = storage.AsSpanLength(5);

            Assert.Equal(5, span.Length);
        }

        /// <summary>
        ///     Tests that SetAt and GetAt work correctly
        /// </summary>
        [Fact]
        public void ShouldSetAndGetWhenUsingSetAtAndGetAt()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.SetAt(42, 0);
            object result = storage.GetAt(0);

            Assert.Equal(42, result);
        }

        /// <summary>
        ///     Tests that Buffer field is accessible
        /// </summary>
        [Fact]
        public void ShouldHaveAccessibleBufferField()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            Assert.NotNull(storage.Buffer);
            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that Dispose does not throw
        /// </summary>
        [Fact]
        public void ShouldNotThrowWhenDisposeCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.Dispose();
        }

        /// <summary>
        ///     Tests that zero capacity creates empty storage
        /// </summary>
        [Fact]
        public void ShouldCreateEmptyStorageWhenZeroCapacity()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);

            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that indexer overwrites previous value
        /// </summary>
        [Fact]
        public void ShouldOverwritePreviousValueWhenIndexerSetTwice()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 10;
            storage[0] = 20;

            Assert.Equal(20, storage[0]);
        }

        /// <summary>
        ///     Tests that AsSpan returns underlying data
        /// </summary>
        [Fact]
        public void ShouldReturnUnderlyingDataWhenAsSpanCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;

            Span<int> span = storage.AsSpan();

            Assert.Equal(42, span[0]);
        }
    }
}
