// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TrapezoidalMap.cs
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

namespace Alis.Extension.Math.PathGenerator.Triangulation.Seidel
{
    /// <summary>
    ///     The trapezoidal map class
    /// </summary>
    internal class TrapezoidalMap
    {
        // Trapezoid container
        /// <summary>
        ///     The map
        /// </summary>
        public readonly HashSet<Trapezoid> Map;
        
        // AABB margin
        /// <summary>
        ///     The margin
        /// </summary>
        private readonly float margin;
        
        // Bottom segment that spans multiple trapezoids
        /// <summary>
        ///     The cross
        /// </summary>
        private Edge bCross;
        
        // Top segment that spans multiple trapezoids
        /// <summary>
        ///     The cross
        /// </summary>
        private Edge cross;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="TrapezoidalMap" /> class
        /// </summary>
        public TrapezoidalMap()
        {
            Map = new HashSet<Trapezoid>();
            margin = 50.0f;
            bCross = null;
            cross = null;
        }
        
        /// <summary>
        ///     Clears this instance
        /// </summary>
        public void Clear()
        {
            bCross = null;
            cross = null;
        }
        
        // Case 1: segment completely enclosed by trapezoid
        //         break trapezoid into 4 smaller trapezoids
        /// <summary>
        ///     Cases the 1 using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="e">The </param>
        /// <returns>The trapezoids</returns>
        public Trapezoid[] Case1(Trapezoid t, Edge e)
        {
            Trapezoid[] trapezoids = new Trapezoid[4];
            trapezoids[0] = new Trapezoid(t.LeftPoint, e.P, t.Top, t.Bottom);
            trapezoids[1] = new Trapezoid(e.P, e.Q, t.Top, e);
            trapezoids[2] = new Trapezoid(e.P, e.Q, e, t.Bottom);
            trapezoids[3] = new Trapezoid(e.Q, t.RightPoint, t.Top, t.Bottom);
            
            trapezoids[0].UpdateLeft(t.UpperLeft, t.LowerLeft);
            trapezoids[1].UpdateLeftRight(trapezoids[0], null, trapezoids[3], null);
            trapezoids[2].UpdateLeftRight(null, trapezoids[0], null, trapezoids[3]);
            trapezoids[3].UpdateRight(t.UpperRight, t.LowerRight);
            
            return trapezoids;
        }
        
        // Case 2: Trapezoid contains point p, q lies outside
        //         break trapezoid into 3 smaller trapezoids
        /// <summary>
        ///     Cases the 2 using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="e">The </param>
        /// <returns>The trapezoids</returns>
        public Trapezoid[] Case2(Trapezoid t, Edge e)
        {
            Point rp = System.Math.Abs(e.Q.X - t.RightPoint.X) < 0.01f ? e.Q : t.RightPoint;
            
            Trapezoid[] trapezoids = new Trapezoid[3];
            trapezoids[0] = new Trapezoid(t.LeftPoint, e.P, t.Top, t.Bottom);
            trapezoids[1] = new Trapezoid(e.P, rp, t.Top, e);
            trapezoids[2] = new Trapezoid(e.P, rp, e, t.Bottom);
            
            trapezoids[0].UpdateLeft(t.UpperLeft, t.LowerLeft);
            trapezoids[1].UpdateLeftRight(trapezoids[0], null, t.UpperRight, null);
            trapezoids[2].UpdateLeftRight(null, trapezoids[0], null, t.LowerRight);
            
            bCross = t.Bottom;
            cross = t.Top;
            
            e.Above = trapezoids[1];
            e.Below = trapezoids[2];
            
            return trapezoids;
        }
        
        // Case 3: Trapezoid is bisected
        /// <summary>
        ///     Cases the 3 using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="e">The </param>
        /// <returns>The trapezoids</returns>
        public Trapezoid[] Case3(Trapezoid t, Edge e)
        {
            Point lp = System.Math.Abs(e.P.X - t.LeftPoint.X) < 0.01f ? e.P : t.LeftPoint;
            
            Point rp = System.Math.Abs(e.Q.X - t.RightPoint.X) < 0.01f ? e.Q : t.RightPoint;
            
            Trapezoid[] trapezoids = new Trapezoid[2];
            
            if (cross == t.Top)
            {
                trapezoids[0] = t.UpperLeft;
                trapezoids[0].UpdateRight(t.UpperRight, null);
                trapezoids[0].RightPoint = rp;
            }
            else
            {
                trapezoids[0] = new Trapezoid(lp, rp, t.Top, e);
                trapezoids[0].UpdateLeftRight(t.UpperLeft, e.Above, t.UpperRight, null);
            }
            
            if (bCross == t.Bottom)
            {
                trapezoids[1] = t.LowerLeft;
                trapezoids[1].UpdateRight(null, t.LowerRight);
                trapezoids[1].RightPoint = rp;
            }
            else
            {
                trapezoids[1] = new Trapezoid(lp, rp, e, t.Bottom);
                trapezoids[1].UpdateLeftRight(e.Below, t.LowerLeft, null, t.LowerRight);
            }
            
            bCross = t.Bottom;
            cross = t.Top;
            
            e.Above = trapezoids[0];
            e.Below = trapezoids[1];
            
            return trapezoids;
        }
        
