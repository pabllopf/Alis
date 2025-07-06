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
        public static void Deconstruct<T1, T2>(this GameObject e, out Ref<T1> comp1, out Ref<T2> comp2)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
            comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
        }
    }
}