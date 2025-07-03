using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject ref tuple
    /// </summary>
    public ref struct GameObjectRefTuple<T1, T2>
    {
        /// <summary>
        ///     The current <see cref="GameObject" />; the components in this tuple belong to this <see cref="GameObject" />.
        /// </summary>
        public GameObject GameObject;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T1> Item1;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T2> Item2;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
        }
    }
}