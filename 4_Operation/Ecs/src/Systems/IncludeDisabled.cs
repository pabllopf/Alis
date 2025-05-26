namespace Alis.Core.Ecs.Systems;

/// <summary>
///     Specifies a query should include all entities
/// </summary>
public struct IncludeDisabled : IRuleProvider
{
    /// <summary>
    ///     The rule.
    /// </summary>
    public Rule Rule => Rule.IncludeDisabledRule;
}