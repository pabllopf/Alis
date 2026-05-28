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
        internal static readonly PointComparer PointComparer = new PointComparer();

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

            pointSet.Sort(PointComparer);

            Vector2F[] h = new Vector2F[pointSet.Count];

            int minmax = FindMinmax(pointSet);
            if (minmax == pointSet.Count - 1)
            {
                return BuildVerticalLineHull(pointSet, h, minmax);
            }

            int maxmin = FindMaxmin(pointSet);
            int top = BuildLowerChain(pointSet, h, minmax, maxmin);
            top = BuildUpperChain(pointSet, h, minmax, maxmin, top);

            return BuildResultFromHull(h, top);
        }

        private static int FindMinmax(Vertices pointSet)
        {
            float xmin = pointSet[0].X;
            int i;
            for (i = 1; i < pointSet.Count; i++)
            {
                if (Math.Abs(pointSet[i].X - xmin) > float.Epsilon)
                {
                    break;
                }
            }

            return i - 1;
        }

        private static int FindMaxmin(Vertices pointSet)
        {
            float xmax = pointSet[pointSet.Count - 1].X;
            int i;
            for (i = pointSet.Count - 2; i >= 0; i--)
            {
                if (Math.Abs(pointSet[i].X - xmax) > float.Epsilon)
                {
                    break;
                }
            }

            return i + 1;
        }

        private static Vertices BuildVerticalLineHull(Vertices pointSet, Vector2F[] h, int minmax)
        {
            const int minmin = 0;
            int top = -1;
            h[++top] = pointSet[minmin];

            if (Math.Abs(pointSet[minmax].Y - pointSet[minmin].Y) > float.Epsilon)
            {
                h[++top] = pointSet[minmax];
            }

            h[++top] = pointSet[minmin];

            return BuildResultFromHull(h, top);
        }

        private static int BuildLowerChain(Vertices pointSet, Vector2F[] h, int minmax, int maxmin)
        {
            const int minmin = 0;
            int top = -1;
            h[++top] = pointSet[minmin];
            int i = minmax;
            while (++i <= maxmin)
            {
                if (ShouldSkipLowerPoint(pointSet, minmin, maxmin, i))
                {
                    continue;
                }

                PopNonHullVertices(h, ref top, pointSet[i]);
                h[++top] = pointSet[i];
            }

            return top;
        }

        private static bool ShouldSkipLowerPoint(Vertices pointSet, int minmin, int maxmin, int i)
        {
            return (MathUtils.Area(pointSet[minmin], pointSet[maxmin], pointSet[i]) >= 0) && (i < maxmin);
        }

        private static void PopNonHullVertices(Vector2F[] hull, ref int top, Vector2F candidate, int minTop = 0)
        {
            while (top > minTop && MathUtils.Area(hull[top - 1], hull[top], candidate) <= 0)
            {
                top--;
            }
        }

        private static int BuildUpperChain(Vertices pointSet, Vector2F[] h, int minmax, int maxmin, int top)
        {
            int maxmax = pointSet.Count - 1;
            if (maxmax != maxmin)
            {
                h[++top] = pointSet[maxmax];
            }

            int bot = top;
            int i = maxmin;
            while (--i >= minmax)
            {
                if (ShouldSkipUpperPoint(pointSet, maxmax, minmax, i))
                {
                    continue;
                }

                PopNonHullVertices(h, ref top, pointSet[i], bot);
                h[++top] = pointSet[i];
            }

            if (minmax != 0)
            {
                h[++top] = pointSet[0];
            }

            return top;
        }

        private static bool ShouldSkipUpperPoint(Vertices pointSet, int maxmax, int minmax, int i)
        {
            return (MathUtils.Area(pointSet[maxmax], pointSet[minmax], pointSet[i]) >= 0) && (i > minmax);
        }

        private static Vertices BuildResultFromHull(Vector2F[] h, int top)
        {
            Vertices res = new Vertices(top + 1);
            for (int j = 0; j < top + 1; j++)
            {
                res.Add(h[j]);
            }

            return res;
        }
    }
}