// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: Trapezoid.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System.Collections.Generic;

namespace Alis.Core.Physic.Tools.Triangulation.Seidel
{
    /// <summary>
    ///     The trapezoid class
    /// </summary>
    internal class Trapezoid
    {
        /// <summary>
        ///     The bottom
        /// </summary>
        public readonly Edge Bottom;

        /// <summary>
        ///     The left point
        /// </summary>
        public readonly Point LeftPoint;

        /// <summary>
        ///     The top
        /// </summary>
        public readonly Edge Top;

        /// <summary>
        ///     The inside
        /// </summary>
        public bool Inside;

        // Neighbor pointers
        /// <summary>
        ///     The lower left
        /// </summary>
        public Trapezoid LowerLeft;

        /// <summary>
        ///     The lower right
        /// </summary>
        public Trapezoid LowerRight;

        /// <summary>
        ///     The right point
        /// </summary>
        public Point RightPoint;

        /// <summary>
        ///     The sink
        /// </summary>
        public Sink Sink;

        /// <summary>
        ///     The upper left
        /// </summary>
        public Trapezoid UpperLeft;

        /// <summary>
        ///     The upper right
        /// </summary>
        public Trapezoid UpperRight;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Trapezoid" /> class
        /// </summary>
        /// <param name="leftPoint">The left point</param>
        /// <param name="rightPoint">The right point</param>
        /// <param name="top">The top</param>
        /// <param name="bottom">The bottom</param>
        public Trapezoid(Point leftPoint, Point rightPoint, Edge top, Edge bottom)
        {
            LeftPoint = leftPoint;
            RightPoint = rightPoint;
            Top = top;
            Bottom = bottom;
            UpperLeft = null;
            UpperRight = null;
            LowerLeft = null;
            LowerRight = null;
            Inside = true;
            Sink = null;
        }

        // Update neighbors to the left
        /// <summary>
        ///     Updates the left using the specified ul
        /// </summary>
        /// <param name="ul">The ul</param>
        /// <param name="ll">The ll</param>
        public void UpdateLeft(Trapezoid ul, Trapezoid ll)
        {
            UpperLeft = ul;
            if (ul != null)
            {
                ul.UpperRight = this;
            }

            LowerLeft = ll;
            if (ll != null)
            {
                ll.LowerRight = this;
            }
        }

        // Update neighbors to the right
        /// <summary>
        ///     Updates the right using the specified ur
        /// </summary>
        /// <param name="ur">The ur</param>
        /// <param name="lr">The lr</param>
        public void UpdateRight(Trapezoid ur, Trapezoid lr)
        {
            UpperRight = ur;
            if (ur != null)
            {
                ur.UpperLeft = this;
            }

            LowerRight = lr;
            if (lr != null)
            {
                lr.LowerLeft = this;
            }
        }

        // Update neighbors on both sides
        /// <summary>
        ///     Updates the left right using the specified ul
        /// </summary>
        /// <param name="ul">The ul</param>
        /// <param name="ll">The ll</param>
        /// <param name="ur">The ur</param>
        /// <param name="lr">The lr</param>
        public void UpdateLeftRight(Trapezoid ul, Trapezoid ll, Trapezoid ur, Trapezoid lr)
        {
            UpperLeft = ul;
            if (ul != null)
            {
                ul.UpperRight = this;
            }

            LowerLeft = ll;
            if (ll != null)
            {
                ll.LowerRight = this;
            }

            UpperRight = ur;
            if (ur != null)
            {
                ur.UpperLeft = this;
            }

            LowerRight = lr;
            if (lr != null)
            {
                lr.LowerLeft = this;
            }
        }

        // Recursively trim outside neighbors
        /// <summary>
        ///     Trims the neighbors
        /// </summary>
        public void TrimNeighbors()
        {
            if (Inside)
            {
                Inside = false;
                if (UpperLeft != null)
                {
                    UpperLeft.TrimNeighbors();
                }

                if (LowerLeft != null)
                {
                    LowerLeft.TrimNeighbors();
                }

                if (UpperRight != null)
                {
                    UpperRight.TrimNeighbors();
                }

                if (LowerRight != null)
                {
                    LowerRight.TrimNeighbors();
                }
            }
        }

        // Determines if this point lies inside the trapezoid
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The bool</returns>
        public bool Contains(Point point) =>
            (point.X > LeftPoint.X) && (point.X < RightPoint.X) && Top.IsAbove(point) &&
            Bottom.IsBelow(point);

        /// <summary>
        ///     Gets the vertices
        /// </summary>
        /// <returns>The verts</returns>
        public List<Point> GetVertices()
        {
            List<Point> verts = new List<Point>(4)
            {
                LineIntersect(Top, LeftPoint.X),
                LineIntersect(Bottom, LeftPoint.X),
                LineIntersect(Bottom, RightPoint.X),
                LineIntersect(Top, RightPoint.X)
            };
            return verts;
        }

        /// <summary>
        ///     Lines the intersect using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        /// <param name="x">The </param>
        /// <returns>The point</returns>
        private Point LineIntersect(Edge edge, float x)
        {
            float y = edge.Slope * x + edge.B;
            return new Point(x, y);
        }

        // Add points to monotone mountain
        /// <summary>
        ///     Adds the points
        /// </summary>
        public void AddPoints()
        {
            if (LeftPoint != Bottom.P)
            {
                Bottom.AddMpoint(LeftPoint);
            }

            if (RightPoint != Bottom.Q)
            {
                Bottom.AddMpoint(RightPoint);
            }

            if (LeftPoint != Top.P)
            {
                Top.AddMpoint(LeftPoint);
            }

            if (RightPoint != Top.Q)
            {
                Top.AddMpoint(RightPoint);
            }
        }
    }
}