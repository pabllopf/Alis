// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ChainHull.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.ConvexHull
{
    /// <summary>
    ///     Andrew's Monotone Chain Convex Hull algorithm.
    ///     Used to get the convex hull of a point cloud.
    ///     Source: http://www.softsurfer.com/Archive/algorithm_0109/algorithm_0109.htm
    /// </summary>
    public static class ChainHull
    {
        /// <summary>
        ///     The point comparer
        /// </summary>
        private static readonly PointComparer PointComparer = new PointComparer();

        /// <summary>
        ///     Returns the convex hull from the given vertices..
        /// </summary>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            Vertices pointSet = new Vertices(vertices);

            //Sort by X-axis
            pointSet.Sort(PointComparer);

            Vector2F[] h = new Vector2F[pointSet.Count];
            Vertices res;

            int top = -1; // indices for bottom and top of the stack
            int i; // array scan index

            // Get the indices of points with min x-coord and min|max y-coord
            const int minmin = 0;
            float xmin = pointSet[0].X;
            for (i = 1; i < pointSet.Count; i++)
            {
                if (Math.Abs(pointSet[i].X - xmin) > float.Epsilon)
                {
                    break;
                }
            }

            // degenerate case: all x-coords == xmin
            int minmax = i - 1;
            if (minmax == pointSet.Count - 1)
            {
                h[++top] = pointSet[minmin];

                if (Math.Abs(pointSet[minmax].Y - pointSet[minmin].Y) > float.Epsilon) // a nontrivial segment
                {
                    h[++top] = pointSet[minmax];
                }

                h[++top] = pointSet[minmin]; // add polygon endpoint

                res = new Vertices(top + 1);
                for (int j = 0; j < top + 1; j++)
                {
                    res.Add(h[j]);
                }

                return res;
            }

            top = -1;

            // Get the indices of points with max x-coord and min|max y-coord
            int maxmax = pointSet.Count - 1;
            float xmax = pointSet[pointSet.Count - 1].X;
            for (i = pointSet.Count - 2; i >= 0; i--)
            {
                if (Math.Abs(pointSet[i].X - xmax) > float.Epsilon)
                {
                    break;
                }
            }

            int maxmin = i + 1;

            // Compute the lower hull on the stack H
            h[++top] = pointSet[minmin]; // push minmin point onto stack
            i = minmax;
            while (++i <= maxmin)
            {
                // the lower line joins P[minmin] with P[maxmin]
                if ((MathUtils.Area(pointSet[minmin], pointSet[maxmin], pointSet[i]) >= 0) && (i < maxmin))
                {
                    continue; // ignore P[i] above or on the lower line
                }

                while (top > 0) // there are at least 2 points on the stack
                {
                    // test if P[i] is left of the line at the stack top
                    if (MathUtils.Area(h[top - 1], h[top], pointSet[i]) > 0)
                    {
                        break; // P[i] is a new hull vertex
                    }

                    top--; // pop top point off stack
                }

                h[++top] = pointSet[i]; // push P[i] onto stack
            }

            // Next, compute the upper hull on the stack H above the bottom hull
            if (maxmax != maxmin) // if distinct xmax points
            {
                h[++top] = pointSet[maxmax]; // push maxmax point onto stack
            }

            int bot = top;
            i = maxmin;
            while (--i >= minmax)
            {
                // the upper line joins P[maxmax] with P[minmax]
                if ((MathUtils.Area(pointSet[maxmax], pointSet[minmax], pointSet[i]) >= 0) && (i > minmax))
                {
                    continue; // ignore P[i] below or on the upper line
                }

                while (top > bot) // at least 2 points on the upper stack
                {
                    // test if P[i] is left of the line at the stack top
                    if (MathUtils.Area(h[top - 1], h[top], pointSet[i]) > 0)
                    {
                        break; // P[i] is a new hull vertex
                    }

                    top--; // pop top point off stack
                }

                h[++top] = pointSet[i]; // push P[i] onto stack
            }

            if (minmax != minmin)
            {
                h[++top] = pointSet[minmin]; // push joining endpoint onto stack
            }

            res = new Vertices(top + 1);

            for (int j = 0; j < top + 1; j++)
            {
                res.Add(h[j]);
            }

            return res;
        }
    }
}