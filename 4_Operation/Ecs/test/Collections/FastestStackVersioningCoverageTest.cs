// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastestStackVersioningCoverageTest.cs
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
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Coverage tests for FastestStack enumerator version guards, empty-stack
    ///     lookups and the generic empty-enumerator path.
    /// </summary>
    public class FastestStackVersioningCoverageTest
    {
        /// <summary>
        ///     Tests that Contains on an empty stack returns false without scanning,
        ///     covering the short-circuit on the _size != 0 precondition.
        /// </summary>
        [Fact]
        public void Contains_OnEmptyStack_ReturnsFalse()
        {
            FastestStack<int> stack = new FastestStack<int>();

            Assert.False(stack.Contains(42));
        }

        /// <summary>
        ///     Tests that the generic empty enumerator is returned for an empty stack,
        ///     covering the Count == 0 branch of IEnumerable<T>.GetEnumerator.
        /// </summary>
        [Fact]
        public void GetEnumerator_EmptyStack_ReturnsEmptyEnumerator()
        {
            FastestStack<int> stack = new FastestStack<int>();
            IEnumerator<int> enumerator = ((IEnumerable<int>) stack).GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that the generic empty enumerator is returned for a disposed stack,
        ///     covering the Count == 0 branch after Dispose.
        /// </summary>
        [Fact]
        public void GetEnumerator_DisposedStack_ReturnsEmptyEnumerator()
        {
            FastestStack<string> stack = new FastestStack<string>();
            stack.Push("value");
            stack.Dispose();

            IEnumerator<string> enumerator = ((IEnumerable<string>) stack).GetEnumerator();

            Assert.False(enumerator.MoveNext());
        }

        /// <summary>
        ///     Tests that enumerating an empty stack trivially completes, exercising the
        ///     MoveNext early return for an empty stack.
        /// </summary>
        [Fact]
        public void Enumerator_EmptyStack_MoveNextReturnsFalse()
        {
            FastestStack<int> stack = new FastestStack<int>();
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Assert.False(enumerator.MoveNext());
            Assert.False(enumerator.MoveNext());
        }
    }
}