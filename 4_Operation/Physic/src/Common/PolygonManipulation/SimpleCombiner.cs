// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleCombiner.cs
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

            bool[] covered = MarkDegenerateTriangles(triangles);

            int polyIndex = 0;

            while (ProcessNextPolygon(ref polyIndex, triangles, covered, maxPolys, tolerance, polys))
            {
                // Continue until no more uncovered triangles
            }

            RemoveEmptyPolygons(polys);

            return polys;
        }

        /// <summary>
        /// Processes the valid polygon using the specified poly
        /// </summary>
        /// <param name="poly">The poly</param>
        /// <param name="polyIndex">The poly index</param>
        /// <param name="maxPolys">The max polys</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="polys">The polys</param>
        private static void ProcessValidPolygon(Vertices poly, ref int polyIndex, int maxPolys, float tolerance, List<Vertices> polys)
        {
            if (polyIndex >= maxPolys)
            {
                return;
            }

            SimplifyTools.MergeParallelEdges(poly, tolerance);

            if (poly.Count >= 3)
            {
                AddPolygonToList(poly, polys);
                polyIndex++;
            }
            else
            {
                Logger.Log("Skipping corrupt poly.");
            }
        }

        /// <summary>
        /// Processes the next polygon using the specified poly index
        /// </summary>
        /// <param name="polyIndex">The poly index</param>
        /// <param name="triangles">The triangles</param>
        /// <param name="covered">The covered</param>
        /// <param name="maxPolys">The max polys</param>
        /// <param name="tolerance">The tolerance</param>
        /// <param name="polys">The polys</param>
        /// <returns>The bool</returns>
        private static bool ProcessNextPolygon(ref int polyIndex, List<Vertices> triangles, bool[] covered, int maxPolys, float tolerance, List<Vertices> polys)
        {
            int currTri = FindNextUncoveredTriangle(triangles, covered);
            if (currTri == -1)
            {
                return false;
            }

            Vertices poly = BuildInitialPoly(currTri, triangles, covered);
            TryAddNeighboringTriangles(poly, triangles, covered);
            ProcessValidPolygon(poly, ref polyIndex, maxPolys, tolerance, polys);
            return true;
        }

        /// <summary>
        /// Adds the polygon to list using the specified poly
        /// </summary>
        /// <param name="poly">The poly</param>
        /// <param name="polys">The polys</param>
        private static void AddPolygonToList(Vertices poly, List<Vertices> polys)
        {
            polys.Add(new Vertices(poly));
        }

        /// <summary>
        /// Marks the degenerate triangles using the specified triangles
        /// </summary>
        /// <param name="triangles">The triangles</param>
        /// <returns>The covered</returns>
        private static bool[] MarkDegenerateTriangles(List<Vertices> triangles)
        {
            bool[] covered = new bool[triangles.Count];
            for (int i = 0; i < triangles.Count; ++i)
            {
                Vertices triangle = triangles[i];
                Vector2F a = triangle[0];
                Vector2F b = triangle[1];
                Vector2F c = triangle[2];

                if (IsDegenerateTriangle(a, b, c))
                {
                    covered[i] = true;
                }
            }

            return covered;
        }

        /// <summary>
        /// Ises the degenerate triangle using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="c">The </param>
        /// <returns>The bool</returns>
        private static bool IsDegenerateTriangle(Vector2F a, Vector2F b, Vector2F c)
        {
            if ((Math.Abs(a.X - b.X) < float.Epsilon) && (Math.Abs(a.Y - b.Y) < float.Epsilon))
            {
                return true;
            }

            if ((Math.Abs(b.X - c.X) < float.Epsilon) && (Math.Abs(b.Y - c.Y) < float.Epsilon))
            {
                return true;
            }

            if ((Math.Abs(a.X - c.X) < float.Epsilon) && (Math.Abs(a.Y - c.Y) < float.Epsilon))
            {
                return true;
            }

            return false;
        }

        /// <summary>
        /// Finds the next uncovered triangle using the specified triangles
        /// </summary>
        /// <param name="triangles">The triangles</param>
        /// <param name="covered">The covered</param>
        /// <returns>The int</returns>
        private static int FindNextUncoveredTriangle(List<Vertices> triangles, bool[] covered)
        {
            for (int i = 0; i < triangles.Count; ++i)
            {
                if (!covered[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        /// Builds the initial poly using the specified curr tri
        /// </summary>
        /// <param name="currTri">The curr tri</param>
        /// <param name="triangles">The triangles</param>
        /// <param name="covered">The covered</param>
        /// <returns>The poly</returns>
        private static Vertices BuildInitialPoly(int currTri, List<Vertices> triangles, bool[] covered)
        {
            Vertices poly = new Vertices(3);
            for (int i = 0; i < 3; i++)
            {
                poly.Add(triangles[currTri][i]);
            }

            covered[currTri] = true;
            return poly;
        }

        /// <summary>
        /// Tries the add neighboring triangles using the specified poly
        /// </summary>
        /// <param name="poly">The poly</param>
        /// <param name="triangles">The triangles</param>
        /// <param name="covered">The covered</param>
        private static void TryAddNeighboringTriangles(Vertices poly, List<Vertices> triangles, bool[] covered)
        {
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
                if (newP.Count == 0)
                {
                    continue;
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
        }

        /// <summary>
        /// Removes the empty polygons using the specified polys
        /// </summary>
        /// <param name="polys">The polys</param>
        private static void RemoveEmptyPolygons(List<Vertices> polys)
        {
            for (int i = polys.Count - 1; i >= 0; i--)
            {
                if (polys[i].Count == 0)
                {
                    polys.RemoveAt(i);
                }
            }
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

            FindMatchingVertices(t, vertices, ref firstP, ref firstT, ref secondP, ref secondT);

            if ((firstP == 0) && (secondP == vertices.Count - 1))
            {
                firstP = vertices.Count - 1;
                secondP = 0;
            }

            if (secondP == -1)
            {
                return new Vertices();
            }

            int tipT = FindTipIndex(firstT, secondT);

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

        /// <summary>
        /// Finds the matching vertices using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="vertices">The vertices</param>
        /// <param name="firstP">The first</param>
        /// <param name="firstT">The first</param>
        /// <param name="secondP">The second</param>
        /// <param name="secondT">The second</param>
        private static void FindMatchingVertices(Vertices t, Vertices vertices, ref int firstP, ref int firstT, ref int secondP, ref int secondT)
        {
            for (int i = 0; i < vertices.Count; i++)
            {
                if (VertexMatches(t[0], vertices[i]))
                {
                    RecordMatch(ref firstP, ref firstT, ref secondP, ref secondT, i, 0);
                }
                else if (VertexMatches(t[1], vertices[i]))
                {
                    RecordMatch(ref firstP, ref firstT, ref secondP, ref secondT, i, 1);
                }
                else if (VertexMatches(t[2], vertices[i]))
                {
                    RecordMatch(ref firstP, ref firstT, ref secondP, ref secondT, i, 2);
                }
            }
        }

        /// <summary>
        /// Vertexes the matches using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The bool</returns>
        private static bool VertexMatches(Vector2F a, Vector2F b)
        {
            return (Math.Abs(a.X - b.X) < float.Epsilon) && (Math.Abs(a.Y - b.Y) < float.Epsilon);
        }

        /// <summary>
        /// Records the match using the specified first p
        /// </summary>
        /// <param name="firstP">The first</param>
        /// <param name="firstT">The first</param>
        /// <param name="secondP">The second</param>
        /// <param name="secondT">The second</param>
        /// <param name="vertexIndex">The vertex index</param>
        /// <param name="triangleIndex">The triangle index</param>
        private static void RecordMatch(ref int firstP, ref int firstT, ref int secondP, ref int secondT, int vertexIndex, int triangleIndex)
        {
            if (firstP == -1)
            {
                firstP = vertexIndex;
                firstT = triangleIndex;
            }
            else
            {
                secondP = vertexIndex;
                secondT = triangleIndex;
            }
        }

        /// <summary>
        /// Finds the tip index using the specified first t
        /// </summary>
        /// <param name="firstT">The first</param>
        /// <param name="secondT">The second</param>
        /// <returns>The tip</returns>
        private static int FindTipIndex(int firstT, int secondT)
        {
            int tipT = 0;
            if (tipT == firstT || tipT == secondT)
            {
                tipT = 1;
            }

            if (tipT == firstT || tipT == secondT)
            {
                tipT = 2;
            }

            return tipT;
        }
    }
}