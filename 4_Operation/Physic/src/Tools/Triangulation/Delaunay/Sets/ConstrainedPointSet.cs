// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ConstrainedPointSet.cs
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

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Sets
{
    /*
     * Extends the PointSet by adding some Constraints on how it will be triangulated<br>
     * A constraint defines an edge between two points in the set, these edges can not
     * be crossed. They will be enforced triangle edges after a triangulation.
     * <p>
     * 
     * 
     * @author Thomas Åhlén, thahlen@gmail.com
     */

    /// <summary>
    ///     The constrained point set class
    /// </summary>
    /// <seealso cref="PointSet" />
    internal class ConstrainedPointSet : PointSet
    {
        /// <summary>
        ///     The constrained point list
        /// </summary>
        private readonly List<TriangulationPoint> constrainedPointList;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ConstrainedPointSet" /> class
        /// </summary>
        /// <param name="points">The points</param>
        /// <param name="index">The index</param>
        public ConstrainedPointSet(List<TriangulationPoint> points, int[] index)
            : base(points) =>
            EdgeIndex = index;

        /**
         * @param points - A list of all points in PointSet
         * @param constraints - Pairs of two points defining a constraint, all points
         * <b>must</b>
         * be part of given PointSet!
         */
        public ConstrainedPointSet(List<TriangulationPoint> points, IEnumerable<TriangulationPoint> constraints)
            : base(points)
        {
            constrainedPointList = new List<TriangulationPoint>();
            constrainedPointList.AddRange(constraints);
        }

        /// <summary>
        ///     Gets or sets the value of the edge index
        /// </summary>
        public int[] EdgeIndex { get; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        public override TriangulationMode TriangulationMode => TriangulationMode.Constrained;

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        public override void PrepareTriangulation(TriangulationContext tcx)
        {
            base.PrepareTriangulation(tcx);
            if (constrainedPointList != null)
            {
                TriangulationPoint p1, p2;
                using (List<TriangulationPoint>.Enumerator iterator = constrainedPointList.GetEnumerator())
                {
                    while (iterator.MoveNext())
                    {
                        p1 = iterator.Current;
                        iterator.MoveNext();
                        p2 = iterator.Current;
                        tcx.NewConstraint(p1, p2);
                    }
                }
            }
            else
            {
                for (int i = 0; i < EdgeIndex.Length; i += 2)
                {
                    // XXX: must change!!
                    tcx.NewConstraint(Points[EdgeIndex[i]], Points[EdgeIndex[i + 1]]);
                }
            }
        }
    }
}