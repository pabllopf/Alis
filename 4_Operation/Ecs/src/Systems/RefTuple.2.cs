




using System;
using Alis.Core.Ecs.Core;
using Alis.Variadic.Generator;

namespace Alis.Core.Ecs.Systems;
    public ref struct RefTuple<T1, T2>
    {
        public Ref<T1> Item1;
    public Ref<T2> Item2;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Ref<T1> @ref1, out Ref<T2> @ref2)
        {
            @ref1 = Item1;
        @ref2 = Item2;

        }
    }
