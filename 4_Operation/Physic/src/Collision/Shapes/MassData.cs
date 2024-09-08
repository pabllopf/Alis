using System;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Collision.Shapes
{
    /// <summary>
    ///     This holds the mass data computed for a shape.
    /// </summary>
    public struct MassData : IEquatable<MassData>
    {
        /// <summary>
        ///     The area of the shape
        /// </summary>
        public float Area { get; internal set; }

        /// <summary>
        ///     The position of the shape's centroid relative to the shape's origin.
        /// </summary>
        public Vector2 Centroid { get; internal set; }

        /// <summary>
        ///     The rotational inertia of the shape about the local origin.
        /// </summary>
        public float Inertia { get; internal set; }

        /// <summary>
        ///     The mass of the shape, usually in kilograms.
        /// </summary>
        public float Mass { get; internal set; }

        /// <summary>
        ///     The equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator ==(MassData left, MassData right) => (Math.Abs(left.Area - right.Area) < Settings.Epsilon) && (Math.Abs(left.Mass - right.Mass) < Settings.Epsilon) && (left.Centroid == right.Centroid) && (Math.Abs(left.Inertia - right.Inertia) < Settings.Epsilon);

        /// <summary>
        ///     The not equal operator
        /// </summary>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static bool operator !=(MassData left, MassData right) => !(left == right);

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(MassData other) => this == other;

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj))
                return false;

            if (obj.GetType() != typeof(MassData))
                return false;

            return Equals((MassData) obj);
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode()
        {
            unchecked
            {
                int result = Area.GetHashCode();
                result = (result * 397) ^ Centroid.GetHashCode();
                result = (result * 397) ^ Inertia.GetHashCode();
                result = (result * 397) ^ Mass.GetHashCode();
                return result;
            }
        }
    }
}