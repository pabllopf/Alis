// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Archetype.cs
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
using System.Collections.Immutable;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using Alis.Core.Ecs.Buffers;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    internal partial class Archetype
    {
        /// <summary>
        ///     Gets the value of the id
        /// </summary>
        internal EntityType ID => _archetypeID;

        /// <summary>
        ///     Gets the value of the archetype type array
        /// </summary>
        internal ImmutableArray<ComponentID> ArchetypeTypeArray => _archetypeID.Types;

        /// <summary>
        ///     Gets the value of the archetype tag array
        /// </summary>
        internal ImmutableArray<TagID> ArchetypeTagArray => _archetypeID.Tags;

        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => $"Archetype Count: {EntityCount} Types: {string.Join(", ", ArchetypeTypeArray.Select(t => t.Type.Name))} Tags: {string.Join(", ", ArchetypeTagArray.Select(t => t.Type.Name))}";

        /// <summary>
        ///     Gets the value of the entity count
        /// </summary>
        internal int EntityCount => _nextComponentIndex;

        /// <summary>
        ///     Gets the value of the data
        /// </summary>
        internal Fields Data => new Fields
        {
            Map = ComponentTagTable,
            Components = Components
        };

        /// <summary>
        ///     Gets the component span
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A span of t</returns>
        internal Span<T> GetComponentSpan<T>()
        {
            ComponentStorageBase[]? components = Components;
            int index = GetComponentIndex<T>();
            if (index == 0)
            {
                FrentExceptions.Throw_ComponentNotFoundException(typeof(T));
            }

            return UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(components.UnsafeArrayIndex(index)).AsSpanLength(_nextComponentIndex);
        }

        /// <summary>
        ///     Gets the component data reference
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The ref</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref T GetComponentDataReference<T>()
        {
            int index = GetComponentIndex<T>();
            return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index)).GetComponentStorageDataReference();
        }

        /// <summary>
        ///     Note! Entity location version is not set!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref EntityIDOnly CreateEntityLocation(EntityFlags flags, out EntityLocation entityLocation)
        {
            if (_entities.Length == _nextComponentIndex)
            {
                Resize(_entities.Length * 2);
            }

            entityLocation.Archetype = this;
            entityLocation.Index = _nextComponentIndex;
            entityLocation.Flags = flags;
            Unsafe.SkipInit(out entityLocation.Version);
            MemoryHelpers.Poison(ref entityLocation.Version);
            return ref _entities.UnsafeArrayIndex(_nextComponentIndex++);
        }

        /// <summary>
        ///     Caller needs write archetype field
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref EntityIDOnly CreateDeferredEntityLocation(World world, scoped ref EntityLocation entityLocation, out int physicalIndex, out ComponentStorageBase[] writeStorage)
        {
            if (_deferredEntityCount == 0)
            {
                world.DeferredCreationArchetypes.Push(this);
            }

            int futureSlot = _nextComponentIndex + _deferredEntityCount++;
            entityLocation.Index = futureSlot;

            if (futureSlot < _entities.Length)
            {
                //hot path: we have space and can directly place into existing array
                writeStorage = Components;
                physicalIndex = futureSlot;
                return ref _entities.UnsafeArrayIndex(physicalIndex);
            }

            //we need to place into temp buffers
            physicalIndex = futureSlot - _entities.Length;
            Debug.Assert(physicalIndex >= 0);
            if (physicalIndex >= _createComponentBufferEntities.Length)
            {
                ResizeCreateComponentBuffers();
            }

            writeStorage = CreateComponentBuffers;

            return ref _createComponentBufferEntities.UnsafeArrayIndex(physicalIndex);
        }

        /// <summary>
        ///     Resolves the deferred entity creations using the specified world
        /// </summary>
        /// <param name="world">The world</param>
        internal void ResolveDeferredEntityCreations(World world)
        {
            Debug.Assert(_deferredEntityCount != 0);
            int deltaFromMaxDeferredInPlace = -(_entities.Length - (_nextComponentIndex + _deferredEntityCount));
            int previousComponentCount = _nextComponentIndex;

            if (!(deltaFromMaxDeferredInPlace <= 0))
            {
                //components overflowed into temp storage

                int oldEntitiesLen = _entities.Length;
                int totalCapacityRequired = previousComponentCount + _deferredEntityCount;
                Debug.Assert(totalCapacityRequired >= oldEntitiesLen);

                //we should always have to resize here - after all, no space is left
                Resize((int) BitOperations.RoundUpToPowerOf2((uint) totalCapacityRequired));
                ComponentStorageBase[]? destination = Components;
                ComponentStorageBase[]? source = CreateComponentBuffers;
                for (int i = 1; i < destination.Length; i++)
                    Array.Copy(source[i].Buffer, 0, destination[i].Buffer, oldEntitiesLen, deltaFromMaxDeferredInPlace);
                Array.Copy(_createComponentBufferEntities, 0, _entities, oldEntitiesLen, deltaFromMaxDeferredInPlace);
            }

            _nextComponentIndex += _deferredEntityCount;

            EntityIDOnly[]? entities = _entities;
            EntityLocation[]? table = world.EntityTable._buffer;
            for (int i = previousComponentCount; i < entities.Length && i < _nextComponentIndex; i++)
                table.UnsafeArrayIndex(entities[i].ID).Archetype = this;

            _deferredEntityCount = 0;
        }

        /// <summary>
        ///     Creates the entity locations using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="world">The world</param>
        /// <returns>The entity span</returns>
        internal Span<EntityIDOnly> CreateEntityLocations(int count, World world)
        {
            int newLen = _nextComponentIndex + count;
            EnsureCapacity(newLen);

            Span<EntityIDOnly> entitySpan = _entities.AsSpan(_nextComponentIndex, count);

            int componentIndex = _nextComponentIndex;
            ref NativeStack<EntityIDOnly> recycled = ref world.RecycledEntityIds;
            for (int i = 0; i < entitySpan.Length; i++)
            {
                ref EntityIDOnly archetypeEntity = ref entitySpan[i];

                archetypeEntity = recycled.CanPop() ? recycled.PopUnsafe() : new EntityIDOnly(world.NextEntityId++, 0);

                ref EntityLocation lookup = ref world.EntityTable.UnsafeIndexNoResize(archetypeEntity.ID);

                lookup.Version = archetypeEntity.Version;
                lookup.Archetype = this;
                lookup.Index = componentIndex++;
                lookup.Flags = EntityFlags.None;
            }

            _nextComponentIndex = componentIndex;

            return entitySpan;
        }

        /// <summary>
        ///     Resizes the new len
        /// </summary>
        /// <param name="newLen">The new len</param>
        private void Resize(int newLen)
        {
            Array.Resize(ref _entities, newLen);
            ComponentStorageBase[]? runners = Components;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        /// <summary>
        ///     Resizes the create component buffers
        /// </summary>
        private void ResizeCreateComponentBuffers()
        {
            int newLen = checked(Math.Max(1, _createComponentBufferEntities.Length) * 2);
            //we only need to resize the EntityIDOnly array when future total entity count is greater than capacity
            Array.Resize(ref _createComponentBufferEntities, newLen);
            ComponentStorageBase[]? runners = CreateComponentBuffers;
            for (int i = 1; i < runners.Length; i++)
                runners[i].ResizeBuffer(newLen);
        }

        /// <summary>
        ///     Ensures the capacity using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        public void EnsureCapacity(int count)
        {
            if (_entities.Length >= count)
            {
                return;
            }

            FastStackArrayPool<EntityIDOnly>.ResizeArrayFromPool(ref _entities, count);
            ComponentStorageBase[]? runners = Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].ResizeBuffer(count);
            }
        }

        /// <summary>
        ///     This method doesn't modify component storages
        /// </summary>
        internal EntityIDOnly DeleteEntityFromStorage(int index, out int deletedIndex)
        {
            deletedIndex = --_nextComponentIndex;
            Debug.Assert(_nextComponentIndex >= 0);
            return _entities.UnsafeArrayIndex(index) = _entities.UnsafeArrayIndex(_nextComponentIndex);
        }

        /// <summary>
        ///     Deletes the entity using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The entity id only</returns>
        internal EntityIDOnly DeleteEntity(int index)
        {
            _nextComponentIndex--;
            Debug.Assert(_nextComponentIndex >= 0);
            //TODO: args

            DeleteComponentData args = new(index, _nextComponentIndex);

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
            ComponentStorageBase[]? comps = Components;
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


            end:

            return _entities.UnsafeArrayIndex(args.ToIndex) = _entities.UnsafeArrayIndex(args.FromIndex);
        }

        /// <summary>
        ///     Updates the world
        /// </summary>
        /// <param name="world">The world</param>
        internal void Update(World world)
        {
            if (_nextComponentIndex == 0)
            {
                return;
            }

            ComponentStorageBase[]? comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Run(world, this);
        }

        /// <summary>
        ///     Updates the world
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="componentID">The component id</param>
        internal void Update(World world, ComponentID componentID)
        {
            if (_nextComponentIndex == 0)
            {
                return;
            }

            int compIndex = GetComponentIndex(componentID);

            if (compIndex == 0)
            {
                return;
            }

            Components.UnsafeArrayIndex(compIndex).Run(world, this);
        }

        /// <summary>
        ///     Multis the threaded update using the specified countdown
        /// </summary>
        /// <param name="countdown">The countdown</param>
        /// <param name="world">The world</param>
        internal void MultiThreadedUpdate(CountdownEvent countdown, World world)
        {
            if (_nextComponentIndex == 0)
            {
                return;
            }

            foreach (ComponentStorageBase? comprunner in Components)
                comprunner.MultithreadedRun(countdown, world, this);
        }

        /// <summary>
        ///     Releases the arrays
        /// </summary>
        internal void ReleaseArrays()
        {
            _entities = [];
            ComponentStorageBase[]? comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
                comprunners[i].Trim(0);
        }

        /// <summary>
        ///     Gets the component index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex<T>() => ComponentTagTable.UnsafeArrayIndex(Component<T>.ID.RawIndex) & GlobalWorldTables.IndexBits;

        /// <summary>
        ///     Gets the component index using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex(ComponentID component) => ComponentTagTable.UnsafeArrayIndex(component.RawIndex) & GlobalWorldTables.IndexBits;

        /// <summary>
        ///     Hases the tag
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag<T>() => ComponentTagTable.UnsafeArrayIndex(Tag<T>.ID.RawValue) << 7 != 0;

        /// <summary>
        ///     Hases the tag using the specified tag id
        /// </summary>
        /// <param name="tagID">The tag id</param>
        /// <returns>The bool</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal bool HasTag(TagID tagID) => ComponentTagTable.UnsafeArrayIndex(tagID.RawValue) << 7 != 0;

        internal Span<EntityIDOnly> GetEntitySpan()
        {
            Debug.Assert(_nextComponentIndex <= _entities.Length);
#if (NETSTANDARD || NETCOREAPP || NETFRAMEWORK) && !NET6_0_OR_GREATER
        return _entities.AsSpan(0, _nextComponentIndex);
#else
            return MemoryMarshal.CreateSpan(ref MemoryMarshal.GetArrayDataReference(_entities), _nextComponentIndex);
#endif
        }

        internal ref EntityIDOnly GetEntityDataReference() => ref MemoryMarshal.GetArrayDataReference(_entities);


        /// <summary>
        ///     The fields
        /// </summary>
        internal struct Fields
        {
            /// <summary>
            ///     The map
            /// </summary>
            internal byte[] Map;

            /// <summary>
            ///     The components
            /// </summary>
            internal ComponentStorageBase[] Components;

            /// <summary>
            ///     Gets the component data reference
            /// </summary>
            /// <typeparam name="T">The </typeparam>
            /// <returns>The ref</returns>
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            internal ref T GetComponentDataReference<T>()
            {
                int index = Map.UnsafeArrayIndex(Component<T>.ID.RawIndex);
                return ref UnsafeExtensions.UnsafeCast<ComponentStorage<T>>(Components.UnsafeArrayIndex(index)).GetComponentStorageDataReference();
            }
        }
    }
}