using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4, T5, T6, T7, T8, T9, T10, T11>
    {
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
        ///     The item
        /// </summary>
        public Ref<T9> Item9;

        /// <summary>
        ///     The item 10
        /// </summary>
        public Ref<T10> Item10;

        /// <summary>
        ///     The item 11
        /// </summary>
        public Ref<T11> Item11;


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5,
            out Ref<T6> ref6, out Ref<T7> ref7, out Ref<T8> ref8, out Ref<T9> ref9, out Ref<T10> ref10, out Ref<T11> ref11)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
            ref8 = Item8;
            ref9 = Item9;
            ref10 = Item10;
            ref11 = Item11;
        }
    }
}