using System;
using Frent.Core;

namespace Frent.Systems
{
    /// <summary>
    /// The entity enumerator
    /// </summary>
    public ref struct EntityEnumerator
    {
        /// <summary>
        /// The world
        /// </summary>
        private World _world;
        /// <summary>
        /// The entities
        /// </summary>
        private Span<EntityIDOnly> _entities;
        /// <summary>
        /// The index
        /// </summary>
        private int _index;
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityEnumerator"/> class
        /// </summary>
        /// <param name="world">The world</param>
        /// <param name="entities">The entities</param>
        internal EntityEnumerator(World world, Span<EntityIDOnly> entities)
        {
            _world = world;
            _entities = entities;
            _index = -1;
        }

        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext() => ++_index < _entities.Length;
        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public Entity Current => _entities[_index].ToEntity(_world);

        /// <summary>
        /// The entity enumerable
        /// </summary>
        public ref struct EntityEnumerable
        {
            /// <summary>
            /// The world
            /// </summary>
            private World _world;
            /// <summary>
            /// The entities
            /// </summary>
            private Span<EntityIDOnly> _entities;
            /// <summary>
            /// Initializes a new instance of the <see cref="EntityEnumerable"/> class
            /// </summary>
            /// <param name="world">The world</param>
            /// <param name="entities">The entities</param>
            internal EntityEnumerable(World world, Span<EntityIDOnly> entities)
            {
                _world = world;
                _entities = entities;
            }

            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>The entity enumerator</returns>
            public EntityEnumerator GetEnumerator() => new EntityEnumerator(_world, _entities);
        }
    }
}