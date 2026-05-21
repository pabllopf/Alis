

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Common.Decomposition
{
    /// <summary>
    ///     Convex decomposition algorithm created by unknown
    ///     Properties:
    ///     - No support for holes
    ///     - Very fast
    ///     - Only works on simple polygons
    ///     - Only works on counter clockwise polygons
    ///     More information: http://www.flipcode.com/archives/Efficient_Polygon_Triangulation.shtml
    /// </summary>
    internal static class FlipcodeDecomposer
    {
        /// <summary>
        ///     The tmp
        /// </summary>
        private static Vector2F _tmpA;

        /// <summary>
        ///     The tmp
        /// </summary>
        private static Vector2F _tmpB;

        /// <summary>
        ///     The tmp
        /// </summary>
        private static Vector2F _tmpC;

        /// <summary>
        ///     Decompose the polygon into triangles.
        ///     Properties:
        ///     - Only works on counter clockwise polygons
        /// </summary>
        /// <param name="vertices">The list of points describing the polygon</param>
        public static List<Vertices> ConvexPartition(Vertices vertices)
        {
            int[] polygon = new int[vertices.Count];

            for (int v = 0; v < vertices.Count; v++)
            {
                polygon[v] = v;
            }

            int nv = vertices.Count;

            int count = 2 * nv; /* error detection */

            List<Vertices> result = new List<Vertices>();

            for (int v = nv - 1; nv > 2;)
            {
                if (0 >= count--)
                {
                    return new List<Vertices>();
                }

                int u = v;
                if (nv <= u)
                {
                    u = 0; // Previous 
                }

                v = u + 1;
                if (nv <= v)
                {
                    v = 0; // New v   
                }

                int w = v + 1;
                if (nv <= w)
                {
                    w = 0; // Next 
                }

                _tmpA = vertices[polygon[u]];
                _tmpB = vertices[polygon[v]];
                _tmpC = vertices[polygon[w]];

                if (Snip(vertices, u, v, w, nv, polygon))
                {
                    int s, t;

                    Vertices triangle = new Vertices(3);
                    triangle.Add(_tmpA);
                    triangle.Add(_tmpB);
                    triangle.Add(_tmpC);
                    result.Add(triangle);

                    for (s = v, t = v + 1; t < nv; s++, t++)
                    {
                        polygon[s] = polygon[t];
                    }

                    nv--;

                    count = 2 * nv;
                }
            }

            return result;
        }

        /// <summary>
        ///     Check if the point P is inside the triangle defined by
        ///     the points A, B, C
        /// </summary>
        /// <param name="a">The A point.</param>
        /// <param name="b">The B point.</param>
        /// <param name="c">The C point.</param>
        /// <param name="p">The point to be tested.</param>
        /// <returns>True if the point is inside the triangle</returns>
        internal static bool InsideTriangle(ref Vector2F a, ref Vector2F b, ref Vector2F c, ref Vector2F p)
        {
            float abp = (c.X - b.X) * (p.Y - b.Y) - (c.Y - b.Y) * (p.X - b.X);

            float aap = (b.X - a.X) * (p.Y - a.Y) - (b.Y - a.Y) * (p.X - a.X);

            float bcp = (a.X - c.X) * (p.Y - c.Y) - (a.Y - c.Y) * (p.X - c.X);

            return (abp >= 0.0f) && (bcp >= 0.0f) && (aap >= 0.0f);
        }

        /// <summary>
        ///     Cut a the contour and add a triangle into V to describe the
        ///     location of the cut
        /// </summary>
        /// <param name="contour">The list of points defining the polygon</param>
        /// <param name="u">The index of the first point</param>
        /// <param name="v">The index of the second point</param>
        /// <param name="w">The index of the third point</param>
        /// <param name="n">The number of elements in the array.</param>
        /// <param name="vertices"></param>
        /// <returns>True if a triangle was found</returns>
        internal static bool Snip(Vertices contour, int u, int v, int w, int n, int[] vertices)
        {
            if (SettingEnv.Epsilon > MathUtils.Area(ref _tmpA, ref _tmpB, ref _tmpC))
            {
                return false;
            }

            for (int p = 0; p < n; p++)
            {
                if (p == u || p == v || p == w)
                {
                    continue;
                }

                Vector2F point = contour[vertices[p]];

                if (InsideTriangle(ref _tmpA, ref _tmpB, ref _tmpC, ref point))
                {
                    return false;
                }
            }

            return true;
        }
    }
}