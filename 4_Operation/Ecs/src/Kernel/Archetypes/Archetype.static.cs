// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Archetype.static.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
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

        //ArchetypeTypes init first, then ID
        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), 
            ArchetypeComponentIDs);

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
    partial class Archetype
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
        ///     Initializes a new instance of the <see cref="Archetype" /> class
        /// </summary>
        static Archetype() => Null = GetArchetypeId([Component.GetComponentId(typeof(void))]);

        //Deferred creation entities fully supported
        ////this archetype exists only so that "GameObjectLocation"s of deferred archetypes have something to point to
        ////disable so less overhead
        //DeferredCreate = GetArchetypeID([], [Tag.GetTagID(typeof(DeferredCreate)), Tag.GetTagID(typeof(Disable))]);
        /// <summary>
        ///     Creates the or get existing archetype using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="tagTypes">The tag types</param>
        /// <param name="scene">The scene</param>
        /// <param name="typeArray">The type array</param>
        /// <param name="tagTypesArray">The tag types array</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentId> types,
            Scene scene, FastImmutableArray<ComponentId>? typeArray = null)
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
        /// <param name="tagTypes">The tag types</param>
        /// <param name="typesArray">The types array</param>
        /// <param name="tagTypesArray">The tag types array</param>
        /// <exception cref="InvalidOperationException">Entities can have a max of 127 components!</exception>
        /// <exception cref="InvalidOperationException">Exceeded maximum unique archetype count of 65535</exception>
        /// <returns>The archetype id</returns>
        internal static GameObjectType GetArchetypeId(ReadOnlySpan<ComponentId> types, FastImmutableArray<ComponentId>? typesArray = null)
        {
            if (types.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new InvalidOperationException("Entities can have a max of 127 components!");
            }

            lock (GlobalWorldTables.BufferChangeLock)
            {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && (!NET6_0_OR_GREATER)
                long key = GetHash(types);
                if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value)) return value.Id;

                int nextIdInt = ++NextArchetypeId;
                if (nextIdInt == ushort.MaxValue)
                    throw new InvalidOperationException("Exceeded maximum unique archetype count of 65535");
                ArchetypeID finalId = new ArchetypeID((ushort) nextIdInt);

                FastImmutableArray<ComponentId> arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);

                ArchetypeData slot = new ArchetypeData(finalId, arr);
                ArchetypeTable.Push(slot);
                ModifyComponentLocationTable(arr, finalId.RawIndex);

                ExistingArchetypes[key] = slot;
#else
                ref ArchetypeData slot =
                    ref CollectionsMarshal.GetValueRefOrAddDefault(ExistingArchetypes, GetHash(types), out bool exists);
                GameObjectType finalId;

                if (exists)
                {
                    //can't be null if entry exists
                    finalId = slot!.Id;
                }
                else
                {
                    int nextIdInt = ++NextArchetypeId;
                    if (nextIdInt == ushort.MaxValue)
                    {
                        throw new InvalidOperationException("Exceeded maximum unique archetype count of 65535");
                    }

                    finalId = new GameObjectType((ushort) nextIdInt);

                    FastImmutableArray<ComponentId> arr =
                        typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);

                    slot = new ArchetypeData(finalId, arr);
                    ArchetypeTable.Push(slot);
                    ModifyComponentLocationTable(arr, finalId.RawIndex);
                }
#endif

                return finalId;
            }
        }

        /// <summary>
        ///     Modifies the component location table using the specified archetype types
        /// </summary>
        /// <param name="archetypeTypes">The archetype types</param>
        /// <param name="archetypeTags">The archetype tags</param>
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
            componentTable.AsSpan().Fill(GlobalWorldTables.DefaultNoTag);

            for (int i = 0; i < archetypeTypes.Length; i++)
                //add 1 so zero is null always
            {
                componentTable[archetypeTypes[i].RawIndex] = (byte) (i + 1);
            }
        }


        private static long GetHash(ReadOnlySpan<ComponentId> types)
        {
            HashCode h1 = new();
            HashCode h2 = new();

            int i;
            for (i = 0; i < types.Length >> 1; i++)
            {
                h1.Add(types[i]);
            }


            uint hash1 = 0U;
            uint hash2 = 0U;
            
            h1.Add(HashCode.Combine(hash1, hash2));

            for (; i < types.Length; i++)
            {
                h2.Add(types[i]);
            }

            long hash = (long) h1.ToHashCode() * 1610612741 + h2.ToHashCode();

            return hash;
        }
    }
}