

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    // for Item1 fields

    /// <summary>
    ///     A tuple of multiple references.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct RefTuple<T>
    {
        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T> Item1;

        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T> @ref)
        {
            @ref = Item1;
        }
    }

    /// <summary>
    ///     The ref tuple
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public ref struct RefTuple<T1, T2>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2)
        {
            ref1 = Item1;
            ref2 = Item2;
        }
    }

    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3>
    {
        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T1> Item1 { get; set; }

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T2> Item2 { get; set; }

        /// <summary>
        ///     The item
        /// </summary>
        public Ref<T3> Item3 { get; set; }


        /// <summary>
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
        }
    }

    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
        }
    }

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

    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4, T5, T6>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5,
            out Ref<T6> ref6)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
        }
    }

    /// <summary>
    ///     The ref tuple
    /// </summary>
    public ref struct RefTuple<T1, T2, T3, T4, T5, T6, T7>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5,
            out Ref<T6> ref6, out Ref<T7> ref7)
        {
            ref1 = Item1;
            ref2 = Item2;
            ref3 = Item3;
            ref4 = Item4;
            ref5 = Item5;
            ref6 = Item6;
            ref7 = Item7;
        }
    }

    /// <summary>
    ///     The ref tuple
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Eight Ref structs (192 bytes total: 8 × 24 bytes)
    ///     Pack = 4 for optimal alignment
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public ref struct RefTuple<T1, T2, T3, T4, T5, T6, T7, T8>
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
        ///     Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> ref1, out Ref<T2> ref2, out Ref<T3> ref3, out Ref<T4> ref4, out Ref<T5> ref5,
            out Ref<T6> ref6, out Ref<T7> ref7, out Ref<T8> ref8)
        {
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