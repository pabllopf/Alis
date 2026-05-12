// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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
using Alis.Core.Aspect.Math.Matrix;
using Alis.Core.Aspect.Math.Vector;

namespace Alis.Core.Aspect.Math.Sample
{
    /// <summary>
    ///     The program class
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main the args
        /// </summary>
        /// <param name="args">The args</param>
        public static void Main(string[] args)
        {
            Vector2F vec1 = new Vector2F(1, 2);
            Vector2F vec2 = new Vector2F(3, 4);
            Vector2F result = vec1 + vec2;
            float distanceSquared = QuickStartScenario.DistanceSquared(vec1, vec2);

            Matrix4X4 matrix = Matrix4X4.Identity;
            Matrix4X4 translated = matrix * Matrix4X4.CreateTranslation(new Vector3F(1, 2, 3));

            Console.WriteLine($"Vector sum: {result.X}, {result.Y}");
            Console.WriteLine($"Distance squared: {distanceSquared}");
            Console.WriteLine($"Translated matrix M11: {translated.M11}");
        }
    }
}
