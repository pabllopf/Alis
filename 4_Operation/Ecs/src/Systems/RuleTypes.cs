using System;

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Types of rules.
    /// </summary>
    [Obsolete("This is unused.")]
    public enum RuleTypes
    {
        /// <summary>
        ///     Indicates an gameObject must have a component or tag.
        /// </summary>
        Have,

        /// <summary>
        ///     Indicates an gameObject must not have a component or tag.
        /// </summary>
        DoesNotHave
    }
}