using System;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The chunk tuple
    /// </summary>
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Deconstructs the comp 1
        /// </summary>
        /// <param name="comp1">The comp</param>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
}