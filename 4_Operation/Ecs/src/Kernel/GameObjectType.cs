global using ArchetypeID = Alis.Core.Ecs.Kernel.GameObjectType;
using System;
using System.Runtime.InteropServices;
using Alis.Core.Aspect.Math.Collections;
using Alis.Core.Ecs.Kernel.Archetype;
using Alis.Core.Ecs.Kernel.Memory;

namespace Alis.Core.Ecs.Kernel
{
    //This isn't named ArchetypeID because archetypes are an implementation detail
    /// <summary>
    ///     Represents an gameObject's type, or set of component and tag types that make it up
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    
    public struct GameObjectType : IEquatable<ArchetypeID>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="GameObjectType" /> class
        /// </summary>
        /// <param name="id">The id</param>
        internal GameObjectType(ushort id)
        {
            RawIndex = id;
        }

        /// <summary>
        ///     The raw index
        /// </summary>
        internal ushort RawIndex;

        /// <summary>
        ///     The component types
        /// </summary>
        public readonly FastImmutableArray<ComponentId> Types =>
            Kernel.Archetype.Archetype.ArchetypeTable[RawIndex].ComponentTypes;

        /// <summary>
        ///     The tag types
        /// </summary>
        public readonly FastImmutableArray<TagId> Tags => Kernel.Archetype.Archetype.ArchetypeTable[RawIndex].TagTypes;

        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> has a component represented by a <see cref="ComponentId" />
        /// </summary>
        /// <param name="componentId">The ID of the component type to check if this <see cref="GameObjectType" /> has</param>
        /// <returns>
        ///     <see langword="true" /> if this GameObject type has a component of the specified component ID,
        ///     <see langword="false" /> otherwise
        /// </returns>
        public readonly bool HasComponent(ComponentId componentId)
        {
            return GlobalWorldTables.ComponentIndex(this, componentId) != 0;
        }

        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> has a tag represented by a <see cref="TagId" />
        /// </summary>
        /// <param name="tagId">The ID of the tag type to check if this <see cref="GameObjectType" /> has</param>
        /// <returns>
        ///     <see langword="true" /> if this GameObject type has a tag of the specified tag ID, <see langword="false" />
        ///     otherwise
        /// </returns>
        public readonly bool HasTag(TagId tagId)
        {
            return GlobalWorldTables.HasTag(this, tagId);
        }

        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> represents the same ID as <paramref name="other" />
        /// </summary>
        /// <param name="other">The EntityType to compare against</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public readonly bool Equals(GameObjectType other)
        {
            return RawIndex == other.RawIndex;
        }

        /// <summary>
        ///     Checks if this <see cref="GameObjectType" /> represents the same ID as <paramref name="obj" />
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public readonly override bool Equals(object obj)
        {
            return obj is GameObjectType other && Equals(other);
        }

        /// <summary>
        ///     Gets the hash code for this <see cref="GameObjectType" />
        /// </summary>
        /// <returns>An integer hash code representing this <see cref="GameObjectType" /></returns>
        public readonly override int GetHashCode()
        {
            return RawIndex;
        }

        /// <summary>
        ///     Checks if two <see cref="GameObjectType" /> instances represent the same ID
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise</returns>
        public static bool operator ==(GameObjectType left, GameObjectType right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Checks if two <see cref="GameObjectType" /> instances represent different IDs
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true" /> if they represent different IDs, <see langword="false" /> otherwise</returns>
        public static bool operator !=(GameObjectType left, GameObjectType right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Gets an <see cref="GameObjectType" /> without needing an <see cref="GameObject" /> of the specific type.
        /// </summary>
        /// <param name="components">The components the <see cref="GameObjectType" /> should have.</param>
        /// <param name="tags">The tags the <see cref="GameObjectType" /> should have.</param>
        public static GameObjectType EntityTypeOf(ReadOnlySpan<ComponentId> components, ReadOnlySpan<TagId> tags)
        {
            return Kernel.Archetype.Archetype.GetArchetypeId(components, tags);
        }

        /// <summary>
        ///     Archetypes the context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The ref archetype archetype</returns>
        internal readonly ref Archetype.Archetype Archetype(Scene context)
        {
            return ref context.WorldArchetypeTable.UnsafeArrayIndex(RawIndex).Archetype!;
        }
    }
}