

using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     Archetype metadata
    /// </summary>
    /// <param name="Id">The archetype ID</param>
    /// <param name="ComponentTypes">The component types in this archetype</param>
    /// <remarks>
    ///     Memory layout optimized: GameObjectType (2 bytes) + FastImmutableArray struct (variable size, contains reference)
    ///     Pack = 4 for balanced alignment with mixed types
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 4)]
    public record struct ArchetypeData(ArchetypeID Id, FastImmutableArray<ComponentId> ComponentTypes);
}