// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Triangulate.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Util;

namespace Alis.Extension.Math.PathGenerator.Triangulation.Seidel
{
    /// <summary>
    ///     The triangulate class
    /// </summary>
    internal class Triangulate
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
        private readonly float sheer;

        /// <summary>
        ///     The trapezoidal map
        /// </summary>
        private readonly TrapezoidalMap trapezoidalMap;

        // Trapezoid decomposition list
        /// <summary>
        ///     The trapezoids
        /// </summary>
        public readonly List<Trapezoid> Trapezoids;

        /// <summary>
        ///     The triangles
        /// </summary>
        public readonly List<List<Point>> Triangles;

        /// <summary>
        ///     Initializes a new instance of the <see cref="Triangulate" /> class
        /// </summary>
        /// <param name="polyLine">The poly line</param>
        /// <param name="sheer">The sheer</param>
        public Triangulate(List<Point> polyLine, float sheer)
        {
            this.sheer = sheer;
            Triangles = new List<List<Point>>();
            Trapezoids = new List<Trapezoid>();
            edgeList = InitEdges(polyLine);
            trapezoidalMap = new TrapezoidalMap();
            boundingBox = trapezoidalMap.BoundingBox(edgeList);
            queryGraph = new QueryGraph(Sink.IsInk(boundingBox));

            Process();
        }

        /// <summary>
        ///     Processes this instance
        /// </summary>
        private void Process()
        {
            ProcessEdges();
            MarkOutsideTrapezoids();
            CollectInteriorTrapezoids();
            CreateMountains();
        }

        /// <summary>
        ///     Processes the edges
        /// </summary>
        private void ProcessEdges()
        {
            foreach (Edge edge in edgeList)
            {
                List<Trapezoid> trapezoids = queryGraph.FollowEdge(edge);

                foreach (Trapezoid trapezoid in trapezoids)
                {
                    RemoveTrapezoidFromMap(trapezoid);

                    bool containsP = trapezoid.Contains(edge.P);
                    bool containsQ = trapezoid.Contains(edge.Q);
                    Trapezoid[] newTrapezoids;

                    if (containsP && containsQ)
                    {
                        newTrapezoids = trapezoidalMap.Case1(trapezoid, edge);
                        queryGraph.Case1(trapezoid.Sink, edge, newTrapezoids);
                    }
                    else if (containsP)
                    {
                        newTrapezoids = trapezoidalMap.Case2(trapezoid, edge);
                        queryGraph.Case2(trapezoid.Sink, edge, newTrapezoids);
                    }
                    else if (!containsQ)
                    {
                        newTrapezoids = trapezoidalMap.Case3(trapezoid, edge);
                        queryGraph.Case3(trapezoid.Sink, edge, newTrapezoids);
                    }
                    else
                    {
                        newTrapezoids = trapezoidalMap.Case4(trapezoid, edge);
                        queryGraph.Case4(trapezoid.Sink, edge, newTrapezoids);
                    }

                    AddNewTrapezoidsToMap(newTrapezoids);
                }

                trapezoidalMap.Clear();
            }
        }

        /// <summary>
        ///     Removes the trapezoid from map using the specified trapezoid
        /// </summary>
        /// <param name="trapezoid">The trapezoid</param>
        private void RemoveTrapezoidFromMap(Trapezoid trapezoid)
        {
            trapezoidalMap.Map.Remove(trapezoid);
        }

        /// <summary>
        ///     Adds the new trapezoids to map using the specified new trapezoids
        /// </summary>
        /// <param name="newTrapezoids">The new trapezoids</param>
        private void AddNewTrapezoidsToMap(Trapezoid[] newTrapezoids)
        {
            foreach (Trapezoid trapezoid in newTrapezoids)
            {
                trapezoidalMap.Map.Add(trapezoid);
            }
        }

        /// <summary>
        ///     Marks the outside trapezoids
        /// </summary>
        private void MarkOutsideTrapezoids()
        {
            foreach (Trapezoid trapezoid in trapezoidalMap.Map)
            {
                MarkOutside(trapezoid);
            }
        }

        /// <summary>
        ///     Collects the interior trapezoids
        /// </summary>
        private void CollectInteriorTrapezoids()
        {
            foreach (Trapezoid trapezoid in trapezoidalMap.Map)
            {
                if (trapezoid.Inside)
                {
                    Trapezoids.Add(trapezoid);
                    trapezoid.AddPoints();
                }
            }
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
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = RandomUtils.GetInt32(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        // Prevents any two distinct endpoints from lying on a common vertical line, and avoiding
        // the degenerate case. See Mark de Berg et al, Chapter 6.3
        /// <summary>
        ///     Shears the transform using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The point</returns>
        private Point ShearTransform(Point point) => new Point(point.X + sheer * point.Y, point.Y);
    }
}