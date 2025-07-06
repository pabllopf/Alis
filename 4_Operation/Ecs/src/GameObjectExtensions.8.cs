using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The gameObject extensions class
    /// </summary>
    public static partial class GameObjectExtensions
    {
        /// <summary>
        ///     Deconstructs the constituent components of an gameObject as reference(s).
        /// </summary>
        /// <exception cref="InvalidOperationException">The gameObject is not alive.</exception>
        /// <exception cref="ComponentNotFoundException">The gameObject does not have all the components specified.</exception>
        public static void Deconstruct<T1, T2, T3, T4, T5, T6, T7, T8>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2,
            out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5, out Ref<T6> comp6, out Ref<T7> comp7,
            out Ref<T8> comp8)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
            comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
            comp4 = GetComp<T4>(archetypeTable, comps, eloc.Index);
            comp5 = GetComp<T5>(archetypeTable, comps, eloc.Index);
            comp6 = GetComp<T6>(archetypeTable, comps, eloc.Index);
            comp7 = GetComp<T7>(archetypeTable, comps, eloc.Index);
            comp8 = GetComp<T8>(archetypeTable, comps, eloc.Index);
        }
    }
}