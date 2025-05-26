using System;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The chunk tuple
    /// </summary>
    public ref struct ChunkTuple<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        ///     An enumerator that can be used to enumerate individual <see cref="GameObject" /> instances.
        /// </summary>
        public GameObjectEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T1> Span1;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T2> Span2;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T3> Span3;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T4> Span4;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T5> Span5;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T6> Span6;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Span<T1> comp1, out Span<T2> comp2, out Span<T3> comp3, out Span<T4> comp4,
            out Span<T5> comp5, out Span<T6> comp6)
        {
            comp1 = Span1;
            comp2 = Span2;
            comp3 = Span3;
            comp4 = Span4;
            comp5 = Span5;
            comp6 = Span6;
        }
    }
}