using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Alis.Core.Ecs.Kernel.Archetypes
{
    /// <summary>
    ///     The archetype edge key
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct ArchetypeEdgeKey : IEquatable<ArchetypeEdgeKey>
    {
        //could be tag type or component type
        /// <summary>
        ///     The component id
        /// </summary>
        internal ComponentId ComponentID;

        /// <summary>
        ///     The tag id
        /// </summary>
        internal TagId TagID;

        /// <summary>
        ///     The archetype from
        /// </summary>
        internal GameObjectType ArchetypeFrom;

        /// <summary>
        ///     The edge type
        /// </summary>
        internal ArchetypeEdgeType EdgeType;

        /// <summary>
        ///     Components the component id
        /// </summary>
        /// <param name="componentId">The component id</param>
        /// <param name="from">The from</param>
        /// <param name="archetypeEdgeType">The archetype edge type</param>
        /// <returns>The archetype edge key</returns>
        public static ArchetypeEdgeKey Component(ComponentId componentId, GameObjectType from,
            ArchetypeEdgeType archetypeEdgeType)
        {
            return new ArchetypeEdgeKey
            {
                ComponentID = componentId,
                ArchetypeFrom = from,
                EdgeType = archetypeEdgeType
            };
        }

        /// <summary>
        ///     Tags the tag id
        /// </summary>
        /// <param name="tagId">The tag id</param>
        /// <param name="from">The from</param>
        /// <param name="archetypeEdgeType">The archetype edge type</param>
        /// <returns>The archetype edge key</returns>
        public static ArchetypeEdgeKey Tag(TagId tagId, GameObjectType from, ArchetypeEdgeType archetypeEdgeType)
        {
            return new ArchetypeEdgeKey
            {
                TagID = tagId,
                ArchetypeFrom = from,
                EdgeType = archetypeEdgeType
            };
        }

#if NET8_0_OR_GREATER
        internal long Packed => Unsafe.BitCast<ArchetypeEdgeKey, long>(this);
#else
    /// <summary>
    ///     Gets the value of the packed
    /// </summary>
    internal long Packed => Unsafe.As<ArchetypeEdgeKey, long>(ref this);
#endif
        /// <summary>
        ///     Equalses the other
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(ArchetypeEdgeKey other)
        {
            return other.Packed == Packed;
        }

        /// <summary>
        ///     Equalses the obj
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
        {
            return obj is ArchetypeEdgeKey other && Equals(other);
        }

        /// <summary>
        ///     Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            return Packed.GetHashCode();
        }
    }
}