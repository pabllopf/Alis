// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PointGenerator.cs
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

namespace Alis.Core.Physic.Tools.Triangulation.Delaunay.Util
{
    /// <summary>
    ///     The point generator class
    /// </summary>
    internal class PointGenerator
    {
        /// <summary>
        ///     The random
        /// </summary>
        private static readonly Random Rng = new Random();

        /// <summary>
        ///     Uniforms the distribution using the specified n
        /// </summary>
        /// <param name="n">The </param>
        /// <param name="scale">The scale</param>
        /// <returns>The points</returns>
        public static List<TriangulationPoint> UniformDistribution(int n, double scale)
        {
            List<TriangulationPoint> points = new List<TriangulationPoint>();
            for (int i = 0; i < n; i++)
            {
                points.Add(new TriangulationPoint(scale * (0.5 - Rng.NextDouble()), scale * (0.5 - Rng.NextDouble())));
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