using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject ref tuple
    /// </summary>
    public ref struct GameObjectRefTuple<T1>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1)
        {
            gameObject = GameObject;
            ref1 = Item1;
        }
    }
}