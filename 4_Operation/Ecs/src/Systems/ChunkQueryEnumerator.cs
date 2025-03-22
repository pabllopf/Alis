using System;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    public ref struct ChunkQueryEnumerator<T>
    {
        //ptr, ptr, int, int is better alignment
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

        public ChunkTuple<T> Current
        {
            get
            {
                Archetype cur = _archetypes[_archetypeIndex];
                return new()
                {
                    Span = cur.GetComponentSpan<T>(),
                };
            }
        }
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        public bool MoveNext() => ++_archetypeIndex < _archetypes.Length;

        public struct QueryEnumerable(Query query)
        {
            public ChunkQueryEnumerator<T> GetEnumerator() => new(query);
        }
    }
}