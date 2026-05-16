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

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Collections
{
    /// <summary>
    ///     The fast lookup
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Archetype array reference (8 bytes) -> InlineArray8 structs (32 bytes + 16 bytes) -> int
    ///     (4 bytes)
    ///     Total: 60 bytes
    ///     Pack = 8 for optimal alignment with reference types and large inline arrays
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct FastLookup()
    {
        /// <summary>
        ///     The archetype
        /// </summary>
        internal Archetype[] Archetypes = new Archetype[8];

        /// <summary>
        ///     The data
        /// </summary>
        internal InlineArray8<uint> _data;

        /// <summary>
        ///     The ids
        /// </summary>
        internal InlineArray8<ushort> _ids;


        /// <summary>
        ///     The index
        /// </summary>
        internal int index;

        /// <summary>
        ///     Finds the adjacent archetype id using the specified id
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="id">The id</param>
        /// <param name="archetype">The archetype</param>
        /// <param name="scene">The scene</param>
        /// <param name="edgeType">The edge type</param>
        /// <returns>The archetype id</returns>
        public ArchetypeID FindAdjacentArchetypeId<T>(T id, GameObjectType archetype, Scene scene, ArchetypeEdgeType edgeType)
            where T : ITypeId
        {
            uint key = GetKey(id.Value, archetype);
            ArchetypeEdgeKey edgeKey;
            int index = LookupIndex(key);
            if (index != 32)
            {
                return new GameObjectType(InlineArray8<ushort>.Get(ref _ids, index));
            }

            if (scene.ArchetypeGraphEdges.TryGetValue(
                    edgeKey = ArchetypeEdgeKey.Component(new(id.Value), archetype, edgeType), out Archetype destination))
                //warm/cool depending on number of times they add/remove
            {
                return destination.Id;
            }

            //cold path
            Archetype dest = Archetype.GetAdjacentArchetypeCold(scene, edgeKey);
            scene.ArchetypeGraphEdges.Add(edgeKey, dest);
            return dest.Id;
        }

        /// <summary>
        ///     Gets the key using the specified id
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="archetypeId">The archetype id</param>
        /// <returns>The key</returns>
        public static uint GetKey(ushort id, GameObjectType archetypeId)
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
        public void SetArchetype(ushort id, GameObjectType from, Archetype to)
        {
            uint key = GetKey(id, from);

            InlineArray8<uint>.Get(ref _data, index) = key;
            InlineArray8<ushort>.Get(ref _ids, index) = to.Id.RawIndex;

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
        }
    }
}