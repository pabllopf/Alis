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
        public GameObject GameObject;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Deconstructs the entity
        /// </summary>
        /// <param name="gameObject">The entity</param>
        /// <param name="ref">The ref</param>
        public void Deconstruct(out GameObject gameObject, out Ref<T> @ref)
        {
            gameObject = GameObject;
            @ref = Item1;
        }
    }
}