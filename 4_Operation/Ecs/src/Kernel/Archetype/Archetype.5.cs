using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel.Archetype
{
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
                { Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id });

        //ArchetypeTypes init first, then ID
        /// <summary>
        ///     The empty
        /// </summary>
        public static readonly GameObjectType Id = Archetype.GetArchetypeId(ArchetypeComponentIDs.AsSpan(), [],
            ArchetypeComponentIDs, FastImmutableArray<TagId>.Empty);

        /// <summary>
        ///     Creates the new or get existing archetypes using the specified scene
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <returns>The archetypes</returns>
        internal static WorldArchetypeTableItem CreateNewOrGetExistingArchetypes(Scene scene)
        {
            ushort index = Id.RawIndex;
            ref WorldArchetypeTableItem archetypes = ref scene.WorldArchetypeTable.UnsafeArrayIndex(index);
            if (archetypes.Archetype is null) archetypes = CreateArchetypes(scene);
            return archetypes;

            //this method is literally only called once per scene
            [MethodImpl(MethodImplOptions.NoInlining)]
            static WorldArchetypeTableItem CreateArchetypes(Scene scene)
            {
                ComponentStorageBase[] runners = new ComponentStorageBase[ArchetypeComponentIDs.Length + 1];
                ComponentStorageBase[] tmpStorages = new ComponentStorageBase[runners.Length];
                byte[] map = GlobalWorldTables.ComponentTagLocationTable[Id.RawIndex];

                int i;

                i = map.UnsafeArrayIndex(Component<T1>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T1>.CreateInstance(1);
                tmpStorages[i] = Component<T1>.CreateInstance(0);
                i = map.UnsafeArrayIndex(Component<T2>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T2>.CreateInstance(1);
                tmpStorages[i] = Component<T2>.CreateInstance(0);
                i = map.UnsafeArrayIndex(Component<T3>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T3>.CreateInstance(1);
                tmpStorages[i] = Component<T3>.CreateInstance(0);
                i = map.UnsafeArrayIndex(Component<T4>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T4>.CreateInstance(1);
                tmpStorages[i] = Component<T4>.CreateInstance(0);
                i = map.UnsafeArrayIndex(Component<T5>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T5>.CreateInstance(1);
                tmpStorages[i] = Component<T5>.CreateInstance(0);


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
}