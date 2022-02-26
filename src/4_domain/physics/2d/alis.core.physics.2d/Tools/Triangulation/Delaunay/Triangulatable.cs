// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Triangulatable.cs
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
using Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay.Delaunay;

namespace Alis.Core.Systems.Physics2D.Tools.Triangulation.Delaunay
{
    /// <summary>
    ///     The triangulatable interface
    /// </summary>
    internal interface ITriangulatable
    {
        /// <summary>
        ///     Gets the value of the points
        /// </summary>
        IList<TriangulationPoint> Points { get; } // MM: Neither of these are used via interface (yet?)

        /// <summary>
        ///     Gets the value of the triangles
        /// </summary>
        IList<DelaunayTriangle> Triangles { get; }

        /// <summary>
        ///     Gets the value of the triangulation mode
        /// </summary>
        TriangulationMode TriangulationMode { get; }

        /// <summary>
        ///     Prepares the triangulation using the specified tcx
        /// </summary>
        /// <param name="tcx">The tcx</param>
        void PrepareTriangulation(TriangulationContext tcx);

        /// <summary>
        ///     Adds the triangle using the specified t
        /// </summary>
        /// <param name="t">The </param>
        void AddTriangle(DelaunayTriangle t);

        /// <summary>
        ///     Adds the triangles using the specified list
        /// </summary>
        /// <param name="list">The list</param>
        void AddTriangles(IEnumerable<DelaunayTriangle> list);

        /// <summary>
        ///     Clears the triangles
        /// </summary>
        void ClearTriangles();
    }
}