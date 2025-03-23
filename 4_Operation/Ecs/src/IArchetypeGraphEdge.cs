using System.Collections.Immutable;
using Alis.Core.Ecs.Core;

/// <summary>
///     The archetype graph edge interface
/// </summary>
internal interface IArchetypeGraphEdge
{
    /// <summary>
    ///     Modifies the tags using the specified tags
    /// </summary>
    /// <param name="tags">The tags</param>
    /// <param name="add">The add</param>
    void ModifyTags(ref ImmutableArray<TagID> tags, bool add);

    /// <summary>
    ///     Modifies the components using the specified components
    /// </summary>
    /// <param name="components">The components</param>
    /// <param name="add">The add</param>
    void ModifyComponents(ref ImmutableArray<ComponentID> components, bool add);
}