using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     An enumerator that can be used to enumerate all <see cref="GameObject" /> instances in a <see cref="Query" />.
    /// </summary>
    public ref struct GameObjectQueryEnumerator
    {
        /// <summary>
        ///     The archetype index
        /// </summary>
        private int _archetypeIndex;

        /// <summary>
        ///     The component index
        /// </summary>
        private int _componentIndex;

        /// <summary>
        ///     The scene
        /// </summary>
        private readonly Scene _scene;

        /// <summary>
        ///     The archetypes
        /// </summary>
        private readonly Span<Archetype> _archetypes;

        /// <summary>
        ///     The gameObject ids
        /// </summary>
        private Span<GameObjectIdOnly> _entityIds;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectQueryEnumerator" /> class
        /// </summary>
        /// <param name="query">The query</param>
        public GameObjectQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current <see cref="GameObject" /> instance.
        /// </summary>
        public GameObject Current => _entityIds[_componentIndex].ToEntity(_scene);

        /// <summary>
        ///     Indicates to the scene that this enumeration is finished; the scene might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next gameObject.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _entityIds.Length) return true;

            _componentIndex = 0;
            _archetypeIndex++;

            while ((uint)_archetypeIndex < (uint)_archetypes.Length)
            {
                Archetype cur = _archetypes[_archetypeIndex];
                _entityIds = cur.GetEntitySpan();
                if (!_entityIds.IsEmpty)
                    return true;

                _archetypeIndex++;
            }

            return false;
        }

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query"></param>
        public readonly struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public GameObjectQueryEnumerator GetEnumerator()
            {
                return new GameObjectQueryEnumerator(query);
            }
        }
    }
}