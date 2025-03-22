﻿using System;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs.Core.Archetype
{
    //38 bytes total - 16 header + mt, 8 comps, 8 create, 8 entities, 6 ids and tracking
    partial class Archetype(EntityType archetypeID, ComponentStorageBase[] components, ComponentStorageBase[] createBuffers)
    {
        //8
        internal readonly ComponentStorageBase[] Components = components;
        //for speeeeeed reasons
        //when creating components during world updates
        //they are added to these arrays
        //these arrays should be heavily pooled to and fro
        internal readonly ComponentStorageBase[] CreateComponentBuffers = createBuffers;

        //8
        //we include version
        //this is so we dont need to lookup
        //the world table every time
        private EntityIDOnly[] _entities = new EntityIDOnly[1];

        private EntityIDOnly[] _createComponentBufferEntities = Array.Empty<EntityIDOnly>();

        //information for tag existence & component index per id
        //updated by static methods
        //saves a lookup on hot paths
        internal byte[] ComponentTagTable = GlobalWorldTables.ComponentTagLocationTable[archetypeID.RawIndex];
        //2
        private readonly EntityType _archetypeID = archetypeID;
        //4
        /// <summary>
        /// The next component index
        /// </summary>
        private int _nextComponentIndex = 0;
        private int _deferredEntityCount = 0;
    }
}