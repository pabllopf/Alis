// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersBranchGTest.cs
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
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Tests targeting Branch G: arrayMaxLength <= count in ToArrayFromEnumerator overflow protection.
    /// </summary>
    public class EnumerableHelpersBranchGTest
    {
        /// <summary>
        ///     Tests that ToArrayFromEnumerator handles overflow when arrayMaxLength equals count.
        /// </summary>
        [Fact]
        public void ToArrayFromEnumerator_ArrayMaxLengthEqualsCount_UsesCountPlusOne()
        {
            MethodInfo method = typeof(EnumerableHelpers)
                .GetMethod("ToArrayFromEnumerator", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(int));

            int arrayMaxLength = 4;
            IEnumerable<int> source = Enumerable.Range(1, 6);
            using IEnumerator<int> enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            int[] result = (int[]) method.Invoke(null, new object[] { enumerator, arrayMaxLength, 0 });

            Assert.Equal(6, result.Length);
        }

        /// <summary>
        ///     Tests that ToArrayFromEnumerator handles overflow when arrayMaxLength is less than count.
        /// </summary>
        [Fact]
        public void ToArrayFromEnumerator_ArrayMaxLengthLessThanCount_UsesCountPlusOne()
        {
            MethodInfo method = typeof(EnumerableHelpers)
                .GetMethod("ToArrayFromEnumerator", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(int));

            int arrayMaxLength = 3;
            IEnumerable<int> source = Enumerable.Range(1, 5);
            using IEnumerator<int> enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            int[] result = (int[]) method.Invoke(null, new object[] { enumerator, arrayMaxLength, 0 });

            Assert.Equal(5, result.Length);
        }

        /// <summary>
        ///     Tests that ToArrayFromEnumerator handles overflow when arrayMaxLength equals default capacity.
        /// </summary>
        [Fact]
        public void ToArrayFromEnumerator_ArrayMaxLengthEqualsDefaultCapacity_HandlesCorrectly()
        {
            MethodInfo method = typeof(EnumerableHelpers)
                .GetMethod("ToArrayFromEnumerator", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(string));

            int arrayMaxLength = 4;
            IEnumerable<string> source = new string[] { "a", "b", "c", "d", "e" };
            using IEnumerator<string> enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            string[] result = (string[]) method.Invoke(null, new object[] { enumerator, arrayMaxLength, 0 });

            Assert.Equal(5, result.Length);
            Assert.Equal("a", result[0]);
            Assert.Equal("e", result[4]);
        }
    }
}
