// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Melkman.cs
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
    ///     Creates a convex hull.
    ///     Note:
    ///     1. Vertices must be of a simple polygon, i.e. edges do not overlap.
    ///     2. Melkman does not work on point clouds
    /// </summary>
    /// <remarks>
    ///     Implemented using Melkman's Convex Hull Algorithm - O(n) time complexity.
    ///     Reference: http://www.ams.sunysb.edu/~jsbm/courses/345/melkman.pdf
    /// </remarks>
    public static class Melkman
    {
        //Melkman based convex hull algorithm contributed by Cowdozer

        /// <summary>
        ///     Returns a convex hull from the given vertices.
        /// </summary>
        /// <returns>A convex hull in counter clockwise winding order.</returns>
        public static Vertices GetConvexHull(Vertices vertices)
        {
            if (vertices.Count <= 3)
            {
                return vertices;
            }

            Vector2F[] deque = new Vector2F[vertices.Count + 1];
            int qf = 3, qb = 0;

            int startIndex = InitializeDeque(vertices, deque, ref qf);
            ProcessDeque(vertices, deque, ref qf, ref qb, startIndex);

            return BuildConvexHullResult(deque, qf, qb);
        }

        /// <summary>
        /// Initializes the deque using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <returns>The start index</returns>
        private static int InitializeDeque(Vertices vertices, Vector2F[] deque, ref int qf)
        {
            int startIndex = 3;
            float k = MathUtils.Area(vertices[0], vertices[1], vertices[2]);
            if (Math.Abs(k) < float.Epsilon)
            {
                InitCollinear(vertices, deque, ref qf, ref startIndex);
            }
            else
            {
                InitNonCollinear(vertices, deque, k);
            }

            return startIndex;
        }

        /// <summary>
        /// Inits the collinear using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="startIndex">The start index</param>
        private static void InitCollinear(Vertices vertices, Vector2F[] deque, ref int qf, ref int startIndex)
        {
            deque[0] = vertices[0];
            deque[1] = vertices[2];
            deque[2] = vertices[0];
            qf = 2;

            for (startIndex = 3; startIndex < vertices.Count; startIndex++)
            {
                Vector2F tmp = vertices[startIndex];
                if (Math.Abs(MathUtils.Area(ref deque[0], ref deque[1], ref tmp)) < float.Epsilon)
                {
                    deque[1] = vertices[startIndex];
                }
                else
                {
                    break;
                }
            }
        }

        /// <summary>
        /// Inits the non collinear using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="deque">The deque</param>
        /// <param name="k">The </param>
        private static void InitNonCollinear(Vertices vertices, Vector2F[] deque, float k)
        {
            deque[0] = deque[3] = vertices[2];
            if (k > 0)
            {
                deque[1] = vertices[0];
                deque[2] = vertices[1];
            }
            else
            {
                deque[1] = vertices[1];
                deque[2] = vertices[0];
            }
        }

        /// <summary>
        /// Processes the deque using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="qb">The qb</param>
        /// <param name="startIndex">The start index</param>
        private static void ProcessDeque(Vertices vertices, Vector2F[] deque, ref int qf, ref int qb, int startIndex)
        {
            int qfm1 = qf - 1;
            int qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;

            for (int i = startIndex; i < vertices.Count; i++)
            {
                Vector2F nextPt = vertices[i];

                if (IsInsideDeque(deque, qf, qb, qfm1, qbm1, nextPt))
                {
                    continue;
                }

                PopDequeFront(deque, ref qf, ref qfm1, nextPt);
                PushDequeFront(deque, ref qf, ref qfm1, nextPt);

                PopDequeBack(deque, ref qb, ref qbm1, nextPt);
                PushDequeBack(deque, ref qb, ref qbm1, nextPt);
            }
        }

        /// <summary>
        /// Ises the inside deque using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="qb">The qb</param>
        /// <param name="qfm1">The qfm</param>
        /// <param name="qbm1">The qbm</param>
        /// <param name="nextPt">The next pt</param>
        /// <returns>The bool</returns>
        private static bool IsInsideDeque(Vector2F[] deque, int qf, int qb, int qfm1, int qbm1, Vector2F nextPt) => (MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0) && (MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0);

        /// <summary>
        /// Pops the deque front using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="qfm1">The qfm</param>
        /// <param name="nextPt">The next pt</param>
        private static void PopDequeFront(Vector2F[] deque, ref int qf, ref int qfm1, Vector2F nextPt)
        {
            while (!(MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0))
            {
                qf = qfm1;
                qfm1 = qf == 0 ? deque.Length - 1 : qf - 1;
            }
        }

        /// <summary>
        /// Pushes the deque front using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="qfm1">The qfm</param>
        /// <param name="nextPt">The next pt</param>
        private static void PushDequeFront(Vector2F[] deque, ref int qf, ref int qfm1, Vector2F nextPt)
        {
            qf = qf == deque.Length - 1 ? 0 : qf + 1;
            qfm1 = qf == 0 ? deque.Length - 1 : qf - 1;
            deque[qf] = nextPt;
        }

        /// <summary>
        /// Pops the deque back using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qb">The qb</param>
        /// <param name="qbm1">The qbm</param>
        /// <param name="nextPt">The next pt</param>
        private static void PopDequeBack(Vector2F[] deque, ref int qb, ref int qbm1, Vector2F nextPt)
        {
            while (!(MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0))
            {
                qb = qbm1;
                qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;
            }
        }

        /// <summary>
        /// Pushes the deque back using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qb">The qb</param>
        /// <param name="qbm1">The qbm</param>
        /// <param name="nextPt">The next pt</param>
        private static void PushDequeBack(Vector2F[] deque, ref int qb, ref int qbm1, Vector2F nextPt)
        {
            qb = qb == 0 ? deque.Length - 1 : qb - 1;
            qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;
            deque[qb] = nextPt;
        }

        /// <summary>
        /// Builds the convex hull result using the specified deque
        /// </summary>
        /// <param name="deque">The deque</param>
        /// <param name="qf">The qf</param>
        /// <param name="qb">The qb</param>
        /// <returns>The result</returns>
        private static Vertices BuildConvexHullResult(Vector2F[] deque, int qf, int qb)
        {
            if (qb < qf)
            {
                Vertices convexHull = new Vertices(qf);
                for (int i = qb; i < qf; i++)
                {
                    convexHull.Add(deque[i]);
                }

                return convexHull;
            }

            Vertices result = new Vertices(qf + deque.Length);
            for (int i = 0; i < qf; i++)
            {
                result.Add(deque[i]);
            }

            for (int i = qb; i < deque.Length; i++)
            {
                result.Add(deque[i]);
            }

            return result;
        }
    }
}