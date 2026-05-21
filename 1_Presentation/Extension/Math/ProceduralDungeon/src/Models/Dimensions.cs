

using System;
using Alis.Core.Aspect.Data.Json;
using HashCode = Alis.Core.Aspect.Math.HashCode;

namespace Alis.Extension.Math.ProceduralDungeon.Models
{
    /// <summary>
    ///     Represents 2D dimensions with width and height.
    ///     This immutable value type encapsulates size information.
    /// </summary>
    /// <remarks>
    ///     Dimensions is implemented as a readonly struct for performance and immutability.
    ///     It ensures that width and height are always positive values.
    /// </remarks>
    public readonly partial struct Dimensions : IEquatable<Dimensions>
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="Dimensions" /> struct.
        /// </summary>
        /// <param name="width">The width value.</param>
        /// <param name="height">The height value.</param>
        /// <exception cref="ArgumentException">Thrown when width or height is not positive.</exception>
        public Dimensions(int width, int height)
        {
            if (width <= 0)
            {
                throw new ArgumentException("Width must be greater than 0.", nameof(width));
            }

            if (height <= 0)
            {
                throw new ArgumentException("Height must be greater than 0.", nameof(height));
            }

            Width = width;
            Height = height;
        }

        /// <summary>
        ///     Gets the width.
        /// </summary>
        [JsonNativePropertyName("width")]
        public int Width { get; }

        /// <summary>
        ///     Gets the height.
        /// </summary>
        [JsonNativePropertyName("height")]
        public int Height { get; }

        /// <summary>
        ///     Gets the area (width * height).
        /// </summary>
        public int Area => Width * Height;

        /// <summary>
        ///     Determines whether two dimensions are equal.
        /// </summary>
        /// <param name="left">The first dimensions.</param>
        /// <param name="right">The second dimensions.</param>
        /// <returns>True if both dimensions are equal; otherwise, false.</returns>
        public static bool operator ==(Dimensions left, Dimensions right) => left.Equals(right);

        /// <summary>
        ///     Determines whether two dimensions are not equal.
        /// </summary>
        /// <param name="left">The first dimensions.</param>
        /// <param name="right">The second dimensions.</param>
        /// <returns>True if dimensions are not equal; otherwise, false.</returns>
        public static bool operator !=(Dimensions left, Dimensions right) => !left.Equals(right);

        /// <summary>
        ///     Determines whether the specified dimensions are equal to this instance.
        /// </summary>
        /// <param name="other">The other dimensions to compare with this instance.</param>
        /// <returns>True if the specified dimensions are equal to this instance; otherwise, false.</returns>
        public bool Equals(Dimensions other) => (Width == other.Width) && (Height == other.Height);

        /// <summary>
        ///     Determines whether the specified object is equal to this instance.
        /// </summary>
        /// <param name="obj">The object to compare with this instance.</param>
        /// <returns>True if the specified object is equal to this instance; otherwise, false.</returns>
        public override bool Equals(object obj) => obj is Dimensions other && Equals(other);

        /// <summary>
        ///     Returns a hash code for this instance.
        /// </summary>
        /// <returns>A hash code for this instance.</returns>
        public override int GetHashCode() => HashCode.Combine(Width, Height);

        /// <summary>
        ///     Returns a string representation of these dimensions.
        /// </summary>
        /// <returns>A string in the format "Width x Height".</returns>
        public override string ToString() => $"{Width} x {Height}";

        /// <summary>
        ///     Determines whether these dimensions can contain the other dimensions.
        /// </summary>
        /// <param name="other">The other dimensions to check.</param>
        /// <returns>True if these dimensions can contain the other; otherwise, false.</returns>
        public bool CanContain(Dimensions other) => (Width >= other.Width) && (Height >= other.Height);
    }
}