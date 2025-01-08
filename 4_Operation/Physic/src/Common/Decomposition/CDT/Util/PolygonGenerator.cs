// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PolygonGenerator.cs
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
        private static readonly RandomNumberGenerator RNG = RandomNumberGenerator.Create();

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
                        // Generate a secure random number for radius adjustment
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

                        // Constrain the radius to be within bounds
                        radius = Math.Min(Math.Max(radius, scale / 10), scale / 2);
                    } while (radius < scale / 10 || radius > scale / 2);

                    // Create the point with the secure random radius
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
                        // Generate secure random number for radius adjustment
                        rng.GetBytes(buffer);
                        double randomValue = BitConverter.ToUInt32(buffer, 0) / (double) uint.MaxValue - 0.5;

                        radius += scale / 5 * randomValue;

                        // Constrain the radius within the desired range
                        radius = Math.Min(Math.Max(radius, scale / 10), scale / 2);
                    } while (radius < scale / 10 || radius > scale / 2);

                    // Calculate the point based on the secure random radius
                    point = new PolygonPoint(radius * Math.Cos(Math.PI * 2 * i / vertexCount),
                        radius * Math.Sin(Math.PI * 2 * i / vertexCount));
                    points[i] = point;
                }
            }

            return new Polygon.Polygon(points);
        }
    }
}