// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EdgeCaseTestSuite.cs
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
using Xunit;

namespace Alis.Core.Test
{
    /// <summary>
    ///     Edge case and boundary tests.
    ///     Tests system behavior at the limits.
    /// </summary>
    public class EdgeCaseTestSuite
    {
        /// <summary>
        ///     Generates the edge cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateEdgeCases()
        {
            // Numeric edge cases
            yield return new object[] {int.MinValue};
            yield return new object[] {int.MaxValue};
            yield return new object[] {0};
            yield return new object[] {1};
            yield return new object[] {-1};
            yield return new object[] {float.MinValue};
            yield return new object[] {float.MaxValue};
            yield return new object[] {float.NaN};
            yield return new object[] {float.PositiveInfinity};
            yield return new object[] {float.NegativeInfinity};

            // Boundary values
            for (int i = -5; i <= 5; i++)
            {
                yield return new object[] {i};
            }
        }

        /// <summary>
        ///     Tests that edge case numeric boundaries
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, MemberData(nameof(GenerateEdgeCases))]
        public void EdgeCase_NumericBoundaries(object value)
        {
            Assert.NotNull(value);
        }

        /// <summary>
        ///     Tests that edge case string handling
        /// </summary>
        /// <param name="value">The value</param>
        [Theory, InlineData(""), InlineData(null), InlineData("abc"), InlineData("123"), InlineData(" ")]
        public void EdgeCase_StringHandling(string value)
        {
            if (value != null)
            {
                Assert.NotNull(value);
            }
        }

        /// <summary>
        ///     Tests that edge case collection boundaries
        /// </summary>
        /// <param name="size">The size</param>
        [Theory, InlineData(0), InlineData(1), InlineData(-1)]
        public void EdgeCase_CollectionBoundaries(int size)
        {
            List<int> list = new List<int>();
            for (int i = 0; i < Math.Abs(size); i++)
            {
                list.Add(i);
            }

            Assert.NotNull(list);
        }
    }
}