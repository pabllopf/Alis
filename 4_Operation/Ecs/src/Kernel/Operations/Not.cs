using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Operations
{
    /// <summary>
    ///     Specifies a query should not have a component of <see paramref="T" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    public readonly struct Not<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.NotComponent(Component<T>.ID);
    }
}