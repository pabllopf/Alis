

using System;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The point class
    /// </summary>
    internal class Point
    {
        /// <summary>
        ///     The
        /// </summary>
        public readonly float X;

        /// <summary>
        ///     The
        /// </summary>
        public readonly float Y;

        /// <summary>
        ///     The prev
        /// </summary>
        public Point Next, Prev;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Point" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public Point(float x, float y)
        {
            X = x;
            Y = y;
            Next = null;
            Prev = null;
        }
        /// <summary>
        ///     The - operator.
        /// </summary>

        public static Point operator -(Point p1, Point p2) => new Point(p1.X - p2.X, p1.Y - p2.Y);
        /// <summary>
        ///     The + operator.
        /// </summary>

        public static Point operator +(Point p1, Point p2) => new Point(p1.X + p2.X, p1.Y + p2.Y);
        /// <summary>
        ///     The - operator.
        /// </summary>

        public static Point operator -(Point p1, float f) => new Point(p1.X - f, p1.Y - f);
        /// <summary>
        ///     The + operator.
        /// </summary>

        public static Point operator +(Point p1, float f) => new Point(p1.X + f, p1.Y + f);

        /// <summary>
        ///     Crosses the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The float</returns>
        public float Cross(Point p) => X * p.Y - Y * p.X;

        /// <summary>
        ///     Dots the p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The float</returns>
        public float Dot(Point p) => X * p.X + Y * p.Y;

        /// <summary>
        ///     Describes whether this instance neq
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool Neq(Point p) => Math.Abs(p.X - X) > float.Epsilon || Math.Abs(p.Y - Y) > float.Epsilon;

        /// <summary>
        ///     Orients the 2 d using the specified pb
        /// </summary>
        /// <param name="pb">The pb</param>
        /// <param name="pc">The pc</param>
        /// <returns>The float</returns>
        public float Orient2D(Point pb, Point pc)
        {
            float acx = X - pc.X;
            float bcx = pb.X - pc.X;
            float acy = Y - pc.Y;
            float bcy = pb.Y - pc.Y;
            return acx * bcy - acy * bcx;
        }
    }
}