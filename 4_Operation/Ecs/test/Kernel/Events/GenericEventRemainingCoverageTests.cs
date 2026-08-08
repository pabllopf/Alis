// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericEventRemainingCoverageTests.cs
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
    ///     Tests the remaining uncovered methods of <see cref="GenericEvent" /> class.
    /// </summary>
    public class GenericEventRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that a default <see cref="GenericEvent" /> has no listeners.
        /// </summary>
        [Fact]
        public void Default_HasNoListeners()
        {
            GenericEvent evt = new GenericEvent();

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that adding a single action causes <see cref="GenericEvent.HasListeners" /> to return <see langword="true" />.
        /// </summary>
        [Fact]
        public void Add_SingleAction_HasListeners()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction action = new TestGenericAction();
            evt.Add(action);

            Assert.True(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Invoke{T}" /> calls a single registered action.
        /// </summary>
        [Fact]
        public void Add_AndInvoke_CallsAction()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction action = new TestGenericAction();
            evt.Add(action);

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);

            Assert.Equal(1, action.InvokeCount);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Invoke{T}" /> calls all registered actions.
        /// </summary>
        [Fact]
        public void Add_TwoActions_BothCalled()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction a1 = new TestGenericAction();
            TestGenericAction a2 = new TestGenericAction();
            evt.Add(a1);
            evt.Add(a2);

            int dummy = 0;
            evt.Invoke(default(GameObject), ref dummy);

            Assert.Equal(1, a1.InvokeCount);
            Assert.Equal(1, a2.InvokeCount);
        }

        /// <summary>
        ///     Tests that removing a single action clears <see cref="GenericEvent.HasListeners" />.
        /// </summary>
        [Fact]
        public void Remove_SingleAction_RemovesIt()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction action = new TestGenericAction();
            evt.Add(action);
            evt.Remove(action);

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that <c>null + action</c> returns <see langword="null" />.
        /// </summary>
        [Fact]
        public void OperatorPlus_WhenNull_ReturnsNull()
        {
            GenericEvent evt = null;
            TestGenericAction action = new TestGenericAction();

            GenericEvent result = evt + action;

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that <c>null - action</c> returns <see langword="null" />.
        /// </summary>
        [Fact]
        public void OperatorMinus_WhenNull_ReturnsNull()
        {
            GenericEvent evt = null;
            TestGenericAction action = new TestGenericAction();

            GenericEvent result = evt - action;

            Assert.Null(result);
        }

        /// <summary>
        ///     Tests that the <c>+</c> operator adds an action.
        /// </summary>
        [Fact]
        public void OperatorPlus_AddsAction()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction action = new TestGenericAction();

            GenericEvent result = evt + action;

            Assert.True(result.HasListeners);
        }

        /// <summary>
        ///     Tests that the <c>-</c> operator removes an action.
        /// </summary>
        [Fact]
        public void OperatorMinus_RemovesAction()
        {
            GenericEvent evt = new GenericEvent();
            TestGenericAction action = new TestGenericAction();
            evt += action;

            evt -= action;

            Assert.False(evt.HasListeners);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Equals(object)" /> returns <see langword="true" /> for the same instance.
        /// </summary>
        [Fact]
        public void Equals_SameInstance_ReturnsTrue()
        {
            GenericEvent evt = new GenericEvent();

            bool result = evt.Equals(evt);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Equals(object)" /> returns <see langword="false" /> for a different instance.
        /// </summary>
        [Fact]
        public void Equals_DifferentInstance_ReturnsFalse()
        {
            GenericEvent a = new GenericEvent();
            GenericEvent b = new GenericEvent();

            bool result = a.Equals(b);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.GetHashCode" /> returns zero.
        /// </summary>
        [Fact]
        public void GetHashCode_ReturnsZero()
        {
            GenericEvent evt = new GenericEvent();

            int hashCode = evt.GetHashCode();

            Assert.Equal(0, hashCode);
        }

        /// <summary>
        ///     Tests that the <c>==</c> operator returns <see langword="true" /> for the same reference.
        /// </summary>
        [Fact]
        public void OperatorEquals_SameReference_True()
        {
            GenericEvent evt = new GenericEvent();

            bool result = evt == evt;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that the <c>!=</c> operator returns <see langword="true" /> for different references.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentReference_True()
        {
            GenericEvent a = new GenericEvent();
            GenericEvent b = new GenericEvent();

            bool result = a != b;

            Assert.True(result);
        }

        /// <summary>
        ///     Test implementation of <see cref="IGenericAction{TParam}" /> for <see cref="GenericEvent" /> tests.
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
