using System;
using Frent.Collections;

namespace Frent.Core.Structures
{
    /// <summary>
    /// The global world tables class
    /// </summary>
    internal static class GlobalWorldTables
    {
        //we accsess by archetype first because i think we access different comps from the same archetype more
        /// <summary>
        /// The component tag location table
        /// </summary>
        public static byte[/*archetype id*/][/*component id*/] ComponentTagLocationTable = [];
        /// <summary>
        /// Gets or sets the value of the component tag table buffer size
        /// </summary>
        internal static int ComponentTagTableBufferSize { get; set; }//reps the length of the second dimension
        /// <summary>
        /// The world
        /// </summary>
        internal static Table<World> Worlds = new Table<World>(2);

        /// <summary>
        /// The buffer change lock
        /// </summary>
        internal static readonly object BufferChangeLock = new object();

        //each byte contains the data as follows:
        // 1 bit Tag exists -> Lookup by tag ID
        // 3 bits - nothing
        // 4 bits - index of component (1111) -> Lookup by component ID

        /// <summary>
        /// The has tag mask
        /// </summary>
        public const byte HasTagMask = 0b_1000_0000;
        /// <summary>
        /// The default no tag
        /// </summary>
        public const byte DefaultNoTag = 0b_0000_0000;
        /// <summary>
        /// The index bits
        /// </summary>
        public const byte IndexBits = 0b_0111_1111;
        /// <summary>
        /// The mod 16 mask
        /// </summary>
        public const int Mod16Mask = 0xF;

        /// <summary>
        /// Grows the component tag table if needed using the specified id value
        /// </summary>
        /// <param name="idValue">The id value</param>
        internal static void GrowComponentTagTableIfNeeded(int idValue)
        {
            byte[][]? table = ComponentTagLocationTable;
            int tableSize = ComponentTagTableBufferSize;
            Span<World> worlds = Worlds.AsSpan();

            //when adding a component, we only care about changing the length
            if (tableSize == idValue)
            {
                ComponentTagTableBufferSize = Math.Max(tableSize << 1, 1);
                for (int i = 0; i < table.Length; i++)
                {
                    ref byte[]? componentsForArchetype = ref table[i];
                    Array.Resize(ref componentsForArchetype, ComponentTagTableBufferSize);

                    //componentsForArchetype.AsSpan(tableSize).Fill(DefaultNoTag);

                    //update world archetypes
                    foreach (World? world in worlds)
                    {
                        if (world is not null && world.WorldArchetypeTable[i] is Archetype archetype)
                        {
                            archetype.ComponentTagTable = componentsForArchetype;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Components the index using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        public static int ComponentIndex(ArchetypeID archetype, ComponentID component) => ComponentTagLocationTable.UnsafeArrayIndex(archetype.RawIndex).UnsafeArrayIndex(component.RawIndex) & IndexBits;
        /// <summary>
        /// Hases the tag using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="tag">The tag</param>
        /// <returns>The bool</returns>
        public static bool HasTag(ArchetypeID archetype, TagID tag) => (ComponentTagLocationTable.UnsafeArrayIndex(archetype.RawIndex).UnsafeArrayIndex(tag.RawValue) & HasTagMask) != 0;
    }
}