// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:GlobalWorldTables.cs
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
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Memory;

namespace Alis.Core.Ecs.Arch
{
    /// <summary>
    ///     The global world tables class
    /// </summary>
    internal static class GlobalWorldTables
    {
        /// <summary>
        ///     The has tag mask
        /// </summary>
        public const byte HasTagMask = 0b_1000_0000;

        /// <summary>
        ///     The default no tag
        /// </summary>
        public const byte DefaultNoTag = 0b_0000_0000;

        /// <summary>
        ///     The index bits
        /// </summary>
        public const byte IndexBits = 0b_0111_1111;

        /// <summary>
        ///     The mod 16 mask
        /// </summary>
        public const int Mod16Mask = 0xF;

        //we accsess by archetype first because i think we access different comps from the same archetype more
        /// <summary>
        ///     The component tag location table
        /// </summary>
        public static byte[ /*archetype id*/][ /*component id*/] ComponentTagLocationTable = [];

        /// <summary>
        ///     The world
        /// </summary>
        internal static Table<Scene> Worlds = new Table<Scene>(2);

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

            //when adding a component, we only care about changing the length
            if (tableSize == idValue)
            {
                ComponentTagTableBufferSize = Math.Max(tableSize << 1, 1);
                int size = table.Length;
                for (int i = 0; i < size; i++)
                {
                    ref byte[] componentsForArchetype = ref table[i];
                    Array.Resize(ref componentsForArchetype, ComponentTagTableBufferSize);

                    //componentsForArchetype.AsSpan(tableSize).Fill(DefaultNoTag);

                    //update world archetypes
                    foreach (Scene world in worlds)
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
        ///     Components the index using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="component">The component</param>
        /// <returns>The int</returns>
        public static int ComponentIndex(EntityType archetype, ComponentID component) => ComponentTagLocationTable.UnsafeArrayIndex(archetype.RawIndex).UnsafeArrayIndex(component.RawIndex) & IndexBits;

        /// <summary>
        ///     Hases the tag using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        /// <param name="tag">The tag</param>
        /// <returns>The bool</returns>
        public static bool HasTag(EntityType archetype, TagId tag) => (ComponentTagLocationTable.UnsafeArrayIndex(archetype.RawIndex).UnsafeArrayIndex(tag.RawData) & HasTagMask) != 0;
    }
}