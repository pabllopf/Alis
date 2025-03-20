using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The query enumerator
    /// </summary>
    public ref struct QueryEnumerator<T>
    {
        /// <summary>
        /// The archetype index
        /// </summary>
        private int _archetypeIndex;
        /// <summary>
        /// The component index
        /// </summary>
        private int _componentIndex;
        /// <summary>
        /// The world
        /// </summary>
        private World _world;
        /// <summary>
        /// The archetypes
        /// </summary>
        private Span<Archetype> _archetypes;
        /// <summary>
        /// The current span
        /// </summary>
        private Span<T> _currentSpan1;
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryEnumerator"/> class
        /// </summary>
        /// <param name="query">The query</param>
        private QueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        /// Gets the value of the current
        /// </summary>
        public RefTuple<T> Current => new()
        {
            Item1 = new Ref<T>(_currentSpan1, _componentIndex),
        };

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        /// <summary>
        /// Moves the next
        /// </summary>
        /// <returns>The bool</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length)
            {
                return true;
            }

            _componentIndex = 0;
            _archetypeIndex++;

            if ((uint)_archetypeIndex < (uint)_archetypes.Length)
            {
                var cur = _archetypes[_archetypeIndex];
                _currentSpan1 = cur.GetComponentSpan<T>();
                return true;
            }

            return false;
        }

        /// <summary>
        /// The query enumerable
        /// </summary>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator
            /// </summary>
            /// <returns>A query enumerator of t</returns>
            public QueryEnumerator<T> GetEnumerator() => new QueryEnumerator<T>(query);
        }
    }
}