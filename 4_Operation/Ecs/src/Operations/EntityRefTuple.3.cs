



namespace Alis.Core.Ecs.Operations
{
    public ref struct EntityRefTuple<T1, T2, T3>
    {
        /// <summary>
        /// The current <see cref="Entity"/>; the components in this tuple belong to this <see cref="Entity"/>.
        /// </summary>
        public Entity Entity;
        public Ref<T1> Item1;
        public Ref<T2> Item2;
        public Ref<T3> Item3;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Entity entity, out Ref<T1> @ref1, out Ref<T2> @ref2, out Ref<T3> @ref3)
        {
            entity = Entity;
            @ref1 = Item1;
            @ref2 = Item2;
            @ref3 = Item3;

        }
    }
}
