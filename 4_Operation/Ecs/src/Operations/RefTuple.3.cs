







namespace Alis.Core.Ecs.Operations
{
    public ref struct RefTuple<T1, T2, T3>
    {
        public Ref<T1> Item1;
        public Ref<T2> Item2;
        public Ref<T3> Item3;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> @ref1, out Ref<T2> @ref2, out Ref<T3> @ref3)
        {
            @ref1 = Item1;
            @ref2 = Item2;
            @ref3 = Item3;

        }
    }
}
