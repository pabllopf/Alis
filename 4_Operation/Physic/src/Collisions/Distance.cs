

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;

namespace Alis.Core.Physic.Collisions
{
    /// <summary>
    ///     Provides distance computation between convex shapes using the GJK algorithm.
    /// </summary>
    /// <remarks>
    ///     This class implements the Gilbert-Johnson-Keerthi (GJK) algorithm for computing
    ///     the minimum distance between two convex shapes. The algorithm works by maintaining
    ///     a simplex (point, line segment, or triangle) in Minkowski space and iteratively
    ///     refining it until the closest point to the origin is found.
    ///     
    ///     The algorithm is used extensively in the physics engine for:
    ///     - Broad-phase collision detection
    ///     - Narrow-phase collision detection
    ///     - Contact point generation
    ///     
    ///     Performance is optimized by caching simplex state between frames and using
    ///     early termination criteria to avoid unnecessary iterations.
    /// </remarks>
    public static class Distance
    {
        /// <summary>
        ///     Gets the total number of calls made to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/> since last reset.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the cumulative call count.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for profiling and performance analysis.
        /// </remarks>
        [ThreadStatic] public static int GjkCalls;

        /// <summary>
        ///     Gets the number of iterations used in the most recent call to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/>.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the iteration count of the last call.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for identifying performance issues with specific collision pairs.
        /// </remarks>
        [ThreadStatic] public static int GjkIters;

        /// <summary>
        ///     Gets the maximum number of iterations ever used by any call to <see cref="ComputeDistance(out DistanceOutput, out SimplexCache, DistanceInput)"/>.
        /// </summary>
        /// <value>
        ///     An <see cref="int"/> representing the maximum iteration count observed.
        /// </value>
        /// <remarks>
        ///     This statistic is only tracked when <see cref="SettingEnv.EnableDiagnostics"/> is <c>true</c>.
        ///     Useful for tuning <see cref="SettingEnv.MaxGjkIterations"/> to balance performance and accuracy.
        /// </remarks>
        [ThreadStatic] public static int GjkMaxIters;

        /// <summary>
        ///     Computes the minimum distance between two convex shapes using the GJK algorithm.
        /// </summary>
        /// <param name="output">The output parameter that receives the distance result and witness points.</param>
        /// <param name="cache">The cache parameter that stores simplex state for potential reuse in subsequent calls.</param>
        /// <param name="input">The input parameters specifying the shapes, their transforms, and calculation options.</param>
        /// <remarks>
        ///     The algorithm iteratively builds a simplex in the Minkowski difference of the two shapes.
        ///     It terminates when:
        ///     - The simplex contains 3 points (origin is inside the simplex = shapes overlap)
        ///     - A duplicate support point is found (cycling prevention)
        ///     - Maximum iterations reached
        ///     - Search direction becomes too small (degenerate case)
        ///     
        ///     The output contains the distance and two witness points (one on each shape)
        ///     that represent the closest points between the shapes.
        /// </remarks>
        public static void ComputeDistance(out DistanceOutput output, out SimplexCache cache, DistanceInput input)
        {
            cache = new SimplexCache();

            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                ++GjkCalls;
            }

            Simplex simplex = new Simplex();
            simplex.ReadCache(ref cache, ref input.ProxyA, ref input.ControllerTransformA, ref input.ProxyB, ref input.ControllerTransformB);

            FixedArray3<int> saveA = new FixedArray3<int>();
            FixedArray3<int> saveB = new FixedArray3<int>();

            //float distanceSqr1 = Settings.MaxFloat;

            int iter = 0;
            while (iter < SettingEnv.MaxGjkIterations)
            {
                int saveCount = simplex.Count;
                for (int i = 0; i < saveCount; ++i)
                {
                    saveA[i] = simplex.V[i].IndexA;
                    saveB[i] = simplex.V[i].IndexB;
                }

                switch (simplex.Count)
                {
                    case 1:
                        break;
                    case 2:
                        simplex.Solve2();
                        break;
                    case 3:
                        simplex.Solve3();
                        break;
                }

                if (simplex.Count == 3)
                {
                    break;
                }

                //float distanceSqr2 = p.LengthSquared();

                //distanceSqr1 = distanceSqr2;

                Vector2F d = simplex.GetSearchDirection();

                if (d.LengthSquared() < SettingEnv.Epsilon * SettingEnv.Epsilon)
                {
                    // or triangle. Thus the shapes are overlapped.

                    break;
                }

                SimplexVertex vertex = simplex.V[simplex.Count];
                vertex.IndexA = input.ProxyA.GetSupport(-Complex.Divide(ref d, ref input.ControllerTransformA.Rotation));
                vertex.Wa = ControllerTransform.Multiply(input.ProxyA.Vertices[vertex.IndexA], ref input.ControllerTransformA);

                vertex.IndexB = input.ProxyB.GetSupport(Complex.Divide(ref d, ref input.ControllerTransformB.Rotation));
                vertex.Wb = ControllerTransform.Multiply(input.ProxyB.Vertices[vertex.IndexB], ref input.ControllerTransformB);
                vertex.W = vertex.Wb - vertex.Wa;
                simplex.V[simplex.Count] = vertex;

                ++iter;

                if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
                {
                    ++GjkIters;
                }

                bool duplicate = false;
                for (int i = 0; i < saveCount; ++i)
                {
                    if ((vertex.IndexA == saveA[i]) && (vertex.IndexB == saveB[i]))
                    {
                        duplicate = true;
                        break;
                    }
                }

                if (duplicate)
                {
                    break;
                }

                ++simplex.Count;
            }

            if (SettingEnv.EnableDiagnostics) //FPE: We only gather diagnostics when enabled
            {
                GjkMaxIters = Math.Max(GjkMaxIters, iter);
            }

            simplex.GetWitnessPoints(out output.PointA, out output.PointB);
            output.Distance = (output.PointA - output.PointB).Length();
            output.Iterations = iter;

            simplex.WriteCache(ref cache);

            if (input.UseRadii)
            {
                float rA = input.ProxyA.Radius;
                float rB = input.ProxyB.Radius;

                if ((output.Distance > rA + rB) && (output.Distance > SettingEnv.Epsilon))
                {
                    output.Distance -= rA + rB;
                    Vector2F normal = output.PointB - output.PointA;
                    normal.Normalize();
                    output.PointA += rA * normal;
                    output.PointB -= rB * normal;
                }
                else
                {
                    Vector2F p = 0.5f * (output.PointA + output.PointB);
                    output.PointA = p;
                    output.PointB = p;
                    output.Distance = 0.0f;
                }
            }
        }
    }
}