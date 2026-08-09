// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackAdditionalCoverageTests.cs
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

using System.Collections;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The fastest stack additional coverage tests class
    /// </summary>
    public class FastestStackAdditionalCoverageTests
    {
        /// <summary>
        ///     Tests that i collection is synchronized returns false
        /// </summary>
        [Fact]
        public void ICollection_IsSynchronized_ReturnsFalse()
        {
            FastestStack<int> stack = new FastestStack<int>();

            Assert.False(((ICollection) stack).IsSynchronized);
        }

        /// <summary>
        ///     Tests that i collection sync root returns non null
        /// </summary>
        [Fact]
        public void ICollection_SyncRoot_ReturnsNonNull()
        {
            FastestStack<int> stack = new FastestStack<int>();

            Assert.NotNull(((ICollection) stack).SyncRoot);
        }

        /// <summary>
        ///     Tests that non generic enumerator iterates elements
        /// </summary>
        [Fact]
        public void NonGenericEnumerator_IteratesElements()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);

            int count = 0;
            foreach (int item in (IEnumerable) stack)
            {
                Assert.True(item == 1 || item == 2);
                count++;
            }

            Assert.Equal(2, count);
        }

        /// <summary>
        ///     Tests that enumerator reset resets iteration
        /// </summary>
        [Fact]
        public void Enumerator_Reset_ResetsIteration()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);

            IEnumerator enumerator = stack.GetEnumerator();
            while (enumerator.MoveNext())
            {
            }

            enumerator.Reset();

            Assert.True(enumerator.MoveNext());
        }
    }
}
