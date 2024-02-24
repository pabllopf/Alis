// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DTSweepContext.cs
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

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay.Sweep
{
    internal class DtSweepContext : TriangulationContext
    {
        /// <summary>
        ///     The alpha
        /// </summary>
        private const float Alpha = 0.3f;

        /// <summary>
        ///     The dt sweep basin
        /// </summary>
        public readonly DtSweepBasin Basin = new DtSweepBasin();

        /// <summary>
        ///     The dt sweep point comparator
        /// </summary>
        private readonly DtSweepPointComparator comparator = new DtSweepPointComparator();

        /// <summary>
        ///     The dt sweep edge event
        /// </summary>
        public readonly DtSweepEdgeEvent EdgeEvent = new DtSweepEdgeEvent();

        /// <summary>
        ///     The front
        /// </summary>
        public AdvancingFront AFront;

        /// <summary>
        ///     Initializes a new instance of the <see cref="DtSweepContext" /> class
        /// </summary>
        public DtSweepContext()
        {
            Clear();
        }

        /// <summary>
        ///     Gets or sets the value of the head
        /// </summary>
        private TriangulationPoint Head { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tail
        /// </summary>
        private TriangulationPoint Tail { get; set; }

        /// <summary>
        ///     Removes the from list using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        public void RemoveFromList(DelaunayTriangle triangle)
        {
            Triangles.Remove(triangle);
        }

        /// <summary>
        ///     Meshes the clean using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        public void MeshClean(DelaunayTriangle triangle)
        {
            MeshCleanReq(triangle);
        }

        /// <summary>
        ///     Meshes the clean req using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        private void MeshCleanReq(DelaunayTriangle triangle)
        {
            if (triangle is {IsInterior: false})
            {
                triangle.IsInterior = true;
                Triangulatable.AddTriangle(triangle);
                for (int i = 0; i < 3; i++)
                {
                    if (!triangle.EdgeIsConstrained[i])
                    {
                        MeshCleanReq(triangle.Neighbors[i]);
                    }
                }
            }
        }

        /// <summary>
        ///     Clears this instance
        /// </summary>
        public sealed override void Clear()
        {
            base.Clear();
            Triangles.Clear();
        }

        /// <summary>
        ///     Adds the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void AddNode(AdvancingFrontNode node)
        {
            AFront.AddNode(node);
        }

        /// <summary>
        ///     Removes the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void RemoveNode(AdvancingFrontNode node)
        {
            AFront.RemoveNode(node);
        }

        /// <summary>
        ///     Locates the node using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The advancing front node</returns>
        public AdvancingFrontNode LocateNode(TriangulationPoint point) => AFront.LocateNode(point);

        /// <summary>
        ///     Creates the advancing front
        /// </summary>
        public void CreateAdvancingFront()
        {
            // Initial triangle
            DelaunayTriangle iTriangle = new DelaunayTriangle(Points[0], Tail, Head);
            Triangles.Add(iTriangle);

            AdvancingFrontNode head = new AdvancingFrontNode(iTriangle.Points[1])
            {
                Triangle = iTriangle
            };

            AdvancingFrontNode middle = new AdvancingFrontNode(iTriangle.Points[0])
            {
                Triangle = iTriangle
            };

            AdvancingFrontNode tail = new AdvancingFrontNode(iTriangle.Points[2]);

            AFront = new AdvancingFront(head, tail);
            AFront.AddNode(middle);

            AFront.Head.Next = middle;
            middle.Next = AFront.Tail;
            middle.Prev = AFront.Head;
            AFront.Tail.Prev = middle;
        }

        /// <summary>Try to map a node to all sides of this triangle that don't have a neighbor.</summary>
        public void MapTriangleToNodes(DelaunayTriangle t)
        {
            for (int i = 0; i < 3; i++)
            {
                if (t.Neighbors[i] == null)
                {
                    AdvancingFrontNode n = AFront.LocatePoint(t.PointCw(t.Points[i]));
                    if (n != null)
                    {
                        n.Triangle = t;
                    }
                }
            }
        }

        /// <summary>
        ///     Prepares the triangulation using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public override void PrepareTriangulation(ITriangulatable t)
        {
            base.PrepareTriangulation(t);

            double xMin;
            double yMin;

            double xMax = xMin = Points[0].X;
            double yMax = yMin = Points[0].Y;

            // Calculate bounds. Should be combined with the sorting
            foreach (TriangulationPoint p in Points)
            {
                if (p.X > xMax)
                {
                    xMax = p.X;
                }

                if (p.X < xMin)
                {
                    xMin = p.X;
                }

                if (p.Y > yMax)
                {
                    yMax = p.Y;
                }

                if (p.Y < yMin)
                {
                    yMin = p.Y;
                }
            }

            double deltaX = Alpha * (xMax - xMin);
            double deltaY = Alpha * (yMax - yMin);
            TriangulationPoint p1 = new TriangulationPoint(xMax + deltaX, yMin - deltaY);
            TriangulationPoint p2 = new TriangulationPoint(xMin - deltaX, yMin - deltaY);

            Head = p1;
            Tail = p2;

            //        long time = System.nanoTime();
            // Sort the points along y-axis
            Points.Sort(comparator);

            //        logger.info( "Triangulation setup [{}ms]", ( System.nanoTime() - time ) / 1e6 );
        }

        /// <summary>
        ///     Finalizes the triangulation
        /// </summary>
        public void FinalizeTriangulation()
        {
            Triangulatable.AddTriangles(Triangles);
            Triangles.Clear();
        }

        /// <summary>
        ///     News the constraint using the specified a
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <returns>The triangulation constraint</returns>
        public override TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b) =>
            new DtSweepConstraint(a, b);

        /// <summary>
        ///     The dt sweep basin class
        /// </summary>
        public class DtSweepBasin
        {
            /// <summary>
            ///     The bottom node
            /// </summary>
            public AdvancingFrontNode BottomNode;

            /// <summary>
            ///     The left highest
            /// </summary>
            public bool LeftHighest;

            /// <summary>
            ///     The left node
            /// </summary>
            public AdvancingFrontNode LeftNode;

            /// <summary>
            ///     The right node
            /// </summary>
            public AdvancingFrontNode RightNode;

            /// <summary>
            ///     The width
            /// </summary>
            public double Width;
        }

        /// <summary>
        ///     The dt sweep edge event class
        /// </summary>
        public class DtSweepEdgeEvent
        {
            /// <summary>
            ///     The constrained edge
            /// </summary>
            public DtSweepConstraint ConstrainedEdge;

            /// <summary>
            ///     The right
            /// </summary>
            public bool Right;
        }
    }
}