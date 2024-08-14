// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:TriangulationAlgorithm.cs
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

namespace Alis.Extension.Math.PathGenerator.Triangulation
{
    /// <summary>
    ///     The triangulation algorithm enum
    /// </summary>
    public enum TriangulationAlgorithm
    {
        /// <summary>
        ///     Convex decomposition algorithm using ear clipping
        ///     Properties:
        ///     - Only works on simple polygons.
        ///     - Does not support holes.
        ///     - Running time is O(n^2), n = number of vertices.
        /// </summary>
        EarClip,
        
        /// <summary>
        ///     Properties:
        ///     - Tries to decompose using polygons instead of triangles.
        ///     - Tends to produce optimal results with low processing time.
        ///     - Running time is O(nr), n = number of vertices, r = reflex vertices.
        ///     - Does not support holes.
        /// </summary>
        BayaZit,
        
        /// <summary>
        ///     Convex decomposition algorithm created by unknown
        ///     Properties:
        ///     - No support for holes
        ///     - Very fast
        ///     - Only works on simple polygons
        ///     - Only works on counter clockwise polygons
        /// </summary>
        FlipCode,
        
        /// <summary>
        ///     Convex decomposition algorithm created by Raimund Seidel
        ///     Properties:
        ///     - Decompose the polygon into trapezoids, then triangulate.
        ///     - To use the trapezoid data, use ConvexPartitionTrapezoid()
        ///     - Generate a lot of garbage due of the Poly2Tri library.
        ///     - Running time is O(n log n), n = number of vertices.
        ///     - Running time is almost linear for most simple polygons.
        ///     - Does not care about winding order.
        /// </summary>
        Seidel,
        
        /// <summary>
        ///     The seidel trapezoids triangulation algorithm
        /// </summary>
        SeidelTrapezoids,
        
        /// <summary>
        ///     2D constrained Delaunay triangulation algorithm.
        ///     Based on the paper "Sweep-line algorithm for constrained Delaunay triangulation" by V.
        ///     Properties:
        ///     - Creates triangles with a large interior angle.
        ///     - Supports holes
        ///     - Running time is O(n^2), n = number of vertices.
        ///     - Does not care about winding order.
        /// </summary>
        DelaUny
    }
}