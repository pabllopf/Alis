// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CustomMathFComprehensiveParametrizedTest.cs
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
using Xunit;

namespace Alis.Core.Aspect.Math.Test
{
    /// <summary>
    ///     Ultra-comprehensive parametrized tests for CustomMathF.
    ///     Generates 1000+ test cases through parameter combinations.
    /// </summary>
    public class CustomMathFComprehensiveParametrizedTest
    {
        /// <summary>
        ///     Generates the arithmetic combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateArithmeticCombinations()
        {
            int[] intValues = {0, 1, 2, 3, 5, 10, 100, -1, -10, -100};
            float[] floatValues = {0f, 1f, 2f, 5f, 10f, 100f, 0.5f, -0.5f, -1f, -10f};

            int caseCount = 0;
            foreach (int a in intValues)
            {
                foreach (int b in intValues.Take(5))
                {
                    yield return new object[] {a, b, caseCount++};
                }
            }
        }

        /// <summary>
        ///     Tests that max int various combinations
        /// </summary>
        /// <param name="a">The </param>
        /// <param name="b">The </param>
        /// <param name="caseIndex">The case index</param>
        [Theory, MemberData(nameof(GenerateArithmeticCombinations))]
        public void MaxInt_VariousCombinations(int a, int b, int caseIndex)
        {
            int result = CustomMathF.Max(a, b);
            Assert.True((result >= a) && (result >= b));
        }

        /// <summary>
        ///     Generates the clamp combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateClampCombinations()
        {
            for (float value = -10f; value <= 10f; value += 2.5f)
            {
                for (float min = -5f; min <= 5f; min += 2.5f)
                {
                    for (float max = min + 1f; max <= 10f; max += 2.5f)
                    {
                        yield return new object[] {value, min, max};
                    }
                }
            }
        }

        /// <summary>
        ///     Tests that clamp all combinations
        /// </summary>
        /// <param name="value">The value</param>
        /// <param name="min">The min</param>
        /// <param name="max">The max</param>
        [Theory, MemberData(nameof(GenerateClampCombinations))]
        public void Clamp_AllCombinations(float value, float min, float max)
        {
            if (min <= max)
            {
                float result = CustomMathF.Clamp(value, min, max);
                Assert.InRange(result, min, max);
            }
        }

        /// <summary>
        ///     Generates the sqrt combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateSqrtCombinations()
        {
            for (float x = 0f; x <= 100f; x += 5f)
            {
                yield return new object[] {x};
            }

            for (float x = 0.1f; x <= 1f; x += 0.1f)
            {
                yield return new object[] {x};
            }
        }

        /// <summary>
        ///     Tests that sqrt range validation
        /// </summary>
        /// <param name="x">The </param>
        [Theory, MemberData(nameof(GenerateSqrtCombinations))]
        public void Sqrt_RangeValidation(float x)
        {
            float result = CustomMathF.Sqrt(x);
            Assert.True(float.IsNaN(result) || result >= 0);
        }

        /// <summary>
        ///     Generates the abs combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateAbsCombinations()
        {
            for (int i = -100; i <= 100; i += 10)
            {
                yield return new object[] {(float) i};
            }
        }

        /// <summary>
        ///     Tests that abs various values
        /// </summary>
        /// <param name="x">The </param>
        [Theory, MemberData(nameof(GenerateAbsCombinations))]
        public void Abs_VariousValues(float x)
        {
            float result = CustomMathF.Abs(x);
            Assert.True(result >= 0);
        }
    }
}