

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Physic.Common.PolygonManipulation
{
    /// <summary>
    ///     Combines a list of triangles into a list of convex polygons.
    ///     Starts with a seed triangle, keep adding triangles to it until you can't add any more without making the polygon
    ///     non-convex.
    /// </summary>
    public static class SimpleCombiner
    {
        /// <summary>
        ///     Combine a list of triangles into a list of convex polygons.
        ///     Note: This only works on triangles.
        /// </summary>
        /// <param name="triangles">The triangles.</param>
        /// <param name="maxPolys">The maximun number of polygons to return.</param>
        /// <param name="tolerance">The tolerance</param>
        public static List<Vertices> PolygonizeTriangles(List<Vertices> triangles, int maxPolys = int.MaxValue, float tolerance = 0.001f)
        {
            if (triangles.Count <= 0)
            {
                return triangles;
            }

            List<Vertices> polys = new List<Vertices>();

            bool[] covered = new bool[triangles.Count];
            for (int i = 0; i < triangles.Count; ++i)
            {
                covered[i] = false;

                Vertices triangle = triangles[i];
                Vector2F a = triangle[0];
                Vector2F b = triangle[1];
                Vector2F c = triangle[2];

                if (((Math.Abs(a.X - b.X) < float.Epsilon) && (Math.Abs(a.Y - b.Y) < float.Epsilon)) || ((Math.Abs(b.X - c.X) < float.Epsilon) && (Math.Abs(b.Y - c.Y) < float.Epsilon)) || ((Math.Abs(a.X - c.X) < float.Epsilon) && (Math.Abs(a.Y - c.Y) < float.Epsilon)))
                {
                    covered[i] = true;
                }
            }

            int polyIndex = 0;

            bool notDone = true;
            while (notDone)
            {
                int currTri = -1;
                for (int i = 0; i < triangles.Count; ++i)
                {
                    if (covered[i])
                    {
                        continue;
                    }

                    currTri = i;
                    break;
                }

                if (currTri == -1)
                {
                    notDone = false;
                }
                else
                {
                    Vertices poly = new Vertices(3);

                    for (int i = 0; i < 3; i++)
                    {
                        poly.Add(triangles[currTri][i]);
                    }

                    covered[currTri] = true;
                    int index = 0;
                    for (int i = 0; i < 2 * triangles.Count; ++i, ++index)
                    {
                        while (index >= triangles.Count)
                        {
                            index -= triangles.Count;
                        }

                        if (covered[index])
                        {
                            continue;
                        }

                        Vertices newP = AddTriangle(triangles[index], poly);
                        if (newP == null)
                        {
                            continue; // is this right
                        }

                        if (newP.Count > SettingEnv.MaxPolygonVertices)
                        {
                            continue;
                        }

                        if (newP.IsConvex())
                        {
                            poly = new Vertices(newP);
                            covered[index] = true;
                        }
                    }

                    if (polyIndex < maxPolys)
                    {
                        SimplifyTools.MergeParallelEdges(poly, tolerance);

                        if (poly.Count >= 3)
                        {
                            polys.Add(new Vertices(poly));
                        }
                        else
                        {
                            Logger.Log("Skipping corrupt poly.");
                        }
                    }

                    if (poly.Count >= 3)
                    {
                        polyIndex++; //Must be outside (polyIndex < polysLength) test
                    }
                }
            }


            for (int i = polys.Count - 1; i >= 0; i--)
            {
                if (polys[i].Count == 0)
                {
                    polys.RemoveAt(i);
                }
            }

            return polys;
        }

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The result</returns>
        private static Vertices AddTriangle(Vertices t, Vertices vertices)
        {
            int firstP = -1;
            int firstT = -1;
            int secondP = -1;
            int secondT = -1;
            for (int i = 0; i < vertices.Count; i++)
            {
                if ((Math.Abs(t[0].X - vertices[i].X) < float.Epsilon) && (Math.Abs(t[0].Y - vertices[i].Y) < float.Epsilon))
                {
                    if (firstP == -1)
                    {
                        firstP = i;
                        firstT = 0;
                    }
                    else
                    {
                        secondP = i;
                        secondT = 0;
                    }
                }
                else if ((Math.Abs(t[1].X - vertices[i].X) < float.Epsilon) && (Math.Abs(t[1].Y - vertices[i].Y) < float.Epsilon))
                {
                    if (firstP == -1)
                    {
                        firstP = i;
                        firstT = 1;
                    }
                    else
                    {
                        secondP = i;
                        secondT = 1;
                    }
                }
                else if ((Math.Abs(t[2].X - vertices[i].X) < float.Epsilon) && (Math.Abs(t[2].Y - vertices[i].Y) < float.Epsilon))
                {
                    if (firstP == -1)
                    {
                        firstP = i;
                        firstT = 2;
                    }
                    else
                    {
                        secondP = i;
                        secondT = 2;
                    }
                }
            }

            if ((firstP == 0) && (secondP == vertices.Count - 1))
            {
                firstP = vertices.Count - 1;
                secondP = 0;
            }

            if (secondP == -1)
            {
                return null;
            }

            int tipT = 0;
            if (tipT == firstT || tipT == secondT)
            {
                tipT = 1;
            }

            if (tipT == firstT || tipT == secondT)
            {
                tipT = 2;
            }

            Vertices result = new Vertices(vertices.Count + 1);
            for (int i = 0; i < vertices.Count; i++)
            {
                result.Add(vertices[i]);

                if (i == firstP)
                {
                    result.Add(t[tipT]);
                }
            }

            return result;
        }
    }
}