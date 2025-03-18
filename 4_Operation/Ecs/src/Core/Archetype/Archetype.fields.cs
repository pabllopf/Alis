using System;
using Frent.Core.Structures;
using Frent.Updating;

namespace Frent.Core;

//38 bytes total - 16 header + mt, 8 comps, 8 create, 8 entities, 6 ids and tracking
/// <summary>
/// The archetype class
/// </summary>
partial class Archetype(ArchetypeID archetypeID, ComponentStorageBase[] components, ComponentStorageBase[] createBuffers)
{
    //8
    /// <summary>
    /// The components
    /// </summary>
    internal readonly ComponentStorageBase[] Components = components;
    //for speeeeeed reasons
    //when creating components during world updates
    //they are added to these arrays
    //these arrays should be heavily pooled to and fro
    /// <summary>
    /// The create buffers
    /// </summary>
    internal readonly ComponentStorageBase[] CreateComponentBuffers = createBuffers;

    //8
    //we include version
    //this is so we dont need to lookup
    //the world table every time
    /// <summary>
    /// The entity id only
    /// </summary>
    private EntityIDOnly[] _entities = new EntityIDOnly[1];

    /// <summary>
    /// The entity id only
    /// </summary>
    private EntityIDOnly[] _createComponentBufferEntities = Array.Empty<EntityIDOnly>();

    //information for tag existence & component index per id
    //updated by static methods
    //saves a lookup on hot paths
    /// <summary>
    /// The raw index
    /// </summary>
    internal byte[] ComponentTagTable = GlobalWorldTables.ComponentTagLocationTable[archetypeID.RawIndex];
    //2
    /// <summary>
    /// The archetype id
    /// </summary>
    private readonly ArchetypeID _archetypeID = archetypeID;
    //4
    /// <summary>
    /// The next component index
    /// </summary>
    private int _nextComponentIndex = 0;
    /// <summary>
    /// The deferred entity count
    /// </summary>
    private int _deferredEntityCount = 0;
}