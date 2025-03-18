global using ArchetypeID = Frent.Core.EntityType;
using System;
using Frent.Core.Structures;
using System.Collections.Immutable;

namespace Frent.Core
{
    //This isn't named ArchetypeID because archetypes are an implementation detail
    /// <summary>
    /// Represents an entity's type, or set of component and tag types that make it up
    /// </summary>
    public struct EntityType : IEquatable<ArchetypeID>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityType"/> class
        /// </summary>
        /// <param name="id">The id</param>
        internal EntityType(ushort id) => RawIndex = id;
        /// <summary>
        /// The raw index
        /// </summary>
        internal ushort RawIndex;

        /// <summary>
        /// The component types
        /// </summary>
        public readonly ImmutableArray<ComponentID> Types => Core.Archetype.ArchetypeTable[RawIndex].ComponentTypes;

        /// <summary>
        /// The tag types
        /// </summary>
        public readonly ImmutableArray<TagID> Tags => Core.Archetype.ArchetypeTable[RawIndex].TagTypes;

        /// <summary>
        /// Checks if this <see cref="EntityType"/> has a component represented by a <see cref="ComponentID"/>
        /// </summary>
        /// <param name="componentID">The ID of the component type to check if this <see cref="EntityType"/> has</param>
        /// <returns><see langword="true"/> if this Entity type has a component of the specified component ID, <see langword="false"/> otherwise</returns>
        public readonly bool HasComponent(ComponentID componentID) => GlobalWorldTables.ComponentIndex(this, componentID) != 0;

        /// <summary>
        /// Checks if this <see cref="EntityType"/> has a tag represented by a <see cref="TagID"/>
        /// </summary>
        /// <param name="tagID">The ID of the tag type to check if this <see cref="EntityType"/> has</param>
        /// <returns><see langword="true"/> if this Entity type has a tag of the specified tag ID, <see langword="false"/> otherwise</returns>
        public readonly bool HasTag(TagID tagID) => GlobalWorldTables.HasTag(this, tagID);

        /// <summary>
        /// Checks if this <see cref="EntityType"/> represents the same ID as <paramref name="other"/>
        /// </summary>
        /// <param name="other">The EntityType to compare against</param>
        /// <returns><see langword="true"/> if they represent the same ID, <see langword="false"/> otherwise</returns>
        public readonly bool Equals(EntityType other) => RawIndex == other.RawIndex;

        /// <summary>
        /// Checks if this <see cref="EntityType"/> represents the same ID as <paramref name="obj"/>
        /// </summary>
        /// <param name="obj">The object to compare against</param>
        /// <returns><see langword="true"/> if they represent the same ID, <see langword="false"/> otherwise</returns>
        public override readonly bool Equals(object? obj) => obj is EntityType other && Equals(other);

        /// <summary>
        /// Gets the hash code for this <see cref="EntityType"/>
        /// </summary>
        /// <returns>An integer hash code representing this <see cref="EntityType"/></returns>
        public override readonly int GetHashCode() => RawIndex;

        /// <summary>
        /// Checks if two <see cref="EntityType"/> instances represent the same ID
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true"/> if they represent the same ID, <see langword="false"/> otherwise</returns>
        public static bool operator ==(EntityType left, EntityType right) => left.Equals(right);

        /// <summary>
        /// Checks if two <see cref="EntityType"/> instances represent different IDs
        /// </summary>
        /// <param name="left">The first EntityType</param>
        /// <param name="right">The second EntityType</param>
        /// <returns><see langword="true"/> if they represent different IDs, <see langword="false"/> otherwise</returns>
        public static bool operator !=(EntityType left, EntityType right) => !left.Equals(right);

        /// <summary>
        /// Archetypes the context
        /// </summary>
        /// <param name="context">The context</param>
        /// <returns>The ref archetype</returns>
        internal readonly ref Archetype Archetype(World context) => ref context.WorldArchetypeTable.UnsafeArrayIndex(RawIndex);
    }
}