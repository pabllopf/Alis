using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype;
    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12, T13>
    {
        public static readonly ImmutableArray<ComponentID> ArchetypeComponentIDs = new ComponentID[] { Component<T1>.ID, Component<T2>.ID, Component<T3>.ID, Component<T4>.ID, Component<T5>.ID, Component<T6>.ID, Component<T7>.ID, Component<T8>.ID, Component<T9>.ID, Component<T10>.ID, Component<T11>.ID, Component<T12>.ID, Component<T13>.ID }.ToImmutableArray();

        //ArchetypeTypes init first, then ID
        public static readonly ArchetypeID ID = Archetype.GetArchetypeID(ArchetypeComponentIDs.AsSpan(), [], ArchetypeComponentIDs, ImmutableArray<TagID>.Empty);

        internal static World.WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(World world)
        {
            var index = ID.RawIndex;
            ref World.WorldArchetypeTableItem archetypes = ref world.WorldArchetypeTable.UnsafeArrayIndex(index);
            if(archetypes.Archetype is null)
            {
                archetypes = CreateArchetypes(world);
            }
            return archetypes;

            //this method is literally only called once per world
            [MethodImpl(MethodImplOptions.NoInlining)]
            static World.WorldArchetypeTableItem CreateArchetypes(World world)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[ID.RawIndex];

                int i;

                i = map.UnsafeArrayIndex(Component<T1>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T1>.CreateInstance(1); tmpStorages[i] = Component<T1>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T2>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T2>.CreateInstance(1); tmpStorages[i] = Component<T2>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T3>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T3>.CreateInstance(1); tmpStorages[i] = Component<T3>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T4>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T4>.CreateInstance(1); tmpStorages[i] = Component<T4>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T5>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T5>.CreateInstance(1); tmpStorages[i] = Component<T5>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T6>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T6>.CreateInstance(1); tmpStorages[i] = Component<T6>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T7>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T7>.CreateInstance(1); tmpStorages[i] = Component<T7>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T8>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T8>.CreateInstance(1); tmpStorages[i] = Component<T8>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T9>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T9>.CreateInstance(1); tmpStorages[i] = Component<T9>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T10>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T10>.CreateInstance(1); tmpStorages[i] = Component<T10>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T11>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T11>.CreateInstance(1); tmpStorages[i] = Component<T11>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T12>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T12>.CreateInstance(1); tmpStorages[i] = Component<T12>.CreateInstance(0);
            i = map.UnsafeArrayIndex(Component<T13>.ID.RawIndex) & GlobalWorldTables.IndexBits; runners[i] = Component<T13>.CreateInstance(1); tmpStorages[i] = Component<T13>.CreateInstance(0);


                Archetype archetype = new Archetype(ID, runners, false);
                Archetype tempCreateArchetype = new Archetype(ID, tmpStorages, true);

                world.ArchetypeAdded(archetype, tempCreateArchetype);
                return new World.WorldArchetypeTableItem(archetype, tempCreateArchetype);
            }
        }

        internal static class OfComponent<C>
        {
            public static readonly int Index = GlobalWorldTables.ComponentIndex(ID, Component<C>.ID);
        }
    }
