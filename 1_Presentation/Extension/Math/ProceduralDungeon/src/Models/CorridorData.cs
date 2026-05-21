

using System;
using Alis.Core.Aspect.Data.Json;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents the data structure for a corridor in the dungeon.
    ///     This is an immutable data structure that holds corridor information.
    /// </summary>
    [Serializable]
    public readonly partial struct CorridorData : IEquatable<CorridorData>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="CorridorData" /> struct.
        /// </summary>
        /// <param name="xPos">The x position of the corridor on the board.</param>
        /// <param name="yPos">The y position of the corridor on the board.</param>
        /// <param name="width">The width of the corridor.</param>
        /// <param name="height">The height of the corridor.</param>
        /// <param name="direction">The direction the corridor is facing.</param>
        public CorridorData(int xPos, int yPos, int width, int height, Direction direction)
        {
            XPos = xPos;
            YPos = yPos;
            Width = width;
            Height = height;
            Direction = direction;
        }

        /// <summary>
        ///     Gets the x position of the corridor on the board.
        /// </summary>
        [JsonNativePropertyName("xPos")]
        public int XPos { get; }

        /// <summary>
        ///     Gets the y position of the corridor on the board.
        /// </summary>
        [JsonNativePropertyName("yPos")]
        public int YPos { get; }

        /// <summary>
        ///     Gets the width of the corridor.
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; }

        /// <summary>
        ///     Gets the height of the corridor.
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; }

        /// <summary>
        ///     Gets the direction the corridor is facing.
        ///     This indicates the direction from the room it connects.
        /// </summary>
        [JsonNativePropertyName("direction")]
        public Direction Direction { get; }

        /// <summary>
        ///     Determines whether the specified <see cref="CorridorData" /> is equal to this instance.
        /// </summary>
        /// <param name="other">The other corridor data to compare with this instance.</param>
        /// <returns>True if the specified corridor data is equal to this instance; otherwise, false.</returns>
        public bool Equals(CorridorData other) => (XPos == other.XPos) &&
                                                  (YPos == other.YPos) &&
                                                  (Width == other.Width) &&
                                                  (Height == other.Height) &&
                                                  (Direction == other.Direction);

        /// <summary>
        ///     Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>True if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj) => obj is CorridorData other && Equals(other);

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode() => HashCode.Combine(XPos, YPos, Width, Height, Direction);

        /// <summary>
        ///     Equality operator for comparing two corridor data instances.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True if both instances are equal; otherwise, false.</returns>
        public static bool operator ==(CorridorData left, CorridorData right) => left.Equals(right);

        /// <summary>
        ///     Inequality operator for comparing two corridor data instances.
        /// </summary>
        /// <param name="left">The left operand.</param>
        /// <param name="right">The right operand.</param>
        /// <returns>True if both instances are not equal; otherwise, false.</returns>
        public static bool operator !=(CorridorData left, CorridorData right) => !left.Equals(right);
    }
}