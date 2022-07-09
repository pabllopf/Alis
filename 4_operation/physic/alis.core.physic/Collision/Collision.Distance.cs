/*
  Box2DX Copyright (c) 2009 Ihar Kalasouski http://code.google.com/p/box2dx
  Box2D original C++ version Copyright (c) 2006-2009 Erin Catto http://www.gphysics.com

  This software is provided 'as-is', without any express or implied
  warranty.  In no event will the authors be held liable for any damages
  arising from the use of this software.

  Permission is granted to anyone to use this software for any purpose,
  including commercial applications, and to alter it and redistribute it
  freely, subject to the following restrictions:

  1. The origin of this software must not be misrepresented; you must not
     claim that you wrote the original software. If you use this software
     in a product, an acknowledgment in the product documentation would be
     appreciated but is not required.
  2. Altered source versions must be plainly marked as such, and must not be
     misrepresented as being the original software.
  3. This notice may not be removed or altered from any source distribution.
*/

#define DEBUG

using Alis.Core.Physic.Collision.Shapes;
using Alis.Core.Physic.Common;

namespace Alis.Core.Physic.Collision
{
    // GJK using Voronoi regions (Christer Ericson) and Barycentric coordinates.

    /// <summary>
	/// The collision class
	/// </summary>
	public partial class Collision
	{
		/// <summary>
		/// Compute the closest points between two shapes. Supports any combination of:
		/// CircleShape, PolygonShape, EdgeShape. The simplex cache is input/output.
		/// On the first call set SimplexCache.Count to zero.
		/// </summary>		
		public unsafe static void Distance(out DistanceOutput output, ref SimplexCache cache, ref DistanceInput input, Shape shapeA, Shape shapeB)
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
					lastA[i] = vertices[i].indexA;
					lastB[i] = vertices[i].indexB;
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
				if (distanceSqr < Settings.FLT_EPSILON_SQUARED)
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
				vertex->indexA = shapeA.GetSupport(Common.Math.MulT(transformA.R, p));
				vertex->wA = Common.Math.Mul(transformA, shapeA.GetVertex(vertex->indexA));
				//Vec2 wBLocal;
				vertex->indexB = shapeB.GetSupport(Common.Math.MulT(transformB.R, -p));
				vertex->wB = Common.Math.Mul(transformB, shapeB.GetVertex(vertex->indexB));
				vertex->w = vertex->wB - vertex->wA;

				// Iteration count is equated to the number of support point calls.
				++iter;

				// Check for convergence.
				float lowerBound = Vec2.Dot(p, vertex->w);
				float upperBound = distanceSqr;
				const float k_relativeTolSqr = 0.01f * 0.01f;	// 1:100
				if (upperBound - lowerBound <= k_relativeTolSqr * upperBound)
				{
					// Converged!
					break;
				}

				// Check for duplicate support points.
				bool duplicate = false;
				for (i = 0; i < lastCount; ++i)
				{
					if (vertex->indexA == lastA[i] && vertex->indexB == lastB[i])
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

				if (output.Distance > rA + rB && output.Distance > Settings.FLT_EPSILON)
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