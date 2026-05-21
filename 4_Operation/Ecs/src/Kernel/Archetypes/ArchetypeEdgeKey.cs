

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype edge key
    /// </summary>
    /// <remarks>
    ///     Memory layout optimized: 8 bytes total (ArchetypeEdgeType enum 4 bytes + ComponentId 2 bytes + GameObjectType 2
    ///     bytes)
    ///     Field order reordered for optimal packing: enum (4 bytes) -> ComponentId (2 bytes) -> GameObjectType (2 bytes)
    ///     Pack = 1 for minimal memory footprint, fits in 8 bytes (long)
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct ArchetypeEdgeKey : IEquatable<ArchetypeEdgeKey>
    {
        /// <summary>
        ///     The edge type
        /// </summary>
        internal ArchetypeEdgeType EdgeType;

        /// <summary>
        ///     The component id
        /// </summary>
        internal ComponentId ComponentID;

        /// <summary>
        ///     The archetype from
        /// </summary>
        internal GameObjectType ArchetypeFrom;


        /// <summary>
        ///     Components the component id
        /// </summary>
        /// <param name="componentId">The component id</param>
        /// <param name="from">The from</param>
        /// <param name="archetypeEdgeType">The archetype edge type</param>
        /// <returns>The archetype edge key</returns>
        public static ArchetypeEdgeKey Component(ComponentId componentId, GameObjectType from,
            ArchetypeEdgeType archetypeEdgeType)
            => new ArchetypeEdgeKey
            {
                ComponentID = componentId,
                ArchetypeFrom = from,
                EdgeType = archetypeEdgeType
            };

        /// <summary>
        ///     Gets the value of the packed
        /// </summary>
        internal long Packed => Unsafe.As<ArchetypeEdgeKey, long>(ref this);

        /// <summary>
        ///     Equalses the other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(ArchetypeEdgeKey other) => other.Packed == Packed;

        /// <summary>
        ///     Equalses the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is ArchetypeEdgeKey other && Equals(other);

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => Packed.GetHashCode();
    }
}