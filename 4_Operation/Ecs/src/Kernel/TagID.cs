using System;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     Represents a specific type as a tag, and can be used for tag related queries
    /// </summary>
    public readonly struct TagId : ITypeId, IEquatable<TagId>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="TagId" /> class
        /// </summary>
        /// <param name="id">The id</param>
        internal TagId(ushort id)
        {
            RawValue = id;
        }

        /// <summary>
        ///     The raw value
        /// </summary>
        internal readonly ushort RawValue;

        /// <summary>
        ///     The type that this TagID represents
        /// </summary>
        public Type Type => Tag.TagTable[RawValue];

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        ushort ITypeId.Value => RawValue;

        /// <summary>
        ///     Checks if this TagID instance represents the same type as <paramref name="other" />
        /// </summary>
        /// <param name="other">The tag to compare against</param>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public readonly bool Equals(TagId other)
        {
            return other.RawValue == RawValue;
        }

        /// <summary>
        ///     Checks if this TagID instance represents the same type as <paramref name="other" />
        /// </summary>
        /// <param name="other">The tag to compare against</param>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public override bool Equals(object other)
        {
            return other is TagId t && RawValue == t.RawValue;
        }

        /// <summary>
        ///     Checks if two <see cref="TagId" />s represent the same type
        /// </summary>
        /// <returns><see langword="true" /> when they represent the same type, <see langword="false" /> otherwise</returns>
        public static bool operator ==(TagId left, TagId right)
        {
            return left.RawValue == right.RawValue;
        }

        /// <summary>
        ///     Checks if two <see cref="TagId" />s represent a different type
        /// </summary>
        /// <returns><see langword="false" /> when they represent the same type, <see langword="true" /> otherwise</returns>
        public static bool operator !=(TagId left, TagId right)
        {
            return left.RawValue != right.RawValue;
        }

        /// <summary>
        ///     Gets the hashcode of this <see cref="TagId" />
        /// </summary>
        /// <returns>A unique code representing the <see cref="TagId" /></returns>
        public override int GetHashCode()
        {
            return RawValue;
        }
    }
}