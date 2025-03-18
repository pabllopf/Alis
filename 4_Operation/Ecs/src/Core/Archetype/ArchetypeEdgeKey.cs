using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

namespace Frent.Core.Structures;


/// <summary>
/// The archetype edge key
/// </summary>
[StructLayout(LayoutKind.Sequential, Pack = 1)]
internal struct ArchetypeEdgeKey : IEquatable<ArchetypeEdgeKey>
{
    //could be tag type or component type
    /// <summary>
    /// The component id
    /// </summary>
    internal ComponentID ComponentID;
    /// <summary>
    /// The tag id
    /// </summary>
    internal TagID TagID;
    /// <summary>
    /// The archetype from
    /// </summary>
    internal ArchetypeID ArchetypeFrom;
    /// <summary>
    /// The edge type
    /// </summary>
    internal ArchetypeEdgeType EdgeType;

    /// <summary>
    /// Components the component id
    /// </summary>
    /// <param name="componentID">The component id</param>
    /// <param name="from">The from</param>
    /// <param name="archetypeEdgeType">The archetype edge type</param>
    /// <returns>The archetype edge key</returns>
    public static ArchetypeEdgeKey Component(ComponentID componentID, ArchetypeID from, ArchetypeEdgeType archetypeEdgeType) => new()
    {
        ComponentID = componentID,
        ArchetypeFrom = from,
        EdgeType = archetypeEdgeType,
    };

    /// <summary>
    /// Tags the tag id
    /// </summary>
    /// <param name="tagID">The tag id</param>
    /// <param name="from">The from</param>
    /// <param name="archetypeEdgeType">The archetype edge type</param>
    /// <returns>The archetype edge key</returns>
    public static ArchetypeEdgeKey Tag(TagID tagID, ArchetypeID from, ArchetypeEdgeType archetypeEdgeType) => new()
    {
        TagID = tagID,
        ArchetypeFrom = from,
        EdgeType = archetypeEdgeType,
    };

#if NET8_0_OR_GREATER
    internal long Packed => Unsafe.BitCast<ArchetypeEdgeKey, long>(this);
#else
    /// <summary>
    /// Gets the value of the packed
    /// </summary>
    internal long Packed => Unsafe.As<ArchetypeEdgeKey, long>(ref this);
#endif
    /// <summary>
    /// Equalses the other
    /// </summary>
    /// <param name="other">The other</param>
    /// <returns>The bool</returns>
    public bool Equals(ArchetypeEdgeKey other) => other.Packed == Packed;
    /// <summary>
    /// Equalses the obj
    /// </summary>
    /// <param name="obj">The obj</param>
    /// <returns>The bool</returns>
    public override bool Equals(object? obj) => obj is ArchetypeEdgeKey other && Equals(other);
    /// <summary>
    /// Gets the hash code
    /// </summary>
    /// <returns>The int</returns>
    public override int GetHashCode() => Packed.GetHashCode();
}

/// <summary>
/// The archetype edge type enum
/// </summary>
internal enum ArchetypeEdgeType : ushort
{
    /// <summary>
    /// The add component archetype edge type
    /// </summary>
    AddComponent = 49157,
    /// <summary>
    /// The remove component archetype edge type
    /// </summary>
    RemoveComponent = 24593,
    /// <summary>
    /// The add tag archetype edge type
    /// </summary>
    AddTag = 12289,
    /// <summary>
    /// The remove tag archetype edge type
    /// </summary>
    RemoveTag = 6151,
}