// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersUncoveredLinesTest.cs
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
using System.Linq;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Covers the remaining uncovered lines in <see cref="EnumerableHelpers" />:
    ///     the empty non-ICollection enumerable path and the overflow protection
    ///     in <see cref="EnumerableHelpers.ToArray{T}" />.
    /// </summary>
    public class EnumerableHelpersUncoveredLinesTest
    {
        /// <summary>
        ///     Tests that <see cref="EnumerableHelpers.ToArray{T}" /> returns an empty array
        ///     for an empty <see cref="IEnumerable{T}" /> that does NOT implement <see cref="ICollection{T}" />.
        ///     This covers the fallthrough path after the <c>using</c> block when MoveNext is false.
        /// </summary>
        [Fact]
        public void ToArray_EmptyNonCollection_ReturnsEmpty()
        {
            IEnumerable<int> source = EmptyEnumerable();
            int[] result = EnumerableHelpers.ToArray(source, out int length);

            Assert.Empty(result);
            Assert.Equal(0, length);
        }

        /// <summary>
        ///     Tests that the overflow protection inside <c>ToArrayFromEnumerator</c> works correctly.
        ///     Invokes the private method via reflection with a small <c>arrayMaxLength</c> so that
        ///     doubling the capacity exceeds the limit, exercising the overflow handling.
        /// </summary>
        [Fact]
        public void ToArrayFromEnumerator_OverflowProtection_CapsCapacity()
        {
            MethodInfo method = typeof(EnumerableHelpers)
                .GetMethod("ToArrayFromEnumerator", BindingFlags.NonPublic | BindingFlags.Static)!
                .MakeGenericMethod(typeof(int));

            IEnumerable<int> source = Enumerable.Range(1, 6);
            using IEnumerator<int> enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            object[] args = { enumerator, 5, 0 };
            int[] result = (int[])method.Invoke(null, args)!;
            int length = (int)args[2];

            Assert.Equal(6, length);
            Assert.Equal(1, result[0]);
            Assert.Equal(2, result[1]);
            Assert.Equal(3, result[2]);
            Assert.Equal(4, result[3]);
            Assert.Equal(5, result[4]);
            Assert.Equal(6, result[5]);
        }

        /// <summary>
        ///     Returns an empty enumerable that does NOT implement <see cref="ICollection{T}" />.
        /// </summary>
        private static IEnumerable<int> EmptyEnumerable()
        {
            yield break;
        }
    }
}
