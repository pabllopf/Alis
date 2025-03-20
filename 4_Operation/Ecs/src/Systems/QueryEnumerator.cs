using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Systems
{
    public ref struct QueryEnumerator<T>
    {
        private int _archetypeIndex;
        private int _componentIndex;
        private World _world;
        private Span<Archetype> _archetypes;
        private Span<T> _currentSpan1;
        private QueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        public RefTuple<T> Current => new()
        {
            Item1 = new Ref<T>(_currentSpan1, _componentIndex),
        };

        public void Dispose()
        {
            _world.ExitDisallowState();
        }

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

        public struct QueryEnumerable(Query query)
        {
            public QueryEnumerator<T> GetEnumerator() => new QueryEnumerator<T>(query);
        }
    }
}