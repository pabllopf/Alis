using System;
using Alis.Core.Ecs.Exceptions;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Deconstruction extensions for entities.
    /// </summary>
    public static partial class GameObjectExtensions
    {
        /// <summary>
        ///     Deconstructs the constituent components of an gameObject as reference(s).
        /// </summary>
        /// <exception cref="InvalidOperationException">The gameObject is not alive.</exception>
        /// <exception cref="ComponentNotFoundException">The gameObject does not have all the components specified.</exception>
        public static void Deconstruct<T>(this GameObject e, out Ref<T> comp)
        {
            GameObjectLocation eloc = e.AssertIsAlive(out _);

            ComponentStorageBase[] comps = eloc.Archetype.Components;
            byte[] archetypeTable = eloc.Archetype.ComponentTagTable;

            comp = GetComp<T>(archetypeTable, comps, eloc.Index);
        }
    }
}