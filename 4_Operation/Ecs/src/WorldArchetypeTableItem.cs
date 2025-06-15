using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The scene archetype table item
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct WorldArchetypeTableItem(Archetype archetype, Archetype temp)
    {
        /// <summary>
        ///     The archetype
        /// </summary>
        public Archetype Archetype = archetype;

        /// <summary>
        ///     The temp
        /// </summary>
        public Archetype DeferredCreationArchetype = temp;
    }
}