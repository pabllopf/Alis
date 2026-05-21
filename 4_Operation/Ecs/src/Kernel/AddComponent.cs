

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Add component command
    /// </summary>
    /// <param name="Entity">The entity to add component to</param>
    /// <param name="ComponentHandle">The component handle to add</param>
    /// <remarks>
    ///     Memory layout optimized: 12 bytes total (GameObjectIdOnly 6 bytes + ComponentHandle 6 bytes)
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public record struct AddComponent(GameObjectIdOnly Entity, ComponentHandle ComponentHandle);
}