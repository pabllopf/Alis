using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Alis.Core.Ecs.Core;
using Alis.Core.Ecs.Redefinition;


namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should have a tag of <see paramref="T" />
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    [SkipLocalsInit]
    public readonly struct Tagged<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.HasTag(Tag<T>.ID);
    }
}