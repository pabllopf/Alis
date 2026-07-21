// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentHandleRemainingCoverageTests.cs
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
using Alis.Core.Ecs;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Kernel
{
    /// <summary>
    ///     Remaining coverage tests for <see cref="ComponentHandle" />.
    /// </summary>
    public class ComponentHandleRemainingCoverageTests
    {
        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.ComponentId" /> matches
        ///     <see cref="Component{T}.Id" /> after creation via <see cref="NoneUpdate{T}.Store" />.
        /// </summary>
        [Fact]
        public void ComponentId_AfterStore_MatchesComponentIntId()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);

            Assert.Equal(Component<int>.Id, handle.ComponentId);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.Equals(ComponentHandle)" /> returns
        ///     <see langword="true" /> when comparing a handle to itself.
        /// </summary>
        [Fact]
        public void Equals_SameHandle_ReturnsTrue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);

            Assert.True(handle.Equals(handle));
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.Equals(ComponentHandle)" /> returns
        ///     <see langword="false" /> when comparing two different handles.
        /// </summary>
        [Fact]
        public void Equals_DifferentHandles_ReturnsFalse()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            storage[1] = 99;
            ComponentHandle handleA = storage.Store(0);
            ComponentHandle handleB = storage.Store(1);

            Assert.False(handleA.Equals(handleB));
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.Equals(object)" /> returns
        ///     <see langword="true" /> when the object is the same handle.
        /// </summary>
        [Fact]
        public void Equals_Object_WithSameHandle_ReturnsTrue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);
            object boxed = handle;

            Assert.True(handle.Equals(boxed));
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.Equals(object)" /> returns
        ///     <see langword="false" /> when the object is <see langword="null" />.
        /// </summary>
        [Fact]
        public void Equals_Object_WithNull_ReturnsFalse()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);

            Assert.False(handle.Equals(null));
        }

        /// <summary>
        ///     Verifies that <c>==</c> returns <see langword="true" /> for equal handles.
        /// </summary>
        [Fact]
        public void OperatorEquals_EqualHandles_ReturnsTrue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handleA = storage.Store(0);
            ComponentHandle handleB = handleA;

            Assert.True(handleA == handleB);
        }

        /// <summary>
        ///     Verifies that <c>!=</c> returns <see langword="true" /> for different handles.
        /// </summary>
        [Fact]
        public void OperatorNotEquals_DifferentHandles_ReturnsTrue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            storage[1] = 99;
            ComponentHandle handleA = storage.Store(0);
            ComponentHandle handleB = storage.Store(1);

            Assert.True(handleA != handleB);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.GetHashCode" /> returns the same value
        ///     when called multiple times on the same handle.
        /// </summary>
        [Fact]
        public void GetHashCode_SameHandle_ReturnsSameValue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);

            int hash1 = handle.GetHashCode();
            int hash2 = handle.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.GetHashCode" /> returns equal values for
        ///     equal handles.
        /// </summary>
        [Fact]
        public void GetHashCode_EqualHandles_ReturnsEqualValues()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handleA = storage.Store(0);
            ComponentHandle handleB = handleA;

            Assert.Equal(handleA.GetHashCode(), handleB.GetHashCode());
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.Retrieve{T}" /> returns the stored value
        ///     after creation via <see cref="NoneUpdate{T}.Store" />.
        /// </summary>
        [Fact]
        public void Retrieve_AfterStore_ReturnsStoredValue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);

            int result = handle.Retrieve<int>();

            Assert.Equal(42, result);
        }

        /// <summary>
        ///     Verifies that a default <see cref="ComponentHandle" /> has a default
        ///     <see cref="ComponentHandle.ComponentId" />.
        /// </summary>
        [Fact]
        public void DefaultHandle_ComponentId_IsDefault()
        {
            ComponentHandle handle = default;

            Assert.Equal(default(ComponentId), handle.ComponentId);
        }

        /// <summary>
        ///     Verifies that two default <see cref="ComponentHandle" /> values are equal.
        /// </summary>
        [Fact]
        public void DefaultHandle_EqualsDefault_ReturnsTrue()
        {
            ComponentHandle handleA = default;
            ComponentHandle handleB = default;

            Assert.True(handleA.Equals(handleB));
        }

        /// <summary>
        ///     Verifies that <c>==</c> returns <see langword="true" /> for two default handles.
        /// </summary>
        [Fact]
        public void DefaultHandle_OperatorEquals_ReturnsTrue()
        {
            ComponentHandle handleA = default;
            ComponentHandle handleB = default;

            Assert.True(handleA == handleB);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.GetHashCode" /> is consistent for a
        ///     default handle.
        /// </summary>
        [Fact]
        public void DefaultHandle_GetHashCode_ReturnsConsistentValue()
        {
            ComponentHandle handle = default;

            int hash1 = handle.GetHashCode();
            int hash2 = handle.GetHashCode();

            Assert.Equal(hash1, hash2);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.ComponentId" /> is default for a default
        ///     handle.
        /// </summary>
        [Fact]
        public void DefaultHandle_Type_IsVoid()
        {
            ComponentHandle handle = default;

            Assert.Equal(typeof(void), handle.Type);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.DebuggerDisplayString" /> returns "null"
        ///     when the backing storage has been consumed.
        /// </summary>
        [Fact]
        public void DebuggerDisplayString_AfterDispose_ReturnsNull()
        {
            ComponentHandle handle = ComponentHandle.Create<string>("test");
            handle.Dispose();

            string display = handle.DebuggerDisplayString;

            Assert.Equal("null", display);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.ParentTable" /> returns the underlying
        ///     <see cref="IdTable" /> storage for a valid handle.
        /// </summary>
        [Fact]
        public void ParentTable_ForValidHandle_ReturnsStorage()
        {
            ComponentHandle handle = ComponentHandle.Create<int>(42);

            IdTable table = handle.ParentTable;

            Assert.NotNull(table);
        }

        /// <summary>
        ///     Verifies that <see cref="ComponentHandle.InvokeComponentEventAndConsume" /> invokes
        ///     the event and consumes the component slot.
        /// </summary>
        [Fact]
        public void InvokeComponentEventAndConsume_WithEvent_InvokesAndConsumes()
        {
            ComponentHandle handle = ComponentHandle.Create<int>(99);
            Scene scene = new Scene();
            GameObject gameObject = scene.Create();
            GenericEvent evt = new GenericEvent();
            CountingAction action = new CountingAction();
            evt += action;

            handle.InvokeComponentEventAndConsume(gameObject, evt);

            Assert.Equal(1, action.CallCount);
        }

        /// <summary>
        ///     The counting action class
        /// </summary>
        private sealed class CountingAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Gets or sets the call count
            /// </summary>
            public int CallCount { get; set; }

            /// <summary>
            ///     Invokes the specified param
            /// </summary>
            /// <typeparam name="T">The type</typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                CallCount++;
            }
        }
    }
}
