using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should have a component of <see paramref="T" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct With<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.HasComponent(Component<T>.Id);
    }
}