// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Edge.cs
// 
//  Author:Pablo Perdomo Falcón
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
    ///     The edge class
    /// </summary>
    internal class Edge
    {
        // Pointers used for building trapezoidal map
        /// <summary>
        ///     The above
        /// </summary>
        public Trapezoid Above;

        /// <summary>
        ///     The
        /// </summary>
        public float B;

        /// <summary>
        ///     The below
        /// </summary>
        public Trapezoid Below;

        // Montone mountain points
        /// <summary>
        ///     The points
        /// </summary>
        public HashSet<Point> MPoints;

        /// <summary>
        ///     The
        /// </summary>
        public Point P;

        /// <summary>
        ///     The
        /// </summary>
        public Point Q;

        // Slope of the line (m)
        /// <summary>
        ///     The slope
        /// </summary>
        public float Slope;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Edge" /> class
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="q">The </param>
        public Edge(Point p, Point q)
        {
            P = p;
            Q = q;

            if (q.X - p.X != 0)
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
            MPoints = new HashSet<Point>
            {
                p,
                q
            };
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