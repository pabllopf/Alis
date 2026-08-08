// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericEventBranchCoverageTests.cs
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

using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Branch coverage tests for <see cref="GenericEvent" /> targeting uncovered paths in
    ///     <c>Remove</c>, <c>Invoke</c>, and <c>operator+</c>.
    /// </summary>
    public class GenericEventBranchCoverageTests
    {
        /// <summary>
        ///     Tests that <see cref="GenericEvent.Invoke{T}" /> does not throw when no listeners have been added.
        ///     Covers the <c>if (_first is not null)</c> false branch.
        /// </summary>
        [Fact]
        public void Invoke_WithNoListeners_DoesNotThrow()
        {
            GenericEvent evt = new GenericEvent();

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);
        }

        /// <summary>
        ///     Tests that removing the <c>_first</c> action when there is a backup in the stack promotes
        ///     the stacked item to <c>_first</c>.
        ///     Covers the <c>TryPop</c> true branch in <c>Remove</c>.
        /// </summary>
        [Fact]
        public void Remove_FirstActionWithBackupInStack_PromotesStackItem()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction a1 = new TestGenericAction();
            TestGenericAction a2 = new TestGenericAction();
            evt.Add(a1);
            evt.Add(a2);

            evt.Remove(a1);

            Assert.True(evt.HasListeners);

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);

            Assert.Equal(0, a1.InvokeCount);
            Assert.Equal(1, a2.InvokeCount);
        }

        /// <summary>
        ///     Tests that removing a stacked action correctly removes it without affecting other listeners.
        ///     Covers the <c>else</c> branch in <c>Remove</c> (delegates to <c>_invokationList.Remove</c>).
        /// </summary>
        [Fact]
        public void Remove_ActionFromStack_RemovesOnlyTarget()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction a1 = new TestGenericAction();
            TestGenericAction a2 = new TestGenericAction();
            TestGenericAction a3 = new TestGenericAction();
            evt.Add(a1);
            evt.Add(a2);
            evt.Add(a3);

            evt.Remove(a2);

            Assert.True(evt.HasListeners);

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);

            Assert.Equal(1, a1.InvokeCount);
            Assert.Equal(0, a2.InvokeCount);
            Assert.Equal(1, a3.InvokeCount);
        }

        /// <summary>
        ///     Tests that the <c>+</c> operator when <c>_first</c> is not null pushes to the invocation stack.
        ///     Covers the <c>else</c> branch in <c>operator+</c>.
        /// </summary>
        [Fact]
        public void OperatorPlus_WhenFirstIsNotNull_AddsToInvokationList()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction a1 = new TestGenericAction();
            TestGenericAction a2 = new TestGenericAction();

            evt = evt + a1;
            evt = evt + a2;

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);

            Assert.Equal(1, a1.InvokeCount);
            Assert.Equal(1, a2.InvokeCount);
        }

        /// <summary>
        ///     Test implementation of <see cref="IGenericAction{TParam}" /> for branch coverage tests.
        /// </summary>
        internal sealed class TestGenericAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     The number of times <see cref="Invoke{T}" /> has been called.
            /// </summary>
            internal int InvokeCount;

            /// <summary>
            ///     Invokes this action with the specified parameters.
            /// </summary>
            /// <typeparam name="T">The unbound generic parameter.</typeparam>
            /// <param name="param">The game object parameter.</param>
            /// <param name="type">The generic parameter.</param>
            public void Invoke<T>(GameObject param, ref T type) => InvokeCount++;
        }
    }
}
