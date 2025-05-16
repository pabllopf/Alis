﻿using System;
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    [DebuggerDisplay(AttributeHelpers.DebuggerDisplay)]
    internal partial class Archetype
    {
        internal ArchetypeID ID => _archetypeID;
        internal ImmutableArray<ComponentID> ArchetypeTypeArray => _archetypeID.Types;
        internal ImmutableArray<TagID> ArchetypeTagArray => _archetypeID.Tags;
        internal string DebuggerDisplayString => $"Archetype Count: {EntityCount} Types: {string.Join(", ", ArchetypeTypeArray.Select(t => t.Type.Name))} Tags: {string.Join(", ", ArchetypeTagArray.Select(t => t.Type.Name))}";
        internal int EntityCount => NextComponentIndex;
        internal Span<T> GetComponentSpan<T>()
        {
            var components = Components;
            int index = GetComponentIndex<T>();
            if (index == 0)
            {
                FrentExceptions.Throw_ComponentNotFoundException<T>();
            }
            return UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(index)).AsSpanLength(NextComponentIndex);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref T GetComponentDataReference<T>()
        {
            int index = GetComponentIndex<T>();
            return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index)).GetComponentStorageDataReference();
        }


        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref EntityIDOnly CreateEntityLocation(EntityFlags flags, out EntityLocation entityLocation)
        {
            if (_entities.Length == NextComponentIndex)
                Resize(_entities.Length * 2);

            entityLocation.Archetype = this;
            entityLocation.Index = NextComponentIndex;
            entityLocation.Flags = flags;
            Unsafe.SkipInit(out entityLocation.Version);
            //poison prolly isnt needed since archetype forces clear anyways
            MemoryHelpers.Poison(ref entityLocation.Version);

            return ref _entities.UnsafeArrayIndex(NextComponentIndex++);
        }

        /// <summary>
        /// Note! Entity location version is not set! 
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref EntityIDOnly CreateDeferredEntityLocation(World world, Archetype deferredCreationArchetype, scoped ref EntityLocation entityLocation, out ComponentStorageBase[] writeStorage)
        {
            if (deferredCreationArchetype.DeferredEntityCount == 0)
                world.DeferredCreationArchetypes.Push(new(this, deferredCreationArchetype, EntityCount));

            int futureSlot = NextComponentIndex + deferredCreationArchetype.DeferredEntityCount++;

            if (futureSlot < _entities.Length)
            {//hot path: we have space and can directly place into existing array
                writeStorage = Components;
                entityLocation.Index = futureSlot;
                entityLocation.Archetype = this;
                return ref _entities.UnsafeArrayIndex(futureSlot);
            }

            return ref CreateDeferredEntityLocationTempBuffers(deferredCreationArchetype, futureSlot, ref entityLocation, out writeStorage);
        }

        // Only to be called by CreateDeferredEntityLocation
        // Allow the jit to inline that method more easily
        private ref EntityIDOnly CreateDeferredEntityLocationTempBuffers(Archetype deferredCreationArchetype, int futureSlot, scoped ref EntityLocation entityLocation, out ComponentStorageBase[] writeStorage)
        {
            //we need to place into temp buffers
            entityLocation.Index = futureSlot - _entities.Length;
            entityLocation.Archetype = deferredCreationArchetype;

            Debug.Assert(entityLocation.Index >= 0);
            if (entityLocation.Index >= deferredCreationArchetype._entities.Length)
            {
                deferredCreationArchetype.ResizeCreateComponentBuffers();
            }

            writeStorage = deferredCreationArchetype.Components;

            return ref deferredCreationArchetype._entities.UnsafeArrayIndex(entityLocation.Index);
        }

        internal void ResolveDeferredEntityCreations(World world, Archetype deferredCreationArchetype)
        {
            Debug.Assert(deferredCreationArchetype._archetypeID == _archetypeID);
            Debug.Assert(deferredCreationArchetype.DeferredEntityCount != 0);
            int deltaFromMaxDeferredInPlace = -(_entities.Length - (NextComponentIndex + deferredCreationArchetype.DeferredEntityCount));
            int previousComponentCount = NextComponentIndex;

            if (!(deltaFromMaxDeferredInPlace <= 0))
            {//components overflowed into temp storage

                int oldEntitiesLen = _entities.Length;
                int totalCapacityRequired = previousComponentCount + deferredCreationArchetype.DeferredEntityCount;
                Debug.Assert(totalCapacityRequired >= oldEntitiesLen);

                //we should always have to resize here - after all, no space is left
                Resize((int)BitOperations.RoundUpToPowerOf2((uint)totalCapacityRequired));
                var destination = Components;
                var source = deferredCreationArchetype.Components;
                for (int i = 1; i < destination.Length; i++)
                    Array.Copy(source[i].Buffer, 0, destination[i].Buffer, oldEntitiesLen, deltaFromMaxDeferredInPlace);
                Array.Copy(deferredCreationArchetype._entities, 0, _entities, oldEntitiesLen, deltaFromMaxDeferredInPlace);
            }

            NextComponentIndex += deferredCreationArchetype.DeferredEntityCount;

            var entities = _entities;
            var table = world.EntityTable._buffer;
            for (int i = previousComponentCount; i < entities.Length && i < NextComponentIndex; i++)
            {
                ref var entityLocationToResolve = ref table.UnsafeArrayIndex(entities[i].ID);
                entityLocationToResolve.Archetype = this;
                entityLocationToResolve.Index = i;
            }

            deferredCreationArchetype.DeferredEntityCount = 0;
        }

        internal Span<EntityIDOnly> CreateEntityLocations(int count, World world)
        {
            int newLen = NextComponentIndex + count;
            EnsureCapacity(newLen);

            Span<EntityIDOnly> entitySpan = _entities.AsSpan(NextComponentIndex, count);

            int componentIndex = NextComponentIndex;
            ref var recycled = ref world.RecycledEntityIds;
            for (int i = 0; i < entitySpan.Length; i++)
            {
                ref EntityIDOnly archetypeEntity = ref entitySpan[i];

                archetypeEntity = recycled.CanPop() ? recycled.PopUnsafe() : new EntityIDOnly(world.NextEntityID++, 0);

                ref EntityLocation lookup = ref world.EntityTable.UnsafeIndexNoResize(archetypeEntity.ID);

                lookup.Version = archetypeEntity.Version;
                lookup.Archetype = this;
                lookup.Index = componentIndex++;
                lookup.Flags = EntityFlags.None;
            }

            NextComponentIndex = componentIndex;

            return entitySpan;
        }

        private void Resize(int newLen)
        {
            Array.Resize(ref _entities, newLen);
            var runners = Components;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        private void ResizeCreateComponentBuffers()
        {
#if DEBUG
        Debug.Assert(_isTempCreationArchetype);
#endif
            int newLen = checked(Math.Max(1, _entities.Length) * 2);
            //we only need to resize the EntityIDOnly array when future total entity count is greater than capacity
            Array.Resize(ref _entities, newLen);
            var runners = Components;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        public void EnsureCapacity(int count)
        {
            if (_entities.Length >= count)
            {
                return;
            }

            FastStackArrayPool<EntityIDOnly>.ResizeArrayFromPool(ref _entities, count);
            var runners = Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].ResizeBuffer(count);
            }
        }

        /// <summary>
        /// This method doesn't modify component storages
        /// </summary>
        internal EntityIDOnly DeleteEntityFromStorage(int index, out int deletedIndex)
        {
            Debug.Assert(NextComponentIndex > 0);
            deletedIndex = --NextComponentIndex;
            return _entities.UnsafeArrayIndex(index) = _entities.UnsafeArrayIndex(NextComponentIndex);
        }

        internal EntityIDOnly DeleteEntity(int index)
        {
            NextComponentIndex--;
            Debug.Assert(NextComponentIndex >= 0);
            //TODO: args
            #region Unroll
            DeleteComponentData args = new(index, NextComponentIndex);

            ref ComponentStorageBase first = ref MemoryMarshal.GetArrayDataReference(Components);

            switch (Components.Length)
            {
                case 1: goto end;
                case 2: goto len2;
                case 3: goto len3;
                case 4: goto len4;
                case 5: goto len5;
                case 6: goto len6;
                case 7: goto len7;
                case 8: goto len8;
                case 9: goto len9;
                default: goto @long;
            }

            @long:
            var comps = Components;
            for (int i = 9; i < comps.Length; i++)
            {
                comps[i].Delete(args);
            }

            //TODO: figure out the distribution of component counts
            len9:
            Unsafe.Add(ref first, 8).Delete(args);
            len8:
            Unsafe.Add(ref first, 7).Delete(args);
            len7:
            Unsafe.Add(ref first, 6).Delete(args);
            len6:
            Unsafe.Add(ref first, 5).Delete(args);
            len5:
            Unsafe.Add(ref first, 4).Delete(args);
            len4:
            Unsafe.Add(ref first, 3).Delete(args);
            len3:
            Unsafe.Add(ref first, 2).Delete(args);
            len2:
            Unsafe.Add(ref first, 1).Delete(args);
            #endregion

            end:

            return _entities.UnsafeArrayIndex(args.ToIndex) = _entities.UnsafeArrayIndex(args.FromIndex);
        }

        internal void Update(World world)
        {
            if (NextComponentIndex == 0)
                return;
            var comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Run(world, this);
        }

        internal void Update(World world, int start, int length)
        {
            if (NextComponentIndex == 0)
                return;
            var comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Run(world, this, start, length);
        }

        internal void MultiThreadedUpdate(CountdownEvent countdown, World world)
        {
            if (NextComponentIndex == 0)
                return;
            foreach (var comprunner in Components)
                comprunner.MultithreadedRun(countdown, world, this);
        }

        internal void ReleaseArrays()
        {
            _entities = [];
            var comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Trim(0);
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex<T>()
        {
            var index = Component<T>.ID.RawIndex;
            return ComponentTagTable.UnsafeArrayIndex(index) & GlobalWorldTables.IndexBits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex(ComponentID component)
        {
            return ComponentTagTable.UnsafeArrayIndex(component.RawIndex) & GlobalWorldTables.IndexBits;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag<T>()
        {
            var index = Tag<T>.ID.RawValue;
            return (ComponentTagTable.UnsafeArrayIndex(index) << 7) != 0;
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag(TagID tagID)
        {
            return (ComponentTagTable.UnsafeArrayIndex(tagID.RawValue) << 7) != 0;
        }

        internal Fields Data => new Fields()
        {
            Map = ComponentTagTable,
            Components = Components,
        };

        internal Span<EntityIDOnly> GetEntitySpan()
        {
            Debug.Assert(NextComponentIndex <= _entities.Length);
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
        return _entities.AsSpan(0, NextComponentIndex);
#else
            return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_entities), NextComponentIndex);
#endif
        }

        internal ref EntityIDOnly GetEntityDataReference() => ref MemoryMarshal.GetArrayDataReference(_entities);

        internal struct Fields
        {
            internal byte[] Map;
            internal ComponentStorageBase[] Components;

            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ref T GetComponentDataReference<T>()
            {
                int index = Map.UnsafeArrayIndex(Component<T>.ID.RawIndex);
                return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index)).GetComponentStorageDataReference();
            }
        }
    }
}