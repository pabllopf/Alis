

namespace Alis.Core.Ecs.Systems
{
    /// <summary>
    ///     Types of rules.
    /// </summary>
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