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
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    public class Archetype(GameObjectType archetypeId, ComponentStorageBase[] components, bool isTempCreateArchetype)
    {
        /// <summary>
        ///     The null
        /// </summary>
        internal static readonly GameObjectType Null;

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastestStack<ArchetypeData> ArchetypeTable = FastestStack<ArchetypeData>.Create(16);

        /// <summary>
        ///     The next archetype id
        /// </summary>
        internal static int NextArchetypeId = -1;

        /// <summary>
        ///     The existing archetypes
        /// </summary>
        private static readonly Dictionary<long, ArchetypeData> ExistingArchetypes = [];

        /// <summary>
        ///     The archetype id
        /// </summary>
        private readonly GameObjectType _archetypeId = archetypeId;


        /// <summary>
        ///     The components
        /// </summary>
        internal readonly ComponentStorageBase[] Components = components;


        //we include version
        //this is so we dont need to lookup
        /// <summary>
        ///     The gameObject id only
        /// </summary>
        private GameObjectIdOnly[] _entities = isTempCreateArchetype ? Array.Empty<GameObjectIdOnly>() : new GameObjectIdOnly[1];

        /// <summary>
        ///     The next component index or deferred gameObject count
        /// </summary>
        /// <remarks>
        ///     You can think of this as a discrimminated union. Next component index is the non-deferred count of a normal
        ///     archetype.
        ///     Deferred gameObject count is the total number of deferred entities, some of which may be stored directly on the
        ///     normal
        ///     archetype.
        /// </remarks>
        private int _nextComponentIndexOrDeferredEntityCount;


        //information for tag existence & component index per id
        //updated by static methods
        /// <summary>
        ///     The raw index
        /// </summary>
        internal byte[] ComponentTagTable = GlobalWorldTables.ComponentTagLocationTable[archetypeId.RawIndex];

        /// <summary>
        ///     Initializes a new instance of the <see cref="Archetype" /> class
        /// </summary>
        static Archetype() => Null = GetArchetypeId([Component.GetComponentId(typeof(void))]);

        /// <summary>
        ///     Gets the value of the id
        /// </summary>
        internal GameObjectType Id => _archetypeId;

        /// <summary>
        ///     Gets the value of the archetype type array
        /// </summary>
        internal FastImmutableArray<ComponentId> ArchetypeTypeArray => _archetypeId.Types;

        /// <summary>
        ///     Gets the value of the gameObject count
        /// </summary>
        internal int EntityCount => NextComponentIndex;

        /// <summary>
        ///     Gets the value of the data
        /// </summary>
        internal Fields Data => new Fields
        {
            Map = ComponentTagTable,
            Components = Components
        };

        /// <summary>
        ///     Gets the value of the next component index
        /// </summary>
        private ref int NextComponentIndex => ref _nextComponentIndexOrDeferredEntityCount;

        /// <summary>
        ///     Gets the value of the deferred gameObject count
        /// </summary>
        private ref int DeferredEntityCount => ref _nextComponentIndexOrDeferredEntityCount;

        /// <summary>
        ///     Gets the component span
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>A span of t</returns>
        internal Span<T> GetComponentSpan<T>()
        {
            ComponentStorageBase[] components = Components;
            int index = GetComponentIndex<T>();
            if (index == 0)
            {
                throw new ComponentNotFoundException(typeof(T));
            }

            return Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref components[0], index))
                .AsSpanLength(NextComponentIndex);
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
            return ref Unsafe.As<ComponentStorage<T>>(Unsafe.Add(ref Components[0], index))
                .GetComponentStorageDataReference();
        }


        /// <summary>
        ///     Creates the gameObject location using the specified flags
        /// </summary>
        /// <param name="flags">The flags</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <returns>The ref gameObject id only</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref GameObjectIdOnly CreateEntityLocation(GameObjectFlags flags, out GameObjectLocation gameObjectLocation)
        {
            if (_entities.Length == NextComponentIndex)
            {
                Resize(_entities.Length * 2);
            }

            gameObjectLocation.Archetype = this;
            gameObjectLocation.Index = NextComponentIndex;
            gameObjectLocation.Flags = flags;
            Unsafe.SkipInit(out gameObjectLocation.Version);
            //poison prolly isnt needed since archetype forces clear anyways
            MemoryHelpers.Poison(ref gameObjectLocation.Version);

            return ref Unsafe.Add(ref _entities[0], NextComponentIndex++);
        }

        /// <summary>
        ///     Note! GameObject location version is not set!
        /// </summary>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal ref GameObjectIdOnly CreateDeferredEntityLocation(Scene scene, Archetype deferredCreationArchetype,
            scoped ref GameObjectLocation gameObjectLocation, out ComponentStorageBase[] writeStorage)
        {
            if (deferredCreationArchetype.DeferredEntityCount == 0)
            {
                scene.DeferredCreationArchetypes.Push(new ArchetypeDeferredUpdateRecord(this, deferredCreationArchetype, EntityCount));
            }

            int futureSlot = NextComponentIndex + deferredCreationArchetype.DeferredEntityCount++;

            if (futureSlot < _entities.Length)
            {
                //hot path: we have space and can directly place into existing array
                writeStorage = Components;
                gameObjectLocation.Index = futureSlot;
                gameObjectLocation.Archetype = this;
                return ref Unsafe.Add(ref _entities[0], futureSlot);
            }

            return ref CreateDeferredEntityLocationTempBuffers(deferredCreationArchetype, futureSlot, ref gameObjectLocation,
                out writeStorage);
        }

        // Only to be called by CreateDeferredEntityLocation
        // Allow the jit to inline that method more easily
        /// <summary>
        ///     Creates the deferred gameObject location temp buffers using the specified deferred creation archetype
        /// </summary>
        /// <param name="deferredCreationArchetype">The deferred creation archetype</param>
        /// <param name="futureSlot">The future slot</param>
        /// <param name="gameObjectLocation">The gameObject location</param>
        /// <param name="writeStorage">The write storage</param>
        /// <returns>The ref gameObject id only</returns>
        private ref GameObjectIdOnly CreateDeferredEntityLocationTempBuffers(Archetype deferredCreationArchetype,
            int futureSlot, scoped ref GameObjectLocation gameObjectLocation, out ComponentStorageBase[] writeStorage)
        {
            //we need to place into temp buffers
            gameObjectLocation.Index = futureSlot - _entities.Length;
            gameObjectLocation.Archetype = deferredCreationArchetype;


            if (gameObjectLocation.Index >= deferredCreationArchetype._entities.Length)
            {
                deferredCreationArchetype.ResizeCreateComponentBuffers();
            }

            writeStorage = deferredCreationArchetype.Components;

            return ref Unsafe.Add(ref deferredCreationArchetype._entities[0], gameObjectLocation.Index);
        }

        /// <summary>
        ///     Resolves the deferred gameObject creations using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="deferredCreationArchetype">The deferred creation archetype</param>
        internal void ResolveDeferredEntityCreations(Scene scene, Archetype deferredCreationArchetype)
        {
            int deltaFromMaxDeferredInPlace =
                -(_entities.Length - (NextComponentIndex + deferredCreationArchetype.DeferredEntityCount));
            int previousComponentCount = NextComponentIndex;

            if (!(deltaFromMaxDeferredInPlace <= 0))
            {
                //components overflowed into temp storage

                int oldEntitiesLen = _entities.Length;
                int totalCapacityRequired = previousComponentCount + deferredCreationArchetype.DeferredEntityCount;

                //we should always have to resize here - after all, no space is left
                Resize((int) BitOperations.RoundUpToPowerOf2((uint) totalCapacityRequired));
                ComponentStorageBase[] destination = Components;
                ComponentStorageBase[] source = deferredCreationArchetype.Components;
                for (int i = 1; i < destination.Length; i++)
                {
                    Array.Copy(source[i].Buffer, 0, destination[i].Buffer, oldEntitiesLen, deltaFromMaxDeferredInPlace);
                }

                Array.Copy(deferredCreationArchetype._entities, 0, _entities, oldEntitiesLen, deltaFromMaxDeferredInPlace);
            }

            NextComponentIndex += deferredCreationArchetype.DeferredEntityCount;

            GameObjectIdOnly[] entities = _entities;
            GameObjectLocation[] table = scene.EntityTable._buffer;
            for (int i = previousComponentCount; (i < entities.Length) && (i < NextComponentIndex); i++)
            {
                ref GameObjectLocation gameObjectLocationToResolve = ref Unsafe.Add(ref table[0], entities[i].ID);
                gameObjectLocationToResolve.Archetype = this;
                gameObjectLocationToResolve.Index = i;
            }

            deferredCreationArchetype.DeferredEntityCount = 0;
        }

        /// <summary>
        ///     Creates the gameObject locations using the specified count
        /// </summary>
        /// <param name="count">The count</param>
        /// <param name="scene">The scene</param>
        /// <returns>The gameObject span</returns>
        internal Span<GameObjectIdOnly> CreateEntityLocations(int count, Scene scene)
        {
            int newLen = NextComponentIndex + count;
            EnsureCapacity(newLen);

            Span<GameObjectIdOnly> entitySpan = _entities.AsSpan(NextComponentIndex, count);

            int componentIndex = NextComponentIndex;
            ref FastestStack<GameObjectIdOnly> recycled = ref scene.RecycledEntityIds;
            for (int i = 0; i < entitySpan.Length; i++)
            {
                ref GameObjectIdOnly archetypeEntity = ref entitySpan[i];

                archetypeEntity = recycled.CanPop() ? recycled.Pop() : new GameObjectIdOnly(scene.NextEntityId++, 0);

                ref GameObjectLocation lookup = ref scene.EntityTable.UnsafeIndexNoResize(archetypeEntity.ID);

                lookup.Version = archetypeEntity.Version;
                lookup.Archetype = this;
                lookup.Index = componentIndex++;
                lookup.Flags = GameObjectFlags.None;
            }

            NextComponentIndex = componentIndex;

            return entitySpan;
        }

        /// <summary>
        ///     Resizes the new len
        /// </summary>
        /// <param name="newLen">The new len</param>
        private void Resize(int newLen)
        {
            Array.Resize(ref _entities, newLen);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].ResizeBuffer(newLen);
            }
        }

        /// <summary>
        ///     Resizes the create component buffers
        /// </summary>
        private void ResizeCreateComponentBuffers()
        {
            int newLen = checked(Math.Max(1, _entities.Length) * 2);
            //we only need to resize the EntityIDOnly array when future total gameObject count is greater than capacity
            Array.Resize(ref _entities, newLen);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].ResizeBuffer(newLen);
            }
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

            FastestArrayPool<GameObjectIdOnly>.ResizeArrayFromPool(ref _entities, count);
            ComponentStorageBase[] runners = Components;
            for (int i = 1; i < runners.Length; i++)
            {
                runners[i].ResizeBuffer(count);
            }
        }

        /// <summary>
        ///     This method doesn't modify component storages
        /// </summary>
        internal GameObjectIdOnly DeleteEntityFromStorage(int index, out int deletedIndex)
        {
            deletedIndex = --NextComponentIndex;
            return Unsafe.Add(ref _entities[0], index) = Unsafe.Add(ref _entities[0], NextComponentIndex);
        }

        /// <summary>
        ///     Deletes the gameObject using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <returns>The gameObject id only</returns>
        internal GameObjectIdOnly DeleteEntity(int index)
        {
            NextComponentIndex--;

            DeleteComponentData args = new DeleteComponentData(index, NextComponentIndex);

            ref ComponentStorageBase first = ref Components[0];

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
            ComponentStorageBase[] comps = Components;
            for (int i = 9; i < comps.Length; i++)
            {
                comps[i].Delete(args);
            }


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

            return Unsafe.Add(ref _entities[0], args.ToIndex) = Unsafe.Add(ref _entities[0], args.FromIndex);
        }

        /// <summary>
        ///     Updates the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        internal void Update(Scene scene)
        {
            if (NextComponentIndex == 0)
            {
                return;
            }

            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
            {
                comprunners[i].Run(scene, this);
            }
        }

        /// <summary>
        ///     Updates the scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="start">The start</param>
        /// <param name="length">The length</param>
        internal void Update(Scene scene, int start, int length)
        {
            if (NextComponentIndex == 0)
            {
                return;
            }

            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
            {
                comprunners[i].Run(scene, this, start, length);
            }
        }

        /// <summary>
        ///     Releases the arrays
        /// </summary>
        internal void ReleaseArrays()
        {
            _entities = [];
            ComponentStorageBase[] comprunners = Components;
            for (int i = 1; i < comprunners.Length; i++)
            {
                comprunners[i].Trim(0);
            }
        }

        /// <summary>
        ///     Gets the component index
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex<T>()
        {
            ushort index = Component<T>.Id.RawIndex;
            return Unsafe.Add(ref ComponentTagTable[0], index) & GlobalWorldTables.IndexBits;
        }

        /// <summary>
        ///     Gets the component index using the specified component
        /// </summary>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        internal int GetComponentIndex(ComponentId component) => Unsafe.Add(ref ComponentTagTable[0], component.RawIndex) & GlobalWorldTables.IndexBits;

        /// <summary>
        ///     Gets the gameObject span
        /// </summary>
        /// <returns>A span of gameObject id only</returns>
        internal Span<GameObjectIdOnly> GetEntitySpan() => _entities.AsSpan(0, NextComponentIndex);

        /// <summary>
        ///     Gets the gameObject data reference
        /// </summary>
        /// <returns>The ref gameObject id only</returns>
        internal ref GameObjectIdOnly GetEntityDataReference() => ref _entities[0];


        /// <summary>
        ///     Creates the or get existing archetype using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="scene">The scene</param>
        /// <param name="typeArray">The type array</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentId> types, Scene scene, FastImmutableArray<ComponentId>? typeArray = null)
        {
            GameObjectType id = GetArchetypeId(types, typeArray);
            return CreateOrGetExistingArchetype(id, scene);
        }

        /// <summary>
        ///     Creates the or get existing archetype using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="scene">The scene</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(GameObjectType id, Scene scene)
        {
            ref WorldArchetypeTableItem archetype = ref scene.WorldArchetypeTable[id.RawIndex];
            if (archetype.Archetype is not null)
            {
                return archetype.Archetype;
            }

            FastImmutableArray<ComponentId> types = id.Types;
            ComponentStorageBase[] componentRunners = new ComponentStorageBase[types.Length + 1];
            ComponentStorageBase[] tmpRunners = new ComponentStorageBase[types.Length + 1];
            for (int i = 1; i < componentRunners.Length; i++)
            {
                IComponentStorageBaseFactory fact = Component.GetComponentFactoryFromType(types[i - 1].Type);
                componentRunners[i] = fact.Create(1);
                tmpRunners[i] = fact.Create(0);
            }

            Archetype normal = new Archetype(id, componentRunners, false);
            Archetype tmpCreateArchetype = new Archetype(id, tmpRunners, true);

            archetype = new WorldArchetypeTableItem(normal, tmpCreateArchetype);
            scene.ArchetypeAdded(normal, tmpCreateArchetype);

            return archetype.Archetype;
        }

        /// <summary>
        ///     Gets the adjacent archetype lookup using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="edge">The edge</param>
        /// <returns>The archetype</returns>
        internal static Archetype GetAdjacentArchetypeLookup(Scene scene, ArchetypeEdgeKey edge)
        {
            if (scene.ArchetypeGraphEdges.TryGetValue(edge, out Archetype archetype))
            {
                return archetype;
            }

            return GetAdjacentArchetypeCold(scene, edge);
        }

        /// <summary>
        ///     Gets the adjacent archetype cold using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="edge">The edge</param>
        /// <returns>The archetype</returns>
        internal static Archetype GetAdjacentArchetypeCold(Scene scene, ArchetypeEdgeKey edge)
        {
            //this scene doesn't have the archetype, or it doesnt even exist

            Archetype from = edge.ArchetypeFrom.Archetype(scene)!;
            FastImmutableArray<ComponentId> fromComponents = edge.ArchetypeFrom.Types;

            switch (edge.EdgeType)
            {
                case ArchetypeEdgeType.AddComponent:
                    fromComponents = MemoryHelpers.Concat(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.RemoveComponent:
                    fromComponents = MemoryHelpers.Remove(fromComponents, edge.ComponentID);
                    break;
            }

            Archetype archetype = CreateOrGetExistingArchetype(fromComponents.AsSpan(), scene, fromComponents);

            return archetype;
        }


        /// <summary>
        ///     Gets the archetype id using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="typesArray">The types array</param>
        /// <exception cref="InvalidOperationException">Entities can have a max of 127 components!</exception>
        /// <exception cref="InvalidOperationException">Exceeded maximum unique archetype count of 65535</exception>
        /// <returns>The game object type</returns>
        internal static GameObjectType GetArchetypeId(ReadOnlySpan<ComponentId> types, FastImmutableArray<ComponentId>? typesArray = null)
        {
            if (types.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new InvalidOperationException("Entities can have a max of 127 components!");
            }

            lock (GlobalWorldTables.BufferChangeLock)
            {
                long key = GetHash(types);
                if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value))
                {
                    return value.Id;
                }

                int nextIdInt = ++NextArchetypeId;
                if (nextIdInt == ushort.MaxValue)
                {
                    throw new InvalidOperationException("Exceeded maximum unique archetype count of 65535");
                }

                ArchetypeID finalId = new ArchetypeID((ushort) nextIdInt);

                FastImmutableArray<ComponentId> arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);

                ArchetypeData slot = new ArchetypeData(finalId, arr);
                ArchetypeTable.Push(slot);
                ModifyComponentLocationTable(arr, finalId.RawIndex);

                ExistingArchetypes[key] = slot;

                return finalId;
            }
        }


        /// <summary>
        ///     Modifies the component location table using the specified archetype types
        /// </summary>
        /// <param name="archetypeTypes">The archetype types</param>
        /// <param name="id">The id</param>
        private static void ModifyComponentLocationTable(FastImmutableArray<ComponentId> archetypeTypes, int id)
        {
            if (GlobalWorldTables.ComponentTagLocationTable.Length == id)
            {
                int size = Math.Max(id << 1, 1);
                Array.Resize(ref GlobalWorldTables.ComponentTagLocationTable, size);
                foreach (Scene world in GlobalWorldTables.Worlds.AsSpan())
                {
                    if (world is Scene w)
                    {
                        w.UpdateArchetypeTable(size);
                    }
                }
            }

            //for (int i = 0; i < archetypeTypes.Length; i++)
            //{
            //    _ = Component.GetComponentID(archetypeTypes[i].Type);
            //}

            ref byte[] componentTable = ref GlobalWorldTables.ComponentTagLocationTable[id];
            componentTable = new byte[GlobalWorldTables.ComponentTagTableBufferSize];

            for (int i = 0; i < archetypeTypes.Length; i++)
                //add 1 so zero is null always
            {
                componentTable[archetypeTypes[i].RawIndex] = (byte) (i + 1);
            }
        }

        /// <summary>
        ///     Gets the hash using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <returns>The hash</returns>
        private static long GetHash(ReadOnlySpan<ComponentId> types)
        {
            HashCode h1 = new HashCode();
            HashCode h2 = new HashCode();

            int i;
            for (i = 0; i < types.Length >> 1; i++)
            {
                h1.Add(types[i]);
            }

            for (; i < types.Length; i++)
            {
                h2.Add(types[i]);
            }

            long hash = (long) h1.ToHashCode() * 1610612741 + h2.ToHashCode();

            return hash;
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[] {Component<T>.Id});

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);


        /// <summary>
        ///     The null
        /// </summary>
        internal static readonly GameObjectType Null;

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastestStack<ArchetypeData> ArchetypeTable = FastestStack<ArchetypeData>.Create(16);

        /// <summary>
        ///     The next archetype id
        /// </summary>
        internal static int NextArchetypeId = -1;

        /// <summary>
        ///     The existing archetypes
        /// </summary>
        private static readonly Dictionary<long, ArchetypeData> ExistingArchetypes = [];

        /// <summary>
        ///     Initializes a new instance of the <see cref="Archetype" /> class
        /// </summary>
        static Archetype() => Null = GetArchetypeId([Component.GetComponentId(typeof(void))]);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T>.CreateInstance(1);
                tmpStorages[i] = Component<T>.CreateInstance(0);

                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }

        /// <summary>
        ///     Creates the or get existing archetype using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="scene">The scene</param>
        /// <param name="typeArray">The type array</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentId> types, Scene scene, FastImmutableArray<ComponentId>? typeArray = null)
        {
            GameObjectType id = GetArchetypeId(types, typeArray);
            return CreateOrGetExistingArchetype(id, scene);
        }

        /// <summary>
        ///     Creates the or get existing archetype using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="scene">The scene</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(GameObjectType id, Scene scene)
        {
            ref WorldArchetypeTableItem archetype = ref scene.WorldArchetypeTable[id.RawIndex];
            if (archetype.Archetype is not null)
            {
                return archetype.Archetype;
            }

            FastImmutableArray<ComponentId> types = id.Types;
            ComponentStorageBase[] componentRunners = new ComponentStorageBase[types.Length + 1];
            ComponentStorageBase[] tmpRunners = new ComponentStorageBase[types.Length + 1];
            for (int i = 1; i < componentRunners.Length; i++)
            {
                IComponentStorageBaseFactory fact = Component.GetComponentFactoryFromType(types[i - 1].Type);
                componentRunners[i] = fact.Create(1);
                tmpRunners[i] = fact.Create(0);
            }

            Archetype normal = new Archetype(id, componentRunners, false);
            Archetype tmpCreateArchetype = new Archetype(id, tmpRunners, true);

            archetype = new WorldArchetypeTableItem(normal, tmpCreateArchetype);
            scene.ArchetypeAdded(normal, tmpCreateArchetype);

            return archetype.Archetype;
        }

        /// <summary>
        ///     Gets the adjacent archetype lookup using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="edge">The edge</param>
        /// <returns>The archetype</returns>
        internal static Archetype GetAdjacentArchetypeLookup(Scene scene, ArchetypeEdgeKey edge)
        {
            if (scene.ArchetypeGraphEdges.TryGetValue(edge, out Archetype archetype))
            {
                return archetype;
            }

            return GetAdjacentArchetypeCold(scene, edge);
        }

        /// <summary>
        ///     Gets the adjacent archetype cold using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="edge">The edge</param>
        /// <returns>The archetype</returns>
        internal static Archetype GetAdjacentArchetypeCold(Scene scene, ArchetypeEdgeKey edge)
        {
            //this scene doesn't have the archetype, or it doesnt even exist

            Archetype from = edge.ArchetypeFrom.Archetype(scene)!;
            FastImmutableArray<ComponentId> fromComponents = edge.ArchetypeFrom.Types;

            switch (edge.EdgeType)
            {
                case ArchetypeEdgeType.AddComponent:
                    fromComponents = MemoryHelpers.Concat(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.RemoveComponent:
                    fromComponents = MemoryHelpers.Remove(fromComponents, edge.ComponentID);
                    break;
            }

            Archetype archetype = CreateOrGetExistingArchetype(fromComponents.AsSpan(), scene, fromComponents);

            return archetype;
        }


        /// <summary>
        ///     Gets the archetype id using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="typesArray">The types array</param>
        /// <exception cref="InvalidOperationException">Entities can have a max of 127 components!</exception>
        /// <exception cref="InvalidOperationException">Exceeded maximum unique archetype count of 65535</exception>
        /// <returns>The game object type</returns>
        internal static GameObjectType GetArchetypeId(ReadOnlySpan<ComponentId> types, FastImmutableArray<ComponentId>? typesArray = null)
        {
            if (types.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new InvalidOperationException("Entities can have a max of 127 components!");
            }

            lock (GlobalWorldTables.BufferChangeLock)
            {
                long key = GetHash(types);
                if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value))
                {
                    return value.Id;
                }

                int nextIdInt = ++NextArchetypeId;
                if (nextIdInt == ushort.MaxValue)
                {
                    throw new InvalidOperationException("Exceeded maximum unique archetype count of 65535");
                }

                ArchetypeID finalId = new ArchetypeID((ushort) nextIdInt);

                FastImmutableArray<ComponentId> arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);

                ArchetypeData slot = new ArchetypeData(finalId, arr);
                ArchetypeTable.Push(slot);
                ModifyComponentLocationTable(arr, finalId.RawIndex);

                ExistingArchetypes[key] = slot;

                return finalId;
            }
        }


        /// <summary>
        ///     Modifies the component location table using the specified archetype types
        /// </summary>
        /// <param name="archetypeTypes">The archetype types</param>
        /// <param name="id">The id</param>
        private static void ModifyComponentLocationTable(FastImmutableArray<ComponentId> archetypeTypes, int id)
        {
            if (GlobalWorldTables.ComponentTagLocationTable.Length == id)
            {
                int size = Math.Max(id << 1, 1);
                Array.Resize(ref GlobalWorldTables.ComponentTagLocationTable, size);
                foreach (Scene world in GlobalWorldTables.Worlds.AsSpan())
                {
                    if (world is Scene w)
                    {
                        w.UpdateArchetypeTable(size);
                    }
                }
            }

            //for (int i = 0; i < archetypeTypes.Length; i++)
            //{
            //    _ = Component.GetComponentID(archetypeTypes[i].Type);
            //}

            ref byte[] componentTable = ref GlobalWorldTables.ComponentTagLocationTable[id];
            componentTable = new byte[GlobalWorldTables.ComponentTagTableBufferSize];

            for (int i = 0; i < archetypeTypes.Length; i++)
                //add 1 so zero is null always
            {
                componentTable[archetypeTypes[i].RawIndex] = (byte) (i + 1);
            }
        }

        /// <summary>
        ///     Gets the hash using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <returns>The hash</returns>
        private static long GetHash(ReadOnlySpan<ComponentId> types)
        {
            HashCode h1 = new HashCode();
            HashCode h2 = new HashCode();

            int i;
            for (i = 0; i < types.Length >> 1; i++)
            {
                h1.Add(types[i]);
            }

            for (; i < types.Length; i++)
            {
                h2.Add(types[i]);
            }

            long hash = (long) h1.ToHashCode() * 1610612741 + h2.ToHashCode();

            return hash;
        }

        /// <summary>
        ///     The of component class
        /// </summary>
        internal static class OfComponent<TC>
        {
            /// <summary>
            ///     The id
            /// </summary>
            public static readonly int Index = GlobalWorldTables.ComponentIndex(Id, Component<TC>.Id);
        }
    }


    /// <summary>
    ///     The archetype class
    /// </summary>
    public static class Archetype<T1, T2>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[] {Component<T1>.Id, Component<T2>.Id});

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[] {Component<T1>.Id, Component<T2>.Id, Component<T3>.Id});

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[]
                {Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id});

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4, T5>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[]
                {Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id});

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T5>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T5>.CreateInstance(1);
                tmpStorages[i] = Component<T5>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[]
            {
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id, Component<T6>.Id
            });

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T5>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T5>.CreateInstance(1);
                tmpStorages[i] = Component<T5>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T6>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T6>.CreateInstance(1);
                tmpStorages[i] = Component<T6>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[]
            {
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id, Component<T6>.Id,
                Component<T7>.Id
            });

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T5>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T5>.CreateInstance(1);
                tmpStorages[i] = Component<T5>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T6>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T6>.CreateInstance(1);
                tmpStorages[i] = Component<T6>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T7>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T7>.CreateInstance(1);
                tmpStorages[i] = Component<T7>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs =
            new FastImmutableArray<ComponentId>(new[]
            {
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id, Component<T6>.Id,
                Component<T7>.Id, Component<T8>.Id
            });

        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), ArchetypeComponentIDs);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
            if (archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(scene);
            }

            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = Unsafe.Add(ref map[0], Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T5>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T5>.CreateInstance(1);
                tmpStorages[i] = Component<T5>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T6>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T6>.CreateInstance(1);
                tmpStorages[i] = Component<T6>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T7>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T7>.CreateInstance(1);
                tmpStorages[i] = Component<T7>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T8>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T8>.CreateInstance(1);
                tmpStorages[i] = Component<T8>.CreateInstance(0);


                Archetype archetype = new Archetype(Id, runners, false);
                Archetype tempCreateArchetype = new Archetype(Id, tmpStorages, true);

                scene.ArchetypeAdded(archetype, tempCreateArchetype);
                return new WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }
    }
}