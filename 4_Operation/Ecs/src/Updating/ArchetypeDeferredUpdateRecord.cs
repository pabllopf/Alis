

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel.Archetypes;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     Archetype deferred update record
    /// </summary>
    /// <param name="Archetype">The archetype</param>
    /// <param name="TemporaryBuffers">The temporary buffers</param>
    /// <param name="InitEntityCount">The initial entity count</param>
    /// <remarks>
    ///     Memory layout optimized: 20 bytes total (two Archetype references 16 bytes + int 4 bytes)
    ///     Pack = 8 for optimal alignment with reference types
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    public record struct ArchetypeDeferredUpdateRecord(
        Archetype Archetype,
        Archetype TemporaryBuffers,
        int InitEntityCount);
}