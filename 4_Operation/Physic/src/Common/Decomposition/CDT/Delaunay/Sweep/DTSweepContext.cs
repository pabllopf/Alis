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

namespace Alis.Core.Physic.Common.Decomposition.CDT.Delaunay.Sweep
{
    /// <summary>
    ///     The dt sweep context class
    /// </summary>
    /// <seealso cref="TriangulationContext" />
    internal class DtSweepContext : TriangulationContext
    {
        // Inital triangle factor, seed triangle will extend 30% of 
        // PointSet width to both left and right.
        /// <summary>
        ///     The alpha
        /// </summary>
        private const float Alpha = 0.3f;

        /// <summary>
        ///     The dt sweep point comparator
        /// </summary>
        private readonly DtSweepPointComparator _comparator = new DtSweepPointComparator();

        /// <summary>
        ///     The front
        /// </summary>
        public AdvancingFront AFront;

        /// <summary>
        ///     The dt sweep basin
        /// </summary>
        public readonly DtSweepBasin Basin = new DtSweepBasin();

        /// <summary>
        ///     The dt sweep edge event
        /// </summary>
        public readonly DtSweepEdgeEvent EdgeEvent = new DtSweepEdgeEvent();

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
        public TriangulationPoint Head { get; set; }

        /// <summary>
        ///     Gets or sets the value of the tail
        /// </summary>
        public TriangulationPoint Tail { get; set; }

        /// <summary>
        ///     Removes the from list using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        public void RemoveFromList(DelaunayTriangle triangle)
        {
            Triangles.Remove(triangle);

            //        for( int i=0; i<3; i++ )
            //        {
            //            if( triangle.neighbors[i] != null )
            //            {
            //                triangle.neighbors[i].clearNeighbor( triangle );
            //            }
            //        }
            //        triangle.clearNeighbors();
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
            if ((triangle != null) && !triangle.IsInterior)
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
        public override void Clear()
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
            //       Logger.Info( "add:" + node.key + ":" + System.identityHashCode(node.key));
            //        m_nodeTree.put( node.getKey(), node );
            AFront.AddNode(node);
        }

        /// <summary>
        ///     Removes the node using the specified node
        /// </summary>
        /// <param name="node">The node</param>
        public void RemoveNode(AdvancingFrontNode node)
        {
            //       Logger.Info( "remove:" + node.key + ":" + System.identityHashCode(node.key));
            //        m_nodeTree.delete( node.getKey() );
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
            AdvancingFrontNode head, tail, middle;
            // Initial triangle
            DelaunayTriangle iTriangle = new DelaunayTriangle(Points[0], Tail, Head);
            Triangles.Add(iTriangle);

            head = new AdvancingFrontNode(iTriangle.Points[1]);
            head.Triangle = iTriangle;
            middle = new AdvancingFrontNode(iTriangle.Points[0]);
            middle.Triangle = iTriangle;
            tail = new AdvancingFrontNode(iTriangle.Points[2]);

            AFront = new AdvancingFront(head, tail);
            AFront.AddNode(middle);


            //       so swap head and tail
            AFront.Head.Next = middle;
            middle.Next = AFront.Tail;
            middle.Prev = AFront.Head;
            AFront.Tail.Prev = middle;
        }

        /// <summary>
        ///     Try to map a node to all sides of this triangle that don't have
        ///     a neighbor.
        /// </summary>
        public void MapTriangleToNodes(DelaunayTriangle t)
        {
            AdvancingFrontNode n;
            for (int i = 0; i < 3; i++)
            {
                if (t.Neighbors[i] == null)
                {
                    n = AFront.LocatePoint(t.PointCw(t.Points[i]));
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

            double xmax, xmin;
            double ymax, ymin;

            xmax = xmin = Points[0].X;
            ymax = ymin = Points[0].Y;

            // Calculate bounds. Should be combined with the sorting
            foreach (TriangulationPoint p in Points)
            {
                if (p.X > xmax)
                {
                    xmax = p.X;
                }

                if (p.X < xmin)
                {
                    xmin = p.X;
                }

                if (p.Y > ymax)
                {
                    ymax = p.Y;
                }

                if (p.Y < ymin)
                {
                    ymin = p.Y;
                }
            }

            double deltaX = Alpha * (xmax - xmin);
            double deltaY = Alpha * (ymax - ymin);
            TriangulationPoint p1 = new TriangulationPoint(xmax + deltaX, ymin - deltaY);
            TriangulationPoint p2 = new TriangulationPoint(xmin - deltaX, ymin - deltaY);

            Head = p1;
            Tail = p2;

            //        long time = System.nanoTime();
            // Sort the points along y-axis
            Points.Sort(_comparator);
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
        public override TriangulationConstraint NewConstraint(TriangulationPoint a, TriangulationPoint b) => new DtSweepConstraint(a, b);

        #region Nested type: DTSweepBasin

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

        #endregion

        #region Nested type: DTSweepEdgeEvent

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

        #endregion
    }
}