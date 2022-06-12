// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Triangulator.cs
// 
//  Author: Pablo Perdomo Falcón
//  Web:    https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Seidel
{
    /// <summary>
    ///     The triangulator class
    /// </summary>
    internal class Triangulator
    {
        // Initialize trapezoidal map and query structure
        /// <summary>
        ///     The bounding box
        /// </summary>
        private readonly Trapezoid boundingBox;

        /// <summary>
        ///     The edge list
        /// </summary>
        private readonly List<Edge> edgeList;

        /// <summary>
        ///     The query graph
        /// </summary>
        private readonly QueryGraph queryGraph;

        /// <summary>
        ///     The sheer
        /// </summary>
        private readonly float sheer = 0.001f;

        /// <summary>
        ///     The trapezoidal map
        /// </summary>
        private readonly TrapezoidalMap trapezoidalMap;

        /// <summary>
        ///     The mono poly
        /// </summary>
        private readonly List<MonotoneMountain> xMonoPoly;

        // Trapezoid decomposition list
        /// <summary>
        ///     The trapezoids
        /// </summary>
        public List<Trapezoid> Trapezoids;

        /// <summary>
        ///     The triangles
        /// </summary>
        public List<List<Point>> Triangles;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Triangulator" /> class
        /// </summary>
        /// <param name="polyLine">The poly line</param>
        /// <param name="sheer">The sheer</param>
        public Triangulator(List<Point> polyLine, float sheer)
        {
            this.sheer = sheer;
            Triangles = new List<List<Point>>();
            Trapezoids = new List<Trapezoid>();
            xMonoPoly = new List<MonotoneMountain>();
            edgeList = InitEdges(polyLine);
            trapezoidalMap = new TrapezoidalMap();
            boundingBox = trapezoidalMap.BoundingBox(edgeList);
            queryGraph = new QueryGraph(Sink.Isink(boundingBox));

            Process();
        }

        // Build the trapezoidal map and query graph
        /// <summary>
        ///     Processes this instance
        /// </summary>
        private void Process()
        {
            foreach (Edge edge in edgeList)
            {
                List<Trapezoid> traps = queryGraph.FollowEdge(edge);

                // Remove trapezoids from trapezoidal Map
                foreach (Trapezoid t in traps)
                {
                    trapezoidalMap.Map.Remove(t);

                    bool cp = t.Contains(edge.P);
                    bool cq = t.Contains(edge.Q);
                    Trapezoid[] tList;

                    if (cp && cq)
                    {
                        tList = trapezoidalMap.Case1(t, edge);
                        queryGraph.Case1(t.Sink, edge, tList);
                    }
                    else if (cp && !cq)
                    {
                        tList = trapezoidalMap.Case2(t, edge);
                        queryGraph.Case2(t.Sink, edge, tList);
                    }
                    else if (!cp && !cq)
                    {
                        tList = trapezoidalMap.Case3(t, edge);
                        queryGraph.Case3(t.Sink, edge, tList);
                    }
                    else
                    {
                        tList = trapezoidalMap.Case4(t, edge);
                        queryGraph.Case4(t.Sink, edge, tList);
                    }

                    // Add new trapezoids to map
                    foreach (Trapezoid y in tList)
                    {
                        trapezoidalMap.Map.Add(y);
                    }
                }

                trapezoidalMap.Clear();
            }

            // Mark outside trapezoids
            foreach (Trapezoid t in trapezoidalMap.Map)
            {
                MarkOutside(t);
            }

            // Collect interior trapezoids
            foreach (Trapezoid t in trapezoidalMap.Map)
            {
                if (t.Inside)
                {
                    Trapezoids.Add(t);
                    t.AddPoints();
                }
            }

            // Generate the triangles
            CreateMountains();
        }

        // Build a list of x-monotone mountains
        /// <summary>
        ///     Creates the mountains
        /// </summary>
        private void CreateMountains()
        {
            foreach (Edge edge in edgeList)
            {
                if (edge.MPoints.Count > 2)
                {
                    MonotoneMountain mountain = new MonotoneMountain();

                    // Sorting is a perfromance hit. Literature says this can be accomplised in
                    // linear time, although I don't see a way around using traditional methods
                    // when using a randomized incremental algorithm

                    // Insertion sort is one of the fastest algorithms for sorting arrays containing 
                    // fewer than ten elements, or for lists that are already mostly sorted.

                    List<Point> points = new List<Point>(edge.MPoints);
                    points.Sort((p1, p2) => p1.X.CompareTo(p2.X));

                    foreach (Point p in points)
                    {
                        mountain.Add(p);
                    }

                    // Triangulate monotone mountain
                    mountain.Process();

                    // Extract the triangles into a single list
                    foreach (List<Point> t in mountain.Triangles)
                    {
                        Triangles.Add(t);
                    }

                    xMonoPoly.Add(mountain);
                }
            }
        }

        // Mark the outside trapezoids surrounding the polygon
        /// <summary>
        ///     Marks the outside using the specified t
        /// </summary>
        /// <param name="t">The </param>
        private void MarkOutside(Trapezoid t)
        {
            if (t.Top == boundingBox.Top || t.Bottom == boundingBox.Bottom)
            {
                t.TrimNeighbors();
            }
        }

        // Create segments and connect end points; update edge event pointer
        /// <summary>
        ///     Inits the edges using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        /// <returns>A list of edge</returns>
        private List<Edge> InitEdges(List<Point> points)
        {
            List<Edge> edges = new List<Edge>();

            for (int i = 0; i < points.Count - 1; i++)
            {
                edges.Add(new Edge(points[i], points[i + 1]));
            }

            edges.Add(new Edge(points[0], points[points.Count - 1]));
            return OrderSegments(edges);
        }

        /// <summary>
        ///     Orders the segments using the specified edge input
        /// </summary>
        /// <param name="edgeInput">The edge input</param>
        /// <returns>The edges</returns>
        private List<Edge> OrderSegments(List<Edge> edgeInput)
        {
            // Ignore vertical segments!
            List<Edge> edges = new List<Edge>();

            foreach (Edge e in edgeInput)
            {
                Point p = ShearTransform(e.P);
                Point q = ShearTransform(e.Q);

                // Point p must be to the left of point q
                if (p.X > q.X)
                {
                    edges.Add(new Edge(q, p));
                }
                else if (p.X < q.X)
                {
                    edges.Add(new Edge(p, q));
                }
            }

            // Randomized triangulation improves performance
            // See Seidel's paper, or O'Rourke's book, p. 57 
            Shuffle(edges);
            return edges;
        }

        /// <summary>
        ///     Shuffles the list
        /// </summary>
        /// <typeparam name="T">The </typeparam>
        /// <param name="list">The list</param>
        private static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }

        // Prevents any two distinct endpoints from lying on a common vertical line, and avoiding
        // the degenerate case. See Mark de Berg et al, Chapter 6.3
        /// <summary>
        ///     Shears the transform using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The point</returns>
        private Point ShearTransform(Point point)
        {
            return new Point(point.X + sheer * point.Y, point.Y);
        }
    }
}