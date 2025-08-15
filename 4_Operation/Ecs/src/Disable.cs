using System.Runtime.InteropServices;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Built-in tag that can be used to disable entities.
    /// </summary>
    /// <remarks>
    ///     Entities with the <see cref="Disable" /> tag will not be updated in <see cref="Scene.Update()" /> or similar
    ///     overloads, nor in queries unless explicitly required.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public record struct Disable;
}