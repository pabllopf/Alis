




using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Variadic.Generator;

namespace Alis.Core.Ecs.Systems;
    public ref struct ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        private World _world;
        private Span<Archetype> _archetypes;
        private int _archetypeIndex;
        private ChunkQueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        /// The current tuple of component chunks.
        /// </summary>
        public ChunkTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new()
                {
                    Span1 = cur.GetComponentSpan<T1>(),
                Span2 = cur.GetComponentSpan<T2>(),
                Span3 = cur.GetComponentSpan<T3>(),
                Span4 = cur.GetComponentSpan<T4>(),
                Span5 = cur.GetComponentSpan<T5>(),
                Span6 = cur.GetComponentSpan<T6>(),
                Span7 = cur.GetComponentSpan<T7>(),
                Span8 = cur.GetComponentSpan<T8>(),
                Span9 = cur.GetComponentSpan<T9>(),
                Span10 = cur.GetComponentSpan<T10>(),
                Span11 = cur.GetComponentSpan<T11>(),
                Span12 = cur.GetComponentSpan<T12>()
                };
            }
        }

        /// <summary>
        /// Indicates to the world that this enumeration is finished; the world might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            _world.ExitDisallowState(null);
        }

        /// <summary>
        /// Moves to the next chunk of components in this enumeration.
        /// </summary>
        /// <returns><see langword="true"/> when its possible to enumerate further, otherwise <see langword="false"/>.</returns>
        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        /// <summary>
        /// Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator over a query.
            /// </summary>
            public ChunkQueryEnumerator<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12> GetEnumerator() => new(query);
        }
    }
