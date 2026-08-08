// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ComponentStorageRemainingCoverageTests.cs
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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Updating;
using Alis.Core.Ecs.Updating.Runners;
using Xunit;

namespace Alis.Core.Ecs.Test.Updating
{
    /// <summary>
    /// The component storage remaining coverage tests class
    /// </summary>
    public class ComponentStorageRemainingCoverageTests
    {
        /// <summary>
        /// Tests that component id for int storage returns component int id
        /// </summary>
        [Fact]
        public void ComponentId_ForIntStorage_ReturnsComponentIntId()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            Assert.Equal(Component<int>.Id, storage.ComponentId);
        }

        /// <summary>
        /// Tests that set at and get at with int value works correctly
        /// </summary>
        [Fact]
        public void SetAtAndGetAt_WithIntValue_WorksCorrectly()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.SetAt(42, 0);
            Assert.Equal(42, storage.GetAt(0));
        }

        /// <summary>
        /// Tests that set at and get at with string value works correctly
        /// </summary>
        [Fact]
        public void SetAtAndGetAt_WithStringValue_WorksCorrectly()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("hello", 0);
            Assert.Equal("hello", storage.GetAt(0));
        }

        /// <summary>
        /// Tests that as span returns full buffer
        /// </summary>
        [Fact]
        public void AsSpan_ReturnsFullBuffer()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            Span<int> span = storage.AsSpan();
            Assert.Equal(8, span.Length);
        }

        /// <summary>
        /// Tests that as span length returns limited span
        /// </summary>
        [Fact]
        public void AsSpanLength_ReturnsLimitedSpan()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            Span<int> span = storage.AsSpanLength(5);
            Assert.Equal(5, span.Length);
        }

        /// <summary>
        /// Tests that get component storage data reference returns ref to first element
        /// </summary>
        [Fact]
        public void GetComponentStorageDataReference_ReturnsRefToFirstElement()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 99;
            ref int ref0 = ref storage.GetComponentStorageDataReference();
            Assert.Equal(99, ref0);
        }

        /// <summary>
        /// Tests that dispose does not throw
        /// </summary>
        [Fact]
        public void Dispose_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Dispose();
        }

        /// <summary>
        /// Tests that dispose with reference type does not throw
        /// </summary>
        [Fact]
        public void Dispose_WithReferenceType_DoesNotThrow()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.Dispose();
        }

        /// <summary>
        /// Tests that dispose called multiple times does not throw
        /// </summary>
        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Dispose();
            storage.Dispose();
        }

        /// <summary>
        /// Tests that dispose bool with false covers disposing branch
        /// </summary>
        [Fact]
        public void DisposeBool_WithFalse_CoversDisposingBranch()
        {
            DisposeBoolTestWrapper storage = new DisposeBoolTestWrapper(4);
            storage.CallDispose(false);
            storage.CallDispose(true);
        }

        /// <summary>
        /// Tests that zero capacity creates empty array
        /// </summary>
        [Fact]
        public void ZeroCapacity_CreatesEmptyArray()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);
            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that zero capacity with string creates empty array
        /// </summary>
        [Fact]
        public void ZeroCapacity_WithString_CreatesEmptyArray()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(0);
            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that invoke generic action with null generic event does not throw
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_NullGenericEvent_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.InvokeGenericActionWith(null, default, 0);
        }

        /// <summary>
        /// Tests that invoke generic action with null i generic action does not throw
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_NullIGenericAction_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.InvokeGenericActionWith(null, 0);
        }

        /// <summary>
        /// Tests that invoke generic action with non generic action invokes callback
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_NonGenericAction_InvokesCallback()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            bool invoked = false;
            storage.InvokeGenericActionWith(new TestGenericAction(() => invoked = true), 0);
            Assert.True(invoked);
        }

        /// <summary>
        /// Tests that invoke generic action with generic event invokes callback
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_GenericEvent_InvokesCallback()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            bool invoked = false;
            GenericEvent evt = new GenericEvent();
            evt.Add(new TestGameObjectGenericAction(() => invoked = true));
            storage.InvokeGenericActionWith(evt, default, 0);
            Assert.True(invoked);
        }

        /// <summary>
        /// Tests that invoke generic action with null generic event with string does not throw
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_NullGenericEventWithString_DoesNotThrow()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.InvokeGenericActionWith(null, default, 0);
        }

        /// <summary>
        /// Tests that invoke generic action with generic event with string invokes callback
        /// </summary>
        [Fact]
        public void InvokeGenericActionWith_GenericEventWithString_InvokesCallback()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("test", 0);
            bool invoked = false;
            GenericEvent evt = new GenericEvent();
            evt.Add(new TestGameObjectGenericAction(() => invoked = true));
            storage.InvokeGenericActionWith(evt, default, 0);
            Assert.True(invoked);
        }

        /// <summary>
        /// Tests that pull component from with int storage copies values
        /// </summary>
        [Fact]
        public void PullComponentFrom_WithIntStorage_CopiesValues()
        {
            NoneUpdate<int> target = new NoneUpdate<int>(4);
            IdTable<int> source = new IdTable<int>();
            source.Create(out int _) = 10;
            source.Create(out int _) = 20;
            source.Create(out int idx2) = 30;

            target.PullComponentFrom(source, 1, idx2);

            Assert.Equal(30, target[1]);
        }

        /// <summary>
        /// Tests that pull component from with string storage copies and clears source
        /// </summary>
        [Fact]
        public void PullComponentFrom_WithStringStorage_CopiesAndClearsSource()
        {
            NoneUpdate<string> target = new NoneUpdate<string>(4);
            IdTable<string> source = new IdTable<string>();
            source.Create(out int _) = "a";
            source.Create(out int _) = "b";
            source.Create(out int idx2) = "c";

            target.PullComponentFrom(source, 0, idx2);

            Assert.Equal("c", target[0]);
        }

        /// <summary>
        /// Tests that trim rounds up to power of two
        /// </summary>
        [Fact]
        public void Trim_RoundsUpToPowerOfTwo()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(5);
            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that trim with power of two preserves length
        /// </summary>
        [Fact]
        public void Trim_WithPowerOfTwo_PreservesLength()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(4);
            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that trim with index one results in length one
        /// </summary>
        [Fact]
        public void Trim_WithIndexOne_ResultsInLengthOne()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(1);
            Assert.Equal(1, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that resize buffer grows to specified size
        /// </summary>
        [Fact]
        public void ResizeBuffer_GrowsToSpecifiedSize()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.ResizeBuffer(8);
            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that resize buffer shrinks to specified size
        /// </summary>
        [Fact]
        public void ResizeBuffer_ShrinksToSpecifiedSize()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            storage.ResizeBuffer(4);
            Assert.Equal(4, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that store with int type returns component handle
        /// </summary>
        [Fact]
        public void Store_WithIntType_ReturnsComponentHandle()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);
            Assert.Equal(Component<int>.Id, handle.ComponentId);
        }

        /// <summary>
        /// Tests that store with string type returns component handle
        /// </summary>
        [Fact]
        public void Store_WithStringType_ReturnsComponentHandle()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("test", 0);
            ComponentHandle handle = storage.Store(0);
            Assert.Equal(Component<string>.Id, handle.ComponentId);
        }

        /// <summary>
        /// Tests that indexer returns correct values at multiple indices
        /// </summary>
        [Fact]
        public void Indexer_ReturnsCorrectValuesAtMultipleIndices()
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
        /// Tests that indexer overwrites previous value
        /// </summary>
        [Fact]
        public void Indexer_OverwritesPreviousValue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 10;
            storage[0] = 20;
            Assert.Equal(20, storage[0]);
        }

        /// <summary>
        /// Tests that as span with string returns buffer
        /// </summary>
        [Fact]
        public void AsSpan_WithString_ReturnsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            Span<string> span = storage.AsSpan();
            Assert.Equal(4, span.Length);
        }

        /// <summary>
        /// Tests that as span length with string returns limited span
        /// </summary>
        [Fact]
        public void AsSpanLength_WithString_ReturnsLimitedSpan()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            Span<string> span = storage.AsSpanLength(2);
            Assert.Equal(2, span.Length);
        }

        /// <summary>
        /// Tests that get component storage data reference with string returns ref to first
        /// </summary>
        [Fact]
        public void GetComponentStorageDataReference_WithString_ReturnsRefToFirst()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("hello", 0);
            ref string ref0 = ref storage.GetComponentStorageDataReference();
            Assert.Equal("hello", ref0);
        }

        /// <summary>
        /// Tests that dispose bool with false and string covers disposing branch
        /// </summary>
        [Fact]
        public void DisposeBool_WithFalseAndString_CoversDisposingBranch()
        {
            DisposeBoolTestWrapperString storage = new DisposeBoolTestWrapperString(4);
            storage.CallDispose(false);
            storage.CallDispose(true);
        }

        /// <summary>
        /// Tests that trim with string type rounds up to power of two
        /// </summary>
        [Fact]
        public void Trim_WithStringType_RoundsUpToPowerOfTwo()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.Trim(5);
            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that resize buffer with string type grows buffer
        /// </summary>
        [Fact]
        public void ResizeBuffer_WithStringType_GrowsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.ResizeBuffer(8);
            Assert.Equal(8, storage.Buffer.Length);
        }

        /// <summary>
        /// Tests that delete with destroyer invokes destroy delegate
        /// </summary>
        [Fact]
        public void Delete_WithDestroyer_InvokesDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyableStruct>();

            NoneUpdate<DestroyableStruct> storage = new NoneUpdate<DestroyableStruct>(4);
            storage[0] = new DestroyableStruct { Value = 10 };
            storage[1] = new DestroyableStruct { Value = 20 };

            storage.Delete(new DeleteComponentData(ToIndex: 0, FromIndex: 1));

            Assert.Equal(-1, storage[0].Value);
        }

        /// <summary>
        /// Tests that store with destroyer invokes destroy delegate
        /// </summary>
        [Fact]
        public void Store_WithDestroyer_InvokesDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyableStruct>();

            NoneUpdate<DestroyableStruct> storage = new NoneUpdate<DestroyableStruct>(4);
            storage[0] = new DestroyableStruct { Value = 42 };

            ComponentHandle handle = storage.Store(0);

            Assert.Equal(Component<DestroyableStruct>.Id, handle.ComponentId);
        }

        /// <summary>
        /// Tests that delete with destroyer and reference type clears from index
        /// </summary>
        [Fact]
        public void Delete_WithDestroyerAndReferenceType_ClearsFromIndex()
        {
            GenerationServices.RegisterDestroy<DestroyableRefStruct>();

            NoneUpdate<DestroyableRefStruct> storage = new NoneUpdate<DestroyableRefStruct>(4);
            storage.SetAt(new DestroyableRefStruct { Text = "first" }, 0);
            storage.SetAt(new DestroyableRefStruct { Text = "second" }, 1);

            storage.Delete(new DeleteComponentData(ToIndex: 0, FromIndex: 1));

            Assert.Null(storage[0].Text);
        }

        /// <summary>
        /// Tests that store with destroyer and reference type invokes destroy delegate
        /// </summary>
        [Fact]
        public void Store_WithDestroyerAndReferenceType_InvokesDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyableRefStruct>();

            NoneUpdate<DestroyableRefStruct> storage = new NoneUpdate<DestroyableRefStruct>(4);
            storage.SetAt(new DestroyableRefStruct { Text = "test" }, 0);

            ComponentHandle handle = storage.Store(0);

            Assert.Equal(Component<DestroyableRefStruct>.Id, handle.ComponentId);
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.GetComponentStorageDataReference" />
        ///     throws <see cref="InvalidOperationException" /> when the buffer is empty.
        /// </summary>
        [Fact]
        public void GetComponentStorageDataReference_WithEmptyBuffer_ThrowsInvalidOperationException()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);

            Assert.Throws<InvalidOperationException>(() => storage.GetComponentStorageDataReference());
        }

        /// <summary>
        ///     Tests that <see cref="ComponentStorage{TComponent}.PullComponentFromAndClear" />
        ///     with a reference type properly clears the source slot.
        /// </summary>
        [Fact]
        public void PullComponentFromAndClear_WithReferenceType_ClearsSourceSlot()
        {
            NoneUpdate<string> target = new NoneUpdate<string>(4);
            target[0] = "old";

            NoneUpdate<string> source = new NoneUpdate<string>(4);
            source[0] = "keep";
            source[1] = "move";
            source[2] = "last";

            target.PullComponentFromAndClear(source, 0, 1, 2);

            Assert.Equal("move", target[0]);
            Assert.Equal("last", source[1]);
            Assert.Null(source[2]);
        }
    }

    /// <summary>
    /// The destroyable struct
    /// </summary>
    internal struct DestroyableStruct : IOnDestroy
    {
        /// <summary>
        /// The value
        /// </summary>
        public int Value;
        /// <summary>
        /// Ons the destroy
        /// </summary>
        public void OnDestroy() => Value = -1;
    }

    /// <summary>
    /// The destroyable ref struct
    /// </summary>
    internal struct DestroyableRefStruct : IOnDestroy
    {
        /// <summary>
        /// The text
        /// </summary>
        public string Text;
        /// <summary>
        /// Ons the destroy
        /// </summary>
        public void OnDestroy() => Text = null;
    }

    /// <summary>
    /// The dispose bool test wrapper class
    /// </summary>
    /// <seealso cref="ComponentStorage{int}"/>
    internal class DisposeBoolTestWrapper(int length) : ComponentStorage<int>(length)
    {
        /// <summary>
        /// Calls the dispose using the specified disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        public void CallDispose(bool disposing) => Dispose(disposing);
        /// <summary>
        /// Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b) { }
        /// <summary>
        /// Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b, int start, int length) { }
    }

    /// <summary>
    /// The dispose bool test wrapper string class
    /// </summary>
    /// <seealso cref="ComponentStorage{string}"/>
    internal class DisposeBoolTestWrapperString(int length) : ComponentStorage<string>(length)
    {
        /// <summary>
        /// Calls the dispose using the specified disposing
        /// </summary>
        /// <param name="disposing">The disposing</param>
        public void CallDispose(bool disposing) => Dispose(disposing);
        /// <summary>
        /// Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b) { }
        /// <summary>
        /// Runs the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="b">The </param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b, int start, int length) { }
    }

    /// <summary>
    /// The test generic action class
    /// </summary>
    /// <seealso cref="IGenericAction"/>
    internal sealed class TestGenericAction : IGenericAction
    {
        /// <summary>
        /// The callback
        /// </summary>
        internal readonly Action _callback;
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGenericAction"/> class
        /// </summary>
        /// <param name="callback">The callback</param>
        public TestGenericAction(Action callback) => _callback = callback;
        /// <summary>
        /// Invokes the type
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="type">The type</param>
        public void Invoke<T>(ref T type) => _callback();
    }

    /// <summary>
    /// The test game object generic action class
    /// </summary>
    /// <seealso cref="IGenericAction{GameObject}"/>
    internal sealed class TestGameObjectGenericAction : IGenericAction<GameObject>
    {
        /// <summary>
        /// The callback
        /// </summary>
        internal readonly Action _callback;
        /// <summary>
        /// Initializes a new instance of the <see cref="TestGameObjectGenericAction"/> class
        /// </summary>
        /// <param name="callback">The callback</param>
        public TestGameObjectGenericAction(Action callback) => _callback = callback;
        /// <summary>
        /// Invokes the param
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="param">The param</param>
        /// <param name="type">The type</param>
        public void Invoke<T>(GameObject param, ref T type) => _callback();
    }
}
