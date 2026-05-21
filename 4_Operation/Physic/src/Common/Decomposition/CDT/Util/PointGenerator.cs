

using System;
using System.Collections.Generic;
using System.Security.Cryptography;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The point generator class
    /// </summary>
    internal class PointGenerator
    {
        /// <summary>
        ///     The random
        /// </summary>
        internal static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Uniforms the distribution using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="scale">The scale</param>
        /// <returns>The points</returns>
        public static List<TriangulationPoint> UniformDistribution(int n, double scale)
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            byte[] buffer = new byte[4];

            for (int i = 0; i < n; i++)
            {
                Rng.GetBytes(buffer);
                double x = BitConverter.ToUInt32(buffer, 0) / (double) uint.MaxValue - 0.5;
                x *= scale;

                Rng.GetBytes(buffer);
                double y = BitConverter.ToUInt32(buffer, 0) / (double) uint.MaxValue - 0.5;
                y *= scale;

                points.Add(new TriangulationPoint(x, y));
            }

            return points;
        }

        /// <summary>
        ///     Uniforms the grid using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="scale">The scale</param>
        /// <returns>The points</returns>
        public static List<TriangulationPoint> UniformGrid(int n, double scale)
        {
            double x = 0;
            double size = scale / n;
            double halfScale = 0.5 * scale;

            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < n + 1; i++)
            {
                x = halfScale - i * size;
                for (int j = 0; j < n + 1; j++)
                {
                    points.Add(new TriangulationPoint(x, halfScale - j * size));
                }
            }

            return points;
        }
    }
}