// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File: SimpleCombiner.cs
// 
//  Author: Pablo Perdomo Falcón
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
using System.Diagnostics;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Config;
using Alis.Core.Physic.Shared;

namespace Alis.Core.Physic.Tools.PolygonManipulation
{
    /// <summary>
    ///     Combines a list of triangles into a list of convex polygons. Starts with a seed triangle, keep adding
    ///     triangles to it until you can't add any more without making the polygon non-convex.
    /// </summary>
    public static class SimpleCombiner
    {
        /// <summary>
        ///     Combine a list of triangles into a list of convex polygons. Note: This only works on triangles.
        /// </summary>
        /// <param name="triangles">The triangles.</param>
        /// <param name="maxPolys">The max number of polygons to return.</param>
        /// <param name="tolerance">The tolerance</param>
        public static List<Vertices> PolygonTriangles(List<Vertices> triangles, int maxPolys = int.MaxValue,
            float tolerance = 0.001f)
        {
            if (triangles.Count <= 0)
            {
                return triangles;
            }

            bool[] covered = InitializeCoveredFlags(triangles);
            int polyIndex = 0;
            List<Vertices> polys = new List<Vertices>();

            while (HasUncoveredTriangles(covered))
            {
                int currTri = FindFirstUncoveredTriangle(covered, triangles.Count);
                if (currTri == -1)
                {
                    break;
                }

                Vertices poly = CreatePolygonFromTriangle(triangles[currTri]);
                covered[currTri] = true;

                for (int i = 0; i < 2 * triangles.Count; ++i)
                {
                    int index = GetValidTriangleIndex(i, triangles.Count);
                    if (covered[index])
                    {
                        continue;
                    }

                    Vertices newP = AddTriangle(triangles[index], poly);
                    if (newP == null || newP.Count > Settings.PolygonVertices)
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
                    SimplifyAndAddPolygon(polys, poly, tolerance);
                }

                polyIndex++;
            }

            RemoveEmptyCollections(polys);
            return polys;
        }

        /// <summary>
        ///     Initializes the covered flags using the specified triangles
        /// </summary>
        /// <param name="triangles">The triangles</param>
        /// <returns>The covered</returns>
        private static bool[] InitializeCoveredFlags(List<Vertices> triangles)
        {
            bool[] covered = new bool[triangles.Count];
            for (int i = 0; i < triangles.Count; ++i)
            {
                covered[i] = false;

                if (IsDegenerateTriangle(triangles[i]))
                {
                    covered[i] = true;
                }
            }

            return covered;
        }

        /// <summary>
        ///     Describes whether has uncovered triangles
        /// </summary>
        /// <param name="covered">The covered</param>
        /// <returns>The bool</returns>
        private static bool HasUncoveredTriangles(bool[] covered)
        {
            return covered.Any(c => !c);
        }

        /// <summary>
        ///     Finds the first uncovered triangle using the specified covered
        /// </summary>
        /// <param name="covered">The covered</param>
        /// <param name="triangleCount">The triangle count</param>
        /// <returns>The int</returns>
        private static int FindFirstUncoveredTriangle(bool[] covered, int triangleCount)
        {
            for (int i = 0; i < triangleCount; ++i)
            {
                if (!covered[i])
                {
                    return i;
                }
            }

            return -1;
        }

        /// <summary>
        ///     Gets the valid triangle index using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        /// <param name="triangleCount">The triangle count</param>
        /// <returns>The index</returns>
        private static int GetValidTriangleIndex(int index, int triangleCount)
        {
            while (index >= triangleCount)
            {
                index -= triangleCount;
            }

            return index;
        }

        /// <summary>
        ///     Creates the polygon from triangle using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        /// <returns>The poly</returns>
        private static Vertices CreatePolygonFromTriangle(Vertices triangle)
        {
            Vertices poly = new Vertices(3);
            for (int i = 0; i < 3; i++)
            {
                poly.Add(triangle[i]);
            }

            return poly;
        }

        /// <summary>
        ///     Describes whether is degenerate triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        /// <returns>The bool</returns>
        private static bool IsDegenerateTriangle(Vertices triangle)
        {
            Vector2 a = triangle[0];
            Vector2 b = triangle[1];
            Vector2 c = triangle[2];
            return ((Math.Abs(a.X - b.X) < 0.01f) && (Math.Abs(a.Y - b.Y) < 0.01f)) ||
                   ((Math.Abs(b.X - c.X) < 0.01f) && (Math.Abs(b.Y - c.Y) < 0.01f)) ||
                   ((Math.Abs(a.X - c.X) < 0.01f) && (Math.Abs(a.Y - c.Y) < 0.01f));
        }

        /// <summary>
        ///     Simplifies the and add polygon using the specified polys
        /// </summary>
        /// <param name="polys">The polys</param>
        /// <param name="poly">The poly</param>
        /// <param name="tolerance">The tolerance</param>
        private static void SimplifyAndAddPolygon(List<Vertices> polys, Vertices poly, float tolerance)
        {
            SimplifyTools.MergeParallelEdges(poly, tolerance);

            if (poly.Count >= 3)
            {
                polys.Add(new Vertices(poly));
            }
            else
            {
                Debug.WriteLine("Skipping corrupt poly.");
            }
        }

        /// <summary>
        ///     Removes the empty collections using the specified polys
        /// </summary>
        /// <param name="polys">The polys</param>
        private static void RemoveEmptyCollections(List<Vertices> polys)
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
        /// <param name="t">The triangle to add</param>
        /// <param name="vertices">The vertices</param>
        /// <returns>The result</returns>
        private static Vertices AddTriangle(Vertices t, Vertices vertices)
        {
            FindFirstAndSecondVertices(t, vertices, out int firstP, out int firstT, out int secondP, out int secondT);

            if ((firstP == 0) && (secondP == vertices.Count - 1))
            {
                firstP = vertices.Count - 1;
                secondP = 0;
            }

            if (secondP == -1)
            {
                return null;
            }

            int tipT = FindTipIndex(firstT, secondT);

            Vertices result = CreateResultVertices(vertices, firstP, tipT, t);

            return result;
        }

        /// <summary>
        ///     Finds the first and second vertices using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="vertices">The vertices</param>
        /// <param name="firstP">The first</param>
        /// <param name="firstT">The first</param>
        /// <param name="secondP">The second</param>
        /// <param name="secondT">The second</param>
        private static void FindFirstAndSecondVertices(Vertices t, Vertices vertices, out int firstP, out int firstT, out int secondP, out int secondT)
        {
            firstP = firstT = secondP = secondT = -1;

            for (int i = 0; i < vertices.Count; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if ((Math.Abs(t[j].X - vertices[i].X) < 0.01f) && (Math.Abs(t[j].Y - vertices[i].Y) < 0.01f))
                    {
                        if (firstP == -1)
                        {
                            firstP = i;
                            firstT = j;
                        }
                        else
                        {
                            secondP = i;
                            secondT = j;
                        }
                    }
                }
            }
        }

        /// <summary>
        ///     Finds the tip index using the specified first t
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

        /// <summary>
        ///     Creates the result vertices using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="firstP">The first</param>
        /// <param name="tipT">The tip</param>
        /// <param name="t">The </param>
        /// <returns>The result</returns>
        private static Vertices CreateResultVertices(Vertices vertices, int firstP, int tipT, Vertices t)
        {
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