using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs
{
    /// <summary>
    /// The neighbor cache core class
    /// </summary>
    internal static class NeighborCacheCore
    {
        /// <summary>
        /// Modifies the components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="ids">The ids</param>
        /// <param name="add">The add</param>
        /// <returns>A fast immutable array of component id</returns>
        public static FastImmutableArray<ComponentId> Modify(
            FastImmutableArray<ComponentId> components,
            ReadOnlySpan<ComponentId> ids,
            bool add)
            => add
                ? MemoryHelpers.Concat(components, ids)
                : MemoryHelpers.Remove(components, ids);
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values = [Component<T1>.Id];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values = [Component<T1>.Id, Component<T2>.Id];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values = [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                Component<T6>.Id
            ];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                Component<T6>.Id, Component<T7>.Id
            ];
    }

    /// <summary>
    /// The neighbor cache component ids class
    /// </summary>
    internal static class NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7, T8>
    {
        /// <summary>
        /// The id
        /// </summary>
        internal static readonly ComponentId[] Values =
            [
                Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                Component<T6>.Id, Component<T7>.Id, Component<T8>.Id
            ];
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7, T8>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6, T7>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5, T6> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5, T6>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4, T5>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3, T4>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2, T3>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T1, T2>.Values, add);
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: Empty struct, 1 byte (C# minimum)
    ///     Pack = 1 for minimal memory footprint
    ///     All logic is in static nested classes
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T> : IArchetypeGraphEdge
    {
        /// <summary>
        /// The add class
        /// </summary>
        internal static class Add
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// The remove class
        /// </summary>
        internal static class Remove
        {
            /// <summary>
            /// The lookup
            /// </summary>
            internal static ArchetypeNeighborCache Lookup;
        }

        /// <summary>
        /// Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
            => components = NeighborCacheCore.Modify(components, NeighborCacheComponentIds<T>.Values, add);
    }
}