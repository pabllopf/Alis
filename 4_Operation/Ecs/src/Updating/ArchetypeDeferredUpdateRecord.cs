using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    /// 
    /// </summary>
    /// <param name="Archetype"></param>
    /// <param name="TemporaryBuffers"></param>
    /// <param name="InitEntityCount"></param>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeDeferredUpdateRecord(
        Archetype Archetype,
        Archetype TemporaryBuffers,
        int InitEntityCount);
}