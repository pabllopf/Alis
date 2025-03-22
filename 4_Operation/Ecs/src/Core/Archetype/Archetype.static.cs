﻿using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    internal static class Archetype<T>
    {
        public static readonly ImmutableArray<ComponentID> ArchetypeComponentIDs = new ComponentID[] { Component<T>.ID }.ToImmutableArray();

        //ArchetypeTypes init first, then ID
        public static readonly EntityType ID = Archetype.GetArchetypeID(ArchetypeComponentIDs.AsSpan(), [], ArchetypeComponentIDs, ImmutableArray<TagID>.Empty);

        internal static Archetype CreateNewOrGetExistingArchetype(World world)
        {
            var index = ID.RawIndex;
            ref Archetype archetype = ref world.WorldArchetypeTable.UnsafeArrayIndex(index);
            archetype ??= CreateArchetype(world);
            return archetype!;

            //this method is literally only called once per world
            [MethodImpl(MethodImplOptions.NoInlining)]
            static Archetype CreateArchetype(World world)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[ID.RawIndex];

                int i;

                i = map.UnsafeArrayIndex(Component<T>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T>.CreateInstance(1); tmpStorages[i] = Component<T>.CreateInstance(0);

                Archetype archetype = new Archetype(ID, runners, tmpStorages);

                world.ArchetypeAdded(archetype);
                return archetype;
            }
        }

        internal static class OfComponent<C>
        {
            public static readonly int Index = GlobalWorldTables.ComponentIndex(ID, Component<C>.ID);
        }
    }

    partial class Archetype
    {
        internal static readonly EntityType Null;
        internal static readonly EntityType DeferredCreate;
        internal static FastStack<ArchetypeData> ArchetypeTable = FastStack<ArchetypeData>.Create(16);
        internal static int NextArchetypeID = -1;

        private static readonly Dictionary<long, ArchetypeData> ExistingArchetypes = [];

        internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagID> tagTypes, World world, ImmutableArray<ComponentID>? typeArray = null, ImmutableArray<TagID>? tagTypesArray = null)
        {
            EntityType id = GetArchetypeID(types, tagTypes, typeArray, tagTypesArray);
            return CreateOrGetExistingArchetype(id, world);
        }

        internal static Archetype CreateOrGetExistingArchetype(EntityType id, World world)
        {
            ref Archetype archetype = ref world.WorldArchetypeTable[id.RawIndex];
            if (archetype is not null)
                return archetype;

            var types = id.Types;
            ComponentStorageBase[] componentRunners = new ComponentStorageBase[types.Length + 1];
            ComponentStorageBase[] tmpRunners = new ComponentStorageBase[types.Length + 1];
            for (int i = 1; i < componentRunners.Length; i++)
            {
                var fact = Component.GetComponentFactoryFromType(types[i - 1].Type);
                componentRunners[i] = fact.Create(1);
                tmpRunners[i] = fact.Create(0);
            }

            archetype = new Archetype(id, componentRunners, tmpRunners);
            world.ArchetypeAdded(archetype);

            return archetype;
        }

        internal static Archetype GetAdjacentArchetypeCold(World world, ArchetypeEdgeKey edge)
        {
            //this world doesn't have the archetype, or it doesnt even exist

            Archetype from = edge.ArchetypeFrom.Archetype(world);
            ImmutableArray<ComponentID> fromComponents = edge.ArchetypeFrom.Types;
            ImmutableArray<TagID> fromTags = edge.ArchetypeFrom.Tags;

            switch (edge.EdgeType)
            {
                case ArchetypeEdgeType.AddComponent:
                    fromComponents = MemoryHelpers.Concat(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.RemoveComponent:
                    fromComponents = MemoryHelpers.Remove(fromComponents, edge.ComponentID);
                    break;
                case ArchetypeEdgeType.AddTag:
                    fromTags = MemoryHelpers.Concat(fromTags, edge.TagID);
                    break;
                case ArchetypeEdgeType.RemoveTag:
                    fromTags = MemoryHelpers.Remove(fromTags, edge.TagID);
                    break;
            }

            var archetype = CreateOrGetExistingArchetype(fromComponents.AsSpan(), fromTags.AsSpan(), world, fromComponents, fromTags);

            return archetype;
        }

        static Archetype()
        {
            Null = GetArchetypeID([Component.GetComponentID(typeof(void))], [Tag.GetTagID(typeof(Disable))]);
            //this archetype exists only so that "EntityLocation"s of deferred archetypes have something to point to
            //disable so less overhead
            DeferredCreate = GetArchetypeID([], [Tag.GetTagID(typeof(DeferredCreate)), Tag.GetTagID(typeof(Disable))]);
        }

        internal static EntityType GetArchetypeID(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagID> tagTypes, ImmutableArray<ComponentID>? typesArray = null, ImmutableArray<TagID>? tagTypesArray = null)
        {
            if (types.Length > MemoryHelpers.MaxComponentCount)
                throw new InvalidOperationException("Entities can have a max of 127 components!");
            lock (GlobalWorldTables.BufferChangeLock)
            {
#if NETSTANDARD2_1
            var key = GetHash(types, tagTypes);
            if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value))
            {
                return value.ID;
            }

            int nextIDInt = ++NextArchetypeID;
            if (nextIDInt == ushort.MaxValue)
                throw new InvalidOperationException($"Exceeded maximum unique archetype count of 65535");
            var finalID = new EntityType((ushort)nextIDInt);

            var arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);
            var tagArr = tagTypesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(tagTypes);

            var slot = new ArchetypeData(finalID, arr, tagArr);
            ArchetypeTable.Push(slot);
            ModifyComponentLocationTable(arr, tagArr, finalID.RawIndex);

            ExistingArchetypes[key] = slot;
