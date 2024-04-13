// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DelaunayTriangle.cs
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
using Alis.Core.Physic.Shared.Optimization;
using Alis.Extension.Math.PathGenerator.Triangulation.Delaunay.Delaunay.Sweep;

namespace Alis.Extension.Math.PathGenerator.Triangulation.Delaunay.Delaunay
{
    /// <summary>
    ///     The delaunay triangle class
    /// </summary>
    internal class DelaunayTriangle
    {
        /// <summary>Neighbor pointers. Flags to determine if an edge is a edge</summary>
        public FixedArray3<bool> EdgeIsConstrained;
        
        /// <summary>Flags to determine if an edge is a Constrained edge</summary>
        public FixedArray3<bool> EdgeIsDelaunay;
        
        /// <summary>
        ///     The neighbors
        /// </summary>
        public FixedArray3<DelaunayTriangle> Neighbors;
        
        /// <summary>Has this triangle been marked as an interior triangle?</summary>
        public FixedArray3<TriangulationPoint> Points;
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="DelaunayTriangle" /> class
        /// </summary>
        /// <param name="p1">The </param>
        /// <param name="p2">The </param>
        /// <param name="p3">The </param>
        public DelaunayTriangle(TriangulationPoint p1, TriangulationPoint p2, TriangulationPoint p3)
        {
            Points[0] = p1;
            Points[1] = p2;
            Points[2] = p3;
        }
        
        /// <summary>
        ///     Gets or sets the value of the is interior
        /// </summary>
        public bool IsInterior { get; set; }
        
        /// <summary>
        ///     Indexes the of using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <exception cref="Exception">Calling index with a point that doesn't exist in triangle</exception>
        /// <returns>The </returns>
        public int IndexOf(TriangulationPoint p)
        {
            int i = Points.IndexOf(p);
            if (i == -1)
            {
                throw new Exception("Calling index with a point that doesn't exist in triangle");
            }
            
            return i;
        }
        
        /// <summary>
        ///     Indexes the cw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The int</returns>
        public int IndexCw(TriangulationPoint p)
        {
            int index = IndexOf(p);
            switch (index)
            {
                case 0:
                    return 2;
                case 1:
                    return 0;
                default:
                    return 1;
            }
        }
        
        /// <summary>
        ///     Indexes the ccw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The int</returns>
        private int IndexCcw(TriangulationPoint p)
        {
            int index = IndexOf(p);
            switch (index)
            {
                case 0:
                    return 1;
                case 1:
                    return 2;
                default:
                    return 0;
            }
        }
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool Contains(TriangulationPoint p) => p == Points[0] || p == Points[1] || p == Points[2];
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="e">The </param>
        /// <returns>The bool</returns>
        public bool Contains(DtSweepConstraint e) => Contains(e.P) && Contains(e.Q);
        
        /// <summary>
        ///     Describes whether this instance contains
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="q">The </param>
        /// <returns>The bool</returns>
        public bool Contains(TriangulationPoint p, TriangulationPoint q) => Contains(p) && Contains(q);
        
        /// <summary>Update neighbor pointers</summary>
        /// <param name="p1">Point 1 of the shared edge</param>
        /// <param name="p2">Point 2 of the shared edge</param>
        /// <param name="t">This triangle's new neighbor</param>
        private void MarkNeighbor(TriangulationPoint p1, TriangulationPoint p2, DelaunayTriangle t)
        {
            if (((p1 == Points[2]) && (p2 == Points[1])) || ((p1 == Points[1]) && (p2 == Points[2])))
            {
                Neighbors[0] = t;
            }
            else if (((p1 == Points[0]) && (p2 == Points[2])) || ((p1 == Points[2]) && (p2 == Points[0])))
            {
                Neighbors[1] = t;
            }
            else if (((p1 == Points[0]) && (p2 == Points[1])) || ((p1 == Points[1]) && (p2 == Points[0])))
            {
                Neighbors[2] = t;
            }
            else
            {
                Debug.WriteLine("Neighbor error, please report!");
                
                // throw new Exception("Neighbor error, please report!");
            }
        }
        
        /// <summary>Exhaustive search to update neighbor pointers</summary>
        public void MarkNeighbor(DelaunayTriangle t)
        {
            if (t.Contains(Points[1], Points[2]))
            {
                Neighbors[0] = t;
                t.MarkNeighbor(Points[1], Points[2], this);
            }
            else if (t.Contains(Points[0], Points[2]))
            {
                Neighbors[1] = t;
                t.MarkNeighbor(Points[0], Points[2], this);
            }
            else if (t.Contains(Points[0], Points[1]))
            {
                Neighbors[2] = t;
                t.MarkNeighbor(Points[0], Points[1], this);
            }
            else
            {
                Debug.WriteLine("markNeighbor failed");
            }
        }
        
