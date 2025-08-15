using System;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Systems;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject query enumerator
    /// </summary>
    public ref struct GameObjectQueryEnumerator<T1, T2, T3, T4>
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
        private Span<T1> _currentSpan1;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T2> _currentSpan2;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T3> _currentSpan3;

        /// <summary>
        ///     The current span
        /// </summary>
        private Span<T4> _currentSpan4;

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
        public GameObjectRefTuple<T1, T2, T3, T4> Current => new()
        {
            GameObject = _entityIds[_componentIndex].ToEntity(_scene),
            Item1 = new Ref<T1>(_currentSpan1, _componentIndex),
            Item2 = new Ref<T2>(_currentSpan2, _componentIndex),
            Item3 = new Ref<T3>(_currentSpan3, _componentIndex),
            Item4 = new Ref<T4>(_currentSpan4, _componentIndex)
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
                    _currentSpan1 = cur.GetComponentSpan<T1>();
                    _currentSpan2 = cur.GetComponentSpan<T2>();
                    _currentSpan3 = cur.GetComponentSpan<T3>();
                    _currentSpan4 = cur.GetComponentSpan<T4>();
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
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public GameObjectQueryEnumerator<T1, T2, T3, T4> GetEnumerator()
            {
                return new GameObjectQueryEnumerator<T1, T2, T3, T4>(query);
            }
        }
    }
}