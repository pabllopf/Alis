using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     A tuple of multiple references with an <see cref="GameObject" />.
    /// </summary>
    public ref struct GameObjectRefTuple<T>
    {
        /// <summary>
        ///     The current <see cref="GameObject" />; the components in this tuple belong to this <see cref="GameObject" />.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out GameObject gameObject, out Ref<T> @ref)
        {
            gameObject = GameObject;
            @ref = Item1;
        }
    }
}