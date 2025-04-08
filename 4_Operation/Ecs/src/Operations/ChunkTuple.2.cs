

using System;

namespace Alis.Core.Ecs.Operations
{
    public ref struct ChunkTuple<T1, T2>
    {
        /// <summary>
        /// An enumerator that can be used to enumerate individual <see cref="GameObject"/> instances.
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        public Span<T1> Span1;
        public Span<T2> Span2;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Span<T1> @comp1, out Span<T2> @comp2)
        {
            @comp1 = Span1;
            @comp2 = Span2;

        }
    }
}