using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should not have a tag of <see paramref="T" />
    /// </summary>
    public struct Untagged<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.NotTag(Tag<T>.ID);
    }
}