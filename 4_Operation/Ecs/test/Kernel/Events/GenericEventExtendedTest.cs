// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericEventExtendedTest.cs
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
using System.Reflection;
using Alis.Core.Ecs.Kernel.Events;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel.Events
{
    /// <summary>
    ///     Extended tests for <see cref="GenericEvent" /> covering edge cases and remaining uncovered paths.
    /// </summary>
    public class GenericEventExtendedTest
    {
        /// <summary>
        ///     Tests that <see cref="GenericEvent.Equals(object)" /> returns <see langword="true" /> when comparing
        ///     the same reference.
        /// </summary>
        [Fact]
        public void Equals_WithSameReference_ReturnsTrue()
        {
            GenericEvent e = CreateGenericEvent();

            bool result = e.Equals(e);

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Equals(object)" /> returns <see langword="false" /> when comparing
        ///     with a different instance.
        /// </summary>
        [Fact]
        public void Equals_WithDifferentInstance_ReturnsFalse()
        {
            GenericEvent a = CreateGenericEvent();
            GenericEvent b = CreateGenericEvent();

            bool result = a.Equals(b);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Equals(object)" /> returns <see langword="false" /> when the
        ///     argument is <see langword="null" />.
        /// </summary>
        [Fact]
        public void Equals_WithNull_ReturnsFalse()
        {
            GenericEvent e = CreateGenericEvent();

            bool result = e.Equals(null);

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.GetHashCode" /> returns zero.
        /// </summary>
        [Fact]
        public void GetHashCode_Always_ReturnsZero()
        {
            GenericEvent e = CreateGenericEvent();

            int hash = e.GetHashCode();

            Assert.Equal(0, hash);
        }

        /// <summary>
        ///     Tests that the <c>==</c> operator returns <see langword="true" /> when comparing the same reference.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithSameReference_ReturnsTrue()
        {
            GenericEvent e = CreateGenericEvent();

            bool result = e == e;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that the <c>==</c> operator returns <see langword="false" /> when comparing different references.
        /// </summary>
        [Fact]
        public void EqualityOperator_WithDifferentReferences_ReturnsFalse()
        {
            GenericEvent a = CreateGenericEvent();
            GenericEvent b = CreateGenericEvent();

            bool result = a == b;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that the <c>!=</c> operator returns <see langword="true" /> when comparing different references.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithDifferentReferences_ReturnsTrue()
        {
            GenericEvent a = CreateGenericEvent();
            GenericEvent b = CreateGenericEvent();

            bool result = a != b;

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that the <c>!=</c> operator returns <see langword="false" /> when comparing the same reference.
        /// </summary>
        [Fact]
        public void InequalityOperator_WithSameReference_ReturnsFalse()
        {
            GenericEvent e = CreateGenericEvent();

            bool result = e != e;

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that <see cref="GenericEvent.Invoke{T}" /> is safe to call when no listeners have been added.
        /// </summary>
        [Fact]
        public void Invoke_WithNoListeners_DoesNotThrow()
        {
            GenericEvent e = CreateGenericEvent();
            int value = 42;

            InvokeInternalInvokeOfInt(e, value);
        }

        /// <summary>
        ///     Tests that the <c>+</c> operator correctly pushes to the invocation stack when
        ///     <c>_first</c> already has a value.
        /// </summary>
        [Fact]
        public void OperatorPlus_WithExistingFirst_AddsToStack()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction first = new CaptureAction();
            CaptureAction second = new CaptureAction();

            e += first;
            e += second;

            int value = 99;
            InvokeInternalInvokeOfInt(e, value);

            Assert.Equal(1, first.Calls);
            Assert.Equal(1, second.Calls);
            Assert.Equal(99, first.LastIntValue);
            Assert.Equal(99, second.LastIntValue);
        }

        /// <summary>
        ///     Creates a new <see cref="GenericEvent" /> instance using the internal constructor.
        /// </summary>
        /// <returns>A new <see cref="GenericEvent" /> instance.</returns>
        private static GenericEvent CreateGenericEvent()
        {
            ConstructorInfo ctor = typeof(GenericEvent).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                Type.EmptyTypes,
                null)!;
            return (GenericEvent) ctor.Invoke(null);
        }

        /// <summary>
        ///     Invokes the internal <see cref="GenericEvent.Invoke{T}" /> method with an <c>int</c> argument.
        /// </summary>
        /// <param name="e">The event instance.</param>
        /// <param name="value">The integer value to pass.</param>
        private static void InvokeInternalInvokeOfInt(GenericEvent e, int value)
        {
            MethodInfo method = typeof(GenericEvent).GetMethod("Invoke", BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeof(int));
            object[] args = [default(GameObject), value];
            method.Invoke(e, args);
        }

        /// <summary>
        ///     A test helper that implements <see cref="IGenericAction{GameObject}" /> to capture invocation data.
        /// </summary>
        private sealed class CaptureAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Gets the number of times <see cref="Invoke{T}" /> was called.
            /// </summary>
            internal int Calls;

            /// <summary>
            ///     Gets the last integer value passed to <see cref="Invoke{T}" />.
            /// </summary>
            internal int LastIntValue;

            /// <summary>
            ///     Invokes the action with the given parameters.
            /// </summary>
            /// <typeparam name="T">The type of the argument.</typeparam>
            /// <param name="param">The game object parameter.</param>
            /// <param name="type">The typed argument.</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                Calls++;
                if (typeof(T) == typeof(int))
                {
                    LastIntValue = (int) (object) type;
                }
            }
        }
    }
}
