using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should have a tag of <see paramref="T" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]

    public struct Tagged<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.HasTag(Tag<T>.Id);
    }
}