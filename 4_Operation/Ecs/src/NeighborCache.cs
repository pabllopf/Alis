using System.Runtime.InteropServices;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Memory;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The neighbor cache
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NeighborCache<T> : IArchetypeGraphEdge
    {
        /// <summary>
        ///     Modifies the tags using the specified tags
        /// </summary>
        /// <param name="tags">The tags</param>
        /// <param name="add">The add</param>
        public void ModifyTags(ref FastImmutableArray<TagId> tags, bool add)
        {
            if (add)
            {
                tags = MemoryHelpers.Concat(tags, Tag<T>.ID);
            }
            else
            {
                tags = MemoryHelpers.Remove(tags, Tag<T>.ID);
            }
        }

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentID> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, Component<T>.ID);
            }
            else
            {
                components = MemoryHelpers.Remove(components, Component<T>.ID);
            }
        }

        //separate into individual classes to avoid creating uneccecary static classes.

        /// <summary>
        ///     The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The tag class
        /// </summary>
        internal static class Tag
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        ///     The detach class
        /// </summary>
        internal static class Detach
        {
            /// <summary>
            ///     The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }
    }
}