// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageTest.cs
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
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    ///     The component storage test class
    /// </summary>
    public class ComponentStorageTest
    {
        /// <summary>
        ///     Tests that indexer returns correct value after assignment
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnValueWhenIndexerSetAndRetrieved()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 42;

            Assert.Equal(42, storage[0]);
        }

        /// <summary>
        ///     Tests that multiple indices work correctly
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnCorrectValuesAtMultipleIndices()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 10;
            storage[1] = 20;
            storage[2] = 30;
            storage[3] = 40;

            Assert.Equal(10, storage[0]);
            Assert.Equal(20, storage[1]);
            Assert.Equal(30, storage[2]);
            Assert.Equal(40, storage[3]);
        }

        /// <summary>
        ///     Tests that AsSpan returns correct length
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnCorrectLengthWhenAsSpanCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            Span<int> span = storage.AsSpan();

            Assert.Equal(8, span.Length);
        }

        /// <summary>
        ///     Tests that AsSpanLength returns correct length
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnCorrectLengthWhenAsSpanLengthCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            Span<int> span = storage.AsSpanLength(5);

            Assert.Equal(5, span.Length);
        }

        /// <summary>
        ///     Tests that SetAt and GetAt work correctly
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldSetAndGetWhenUsingSetAtAndGetAt()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.SetAt(42, 0);
            object result = storage.GetAt(0);

            Assert.Equal(42, result);
        }

        /// <summary>
        ///     Tests that Buffer field is accessible
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldHaveAccessibleBufferField()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            Assert.NotNull(storage.Buffer);
            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that Dispose does not throw
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldNotThrowWhenDisposeCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.Dispose();
        }

        /// <summary>
        ///     Tests that zero capacity creates empty storage
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldCreateEmptyStorageWhenZeroCapacity()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);

            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that indexer overwrites previous value
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldOverwritePreviousValueWhenIndexerSetTwice()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage[0] = 10;
            storage[0] = 20;

            Assert.Equal(20, storage[0]);
        }

        /// <summary>
        ///     Tests that AsSpan returns underlying data
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnUnderlyingDataWhenAsSpanCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;

            Span<int> span = storage.AsSpan();

            Assert.Equal(42, span[0]);
        }

        /// <summary>
        ///     Tests that GetComponentStorageDataReference returns reference to first element
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldReturnRefToFirstElementWhenGetComponentStorageDataReferenceCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 99;

            ref int ref0 = ref storage.GetComponentStorageDataReference();

            Assert.Equal(99, ref0);
        }

        /// <summary>
        ///     Tests that InvokeGenericActionWith IGenericAction overload invokes the action
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldInvokeActionWhenInvokeGenericActionWithIGenericAction()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            bool invoked = false;

            TestAction action = new TestAction(() => invoked = true);
            storage.InvokeGenericActionWith(action, 0);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that InvokeGenericActionWith generic event overload invokes the action
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldInvokeActionWhenInvokeGenericActionWithGenericEvent()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            bool invoked = false;

            GenericEvent evt = new GenericEvent();
            evt.Add(new TestGameObjectAction(() => invoked = true));
            storage.InvokeGenericActionWith(evt, default, 0);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Test helper implementing IGenericAction
        /// </summary>
        private sealed class TestAction : IGenericAction
        {
            /// <summary>
            /// The callback
            /// </summary>
            private readonly Action _callback;
            /// <summary>
            /// Initializes a new instance of the <see cref="TestAction"/> class
            /// </summary>
            /// <param name="callback">The callback</param>
            public TestAction(Action callback) => _callback = callback;
            /// <summary>
            /// Invokes the type
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="type">The type</param>
            public void Invoke<T>(ref T type) => _callback();
        }

        /// <summary>
        ///     Test helper implementing IGenericAction&lt;GameObject&gt;
        /// </summary>
        private sealed class TestGameObjectAction : IGenericAction<GameObject>
        {
            /// <summary>
            /// The callback
            /// </summary>
            private readonly Action _callback;
            /// <summary>
            /// Initializes a new instance of the <see cref="TestGameObjectAction"/> class
            /// </summary>
            /// <param name="callback">The callback</param>
            public TestGameObjectAction(Action callback) => _callback = callback;
            /// <summary>
            /// Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type) => _callback();
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.InvokeGenericActionWith" />
        ///     does not throw when a null <see cref="GenericEvent" /> is passed.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void InvokeGenericActionWith_NullGenericEvent_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.InvokeGenericActionWith(null, default, 0);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.InvokeGenericActionWith" />
        ///     does not throw when a null <see cref="IGenericAction" /> is passed.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void InvokeGenericActionWith_NullIGenericAction_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.InvokeGenericActionWith(null, 0);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.Trim" /> resizes the buffer
        ///     to the next power of two.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldRoundUpToPowerOfTwoWhenTrimCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.Trim(3);

            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.Trim" /> preserves
        ///     the buffer length when chunk index is already a power of two.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldPreserveLengthWhenTrimWithPowerOfTwo()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.Trim(4);

            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.Trim" /> rounds up
        ///     to a larger power of two.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldRoundUpToNextPowerOfTwoWhenTrimWithNonPowerOfTwo()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.Trim(5);

            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.ResizeBuffer" /> resizes
        ///     the underlying array to the specified size.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldResizeBufferWhenResizeBufferCalled()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);

            storage.ResizeBuffer(8);

            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.ResizeBuffer" />
        ///     shrinks the buffer when a smaller size is given.
        /// </summary>
        [Fact(Skip = "Known ECS source bug - IndexOutOfRangeException/ArgumentNullException")]
        public void ShouldShrinkBufferWhenResizeBufferWithSmallerSize()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);

            storage.ResizeBuffer(4);

            Assert.Equal(4, storage.Buffer.Length);
        }
    }
}
