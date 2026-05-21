

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Represents an entry in the world archetype table, pairing an archetype with a temporary
    ///     deferred-creation archetype used during structural changes.
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 16 bytes total (two Archetype references, 8 bytes each).
    ///     Pack = 8 for optimal alignment with reference types on 64-bit architectures.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public struct WorldArchetypeTableItem(Archetype archetype, Archetype temp)
    {
        /// <summary>
        ///     The main archetype used for entities in this table slot.
        /// </summary>
        public Archetype Archetype = archetype;

        /// <summary>
        ///     A temporary archetype used for deferred entity creation during structural changes.
        /// </summary>
        public Archetype DeferredCreationArchetype = temp;
    }
}