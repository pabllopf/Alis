

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Create entity command
    /// </summary>
    /// <param name="Entity">The entity to create</param>
    /// <param name="BufferIndex">The buffer index</param>
    /// <param name="BufferLength">The buffer length</param>
    /// <remarks>
    ///     Memory layout optimized: 14 bytes total (GameObjectIdOnly 6 bytes + two ints 8 bytes)
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct CreateCommand(GameObjectIdOnly Entity, int BufferIndex, int BufferLength);
}