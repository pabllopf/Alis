// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:StressTestSuite.cs
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

using System.Collections.Generic;
using Xunit;

namespace Alis.Core.Test
{
    /// <summary>
    ///     Stress tests for performance validation.
    /// </summary>
    public class StressTestSuite
    {
        /// <summary>
        ///     Tests that stress massive loop operations
        /// </summary>
        /// <param name="iterations">The iterations</param>
        [Theory, InlineData(10), InlineData(100), InlineData(1000), InlineData(10000), InlineData(100000)]
        public void Stress_MassiveLoopOperations(int iterations)
        {
            int count = 0;
            for (int i = 0; i < iterations; i++)
            {
                count++;
            }

            Assert.Equal(iterations, count);
        }

        /// <summary>
        ///     Tests that stress memory allocation
        /// </summary>
        /// <param name="allocations">The allocations</param>
        [Theory, InlineData(1), InlineData(10), InlineData(100), InlineData(1000)]
        public void Stress_MemoryAllocation(int allocations)
        {
            List<object> objects = new List<object>();
            for (int i = 0; i < allocations; i++)
            {
                objects.Add(new object());
            }

            Assert.Equal(allocations, objects.Count);
        }

        /// <summary>
        ///     Tests that stress nested operations
        /// </summary>
        /// <param name="depth">The depth</param>
        [Theory, InlineData(5), InlineData(10), InlineData(100)]
        public void Stress_NestedOperations(int depth)
        {
            int result = NestedFunction(depth);
            Assert.True(result >= 0);
        }

        /// <summary>
        ///     Nesteds the function using the specified depth
        /// </summary>
        /// <param name="depth">The depth</param>
        /// <returns>The int</returns>
        private int NestedFunction(int depth)
        {
            if (depth <= 0)
            {
                return 0;
            }

            return 1 + NestedFunction(depth - 1);
        }

        /// <summary>
        ///     Tests that stress string operations
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(100), InlineData(1000), InlineData(10000)]
        public void Stress_StringOperations(int count)
        {
            List<string> strings = new List<string>();
            for (int i = 0; i < count; i++)
            {
                strings.Add(i.ToString());
            }

            Assert.Equal(count, strings.Count);
        }

        /// <summary>
        ///     Tests that stress dictionary operations
        /// </summary>
        /// <param name="count">The count</param>
        [Theory, InlineData(50), InlineData(100), InlineData(500)]
        public void Stress_DictionaryOperations(int count)
        {
            Dictionary<int, string> dict = new Dictionary<int, string>();
            for (int i = 0; i < count; i++)
            {
                dict[i] = $"Value{i}";
            }

            Assert.Equal(count, dict.Count);
        }
    }
}