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
    public class ComponentStorageRemainingCoverageTests
    {
        [Fact]
        public void ComponentId_ForIntStorage_ReturnsComponentIntId()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            Assert.Equal(Component<int>.Id, storage.ComponentId);
        }

        [Fact]
        public void SetAtAndGetAt_WithIntValue_WorksCorrectly()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.SetAt(42, 0);
            Assert.Equal(42, storage.GetAt(0));
        }

        [Fact]
        public void SetAtAndGetAt_WithStringValue_WorksCorrectly()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("hello", 0);
            Assert.Equal("hello", storage.GetAt(0));
        }

        [Fact]
        public void AsSpan_ReturnsFullBuffer()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            Span<int> span = storage.AsSpan();
            Assert.Equal(8, span.Length);
        }

        [Fact]
        public void AsSpanLength_ReturnsLimitedSpan()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            Span<int> span = storage.AsSpanLength(5);
            Assert.Equal(5, span.Length);
        }

        [Fact]
        public void GetComponentStorageDataReference_ReturnsRefToFirstElement()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 99;
            ref int ref0 = ref storage.GetComponentStorageDataReference();
            Assert.Equal(99, ref0);
        }

        [Fact]
        public void Dispose_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Dispose();
        }

        [Fact]
        public void Dispose_WithReferenceType_DoesNotThrow()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.Dispose();
        }

        [Fact]
        public void Dispose_CalledMultipleTimes_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Dispose();
            storage.Dispose();
        }

        [Fact]
        public void DisposeBool_WithFalse_CoversDisposingBranch()
        {
            DisposeBoolTestWrapper storage = new DisposeBoolTestWrapper(4);
            storage.CallDispose(false);
            storage.CallDispose(true);
        }

        [Fact]
        public void ZeroCapacity_CreatesEmptyArray()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(0);
            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        [Fact]
        public void ZeroCapacity_WithString_CreatesEmptyArray()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(0);
            Assert.NotNull(storage.Buffer);
            Assert.Equal(0, storage.Buffer.Length);
        }

        [Fact]
        public void InvokeGenericActionWith_NullGenericEvent_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.InvokeGenericActionWith(null, default, 0);
        }

        [Fact]
        public void InvokeGenericActionWith_NullIGenericAction_DoesNotThrow()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.InvokeGenericActionWith(null, 0);
        }

        [Fact]
        public void InvokeGenericActionWith_NonGenericAction_InvokesCallback()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            bool invoked = false;
            storage.InvokeGenericActionWith(new TestGenericAction(() => invoked = true), 0);
            Assert.True(invoked);
        }

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

        [Fact]
        public void InvokeGenericActionWith_NullGenericEventWithString_DoesNotThrow()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.InvokeGenericActionWith(null, default, 0);
        }

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

        [Fact]
        public void PullComponentFrom_WithIntStorage_CopiesValues()
        {
            NoneUpdate<int> target = new NoneUpdate<int>(4);
            IdTable<int> source = new IdTable<int>();
            source.Create(out int idx0) = 10;
            source.Create(out int idx1) = 20;
            source.Create(out int idx2) = 30;

            target.PullComponentFrom(source, 1, idx2);

            Assert.Equal(30, target[1]);
        }

        [Fact]
        public void PullComponentFrom_WithStringStorage_CopiesAndClearsSource()
        {
            NoneUpdate<string> target = new NoneUpdate<string>(4);
            IdTable<string> source = new IdTable<string>();
            source.Create(out int idx0) = "a";
            source.Create(out int idx1) = "b";
            source.Create(out int idx2) = "c";

            target.PullComponentFrom(source, 0, idx2);

            Assert.Equal("c", target[0]);
        }

        [Fact]
        public void Trim_RoundsUpToPowerOfTwo()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(5);
            Assert.Equal(8, storage.Buffer.Length);
        }

        [Fact]
        public void Trim_WithPowerOfTwo_PreservesLength()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(4);
            Assert.Equal(4, storage.Buffer.Length);
        }

        [Fact]
        public void Trim_WithIndexOne_ResultsInLengthOne()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.Trim(1);
            Assert.Equal(1, storage.Buffer.Length);
        }

        [Fact]
        public void ResizeBuffer_GrowsToSpecifiedSize()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage.ResizeBuffer(8);
            Assert.Equal(8, storage.Buffer.Length);
        }

        [Fact]
        public void ResizeBuffer_ShrinksToSpecifiedSize()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(8);
            storage.ResizeBuffer(4);
            Assert.Equal(4, storage.Buffer.Length);
        }

        [Fact]
        public void Store_WithIntType_ReturnsComponentHandle()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 42;
            ComponentHandle handle = storage.Store(0);
            Assert.Equal(Component<int>.Id, handle.ComponentId);
        }

        [Fact]
        public void Store_WithStringType_ReturnsComponentHandle()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("test", 0);
            ComponentHandle handle = storage.Store(0);
            Assert.Equal(Component<string>.Id, handle.ComponentId);
        }

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

        [Fact]
        public void Indexer_OverwritesPreviousValue()
        {
            NoneUpdate<int> storage = new NoneUpdate<int>(4);
            storage[0] = 10;
            storage[0] = 20;
            Assert.Equal(20, storage[0]);
        }

        [Fact]
        public void AsSpan_WithString_ReturnsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            Span<string> span = storage.AsSpan();
            Assert.Equal(4, span.Length);
        }

        [Fact]
        public void AsSpanLength_WithString_ReturnsLimitedSpan()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            Span<string> span = storage.AsSpanLength(2);
            Assert.Equal(2, span.Length);
        }

        [Fact]
        public void GetComponentStorageDataReference_WithString_ReturnsRefToFirst()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.SetAt("hello", 0);
            ref string ref0 = ref storage.GetComponentStorageDataReference();
            Assert.Equal("hello", ref0);
        }

        [Fact]
        public void DisposeBool_WithFalseAndString_CoversDisposingBranch()
        {
            DisposeBoolTestWrapperString storage = new DisposeBoolTestWrapperString(4);
            storage.CallDispose(false);
            storage.CallDispose(true);
        }

        [Fact]
        public void Trim_WithStringType_RoundsUpToPowerOfTwo()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.Trim(5);
            Assert.Equal(8, storage.Buffer.Length);
        }

        [Fact]
        public void ResizeBuffer_WithStringType_GrowsBuffer()
        {
            NoneUpdate<string> storage = new NoneUpdate<string>(4);
            storage.ResizeBuffer(8);
            Assert.Equal(8, storage.Buffer.Length);
        }

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

        [Fact]
        public void Store_WithDestroyer_InvokesDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyableStruct>();

            NoneUpdate<DestroyableStruct> storage = new NoneUpdate<DestroyableStruct>(4);
            storage[0] = new DestroyableStruct { Value = 42 };

            ComponentHandle handle = storage.Store(0);

            Assert.Equal(Component<DestroyableStruct>.Id, handle.ComponentId);
        }

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

        [Fact]
        public void Store_WithDestroyerAndReferenceType_InvokesDestroyDelegate()
        {
            GenerationServices.RegisterDestroy<DestroyableRefStruct>();

            NoneUpdate<DestroyableRefStruct> storage = new NoneUpdate<DestroyableRefStruct>(4);
            storage.SetAt(new DestroyableRefStruct { Text = "test" }, 0);

            ComponentHandle handle = storage.Store(0);

            Assert.Equal(Component<DestroyableRefStruct>.Id, handle.ComponentId);
        }
    }

    internal struct DestroyableStruct : IOnDestroy
    {
        public int Value;
        public void OnDestroy() => Value = -1;
    }

    internal struct DestroyableRefStruct : IOnDestroy
    {
        public string Text;
        public void OnDestroy() => Text = null;
    }

    internal class DisposeBoolTestWrapper(int length) : ComponentStorage<int>(length)
    {
        public void CallDispose(bool disposing) => Dispose(disposing);
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b) { }
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b, int start, int length) { }
    }

    internal class DisposeBoolTestWrapperString(int length) : ComponentStorage<string>(length)
    {
        public void CallDispose(bool disposing) => Dispose(disposing);
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b) { }
        internal override void Run(Alis.Core.Ecs.Scene scene, Alis.Core.Ecs.Kernel.Archetypes.Archetype b, int start, int length) { }
    }

    internal sealed class TestGenericAction : IGenericAction
    {
        private readonly Action _callback;
        public TestGenericAction(Action callback) => _callback = callback;
        public void Invoke<T>(ref T type) => _callback();
    }

    internal sealed class TestGameObjectGenericAction : IGenericAction<GameObject>
    {
        private readonly Action _callback;
        public TestGameObjectGenericAction(Action callback) => _callback = callback;
        public void Invoke<T>(GameObject param, ref T type) => _callback();
    }
}
