using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Enumerator over a set of <see cref="GameObject" /> instances.
    /// </summary>
    public ref struct GameObjectEnumerator
    {
        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The entities
        /// </summary>
        private readonly Span<GameObjectIdOnly> _entities;

        /// <summary>
        ///     The index
        /// </summary>
        private int _index;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectEnumerator" /> class
        /// </summary>
        /// <param name="scene">The scene</param>
        /// <param name="entities">The entities</param>
        internal GameObjectEnumerator(Scene scene, Span<GameObjectIdOnly> entities)
        {
            _scene = scene;
            _entities = entities;
            _index = -1;
        }

        /// <summary>
        ///     Moves to the next <see cref="GameObject" /> instance.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            return ++_index < _entities.Length;
        }

        /// <summary>
        ///     The current <see cref="GameObject" /> instance.
        /// </summary>
        public GameObject Current => _entities[_index].ToEntity(_scene);

        /// <summary>
        ///     Proxy struct used to get an <see cref="GameObjectEnumerator" />.
        /// </summary>
        public readonly ref struct EntityEnumerable
        {
            /// <summary>
            ///     The scene
            /// </summary>
            private readonly Scene _scene;

            /// <summary>
            ///     The entities
            /// </summary>
            private readonly Span<GameObjectIdOnly> _entities;

            /// <summary>
            ///     Initializes a new instance of the <see cref="EntityEnumerable" /> class
            /// </summary>
            /// <param name="scene">The scene</param>
            /// <param name="entities">The entities</param>
            internal EntityEnumerable(Scene scene, Span<GameObjectIdOnly> entities)
            {
                _scene = scene;
                _entities = entities;
            }

            /// <summary>
            ///     Gets an <see cref="GameObjectEnumerator" /> from this <see cref="EntityEnumerable" />. Allows for the usage of foreach
            ///     syntax.
            /// </summary>
            public GameObjectEnumerator GetEnumerator()
            {
                return new GameObjectEnumerator(_scene, _entities);
            }
        }
    }
}