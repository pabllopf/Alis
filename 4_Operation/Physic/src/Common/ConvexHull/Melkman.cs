

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
            int qf = 3, qb = 0; //Queue front index, queue back index

            int startIndex = 3;
            float k = MathUtils.Area(vertices[0], vertices[1], vertices[2]);
            if (Math.Abs(k) < float.Epsilon)
            {
                deque[0] = vertices[0];
                deque[1] = vertices[2]; //We can skip vertex 1 because it should be between 0 and 2
                deque[2] = vertices[0];
                qf = 2;

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
                    deque[1] = vertices[0];
                    deque[2] = vertices[1];
                }
                else
                {
                    deque[1] = vertices[1];
                    deque[2] = vertices[0];
                }
            }

            int qfm1 = qf - 1;
            int qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;

            for (int i = startIndex; i < vertices.Count; i++)
            {
                Vector2F nextPt = vertices[i];

                if ((MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0) && (MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0))
                {
                    continue;
                }

                while (!(MathUtils.Area(ref deque[qfm1], ref deque[qf], ref nextPt) > 0))
                {
                    qf = qfm1;
                    qfm1 = qf == 0 ? deque.Length - 1 : qf - 1;
                }

                qf = qf == deque.Length - 1 ? 0 : qf + 1;
                qfm1 = qf == 0 ? deque.Length - 1 : qf - 1;
                deque[qf] = nextPt;

                while (!(MathUtils.Area(ref deque[qb], ref deque[qbm1], ref nextPt) > 0))
                {
                    qb = qbm1;
                    qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;
                }

                qb = qb == 0 ? deque.Length - 1 : qb - 1;
                qbm1 = qb == deque.Length - 1 ? 0 : qb + 1;
                deque[qb] = nextPt;
            }

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