

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Updating
{
    /// <summary>
    ///     Delete component data
    /// </summary>
    /// <param name="ToIndex">The destination index</param>
    /// <param name="FromIndex">The source index</param>
    /// <remarks>
    ///     Memory layout optimized: 8 bytes total (two ints, 4 bytes each)
    ///     Pack = 1 for minimal memory footprint, naturally aligned
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct DeleteComponentData(int ToIndex, int FromIndex);
}