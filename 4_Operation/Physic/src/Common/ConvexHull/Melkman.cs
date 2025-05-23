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

            //We'll never need a queue larger than the current number of Vertices +1
            //Create double-ended queue
            Vector2F[] deque = new Vector2F[vertices.Count + 1];
            int qf = 3, qb = 0; //Queue front index, queue back index

            //Start by placing first 3 vertices in convex CCW order
            int startIndex = 3;
            float k = MathUtils.Area(vertices[0], vertices[1], vertices[2]);
            if (Math.Abs(k) < float.Epsilon)
            {
                //Vertices are collinear.
                deque[0] = vertices[0];
                deque[1] = vertices[2]; //We can skip vertex 1 because it should be between 0 and 2
                deque[2] = vertices[0];
                qf = 2;

                //Go until the end of the collinear sequence of vertices
                for (startIndex = 3; startIndex < vertices.Count; startIndex++)
                {
                    Vector2F tmp = vertices[startIndex];
                    if (Math.Abs(MathUtils.Area(ref deque[0], ref deque[1], ref tmp)) < float.Epsilon) //This point is also collinear
                    {
                        deque[1] = vertices[startIndex];
                    }
                    else
                    {
                        break;
                    }
                }
            }
            else
            {
                deque[0] = deque[3] = vertices[2];
                if (k > 0)
                {
                    //Is Left.  Set deque = {2, 0, 1, 2}
                    deque[1] = vertices[0];
                    deque[2] = vertices[1];
                }
                else
                {
                    //Is Right. Set deque = {2, 1, 0, 2}
                    deque[1] = vertices[1];
                    deque[2] = vertices[0];
                }
            }

            int qfm1 = qf - 1;
            int qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;

            //Add vertices one at a time and adjust convex hull as needed
            for (int i = startIndex; i < vertices.Count; i++)
            {
                Vector2F nextPt = vertices[i];

                //Ignore if it is already within the convex hull we have constructed
                if ((MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0) && (MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0))
                {
                    continue;
                }

                //Pop front until convex
                while (!(MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0))
                {
                    //Pop the front element from the queue
                    qf = qfm1; //qf--;
                    qfm1 = qf == 0 ? deque.Length - 1 : qf - 1; //qfm1 = qf - 1;
                }

                //Add vertex to the front of the queue
                qf = qf == deque.Length - 1 ? 0 : qf + 1; //qf++;
                qfm1 = qf == 0 ? deque.Length - 1 : qf - 1; //qfm1 = qf - 1;
                deque[qf] = nextPt;

                //Pop back until convex
                while (!(MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0))
                {
                    //Pop the back element from the queue
                    qb = qbm1; //qb++;
                    qbm1 = qb == deque.Length - 1 ? 0 : qb + 1; //qbm1 = qb + 1;
                }

                //Add vertex to the back of the queue
                qb = qb == 0 ? deque.Length - 1 : qb - 1; //qb--;
                qbm1 = qb == deque.Length - 1 ? 0 : qb + 1; //qbm1 = qb + 1;
                deque[qb] = nextPt;
            }

            //Create the convex hull from what is left in the deque
            if (qb < qf)
            {
                Vertices convexHull = new Vertices(qf);

                for (int i = qb; i < qf; i++)
                {
                    convexHull.Add(deque[i]);
                }

                return convexHull;
            }
            else
            {
                Vertices convexHull = new Vertices(qf + deque.Length);

                for (int i = 0; i < qf; i++)
                {
                    convexHull.Add(deque[i]);
                }

                for (int i = qb; i < deque.Length; i++)
                {
                    convexHull.Add(deque[i]);
                }

                return convexHull;
            }
        }
    }
}