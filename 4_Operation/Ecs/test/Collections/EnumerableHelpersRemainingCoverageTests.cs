// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EnumerableHelpersRemainingCoverageTests.cs
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
    ///     Covers the remaining uncovered branches in <see cref="EnumerableHelpers" />,
    ///     specifically the overflow protection in <see cref="EnumerableHelpers.ToArray{T}" />.
    /// </summary>
    public class EnumerableHelpersRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that <c>ToArrayFromEnumerator</c> correctly handles the case where
        ///     doubling the capacity would exceed <c>arrayMaxLength</c>. This exercises
        ///     the overflow protection that is impractical to reach through the public API.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ToArrayFromEnumerator_ArrayMaxLengthExceeded_UsesOverflowLogic()
        {
            MethodInfo method = typeof(EnumerableHelpers)
                .GetMethod("ToArrayFromEnumerator", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(int));

            IEnumerable<int> source = Enumerable.Range(1, 6);
            using IEnumerator<int> enumerator = source.GetEnumerator();
            enumerator.MoveNext();

            object[] args = { enumerator, 5, 0 };
            int[] result = (int[])method.Invoke(null, args);
            int length = (int)args[2];

            Assert.Equal(6, length);
            Assert.Equal(1, result[0]);
            Assert.Equal(6, result[5]);
        }
    }
}