        /// <summary>
        ///     Clears the neighbors
        /// </summary>
        private void ClearNeighbors()
        {
            Neighbors[0] = Neighbors[1] = Neighbors[2] = null;
        }
        
        /// <summary>
        ///     Clears the neighbor using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        private void ClearNeighbor(DelaunayTriangle triangle)
        {
            if (Neighbors[0] == triangle)
            {
                Neighbors[0] = null;
            }
            else if (Neighbors[1] == triangle)
            {
                Neighbors[1] = null;
            }
            else
            {
                Neighbors[2] = null;
            }
        }
        
        /// <summary>Clears all references to all other triangles and points</summary>
        public void Clear()
        {
            for (int i = 0; i < 3; i++)
            {
                DelaunayTriangle t = Neighbors[i];
                t?.ClearNeighbor(this);
            }
            
            ClearNeighbors();
            Points[0] = Points[1] = Points[2] = null;
        }
        
        /// <param name="t">Opposite triangle</param>
        /// <param name="p">The point in t that isn't shared between the triangles</param>
        public TriangulationPoint OppositePoint(DelaunayTriangle t, TriangulationPoint p)
        {
            Debug.Assert(t != this, "self-pointer error");
            return PointCw(t.PointCw(p));
        }
        
        /// <summary>
        ///     Neighbors the cw using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The delaunay triangle</returns>
        public DelaunayTriangle NeighborCw(TriangulationPoint point) => Neighbors[(Points.IndexOf(point) + 1) % 3];
        
        /// <summary>
        ///     Neighbors the ccw using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The delaunay triangle</returns>
        public DelaunayTriangle NeighborCcw(TriangulationPoint point) => Neighbors[(Points.IndexOf(point) + 2) % 3];
        
        /// <summary>
        ///     Neighbors the across using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The delaunay triangle</returns>
        public DelaunayTriangle NeighborAcross(TriangulationPoint point) => Neighbors[Points.IndexOf(point)];
        
        /// <summary>
        ///     Points the ccw using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The triangulation point</returns>
        public TriangulationPoint PointCcw(TriangulationPoint point) => Points[(IndexOf(point) + 1) % 3];
        
        /// <summary>
        ///     Points the cw using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        /// <returns>The triangulation point</returns>
        public TriangulationPoint PointCw(TriangulationPoint point) => Points[(IndexOf(point) + 2) % 3];
        
        /// <summary>
        ///     Rotates the cw
        /// </summary>
        private void RotateCw()
        {
            TriangulationPoint t = Points[2];
            Points[2] = Points[1];
            Points[1] = Points[0];
            Points[0] = t;
        }
        
        /// <summary>Legalize triangle by rotating clockwise around oPoint</summary>
        /// <param name="oPoint">The origin point to rotate around</param>
        /// <param name="nPoint">???</param>
        public void Legalize(TriangulationPoint oPoint, TriangulationPoint nPoint)
        {
            RotateCw();
            Points[IndexCcw(oPoint)] = nPoint;
        }
        
        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => Points[0] + "," + Points[1] + "," + Points[2];
        
        /// <summary>Finalize edge marking</summary>
        public void MarkNeighborEdges()
        {
            for (int i = 0; i < 3; i++)
            {
                if (EdgeIsConstrained[i] && (Neighbors[i] != null))
                {
                    Neighbors[i].MarkConstrainedEdge(Points[(i + 1) % 3], Points[(i + 2) % 3]);
                }
            }
        }
        
        /// <summary>
        ///     Marks the edge using the specified triangle
        /// </summary>
        /// <param name="triangle">The triangle</param>
        public void MarkEdge(DelaunayTriangle triangle)
        {
            for (int i = 0; i < 3; i++)
            {
                if (EdgeIsConstrained[i])
                {
                    triangle.MarkConstrainedEdge(Points[(i + 1) % 3], Points[(i + 2) % 3]);
                }
            }
        }
        
        /// <summary>
        ///     Marks the edge using the specified t list
        /// </summary>
        /// <param name="tList">The list</param>
        public void MarkEdge(List<DelaunayTriangle> tList)
        {
            foreach (DelaunayTriangle t in tList)
            {
                for (int i = 0; i < 3; i++)
                {
                    if (t.EdgeIsConstrained[i])
                    {
                        MarkConstrainedEdge(t.Points[(i + 1) % 3], t.Points[(i + 2) % 3]);
                    }
                }
            }
        }
        
        /// <summary>
        ///     Marks the constrained edge using the specified index
        /// </summary>
        /// <param name="index">The index</param>
        public void MarkConstrainedEdge(int index)
        {
            EdgeIsConstrained[index] = true;
        }
        
        /// <summary>
        ///     Marks the constrained edge using the specified edge
        /// </summary>
        /// <param name="edge">The edge</param>
        public void MarkConstrainedEdge(DtSweepConstraint edge)
        {
            MarkConstrainedEdge(edge.P, edge.Q);
        }
        
