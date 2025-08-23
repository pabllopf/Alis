using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     The scene update filter class
    /// </summary>
    /// <seealso cref="IComponentUpdateFilter" />
    public class SceneUpdateFilter : IComponentUpdateFilter
    {
        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly ShortSparseSet<(Archetype Archetype, int Start, int Length)> _archetypes = new();

        //its entirely possible that the HashSet<Type> for this filter in GenerationServices.TypeAttributeCache doesn't even exist yet
        /// <summary>
        ///     The attribute type
        /// </summary>
        private readonly Type _attributeType;

        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        //if we want, we can replace this with a byte[] array to save memory
        /// <summary>
        ///     The component storage base
        /// </summary>
        private ComponentStorageBase[] _allComponents = new ComponentStorageBase[8];

        /// <summary>
        ///     The filter
        /// </summary>
        private HashSet<Type> _filter;

        //these components need to be updated
        /// <summary>
        ///     The create
        /// </summary>
        private FastestStack<ComponentId> _filteredComponents = FastestStack<ComponentId>.Create(8);

        /// <summary>
        ///     The last registered component id
        /// </summary>
        private int _lastRegisteredComponentId;

        /// <summary>
        ///     The next component storage index
        /// </summary>
        private int _nextComponentStorageIndex;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SceneUpdateFilter" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="attributeType">The attribute type</param>
        public SceneUpdateFilter(Scene scene, Type attributeType)
        {
            _attributeType = attributeType;
            _scene = scene;

            foreach (GameObjectType archetype in scene.EnabledArchetypes.AsSpan())
                ArchetypeAdded(archetype.Archetype(scene)!);
        }

        /// <summary>
        ///     Updates the subset using the specified archetypes
        /// </summary>
        /// <param name="archetypes">The archetypes</param>
        public void UpdateSubset(ReadOnlySpan<ArchetypeDeferredUpdateRecord> archetypes)
        {
            Span<ComponentStorageBase> componentStorages = _allComponents.AsSpan(0, _nextComponentStorageIndex);
            foreach ((Archetype archetype, Archetype _, int count) in archetypes)
            {
                (Archetype current, int start, int end) = _archetypes[archetype.Id.RawIndex];

                foreach (ComponentStorageBase storage in componentStorages.Slice(start, end))
                    storage.Run(_scene, current, count, current.EntityCount - count);
            }
        }

        /// <summary>
        ///     Updates this instance
        /// </summary>
        public void Update()
        {
            Scene scene = _scene;
            Span<ComponentStorageBase> componentStorages = _allComponents.AsSpan(0, _nextComponentStorageIndex);
            Span<(Archetype Archetype, int Start, int Length)> archetypes = _archetypes.AsSpan();
            for (int i = 0; i < archetypes.Length; i++)
            {
                (Archetype current, int start, int count) = archetypes[i];
                Span<ComponentStorageBase> storages = componentStorages.Slice(start, count);
                foreach (ComponentStorageBase storage in storages) storage.Run(scene, current);
            }
        }

        /// <summary>
        ///     Registers the new components
        /// </summary>
        private void RegisterNewComponents()
        {
            if (_filter is null &&
                !GenerationServices.TypeAttributeCache.TryGetValue(_attributeType, out _filter))
                return;

            for (ref int i = ref _lastRegisteredComponentId; i < Component.ComponentTable.Count; i++)
            {
                ComponentId thisId = new((ushort)i);

                if (_filter.Contains(thisId.Type)) _filteredComponents.Push(thisId);
            }
        }

        /// <summary>
        ///     Archetypes the added using the specified archetype
        /// </summary>
        /// <param name="archetype">The archetype</param>
        internal void ArchetypeAdded(Archetype archetype)
        {
            if (_lastRegisteredComponentId < Component.ComponentTable.Count)
                RegisterNewComponents();

            int start = _nextComponentStorageIndex;
            int count = 0;
            foreach (ComponentId component in _filteredComponents.AsSpan())
            {
                int index = archetype.GetComponentIndex(component);
                if (index != 0) //archetype.Components[0] is always null; 0 tombstone value
                {
                    count++;

                    if (_nextComponentStorageIndex == _allComponents.Length)
                        Array.Resize(ref _allComponents, _allComponents.Length * 2);
                    _allComponents[_nextComponentStorageIndex++] = archetype.Components[index];
                }
            }

            if (count > 0)
                _archetypes[archetype.Id.RawIndex] = (archetype, start, count);
        }
    }
}