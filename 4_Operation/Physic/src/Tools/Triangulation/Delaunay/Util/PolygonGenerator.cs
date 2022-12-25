// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:   PolygonGenerator.cs
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

using System;
using Alis.Core.Physic.Tools.Triangulation.Delaunay.Polygon;
using Alis.Core.Physic.Utilities;

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Util
{
    /// <summary>
    ///     The polygon generator class
    /// </summary>
    internal class PolygonGenerator
    {
        /// <summary>
        ///     The random
        /// </summary>
        private static readonly Random Rng = new Random();

        /// <summary>
        ///     Randoms the circle sweep using the specified scale
        /// </summary>
        /// <param name="scale">The scale</param>
        /// <param name="vertexCount">The vertex count</param>
        /// <returns>The polygon polygon</returns>
        public static Polygon.Polygon RandomCircleSweep(double scale, int vertexCount)
        {
            double radius = scale / 4;

            PolygonPoint[] points = new PolygonPoint[vertexCount];
            for (int i = 0; i < vertexCount; i++)
            {
                do
                {
                    if (i % 250 == 0)
                    {
                        radius += scale / 2 * (0.5 - Rng.NextDouble());
                    }
                    else if (i % 50 == 0)
                    {
                        radius += scale / 5 * (0.5 - Rng.NextDouble());
                    }
                    else
                    {
                        radius += 25 * scale / vertexCount * (0.5 - Rng.NextDouble());
                    }

                    radius = radius > scale / 2 ? scale / 2 : radius;
                    radius = radius < scale / 10 ? scale / 10 : radius;
                } while (radius < scale / 10 || radius > scale / 2);

                points[i] = new PolygonPoint(radius * Math.Cos(MathConstants.TwoPi * i / vertexCount),
                    radius * Math.Sin(MathConstants.TwoPi * i / vertexCount));
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
            double radius = scale / 4;
            PolygonPoint[] points = new PolygonPoint[vertexCount];

            for (int i = 0; i < vertexCount; i++)
            {
                do
                {
                    radius += scale / 5 * (0.5 - Rng.NextDouble());
                    radius = radius > scale / 2 ? scale / 2 : radius;
                    radius = radius < scale / 10 ? scale / 10 : radius;
                } while (radius < scale / 10 || radius > scale / 2);

                points[i] = new PolygonPoint(radius * Math.Cos(MathConstants.TwoPi * i / vertexCount),
                    radius * Math.Sin(MathConstants.TwoPi * i / vertexCount));
            }

            return new Polygon.Polygon(points);
        }
    }
}