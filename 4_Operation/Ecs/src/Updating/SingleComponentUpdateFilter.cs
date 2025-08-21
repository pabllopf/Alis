using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The single component update filter class
    /// </summary>
    /// <seealso cref="IComponentUpdateFilter" />
    public class SingleComponentUpdateFilter : IComponentUpdateFilter
    {
        /// <summary>
        ///     The component id
        /// </summary>
        private readonly ComponentId _componentId;

        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private (Archetype Archetype, ComponentStorageBase Storage)[] _archetypes = [];

        /// <summary>
        ///     The count
        /// </summary>
        private int _count;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SingleComponentUpdateFilter" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="component">The component</param>
        public SingleComponentUpdateFilter(Scene scene, ComponentId component)
        {
            _scene = scene;
            _componentId = component;

            foreach (GameObjectType archetype in scene.EnabledArchetypes.AsSpan())
            {
                ArchetypeAdded(archetype.Archetype(scene)!);
            }
        }

        /// <summary>
        ///     Updates the subset using the specified archetypes
        /// </summary>
        /// <param name="archetypes">The archetypes</param>
        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
        {
            Scene scene = _scene;
            foreach ((Archetype archetype, _, int initalEntityCount) in archetypes)
            {
                int componentIndex = archetype.GetComponentIndex(_componentId);
                if (componentIndex != 0)
                    //this archetype has this component type
                    archetype.Components[componentIndex].Run(scene, archetype, initalEntityCount,
                        archetype.EntityCount - initalEntityCount);
            }
        }


        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            Scene scene = _scene;
            foreach ((Archetype archetype, ComponentStorageBase storage) in _archetypes.AsSpan(0, _count))
            {
                storage.Run(scene, archetype);
            }
        }

        /// <summary>
        ///     Archetypes the added using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        public void ArchetypeAdded(Archetype archetype)
        {
            int index = archetype.GetComponentIndex(_componentId);
            if (index != 0)
                MemoryHelpers.GetValueOrResize(ref _archetypes, _count++) = (archetype, archetype.Components[index]);
        }
    }
}