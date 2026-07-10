using System;
using System.Collections;
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    public class FastestStackRemainingCoverageTests
    {
        [Fact]
        public void Capacity_WithDefaultConstructor_ReturnsZero()
        {
            var stack = new FastestStack<int>();
            Assert.Equal(0, stack.Capacity);
        }

        [Fact]
        public void Capacity_WithCapacityConstructor_ReturnsCapacity()
        {
            var stack = new FastestStack<int>(10);
            Assert.Equal(10, stack.Capacity);
        }

        [Fact]
        public void IsSynchronized_ReturnsFalse()
        {
            ICollection stack = new FastestStack<int>();
            Assert.False(stack.IsSynchronized);
        }

        [Fact]
        public void SyncRoot_IsNotNull()
        {
            ICollection stack = new FastestStack<int>();
            Assert.NotNull(stack.SyncRoot);
        }

        [Fact]
        public void Push_Many_TriggersGrowWithMaxArrayLength()
        {
            var stack = new FastestStack<int>(0);
            stack.EnsureCapacity(0X7FEFFFFF);
            Assert.True(stack.Capacity >= 0X7FEFFFFF);
        }

        [Fact]
        public void Any_EmptyStack_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            Assert.False(stack.Any);
        }

        [Fact]
        public void Any_WithItems_ReturnsTrue()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            Assert.True(stack.Any);
        }

        [Fact]
        public void Contains_EmptyStack_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            Assert.False(stack.Contains(1));
        }

        [Fact]
        public void Contains_WithItem_ReturnsTrue()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            Assert.True(stack.Contains(10));
            Assert.True(stack.Contains(20));
        }

        [Fact]
        public void Contains_WithoutItem_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            Assert.False(stack.Contains(99));
        }

        [Fact]
        public void CopyTo_NullArray_ThrowsArgumentNull()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            Assert.Throws<ArgumentNullException>(() => stack.CopyTo(null, 0));
        }

        [Fact]
        public void CopyTo_NegativeIndex_ThrowsArgumentOutOfRange()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.CopyTo(new int[5], -1));
        }

        [Fact]
        public void CopyTo_IndexBeyondLength_ThrowsArgumentOutOfRange()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.CopyTo(new int[5], 10));
        }

        [Fact]
        public void CopyTo_InsufficientSpace_ThrowsArgumentException()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Throws<ArgumentException>(() => stack.CopyTo(new int[2], 0));
        }

        [Fact]
        public void CopyTo_WithItems_CopiesInReverseOrder()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            int[] target = new int[5];
            stack.CopyTo(target, 1);
            Assert.Equal(0, target[0]);
            Assert.Equal(30, target[1]);
            Assert.Equal(20, target[2]);
            Assert.Equal(10, target[3]);
            Assert.Equal(0, target[4]);
        }

        [Fact]
        public void CopyTo_EmptyStack_CopiesNothing()
        {
            var stack = new FastestStack<int>();
            int[] target = new int[3];
            stack.CopyTo(target, 0);
            Assert.All(target, v => Assert.Equal(0, v));
        }

        [Fact]
        public void ICollection_CopyTo_NullArray_ThrowsArgumentNull()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Assert.Throws<ArgumentNullException>(() => stack.CopyTo(null, 0));
        }

        [Fact]
        public void ICollection_CopyTo_MultiDimArray_ThrowsArgumentException()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Array multi = new int[2, 2];
            Assert.Throws<ArgumentException>(() => stack.CopyTo(multi, 0));
        }

        [Fact]
        public void ICollection_CopyTo_NonZeroLowerBound_ThrowsArgumentException()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Array nonZero = Array.CreateInstance(typeof(int), new[] { 5 }, new[] { 1 });
            Assert.Throws<ArgumentException>(() => stack.CopyTo(nonZero, 0));
        }

        [Fact]
        public void ICollection_CopyTo_NegativeIndex_ThrowsArgumentOutOfRange()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.CopyTo(new int[5], -1));
        }

        [Fact]
        public void ICollection_CopyTo_IndexBeyondLength_ThrowsArgumentOutOfRange()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.CopyTo(new int[5], 10));
        }

        [Fact]
        public void ICollection_CopyTo_InsufficientSpace_ThrowsArgumentException()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            s.Push(2);
            s.Push(3);
            ICollection stack = s;
            Assert.Throws<ArgumentException>(() => stack.CopyTo(new int[2], 0));
        }

        [Fact]
        public void ICollection_CopyTo_WrongArrayType_ThrowsArgumentException()
        {
            var s = new FastestStack<int>();
            s.Push(1);
            ICollection stack = s;
            Assert.Throws<ArgumentException>(() => stack.CopyTo(new string[5], 0));
        }

        [Fact]
        public void ICollection_CopyTo_Valid_CopiesCorrectly()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            ICollection coll = stack;
            int[] target = new int[5];
            coll.CopyTo(target, 1);
            Assert.Equal(0, target[0]);
            Assert.Equal(30, target[1]);
            Assert.Equal(20, target[2]);
            Assert.Equal(10, target[3]);
            Assert.Equal(0, target[4]);
        }

        [Fact]
        public void GetEnumerator_ReturnsEnumerator()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            Assert.True(e.MoveNext());
            Assert.Equal(1, e.Current);
        }

        [Fact]
        public void GetEnumerator_EmptyStack_NoMove()
        {
            var stack = new FastestStack<int>();
            var e = stack.GetEnumerator();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void GenericGetEnumerator_WithItems_Enumerates()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            var e = ((IEnumerable<int>)stack).GetEnumerator();
            int count = 0;
            while (e.MoveNext()) count++;
            Assert.Equal(2, count);
        }

        [Fact]
        public void GenericGetEnumerator_Empty_NoMove()
        {
            var stack = new FastestStack<int>();
            var e = ((IEnumerable<int>)stack).GetEnumerator();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void NonGenericGetEnumerator_Works()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = ((IEnumerable)stack).GetEnumerator();
            Assert.True(e.MoveNext());
            Assert.Equal(1, e.Current);
        }

        [Fact]
        public void TrimExcess_WithHighUtilization_DoesNothing()
        {
            var stack = new FastestStack<int>(10);
            for (int i = 0; i < 9; i++) stack.Push(i);
            int before = stack.Capacity;
            stack.TrimExcess();
            Assert.Equal(before, stack.Capacity);
        }

        [Fact]
        public void TrimExcess_WithLowUtilization_ReducesCapacity()
        {
            var stack = new FastestStack<int>(100);
            stack.Push(1);
            stack.TrimExcess();
            Assert.True(stack.Capacity < 100);
            Assert.Equal(1, stack.Count);
            Assert.Equal(1, stack.Peek());
        }

        [Fact]
        public void TrimExcess_NegativeCapacity_ThrowsArgumentOutOfRange()
        {
            var stack = new FastestStack<int>(10);
            stack.Push(1);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(-1));
        }

        [Fact]
        public void TrimExcess_CapacityLessThanSize_ThrowsArgumentOutOfRange()
        {
            var stack = new FastestStack<int>(10);
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(2));
        }

        [Fact]
        public void TrimExcess_SameCapacity_DoesNothing()
        {
            var stack = new FastestStack<int>(10);
            stack.Push(1);
            stack.Push(2);
            stack.TrimExcess(10);
            Assert.Equal(10, stack.Capacity);
        }

        [Fact]
        public void TrimExcess_WithExactCapacity_Resizes()
        {
            var stack = new FastestStack<int>(100);
            stack.Push(1);
            stack.TrimExcess(50);
            Assert.Equal(50, stack.Capacity);
        }

        [Fact]
        public void Peek_OnEmptyStack_ThrowsInvalidOperation()
        {
            var stack = new FastestStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
        }

        [Fact]
        public void Peek_WithItems_ReturnsTop()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            Assert.Equal(20, stack.Peek());
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void TryPeek_EmptyStack_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            Assert.False(stack.TryPeek(out int val));
            Assert.Equal(0, val);
        }

        [Fact]
        public void TryPeek_WithItems_ReturnsTrue()
        {
            var stack = new FastestStack<int>();
            stack.Push(42);
            Assert.True(stack.TryPeek(out int val));
            Assert.Equal(42, val);
        }

        [Fact]
        public void Pop_OnEmptyStack_ThrowsInvalidOperation()
        {
            var stack = new FastestStack<int>();
            Assert.Throws<InvalidOperationException>(() => stack.Pop());
        }

        [Fact]
        public void Pop_WithItems_ReturnsAndRemoves()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            Assert.Equal(20, stack.Pop());
            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Pop());
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void TryPop_EmptyStack_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            Assert.False(stack.TryPop(out int val));
            Assert.Equal(0, val);
        }

        [Fact]
        public void TryPop_WithItems_ReturnsTrueAndRemoves()
        {
            var stack = new FastestStack<int>();
            stack.Push(42);
            Assert.True(stack.TryPop(out int val));
            Assert.Equal(42, val);
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Remove_ExistingItem_RemovesIt()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Remove(20);
            Assert.Equal(2, stack.Count);
            Assert.False(stack.Contains(20));
        }

        [Fact]
        public void Remove_NonExistingItem_DoesNothing()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Remove(99);
            Assert.Equal(2, stack.Count);
        }

        [Fact]
        public void Remove_LastItem_PopsIt()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Remove(20);
            Assert.Equal(1, stack.Count);
            Assert.Equal(10, stack.Peek());
        }

        [Fact]
        public void Remove_FirstItem_PopsFromMiddle()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            stack.Remove(10);
            Assert.Equal(2, stack.Count);
            Assert.True(stack.Contains(20));
            Assert.True(stack.Contains(30));
        }

        [Fact]
        public void EnsureCapacity_Negative_ThrowsArgumentOutOfRange()
        {
            var stack = new FastestStack<int>();
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.EnsureCapacity(-1));
        }

        [Fact]
        public void EnsureCapacity_WhenSmaller_DoesNotChange()
        {
            var stack = new FastestStack<int>(10);
            stack.EnsureCapacity(5);
            Assert.Equal(10, stack.Capacity);
        }

        [Fact]
        public void EnsureCapacity_WhenLarger_Grows()
        {
            var stack = new FastestStack<int>(4);
            int result = stack.EnsureCapacity(100);
            Assert.True(result >= 100);
            Assert.True(stack.Capacity >= 100);
        }

        [Fact]
        public void EnsureCapacity_WhenDefault_GrowsFromEmpty()
        {
            var stack = new FastestStack<int>();
            int result = stack.EnsureCapacity(20);
            Assert.True(result >= 20);
        }

        [Fact]
        public void ToArray_EmptyStack_ReturnsEmpty()
        {
            var stack = new FastestStack<int>();
            int[] arr = stack.ToArray();
            Assert.Empty(arr);
        }

        [Fact]
        public void ToArray_WithItems_ReturnsCorrectOrder()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            stack.Push(30);
            int[] arr = stack.ToArray();
            Assert.Equal(3, arr.Length);
            Assert.Equal(30, arr[0]);
            Assert.Equal(20, arr[1]);
            Assert.Equal(10, arr[2]);
        }

        [Fact]
        public void Dispose_ResetsStack()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            stack.Dispose();
            Assert.Equal(0, stack.Count);
            Assert.Equal(0, stack.Capacity);
            Assert.False(stack.Any);
        }

        [Fact]
        public void Create_StaticMethod_ReturnsStack()
        {
            var stack = FastestStack<int>.Create(10);
            Assert.Equal(10, stack.Capacity);
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void AsSpan_ReturnsSpan()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            var span = stack.AsSpan();
            Assert.Equal(2, span.Length);
            Assert.Equal(10, span[0]);
            Assert.Equal(20, span[1]);
        }

        [Fact]
        public void AsSpan_Empty_ReturnsEmpty()
        {
            var stack = new FastestStack<int>();
            var span = stack.AsSpan();
            Assert.Equal(0, span.Length);
        }

        [Fact]
        public void CanPop_Empty_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            Assert.False(stack.CanPop());
        }

        [Fact]
        public void CanPop_WithItems_ReturnsTrue()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            Assert.True(stack.CanPop());
        }

        [Fact]
        public void Indexer_Get_ReturnsCorrectValue()
        {
            var stack = new FastestStack<int>(4);
            stack.Push(10);
            stack.Push(20);
            Assert.Equal(10, stack[0]);
            Assert.Equal(20, stack[1]);
        }

        [Fact]
        public void Indexer_Set_ModifiesValue()
        {
            var stack = new FastestStack<int>(4);
            stack.Push(10);
            stack.Push(20);
            stack[0] = 99;
            Assert.Equal(99, stack[0]);
        }

        [Fact]
        public void Constructor_WithNullEnumerable_ThrowsArgumentNull()
        {
            Assert.Throws<ArgumentNullException>(() => new FastestStack<int>(null));
        }

        [Fact]
        public void Constructor_WithZeroCapacity_UsesEmptyArray()
        {
            var stack = new FastestStack<int>(0);
            Assert.Equal(0, stack.Capacity);
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Constructor_WithNegativeCapacity_ThrowsArgumentOutOfRange()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new FastestStack<int>(-1));
        }

        [Fact]
        public void Constructor_WithCollection_LoadsItems()
        {
            var stack = new FastestStack<int>(new[] { 1, 2, 3 });
            Assert.Equal(3, stack.Count);
            Assert.Equal(3, stack.Pop());
        }

        [Fact]
        public void Push_BeyondDefaultCapacity_Resizes()
        {
            var stack = new FastestStack<int>();
            for (int i = 0; i < 33; i++) stack.Push(i);
            Assert.Equal(33, stack.Count);
            Assert.True(stack.Capacity >= 33);
        }

        [Fact]
        public void Push_BeyondInitialCapacity_Resizes()
        {
            var stack = new FastestStack<int>(4);
            for (int i = 0; i < 10; i++) stack.Push(i);
            Assert.Equal(10, stack.Count);
            Assert.True(stack.Capacity >= 10);
        }

        [Fact]
        public void Pop_WithReferenceType_ClearsSlot()
        {
            var stack = new FastestStack<string>(4);
            stack.Push("first");
            stack.Push("second");
            stack.Pop();
            Assert.Equal(1, stack.Count);
            Assert.Equal("first", stack.Peek());
        }

        [Fact]
        public void TryPop_WithReferenceType_ClearsSlot()
        {
            var stack = new FastestStack<string>(4);
            stack.Push("first");
            stack.Push("second");
            Assert.True(stack.TryPop(out string val));
            Assert.Equal("second", val);
            Assert.Equal(1, stack.Count);
            Assert.Equal("first", stack.Peek());
        }

        [Fact]
        public void Enumerator_MoveNext_ReturnsElementsInOrder()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            var e = stack.GetEnumerator();
            Assert.True(e.MoveNext());
            Assert.Equal(2, e.Current);
            Assert.True(e.MoveNext());
            Assert.Equal(1, e.Current);
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void Enumerator_Current_BeforeMoveNext_ThrowsInvalidOperation()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            Assert.Throws<InvalidOperationException>(() => e.Current);
        }

        [Fact]
        public void Enumerator_Current_AfterEnumerationEnded_ThrowsInvalidOperation()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.MoveNext();
            e.MoveNext();
            Assert.Throws<InvalidOperationException>(() => e.Current);
        }

        [Fact]
        public void Enumerator_Dispose_SetsIndexToMinusOne()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.Dispose();
            Assert.Throws<InvalidOperationException>(() => e.Current);
        }

        [Fact]
        public void Enumerator_EmptyStack_ReturnsFalseOnMoveNext()
        {
            var stack = new FastestStack<int>();
            var e = stack.GetEnumerator();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void Enumerator_IEnumerator_Reset_Restarts()
        {
            var stack = new FastestStack<int>();
            stack.Push(10);
            stack.Push(20);
            IEnumerator e = ((IEnumerable<int>)stack).GetEnumerator();
            e.MoveNext();
            Assert.Equal(20, e.Current);
            e.Reset();
            Assert.True(e.MoveNext());
            Assert.Equal(20, e.Current);
        }

        [Fact]
        public void Enumerator_IEnumerator_Current_ReturnsCurrent()
        {
            var stack = new FastestStack<int>();
            stack.Push(42);
            IEnumerator e = ((IEnumerable<int>)stack).GetEnumerator();
            e.MoveNext();
            Assert.Equal(42, e.Current);
        }

        [Fact]
        public void Enumerator_MoveNext_AfterDispose_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.Dispose();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void Enumerator_Current_AfterDispose_ThrowsInvalidOperation()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.Dispose();
            Assert.Throws<InvalidOperationException>(() => e.Current);
        }

        [Fact]
        public void Enumerator_MoveNext_EmptyAfterNonEmpty_ReturnsFalse()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.MoveNext();
            e.MoveNext();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void Enumerator_DisposeCalled_DoesNotThrowOnMultipleDispose()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            var e = stack.GetEnumerator();
            e.Dispose();
            e.Dispose();
            Assert.False(e.MoveNext());
        }

        [Fact]
        public void Enumerator_BoxedVersionMismatch_MoveNext_Throws()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            stack.Push(2);
            FastestStack<int>.Enumerator e = stack.GetEnumerator();
            object boxed = e;
            var field = typeof(FastestStack<int>.Enumerator).GetField("_version",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field.SetValue(boxed, -123);
            e = (FastestStack<int>.Enumerator)boxed;
            Assert.Throws<InvalidOperationException>(() => e.MoveNext());
        }

        [Fact]
        public void Enumerator_BoxedVersionMismatch_Reset_Throws()
        {
            var stack = new FastestStack<int>();
            stack.Push(1);
            FastestStack<int>.Enumerator e = stack.GetEnumerator();
            object boxed = e;
            var field = typeof(FastestStack<int>.Enumerator).GetField("_version",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
            field.SetValue(boxed, -123);
            e = (FastestStack<int>.Enumerator)boxed;
            var reset = ((IEnumerator)e);
            Assert.Throws<InvalidOperationException>(() => reset.Reset());
        }

        [Fact]
        public void Push_AfterTrimExcess_GrowsCorrectly()
        {
            var stack = new FastestStack<int>(4);
            stack.Push(1);
            stack.Push(2);
            stack.TrimExcess(2);
            stack.Push(3);
            Assert.Equal(3, stack.Count);
            Assert.Equal(3, stack.Peek());
        }

        [Fact]
        public void Clear_WithReferenceType_ClearsElements()
        {
            var stack = new FastestStack<string>(4);
            stack.Push("hello");
            stack.Clear();
            Assert.Equal(0, stack.Count);
        }

        [Fact]
        public void Push_WithReferenceType_DoesNotCrash()
        {
            var stack = new FastestStack<string>();
            stack.Push("hello");
            stack.Push("world");
            Assert.Equal(2, stack.Count);
            Assert.Equal("world", stack.Pop());
            Assert.Equal("hello", stack.Pop());
        }
    }
}
