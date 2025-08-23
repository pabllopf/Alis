using System;
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
        ///     Deferred gameObject count is the total number of deferred entities, some of which may be stored directly on the normal
        ///     archetype.
        /// </remarks>
        private int _nextComponentIndexOrDeferredEntityCount;

#if DEBUG
    private ref int NextComponentIndex
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        get { return ref _nextComponentIndexOrDeferredEntityCount; }
    }

    private ref int DeferredEntityCount
    {
        [System.Runtime.CompilerServices.MethodImpl(System.Runtime.CompilerServices.MethodImplOptions.AggressiveInlining)]
        get { return ref _nextComponentIndexOrDeferredEntityCount; }
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