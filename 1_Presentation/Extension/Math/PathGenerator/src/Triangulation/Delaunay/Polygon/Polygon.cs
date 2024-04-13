// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Polygon.cs
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
using System.Linq;
using Alis.Extension.Math.PathGenerator.Triangulation.Delaunay.Delaunay;

namespace Alis.Extension.Math.PathGenerator.Triangulation.Delaunay.Polygon
{
    /// <summary>
    ///     The polygon class
    /// </summary>
    /// <seealso cref="ITriangulatable" />
    internal class Polygon : ITriangulatable
    {
        /// <summary>
        ///     The triangulation point
        /// </summary>
        private readonly List<TriangulationPoint> pointsPrivate = new List<TriangulationPoint>();
        
        /// <summary>
        ///     The holes
        /// </summary>
        private List<Polygon> holesPrivate;
        
        /// <summary>
        ///     The last
        /// </summary>
        private PolygonPoint lastPrivate;
        
        /// <summary>
        ///     The steiner points
        /// </summary>
        private List<TriangulationPoint> steinerPointsPrivate;
        
        /// <summary>
        ///     The triangles
        /// </summary>
        private List<DelaunayTriangle> trianglesPrivate;
        
        /// <summary>Create a polygon from a list of at least 3 points with no duplicates.</summary>
        /// <param name="points">A list of unique points</param>
        public Polygon(IList<PolygonPoint> points)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("List has fewer than 3 points", nameof(points));
            }
            
            // Lets do one sanity check that first and last point hasn't got same position
            // Its something that often happen when importing polygon data from other formats
            if (points[0].Equals(points[points.Count - 1]))
            {
                points.RemoveAt(points.Count - 1);
            }
            
            pointsPrivate.AddRange(points);
        }
        
        /// <summary>Create a polygon from a list of at least 3 points with no duplicates.</summary>
        /// <param name="points">A list of unique points.</param>
        public Polygon(IEnumerable<PolygonPoint> points) : this(points as IList<PolygonPoint> ?? points.ToArray())
        {
        }
        
        /// <summary>
        ///     Initializes a new instance of the <see cref="Polygon" /> class
        /// </summary>
        public Polygon()
        {
        }
        
        /// <summary>
        ///     Gets the value of the holes
        /// </summary>
        public IList<Polygon> Holes => holesPrivate;
        
        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode => TriangulationMode.Polygon;
        
        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        public IList<TriangulationPoint> Points => pointsPrivate;
        
        /// <summary>
        ///     Gets the value of the triangles
        /// </summary>
        public IList<DelaunayTriangle> Triangles => trianglesPrivate;
        
        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void AddTriangle(DelaunayTriangle t)
        {
            trianglesPrivate.Add(t);
        }
        
        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        public void AddTriangles(IEnumerable<DelaunayTriangle> list)
        {
            trianglesPrivate.AddRange(list);
        }
        
        /// <summary>
        ///     Clears the triangles
        /// </summary>
        public void ClearTriangles()
        {
            if (trianglesPrivate != null)
            {
                trianglesPrivate.Clear();
            }
        }
        
        /// <summary>Creates constraints and populates the context with points</summary>
        /// <param name="tcx">The context</param>
        public void PrepareTriangulation(TriangulationContext tcx)
        {
            if (trianglesPrivate == null)
            {
                trianglesPrivate = new List<DelaunayTriangle>(pointsPrivate.Count);
            }
            else
            {
                trianglesPrivate.Clear();
            }
            
            // Outer constraints
            for (int i = 0; i < pointsPrivate.Count - 1; i++)
            {
                tcx.NewConstraint(pointsPrivate[i], pointsPrivate[i + 1]);
            }
            
            tcx.NewConstraint(pointsPrivate[0], pointsPrivate[pointsPrivate.Count - 1]);
            tcx.Points.AddRange(pointsPrivate);
            
            // Hole constraints
            if (holesPrivate != null)
            {
                foreach (Polygon p in holesPrivate)
                {
                    for (int i = 0; i < p.pointsPrivate.Count - 1; i++)
                    {
                        tcx.NewConstraint(p.pointsPrivate[i], p.pointsPrivate[i + 1]);
                    }
                    
                    tcx.NewConstraint(p.pointsPrivate[0], p.pointsPrivate[p.pointsPrivate.Count - 1]);
                    tcx.Points.AddRange(p.pointsPrivate);
                }
            }
            
            if (steinerPointsPrivate != null)
            {
                tcx.Points.AddRange(steinerPointsPrivate);
            }
        }
        
        /// <summary>
        ///     Adds the steiner point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        public void AddSteinerPoint(TriangulationPoint point)
        {
            steinerPointsPrivate ??= new List<TriangulationPoint>();
            
            steinerPointsPrivate.Add(point);
        }
        
        /// <summary>
        ///     Adds the steiner points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        public void AddSteinerPoints(List<TriangulationPoint> points)
        {
            steinerPointsPrivate ??= new List<TriangulationPoint>();
            
            steinerPointsPrivate.AddRange(points);
        }
        
        /// <summary>
        ///     Clears the steiner points
        /// </summary>
        public void ClearSteinerPoints()
        {
            if (steinerPointsPrivate != null)
            {
                steinerPointsPrivate.Clear();
            }
        }
        
        /// <summary>Add a hole to the polygon.</summary>
        /// <param name="poly">A subtraction polygon fully contained inside this polygon.</param>
        public void AddHole(Polygon poly)
        {
            holesPrivate ??= new List<Polygon>();
            holesPrivate.Add(poly);
        }
        
        /// <summary>Inserts newPoint after point.</summary>
        /// <param name="point">The point to insert after in the polygon</param>
        /// <param name="newPoint">The point to insert into the polygon</param>
        public void InsertPointAfter(PolygonPoint point, PolygonPoint newPoint)
        {
            // Validate that 
            int index = pointsPrivate.IndexOf(point);
            if (index == -1)
            {
                throw new ArgumentException(
                    "Tried to insert a point into a Polygon after a point not belonging to the Polygon", nameof(point));
            }
            
            newPoint.Next = point.Next;
            newPoint.Previous = point;
            point.Next.Previous = newPoint;
            point.Next = newPoint;
            pointsPrivate.Insert(index + 1, newPoint);
        }
        
        /// <summary>Inserts list (after last point in polygon?)</summary>
        /// <param name="list"></param>
        public void AddPoints(IEnumerable<PolygonPoint> list)
        {
            foreach (PolygonPoint p in list)
            {
                p.Previous = lastPrivate;
                if (lastPrivate != null)
                {
                    p.Next = lastPrivate.Next;
                    lastPrivate.Next = p;
                }
                
                lastPrivate = p;
                pointsPrivate.Add(p);
            }
            
            PolygonPoint first = (PolygonPoint) pointsPrivate[0];
            lastPrivate.Next = first;
            first.Previous = lastPrivate;
        }
        
        /// <summary>Adds a point after the last in the polygon.</summary>
        /// <param name="p">The point to add</param>
        public void AddPoint(PolygonPoint p)
        {
            p.Previous = lastPrivate;
            p.Next = lastPrivate.Next;
            lastPrivate.Next = p;
            pointsPrivate.Add(p);
        }
        
        /// <summary>Removes a point from the polygon.</summary>
        /// <param name="p"></param>
        public void RemovePoint(PolygonPoint p)
        {
            PolygonPoint next = p.Next;
            PolygonPoint prev = p.Previous;
            prev.Next = next;
            next.Previous = prev;
            pointsPrivate.Remove(p);
        }
    }
}