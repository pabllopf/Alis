using System.Collections.Generic;
using Alis.Core.Aspect.Math.Shapes.Point;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Shape
{
    /// <summary>
    /// The point massive test class
    /// </summary>
    public class PointFMassiveTest1
    {
        /// <summary>
        /// Generates the test cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateTestCases()
        {
            // Generate 121 test cases
            yield return new object[] { -10f, -10f };
            yield return new object[] { -10f, -8f };
            yield return new object[] { -10f, -6f };
            yield return new object[] { -10f, -4f };
            yield return new object[] { -10f, -2f };
            yield return new object[] { -10f, 0f };
            yield return new object[] { -10f, 2f };
            yield return new object[] { -10f, 4f };
            yield return new object[] { -10f, 6f };
            yield return new object[] { -10f, 8f };
            yield return new object[] { -10f, 10f };
            yield return new object[] { -8f, -10f };
            yield return new object[] { -8f, -8f };
            yield return new object[] { -8f, -6f };
            yield return new object[] { -8f, -4f };
            yield return new object[] { -8f, -2f };
            yield return new object[] { -8f, 0f };
            yield return new object[] { -8f, 2f };
            yield return new object[] { -8f, 4f };
            yield return new object[] { -8f, 6f };
            yield return new object[] { -8f, 8f };
            yield return new object[] { -8f, 10f };
            yield return new object[] { -6f, -10f };
            yield return new object[] { -6f, -8f };
            yield return new object[] { -6f, -6f };
            yield return new object[] { -6f, -4f };
            yield return new object[] { -6f, -2f };
            yield return new object[] { -6f, 0f };
            yield return new object[] { -6f, 2f };
            yield return new object[] { -6f, 4f };
            yield return new object[] { -6f, 6f };
            yield return new object[] { -6f, 8f };
            yield return new object[] { -6f, 10f };
            yield return new object[] { -4f, -10f };
            yield return new object[] { -4f, -8f };
            yield return new object[] { -4f, -6f };
            yield return new object[] { -4f, -4f };
            yield return new object[] { -4f, -2f };
            yield return new object[] { -4f, 0f };
            yield return new object[] { -4f, 2f };
            yield return new object[] { -4f, 4f };
            yield return new object[] { -4f, 6f };
            yield return new object[] { -4f, 8f };
            yield return new object[] { -4f, 10f };
            yield return new object[] { -2f, -10f };
            yield return new object[] { -2f, -8f };
            yield return new object[] { -2f, -6f };
            yield return new object[] { -2f, -4f };
            yield return new object[] { -2f, -2f };
            yield return new object[] { -2f, 0f };
            yield return new object[] { -2f, 2f };
            yield return new object[] { -2f, 4f };
            yield return new object[] { -2f, 6f };
            yield return new object[] { -2f, 8f };
            yield return new object[] { -2f, 10f };
            yield return new object[] { 0f, -10f };
            yield return new object[] { 0f, -8f };
            yield return new object[] { 0f, -6f };
            yield return new object[] { 0f, -4f };
            yield return new object[] { 0f, -2f };
            yield return new object[] { 0f, 0f };
            yield return new object[] { 0f, 2f };
            yield return new object[] { 0f, 4f };
            yield return new object[] { 0f, 6f };
            yield return new object[] { 0f, 8f };
            yield return new object[] { 0f, 10f };
            yield return new object[] { 2f, -10f };
            yield return new object[] { 2f, -8f };
            yield return new object[] { 2f, -6f };
            yield return new object[] { 2f, -4f };
            yield return new object[] { 2f, -2f };
            yield return new object[] { 2f, 0f };
            yield return new object[] { 2f, 2f };
            yield return new object[] { 2f, 4f };
            yield return new object[] { 2f, 6f };
            yield return new object[] { 2f, 8f };
            yield return new object[] { 2f, 10f };
            yield return new object[] { 4f, -10f };
            yield return new object[] { 4f, -8f };
            yield return new object[] { 4f, -6f };
            yield return new object[] { 4f, -4f };
            yield return new object[] { 4f, -2f };
            yield return new object[] { 4f, 0f };
            yield return new object[] { 4f, 2f };
            yield return new object[] { 4f, 4f };
            yield return new object[] { 4f, 6f };
            yield return new object[] { 4f, 8f };
            yield return new object[] { 4f, 10f };
            yield return new object[] { 6f, -10f };
            yield return new object[] { 6f, -8f };
            yield return new object[] { 6f, -6f };
            yield return new object[] { 6f, -4f };
            yield return new object[] { 6f, -2f };
            yield return new object[] { 6f, 0f };
            yield return new object[] { 6f, 2f };
            yield return new object[] { 6f, 4f };
            yield return new object[] { 6f, 6f };
            yield return new object[] { 6f, 8f };
            yield return new object[] { 6f, 10f };
            yield return new object[] { 8f, -10f };
            yield return new object[] { 8f, -8f };
            yield return new object[] { 8f, -6f };
            yield return new object[] { 8f, -4f };
            yield return new object[] { 8f, -2f };
            yield return new object[] { 8f, 0f };
            yield return new object[] { 8f, 2f };
            yield return new object[] { 8f, 4f };
            yield return new object[] { 8f, 6f };
            yield return new object[] { 8f, 8f };
            yield return new object[] { 8f, 10f };
            yield return new object[] { 10f, -10f };
            yield return new object[] { 10f, -8f };
            yield return new object[] { 10f, -6f };
            yield return new object[] { 10f, -4f };
            yield return new object[] { 10f, -2f };
            yield return new object[] { 10f, 0f };
            yield return new object[] { 10f, 2f };
            yield return new object[] { 10f, 4f };
            yield return new object[] { 10f, 6f };
            yield return new object[] { 10f, 8f };
            yield return new object[] { 10f, 10f };
            
        }

        /// <summary>
        /// Tests that point f operation 1
        /// </summary>
        /// <param name="x">The </param>
        /// <param name="y">The </param>
        [Theory]
        [MemberData(nameof(GenerateTestCases))]
        public void PointF_Operation_1(float x, float y)
        {
            PointF shape = new PointF(x, y);
            Assert.NotNull(shape);
        }
    }
}
