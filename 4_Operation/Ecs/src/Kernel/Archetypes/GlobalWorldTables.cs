

using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Collections;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The global scene tables class
    /// </summary>
    internal static class GlobalWorldTables
    {
        /// <summary>
        ///     The index bits
        /// </summary>
        public const byte IndexBits = 0b_0111_1111;

        /// <summary>
        ///     The mod 16 mask
        /// </summary>
        public const int Mod16Mask = 0xF;

        /// <summary>
        ///     The component tag location table
        /// </summary>
        public static byte[ /*archetype id*/][ /*component id*/] ComponentTagLocationTable = [];

        /// <summary>
        ///     The scene
        /// </summary>
        internal static FastestTable<Scene> Worlds = new FastestTable<Scene>(2);

        /// <summary>
        ///     The buffer change lock
        /// </summary>
        internal static readonly object BufferChangeLock = new object();

        /// <summary>
        ///     Gets or sets the value of the component tag table buffer size
        /// </summary>
        internal static int ComponentTagTableBufferSize { get; set; } //reps the length of the second dimension

        /// <summary>
        ///     Grows the component tag table if needed using the specified id value
        /// </summary>
        /// <param name="idValue">The id value</param>
        internal static void GrowComponentTagTableIfNeeded(int idValue)
        {
            byte[][] table = ComponentTagLocationTable;
            int tableSize = ComponentTagTableBufferSize;
            Span<Scene> worlds = Worlds.AsSpan();

            if (tableSize == idValue)
            {
                ComponentTagTableBufferSize = Math.Max(tableSize << 1, 1);
                for (int i = 0; i < table.Length; i++)
                {
                    ref byte[] componentsForArchetype = ref table[i];
                    Array.Resize(ref componentsForArchetype, ComponentTagTableBufferSize);

                    //componentsForArchetype.AsSpan(tableSize).Fill(DefaultNoTag);

                    foreach (Scene world in worlds)
                    {
                        if (world is not null)
                        {
                            ref WorldArchetypeTableItem tableItem = ref world.WorldArchetypeTable[i];
                            if (tableItem.Archetype is not null)
                            {
                                tableItem.Archetype.ComponentTagTable = componentsForArchetype;
                                tableItem.DeferredCreationArchetype.ComponentTagTable = componentsForArchetype;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Components the index using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        public static int ComponentIndex(GameObjectType archetype, ComponentId component) => Unsafe.Add(ref ComponentTagLocationTable[archetype.RawIndex][0], component.RawIndex) & IndexBits;

        /// <summary>
        ///     Hases the archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <returns>The bool</returns>
        public static bool Has(GameObjectType archetype) => ComponentTagLocationTable[archetype.RawIndex][0] != 0;
    }
}