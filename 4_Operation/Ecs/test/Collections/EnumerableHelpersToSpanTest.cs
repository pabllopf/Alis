// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersToSpanTest.cs
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
using System.Linq;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Coverage tests for <see cref="EnumerableHelpers.ToSpan{T}" /> covering all code paths
    ///     including empty source, source larger than destination, exact fit, and single element.
    /// </summary>
    public class EnumerableHelpersToSpanTest
    {
        /// <summary>
        ///     Tests that ToSpan copies all elements from a list to a span of equal size.
        /// </summary>
        [Fact]
        public void ToSpan_FromList_FillsSpanCorrectly()
        {
            Span<int> destination = stackalloc int[5];
            List<int> source = new List<int> { 10, 20, 30, 40, 50 };

            EnumerableHelpers.ToSpan(source, destination, out int length);

            Assert.Equal(5, length);
            Assert.Equal(10, destination[0]);
            Assert.Equal(20, destination[1]);
            Assert.Equal(30, destination[2]);
            Assert.Equal(40, destination[3]);
            Assert.Equal(50, destination[4]);
        }

        /// <summary>
        ///     Tests that ToSpan stops filling when source has more elements than destination.
        /// </summary>
        [Fact]
        public void ToSpan_SourceLargerThanDestination_StopsAtCapacity()
        {
            Span<int> destination = stackalloc int[3];
            List<int> source = new List<int> { 1, 2, 3, 4, 5 };

            EnumerableHelpers.ToSpan(source, destination, out int length);

            Assert.Equal(3, length);
            Assert.Equal(1, destination[0]);
            Assert.Equal(2, destination[1]);
            Assert.Equal(3, destination[2]);
        }

        /// <summary>
        ///     Tests that ToSpan returns zero length for empty source.
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
        ///     Tests that ToSpan works with single element source.
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
        ///     Tests that ToSpan works with exact fit (source size equals destination size).
        /// </summary>
        [Fact]
        public void ToSpan_ExactFit_CopiesAllElements()
        {
            Span<int> destination = stackalloc int[3];
            int[] source = new int[] { 7, 8, 9 };

            EnumerableHelpers.ToSpan(source, destination, out int length);

            Assert.Equal(3, length);
            Assert.Equal(7, destination[0]);
            Assert.Equal(8, destination[1]);
            Assert.Equal(9, destination[2]);
        }

        /// <summary>
        ///     Tests that ToSpan works with a pure IEnumerable (yield return).
        /// </summary>
        [Fact]
        public void ToSpan_PureEnumerable_CopiesCorrectly()
        {
            Span<int> destination = stackalloc int[4];
            IEnumerable<int> source = YieldElements();

            EnumerableHelpers.ToSpan(source, destination, out int length);

            Assert.Equal(4, length);
            Assert.Equal(100, destination[0]);
            Assert.Equal(200, destination[1]);
            Assert.Equal(300, destination[2]);
            Assert.Equal(400, destination[3]);
        }

        /// <summary>
        ///     Tests that ToSpan with empty destination returns zero length.
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
        ///     Tests that ToSpan works with value type elements.
        /// </summary>
        [Fact]
        public void ToSpan_ValueTypes_WorksCorrectly()
        {
            Span<double> destination = stackalloc double[3];
            List<double> source = new List<double> { 1.1, 2.2, 3.3 };

            EnumerableHelpers.ToSpan(source, destination, out int length);

            Assert.Equal(3, length);
            Assert.Equal(1.1, destination[0]);
            Assert.Equal(2.2, destination[1]);
            Assert.Equal(3.3, destination[2]);
        }

        /// <summary>
        ///     Helper that yields four elements for testing pure IEnumerable path.
        /// </summary>
        private static IEnumerable<int> YieldElements()
        {
            yield return 100;
            yield return 200;
            yield return 300;
            yield return 400;
        }
    }
}
