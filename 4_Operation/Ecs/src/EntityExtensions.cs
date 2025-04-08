using System;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Deconstruction extensions for entities.
    /// </summary>
    public static partial class EntityExtensions
    {
        /// <summary>
        ///     Deconstructs the constituent components of an entity as reference(s).
        /// </summary>
        /// <exception cref="InvalidOperationException">The entity is not alive.</exception>
        /// <exception cref="ComponentNotFoundException">The entity does not have all the components specified.</exception>
        public static void Deconstruct<T>(this GameObject e, out Ref<T> comp)
        {
            EntityLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp = GetComp<T>(archetypeTable, comps, eloc.Index);
        }
    }
}