using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Kernel.Archetype;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The query enumerator
    /// </summary>
    public ref struct QueryEnumerator<T>
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
        ///     The current span
        /// </summary>
        private Span<T> _currentSpan1;

        /// <summary>
        ///     Initializes a new instance of the <see cref="QueryEnumerator" /> class
        /// </summary>
        /// <param name="query">The query</param>
        private QueryEnumerator(Query query)
        {
            _scene = query.Scene;
            _scene.EnterDisallowState();
            _archetypes = query.AsSpan();
            _archetypeIndex = -1;
        }

        /// <summary>
        ///     The current tuple of component references.
        /// </summary>
        public RefTuple<T> Current => new()
        {
            Item1 = new Ref<T>(_currentSpan1, _componentIndex)
        };

        /// <summary>
        ///     Indicates to the scene that this enumeration is finished; the scene might allow structual changes after this.
        /// </summary>
        /// <remarks>This MUST be called when finished with the enumerator!</remarks>
        public void Dispose()
        {
            _scene.ExitDisallowState(null);
        }

        /// <summary>
        ///     Moves to the next gameObject set of gameObject references.
        /// </summary>
        /// <returns><see langword="true" /> when its possible to enumerate further, otherwise <see langword="false" />.</returns>
        public bool MoveNext()
        {
            if (++_componentIndex < _currentSpan1.Length) return true;

            _componentIndex = 0;
            _archetypeIndex++;

            while ((uint)_archetypeIndex < (uint)_archetypes.Length)
            {
                Archetype cur = _archetypes[_archetypeIndex];
                _currentSpan1 = cur.GetComponentSpan<T>();

                if (!_currentSpan1.IsEmpty)
                    return true;

                _archetypeIndex++;
            }

            return false;
        }

        /// <summary>
        ///     Proxy type for foreach syntax
        /// </summary>
        /// <param name="query"></param>
        [StructLayout(LayoutKind.Sequential, Pack = 1)]
        
        public struct QueryEnumerable(Query query)
        {
            /// <summary>
            ///     Gets the enumerator over a query.
            /// </summary>
            public QueryEnumerator<T> GetEnumerator()
            {
                return new QueryEnumerator<T>(query);
            }
        }
    }
}