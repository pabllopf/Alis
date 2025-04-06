






using System;
using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Operations
{
    public ref struct QueryEnumerator<T1, T2, T3, T4>
    {
        private int _archetypeIndex;
        private int _componentIndex;
        private World _world;
        private Span<Archetype> _archetypes;
        private Span<T1> _currentSpan1;
        private Span<T2> _currentSpan2;
        private Span<T3> _currentSpan3;
        private Span<T4> _currentSpan4;

        private QueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        /// The current tuple of component references.
        /// </summary>
        public RefTuple<T1, T2, T3, T4> Current => new()
        {
            Item1 = new Ref<T1>(_currentSpan1,  _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2,  _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3,  _componentIndex),
            Item4 = new Ref<T4>(_currentSpan4,  _componentIndex),

        };

        /// <summary>
        /// Indicates to the world that this enumeration is finished; the world might allow structual changes after this.
        /// </summary>
        /// <remarks>This MUST be called when finished with the enumerator!</remarks>
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        /// <summary>
        /// Moves to the next entity set of entity references.
        /// </summary>
        /// <returns><see langword="true"/> when its possible to enumerate further, otherwise <see langword="false"/>.</returns>
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
                _currentSpan1 = cur.GetComponentSpan<T1>();
                _currentSpan2 = cur.GetComponentSpan<T2>();
                _currentSpan3 = cur.GetComponentSpan<T3>();
                _currentSpan4 = cur.GetComponentSpan<T4>();

                return true;
            }

            return false;
        }

        /// <summary>
        /// Proxy type for foreach syntax
        /// </summary>
        /// <param name="query"></param>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator over a query.
            /// </summary>
            public QueryEnumerator<T1, T2, T3, T4> GetEnumerator() => new QueryEnumerator<T1, T2, T3, T4>(query);
        }
    }
}