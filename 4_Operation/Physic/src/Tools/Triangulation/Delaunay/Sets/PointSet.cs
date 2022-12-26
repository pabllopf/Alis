// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointSet.cs
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
using Alis.Core.Physic.Tools.Triangulation.Delaunay.Delaunay;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Sets
{
    /// <summary>
    ///     The point set class
    /// </summary>
    /// <seealso cref="ITriangulatable" />
    internal class PointSet : ITriangulatable
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="PointSet" /> class
        /// </summary>
        /// <param name="points">The points</param>
        public PointSet(List<TriangulationPoint> points) => Points = new List<TriangulationPoint>(points);

        /// <summary>
        ///     Gets or sets the value of the points
        /// </summary>
        public IList<TriangulationPoint> Points { get; }

        /// <summary>
        ///     Gets or sets the value of the triangles
        /// </summary>
        public IList<DelaunayTriangle> Triangles { get; private set; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public virtual TriangulationMode TriangulationMode => TriangulationMode.Unconstrained;

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
            foreach (DelaunayTriangle tri in list)
            {
                Triangles.Add(tri);
            }
        }

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        public void ClearTriangles()
        {
            Triangles.Clear();
        }

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        public virtual void PrepareTriangulation(TriangulationContext tcx)
        {
            if (Triangles == null)
            {
                Triangles = new List<DelaunayTriangle>(Points.Count);
            }
            else
            {
                Triangles.Clear();
            }

            tcx.Points.AddRange(Points);
        }
    }
}