using System.Runtime.CompilerServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Redifinition;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel.Archetype
{
    /// <summary>
    ///     The archetype class
    /// </summary>
    internal static class Archetype<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
        /// <summary>
        ///     The to immutable array
        /// </summary>
        public static readonly FastImmutableArray<ComponentId> ArchetypeComponentIDs = new FastImmutableArray<ComponentId>(
            new[]
            {
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id, Component<T6>.Id,
                Component<T7>.Id, Component<T8>.Id, Component<T9>.Id, Component<T10>.Id, Component<T11>.Id
            });

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
            ref WorldArchetypeTableItem archetypes = ref Unsafe.Add(ref scene.WorldArchetypeTable[0], index);
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
                i = Unsafe.Add(ref map[0], Component<T9>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T9>.CreateInstance(1);
                tmpStorages[i] = Component<T9>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T10>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T10>.CreateInstance(1);
                tmpStorages[i] = Component<T10>.CreateInstance(0);
                i = Unsafe.Add(ref map[0], Component<T11>.Id.RawIndex) & GlobalWorldTables.IndexBits;
                runners[i] = Component<T11>.CreateInstance(1);
                tmpStorages[i] = Component<T11>.CreateInstance(0);


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