



namespace Alis.Core.Ecs.Operations
{
    public ref struct EntityRefTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11, T12>
    {
        /// <summary>
        /// The current <see cref="GameObject"/>; the components in this tuple belong to this <see cref="GameObject"/>.
        /// </summary>
        public GameObject GameObject;
        public Ref<T1> Item1;
        public Ref<T2> Item2;
        public Ref<T3> Item3;
        public Ref<T4> Item4;
        public Ref<T5> Item5;
        public Ref<T6> Item6;
        public Ref<T7> Item7;
        public Ref<T8> Item8;
        public Ref<T9> Item9;
        public Ref<T10> Item10;
        public Ref<T11> Item11;
        public Ref<T12> Item12;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out GameObject gameObject, out Ref<T1> @ref1, out Ref<T2> @ref2, out Ref<T3> @ref3, out Ref<T4> @ref4, out Ref<T5> @ref5, out Ref<T6> @ref6, out Ref<T7> @ref7, out Ref<T8> @ref8, out Ref<T9> @ref9, out Ref<T10> @ref10, out Ref<T11> @ref11, out Ref<T12> @ref12)
        {
            gameObject = GameObject;
            @ref1 = Item1;
            @ref2 = Item2;
            @ref3 = Item3;
            @ref4 = Item4;
            @ref5 = Item5;
            @ref6 = Item6;
            @ref7 = Item7;
            @ref8 = Item8;
            @ref9 = Item9;
            @ref10 = Item10;
            @ref11 = Item11;
            @ref12 = Item12;

        }
    }
}
