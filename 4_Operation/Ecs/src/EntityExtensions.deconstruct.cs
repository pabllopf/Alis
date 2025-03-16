using System;
using Frent.Core;
using Frent.Core.Structures;
using Frent.Updating;
using Frent.Updating.Runners;

using System.Runtime.CompilerServices;

namespace Frent
{
    /// <summary>
    /// Deconstruction extensions for entities.
    /// </summary>
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

    /// <summary>
    /// The entity extensions class
    /// </summary>
    partial class EntityExtensions
    {
        /// <summary>
        /// Gets the comp using the specified archetype table
        /// </summary>
        /// <typeparam name="TC">The tc</typeparam>
        /// <param name="archetypeTable">The archetype table</param>
        /// <param name="comps">The comps</param>
        /// <param name="index">The index</param>
        /// <returns>A ref of tc</returns>
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = archetypeTable.UnsafeArrayIndex(Component<TC>.ID.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>(UnsafeExtensions.UnsafeCast<ComponentStorage<TC>>(comps.UnsafeArrayIndex(compIndex)), index);
        }
    }
}
