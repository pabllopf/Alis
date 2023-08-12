using System;
using System.Diagnostics;

namespace Alis.Core.Graphic.Backends.SDL2
{
    /// <summary>
    /// The point
    /// </summary>
    [DebuggerDisplay("{DebuggerDisplayString,nq}")]
    public struct Point : IEquatable<Point>
    {
        /// <summary>
        /// The 
        /// </summary>
        public int X;
        /// <summary>
        /// The 
        /// </summary>
        public int Y;

        /// <summary>
        /// Initializes a new instance of the <see cref="Point"/> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="other">The other</param>
        /// <returns>The bool</returns>
        public bool Equals(Point other) => X.Equals(other.X) && Y.Equals(other.Y);
        /// <summary>
        /// Describes whether this instance equals
        /// </summary>
        /// <param name="obj">The obj</param>
        /// <returns>The bool</returns>
        public override bool Equals(object obj) => obj is Point p && Equals(p);
        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>The int</returns>
        public override int GetHashCode() => HashHelpersdl2.Combine(X.GetHashCode(), Y.GetHashCode());
        /// <summary>
        /// Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => $"({X}, {Y})";

        public static bool operator ==(Point left, Point right) => left.Equals(right);
        public static bool operator !=(Point left, Point right) => !left.Equals(right);

        /// <summary>
        /// Gets the value of the debugger display string
        /// </summary>
        private string DebuggerDisplayString => ToString();
    }
}
