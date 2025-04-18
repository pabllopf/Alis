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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Marshalling;
using Alis.Core.Ecs.Updating;
using HashCode = Alis.Core.Aspect.Math.Util.HashCode;

namespace Alis.Core.Ecs.Arch
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T>
    {
        /// <summary>
        ///     The id
        /// </summary>
        public static readonly FastImmutableArray<ComponentID> ArchetypeComponentIDs = new FastImmutableArray<ComponentID>(new[] {Component<T>.ID});

        //ArchetypeTypes init first, then ID
        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly EntityType ID = Archetype.GetArchetypeID(ArchetypeComponentIDs.AsSpan(), [], ArchetypeComponentIDs, FastImmutableArray<TagId>.Empty);

        /// <summary>
        ///     Creates the new or get existing archetype using the specified world
        /// </summary>
        /// <param name="scene">The world</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateNewOrGetExistingArchetype(Scene scene)
        {
            ushort index = ID.RawIndex;
            ref Archetype archetype = ref scene.WorldArchetypeTable.UnsafeArrayIndex(index);
            archetype ??= CreateArchetype(scene);
            return archetype!;

            //this method is literally only called once per world
            [MethodImpl(MethodImplOptions.NoInlining)]
            static Archetype CreateArchetype(Scene world)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[ID.RawIndex];

                int i;

                i = map.UnsafeArrayIndex(Component<T>.ID.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T>.CreateInstance(1);
                tmpStorages[i] = Component<T>.CreateInstance(0);

                Archetype archetype = new Archetype(ID, runners, tmpStorages);

                world.ArchetypeAdded(archetype);
                return archetype;
            }
        }

        /// <summary>
        ///     The of component class
        /// </summary>
        internal static class OfComponent<C>
        {
            /// <summary>
            ///     The id
            /// </summary>
            public static readonly int Index = GlobalWorldTables.ComponentIndex(ID, Component<C>.ID);
        }
    }

    /// <summary>
    ///     The archetype class
    /// </summary>
    internal partial class Archetype
    {
        /// <summary>
        ///     The null
        /// </summary>
        internal static readonly EntityType Null;

        /// <summary>
        ///     The deferred create
        /// </summary>
        internal static readonly EntityType DeferredCreate;

        /// <summary>
        ///     The create
        /// </summary>
        internal static FastStack<ArchetypeData> ArchetypeTable = FastStack<ArchetypeData>.Create(16);

        /// <summary>
        ///     The next archetype id
        /// </summary>
        internal static int NextArchetypeID = -1;

        /// <summary>
        ///     The existing archetypes
        /// </summary>
        private static readonly Dictionary<long, ArchetypeData> ExistingArchetypes = [];

        /// <summary>
        ///     Initializes a new instance of the <see cref="Archetype" /> class
        /// </summary>
        static Archetype()
        {
            Null = GetArchetypeID([Component.GetComponentID(typeof(void))], [Tag.GetTagID(typeof(Disable))]);
            //this archetype exists only so that "EntityLocation"s of deferred archetypes have something to point to
            //disable so less overhead
            DeferredCreate = GetArchetypeID([], [Tag.GetTagID(typeof(DeferredCreate)), Tag.GetTagID(typeof(Disable))]);
        }

        /// <summary>
        ///     Creates the or get existing archetype using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="tagTypes">The tag types</param>
        /// <param name="scene">The world</param>
        /// <param name="typeArray">The type array</param>
        /// <param name="tagTypesArray">The tag types array</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagId> tagTypes, Scene scene, FastImmutableArray<ComponentID>? typeArray = null, FastImmutableArray<TagId>? tagTypesArray = null)
        {
            EntityType id = GetArchetypeID(types, tagTypes, typeArray, tagTypesArray);
            return CreateOrGetExistingArchetype(id, scene);
        }

        /// <summary>
        ///     Creates the or get existing archetype using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="scene">The world</param>
        /// <returns>The archetype</returns>
        internal static Archetype CreateOrGetExistingArchetype(EntityType id, Scene scene)
        {
            ref Archetype archetype = ref scene.WorldArchetypeTable[id.RawIndex];
            if (archetype is not null)
            {
                return archetype;
            }

            FastImmutableArray<ComponentID> types = id.Types;
            ComponentStorageBase[] componentRunners = new ComponentStorageBase[types.Length + 1];
            ComponentStorageBase[] tmpRunners = new ComponentStorageBase[types.Length + 1];
            int size = componentRunners.Length;
            for (int i = 1; i < size; i++)
            {
                IComponentStorageBaseFactory fact = Component.GetComponentFactoryFromType(types[i - 1].Type);
                componentRunners[i] = fact.Create(1);
                tmpRunners[i] = fact.Create(0);
            }

            archetype = new Archetype(id, componentRunners, tmpRunners);
            scene.ArchetypeAdded(archetype);

            return archetype;
        }

        /// <summary>
        ///     Gets the adjacent archetype cold using the specified world
        /// </summary>
        /// <param name="scene">The world</param>
        /// <param name="edge">The edge</param>
        /// <returns>The archetype</returns>
        internal static Archetype GetAdjacentArchetypeCold(Scene scene, ArchetypeEdgeKey edge)
        {
            //this world doesn't have the archetype, or it doesnt even exist

            Archetype from = edge.ArchetypeFrom.Archetype(scene);
            FastImmutableArray<ComponentID> fromComponents = edge.ArchetypeFrom.Types;
            FastImmutableArray<TagId> fromTags = edge.ArchetypeFrom.Tags;

            switch (edge.EdgeType)
            {
                case ArchetypeEdgeType.AddComponent:
                    fromComponents = MemoryHelpers.Concat(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.RemoveComponent:
                    fromComponents = MemoryHelpers.Remove(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.AddTag:
                    fromTags = MemoryHelpers.Concat(fromTags, edge.TagId);
                    break;
                case ArchetypeEdgeType.RemoveTag:
                    fromTags = MemoryHelpers.Remove(fromTags, edge.TagId);
                    break;
            }

            Archetype archetype = CreateOrGetExistingArchetype(fromComponents.AsSpan(), fromTags.AsSpan(), scene, fromComponents, fromTags);

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
        /// <returns>The entity type</returns>
        internal static EntityType GetArchetypeID(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagId> tagTypes, FastImmutableArray<ComponentID>? typesArray = null, FastImmutableArray<TagId>? tagTypesArray = null)
        {
            if (types.Length > MemoryHelpers.MaxComponentCount)
            {
                throw new InvalidOperationException("Entities can have a max of 127 components!");
            }

            lock (GlobalWorldTables.BufferChangeLock)
            {
#if (NETSTANDARD || NETFRAMEWORK || NETCOREAPP) && !NET6_0_OR_GREATER
                long key = GetHash(types, tagTypes);
                if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value))
                {
                    return value.Id;
                }

                int nextIDInt = ++NextArchetypeID;
                if (nextIDInt == ushort.MaxValue)
                {
                    throw new InvalidOperationException("Exceeded maximum unique archetype count of 65535");
                }

                EntityType finalID = new EntityType((ushort) nextIDInt);

                FastImmutableArray<ComponentID> arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);
                FastImmutableArray<TagId> tagArr = tagTypesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(tagTypes);

                ArchetypeData slot = new ArchetypeData(finalID, arr, tagArr);
                ArchetypeTable.Push(slot);
                ModifyComponentLocationTable(arr, tagArr, finalID.RawIndex);

                ExistingArchetypes[key] = slot;
#else
                ref ArchetypeData slot = ref CollectionsMarshal.GetValueRefOrAddDefault(ExistingArchetypes, GetHash(types, tagTypes), out bool exists);
                ArchetypeID finalID;

                if (exists)
                {
                    //can't be null if entry exists
                    finalID = slot!.Id;
                }
                else
                {
                    int nextIDInt = ++NextArchetypeID;
                    if (nextIDInt == ushort.MaxValue)
                    {
                        throw new InvalidOperationException($"Exceeded maximum unique archetype count of 65535");
                    }

                    finalID = new ArchetypeID((ushort) nextIDInt);

                    FastImmutableArray<ComponentID> arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);
                    FastImmutableArray<TagId> tagArr = tagTypesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(tagTypes);

                    slot = new ArchetypeData(finalID, arr, tagArr);
                    ArchetypeTable.Push(slot);
                    ModifyComponentLocationTable(arr, tagArr, finalID.RawIndex);
                }
#endif

                return finalID;
            }
        }

        /// <summary>
        ///     Modifies the component location table using the specified archetype types
        /// </summary>
        /// <param name="archetypeTypes">The archetype types</param>
        /// <param name="archetypeTags">The archetype tags</param>
        /// <param name="id">The id</param>
        private static void ModifyComponentLocationTable(FastImmutableArray<ComponentID> archetypeTypes, FastImmutableArray<TagId> archetypeTags, int id)
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

            ref byte[] componentTable = ref GlobalWorldTables.ComponentTagLocationTable[id];
            componentTable = new byte[GlobalWorldTables.ComponentTagTableBufferSize];
            componentTable.AsSpan().Fill(GlobalWorldTables.DefaultNoTag);

            int sizearchetypeTypes = archetypeTypes.Length;
            for (int i = 0; i < sizearchetypeTypes; i++)
            {
                //add 1 so zero is null always
                componentTable[archetypeTypes[i].RawIndex] = (byte) (i + 1);
            }

            int sizearchetypeTags = archetypeTags.Length;
            for (int i = 0; i < sizearchetypeTags; i++)
            {
                componentTable[archetypeTags[i].RawData] |= GlobalWorldTables.HasTagMask;
            }
        }

        /// <summary>
        ///     Gets the hash using the specified types
        /// </summary>
        /// <param name="types">The types</param>
        /// <param name="andMoreTypes">The and more types</param>
        /// <returns>The hash</returns>
        private static long GetHash(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagId> andMoreTypes)
        {
            HashCode h1 = new();
            HashCode h2 = new();

            int i;
            int size = types.Length;
            for (i = 0; i < size >> 1; i++)
            {
                h1.Add(types[i]);
            }


            uint hash1 = 0U;
            uint hash2 = 0U;

            foreach (TagId item in andMoreTypes)
            {
                hash1 ^= item.RawData * 98317U;
                hash2 += item.RawData * 53U;
            }

            h1.Add(HashCode.Combine(hash1, hash2));

            int sizetypes = types.Length;
            for (; i < sizetypes; i++)
            {
                h2.Add(types[i]);
            }

            long hash = (long) h1.ToHashCode() * 1610612741 + h2.ToHashCode();

            return hash;
        }
    }
}