#else
                ref ArchetypeData slot = ref CollectionsMarshal.GetValueRefOrAddDefault(ExistingArchetypes, GetHash(types, tagTypes), out bool exists);
                ArchetypeID finalID;

                if (exists)
                {
                    //can't be null if entry exists
                    finalID = slot!.ID;
                }
                else
                {
                    int nextIDInt = ++NextArchetypeID;
                    if (nextIDInt == ushort.MaxValue)
                        throw new InvalidOperationException($"Exceeded maximum unique archetype count of 65535");
                    finalID = new ArchetypeID((ushort)nextIDInt);

                    var arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);
                    var tagArr = tagTypesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(tagTypes);

                    slot = new ArchetypeData(finalID, arr, tagArr);
                    ArchetypeTable.Push(slot);
                    ModifyComponentLocationTable(arr, tagArr, finalID.RawIndex);
                }
#endif

                return finalID;
            }
        }

        private static void ModifyComponentLocationTable(ImmutableArray<ComponentID> archetypeTypes, ImmutableArray<TagID> archetypeTags, int id)
        {
            if (GlobalWorldTables.ComponentTagLocationTable.Length == id)
            {
                int size = Math.Max(id << 1, 1);
                Array.Resize(ref GlobalWorldTables.ComponentTagLocationTable, size);
                foreach (var world in GlobalWorldTables.Worlds.AsSpan())
                {
                    if (world is World w)
                    {
                        w.UpdateArchetypeTable(size);
                    }
                }
            }

            //for (int i = 0; i < archetypeTypes.Length; i++)
            //{
            //    _ = Component.GetComponentID(archetypeTypes[i].Type);
            //}

            ref var componentTable = ref GlobalWorldTables.ComponentTagLocationTable[id];
            componentTable = new byte[GlobalWorldTables.ComponentTagTableBufferSize];
            componentTable.AsSpan().Fill(GlobalWorldTables.DefaultNoTag);

            for (int i = 0; i < archetypeTypes.Length; i++)
            {
                //add 1 so zero is null always
                componentTable[archetypeTypes[i].RawIndex] = (byte)(i + 1);
            }

            for (int i = 0; i < archetypeTags.Length; i++)
            {
                componentTable[archetypeTags[i].RawValue] |= GlobalWorldTables.HasTagMask;
            }
        }

        private static long GetHash(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagID> andMoreTypes)
        {
            HashCode h1 = new();
            HashCode h2 = new();

            int i;
            for (i = 0; i < types.Length >> 1; i++)
            {
                h1.Add(types[i]);
            }


            var hash1 = 0U;
            var hash2 = 0U;

            foreach (var item in andMoreTypes)
            {
                hash1 ^= item.RawValue * 98317U;
                hash2 += item.RawValue * 53U;
            }

            h1.Add(HashCode.Combine(hash1, hash2));

            for (; i < types.Length; i++)
            {
                h2.Add(types[i]);
            }

            var hash = ((long)h1.ToHashCode() * 1610612741) + h2.ToHashCode();

            return hash;
        }
    }
}
