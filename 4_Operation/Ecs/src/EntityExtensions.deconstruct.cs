﻿using System;
using System.Runtime.CompilerServices;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Core.Archetype;
using Alis.Core.Ecs.Core.Memory;
using Alis.Core.Ecs.Updating;

namespace Alis.Core.Ecs
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

    partial class EntityExtensions
    {
        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static Ref<TC> GetComp<TC>(byte[] archetypeTable, ComponentStorageBase[] comps, int index)
        {
            int compIndex = archetypeTable.UnsafeArrayIndex(Component<TC>.ID.RawIndex) & GlobalWorldTables.IndexBits;
            return new Ref<TC>(UnsafeExtensions.UnsafeCast<ComponentStorage<TC>>(comps.UnsafeArrayIndex(compIndex)), index);
        }
    }
}
