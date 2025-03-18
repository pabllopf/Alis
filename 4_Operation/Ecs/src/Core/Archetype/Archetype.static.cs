using System;
using System.Collections.Generic;
using Frent.Collections;
using Frent.Core.Structures;
using Frent.Updating;

using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Core;





/// <summary>
/// The archetype class
/// </summary>
internal static class Archetype<T>
{
    /// <summary>
    /// The to immutable array
    /// </summary>
    public static readonly ImmutableArray<ComponentID> ArchetypeComponentIDs = new ComponentID[] { Component<T>.ID }.ToImmutableArray();

    //ArchetypeTypes init first, then ID
    /// <summary>
    /// The empty
    /// </summary>
    public static readonly ArchetypeID ID = Archetype.GetArchetypeID(ArchetypeComponentIDs.AsSpan(), [], ArchetypeComponentIDs, ImmutableArray<TagID>.Empty);

    /// <summary>
    /// Creates the new or get existing archetype using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <returns>The archetype</returns>
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

    /// <summary>
    /// The of component class
    /// </summary>
    internal static class OfComponent<C>
    {
        /// <summary>
        /// The id
        /// </summary>
        public static readonly int Index = GlobalWorldTables.ComponentIndex(ID, Component<C>.ID);
    }
}

/// <summary>
/// The archetype class
/// </summary>
partial class Archetype
{
    /// <summary>
    /// The null
    /// </summary>
    internal static readonly ArchetypeID Null;
    /// <summary>
    /// The deferred create
    /// </summary>
    internal static readonly ArchetypeID DeferredCreate;
    /// <summary>
    /// The create
    /// </summary>
    internal static FastStack<ArchetypeData> ArchetypeTable = FastStack<ArchetypeData>.Create(16);
    /// <summary>
    /// The next archetype id
    /// </summary>
    internal static int NextArchetypeID = -1;

    /// <summary>
    /// The existing archetypes
    /// </summary>
    private static readonly Dictionary<long, ArchetypeData> ExistingArchetypes = [];

    /// <summary>
    /// Creates the or get existing archetype using the specified types
    /// </summary>
    /// <param name="types">The types</param>
    /// <param name="tagTypes">The tag types</param>
    /// <param name="world">The world</param>
    /// <param name="typeArray">The type array</param>
    /// <param name="tagTypesArray">The tag types array</param>
    /// <returns>The archetype</returns>
    internal static Archetype CreateOrGetExistingArchetype(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagID> tagTypes, World world, ImmutableArray<ComponentID>? typeArray = null, ImmutableArray<TagID>? tagTypesArray = null)
    {
        ArchetypeID id = GetArchetypeID(types, tagTypes, typeArray, tagTypesArray);
        return CreateOrGetExistingArchetype(id, world);
    }

    /// <summary>
    /// Creates the or get existing archetype using the specified id
    /// </summary>
    /// <param name="id">The id</param>
    /// <param name="world">The world</param>
    /// <returns>The archetype</returns>
    internal static Archetype CreateOrGetExistingArchetype(ArchetypeID id, World world)
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

    /// <summary>
    /// Gets the adjacent archetype cold using the specified world
    /// </summary>
    /// <param name="world">The world</param>
    /// <param name="edge">The edge</param>
    /// <returns>The archetype</returns>
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

    /// <summary>
    /// Initializes a new instance of the <see cref="Archetype"/> class
    /// </summary>
    static Archetype()
    {
        Null = GetArchetypeID([Component.GetComponentID(typeof(void))], [Tag.GetTagID(typeof(Disable))]);
        //this archetype exists only so that "EntityLocation"s of deferred archetypes have something to point to
        //disable so less overhead
        DeferredCreate = GetArchetypeID([], [Tag.GetTagID(typeof(DeferredCreate)), Tag.GetTagID(typeof(Disable))]);
    }

    /// <summary>
    /// Gets the archetype id using the specified types
    /// </summary>
    /// <param name="types">The types</param>
    /// <param name="tagTypes">The tag types</param>
    /// <param name="typesArray">The types array</param>
    /// <param name="tagTypesArray">The tag types array</param>
    /// <exception cref="InvalidOperationException">Entities can have a max of 127 components!</exception>
    /// <exception cref="InvalidOperationException">Exceeded maximum unique archetype count of 65535</exception>
    /// <returns>The archetype id</returns>
    internal static ArchetypeID GetArchetypeID(ReadOnlySpan<ComponentID> types, ReadOnlySpan<TagID> tagTypes, ImmutableArray<ComponentID>? typesArray = null, ImmutableArray<TagID>? tagTypesArray = null)
    {
        if (types.Length > MemoryHelpers.MaxComponentCount)
            throw new InvalidOperationException("Entities can have a max of 127 components!");
        lock (GlobalWorldTables.BufferChangeLock)
        {
            var key = GetHash(types, tagTypes);
            if (ExistingArchetypes.TryGetValue(key, out ArchetypeData value))
            {
                return value.ID;
            }

            int nextIDInt = ++NextArchetypeID;
            if (nextIDInt == ushort.MaxValue)
                throw new InvalidOperationException($"Exceeded maximum unique archetype count of 65535");
            var finalID = new ArchetypeID((ushort)nextIDInt);

            var arr = typesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(types);
            var tagArr = tagTypesArray ?? MemoryHelpers.ReadOnlySpanToImmutableArray(tagTypes);

            var slot = new ArchetypeData(finalID, arr, tagArr);
            ArchetypeTable.Push(slot);
            ModifyComponentLocationTable(arr, tagArr, finalID.RawIndex);

            ExistingArchetypes[key] = slot;


            return finalID;
        }
    }

    /// <summary>
    /// Modifies the component location table using the specified archetype types
    /// </summary>
    /// <param name="archetypeTypes">The archetype types</param>
    /// <param name="archetypeTags">The archetype tags</param>
    /// <param name="id">The id</param>
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

    /// <summary>
    /// Gets the hash using the specified types
    /// </summary>
    /// <param name="types">The types</param>
    /// <param name="andMoreTypes">The and more types</param>
    /// <returns>The hash</returns>
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
