using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetype;

namespace Alis.Core.Ecs.Updating
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeDeferredUpdateRecord(
        Archetype Archetype,
        Archetype TemporaryBuffers,
        int InitEntityCount);
}