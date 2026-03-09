// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GenericEventTest.cs
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
    ///     Tests for <see cref="GenericEvent" />.
    /// </summary>
    public class GenericEventTest
    {
        /// <summary>
        /// Tests that generic event when created has no listeners
        /// </summary>
        [Fact]
        public void GenericEvent_WhenCreated_HasNoListeners()
        {
            GenericEvent e = CreateGenericEvent();

            Assert.False(GetHasListeners(e));
        }

        /// <summary>
        /// Tests that add with single action sets has listeners true
        /// </summary>
        [Fact]
        public void Add_WithSingleAction_SetsHasListenersTrue()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction action = new CaptureAction();

            InvokeInternalAdd(e, action);

            Assert.True(GetHasListeners(e));
        }

        /// <summary>
        /// Tests that invoke with single action invokes action with expected type
        /// </summary>
        [Fact]
        public void Invoke_WithSingleAction_InvokesActionWithExpectedType()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction action = new CaptureAction();
            InvokeInternalAdd(e, action);

            int value = 42;
            InvokeInternalInvokeOfInt(e, value);

            Assert.Equal(1, action.Calls);
            Assert.Equal(typeof(int), action.LastType);
            Assert.Equal(42, action.LastIntValue);
        }

        /// <summary>
        /// Tests that invoke with multiple actions invokes all registered actions
        /// </summary>
        [Fact]
        public void Invoke_WithMultipleActions_InvokesAllRegisteredActions()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction a1 = new CaptureAction();
            CaptureAction a2 = new CaptureAction();
            CaptureAction a3 = new CaptureAction();

            InvokeInternalAdd(e, a1);
            InvokeInternalAdd(e, a2);
            InvokeInternalAdd(e, a3);

            int value = 7;
            InvokeInternalInvokeOfInt(e, value);

            Assert.Equal(1, a1.Calls);
            Assert.Equal(1, a2.Calls);
            Assert.Equal(1, a3.Calls);
        }

        /// <summary>
        /// Tests that remove with only action clears has listeners
        /// </summary>
        [Fact]
        public void Remove_WithOnlyAction_ClearsHasListeners()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction action = new CaptureAction();

            InvokeInternalAdd(e, action);
            InvokeInternalRemove(e, action);

            Assert.False(GetHasListeners(e));
        }

        /// <summary>
        /// Tests that remove with first action from multiple keeps others invokable
        /// </summary>
        [Fact]
        public void Remove_WithFirstActionFromMultiple_KeepsOthersInvokable()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction a1 = new CaptureAction();
            CaptureAction a2 = new CaptureAction();
            CaptureAction a3 = new CaptureAction();

            InvokeInternalAdd(e, a1);
            InvokeInternalAdd(e, a2);
            InvokeInternalAdd(e, a3);

            InvokeInternalRemove(e, a1);
            int value = 9;
            InvokeInternalInvokeOfInt(e, value);

            Assert.Equal(0, a1.Calls);
            Assert.Equal(1, a2.Calls);
            Assert.Equal(1, a3.Calls);
            Assert.True(GetHasListeners(e));
        }

        /// <summary>
        /// Tests that remove with non existing action does not affect existing actions
        /// </summary>
        [Fact]
        public void Remove_WithNonExistingAction_DoesNotAffectExistingActions()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction existing = new CaptureAction();
            CaptureAction nonExisting = new CaptureAction();

            InvokeInternalAdd(e, existing);
            InvokeInternalRemove(e, nonExisting);

            int value = 5;
            InvokeInternalInvokeOfInt(e, value);

            Assert.Equal(1, existing.Calls);
            Assert.True(GetHasListeners(e));
        }

        /// <summary>
        /// Tests that operator plus minus with null left returns null
        /// </summary>
        [Fact]
        public void OperatorPlusMinus_WithNullLeft_ReturnsNull()
        {
            GenericEvent e = null;
            CaptureAction action = new CaptureAction();

            GenericEvent addResult = e + action;
            GenericEvent removeResult = e - action;

            Assert.Null(addResult);
            Assert.Null(removeResult);
        }

        /// <summary>
        /// Tests that operator plus minus with valid event adds and removes action
        /// </summary>
        [Fact]
        public void OperatorPlusMinus_WithValidEvent_AddsAndRemovesAction()
        {
            GenericEvent e = CreateGenericEvent();
            CaptureAction action = new CaptureAction();

            e += action;
            Assert.True(GetHasListeners(e));

            e -= action;
            Assert.False(GetHasListeners(e));
        }

        /// <summary>
        /// Creates the generic event
        /// </summary>
        /// <returns>The generic event</returns>
        private static GenericEvent CreateGenericEvent()
        {
            ConstructorInfo ctor = typeof(GenericEvent).GetConstructor(BindingFlags.Instance | BindingFlags.NonPublic,
                binder: null,
                Type.EmptyTypes,
                modifiers: null)!;
            return (GenericEvent) ctor.Invoke(null);
        }

        /// <summary>
        /// Gets the has listeners using the specified e
        /// </summary>
        /// <param name="e">The </param>
        /// <returns>The bool</returns>
        private static bool GetHasListeners(GenericEvent e)
        {
            PropertyInfo prop = typeof(GenericEvent).GetProperty("HasListeners",
                BindingFlags.Instance | BindingFlags.NonPublic)!;
            return (bool) prop.GetValue(e)!;
        }

        /// <summary>
        /// Invokes the internal add using the specified e
        /// </summary>
        /// <param name="e">The </param>
        /// <param name="action">The action</param>
        private static void InvokeInternalAdd(GenericEvent e, IGenericAction<GameObject> action)
        {
            MethodInfo method = typeof(GenericEvent).GetMethod("Add", BindingFlags.Instance | BindingFlags.NonPublic)!;
            method.Invoke(e, [action]);
        }

        /// <summary>
        /// Invokes the internal remove using the specified e
        /// </summary>
        /// <param name="e">The </param>
        /// <param name="action">The action</param>
        private static void InvokeInternalRemove(GenericEvent e, IGenericAction<GameObject> action)
        {
            MethodInfo method = typeof(GenericEvent).GetMethod("Remove", BindingFlags.Instance | BindingFlags.NonPublic)!;
            method.Invoke(e, [action]);
        }

        /// <summary>
        /// Invokes the internal invoke of int using the specified e
        /// </summary>
        /// <param name="e">The </param>
        /// <param name="value">The value</param>
        private static void InvokeInternalInvokeOfInt(GenericEvent e, int value)
        {
            MethodInfo method = typeof(GenericEvent).GetMethod("Invoke", BindingFlags.Instance | BindingFlags.NonPublic)!
                .MakeGenericMethod(typeof(int));
            object[] args = [default(GameObject), value];
            method.Invoke(e, args);
        }

        /// <summary>
        /// The capture action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}"/>
        private sealed class CaptureAction : IGenericAction<GameObject>
        {
            /// <summary>
            /// The calls
            /// </summary>
            internal int Calls;
            /// <summary>
            /// The last type
            /// </summary>
            internal Type LastType;
            /// <summary>
            /// The last int value
            /// </summary>
            internal int LastIntValue;

            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                Calls++;
                LastType = typeof(T);
                if (typeof(T) == typeof(int))
                {
                    LastIntValue = (int) (object) type;
                }
            }
        }
    }
}

