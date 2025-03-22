using System;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    /// The ref tuple
    /// </summary>
    public ref struct RefTuple<T>
    {
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T> Item1;
        /// <summary>
        /// Deconstructs the ref
        /// </summary>
        /// <param name="@ref">The ref</param>
        public void Deconstruct(out Ref<T> @ref)
        {
            @ref = Item1;
        }
    }





    /// <summary>
    /// The entity ref tuple
    /// </summary>
    public ref struct EntityRefTuple<T>
    {
        /// <summary>
        /// The entity
        /// </summary>
        public Entity Entity;
        /// <summary>
        /// The item
        /// </summary>
        public Ref<T> Item1;
        /// <summary>
        /// Deconstructs the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="@ref">The ref</param>
        public void Deconstruct(out Entity entity, out Ref<T> @ref)
        {
            entity = Entity;
            @ref = Item1;
        }
    }





    /// <summary>
    /// The chunk tuple
    /// </summary>
    public ref struct ChunkTuple<T>
    {
        /// <summary>
        /// The entities
        /// </summary>
        public EntityEnumerator.EntityEnumerable Entities;
        /// <summary>
        /// The span
        /// </summary>
        public Span<T> Span;
        /// <summary>
        /// Deconstructs the comp 1
        /// </summary>
        /// <param name="@comp1">The comp</param>
        public void Deconstruct(out Span<T> @comp1)
        {
            @comp1 = Span;
        }
    }
}