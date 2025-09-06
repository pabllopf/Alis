// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Archetype.fields.cs
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
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    //46 bytes total - 16 header + mt, 8 comps, 8 entities, 8 table, 6 ids and tracking
    /// <summary>
    ///     The archetype class
    /// </summary>
    partial class Archetype(GameObjectType archetypeId, ComponentStorageBase[] components, bool isTempCreateArchetype)
    {
        //8
        /// <summary>
        ///     The components
        /// </summary>
        internal readonly ComponentStorageBase[] Components = components;

        //8
        //we include version
        //this is so we dont need to lookup
        //the scene table every time
        /// <summary>
        ///     The gameObject id only
        /// </summary>
        private GameObjectIdOnly[] _entities = isTempCreateArchetype ? Array.Empty<GameObjectIdOnly>() : new GameObjectIdOnly[1];

        //8
        //information for tag existence & component index per id
        //updated by static methods
        //saves a lookup on hot paths
        /// <summary>
        ///     The raw index
        /// </summary>
        internal byte[] ComponentTagTable = GlobalWorldTables.ComponentTagLocationTable[archetypeId.RawIndex];

        //2
        /// <summary>
        ///     The archetype id
        /// </summary>
        private readonly GameObjectType _archetypeId = archetypeId;

        //4
        /// <summary>
        ///     The next component index or deferred gameObject count
        /// </summary>
        /// <remarks>
        ///     You can think of this as a discrimminated union. Next component index is the non-deferred count of a normal
        ///     archetype.
        ///     Deferred gameObject count is the total number of deferred entities, some of which may be stored directly on the
        ///     normal
        ///     archetype.
        /// </remarks>
        private int _nextComponentIndexOrDeferredEntityCount;

#if DEBUG
        private ref int NextComponentIndex
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _nextComponentIndexOrDeferredEntityCount;
        }

        private ref int DeferredEntityCount
        {
            [MethodImpl(MethodImplOptions.AggressiveInlining)]
            get => ref _nextComponentIndexOrDeferredEntityCount;
        }

        private readonly bool _isTempCreationArchetype = isTempCreateArchetype;
#else
        /// <summary>
        ///     Gets the value of the next component index
        /// </summary>
        private ref int NextComponentIndex => ref _nextComponentIndexOrDeferredEntityCount;

        /// <summary>
        ///     Gets the value of the deferred gameObject count
        /// </summary>
        private ref int DeferredEntityCount => ref _nextComponentIndexOrDeferredEntityCount;
#endif
    }
}