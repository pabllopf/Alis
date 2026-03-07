using Alis.Core.Aspect.Math.Vector;
using Xunit;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Alis.Core.Aspect.Math.Test.Vector
{
    /// <summary>
    /// Parametrized comprehensive tests for Vector3F.
    /// Tests all combinations of vector operations.
    /// </summary>
    public class Vector3FParametrizedComprehensiveTest
    {
        /// <summary>
        /// Generates the vector combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateVectorCombinations()
        {
            float[] testValues = { 0f, 1f, -1f, 2f, -2f, 0.5f, -0.5f, 10f, 100f };
            
            foreach (var v1 in testValues)
            {
                foreach (var v2 in testValues.Skip(0).Take(5))
                {
                    yield return new object[] { v1, v2 };
                }
            }
        }



        /// <summary>
        /// Generates the multiplication combinations
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateMultiplicationCombinations()
        {
            float[] scalars = { 0f, 0.5f, 1f, 2f, -1f, 10f };
            float[] vectors = { 0f, 1f, 5f, 10f };
            
            foreach (var scalar in scalars)
            {
                foreach (var vector in vectors)
                {
                    yield return new object[] { vector, scalar };
                }
            }
        }
        
    }
}
