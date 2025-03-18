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
using Alis.Core.Physic.Common.Decomposition.CDT.Delaunay;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Polygon
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
        protected readonly List<TriangulationPoint> Points = new List<TriangulationPoint>();

        /// <summary>
        ///     The holes
        /// </summary>
        protected List<Polygon> Holes;

        /// <summary>
        ///     The last
        /// </summary>
        protected PolygonPoint Last;

        /// <summary>
        ///     The steiner points
        /// </summary>
        protected List<TriangulationPoint> SteinerPoints;

        /// <summary>
        ///     The triangles
        /// </summary>
        protected List<DelaunayTriangle> Triangles;

        /// <summary>
        ///     Create a polygon from a list of at least 3 points with no duplicates.
        /// </summary>
        /// <param name="points">A list of unique points</param>
        public Polygon(IList<PolygonPoint> points)
        {
            if (points.Count < 3)
            {
                throw new ArgumentException("List has fewer than 3 points", "points");
            }

            // Lets do one sanity check that first and last point hasn't got same position
            // Its something that often happen when importing polygon data from other formats
            if (points[0].Equals(points[points.Count - 1]))
            {
                points.RemoveAt(points.Count - 1);
            }

            Points.AddRange(points);
        }

        /// <summary>
        ///     Create a polygon from a list of at least 3 points with no duplicates.
        /// </summary>
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
        public IList<Polygon> GetHoles => Holes;


        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public TriangulationMode TriangulationMode => TriangulationMode.Polygon;

        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        public IList<TriangulationPoint> GetPoints => Points;

        /// <summary>
        ///     Gets the value of the triangles
        /// </summary>
        public IList<DelaunayTriangle> GetTriangles => Triangles;

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        public void AddTriangle(DelaunayTriangle t)
        {
            Triangles.Add(t);
        }

        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        public void AddTriangles(IEnumerable<DelaunayTriangle> list)
        {
            Triangles.AddRange(list);
        }

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        public void ClearTriangles()
        {
            if (Triangles != null)
            {
                Triangles.Clear();
            }
        }

        /// <summary>
        ///     Creates constraints and populates the context with points
        /// </summary>
        /// <param name="tcx">The context</param>
        public void PrepareTriangulation(TriangulationContext tcx)
        {
            if (Triangles == null)
            {
                Triangles = new List<DelaunayTriangle>(Points.Count);
            }
            else
            {
                Triangles.Clear();
            }

            // Outer constraints
            for (int i = 0; i < Points.Count - 1; i++)
            {
                tcx.NewConstraint(Points[i], Points[i + 1]);
            }

            tcx.NewConstraint(Points[0], Points[Points.Count - 1]);
            tcx.Points.AddRange(Points);

            // Hole constraints
            if (Holes != null)
            {
                foreach (Polygon p in Holes)
                {
                    for (int i = 0; i < p.Points.Count - 1; i++)
                    {
                        tcx.NewConstraint(p.Points[i], p.Points[i + 1]);
                    }

                    tcx.NewConstraint(p.Points[0], p.Points[p.Points.Count - 1]);
                    tcx.Points.AddRange(p.Points);
                }
            }

            if (SteinerPoints != null)
            {
                tcx.Points.AddRange(SteinerPoints);
            }
        }

        /// <summary>
        ///     Adds the steiner point using the specified point
        /// </summary>
        /// <param name="point">The point</param>
        public void AddSteinerPoint(TriangulationPoint point)
        {
            if (SteinerPoints == null)
            {
                SteinerPoints = new List<TriangulationPoint>();
            }

            SteinerPoints.Add(point);
        }

        /// <summary>
        ///     Adds the steiner points using the specified points
        /// </summary>
        /// <param name="points">The points</param>
        public void AddSteinerPoints(List<TriangulationPoint> points)
        {
            if (SteinerPoints == null)
            {
                SteinerPoints = new List<TriangulationPoint>();
            }

            SteinerPoints.AddRange(points);
        }

        /// <summary>
        ///     Clears the steiner points
        /// </summary>
        public void ClearSteinerPoints()
        {
            if (SteinerPoints != null)
            {
                SteinerPoints.Clear();
            }
        }

        /// <summary>
        ///     Add a hole to the polygon.
        /// </summary>
        /// <param name="poly">A subtraction polygon fully contained inside this polygon.</param>
        public void AddHole(Polygon poly)
        {
            if (Holes == null)
            {
                Holes = new List<Polygon>();
            }

            Holes.Add(poly);
            // XXX: tests could be made here to be sure it is fully inside
            //        addSubtraction( poly.getPoints() );
        }

        /// <summary>
        ///     Inserts newPoint after point.
        /// </summary>
        /// <param name="point">The point to insert after in the polygon</param>
        /// <param name="newPoint">The point to insert into the polygon</param>
        public void InsertPointAfter(PolygonPoint point, PolygonPoint newPoint)
        {
            // Validate that 
            int index = Points.IndexOf(point);
            if (index == -1)
            {
                throw new ArgumentException(
                    "Tried to insert a point into a Polygon after a point not belonging to the Polygon", "point");
            }

            newPoint.Next = point.Next;
            newPoint.Previous = point;
            point.Next.Previous = newPoint;
            point.Next = newPoint;
            Points.Insert(index + 1, newPoint);
        }

        /// <summary>
        ///     Inserts list (after last point in polygon?)
        /// </summary>
        /// <param name="list"></param>
        public void AddPoints(IEnumerable<PolygonPoint> list)
        {
            PolygonPoint first;
            foreach (PolygonPoint p in list)
            {
                p.Previous = Last;
                if (Last != null)
                {
                    p.Next = Last.Next;
                    Last.Next = p;
                }

                Last = p;
                Points.Add(p);
            }

            first = (PolygonPoint) Points[0];
            Last.Next = first;
            first.Previous = Last;
        }

        /// <summary>
        ///     Adds a point after the last in the polygon.
        /// </summary>
        /// <param name="p">The point to add</param>
        public void AddPoint(PolygonPoint p)
        {
            p.Previous = Last;
            p.Next = Last.Next;
            Last.Next = p;
            Points.Add(p);
        }

        /// <summary>
        ///     Removes a point from the polygon.
        /// </summary>
        /// <param name="p"></param>
        public void RemovePoint(PolygonPoint p)
        {
            PolygonPoint next, prev;

            next = p.Next;
            prev = p.Previous;
            prev.Next = next;
            next.Previous = prev;
            Points.Remove(p);
        }
    }
}