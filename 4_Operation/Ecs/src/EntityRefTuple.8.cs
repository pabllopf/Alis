﻿using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs;
    public ref struct EntityRefTuple<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// The current <see cref="Entity"/>; the components in this tuple belong to this <see cref="Entity"/>.
        /// </summary>
        public Entity Entity;
        public Ref<T1> Item1;
    public Ref<T2> Item2;
    public Ref<T3> Item3;
    public Ref<T4> Item4;
    public Ref<T5> Item5;
    public Ref<T6> Item6;
    public Ref<T7> Item7;
    public Ref<T8> Item8;


        /// <summary>
        /// Allows tuple deconstruction syntax to be used.
        /// </summary>
        public void Deconstruct(out Entity entity, out Ref<T1> @ref1, out Ref<T2> @ref2, out Ref<T3> @ref3, out Ref<T4> @ref4, out Ref<T5> @ref5, out Ref<T6> @ref6, out Ref<T7> @ref7, out Ref<T8> @ref8)
        {
            entity = Entity;
            @ref1 = Item1;
        @ref2 = Item2;
        @ref3 = Item3;
        @ref4 = Item4;
        @ref5 = Item5;
        @ref6 = Item6;
        @ref7 = Item7;
        @ref8 = Item8;

        }
    }
