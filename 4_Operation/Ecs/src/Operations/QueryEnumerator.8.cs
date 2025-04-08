






using System;
using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Operations
{
    public ref struct QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        private int _archetypeIndex;
        private int _componentIndex;
        private Scene scene;
        private Span<Archetype> _archetypes;
        private Span<T1> _currentSpan1;
        private Span<T2> _currentSpan2;
        private Span<T3> _currentSpan3;
        private Span<T4> _currentSpan4;
        private Span<T5> _currentSpan5;
        private Span<T6> _currentSpan6;
        private Span<T7> _currentSpan7;
        private Span<T8> _currentSpan8;

        private QueryEnumerator(Query query)
        {
            scene = query.Scene;
            scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        /// The current tuple of component references.
        /// </summary>
        public RefTuple<T1, T2, T3, T4, T5, T6, T7, T8> Current => new()
        {
            Item1 = new Ref<T1>(_currentSpan1,  _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2,  _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3,  _componentIndex),
            Item4 = new Ref<T4>(_currentSpan4,  _componentIndex),
            Item5 = new Ref<T5>(_currentSpan5,  _componentIndex),
            Item6 = new Ref<T6>(_currentSpan6,  _componentIndex),
            Item7 = new Ref<T7>(_currentSpan7,  _componentIndex),
            Item8 = new Ref<T8>(_currentSpan8,  _componentIndex),

        };

        /// <summary>
        /// Indicates to the world that this enumeration is finished; the world might allow structual changes after this.
        /// </summary>
        /// <remarks>This MUST be called when finished with the enumerator!</remarks>
        public void Dispose()
        {
            scene.ExitDisallowState();
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
                _currentSpan5 = cur.GetComponentSpan<T5>();
                _currentSpan6 = cur.GetComponentSpan<T6>();
                _currentSpan7 = cur.GetComponentSpan<T7>();
                _currentSpan8 = cur.GetComponentSpan<T8>();

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
            public QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8> GetEnumerator() => new QueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8>(query);
        }
    }
}