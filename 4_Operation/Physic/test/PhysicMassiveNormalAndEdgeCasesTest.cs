using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test
{
    /// <summary>
    /// Adds broad coverage for normal and boundary AABB scenarios.
    /// </summary>
    public class PhysicMassiveNormalAndEdgeCasesTest
    {
        /// <summary>
        /// Generates the aabb cases
        /// </summary>
        /// <returns>An enumerable of object array</returns>
        public static IEnumerable<object[]> GenerateAabbCases()
        {
            for (int i = 0; i < 100; i++)
            {
                float minX = (i % 100) - 50f;
                float minY = ((i / 100f) % 25f) - 12f;
                float width = (i % 17 == 0) ? 0f : (i % 31) + 0.5f;
                float height = (i % 19 == 0) ? 0f : ((i * 3) % 29) + 0.25f;
                float maxX = minX + width;
                float maxY = minY + height;
                yield return new object[] {minX, minY, maxX, maxY};
            }
        }

        /// <summary>
        /// Tests that aabb normal and edge cases remain stable
        /// </summary>
        /// <param name="minX">The min</param>
        /// <param name="minY">The min</param>
        /// <param name="maxX">The max</param>
        /// <param name="maxY">The max</param>
        [Theory, MemberData(nameof(GenerateAabbCases))]
        public void Aabb_NormalAndEdgeCases_RemainStable(float minX, float minY, float maxX, float maxY)
        {
            Vector2F min = new Vector2F(minX, minY);
            Vector2F max = new Vector2F(maxX, maxY);
            Aabb aabb = new Aabb(min, max);

            Assert.True(aabb.IsValid());
            Assert.InRange(Math.Abs(aabb.Width - (maxX - minX)), 0f, 1e-5f);
            Assert.InRange(Math.Abs(aabb.Height - (maxY - minY)), 0f, 1e-5f);

            Aabb self = aabb;
            Assert.True(aabb.Contains(ref self));
            Assert.True(Aabb.TestOverlap(ref aabb, ref self));

            if (aabb.Width > 0f && aabb.Height > 0f)
            {
                Vector2F center = aabb.Center;
                Assert.True(aabb.Contains(ref center));
            }

            Assert.True(aabb.Q1.IsValid());
            Assert.True(aabb.Q2.IsValid());
            Assert.True(aabb.Q3.IsValid());
            Assert.True(aabb.Q4.IsValid());
        }
    }
}


