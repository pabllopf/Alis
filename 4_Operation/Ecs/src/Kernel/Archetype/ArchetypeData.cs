using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Kernel.Archetype
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeData(
        GameObjectType Id,
        FastImmutableArray<ComponentId> ComponentTypes,
        FastImmutableArray<TagId> TagTypes);
}