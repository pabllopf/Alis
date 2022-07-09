// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.Distance.cs
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

#define DEBUG

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    // GJK using Voronoi regions (Christer Ericson) and Barycentric coordinates.

    /// <summary>
    ///     The collision class
    /// </summary>
    public partial class Collision
    {
        /// <summary>
        ///     Compute the closest points between two shapes. Supports any combination of:
        ///     CircleShape, PolygonShape, EdgeShape. The simplex cache is input/output.
        ///     On the first call set SimplexCache.Count to zero.
        /// </summary>
        public static unsafe void Distance(out DistanceOutput output, ref SimplexCache cache, ref DistanceInput input,
            Shape shapeA, Shape shapeB)
        {
            output = new DistanceOutput();

            XForm transformA = input.TransformA;
            XForm transformB = input.TransformB;

            // Initialize the simplex.
            Simplex simplex = new Simplex();
            fixed (SimplexCache* sPtr = &cache)
            {
                simplex.ReadCache(sPtr, shapeA, transformA, shapeB, transformB);
            }

            // Get simplex vertices as an array.
            SimplexVertex* vertices = &simplex._v1;

            // These store the vertices of the last simplex so that we
            // can check for duplicates and prevent cycling.
            int* lastA = stackalloc int[4], lastB = stackalloc int[4];
            int lastCount;

            // Main iteration loop.
            int iter = 0;
            const int k_maxIterationCount = 20;
            while (iter < k_maxIterationCount)
            {
                // Copy simplex so we can identify duplicates.
                lastCount = simplex._count;
                int i;
                for (i = 0; i < lastCount; ++i)
                {
                    lastA[i] = vertices[i].IndexA;
                    lastB[i] = vertices[i].IndexB;
                }

                switch (simplex._count)
                {
                    case 1:
                        break;

                    case 2:
                        simplex.Solve2();
                        break;

                    case 3:
                        simplex.Solve3();
                        break;

                    default:
#if DEBUG
                        Box2DXDebug.Assert(false);
#endif
                        break;
                }

                // If we have 3 points, then the origin is in the corresponding triangle.
                if (simplex._count == 3)
                {
                    break;
                }

                // Compute closest point.
                Vec2 p = simplex.GetClosestPoint();
                float distanceSqr = p.LengthSquared();

                // Ensure the search direction is numerically fit.
                if (distanceSqr < Settings.FltEpsilonSquared)
                {
                    // The origin is probably contained by a line segment
                    // or triangle. Thus the shapes are overlapped.

                    // We can't return zero here even though there may be overlap.
                    // In case the simplex is a point, segment, or triangle it is difficult
                    // to determine if the origin is contained in the CSO or very close to it.
                    break;
                }

                // Compute a tentative new simplex vertex using support points.
                SimplexVertex* vertex = vertices + simplex._count;
                vertex->IndexA = shapeA.GetSupport(Math.MulT(transformA.R, p));
                vertex->Wa = Math.Mul(transformA, shapeA.GetVertex(vertex->IndexA));
                //Vec2 wBLocal;
                vertex->IndexB = shapeB.GetSupport(Math.MulT(transformB.R, -p));
                vertex->Wb = Math.Mul(transformB, shapeB.GetVertex(vertex->IndexB));
                vertex->W = vertex->Wb - vertex->Wa;

                // Iteration count is equated to the number of support point calls.
                ++iter;

                // Check for convergence.
                float lowerBound = Vec2.Dot(p, vertex->W);
                float upperBound = distanceSqr;
                const float k_relativeTolSqr = 0.01f * 0.01f; // 1:100
                if (upperBound - lowerBound <= k_relativeTolSqr * upperBound)
                {
                    // Converged!
                    break;
                }

                // Check for duplicate support points.
                bool duplicate = false;
                for (i = 0; i < lastCount; ++i)
                {
                    if (vertex->IndexA == lastA[i] && vertex->IndexB == lastB[i])
                    {
                        duplicate = true;
                        break;
                    }
                }

                // If we found a duplicate support point we must exit to avoid cycling.
                if (duplicate)
                {
                    break;
                }

                // New vertex is ok and needed.
                ++simplex._count;
            }


            fixed (DistanceOutput* doPtr = &output)
            {
                // Prepare output.
                simplex.GetWitnessPoints(&doPtr->PointA, &doPtr->PointB);
                doPtr->Distance = Vec2.Distance(doPtr->PointA, doPtr->PointB);
                doPtr->Iterations = iter;
            }

            fixed (SimplexCache* sPtr = &cache)
            {
                // Cache the simplex.
                simplex.WriteCache(sPtr);
            }

            // Apply radii if requested.
            if (input.UseRadii)
            {
                float rA = shapeA.Radius;
                float rB = shapeB.Radius;

                if (output.Distance > rA + rB && output.Distance > Settings.FltEpsilon)
                {
                    // Shapes are still no overlapped.
                    // Move the witness points to the outer surface.
                    output.Distance -= rA + rB;
                    Vec2 normal = output.PointB - output.PointA;
                    normal.Normalize();
                    output.PointA += rA * normal;
                    output.PointB -= rB * normal;
                }
                else
                {
                    // Shapes are overlapped when radii are considered.
                    // Move the witness points to the middle.
                    Vec2 p = 0.5f * (output.PointA + output.PointB);
                    output.PointA = p;
                    output.PointB = p;
                    output.Distance = 0.0f;
                }
            }
        }
    }
}