using System;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    // for Item1 fields

    /// <summary>
    ///     A tuple of multiple references.
    /// </summary>
    public ref struct RefTuple<T>
    {
        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T> @ref)
        {
            @ref = Item1;
        }
    }

    /// <summary>
    ///     A tuple of a chunk of entities and their components.
    /// </summary>
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        ///     An enumerator that can be used to enumerate individual <see cref="GameObject" /> instances.
        /// </summary>
        public GameObjectEnumerator.EntityEnumerable Entities;

        /// <summary>
        ///     The span
        /// </summary>
        public Span<T> Span;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Span<T> comp1)
        {
            comp1 = Span;
        }
    }
}