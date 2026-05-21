

using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should have a component of <see paramref="T" />
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct With<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.HasComponent(Component<T>.Id);
    }
}