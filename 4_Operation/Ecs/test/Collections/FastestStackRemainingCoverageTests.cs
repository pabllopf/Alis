// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:FastestStackRemainingCoverageTests.cs
//
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
//
//  Copyright (c) 2021 GNU General Public License v3.0
//
//  --------------------------------------------------------------------------

using System;
using System.Collections;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     Coverage tests for the remaining FastestStack growth and enumerator guards.
    /// </summary>
    public class FastestStackRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that the doubled capacity is clamped to the maximum array length.
        ///     The production maximum is far too large to allocate in a test, so the
        ///     testability overload supplies a small limit without changing the algorithm.
        /// </summary>
        [Fact]
        public void Grow_WhenDoubledCapacityExceedsMaximum_ClampsToMaximum()
        {
            FastestStack<int> stack = new FastestStack<int>(16);

            stack.Grow(4, 16);

            Assert.Equal(16, stack.Capacity);
        }

        /// <summary>
        ///     Verifies the enumerator version guard of MoveNext. The stack is a value type
        ///     copied into the enumerator, so a mutation of the original stack cannot be
        ///     observed by the guard; the internal snapshot version is advanced directly
        ///     (no reflection, no dynamic code) to reproduce the guarded state.
        /// </summary>
        [Fact]
        public void MoveNext_WhenEnumeratorSnapshotVersionChanged_Throws()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Unsafe.AsRef(in enumerator._fastestStack)._version++;

            Assert.Throws<InvalidOperationException>(() => enumerator.MoveNext());
        }

        /// <summary>
        ///     Verifies the enumerator version guard of IEnumerator.Reset using the same
        ///     white-box snapshot mutation as the MoveNext test.
        /// </summary>
        [Fact]
        public void Reset_WhenEnumeratorSnapshotVersionChanged_Throws()
        {
            FastestStack<int> stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();

            Unsafe.AsRef(in enumerator._fastestStack)._version++;
            IEnumerator boxed = enumerator;

            Assert.Throws<InvalidOperationException>(() => boxed.Reset());
        }
    }
}
