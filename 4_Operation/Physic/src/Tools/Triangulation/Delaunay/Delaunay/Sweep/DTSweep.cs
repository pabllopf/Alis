// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweep.cs
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
using System.Diagnostics;
using Alis.Core.Aspect.Logging;
using Alis.Core.Physic.Exceptions;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep class
    /// </summary>
    internal static class DtSweep
    {
        /// <summary>
        ///     The pi
        /// </summary>
        private const double PiDiv2 = Math.PI / 2;

        /// <summary>
        ///     The pi
        /// </summary>
        private const double Pi3Div4 = 3 * Math.PI / 4;

        /// <summary>Triangulate simple polygon with holes</summary>
        public static void Triangulate(DtSweepContext tcx)
        {
            tcx.CreateAdvancingFront();

            Sweep(tcx);

            // Finalize triangulation
            if (tcx.TriangulationMode == TriangulationMode.Polygon)
            {
                FinalizationPolygon(tcx);
            }
            else
            {
                FinalizationConvexHull(tcx);
            }

            tcx.Done();
        }

        /// <summary>Start sweeping the Y-sorted point set from bottom to top</summary>
        private static void Sweep(DtSweepContext tcx)
        {
            List<TriangulationPoint> points = tcx.Points;

            for (int i = 1; i < points.Count; i++)
            {
                TriangulationPoint point = points[i];

                AdvancingFrontNode node = PointEvent(tcx, point);

                if (point.HasEdges)
                {
                    foreach (DtSweepConstraint e in point.Edges)
                    {
                        EdgeEvent(tcx, e, node);
                    }
                }

                tcx.Update(null);
            }
        }

        /// <summary>If this is a Delaunay Triangulation of a point set we need to fill so the triangle mesh gets a ConvexHull</summary>
        private static void FinalizationConvexHull(DtSweepContext tcx)
        {
            DelaunayTriangle t1, t2;

            AdvancingFrontNode n1 = tcx.AFront.Head.Next;
            AdvancingFrontNode n2 = n1.Next;

            TurnAdvancingFrontConvex(tcx, n1, n2);

            n1 = tcx.AFront.Tail.Prev;
            if (n1.Triangle.Contains(n1.Next.Point) && n1.Triangle.Contains(n1.Prev.Point))
            {
                t1 = n1.Triangle.NeighborAcross(n1.Point);
                RotateTrianglePair(n1.Triangle, n1.Point, t1, t1.OppositePoint(n1.Triangle, n1.Point));
                tcx.MapTriangleToNodes(n1.Triangle);
                tcx.MapTriangleToNodes(t1);
            }

            n1 = tcx.AFront.Head.Next;
            if (n1.Triangle.Contains(n1.Prev.Point) && n1.Triangle.Contains(n1.Next.Point))
            {
                t1 = n1.Triangle.NeighborAcross(n1.Point);
                RotateTrianglePair(n1.Triangle, n1.Point, t1, t1.OppositePoint(n1.Triangle, n1.Point));
                tcx.MapTriangleToNodes(n1.Triangle);
                tcx.MapTriangleToNodes(t1);
            }

            // Lower right boundary 
            TriangulationPoint first = tcx.AFront.Head.Point;
            n2 = tcx.AFront.Tail.Prev;
            t1 = n2.Triangle;
            TriangulationPoint p1 = n2.Point;
            n2.Triangle = null;
            do
            {
                tcx.RemoveFromList(t1);
                p1 = t1.PointCcw(p1);
                if (p1 == first)
                {
                    break;
                }

                t2 = t1.NeighborCcw(p1);
                t1.Clear();
                t1 = t2;
            } while (true);

            // Lower left boundary
            first = tcx.AFront.Head.Next.Point;
            p1 = t1.PointCw(tcx.AFront.Head.Point);
            t2 = t1.NeighborCw(tcx.AFront.Head.Point);
            t1.Clear();
            t1 = t2;
            while (p1 != first)
            {
                tcx.RemoveFromList(t1);
                p1 = t1.PointCcw(p1);
                t2 = t1.NeighborCcw(p1);
                t1.Clear();
                t1 = t2;
            }

            // Remove current head and tail node now that we have removed all triangles attached
            // to them. Then set new head and tail node points
            tcx.AFront.Head = tcx.AFront.Head.Next;
            tcx.AFront.Head.Prev = null;
            tcx.AFront.Tail = tcx.AFront.Tail.Prev;
            tcx.AFront.Tail.Next = null;

            tcx.FinalizeTriangulation();
        }

        /// <summary>We will traverse the entire advancing front and fill it to form a convex hull.</summary>
        private static void TurnAdvancingFrontConvex(DtSweepContext tcx, AdvancingFrontNode b, AdvancingFrontNode c)
        {
            AdvancingFrontNode first = b;
            while (c != tcx.AFront.Tail)
            {
                if (TriangulationUtil.Orient2d(b.Point, c.Point, c.Next.Point) == Orientation.Ccw)
                {
                    // [b,c,d] Concave - fill around c
                    Fill(tcx, c);
                    c = c.Next;
                }
                else
                {
                    // [b,c,d] Convex
                    if ((b != first) && (TriangulationUtil.Orient2d(b.Prev.Point, b.Point, c.Point) == Orientation.Ccw))
                    {
                        // [a,b,c] Concave - fill around b
                        Fill(tcx, b);
                        b = b.Prev;
                    }
                    else
                    {
                        // [a,b,c] Convex - nothing to fill
                        b = c;
                        c = c.Next;
                    }
                }
            }
        }

        /// <summary>
        ///     Finalization the polygon using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        private static void FinalizationPolygon(DtSweepContext tcx)
        {
            // Get an Internal triangle to start with
            DelaunayTriangle t = tcx.AFront.Head.Next.Triangle;
            TriangulationPoint p = tcx.AFront.Head.Next.Point;
            while (!t.GetConstrainedEdgeCw(p))
            {
                t = t.NeighborCcw(p);
            }

            // Collect interior triangles constrained by edges
            tcx.MeshClean(t);
        }

        /// <summary>
        ///     Find closes node to the left of the new point and create a new triangle. If needed new holes and basins will
        ///     be filled to.
        /// </summary>
        private static AdvancingFrontNode PointEvent(DtSweepContext tcx, TriangulationPoint point)
        {
            AdvancingFrontNode node = tcx.LocateNode(point);
            AdvancingFrontNode newNode = NewFrontTriangle(tcx, point, node);

            // Only need to check +epsilon since point never have smaller 
            // x value than node due to how we fetch nodes from the front
            if (point.X <= node.Point.X + TriangulationUtil.Epsilon)
            {
                Fill(tcx, node);
            }

            tcx.AddNode(newNode);

            FillAdvancingFront(tcx, newNode);
            return newNode;
        }

        /// <summary>Creates a new front triangle and legalize it</summary>
        private static AdvancingFrontNode NewFrontTriangle(DtSweepContext tcx, TriangulationPoint point,
            AdvancingFrontNode node)
        {
            DelaunayTriangle triangle = new DelaunayTriangle(point, node.Point, node.Next.Point);
            triangle.MarkNeighbor(node.Triangle);
            tcx.Triangles.Add(triangle);

            AdvancingFrontNode newNode = new AdvancingFrontNode(point)
            {
                Next = node.Next,
                Prev = node
            };
            node.Next.Prev = newNode;
            node.Next = newNode;

            tcx.AddNode(newNode); // XXX: BST

            if (!Legalize(tcx, triangle))
            {
                tcx.MapTriangleToNodes(triangle);
            }

            return newNode;
        }

        /// <summary>
        ///     Edges the event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void EdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            try
            {
                tcx.EdgeEvent.ConstrainedEdge = edge;
                tcx.EdgeEvent.Right = edge.P.X > edge.Q.X;

                if (IsEdgeSideOfTriangle(node.Triangle, edge.P, edge.Q))
                {
                    return;
                }

                FillEdgeEvent(tcx, edge, node);

                EdgeEvent(tcx, edge.P, edge.Q, node.Triangle, edge.Q);
            }
            catch (PointOnEdgeException e)
            {
                Debug.WriteLine("Skipping Edge: {0}", e.Message);
            }
        }

        /// <summary>
        ///     Fills the edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            if (tcx.EdgeEvent.Right)
            {
                FillRightAboveEdgeEvent(tcx, edge, node);
            }
            else
            {
                FillLeftAboveEdgeEvent(tcx, edge, node);
            }
        }

        /// <summary>
        ///     Fills the right concave edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillRightConcaveEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge,
            AdvancingFrontNode node)
        {
            Fill(tcx, node.Next);
            if (node.Next.Point != edge.P)
            {
                // GetNext above or below edge?
                if (TriangulationUtil.Orient2d(edge.Q, node.Next.Point, edge.P) == Orientation.Ccw)
                {
                    // Below
                    if (TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) ==
                        Orientation.Ccw)
                    {
                        // GetNext is concave
                        FillRightConcaveEdgeEvent(tcx, edge, node);
                    }
                }
            }
        }

        /// <summary>
        ///     Fills the right convex edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillRightConvexEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge,
            AdvancingFrontNode node)
        {
            // GetNext concave or convex?
            if (TriangulationUtil.Orient2d(node.Next.Point, node.Next.Next.Point, node.Next.Next.Next.Point) ==
                Orientation.Ccw)
            {
                // Concave
                FillRightConcaveEdgeEvent(tcx, edge, node.Next);
            }
            else
            {
                // Convex
                // GetNext above or below edge?
                if (TriangulationUtil.Orient2d(edge.Q, node.Next.Next.Point, edge.P) == Orientation.Ccw)
                {
                    // Below
                    FillRightConvexEdgeEvent(tcx, edge, node.Next);
                }
            }
        }

        /// <summary>
        ///     Fills the right below edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillRightBelowEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            if (node.Point.X < edge.P.X) // needed?
            {
                if (TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.Ccw)
                {
                    // Concave 
                    FillRightConcaveEdgeEvent(tcx, edge, node);
                }
                else
                {
                    // Convex
                    FillRightConvexEdgeEvent(tcx, edge, node);

                    // Retry this one
                    FillRightBelowEdgeEvent(tcx, edge, node);
                }
            }
        }

        /// <summary>
        ///     Fills the right above edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillRightAboveEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            while (node.Next.Point.X < edge.P.X)
            {
                // Check if next node is below the edge
                Orientation o1 = TriangulationUtil.Orient2d(edge.Q, node.Next.Point, edge.P);
                if (o1 == Orientation.Ccw)
                {
                    FillRightBelowEdgeEvent(tcx, edge, node);
                }
                else
                {
                    node = node.Next;
                }
            }
        }

        /// <summary>
        ///     Fills the left convex edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillLeftConvexEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            // GetNext concave or convex?
            if (TriangulationUtil.Orient2d(node.Prev.Point, node.Prev.Prev.Point, node.Prev.Prev.Prev.Point) ==
                Orientation.Cw)
            {
                // Concave
                FillLeftConcaveEdgeEvent(tcx, edge, node.Prev);
            }
            else
            {
                // Convex
                // GetNext above or below edge?
                if (TriangulationUtil.Orient2d(edge.Q, node.Prev.Prev.Point, edge.P) == Orientation.Cw)
                {
                    // Below
                    FillLeftConvexEdgeEvent(tcx, edge, node.Prev);
                }
            }
        }

        /// <summary>
        ///     Fills the left concave edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillLeftConcaveEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge,
            AdvancingFrontNode node)
        {
            Fill(tcx, node.Prev);
            if (node.Prev.Point != edge.P)
            {
                // GetNext above or below edge?
                if (TriangulationUtil.Orient2d(edge.Q, node.Prev.Point, edge.P) == Orientation.Cw)
                {
                    // Below
                    if (TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point) == Orientation.Cw)
                    {
                        // GetNext is concave
                        FillLeftConcaveEdgeEvent(tcx, edge, node);
                    }
                }
            }
        }

        /// <summary>
        ///     Fills the left below edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillLeftBelowEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            if (node.Point.X > edge.P.X)
            {
                if (TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point) == Orientation.Cw)
                {
                    // Concave 
                    FillLeftConcaveEdgeEvent(tcx, edge, node);
                }
                else
                {
                    // Convex
                    FillLeftConvexEdgeEvent(tcx, edge, node);

                    // Retry this one
                    FillLeftBelowEdgeEvent(tcx, edge, node);
                }
            }
        }

        /// <summary>
        ///     Fills the left above edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="edge">The edge</param>
        /// <param name="node">The node</param>
        private static void FillLeftAboveEdgeEvent(DtSweepContext tcx, DtSweepConstraint edge, AdvancingFrontNode node)
        {
            while (node.Prev.Point.X > edge.P.X)
            {
                // Check if next node is below the edge
                Orientation o1 = TriangulationUtil.Orient2d(edge.Q, node.Prev.Point, edge.P);
                if (o1 == Orientation.Cw)
                {
                    FillLeftBelowEdgeEvent(tcx, edge, node);
                }
                else
                {
                    node = node.Prev;
                }
            }
        }

        /// <summary>
        ///     Describes whether is edge side of triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        /// <param name="ep">The ep</param>
        /// <param name="eq">The eq</param>
        /// <returns>The bool</returns>
        private static bool IsEdgeSideOfTriangle(DelaunayTriangle triangle, TriangulationPoint ep,
            TriangulationPoint eq)
        {
            int index = triangle.EdgeIndex(ep, eq);
            if (index != -1)
            {
                triangle.MarkConstrainedEdge(index);
                triangle = triangle.Neighbors[index];
                if (triangle != null)
                {
                    triangle.MarkConstrainedEdge(ep, eq);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        ///     Edges the event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="ep">The ep</param>
        /// <param name="eq">The eq</param>
        /// <param name="triangle">The triangle</param>
        /// <param name="point">The point</param>
        /// <exception cref="PointOnEdgeException">EdgeEvent - Point on constrained edge not supported yet</exception>
        /// <exception cref="PointOnEdgeException">EdgeEvent - Point on constrained edge not supported yet</exception>
        private static void EdgeEvent(DtSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq,
            DelaunayTriangle triangle, TriangulationPoint point)
        {
            if (IsEdgeSideOfTriangle(triangle, ep, eq))
            {
                return;
            }

            TriangulationPoint p1 = triangle.PointCcw(point);
            Orientation o1 = TriangulationUtil.Orient2d(eq, p1, ep);
            if (o1 == Orientation.Collinear)
            {
                if (triangle.Contains(eq, p1))
                {
                    triangle.MarkConstrainedEdge(eq, p1);

                    // We are modifying the constraint maybe it would be better to 
                    // not change the given constraint and just keep a variable for the new constraint
                    tcx.EdgeEvent.ConstrainedEdge.Q = p1;
                    triangle = triangle.NeighborAcross(point);
                    EdgeEvent(tcx, ep, p1, triangle, p1);
                }
                else
                {
                    throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet");
                }

                if (tcx.IsDebugEnabled)
                {
                    Debug.WriteLine("EdgeEvent - Point on constrained edge");
                }

                return;
            }

            TriangulationPoint p2 = triangle.PointCw(point);
            Orientation o2 = TriangulationUtil.Orient2d(eq, p2, ep);
            if (o2 == Orientation.Collinear)
            {
                if (triangle.Contains(eq, p2))
                {
                    triangle.MarkConstrainedEdge(eq, p2);

                    // We are modifying the constraint maybe it would be better to 
                    // not change the given constraint and just keep a variable for the new constraint
                    tcx.EdgeEvent.ConstrainedEdge.Q = p2;
                    triangle = triangle.NeighborAcross(point);
                    EdgeEvent(tcx, ep, p2, triangle, p2);
                }
                else
                {
                    throw new PointOnEdgeException("EdgeEvent - Point on constrained edge not supported yet");
                }

                if (tcx.IsDebugEnabled)
                {
                    Debug.WriteLine("EdgeEvent - Point on constrained edge");
                }

                return;
            }

            if (o1 == o2)
            {
                // Need to decide if we are rotating CW or CCW to get to a triangle
                // that will cross edge
                triangle = o1 == Orientation.Cw ? triangle.NeighborCcw(point) : triangle.NeighborCw(point);

                EdgeEvent(tcx, ep, eq, triangle, point);
            }
            else
            {
                // This triangle crosses constraint so lets flip start!
                FlipEdgeEvent(tcx, ep, eq, triangle, point);
            }
        }

        /// <summary>
        ///     Flips the edge event using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="ep">The ep</param>
        /// <param name="eq">The eq</param>
        /// <param name="t">The </param>
        /// <param name="p">The </param>
        /// <exception cref="Exception">Intersecting Constraints</exception>
        private static void FlipEdgeEvent(DtSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq,
            DelaunayTriangle t, TriangulationPoint p)
        {
            DelaunayTriangle ot = t.NeighborAcross(p);

            if (t.GetConstrainedEdgeAcross(p))
            {
                throw new Exception("Intersecting Constraints");
            }

            TriangulationPoint op = ot.OppositePoint(t, p);
            bool inScanArea = TriangulationUtil.InScanArea(p, t.PointCcw(p), t.PointCw(p), op);

            if (inScanArea)
            {
                RotateSharedEdge(tcx, t, p, ot, op, ep, eq);
            }
            else
            {
                TriangulationPoint newP = NextFlipPoint(ep, eq, ot, op);
                FlipScanEdgeEvent(tcx, ep, eq, t, ot, newP);
                EdgeEvent(tcx, ep, eq, t, p);
            }
        }

        /// <summary>
        ///     Rotates the shared edge using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="t">The </param>
        /// <param name="p">The </param>
        /// <param name="ot">The ot</param>
        /// <param name="op">The op</param>
        /// <param name="ep">The ep</param>
        /// <param name="eq">The eq</param>
        private static void RotateSharedEdge(DtSweepContext tcx, DelaunayTriangle t, TriangulationPoint p,
            DelaunayTriangle ot, TriangulationPoint op, TriangulationPoint ep, TriangulationPoint eq)
        {
            // Rotate shared edge one vertex CW
            RotateTrianglePair(t, p, ot, op);
            tcx.MapTriangleToNodes(t);
            tcx.MapTriangleToNodes(ot);

            if ((p == eq) && (op == ep))
            {
                if ((eq == tcx.EdgeEvent.ConstrainedEdge.Q) && (ep == tcx.EdgeEvent.ConstrainedEdge.P))
                {
                    if (tcx.IsDebugEnabled)
                    {
                        Logger.Log("[FLIP] - constrained edge done");
                    }

                    t.MarkConstrainedEdge(ep, eq);
                    ot.MarkConstrainedEdge(ep, eq);
                    Legalize(tcx, t);
                    Legalize(tcx, ot);
                }
                else
                {
                    if (tcx.IsDebugEnabled)
                    {
                        Logger.Log("[FLIP] - sub edge done");
                    }
                }
            }
            else
            {
                if (tcx.IsDebugEnabled)
                {
                    Logger.Log("[FLIP] - flipping and continuing with triangle still crossing edge");
                }

                Orientation o = TriangulationUtil.Orient2d(eq, op, ep);
                t = NextFlipTriangle(tcx, o, t, ot, p, op);
                FlipEdgeEvent(tcx, ep, eq, t, p);
            }
        }

        /// <summary>
        ///     When we need to traverse from one triangle to the next we need the point in current triangle that is the
        ///     opposite point to the next triangle.
        /// </summary>
        private static TriangulationPoint NextFlipPoint(TriangulationPoint ep, TriangulationPoint eq,
            DelaunayTriangle ot, TriangulationPoint op)
        {
            Orientation o2d = TriangulationUtil.Orient2d(eq, op, ep);
            if (o2d == Orientation.Cw)
            {
                // Right
                return ot.PointCcw(op);
            }

            if (o2d == Orientation.Ccw)
            {
                // Left
                return ot.PointCw(op);
            }

            throw new PointOnEdgeException("Point on constrained edge not supported yet");
        }

        /// <summary>
        ///     After a flip we have two triangles and know that only one will still be intersecting the edge. So decide which
        ///     to continue with and legalize the other
        /// </summary>
        /// <param name="tcx"></param>
        /// <param name="o">should be the result of an TriangulationUtil.orient2d( eq, op, ep )</param>
        /// <param name="t">triangle 1</param>
        /// <param name="ot">triangle 2</param>
        /// <param name="p">a point shared by both triangles</param>
        /// <param name="op">another point shared by both triangles</param>
        /// <returns>returns the triangle still intersecting the edge</returns>
        private static DelaunayTriangle NextFlipTriangle(DtSweepContext tcx, Orientation o, DelaunayTriangle t,
            DelaunayTriangle ot, TriangulationPoint p, TriangulationPoint op)
        {
            int edgeIndex;
            if (o == Orientation.Ccw)
            {
                // ot is not crossing edge after flip
                edgeIndex = ot.EdgeIndex(p, op);
                ot.EdgeIsDelaunay[edgeIndex] = true;
                Legalize(tcx, ot);
                ot.EdgeIsDelaunay.Clear();
                return t;
            }

            // t is not crossing edge after flip
            edgeIndex = t.EdgeIndex(p, op);
            t.EdgeIsDelaunay[edgeIndex] = true;
            Legalize(tcx, t);
            t.EdgeIsDelaunay.Clear();
            return ot;
        }

        /// <summary>
        ///     Scan part of the FlipScan algorithm When a triangle pair isn't flippable we will scan for the next point that
        ///     is inside the flip triangle scan area. When found we generate a new flipEdgeEvent
        /// </summary>
        /// <param name="tcx"></param>
        /// <param name="ep">last point on the edge we are traversing</param>
        /// <param name="eq">first point on the edge we are traversing</param>
        /// <param name="flipTriangle">the current triangle sharing the point eq with edge</param>
        /// <param name="t"></param>
        /// <param name="p"></param>
        private static void FlipScanEdgeEvent(DtSweepContext tcx, TriangulationPoint ep, TriangulationPoint eq,
            DelaunayTriangle flipTriangle, DelaunayTriangle t, TriangulationPoint p)
        {
            DelaunayTriangle ot = t.NeighborAcross(p);

            TriangulationPoint op = ot.OppositePoint(t, p);

            bool inScanArea = TriangulationUtil.InScanArea(eq, flipTriangle.PointCcw(eq), flipTriangle.PointCw(eq), op);
            if (inScanArea)
            {
                // flip with new edge op->eq
                FlipEdgeEvent(tcx, eq, op, ot, op);
            }
            else
            {
                TriangulationPoint newP = NextFlipPoint(ep, eq, ot, op);
                FlipScanEdgeEvent(tcx, ep, eq, flipTriangle, ot, newP);
            }
        }

        /// <summary>Fills holes in the Advancing Front</summary>
        private static void FillAdvancingFront(DtSweepContext tcx, AdvancingFrontNode n)
        {
            double angle;

            // Fill right holes
            AdvancingFrontNode node = n.Next;
            while (node.HasNext)
            {
                // if HoleAngle exceeds 90 degrees then break.
                if (LargeHole_DontFill(node))
                {
                    break;
                }

                Fill(tcx, node);
                node = node.Next;
            }

            // Fill left holes
            node = n.Prev;
            while (node.HasPrev)
            {
                // if HoleAngle exceeds 90 degrees then break.
                if (LargeHole_DontFill(node))
                {
                    break;
                }

                angle = HoleAngle(node);
                if (angle > PiDiv2 || angle < -PiDiv2)
                {
                    break;
                }

                Fill(tcx, node);
                node = node.Prev;
            }

            // Fill right basins
            if (n.HasNext && n.Next.HasNext)
            {
                angle = BasinAngle(n);
                if (angle < Pi3Div4)
                {
                    FillBasin(tcx, n);
                }
            }
        }

        // True if HoleAngle exceeds 90 degrees.
        /// <summary>
        ///     Describes whether large hole dont fill
        /// </summary>
        /// <param name="node">The node</param>
        /// <returns>The bool</returns>
        private static bool LargeHole_DontFill(AdvancingFrontNode node)
        {
            AdvancingFrontNode nextNode = node.Next;
            AdvancingFrontNode prevNode = node.Prev;
            if (!AngleExceeds90Degrees(node.Point, nextNode.Point, prevNode.Point))
            {
                return false;
            }

            // Check additional points on front.
            AdvancingFrontNode next2Node = nextNode.Next;

            // "..Plus.." because only want angles on same side as point being added.
            if ((next2Node != null) &&
                !AngleExceedsPlus90DegreesOrIsNegative(node.Point, next2Node.Point, prevNode.Point))
            {
                return false;
            }

            AdvancingFrontNode prev2Node = prevNode.Prev;

            // "..Plus.." because only want angles on same side as point being added.
            if ((prev2Node != null) &&
                !AngleExceedsPlus90DegreesOrIsNegative(node.Point, nextNode.Point, prev2Node.Point))
            {
                return false;
            }

            return true;
        }

        /// <summary>
        ///     Describes whether angle exceeds 90 degrees
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <returns>The exceeds 90 degrees</returns>
        private static bool AngleExceeds90Degrees(TriangulationPoint origin, TriangulationPoint pa,
            TriangulationPoint pb)
        {
            double angle = Angle(origin, pa, pb);
            bool exceeds90Degrees = angle > PiDiv2 || angle < -PiDiv2;
            return exceeds90Degrees;
        }

        /// <summary>
        ///     Describes whether angle exceeds plus 90 degrees or is negative
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <returns>The exceeds plus 90 degrees or is negative</returns>
        private static bool AngleExceedsPlus90DegreesOrIsNegative(TriangulationPoint origin, TriangulationPoint pa,
            TriangulationPoint pb)
        {
            double angle = Angle(origin, pa, pb);
            bool exceedsPlus90DegreesOrIsNegative = angle > PiDiv2 || angle < 0;
            return exceedsPlus90DegreesOrIsNegative;
        }

        /// <summary>
        ///     Angles the origin
        /// </summary>
        /// <param name="origin">The origin</param>
        /// <param name="pa">The pa</param>
        /// <param name="pb">The pb</param>
        /// <returns>The angle</returns>
        private static double Angle(TriangulationPoint origin, TriangulationPoint pa, TriangulationPoint pb)
        {
            /* Complex plane
             * ab = cosA +i*sinA
             * ab = (ax + ay*i)(bx + by*i) = (ax*bx + ay*by) + i(ax*by-ay*bx)
             * atan2(y,x) computes the principal value of the argument function
             * applied to the complex number x+iy
             * Where x = ax*bx + ay*by
             * y = ax*by - ay*bx
             */
            double px = origin.X;
            double py = origin.Y;
            double ax = pa.X - px;
            double ay = pa.Y - py;
            double bx = pb.X - px;
            double by = pb.Y - py;
            double x = ax * by - ay * bx;
            double y = ax * bx + ay * by;
            double angle = Math.Atan2(x, y);
            return angle;
        }

        /// <summary>
        ///     Fills a basin that has formed on the Advancing Front to the right of given node. First we decide a left,bottom
        ///     and right node that forms the boundaries of the basin. Then we do a fill.
        /// </summary>
        /// <param name="tcx"></param>
        /// <param name="node">starting node, this or next node will be left node</param>
        private static void FillBasin(DtSweepContext tcx, AdvancingFrontNode node)
        {
            // tcx.basin.leftNode = node.next.next;
            tcx.Basin.LeftNode = TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point) == Orientation.Ccw ? node : node.Next;

            // Find the bottom and right node
            tcx.Basin.BottomNode = tcx.Basin.LeftNode;
            while (tcx.Basin.BottomNode.HasNext && (tcx.Basin.BottomNode.Point.Y >= tcx.Basin.BottomNode.Next.Point.Y))
            {
                tcx.Basin.BottomNode = tcx.Basin.BottomNode.Next;
            }

            if (tcx.Basin.BottomNode == tcx.Basin.LeftNode)
            {
                // No valid basins
                return;
            }

            tcx.Basin.RightNode = tcx.Basin.BottomNode;
            while (tcx.Basin.RightNode.HasNext && (tcx.Basin.RightNode.Point.Y < tcx.Basin.RightNode.Next.Point.Y))
            {
                tcx.Basin.RightNode = tcx.Basin.RightNode.Next;
            }

            if (tcx.Basin.RightNode == tcx.Basin.BottomNode)
            {
                // No valid basins
                return;
            }

            tcx.Basin.Width = tcx.Basin.RightNode.Point.X - tcx.Basin.LeftNode.Point.X;
            tcx.Basin.LeftHighest = tcx.Basin.LeftNode.Point.Y > tcx.Basin.RightNode.Point.Y;

            FillBasinReq(tcx, tcx.Basin.BottomNode);
        }

        /// <summary>Recursive algorithm to fill a Basin with triangles</summary>
        private static void FillBasinReq(DtSweepContext tcx, AdvancingFrontNode node)
        {
            // if shallow stop filling
            if (IsShallow(tcx, node))
            {
                return;
            }

            Fill(tcx, node);
            if ((node.Prev == tcx.Basin.LeftNode) && (node.Next == tcx.Basin.RightNode))
            {
                return;
            }

            if (node.Prev == tcx.Basin.LeftNode)
            {
                Orientation o = TriangulationUtil.Orient2d(node.Point, node.Next.Point, node.Next.Next.Point);
                if (o == Orientation.Cw)
                {
                    return;
                }

                node = node.Next;
            }
            else if (node.Next == tcx.Basin.RightNode)
            {
                Orientation o = TriangulationUtil.Orient2d(node.Point, node.Prev.Point, node.Prev.Prev.Point);
                if (o == Orientation.Ccw)
                {
                    return;
                }

                node = node.Prev;
            }
            else
            {
                // Continue with the neighbor node with lowest Y value
                node = node.Prev.Point.Y < node.Next.Point.Y ? node.Prev : node.Next;
            }

            FillBasinReq(tcx, node);
        }

        /// <summary>
        ///     Describes whether is shallow
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="node">The node</param>
        /// <returns>The bool</returns>
        private static bool IsShallow(DtSweepContext tcx, AdvancingFrontNode node)
        {
            double height;

            if (tcx.Basin.LeftHighest)
            {
                height = tcx.Basin.LeftNode.Point.Y - node.Point.Y;
            }
            else
            {
                height = tcx.Basin.RightNode.Point.Y - node.Point.Y;
            }

            if (tcx.Basin.Width > height)
            {
                return true;
            }

            return false;
        }

        /// <summary>???</summary>
        /// <param name="node">middle node</param>
        /// <returns>the angle between 3 front nodes</returns>
        private static double HoleAngle(AdvancingFrontNode node)
        {
            // XXX: do we really need a signed angle for holeAngle?
            //      could possible save some cycles here
            /* Complex plane
             * ab = cosA +i*sinA
             * ab = (ax + ay*i)(bx + by*i) = (ax*bx + ay*by) + i(ax*by-ay*bx)
             * atan2(y,x) computes the principal value of the argument function
             * applied to the complex number x+iy
             * Where x = ax*bx + ay*by
             *       y = ax*by - ay*bx
             */
            double px = node.Point.X;
            double py = node.Point.Y;
            double ax = node.Next.Point.X - px;
            double ay = node.Next.Point.Y - py;
            double bx = node.Prev.Point.X - px;
            double by = node.Prev.Point.Y - py;
            return Math.Atan2(ax * by - ay * bx, ax * bx + ay * by);
        }

        /// <summary>The basin angle is decided against the horizontal line [1,0]</summary>
        private static double BasinAngle(AdvancingFrontNode node)
        {
            double ax = node.Point.X - node.Next.Next.Point.X;
            double ay = node.Point.Y - node.Next.Next.Point.Y;
            return Math.Atan2(ay, ax);
        }

        /// <summary>Adds a triangle to the advancing front to fill a hole.</summary>
        /// <param name="tcx"></param>
        /// <param name="node">middle node, that is the bottom of the hole</param>
        private static void Fill(DtSweepContext tcx, AdvancingFrontNode node)
        {
            DelaunayTriangle triangle = new DelaunayTriangle(node.Prev.Point, node.Point, node.Next.Point);

            triangle.MarkNeighbor(node.Prev.Triangle);
            triangle.MarkNeighbor(node.Triangle);
            tcx.Triangles.Add(triangle);

            // Update the advancing front
            node.Prev.Next = node.Next;
            node.Next.Prev = node.Prev;
            tcx.RemoveNode(node);

            // If it was legalized the triangle has already been mapped
            if (!Legalize(tcx, triangle))
            {
                tcx.MapTriangleToNodes(triangle);
            }
        }

        /// <summary>
        ///     Determines if a triangle is legalized and legalizes it if needed.
        /// </summary>
        /// <param name="tcx">The sweep context.</param>
        /// <param name="t">The triangle to check and legalize.</param>
        /// <returns>True if the triangle was legalized, false otherwise.</returns>
        private static bool Legalize(DtSweepContext tcx, DelaunayTriangle t)
        {
            for (int i = 0; i < 3; i++)
            {
                if (t.EdgeIsDelaunay[i])
                {
                    continue;
                }

                DelaunayTriangle ot = t.Neighbors[i];
                if (ot != null)
                {
                    TriangulationPoint p = t.Points[i];
                    TriangulationPoint op = ot.OppositePoint(t, p);
                    int oi = ot.IndexOf(op);

                    if (ShouldNotLegalize(ot, oi))
                    {
                        HandleEdgeIsConstrained(t, i, ot, oi);
                        continue;
                    }

                    if (IsInsideCirCircle(p, t.PointCcw(p), t.PointCw(p), op))
                    {
                        t.EdgeIsDelaunay[i] = true;
                        ot.EdgeIsDelaunay[oi] = true;

                        if (!TryLegalizeTriangle(tcx, t, ot, p, op))
                        {
                            tcx.MapTriangleToNodes(t);
                            tcx.MapTriangleToNodes(ot);
                        }

                        t.EdgeIsDelaunay[i] = false;
                        ot.EdgeIsDelaunay[oi] = false;

                        return true;
                    }
                }
            }

            return false;
        }

        /// <summary>
        ///     Handles the edge is constrained using the specified t
        /// </summary>
        /// <param name="t">The </param>
        /// <param name="edgeIndex">The edge index</param>
        /// <param name="ot">The ot</param>
        /// <param name="oppositeIndex">The opposite index</param>
        private static void HandleEdgeIsConstrained(DelaunayTriangle t, int edgeIndex, DelaunayTriangle ot, int oppositeIndex)
        {
            t.EdgeIsConstrained[edgeIndex] = ot.EdgeIsConstrained[oppositeIndex];
        }

        /// <summary>
        ///     Describes whether try legalize triangle
        /// </summary>
        /// <param name="tcx">The tcx</param>
        /// <param name="t">The </param>
        /// <param name="ot">The ot</param>
        /// <param name="p">The </param>
        /// <param name="op">The op</param>
        /// <returns>The bool</returns>
        private static bool TryLegalizeTriangle(DtSweepContext tcx, DelaunayTriangle t, DelaunayTriangle ot, TriangulationPoint p, TriangulationPoint op)
        {
            RotateTrianglePair(t, p, ot, op);

            bool notLegalized = !Legalize(tcx, t);
            if (notLegalized)
            {
                tcx.MapTriangleToNodes(t);
            }

            notLegalized = !Legalize(tcx, ot);
            if (notLegalized)
            {
                tcx.MapTriangleToNodes(ot);
            }

            return true;
        }


        /// <summary>
        ///     Checks if an edge should not be legalized.
        /// </summary>
        /// <param name="ot">The neighboring triangle.</param>
        /// <param name="oi">The index of the opposite point.</param>
        /// <returns>True if the edge should not be legalized, false otherwise.</returns>
        private static bool ShouldNotLegalize(DelaunayTriangle ot, int oi) => ot.EdgeIsConstrained[oi] || ot.EdgeIsDelaunay[oi];

        /// <summary>
        ///     Checks if a point is inside the cir circle of a triangle.
        /// </summary>
        /// <param name="p">The point to check.</param>
        /// <param name="a">The first triangle vertex.</param>
        /// <param name="b">The second triangle vertex.</param>
        /// <param name="c">The third triangle vertex.</param>
        /// <returns>True if the point is inside the cir circle, false otherwise.</returns>
        private static bool IsInsideCirCircle(TriangulationPoint p, TriangulationPoint a, TriangulationPoint b, TriangulationPoint c) => TriangulationUtil.SmartIncircle(p, a, b, c);


        /// <summary>
        ///     Rotates a triangle pair one vertex CW
        ///     n2                    n2
        ///     Position +-----+             Position +-----+
        ///     | t  /|               |\  t |
        ///     |   / |               | \   |
        ///     n1|  /  |n3           n1|  \  |n3
        ///     | /   |    after CW   |   \ |
        ///     |/ oT |               | oT \|
        ///     +-----+ oP            +-----+
        ///     n4                    n4
        /// </summary>
        private static void RotateTrianglePair(DelaunayTriangle t, TriangulationPoint p, DelaunayTriangle ot,
            TriangulationPoint op)
        {
            DelaunayTriangle n1 = t.NeighborCcw(p);
            DelaunayTriangle n2 = t.NeighborCw(p);
            DelaunayTriangle n3 = ot.NeighborCcw(op);
            DelaunayTriangle n4 = ot.NeighborCw(op);

            bool ce1 = t.GetConstrainedEdgeCcw(p);
            bool ce2 = t.GetConstrainedEdgeCw(p);
            bool ce3 = ot.GetConstrainedEdgeCcw(op);
            bool ce4 = ot.GetConstrainedEdgeCw(op);

            bool de1 = t.GetDelaunayEdgeCcw(p);
            bool de2 = t.GetDelaunayEdgeCw(p);
            bool de3 = ot.GetDelaunayEdgeCcw(op);
            bool de4 = ot.GetDelaunayEdgeCw(op);

            t.Legalize(p, op);
            ot.Legalize(op, p);

            // Remap dEdge
            ot.SetDelaunayEdgeCcw(p, de1);
            t.SetDelaunayEdgeCw(p, de2);
            t.SetDelaunayEdgeCcw(op, de3);
            ot.SetDelaunayEdgeCw(op, de4);

            // Remap cEdge
            ot.SetConstrainedEdgeCcw(p, ce1);
            t.SetConstrainedEdgeCw(p, ce2);
            t.SetConstrainedEdgeCcw(op, ce3);
            ot.SetConstrainedEdgeCw(op, ce4);

            // Remap neighbors
            // XXX: might optimize the markNeighbor by keeping track of
            //      what side should be assigned to what neighbor after the 
            //      rotation. Now mark neighbor does lots of testing to find 
            //      the right side.
            t.Neighbors.Clear();
            ot.Neighbors.Clear();
            if (n1 != null)
            {
                ot.MarkNeighbor(n1);
            }

            if (n2 != null)
            {
                t.MarkNeighbor(n2);
            }

            if (n3 != null)
            {
                t.MarkNeighbor(n3);
            }

            if (n4 != null)
            {
                ot.MarkNeighbor(n4);
            }

            t.MarkNeighbor(ot);
        }
    }
}