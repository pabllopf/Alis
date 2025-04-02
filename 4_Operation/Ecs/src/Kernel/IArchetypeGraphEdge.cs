using Alis.Core.Ecs.Kernel.Collections;

namespace Alis.Core.Ecs.Kernel
{
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
        void ModifyTags(ref FastImmutableArray<TagId> tags, bool add);

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        void ModifyComponents(ref FastImmutableArray<ComponentID> components, bool add);
    }
}