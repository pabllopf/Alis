using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject ref tuple
    /// </summary>
    public ref struct GameObjectRefTuple<T1, T2, T3, T4, T5, T6, T7, T8>
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
        ///     The item
        /// </summary>
        public Ref<T3> Item3;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T4> Item4;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T5> Item5;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T6> Item6;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T7> Item7;

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T8> Item8;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4,
            out Ref<T5> ref5, out Ref<T6> ref6, out Ref<T7> ref7, out Ref<T8> ref8)
        {
            gameObject = GameObject;
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
            ref8 = Item8;
        }
    }
}