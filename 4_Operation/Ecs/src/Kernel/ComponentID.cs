using System;

namespace Alis.Core.Ecs.Kernel
{
    /// <summary>
    ///     A lightweight struct that represents a component type. Used for fast lookups.
    /// </summary>
    public readonly struct ComponentId : ITypeId, IEquatable<ComponentId>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="ComponentId" /> class
        /// </summary>
        /// <param name="id">The id</param>
        internal ComponentId(ushort id)
        {
            RawIndex = id;
        }

        /// <summary>
        ///     The raw index
        /// </summary>
        internal readonly ushort RawIndex;

        /// <summary>
        ///     The type of component this <see cref="ComponentId" /> represents.
        /// </summary>
        public Type Type => Component.ComponentTable[RawIndex].Type;

        /// <summary>
        ///     Gets the value of the value
        /// </summary>
        ushort ITypeId.Value => RawIndex;

        /// <summary>
        ///     Checks if this <see cref="ComponentId" /> instance represents the same ID as <paramref name="other" />.
        /// </summary>
        /// <param name="other">The <see cref="ComponentId" /> to compare against.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public bool Equals(ComponentId other)
        {
            return RawIndex == other.RawIndex;
        }

        /// <summary>
        ///     Checks if this <see cref="ComponentId" /> instance represents the same ID as <paramref name="obj" />.
        /// </summary>
        /// <param name="obj">The object to compare against.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public override bool Equals(object obj)
        {
            return obj is ComponentId other && Equals(other);
        }

        /// <summary>
        ///     Gets the hash code for this <see cref="ComponentId" />.
        /// </summary>
        /// <returns>An integer hash code representing this <see cref="ComponentId" />.</returns>
        public override int GetHashCode()
        {
            return RawIndex;
        }

        /// <summary>
        ///     Checks if two <see cref="ComponentId" /> instances represent the same ID.
        /// </summary>
        /// <param name="left">The first <see cref="ComponentId" />.</param>
        /// <param name="right">The second <see cref="ComponentId" />.</param>
        /// <returns><see langword="true" /> if they represent the same ID, <see langword="false" /> otherwise.</returns>
        public static bool operator ==(ComponentId left, ComponentId right)
        {
            return left.Equals(right);
        }

        /// <summary>
        ///     Checks if two <see cref="ComponentId" /> instances represent different IDs.
        /// </summary>
        /// <param name="left">The first <see cref="ComponentId" />.</param>
        /// <param name="right">The second <see cref="ComponentId" />.</param>
        /// <returns><see langword="true" /> if they represent different IDs, <see langword="false" /> otherwise.</returns>
        public static bool operator !=(ComponentId left, ComponentId right)
        {
            return !left.Equals(right);
        }

        /// <summary>
        ///     Gets the value of the debugger display string
        /// </summary>
        internal string DebuggerDisplayString => $"Types: {Type} ID: {RawIndex}";
    }
}