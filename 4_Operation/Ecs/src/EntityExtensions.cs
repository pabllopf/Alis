using System;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Updating;
using Alis.Variadic.Generator;

namespace Alis.Core.Ecs;

/// <summary>
/// Deconstruction extensions for entities.
/// </summary>


[Variadic("        comp = GetComp<T>(archetypeTable, comps, eloc.Index);",
    "|        comp$ = GetComp<T$>(archetypeTable, comps, eloc.Index);\n|")]
public static partial class EntityExtensions
{
    /// <summary>
    /// Deconstructs the constituent components of an entity as reference(s).
    /// </summary>
    /// <exception cref="InvalidOperationException">The entity is not alive.</exception>
    /// <exception cref="ComponentNotFoundException">The entity does not have all the components specified.</exception>
    public static void Deconstruct<T>(this Entity e, out Ref<T> comp)
    {
        EntityLocation eloc = e.AssertIsAlive(out _);

        ComponentStorageBase[] comps = eloc.Archetype.Components;
        byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

        comp = GetComp<T>(archetypeTable, comps, eloc.Index);
    }
}