        /// <summary>Mark edge as constrained</summary>
        public void MarkConstrainedEdge(TriangulationPoint p, TriangulationPoint q)
        {
            int i = EdgeIndex(p, q);
            if (i != -1)
            {
                EdgeIsConstrained[i] = true;
            }
        }
        
        /// <summary>
        ///     Areas this instance
        /// </summary>
        /// <returns>The double</returns>
        public double Area()
        {
            double b = Points[0].X - Points[1].X;
            double h = Points[2].Y - Points[1].Y;
            
            return System.Math.Abs(b * h * 0.5f);
        }
        
        /// <summary>
        ///     Centroids this instance
        /// </summary>
        /// <returns>The triangulation point</returns>
        public TriangulationPoint Centroid()
        {
            double cx = (Points[0].X + Points[1].X + Points[2].X) / 3f;
            double cy = (Points[0].Y + Points[1].Y + Points[2].Y) / 3f;
            return new TriangulationPoint(cx, cy);
        }
        
        /// <summary>Get the index of the neighbor that shares this edge (or -1 if it isn't shared)</summary>
        /// <returns>index of the shared edge or -1 if edge isn't shared</returns>
        public int EdgeIndex(TriangulationPoint p1, TriangulationPoint p2)
        {
            int i1 = Points.IndexOf(p1);
            int i2 = Points.IndexOf(p2);
            
            // Points of this triangle in the edge p1-p2
            bool a = i1 == 0 || i2 == 0;
            bool b = i1 == 1 || i2 == 1;
            bool c = i1 == 2 || i2 == 2;
            
            if (b && c)
            {
                return 0;
            }
            
            if (a && c)
            {
                return 1;
            }
            
            if (a && b)
            {
                return 2;
            }
            
            return -1;
        }
        
        /// <summary>
        ///     Describes whether this instance get constrained edge ccw
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetConstrainedEdgeCcw(TriangulationPoint p) => EdgeIsConstrained[(IndexOf(p) + 2) % 3];
        
        /// <summary>
        ///     Describes whether this instance get constrained edge cw
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetConstrainedEdgeCw(TriangulationPoint p) => EdgeIsConstrained[(IndexOf(p) + 1) % 3];
        
        /// <summary>
        ///     Describes whether this instance get constrained edge across
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetConstrainedEdgeAcross(TriangulationPoint p) => EdgeIsConstrained[IndexOf(p)];
        
        /// <summary>
        ///     Sets the constrained edge ccw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetConstrainedEdgeCcw(TriangulationPoint p, bool ce)
        {
            EdgeIsConstrained[(IndexOf(p) + 2) % 3] = ce;
        }
        
        /// <summary>
        ///     Sets the constrained edge cw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetConstrainedEdgeCw(TriangulationPoint p, bool ce)
        {
            EdgeIsConstrained[(IndexOf(p) + 1) % 3] = ce;
        }
        
        /// <summary>
        ///     Sets the constrained edge across using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetConstrainedEdgeAcross(TriangulationPoint p, bool ce)
        {
            EdgeIsConstrained[IndexOf(p)] = ce;
        }
        
        /// <summary>
        ///     Describes whether this instance get delaunay edge ccw
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetDelaunayEdgeCcw(TriangulationPoint p) => EdgeIsDelaunay[(IndexOf(p) + 2) % 3];
        
        /// <summary>
        ///     Describes whether this instance get delaunay edge cw
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetDelaunayEdgeCw(TriangulationPoint p) => EdgeIsDelaunay[(IndexOf(p) + 1) % 3];
        
        /// <summary>
        ///     Describes whether this instance get delaunay edge across
        /// </summary>
        /// <param name="p">The </param>
        /// <returns>The bool</returns>
        public bool GetDelaunayEdgeAcross(TriangulationPoint p) => EdgeIsDelaunay[IndexOf(p)];
        
        /// <summary>
        ///     Sets the delaunay edge ccw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetDelaunayEdgeCcw(TriangulationPoint p, bool ce)
        {
            EdgeIsDelaunay[(IndexOf(p) + 2) % 3] = ce;
        }
        
        /// <summary>
        ///     Sets the delaunay edge cw using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetDelaunayEdgeCw(TriangulationPoint p, bool ce)
        {
            EdgeIsDelaunay[(IndexOf(p) + 1) % 3] = ce;
        }
        
        /// <summary>
        ///     Sets the delaunay edge across using the specified p
        /// </summary>
        /// <param name="p">The </param>
        /// <param name="ce">The ce</param>
        public void SetDelaunayEdgeAcross(TriangulationPoint p, bool ce)
        {
            EdgeIsDelaunay[IndexOf(p)] = ce;
        }
    }
}