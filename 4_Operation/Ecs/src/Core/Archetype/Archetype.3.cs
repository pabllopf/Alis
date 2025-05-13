using System.Collections.Immutable;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype;
    internal static class Archetype<T1, T2, T3>
    {
        public static readonly ImmutableArray<ComponentID> ArchetypeComponentIDs = new ComponentID[] { Component<T1>.ID, Component<T2>.ID, Component<T3>.ID }.ToImmutableArray();

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
