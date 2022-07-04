// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   TriangulationPoint.cs
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

using System.Collections.Generic;
using Alis.Core.Physic.D2.Tools.Triangulation.Delaunay.Delaunay.Sweep;

namespace Alis.Core.Physic.D2.Tools.Triangulation.Delaunay
{
    /// <summary>
    ///     The triangulation point class
    /// </summary>
    internal class TriangulationPoint
    {
        /// <summary>
        ///     The x value
        /// </summary>
        private double x;

        /// <summary>
        ///     The y value
        /// </summary>
        private double y;

        /// <summary>
        /// The edges
        /// </summary>
        private List<DtSweepConstraint> edges;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangulationPoint" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public TriangulationPoint(double x, double y)
        {
            this.x = x;
            this.y = y;
            edges = new List<DtSweepConstraint>();
        }

        /// <summary>
        ///     Gets or sets the value of the edges
        /// </summary>
        public List<DtSweepConstraint> GetEdges() => edges;

        /// <summary>
        ///     Gets the value of the has edges
        /// </summary>
        public bool HasEdges() => edges.Count >= 0;

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString() => "[" + x + "," + y + "]";
        
        /// <summary>
        /// Adds the edge.
        /// </summary>
        /// <param name="dtSweepConstraint">The dt sweep constraint.</param>
        public void AddEdge(DtSweepConstraint dtSweepConstraint) => edges.Add(dtSweepConstraint);
    }
}