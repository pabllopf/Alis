using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Id"></param>
    /// <param name="ComponentTypes"></param>
    /// <param name="TagTypes"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeData(
        GameObjectType Id,
        FastImmutableArray<ComponentId> ComponentTypes,
        FastImmutableArray<TagId> TagTypes);
}