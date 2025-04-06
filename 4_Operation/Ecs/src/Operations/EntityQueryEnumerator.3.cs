using System;
using Alis.Core.Ecs.Arch;

namespace Alis.Core.Ecs.Operations
{
    public ref struct EntityQueryEnumerator<T1, T2, T3>
    {
        private int _archetypeIndex;
        private int _componentIndex;
        private World _world;
        private Span<Archetype> _archetypes;
        private Span<EntityIdOnly> _entityIds;
        private Span<T1> _currentSpan1;
        private Span<T2> _currentSpan2;
        private Span<T3> _currentSpan3;

        private EntityQueryEnumerator(Query query)
        {
            _world = query.World;
            _world.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        /// The current tuple of component references and the <see cref="Entity"/> instance.
        /// </summary>
        public EntityRefTuple<T1, T2, T3> Current => new()
        {
            Entity = _entityIds[_componentIndex].ToEntity(_world),
            Item1 = new Ref<T1>(_currentSpan1, _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2, _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3, _componentIndex),

        };

        /// <summary>
        /// Indicates to the world that this enumeration is finished; the world might allow structual changes after this.
        /// </summary>
        public void Dispose()
        {
            _world.ExitDisallowState();
        }

        /// <summary>
        /// Moves to the next entity and its components in this enumeration.
        /// </summary>
        /// <returns><see langword="true"/> when its possible to enumerate further, otherwise <see langword="false"/>.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length)
            {
                return true;
            }

            do
            {
                _componentIndex = 0;
                _archetypeIndex++;

                if ((uint)_archetypeIndex < (uint)_archetypes.Length)
                {
                    var cur = _archetypes[_archetypeIndex];
                    _entityIds = cur.GetEntitySpan();
                    _currentSpan1 = cur.GetComponentSpan<T1>();
                    _currentSpan2 = cur.GetComponentSpan<T2>();
                    _currentSpan3 = cur.GetComponentSpan<T3>();

                }
                else
                {
                    return false;
                }
            } while (!(_componentIndex < _currentSpan1.Length));

            return true;
        }

        /// <summary>
        /// Proxy type for foreach syntax
        /// </summary>
        /// <param name="query">The query to wrap.</param>
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            /// Gets the enumerator over a query.
            /// </summary>
            public EntityQueryEnumerator<T1, T2, T3> GetEnumerator() => new EntityQueryEnumerator<T1, T2, T3>(query);
        }
    }
}
