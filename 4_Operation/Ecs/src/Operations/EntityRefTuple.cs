using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Operations
{
    /// <summary>
    ///     The entity ref tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct EntityRefTuple<T>
    {
        /// <summary>
        ///     The entity
        /// </summary>
        public Entity Entity;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Deconstructs the entity
        /// </summary>
        /// <param name="entity">The entity</param>
        /// <param name="ref">The ref</param>
        public void Deconstruct(out Entity entity, out Ref<T> @ref)
        {
            entity = Entity;
            @ref = Item1;
        }
    }
}