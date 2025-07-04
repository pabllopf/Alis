using System;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The game object query enumerator
    /// </summary>
    public ref struct GameObjectQueryEnumerator<T>
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
        ///     The current span
        /// </summary>
        private Span<T> _currentSpan1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectQueryEnumerator" /> class
        /// </summary>
        /// <param name="query">The query</param>
        private GameObjectQueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component references and the <see cref="GameObject" /> instance.
        /// </summary>
        public GameObjectRefTuple<T> Current => new()
        {
            GameObject = _entityIds[_componentIndex].ToEntity(_scene),
            Item1 = new Ref<T>(_currentSpan1, _componentIndex)
        };

        /// <summary>
        ///     Indicates to the scene that this enumeration is finished; the scene might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next gameObject and its components in this enumeration.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length) return true;

            do
            {
                _componentIndex = 0;
                _archetypeIndex++;

                if ((uint)_archetypeIndex < (uint)_archetypes.Length)
                {
                    Archetype cur = _archetypes[_archetypeIndex];
                    _entityIds = cur.GetEntitySpan();
                    _currentSpan1 = cur.GetComponentSpan<T>();
                }
                else
                {
                    return false;
                }
            } while (!(_componentIndex < _currentSpan1.Length));

            return true;
        }

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public GameObjectQueryEnumerator<T> GetEnumerator()
            {
                return new GameObjectQueryEnumerator<T>(query);
            }
        }
    }
}