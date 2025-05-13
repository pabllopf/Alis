




using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Updating;
using Alis.Variadic.Generator;

namespace Alis.Core.Ecs;
public static partial class EntityExtensions
{
    /// <summary>
    /// Deconstructs the constituent components of an entity as reference(s).
    /// </summary>
    /// <exception cref="InvalidOperationException">The entity is not alive.</exception>
    /// <exception cref="ComponentNotFoundException">The entity does not have all the components specified.</exception>
    public static void Deconstruct<T1, T2, T3, T4, T5>(this Entity e, out Ref<T1> comp1, out Ref<T2> comp2, out Ref<T3> comp3, out Ref<T4> comp4, out Ref<T5> comp5)
    {
        EntityLocation eloc = e.AssertIsAlive(out _);

        ComponentStorageBase[] comps = eloc.Archetype.Components;
        byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

        comp1 = GetComp<T1>(archetypeTable, comps, eloc.Index);
        comp2 = GetComp<T2>(archetypeTable, comps, eloc.Index);
        comp3 = GetComp<T3>(archetypeTable, comps, eloc.Index);
        comp4 = GetComp<T4>(archetypeTable, comps, eloc.Index);
        comp5 = GetComp<T5>(archetypeTable, comps, eloc.Index);

    }
}