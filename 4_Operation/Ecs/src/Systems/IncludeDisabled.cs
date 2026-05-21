

using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should include all entities
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct IncludeDisabled : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.IncludeDisabledRule;
    }
}