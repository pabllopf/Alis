using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Core.Archetype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeData(
        ArchetypeID Id,
        FastImmutableArray<ComponentId> ComponentTypes,
        FastImmutableArray<TagId> TagTypes);
}