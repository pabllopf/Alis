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
using Alis.Core.Physic.Shared;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.ConvexHull
{
    /// <summary>
    ///     Andrew's Monotone Chain Convex Hull algorithm. Used to get the convex hull of a point cloud.
    /// </summary>
    public static class ChainHull
    {
        /// <summary>
        ///     The point comparer
        /// </summary>
        private static readonly PointComparer PointComparerPrivate = new PointComparer();

        /// <summary>Returns the convex hull from the given vertices..</summary>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            Vertices pointSet = new Vertices(vertices);

            //Sort by X-axis
            pointSet.Sort(PointComparerPrivate);

            Vector2[] h = new Vector2[pointSet.Count];
            Vertices res;

            int top = -1; // indices for bottom and top of the stack
            int i; // array scan index

            // Get the indices of points with min x-coord and min|max y-coord
            const int minMin = 0;
            float xMin = pointSet[0].X;
            for (i = 1; i < pointSet.Count; i++)
            {
                if (Math.Abs(pointSet[i].X - xMin) > 0.01f)
                {
                    break;
                }
            }

            // degenerate case: all x-coords == x min
            int minmax = i - 1;
            if (minmax == pointSet.Count - 1)
            {
                h[++top] = pointSet[minMin];

                if (Math.Abs(pointSet[minmax].Y - pointSet[minMin].Y) > 0.01f) // a nontrivial segment
                {
                    h[++top] = pointSet[minmax];
                }

                h[++top] = pointSet[minMin]; // add polygon endpoint

                res = new Vertices(top + 1);
                for (int j = 0; j < top + 1; j++)
                {
                    res.Add(h[j]);
                }

                return res;
            }

            top = -1;

            // Get the indices of points with max x-coord and min|max y-coord
            int maxMax = pointSet.Count - 1;
            float xMax = pointSet[pointSet.Count - 1].X;
            for (i = pointSet.Count - 2; i >= 0; i--)
            {
                if (Math.Abs(pointSet[i].X - xMax) > 0.01f)
                {
                    break;
                }
            }

            int maxMin = i + 1;

            // Compute the lower hull on the stack H
            h[++top] = pointSet[minMin]; // push min min point onto stack
            i = minmax;
            while (++i <= maxMin)
            {
                // the lower line joins Position[min, min] with Position[min, max]
                if ((MathUtils.Area(pointSet[minMin], pointSet[maxMin], pointSet[i]) >= 0) && (i < maxMin))
                {
                    continue; // ignore Position[i] above or on the lower line
                }

                while (top > 0) // there are at least 2 points on the stack
                {
                    // test if Position[i] is left of the line at the stack top
                    if (MathUtils.Area(h[top - 1], h[top], pointSet[i]) > 0)
                    {
                        break; // Position[i] is a new hull vertex
                    }

                    top--; // pop top point off stack
                }

                h[++top] = pointSet[i]; // push Position[i] onto stack
            }

            // GetNext, compute the upper hull on the stack H above the bottom hull
            if (maxMax != maxMin) // if distinct max points
            {
                h[++top] = pointSet[maxMax]; 
            }

            int bot = top;
            i = maxMin;
            while (--i >= minmax)
            {
                // the upper line joins Position [max] with Position[min]
                if ((MathUtils.Area(pointSet[maxMax], pointSet[minmax], pointSet[i]) >= 0) && (i > minmax))
                {
                    continue; // ignore Position[i] below or on the upper line
                }

                while (top > bot) // at least 2 points on the upper stack
                {
                    // test if Position[i] is left of the line at the stack top
                    if (MathUtils.Area(h[top - 1], h[top], pointSet[i]) > 0)
                    {
                        break; // Position[i] is a new hull vertex
                    }

                    top--; // pop top point off stack
                }

                h[++top] = pointSet[i]; // push Position[i] onto stack
            }

            if (minmax != minMin)
            {
                h[++top] = pointSet[minMin]; // push joining endpoint onto stack
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