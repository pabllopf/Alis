// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageReferenceTest.cs
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

using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     Tests for <see cref="ComponentStorage{TComponent}" /> using reference types to cover
    ///     <see cref="System.Runtime.CompilerServices.RuntimeHelpers.IsReferenceOrContainsReferences{T}" />
    ///     true branches.
    /// </summary>
    public class ComponentStorageReferenceTest
    {
        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.SetAt" /> and
        ///     <see cref="ComponentStorage{TComponent}.GetAt" /> work with string (reference type).
        /// </summary>
        [Fact]
        public void SetAtAndGetAt_WithReferenceType_WorksCorrectly()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);

            storage.SetAt("hello", 0);
            object result = storage.GetAt(0);

            Assert.Equal("hello", result);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.ResizeBuffer" /> works with reference types.
        /// </summary>
        [Fact]
        public void ResizeBuffer_WithReferenceType_GrowsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            int originalLength = storage.Buffer.Length;

            storage.ResizeBuffer(8);

            Assert.Equal(8, storage.Buffer.Length);
            Assert.True(storage.Buffer.Length > originalLength);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.Trim" /> rounds up to power of two.
        /// </summary>
        [Fact]
        public void Trim_WithReferenceType_RoundsUpToPowerOfTwo()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);

            storage.Trim(5);

            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.Delete" /> clears the reference
        ///     at the from index when TComponent is a reference type.
        /// </summary>
        [Fact]
        public void Delete_WithReferenceType_ClearsFromIndex()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("world", 0);
            storage.SetAt("foo", 1);

            storage.Delete(new DeleteComponentData(ToIndex: 0, FromIndex: 1));

            Assert.Equal("foo", storage[0]);
        }

        /// <summary>
        ///     Tests that AsSpan returns the underlying buffer with reference types.
        /// </summary>
        [Fact]
        public void AsSpan_WithReferenceType_ReturnsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);

            System.Span<string> span = storage.AsSpan();

            Assert.Equal(4, span.Length);
        }

        /// <summary>
        ///     Tests that AsSpanLength returns correct span with reference types.
        /// </summary>
        [Fact]
        public void AsSpanLength_WithReferenceType_ReturnsLimitedSpan()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);

            System.Span<string> span = storage.AsSpanLength(2);

            Assert.Equal(2, span.Length);
        }

        /// <summary>
        ///     Tests that Dispose does not throw with reference types.
        /// </summary>
        [Fact]
        public void Dispose_WithReferenceType_DoesNotThrow()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);

            storage.Dispose();
        }
    }
}
