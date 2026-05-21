

using System;
using System.Security.Cryptography;
using Alis.Core.Physic.Common.Decomposition.CDT.Polygon;

namespace Alis.Core.Physic.Common.Decomposition.CDT.Util
{
    /// <summary>
    ///     The polygon generator class
    /// </summary>
    internal class PolygonGenerator
    {
        /// <summary>
        ///     The random
        /// </summary>
        internal static readonly RandomNumberGenerator Rng = RandomNumberGenerator.Create();

        /// <summary>
        ///     Randoms the circle sweep using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <returns>The polygon polygon</returns>
        public static Polygon.Polygon RandomCircleSweep(double scale, int vertexCount)
        {
            PolygonPoint point;
            PolygonPoint[] points;
            double radius = scale / 4;

            points = new PolygonPoint[vertexCount];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[4];

                for (int i = 0; i < vertexCount; i++)
                {
                    do
                    {
                        rng.GetBytes(buffer);
                        double randomValue = BitConverter.ToUInt32(buffer, 0) / (double) uint.MaxValue - 0.5;

                        if (i % 250 == 0)
                        {
                            radius += scale / 2 * randomValue;
                        }
                        else if (i % 50 == 0)
                        {
                            radius += scale / 5 * randomValue;
                        }
                        else
                        {
                            radius += 25 * scale / vertexCount * randomValue;
                        }

                        radius = Math.Min(Math.Max(radius, scale / 10), scale / 2);
                    } while (radius < scale / 10 || radius > scale / 2);

                    point = new PolygonPoint(radius * Math.Cos(Math.PI * 2 * i / vertexCount),
                        radius * Math.Sin(Math.PI * 2 * i / vertexCount));
                    points[i] = point;
                }
            }

            return new Polygon.Polygon(points);
        }

        /// <summary>
        ///     Randoms the circle sweep 2 using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <returns>The polygon polygon</returns>
        public static Polygon.Polygon RandomCircleSweep2(double scale, int vertexCount)
        {
            PolygonPoint point;
            PolygonPoint[] points;
            double radius = scale / 4;

            points = new PolygonPoint[vertexCount];

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                byte[] buffer = new byte[4];

                for (int i = 0; i < vertexCount; i++)
                {
                    do
                    {
                        rng.GetBytes(buffer);
                        double randomValue = BitConverter.ToUInt32(buffer, 0) / (double) uint.MaxValue - 0.5;

                        radius += scale / 5 * randomValue;

                        radius = Math.Min(Math.Max(radius, scale / 10), scale / 2);
                    } while (radius < scale / 10 || radius > scale / 2);

                    point = new PolygonPoint(radius * Math.Cos(Math.PI * 2 * i / vertexCount),
                        radius * Math.Sin(Math.PI * 2 * i / vertexCount));
                    points[i] = point;
                }
            }

            return new Polygon.Polygon(points);
        }
    }
}