        // Case 4: Trapezoid contains point q, p lies outside
        //         break trapezoid into 3 smaller trapezoids
        /// <summary>
        ///     Cases the 4 using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="e">The </param>
        /// <returns>The trapezoids</returns>
        public Trapezoid[] Case4(Trapezoid t, Edge e)
        {
            Point lp = System.Math.Abs(e.P.X - t.LeftPoint.X) < 0.01f ? e.P : t.LeftPoint;
            
            Trapezoid[] trapezoids = new Trapezoid[3];
            
            if (cross == t.Top)
            {
                trapezoids[0] = t.UpperLeft;
                trapezoids[0].RightPoint = e.Q;
            }
            else
            {
                trapezoids[0] = new Trapezoid(lp, e.Q, t.Top, e);
                trapezoids[0].UpdateLeft(t.UpperLeft, e.Above);
            }
            
            if (bCross == t.Bottom)
            {
                trapezoids[1] = t.LowerLeft;
                trapezoids[1].RightPoint = e.Q;
            }
            else
            {
                trapezoids[1] = new Trapezoid(lp, e.Q, e, t.Bottom);
                trapezoids[1].UpdateLeft(e.Below, t.LowerLeft);
            }
            
            trapezoids[2] = new Trapezoid(e.Q, t.RightPoint, t.Top, t.Bottom);
            trapezoids[2].UpdateLeftRight(trapezoids[0], trapezoids[1], t.UpperRight, t.LowerRight);
            
            return trapezoids;
        }
        
        /// <summary>
        ///     Bound the box using the specified edges
        /// </summary>
        /// <param name="edges">The edges</param>
        /// <returns>The trapezoid</returns>
        public Trapezoid BoundingBox(List<Edge> edges)
        {
            Point max = CalculateMaxPoint(edges);
            Point min = CalculateMinPoint(edges);
            
            Edge top = new Edge(new Point(min.X, max.Y), new Point(max.X, max.Y));
            Edge bottom = new Edge(new Point(min.X, min.Y), new Point(max.X, min.Y));
            Point left = bottom.P;
            Point right = top.Q;
            
            return new Trapezoid(left, right, top, bottom);
        }
        
        /// <summary>
        ///     Calculates the max point using the specified edges
        /// </summary>
        /// <param name="edges">The edges</param>
        /// <returns>The max</returns>
        private Point CalculateMaxPoint(List<Edge> edges)
        {
            Point max = edges[0].P + margin;
            
            foreach (Edge e in edges)
            {
                max = UpdateMaxPoint(max, e.P);
                max = UpdateMaxPoint(max, e.Q);
            }
            
            return max;
        }
        
        /// <summary>
        ///     Calculates the min point using the specified edges
        /// </summary>
        /// <param name="edges">The edges</param>
        /// <returns>The min</returns>
        private Point CalculateMinPoint(List<Edge> edges)
        {
            Point min = edges[0].Q - margin;
            
            foreach (Edge e in edges)
            {
                min = UpdateMinPoint(min, e.P);
                min = UpdateMinPoint(min, e.Q);
            }
            
            return min;
        }
        
        /// <summary>
        ///     Updates the max point using the specified current max
        /// </summary>
        /// <param name="currentMax">The current max</param>
        /// <param name="point">The point</param>
        /// <returns>The point</returns>
        private Point UpdateMaxPoint(Point currentMax, Point point)
        {
            double newX = System.Math.Max(currentMax.X, point.X);
            double newY = System.Math.Max(currentMax.Y, point.Y);
            return new Point((float) (newX + margin), (float) newY);
        }
        
        /// <summary>
        ///     Updates the min point using the specified current min
        /// </summary>
        /// <param name="currentMin">The current min</param>
        /// <param name="point">The point</param>
        /// <returns>The point</returns>
        private Point UpdateMinPoint(Point currentMin, Point point)
        {
            double newX = System.Math.Min(currentMin.X, point.X);
            double newY = System.Math.Min(currentMin.Y, point.Y);
            return new Point((float) (newX - margin), (float) newY);
        }
    }
}