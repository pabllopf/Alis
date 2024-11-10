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
using System.Diagnostics;
using Alis.Core.Physic.Common.ConvexHull;

namespace Alis.Core.Physic.Common.Decomposition
{
    /// <summary>
    ///     The triangulate class
    /// </summary>
    public static class Triangulate
    {
        /// <param name="skipSanityChecks">
        ///     Set this to true to skip sanity checks in the engine. This will speed up the
        ///     tools by removing the overhead of the checks, but you will need to handle checks
        ///     yourself where it is needed.
        /// </param>
        public static List<Vertices> ConvexPartition(Vertices vertices, TriangulationAlgorithm algorithm, bool discardAndFixInvalid = true, float tolerance = 0.001f, bool skipSanityChecks = false)
        {
            if (vertices.Count <= 3)
                return new List<Vertices> {vertices};

            List<Vertices> results;

            switch (algorithm)
            {
                case TriangulationAlgorithm.Earclip:
                    if (skipSanityChecks)
                        Debug.Assert(!vertices.IsCounterClockWise(), "The Earclip algorithm expects the polygon to be clockwise.");
                    else if (vertices.IsCounterClockWise())
                    {
                        Vertices temp = new Vertices(vertices);
                        temp.Reverse();
                        vertices = temp;
                    }

                    results = EarclipDecomposer.ConvexPartition(vertices, tolerance);
                    break;
                case TriangulationAlgorithm.Bayazit:
                    if (skipSanityChecks)
                        Debug.Assert(vertices.IsCounterClockWise(), "The polygon is not counter clockwise. This is needed for Bayazit to work correctly.");
                    else if (!vertices.IsCounterClockWise())
                    {
                        Vertices temp = new Vertices(vertices);
                        temp.Reverse();
                        vertices = temp;
                    }

                    results = BayazitDecomposer.ConvexPartition(vertices);
                    break;
                case TriangulationAlgorithm.Flipcode:
                    if (skipSanityChecks)
                        Debug.Assert(vertices.IsCounterClockWise(), "The polygon is not counter clockwise. This is needed for Bayazit to work correctly.");
                    else if (!vertices.IsCounterClockWise())
                    {
                        Vertices temp = new Vertices(vertices);
                        temp.Reverse();
                        vertices = temp;
                    }

                    results = FlipcodeDecomposer.ConvexPartition(vertices);
                    break;
                case TriangulationAlgorithm.Seidel:
                    results = SeidelDecomposer.ConvexPartition(vertices, tolerance);
                    break;
                case TriangulationAlgorithm.SeidelTrapezoids:
                    results = SeidelDecomposer.ConvexPartitionTrapezoid(vertices, tolerance);
                    break;
                case TriangulationAlgorithm.Delauny:
                    results = CDTDecomposer.ConvexPartition(vertices);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("algorithm");
            }

            if (discardAndFixInvalid)
            {
                for (int i = results.Count - 1; i >= 0; i--)
                {
                    Vertices polygon = results[i];

                    if (!ValidatePolygon(polygon))
                        results.RemoveAt(i);
                }
            }

            return results;
        }

        /// <summary>
        ///     Describes whether validate polygon
        /// </summary>
        /// <param name="polygon">The polygon</param>
        /// <returns>The bool</returns>
        private static bool ValidatePolygon(Vertices polygon)
        {
            PolygonError errorCode = polygon.CheckPolygon();

            if (errorCode == PolygonError.InvalidAmountOfVertices || errorCode == PolygonError.AreaTooSmall || errorCode == PolygonError.SideTooSmall || errorCode == PolygonError.NotSimple)
                return false;

            if (errorCode == PolygonError.NotCounterClockWise) //NotCounterCloseWise is the last check in CheckPolygon(), thus we don't need to call ValidatePolygon again.
                polygon.Reverse();

            if (errorCode == PolygonError.NotConvex)
            {
                polygon = GiftWrap.GetConvexHull(polygon);
                return ValidatePolygon(polygon);
            }

            return true;
        }
    }
}