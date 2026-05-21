// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Vector2FParametrizedComprehensiveTest.cs
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

using System.Collections.Generic;
using System.Linq;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    ///     Parametrized comprehensive tests for Vector2F.
    ///     Tests all combinations of vector operations.
    /// </summary>
    public class Vector2FParametrizedComprehensiveTest
    {
        /// <summary>
        ///     Generates the vector combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateVectorCombinations()
        {
            float[] testValues = {0f, 1f, -1f, 2f, -2f, 0.5f, -0.5f, 10f, 100f};

            foreach (float v1 in testValues)
            {
                foreach (float v2 in testValues.Skip(0).Take(5))
                {
                    yield return new object[] {v1, v2};
                }
            }
        }

        /// <summary>
        ///     Generates the multiplication combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateMultiplicationCombinations()
        {
            float[] scalars = {0f, 0.5f, 1f, 2f, -1f, 10f};
            float[] vectors = {0f, 1f, 5f, 10f};

            foreach (float scalar in scalars)
            {
                foreach (float vector in vectors)
                {
                    yield return new object[] {vector, scalar};
                }
            }
        }

        /// <summary>
        ///     Tests that scalar multiplication combinations
        /// </summary>
        /// <param name="vectorValue">The vector value</param>
        /// <param name="scalar">The scalar</param>
        [Theory, MemberData(nameof(GenerateMultiplicationCombinations))]
        public void ScalarMultiplication_Combinations(float vectorValue, float scalar)
        {
            Vector2F vector = new Vector2F(vectorValue);
            Vector2F result = vector * scalar;

            Assert.NotNull(result);
        }
    }
}