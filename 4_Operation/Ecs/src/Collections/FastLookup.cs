// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FastLookup.cs
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
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Arch;
#if NET7_0_OR_GREATER
using System.Runtime.Intrinsics;
#endif

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fast lookup
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    internal struct FastLookup()
    {
        /// <summary>
        ///     The data
        /// </summary>
        private InlineArray8<uint> _data;

        /// <summary>
        ///     The ids
        /// </summary>
        private InlineArray8<ushort> _ids;

        /// <summary>
        ///     The archetype
        /// </summary>
        internal Archetype[] Archetypes = new Archetype[8];

        /// <summary>
        ///     The index
        /// </summary>
        private int index;

        /// <summary>
        ///     Finds the adjacent archetype id using the specified id
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="id">The id</param>
        /// <param name="archetype">The archetype</param>
        /// <param name="scene">The world</param>
        /// <param name="edgeType">The edge type</param>
        /// <returns>The entity type</returns>
        
        public ArchetypeID FindAdjacentArchetypeId<T>(T id, EntityType archetype, Scene scene, ArchetypeEdgeType edgeType)
            where T : ITypeID
        {
            uint key = GetKey(id.Value, archetype);
            ArchetypeEdgeKey edgeKey;
            int index = LookupIndex(key);
            if (index != 32)
            {
                return new EntityType(InlineArray8<ushort>.Get(ref _ids, index));
            }

            if (scene.ArchetypeGraphEdges.TryGetValue(edgeKey = typeof(T) == typeof(ComponentID) ? ArchetypeEdgeKey.Component(new(id.Value), archetype, edgeType) : ArchetypeEdgeKey.Tag(new(id.Value), archetype, edgeType), out Archetype destination))
            {
                //warm/cool depending on number of times they add/remove
                return destination.ID;
            }

            //cold path
            Archetype dest = Archetype.GetAdjacentArchetypeCold(scene, edgeKey);
            scene.ArchetypeGraphEdges.Add(edgeKey, dest);
            return dest.ID;
        }

        /// <summary>
        ///     Gets the key using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="archetypeId">The archetype id</param>
        /// <returns>The key</returns>
        public uint GetKey(ushort id, EntityType archetypeId)
        {
            uint key = archetypeId.RawIndex | ((uint) id << 16);
            return key;
        }

        /// <summary>
        ///     Sets the archetype using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="from">The from</param>
        /// <param name="to">The to</param>
        public void SetArchetype(ushort id, EntityType from, Archetype to)
        {
            uint key = GetKey(id, from);

            InlineArray8<uint>.Get(ref _data, index) = key;
            InlineArray8<ushort>.Get(ref _ids, index) = to.ID.RawIndex;

            Archetypes[index] = to;

            index = (index + 1) & 7;
        }

        /// <summary>
        ///     Lookups the index using the specified key
        /// </summary>
        /// <param name="key">The key</param>
        /// <returns>The int</returns>
        public int LookupIndex(uint key)
        {
#if NET6_0_OR_GREATER
            ReadOnlySpan<uint> span = MemoryMarshal.CreateReadOnlySpan(ref _data._0, 8);
            for (int i = 0; i < span.Length; i++)
            {
                if (span[i] == key)
                    return i;
            }
            return 32;
#else
            if (_data._0 == key)
            {
                return 0;
            }

            if (_data._1 == key)
            {
                return 1;
            }

            if (_data._2 == key)
            {
                return 2;
            }

            if (_data._3 == key)
            {
                return 3;
            }

            if (_data._4 == key)
            {
                return 4;
            }

            if (_data._5 == key)
            {
                return 5;
            }

            if (_data._6 == key)
            {
                return 6;
            }

            if (_data._7 == key)
            {
                return 7;
            }

            return 32;
#endif
        }
    }
}