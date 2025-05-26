using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4, T5>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
        }
    }
}