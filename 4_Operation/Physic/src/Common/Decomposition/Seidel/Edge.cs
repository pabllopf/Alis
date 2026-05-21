

using System;
using System.Collections.Generic;

namespace Alis.Core.Physic.Common.Decomposition.Seidel
{
    /// <summary>
    ///     The edge class
    /// </summary>
    internal class Edge
    {
        /// <summary>
        ///     The
        /// </summary>
        public readonly float B;

        /// <summary>
        ///     The points
        /// </summary>
        public readonly HashSet<Point> MPoints;

        /// <summary>
        ///     The
        /// </summary>
        public readonly Point P;

        /// <summary>
        ///     The
        /// </summary>
        public readonly Point Q;

        /// <summary>
        ///     The slope
        /// </summary>
        public readonly float Slope;

        /// <summary>
        ///     The above
        /// </summary>
        public Trapezoid Above;

        /// <summary>
        ///     The below
        /// </summary>
        public Trapezoid Below;


        /// <summary>
        ///     Initializes a new instance of the <see cref="Edge" /> class
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="q">The </param>
        public Edge(Point p, Point q)
        {
            P = p;
            Q = q;

            if (Math.Abs(q.X - p.X) > float.Epsilon)
            {
                Slope = (q.Y - p.Y) / (q.X - p.X);
            }
            else
            {
                Slope = 0;
            }

            B = p.Y - p.X * Slope;
            Above = null;
            Below = null;
            MPoints = new HashSet<Point>();
            MPoints.Add(p);
            MPoints.Add(q);
        }

        /// <summary>
        ///     Describes whether this instance is above
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public bool IsAbove(Point point) => P.Orient2D(Q, point) < 0;

        /// <summary>
        ///     Describes whether this instance is below
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public bool IsBelow(Point point) => P.Orient2D(Q, point) > 0;

        /// <summary>
        ///     Adds the mpoint using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        public void AddMpoint(Point point)
        {
            foreach (Point mp in MPoints)
            {
                if (!mp.Neq(point))
                {
                    return;
                }
            }

            MPoints.Add(point);
        }
    }
}