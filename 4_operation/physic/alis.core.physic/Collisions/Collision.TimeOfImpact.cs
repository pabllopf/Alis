// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   Collision.TimeOfImpact.cs
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

using Alis.Aspect.Logging;
using Alis.Aspect.Math;
using Alis.Core.Physic.Collisions.Shapes;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     The collision class
    /// </summary>
    public static partial class Collision
    {
        /// <summary>
        ///     The max toi iters
        /// </summary>
        public static int MaxToiIters;

        /// <summary>
        ///     The max toi root iters
        /// </summary>
        public static int MaxToiRootIters;

        // CCD via the secant method.
        /// <summary>
        ///     Compute the time when two shapes begin to touch or touch at a closer distance.
        ///     TOI considers the shape radii. It attempts to have the radii overlap by the tolerance.
        ///     Iterations terminate with the overlap is within 0.5 * tolerance. The tolerance should be
        ///     smaller than sum of the shape radii.
        ///     Warning the sweeps must have the same time interval.
        /// </summary>
        /// <returns>
        ///     The fraction between [0,1] in which the shapes first touch.
        ///     fraction=0 means the shapes begin touching/overlapped, and fraction=1 means the shapes don't touch.
        /// </returns>
        public static float TimeOfImpact(ToiInput input, Shape shapeA, Shape shapeB)
        {
            Sweep sweepA = input.SweepA;
            Sweep sweepB = input.SweepB;

            Box2DxDebug.Assert(sweepA.T0 == sweepB.T0);
            Box2DxDebug.Assert(1.0f - sweepA.T0 > Settings.FltEpsilon);

            float radius = shapeA.Radius + shapeB.Radius;
            float tolerance = input.Tolerance;

            float alpha = 0.0f;

            const int kMaxIterations = 1000; // TODO_ERIN b2Settings
            int iter = 0;
            float target = 0.0f;

            // Prepare input for distance query.
            SimplexCache cache = new SimplexCache();
            cache.Count = 0;
            DistanceInput distanceInput;
            distanceInput.UseRadii = false;

            for (;;)
            {
                XForm xfA, xfB;
                sweepA.GetTransform(out xfA, alpha);
                sweepB.GetTransform(out xfB, alpha);

                // Get the distance between shapes.
                distanceInput.TransformA = xfA;
                distanceInput.TransformB = xfB;
                DistanceOutput distanceOutput;
                Distance(out distanceOutput, ref cache, ref distanceInput, shapeA, shapeB);

                if (distanceOutput.Distance <= 0.0f)
                {
                    alpha = 1.0f;
                    break;
                }

                SeparationFunction fcn = new SeparationFunction();
                unsafe
                {
                    fcn.Initialize(&cache, shapeA, xfA, shapeB, xfB);
                }

                float separation = fcn.Evaluate(xfA, xfB);
                if (separation <= 0.0f)
                {
                    alpha = 1.0f;
                    break;
                }

                if (iter == 0)
                {
                    // Compute a reasonable target distance to give some breathing room
                    // for conservative advancement. We take advantage of the shape radii
                    // to create additional clearance.
                    if (separation > radius)
                    {
                        target = Math.Max(radius - tolerance, 0.75f * radius);
                    }
                    else
                    {
                        target = Math.Max(separation - tolerance, 0.02f * radius);
                    }
                }

                if (separation - target < 0.5f * tolerance)
                {
                    if (iter == 0)
                    {
                        alpha = 1.0f;
                    }

                    break;
                }

#if _FALSE
				// Dump the curve seen by the root finder
				{
					const int32 N = 100;
					float32 dx = 1.0f / N;
					float32 xs[N+1];
					float32 fs[N+1];

					float32 x = 0.0f;

					for (int32 i = 0; i <= N; ++i)
					{
						sweepA.GetTransform(&xfA, x);
						sweepB.GetTransform(&xfB, x);
						float32 f = fcn.Evaluate(xfA, xfB) - target;

						printf("%g %g\n", x, f);

						xs[i] = x;
						fs[i] = f;

						x += dx;
					}
				}
#endif

                // Compute 1D root of: f(x) - target = 0
                float newAlpha = alpha;
                {
                    float x1 = alpha, x2 = 1.0f;

                    float f1 = separation;

                    sweepA.GetTransform(out xfA, x2);
                    sweepB.GetTransform(out xfB, x2);
                    float f2 = fcn.Evaluate(xfA, xfB);

                    // If intervals don't overlap at t2, then we are done.
                    if (f2 >= target)
                    {
                        alpha = 1.0f;
                        break;
                    }

                    // Determine when intervals intersect.
                    int rootIterCount = 0;
                    for (;;)
                    {
                        // Use a mix of the secant rule and bisection.
                        float x;
                        if ((rootIterCount & 1) != 0)
                        {
                            // Secant rule to improve convergence.
                            x = x1 + (target - f1) * (x2 - x1) / (f2 - f1);
                        }
                        else
                        {
                            // Bisection to guarantee progress.
                            x = 0.5f * (x1 + x2);
                        }

                        sweepA.GetTransform(out xfA, x);
                        sweepB.GetTransform(out xfB, x);

                        float f = fcn.Evaluate(xfA, xfB);

                        if (Math.Abs(f - target) < 0.025f * tolerance)
                        {
                            newAlpha = x;
                            break;
                        }

                        // Ensure we continue to bracket the root.
                        if (f > target)
                        {
                            x1 = x;
                            f1 = f;
                        }
                        else
                        {
                            x2 = x;
                            f2 = f;
                        }

                        ++rootIterCount;

                        Box2DxDebug.Assert(rootIterCount < 50);
                    }

                    MaxToiRootIters = Math.Max(MaxToiRootIters, rootIterCount);
                }

                // Ensure significant advancement.
                if (newAlpha < (1.0f + 100.0f * Settings.FltEpsilon) * alpha)
                {
                    break;
                }

                alpha = newAlpha;

                ++iter;

                if (iter == kMaxIterations)
                {
                    break;
                }
            }

            MaxToiIters = Math.Max(MaxToiIters, iter);

            return alpha;
        }
    }
}