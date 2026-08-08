// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersTests.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    /// The enumerable helpers tests class
    /// </summary>
    public class EnumerableHelpersTests
    {
        /// <summary>
        /// Tests that to span from list fills span correctly
        /// </summary>
        [Fact]
        public void ToSpan_FromList_FillsSpanCorrectly()
        {
            Span<int> destination = stackalloc int[5];
            List<int> source = new List<int> { 10, 20, 30, 40, 50 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(5, length);
            Assert.Equal(10, destination[0]);
            Assert.Equal(50, destination[4]);
        }

        /// <summary>
        /// Tests that to span source larger than destination stops at capacity
        /// </summary>
        [Fact]
        public void ToSpan_SourceLargerThanDestination_StopsAtCapacity()
        {
            Span<int> destination = stackalloc int[3];
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(3, length);
            Assert.Equal(1, destination[0]);
            Assert.Equal(3, destination[2]);
        }

        /// <summary>
        /// Tests that to span empty source returns zero length
        /// </summary>
        [Fact]
        public void ToSpan_EmptySource_ReturnsZeroLength()
        {
            Span<int> destination = stackalloc int[5];
            List<int> source = new List<int>();
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(0, length);
        }

        /// <summary>
        /// Tests that to span single element copies correctly
        /// </summary>
        [Fact]
        public void ToSpan_SingleElement_CopiesCorrectly()
        {
            Span<int> destination = stackalloc int[5];
            List<int> source = new List<int> { 42 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(1, length);
            Assert.Equal(42, destination[0]);
        }

        /// <summary>
        /// Tests that to span exact fit copies all elements
        /// </summary>
        [Fact]
        public void ToSpan_ExactFit_CopiesAllElements()
        {
            Span<int> destination = stackalloc int[3];
            int[] source = new int[] { 7, 8, 9 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(3, length);
            Assert.Equal(7, destination[0]);
            Assert.Equal(9, destination[2]);
        }

        /// <summary>
        /// Tests that to span pure enumerable copies correctly
        /// </summary>
        [Fact]
        public void ToSpan_PureEnumerable_CopiesCorrectly()
        {
            Span<int> destination = stackalloc int[4];
            IEnumerable<int> source = YieldElements();
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(4, length);
            Assert.Equal(100, destination[0]);
            Assert.Equal(400, destination[3]);
        }

        /// <summary>
        /// Tests that to span empty destination returns zero length
        /// </summary>
        [Fact]
        public void ToSpan_EmptyDestination_ReturnsZeroLength()
        {
            Span<int> destination = stackalloc int[0];
            List<int> source = new List<int> { 1, 2, 3 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(0, length);
        }

        /// <summary>
        /// Tests that to span value types works correctly
        /// </summary>
        [Fact]
        public void ToSpan_ValueTypes_WorksCorrectly()
        {
            Span<double> destination = stackalloc double[3];
            List<double> source = new List<double> { 1.1, 2.2, 3.3 };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(3, length);
            Assert.Equal(1.1, destination[0], 5);
            Assert.Equal(3.3, destination[2], 5);
        }

        /// <summary>
        /// Tests that to span from array exact fit
        /// </summary>
        [Fact]
        public void ToSpan_FromArray_ExactFit()
        {
            Span<string> destination = new string[2];
            string[] source = new string[] { "hello", "world" };
            EnumerableHelpers.ToSpan((IEnumerable<string>)source, destination, out int length);
            Assert.Equal(2, length);
            Assert.Equal("hello", destination[0]);
            Assert.Equal("world", destination[1]);
        }

        /// <summary>
        /// Tests that to span reference type list copies correctly
        /// </summary>
        [Fact]
        public void ToSpan_ReferenceTypeList_CopiesCorrectly()
        {
            Span<string> destination = new string[3];
            List<string> source = new List<string> { "a", "b", "c" };
            EnumerableHelpers.ToSpan(source, destination, out int length);
            Assert.Equal(3, length);
            Assert.Equal("a", destination[0]);
            Assert.Equal("c", destination[2]);
        }

        /// <summary>
        /// Yields the elements
        /// </summary>
        /// <returns>An enumerable of int</returns>
        private static IEnumerable<int> YieldElements()
        {
            yield return 100;
            yield return 200;
            yield return 300;
            yield return 400;
        }
    }
}
