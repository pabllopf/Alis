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
        // List of edges this point constitutes an upper ending point (CDT)

        /// <summary>
        ///     The
        /// </summary>
        public double X, Y;

        /// <summary>
        ///     Initializes a new instance of the <see cref="TriangulationPoint" /> class
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        public TriangulationPoint(double x, double y)
        {
            X = x;
            Y = y;
        }

        /// <summary>
        ///     Gets or sets the value of the edges
        /// </summary>
        public List<DtSweepConstraint> Edges { get; private set; }

        /// <summary>
        ///     Gets or sets the value of the xf
        /// </summary>
        public float Xf
        {
            get => (float) X;
            set => X = value;
        }

        /// <summary>
        ///     Gets or sets the value of the yf
        /// </summary>
        public float Yf
        {
            get => (float) Y;
            set => Y = value;
        }

        /// <summary>
        ///     Gets the value of the has edges
        /// </summary>
        public bool HasEdges => Edges != null;

        /// <summary>
        ///     Returns the string
        /// </summary>
        /// <returns>The string</returns>
        public override string ToString()
        {
            return "[" + X + "," + Y + "]";
        }

        /// <summary>
        ///     Adds the edge using the specified e
        /// </summary>
        /// <param name="e">The </param>
        public void AddEdge(DtSweepConstraint e)
        {
            if (Edges == null)
            {
                Edges = new List<DtSweepConstraint>();
            }

            Edges.Add(e);
        }
    }
}