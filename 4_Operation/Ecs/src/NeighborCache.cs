using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Collections;
using Alis.Core.Ecs.Kernel;
using Alis.Core.Ecs.Redifinition;

namespace Alis.Core.Ecs
{
    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7, T8> : IArchetypeGraphEdge
    {
        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id, Component<T7>.Id, Component<T8>.Id
                ]);
            }
            else
            {
                components = MemoryHelpers.Remove(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id, Component<T7>.Id, Component<T8>.Id
                ]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T1, T2, T3, T4, T5, T6, T7> : IArchetypeGraphEdge
    {
       
        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id, Component<T7>.Id
                ]);
            }
            else
            {
                components = MemoryHelpers.Remove(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id, Component<T7>.Id
                ]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T1, T2, T3, T4, T5, T6> : IArchetypeGraphEdge
    {
       

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id
                ]);
            }
            else
            {
                components = MemoryHelpers.Remove(components,
                [
                    Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id,
                    Component<T6>.Id
                ]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2, T3, T4, T5> : IArchetypeGraphEdge
    {
       
        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components,
                    [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id]);
            }
            else
            {
                components = MemoryHelpers.Remove(components,
                    [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id, Component<T5>.Id]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T1, T2, T3, T4> : IArchetypeGraphEdge
    {
      
        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components,
                    [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id]);
            }
            else
            {
                components = MemoryHelpers.Remove(components,
                    [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id, Component<T4>.Id]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T1, T2, T3> : IArchetypeGraphEdge
    {
     

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id]);
            }
            else
            {
                components = MemoryHelpers.Remove(components, [Component<T1>.Id, Component<T2>.Id, Component<T3>.Id]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct NeighborCache<T1, T2> : IArchetypeGraphEdge
    {
       
        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, [Component<T1>.Id, Component<T2>.Id]);
            }
            else
            {
                components = MemoryHelpers.Remove(components, [Component<T1>.Id, Component<T2>.Id]);
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

        

        
    }

    /// <summary>
    ///     The neighbor cache
    /// </summary>
    public struct NeighborCache<T> : IArchetypeGraphEdge
    {
        

        /// <summary>
        ///     Modifies the components using the specified components
        /// </summary>
        /// <param name="components">The components</param>
        /// <param name="add">The add</param>
        public void ModifyComponents(ref FastImmutableArray<ComponentId> components, bool add)
        {
            if (add)
            {
                components = MemoryHelpers.Concat(components, Component<T>.Id);
            }
            else
            {
                components = MemoryHelpers.Remove(components, Component<T>.Id);
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

        

        
    }
}