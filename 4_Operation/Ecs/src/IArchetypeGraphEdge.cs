

using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     Defines an interface for modifying component lists during archetype graph traversal.
    /// </summary>
    /// <remarks>
    ///     This internal interface is used by the archetype graph to add or remove components
    ///     when entities are created with or without specific component types. Implementations
    ///     represent edges in the archetype graph that connect archetypes differing by one component.
    /// </remarks>
    internal interface IArchetypeGraphEdge
    {
        /// <summary>
        ///     Modifies the component list by either adding or removing a component type.
        /// </summary>
        /// <param name="components">A reference to the list of component IDs that will be modified in place.</param>
        /// <param name="add">
        ///     <see langword="true"/> to add the component represented by this edge;
        ///     <see langword="false"/> to remove it.
        /// </param>
        void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add);
    }
}