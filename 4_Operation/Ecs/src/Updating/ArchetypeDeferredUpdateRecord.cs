using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core.Archetype;

namespace Alis.Core.Ecs.Updating
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct ArchetypeDeferredUpdateRecord(
        Archetype Archetype,
        Archetype TemporaryBuffers,
        int InitEntityCount);
}