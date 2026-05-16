// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollectionsExhaustiveCoverageTest.cs
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
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Kernel.Events;
using Alis.Core.Ecs.Test.Models;
using Xunit;

namespace Alis.Core.Ecs.Test.Collections
{
    /// <summary>
    ///     The collections exhaustive coverage test class
    /// </summary>
    public class CollectionsExhaustiveCoverageTest
    {
        /// <summary>
        ///     Tests that fastest array pool rent return resize and private paths work
        /// </summary>
        [Fact]
        public void FastestArrayPool_RentReturnResizeAndPrivatePaths_Work()
        {
            FastestArrayPool<string> pool = new FastestArrayPool<string>();

            string[] tiny = pool.Rent(3);
            Assert.Equal(3, tiny.Length);

            string[] sixteen = pool.Rent(16);
            Assert.True(sixteen.Length >= 16);
            sixteen[0] = "keep";
            pool.Return(sixteen, true);

            string[] reused = pool.Rent(16);
            Assert.Same(sixteen, reused);
            Assert.Null(reused[0]);

            string[] oversized = pool.Rent(1 << 30);
            Assert.Equal(1 << 30, oversized.Length);

            int[] from = [1, 2, 3, 4, 5];
            FastestArrayPool<int>.ResizeArrayFromPool(ref from, 32);
            Assert.True(from.Length >= 32);
            Assert.Equal(1, from[0]);
            Assert.Equal(5, from[4]);

            MethodInfo getBucketIndex = typeof(FastestArrayPool<int>)
                .GetMethod("GetBucketIndex", BindingFlags.Static | BindingFlags.NonPublic);
            Assert.NotNull(getBucketIndex);
            Assert.Equal(-1, (int) getBucketIndex.Invoke(null, [15])!);
            Assert.Equal(0, (int) getBucketIndex.Invoke(null, [16])!);

            FastestArrayPool<int> intPool = new FastestArrayPool<int>();
            int[] candidate = intPool.Rent(32);
            intPool.Return(candidate);
            int[] beforeClear = intPool.Rent(32);
            Assert.Same(candidate, beforeClear);
            intPool.Return(beforeClear);

            MethodInfo clearBuckets = typeof(FastestArrayPool<int>)
                .GetMethod("ClearBuckets", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(clearBuckets);
            clearBuckets.Invoke(intPool, null);

            int[] afterClear = intPool.Rent(32);
            Assert.NotSame(candidate, afterClear);
        }

        /// <summary>
        ///     Tests that fastest stack all public members and enumerator branches work
        /// </summary>
        [Fact]
        public void FastestStack_AllPublicMembersAndEnumeratorBranches_Work()
        {
            FastestStack<int> stack = new FastestStack<int>(0);
            Assert.Equal(0, stack.Count);
            Assert.Equal(0, stack.Capacity);
            Assert.False(stack.Any);
            Assert.False(((ICollection) stack).IsSynchronized);
            Assert.NotNull(((ICollection) stack).SyncRoot);

            Assert.Throws<ArgumentOutOfRangeException>(() => new FastestStack<int>(-1));
            Assert.Throws<ArgumentNullException>(() => new FastestStack<int>(null));

            FastestStack<int> fromEnumerable = new FastestStack<int>(new[] {1, 2, 3});
            Assert.Equal(3, fromEnumerable.Count);

            stack.Push(1);
            stack.Push(2);
            stack.Push(3);
            Assert.True(stack.Any);
            Assert.True(stack.Contains(2));
            Assert.False(stack.Contains(999));
            Assert.Equal(3, stack.Peek());
            Assert.True(stack.TryPeek(out int peeked));
            Assert.Equal(3, peeked);

            int[] copy = new int[5];
            stack.CopyTo(copy, 1);
            Assert.Equal(3, copy[1]);
            Assert.Equal(2, copy[2]);
            Assert.Equal(1, copy[3]);

            Assert.Throws<ArgumentNullException>(() => stack.CopyTo(null, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.CopyTo(new int[4], -1));
            Assert.Throws<ArgumentException>(() => stack.CopyTo(new int[2], 0));

            ICollection coll = stack;
            Assert.Throws<ArgumentNullException>(() => coll.CopyTo(null, 0));
            Assert.Throws<ArgumentException>(() => coll.CopyTo(new int[1, 1], 0));

            Array nonZeroLowerBound = Array.CreateInstance(typeof(int), [3], [1]);
            Assert.Throws<ArgumentException>(() => coll.CopyTo(nonZeroLowerBound, 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => coll.CopyTo(new int[4], -1));
            Assert.Throws<ArgumentException>(() => coll.CopyTo(new int[2], 0));
            Assert.Throws<ArgumentException>(() => coll.CopyTo(new string[5], 0));

            stack.Remove(2);
            Assert.False(stack.Contains(2));
            stack.Remove(555);

            Assert.Equal(3, stack.Pop());
            Assert.True(stack.TryPop(out int popped));
            Assert.Equal(1, popped);
            Assert.False(stack.TryPop(out _));
            Assert.False(stack.TryPeek(out _));
            Assert.Throws<InvalidOperationException>(() => stack.Peek());
            Assert.Throws<InvalidOperationException>(() => stack.Pop());

            stack.Push(10);
            stack.Push(11);
            stack.Push(12);
            stack[1] = 21;
            Assert.Equal(21, stack[1]);

            int ensured = stack.EnsureCapacity(100);
            Assert.True(ensured >= 100);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.EnsureCapacity(-1));

            stack.TrimExcess();
            Assert.True(stack.Capacity >= stack.Count);
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(-1));
            Assert.Throws<ArgumentOutOfRangeException>(() => stack.TrimExcess(1));
            stack.TrimExcess(stack.Capacity);
            stack.TrimExcess(stack.Count + 10);

            int[] asArray = stack.ToArray();
            Assert.Equal(stack.Count, asArray.Length);
            Assert.Equal(stack.Peek(), asArray[0]);

            Span<int> span = stack.AsSpan();
            Assert.Equal(stack.Count, span.Length);

            FastestStack<int>.Enumerator enumerator = stack.GetEnumerator();
            Assert.Throws<InvalidOperationException>(() => { _ = enumerator.Current; });
            Assert.True(enumerator.MoveNext());
            Assert.Equal(stack.Peek(), enumerator.Current);
            while (enumerator.MoveNext())
            {
            }

            Assert.Throws<InvalidOperationException>(() => { _ = enumerator.Current; });

            IEnumerator boxedEnumerator = ((IEnumerable<int>) stack).GetEnumerator();
            Assert.NotNull(boxedEnumerator);
            while (boxedEnumerator.MoveNext())
            {
            }

            Assert.False(boxedEnumerator.MoveNext());

            IEnumerator<int> emptyEnum = ((IEnumerable<int>) new FastestStack<int>()).GetEnumerator();
            Assert.False(emptyEnum.MoveNext());

            var mismatch = stack.GetEnumerator();
            FieldInfo versionField = typeof(FastestStack<int>.Enumerator)
                .GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(versionField);
            object boxedMismatch = mismatch;
            versionField.SetValue(boxedMismatch, -123);
            mismatch = (FastestStack<int>.Enumerator) boxedMismatch;
            Assert.Throws<InvalidOperationException>(() => mismatch.MoveNext());

            IEnumerator resetMismatch = ((IEnumerable<int>) stack).GetEnumerator();
            object boxedReset = resetMismatch;
            FieldInfo resetVersionField = boxedReset.GetType().GetField("_version", BindingFlags.Instance | BindingFlags.NonPublic);
            Assert.NotNull(resetVersionField);
            resetVersionField.SetValue(boxedReset, -777);
            resetMismatch = (IEnumerator) boxedReset;
            Assert.Throws<InvalidOperationException>(() => resetMismatch.Reset());

            FastestStack<string> refStack = new FastestStack<string>(4);
            refStack.Push("a");
            refStack.Push("b");
            refStack.Clear();
            Assert.Equal(0, refStack.Count);

            FastestStack<int> created = FastestStack<int>.Create(3);
            Assert.True(created.Capacity >= 3);
            Assert.False(created.CanPop());

            stack.Dispose();
            Assert.Equal(0, stack.Count);
            Assert.Equal(0, stack.Capacity);
        }

        /// <summary>
        ///     Tests that archetype neighbor cache all slots and overloads work
        /// </summary>
        [Fact]
        public void ArchetypeNeighborCache_AllSlotsAndOverloads_Work()
        {
            ArchetypeNeighborCache cache = new ArchetypeNeighborCache();

            Assert.Equal(32, cache.Traverse(99));
            Assert.Null(cache.TraverseArchetype(99));

            cache.Set(1, 11);
            cache.Set(2, 22);
            cache.Set(3, 33);
            cache.Set(4, 44);

            Assert.Equal(0, cache.Traverse(1));
            Assert.Equal(1, cache.Traverse(2));
            Assert.Equal(2, cache.Traverse(3));
            Assert.Equal(3, cache.Traverse(4));
            Assert.Equal((ushort) 11, cache.Lookup(0));
            Assert.Equal((ushort) 22, cache.Lookup(1));
            Assert.Equal((ushort) 33, cache.Lookup(2));
            Assert.Equal((ushort) 44, cache.Lookup(3));

            using Scene scene = new Scene();
            Archetype arch = scene.DefaultArchetype;
            cache.Set(9, arch);
            Assert.Same(arch, cache.TraverseArchetype(9));
            int slot = cache.Traverse(9);
            Assert.True(slot is >= 0 and <= 3);
            Assert.Equal(arch.Id.RawIndex, cache.Lookup(slot));
        }

        /// <summary>
        ///     Tests that fast lookup set lookup and find adjacent archetype all paths work
        /// </summary>
        [Fact]
        public void FastLookup_SetLookupAndFindAdjacentArchetype_AllPaths_Work()
        {
            FastLookup lookup = new FastLookup();
            using Scene scene = new Scene();

            Archetype destination = scene.DefaultArchetype;
            GameObjectType from = destination.Id;
            ComponentId componentId = Component<Position>.Id;

            lookup.SetArchetype(componentId.RawIndex, from, destination);
            uint storedKey = FastLookup.GetKey(componentId.RawIndex, from);
            int storedIndex = lookup.LookupIndex(storedKey);
            Assert.True(storedIndex is >= 0 and < 8);
            Assert.Same(destination, lookup.Archetypes[storedIndex]);

            for (int i = 0; i < 8; i++)
            {
                ushort id = (ushort) (100 + i);
                lookup.SetArchetype(id, from, destination);
                uint key = FastLookup.GetKey(id, from);
                lookup.LookupIndex(key);
            }

            lookup.SetArchetype(200, from, destination);
            Assert.Equal(1, lookup.LookupIndex(FastLookup.GetKey(200, from)));
            Assert.Equal(32, lookup.LookupIndex(123456789u));

            ArchetypeEdgeType edgeType = ArchetypeEdgeType.AddComponent;
            ArchetypeEdgeKey keyForDict = ArchetypeEdgeKey.Component(componentId, from, edgeType);
            scene.ArchetypeGraphEdges[keyForDict] = destination;

            GameObjectType idFromDictionary = lookup.FindAdjacentArchetypeId(componentId, from, scene, edgeType);
            Assert.Equal(destination.Id, idFromDictionary);

            scene.ArchetypeGraphEdges.Clear();
            FastLookup coldLookup = new FastLookup();
            GameObjectType coldId = coldLookup.FindAdjacentArchetypeId(componentId, from, scene, edgeType);
            Assert.True(scene.ArchetypeGraphEdges.Count >= 1);
            Assert.NotEqual(default(GameObjectType), coldId);
        }

        /// <summary>
        ///     Tests that short sparse set all members and branches work
        /// </summary>
        [Fact]
        public void ShortSparseSet_AllMembersAndBranches_Work()
        {
            ShortSparseSet<string> set = new ShortSparseSet<string>();
            Assert.Equal(4, set.Capacity);
            Assert.Equal(0, set.Count);

            set[1] = "one";
            set[2] = "two";
            set[10] = "ten";
            Assert.Equal(3, set.Count);
            Assert.True(set.Capacity >= 3);

            ref string viaGet = ref set.Get(1);
            Assert.Equal("one", viaGet);

            bool found = set.TryGet(2, out string foundValue);
            Assert.False(found);
            Assert.Equal("two", foundValue);

            bool notFound = set.TryGet(999, out string missingValue);
            Assert.False(notFound);
            Assert.Null(missingValue);

            Assert.True(set.Has(10));
            Assert.False(set.Has(-1));
            Assert.False(set.Has(9999));

            set.EnsureCapacity(50);
            Assert.True(set.Capacity >= 50);

            Span<string> span = set.AsSpan();
            Assert.Equal(set.Count, span.Length);

            bool removed = set.Remove(1);
            Assert.True(removed);

            ShortSparseSet<int> emptySet = new ShortSparseSet<int>();
            bool removeMissing = emptySet.Remove(22);
            Assert.False(removeMissing);

            Assert.Throws<ArgumentOutOfRangeException>(() => emptySet.Get(99));

            set.Clear();
            Assert.Equal(0, set.Count);
            Assert.False(set.Has(10));
        }

        /// <summary>
        ///     Tests that enumerable helpers reset and to array all code paths work
        /// </summary>
        [Fact]
        public void EnumerableHelpers_ResetAndToArray_AllCodePaths_Work()
        {
            ResettableEnumerator resettable = new ResettableEnumerator();
            EnumerableHelpers.Reset(ref resettable);
            Assert.True(resettable.ResetCalled);

            IEnumerator<int> empty = EnumerableHelpers.GetEmptyEnumerator<int>();
            Assert.False(empty.MoveNext());

            List<int> nonEmptyList = new List<int> {1, 2, 3};
            int[] listArr = EnumerableHelpers.ToArray(nonEmptyList, out int listLength);
            Assert.Equal(3, listLength);
            Assert.Equal(new[] {1, 2, 3}, listArr);

            List<int> emptyList = new List<int>();
            int[] emptyArr = EnumerableHelpers.ToArray(emptyList, out int emptyLen);
            Assert.Equal(0, emptyLen);
            Assert.Empty(emptyArr);

            IEnumerable<int> generated = YieldSequence(9);
            int[] generatedArr = EnumerableHelpers.ToArray(generated, out int generatedLen);
            Assert.Equal(9, generatedLen);
            Assert.Equal(0, generatedArr[0]);
            Assert.Equal(8, generatedArr[8]);

            IEnumerable<int> generatedEmpty = YieldSequence(0);
            int[] generatedEmptyArr = EnumerableHelpers.ToArray(generatedEmpty, out int generatedEmptyLen);
            Assert.Equal(0, generatedEmptyLen);
            Assert.Empty(generatedEmptyArr);
        }

        /// <summary>
        ///     Tests that chunk index span resize and return work
        /// </summary>
        [Fact]
        public void Chunk_IndexSpanResizeAndReturn_Work()
        {
            Chunk<int> chunk = new Chunk<int>(4);
            Assert.True(chunk.Length >= 4);

            chunk[0] = 10;
            chunk[1] = 20;
            Assert.Equal(10, chunk[0]);

            Span<int> full = chunk.AsSpan();
            Assert.True(full.Length >= 4);
            Span<int> slice = chunk.AsSpan(0, 2);
            Assert.Equal(2, slice.Length);
            Assert.Equal(20, slice[1]);

            Chunk<int>[] chunks = new Chunk<int>[1];
            Chunk<int>.NextChunk(ref chunks, 8, 0);
            Assert.NotNull(chunks[0].Buffer);
            Chunk<int>.NextChunk(ref chunks, 8, 1);
            Assert.True(chunks.Length >= 2);
            Assert.NotNull(chunks[1].Buffer);

            chunks[0].Return();
            chunks[1].Return();
            chunk.Return();
            Assert.Null(chunk.Buffer);
        }

        /// <summary>
        ///     Tests that id table generic and boxed paths work
        /// </summary>
        [Fact]
        public void IdTable_GenericAndBoxedPaths_Work()
        {
            IdTable<string> table = new IdTable<string>();

            ref string created = ref table.Create(out int index0);
            created = "alpha";
            Assert.Equal("alpha", table.Take(index0));

            int boxedIndex = table.CreateBoxed("beta");
            Assert.Equal("beta", table.GetValueBoxed(boxedIndex));
            Assert.Equal("beta", table.TakeBoxed(boxedIndex));

            table.Consume(boxedIndex);
            ref string recycled = ref table.Create(out int recycledIndex);
            Assert.Equal(boxedIndex, recycledIndex);
            Assert.Null(recycled);

            using Scene scene = new Scene();
            GameObject gameObject = scene.Create();
            TrackingAction tracker = new TrackingAction();
            GenericEvent genericEvent = new GenericEvent();
            genericEvent += tracker;

            ref string atIndex0 = ref table.Take(index0);
            atIndex0 = "gamma";
            table.InvokeEventWithAndConsume(genericEvent, gameObject, index0);
            Assert.Equal(1, tracker.CallCount);

            ref string afterConsume = ref table.Create(out int reusedIndex0);
            Assert.Equal(index0, reusedIndex0);

            table.Dispose();
        }

        /// <summary>
        ///     Tests that fastest table indexer unsafe and capacity work
        /// </summary>
        [Fact]
        public void FastestTable_IndexerUnsafeAndCapacity_Work()
        {
            FastestTable<int> empty = FastestTable<int>.Empty;
            Assert.Equal(0, empty.Length);

            FastestTable<int> table = new FastestTable<int>(2);
            Assert.True(table.Length >= 2);

            table[0] = 11;
            table[1] = 22;
            table[8] = 88;
            Assert.Equal(11, table[0]);
            Assert.Equal(88, table[8]);

            ref int unsafeRef = ref table.UnsafeIndexNoResize(1);
            unsafeRef = 222;
            Assert.Equal(222, table[1]);

            table.EnsureCapacity(100);
            Assert.True(table.Length >= 100);

            Span<int> span = table.AsSpan();
            Assert.Equal(table.Length, span.Length);
        }

        /// <summary>
        ///     Yields the sequence using the specified length
        /// </summary>
        /// <param name="length">The length</param>
        /// <returns>An enumerable of int</returns>
        private static IEnumerable<int> YieldSequence(int length)
        {
            for (int i = 0; i < length; i++)
            {
                yield return i;
            }
        }

        /// <summary>
        ///     The resettable enumerator
        /// </summary>
        private struct ResettableEnumerator : IEnumerator
        {
            /// <summary>
            ///     Gets or sets the value of the reset called
            /// </summary>
            public bool ResetCalled { get; private set; }

            /// <summary>
            ///     Gets the value of the current
            /// </summary>
            public object Current => null;

            /// <summary>
            ///     Moves the next
            /// </summary>
            /// <returns>The bool</returns>
            public bool MoveNext() => false;

            /// <summary>
            ///     Resets this instance
            /// </summary>
            public void Reset() => ResetCalled = true;
        }

        /// <summary>
        ///     The tracking action class
        /// </summary>
        /// <seealso cref="IGenericAction{GameObject}" />
        private sealed class TrackingAction : IGenericAction<GameObject>
        {
            /// <summary>
            ///     Gets or sets the value of the call count
            /// </summary>
            public int CallCount { get; private set; }

            /// <summary>
            ///     Invokes the param
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <param name="param">The param</param>
            /// <param name="type">The type</param>
            public void Invoke<T>(GameObject param, ref T type)
            {
                CallCount++;
            }
        }
    }
}