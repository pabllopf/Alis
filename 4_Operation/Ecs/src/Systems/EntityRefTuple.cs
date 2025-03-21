using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The entity ref tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
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