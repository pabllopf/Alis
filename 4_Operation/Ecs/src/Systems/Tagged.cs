using Alis.Core.Ecs.Core;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Specifies a query should have a tag of <see paramref="T" />
    /// </summary>
    public struct Tagged<T> : IRuleProvider
    {
        /// <summary>
        ///     The rule.
        /// </summary>
        public Rule Rule => Rule.HasTag(Tag<T>.ID);
    }
}