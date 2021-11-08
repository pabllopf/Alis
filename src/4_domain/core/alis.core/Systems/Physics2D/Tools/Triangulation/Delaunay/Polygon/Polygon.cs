// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Polygon.cs
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

// Changes from the Java version
//   Polygon constructors sprused up, checks for 3+ polys
//   Naming of everything
//   getTriangulationMode() -> TriangulationMode { get; }
//   Exceptions replaced
// Future possibilities
//   We have a lot of Add/Clear methods -- we may prefer to just expose the container
//   Some self-explanitory methods may deserve commenting anyways

using System;
using System.Collections.Generic;
using System.Linq;
using Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay.Delaunay;

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay.Polygon
{
    /// <summary>
    ///     The polygon class
    /// </summary>
    /// <seealso cref="Triangulatable" />
    internal class Polygon : Triangulatable
    {
        /// <summary>
        ///     The holes
        /// </summary>
        protected List<Polygon> _holes;

        /// <summary>
        ///     The last
        /// </summary>
        protected PolygonPoint _last;

        /// <summary>
        ///     The triangulation point
        /// </summary>
        protected List<TriangulationPoint> _points = new List<TriangulationPoint>();

        /// <summary>
        ///     The steiner points
        /// </summary>
        protected List<TriangulationPoint> _steinerPoints;

        /// <summary>
        ///     The triangles
        /// </summary>
        protected List<DelaunayTriangle> _triangles;

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

            _points.AddRange(points);
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
        public IList<Polygon> Holes => _holes;

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode => TriangulationMode.Polygon;

        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        public IList<TriangulationPoint> Points => _points;

        /// <summary>
        ///     Gets the value of the triangles
        /// </summary>
        public IList<DelaunayTriangle> Triangles => _triangles;

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void AddTriangle(DelaunayTriangle t)
        {
            _triangles.Add(t);
        }

        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        public void AddTriangles(IEnumerable<DelaunayTriangle> list)
        {
            _triangles.AddRange(list);
        }

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        public void ClearTriangles()
        {
            if (_triangles != null)
            {
                _triangles.Clear();
            }
        }

        /// <summary>Creates constraints and populates the context with points</summary>
        /// <param name="tcx">The context</param>
        public void PrepareTriangulation(TriangulationContext tcx)
        {
            if (_triangles == null)
            {
                _triangles = new List<DelaunayTriangle>(_points.Count);
            }
            else
            {
                _triangles.Clear();
            }

            // Outer constraints
            for (int i = 0; i < _points.Count - 1; i++)
            {
                tcx.NewConstraint(_points[i], _points[i + 1]);
            }

            tcx.NewConstraint(_points[0], _points[_points.Count - 1]);
            tcx.Points.AddRange(_points);

            // Hole constraints
            if (_holes != null)
            {
                foreach (Polygon p in _holes)
                {
                    for (int i = 0; i < p._points.Count - 1; i++)
                    {
                        tcx.NewConstraint(p._points[i], p._points[i + 1]);
                    }

                    tcx.NewConstraint(p._points[0], p._points[p._points.Count - 1]);
                    tcx.Points.AddRange(p._points);
                }
            }

            if (_steinerPoints != null)
            {
                tcx.Points.AddRange(_steinerPoints);
            }
        }

        /// <summary>
        ///     Adds the steiner point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        public void AddSteinerPoint(TriangulationPoint point)
        {
            if (_steinerPoints == null)
            {
                _steinerPoints = new List<TriangulationPoint>();
            }

            _steinerPoints.Add(point);
        }

        /// <summary>
        ///     Adds the steiner points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        public void AddSteinerPoints(List<TriangulationPoint> points)
        {
            if (_steinerPoints == null)
            {
                _steinerPoints = new List<TriangulationPoint>();
            }

            _steinerPoints.AddRange(points);
        }

        /// <summary>
        ///     Clears the steiner points
        /// </summary>
        public void ClearSteinerPoints()
        {
            if (_steinerPoints != null)
            {
                _steinerPoints.Clear();
            }
        }

        /// <summary>Add a hole to the polygon.</summary>
        /// <param name="poly">A subtraction polygon fully contained inside this polygon.</param>
        public void AddHole(Polygon poly)
        {
            if (_holes == null)
            {
                _holes = new List<Polygon>();
            }

            _holes.Add(poly);

            // XXX: tests could be made here to be sure it is fully inside
            //        addSubtraction( poly.getPoints() );
        }

        /// <summary>Inserts newPoint after point.</summary>
        /// <param name="point">The point to insert after in the polygon</param>
        /// <param name="newPoint">The point to insert into the polygon</param>
        public void InsertPointAfter(PolygonPoint point, PolygonPoint newPoint)
        {
            // Validate that 
            int index = _points.IndexOf(point);
            if (index == -1)
            {
                throw new ArgumentException(
                    "Tried to insert a point into a Polygon after a point not belonging to the Polygon", nameof(point));
            }

            newPoint.Next = point.Next;
            newPoint.Previous = point;
            point.Next.Previous = newPoint;
            point.Next = newPoint;
            _points.Insert(index + 1, newPoint);
        }

        /// <summary>Inserts list (after last point in polygon?)</summary>
        /// <param name="list"></param>
        public void AddPoints(IEnumerable<PolygonPoint> list)
        {
            foreach (PolygonPoint p in list)
            {
                p.Previous = _last;
                if (_last != null)
                {
                    p.Next = _last.Next;
                    _last.Next = p;
                }

                _last = p;
                _points.Add(p);
            }

            PolygonPoint first = (PolygonPoint) _points[0];
            _last.Next = first;
            first.Previous = _last;
        }

        /// <summary>Adds a point after the last in the polygon.</summary>
        /// <param name="p">The point to add</param>
        public void AddPoint(PolygonPoint p)
        {
            p.Previous = _last;
            p.Next = _last.Next;
            _last.Next = p;
            _points.Add(p);
        }

        /// <summary>Removes a point from the polygon.</summary>
        /// <param name="p"></param>
        public void RemovePoint(PolygonPoint p)
        {
            PolygonPoint next = p.Next;
            PolygonPoint prev = p.Previous;
            prev.Next = next;
            next.Previous = prev;
            _points.Remove(p);
        }
    }
}