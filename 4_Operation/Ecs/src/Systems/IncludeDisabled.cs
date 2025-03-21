using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should include all entities
    /// </summary>
    [StructLayout(LayoutKind.Sequential)]
    public struct IncludeDisabled : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.IncludeDisabledRule;
    }
}