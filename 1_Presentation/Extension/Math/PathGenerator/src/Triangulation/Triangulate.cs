// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Triangulate.cs
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
using Alis.Core.Physic.Shared;
using Alis.Extension.Math.PathGenerator.ConvexHull;
using Alis.Extension.Math.PathGenerator.Triangulation.BayaZit;
using Alis.Extension.Math.PathGenerator.Triangulation.Delaunay;
using Alis.Extension.Math.PathGenerator.Triangulation.EarClip;
using Alis.Extension.Math.PathGenerator.Triangulation.FlipCode;
using Alis.Extension.Math.PathGenerator.Triangulation.Seidel;

namespace Alis.Extension.Math.PathGenerator.Triangulation
{
    /// <summary>
    ///     The triangulate class
    /// </summary>
    public static class Triangulate
    {
        /// <summary>
        ///     Convexes the partition using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="algorithm">The algorithm</param>
        /// <param name="discardAndFixInvalid">The discard and fix invalid</param>
        /// <param name="tolerance">The tolerance</param>
        /// <returns>The results</returns>
        public static List<Vertices> ConvexPartition(Vertices vertices, TriangulationAlgorithm algorithm,
            bool discardAndFixInvalid = true, float tolerance = 0.001f)
        {
            if (vertices.Count <= 3)
            {
                return new List<Vertices> {vertices};
            }
            
            if (!ValidateCounterClockwise(vertices, algorithm))
            {
                vertices.Reverse();
            }
            
            List<Vertices> results = GetConvexPartition(vertices, algorithm, tolerance);
            
            if (discardAndFixInvalid)
            {
                results.RemoveAll(polygon => !ValidatePolygon(polygon));
            }
            
            return results;
        }
        
        /// <summary>
        ///     Describes whether validate counter clockwise
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="algorithm">The algorithm</param>
        /// <returns>The bool</returns>
        private static bool ValidateCounterClockwise(Vertices vertices, TriangulationAlgorithm algorithm)
        {
            return algorithm switch
            {
                TriangulationAlgorithm.EarClip => !vertices.IsCounterClockWise(),
                TriangulationAlgorithm.BayaZit => vertices.IsCounterClockWise(),
                TriangulationAlgorithm.FlipCode => vertices.IsCounterClockWise(),
                _ => true
            };
        }
        
        /// <summary>
        ///     Gets the convex partition using the specified vertices
        /// </summary>
        /// <param name="vertices">The vertices</param>
        /// <param name="algorithm">The algorithm</param>
        /// <param name="tolerance">The tolerance</param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <returns>A list of vertices</returns>
        private static List<Vertices> GetConvexPartition(Vertices vertices, TriangulationAlgorithm algorithm, float tolerance)
        {
            return algorithm switch
            {
                TriangulationAlgorithm.EarClip => EarClipDecomposer.ConvexPartition(vertices, tolerance),
                TriangulationAlgorithm.BayaZit => BayaZitDecomposer.ConvexPartition(vertices),
                TriangulationAlgorithm.FlipCode => FlipCodeDecomposer.ConvexPartition(vertices),
                TriangulationAlgorithm.Seidel => SeidelDecomposer.ConvexPartition(vertices, tolerance),
                TriangulationAlgorithm.SeidelTrapezoids => SeidelDecomposer.ConvexPartitionTrapezoid(vertices, tolerance),
                TriangulationAlgorithm.DelaUny => CdtDecomposer.ConvexPartition(vertices),
                _ => throw new ArgumentOutOfRangeException(nameof(algorithm))
            };
        }
        
        /// <summary>
        ///     Describes whether validate polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <returns>The bool</returns>
        private static bool ValidatePolygon(Vertices polygon)
        {
            PolygonError errorCode = polygon.CheckPolygon();
            
            if (errorCode == PolygonError.InvalidAmountOfVertices ||
                errorCode == PolygonError.AreaTooSmall ||
                errorCode == PolygonError.SideTooSmall ||
                errorCode == PolygonError.NotSimple)
            {
                return false;
            }
            
            if (errorCode == PolygonError.NotCounterClockWise)
            {
                polygon.Reverse();
            }
            
            if (errorCode == PolygonError.NotConvex)
            {
                polygon = GiftWrap.GetConvexHull(polygon);
                return ValidatePolygon(polygon);
            }
            
            return true;
        }
    }
}