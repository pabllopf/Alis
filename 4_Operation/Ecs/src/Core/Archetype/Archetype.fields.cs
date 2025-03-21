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
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    //38 bytes total - 16 header + mt, 8 comps, 8 create, 8 entities, 6 ids and tracking
    /// <summary>
    ///     The archetype class
    /// </summary>
    internal partial class Archetype(EntityType archetypeID, ComponentStorageBase[] components, ComponentStorageBase[] createBuffers)
    {
        //2
        /// <summary>
        ///     The archetype id
        /// </summary>
        private readonly EntityType _archetypeID = archetypeID;

        //8
        /// <summary>
        ///     The components
        /// </summary>
        internal readonly ComponentStorageBase[] Components = components;

        //for speeeeeed reasons
        //when creating components during world updates
        //they are added to these arrays
        //these arrays should be heavily pooled to and fro
        /// <summary>
        ///     The create buffers
        /// </summary>
        internal readonly ComponentStorageBase[] CreateComponentBuffers = createBuffers;

        /// <summary>
        ///     The entity id only
        /// </summary>
        private EntityIDOnly[] _createComponentBufferEntities = Array.Empty<EntityIDOnly>();

        /// <summary>
        ///     The deferred entity count
        /// </summary>
        private int _deferredEntityCount;

        //8
        //we include version
        //this is so we dont need to lookup
        //the world table every time
        /// <summary>
        ///     The entity id only
        /// </summary>
        private EntityIDOnly[] _entities = new EntityIDOnly[1];

        //4
        /// <summary>
        ///     The next component index
        /// </summary>
        private int _nextComponentIndex;

        //information for tag existence & component index per id
        //updated by static methods
        //saves a lookup on hot paths
        /// <summary>
        ///     The raw index
        /// </summary>
        internal byte[] ComponentTagTable = GlobalWorldTables.ComponentTagLocationTable[archetypeID.RawIndex];
    }
}