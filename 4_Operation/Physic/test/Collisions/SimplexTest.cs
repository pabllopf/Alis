using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class SimplexTest
    {
        [Fact]
        public void GetSearchDirection_WithSingleVertex_ShouldNegateVertex()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(2.0f, -3.0f) };

            Vector2F direction = simplex.GetSearchDirection();

            Assert.Equal(new Vector2F(-2.0f, 3.0f), direction);
        }

        [Fact]
        public void Solve2_ShouldReduceToClosestVertex_WhenOriginOutsideSegment()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(5.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(7.0f, 0.0f) };

            simplex.Solve2();

            Assert.Equal(1, simplex.Count);
        }

        [Fact]
        public void GetMetric_WithTwoPoints_ShouldReturnSegmentLength()
        {
            Simplex simplex = new Simplex
            {
                Count = 2,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex { W = new Vector2F(0.0f, 0.0f) };
            simplex.V[1] = new SimplexVertex { W = new Vector2F(3.0f, 4.0f) };

            float metric = simplex.GetMetric();

            Assert.Equal(5.0f, metric);
        }

        [Fact]
        public void GetWitnessPoints_WithSinglePoint_ShouldReturnStoredPoints()
        {
            Simplex simplex = new Simplex
            {
                Count = 1,
                V = new FixedArray3<SimplexVertex>()
            };
            simplex.V[0] = new SimplexVertex
            {
                Wa = new Vector2F(1.0f, 2.0f),
                Wb = new Vector2F(3.0f, 4.0f)
            };

            simplex.GetWitnessPoints(out Vector2F pointA, out Vector2F pointB);

            Assert.Equal(new Vector2F(1.0f, 2.0f), pointA);
            Assert.Equal(new Vector2F(3.0f, 4.0f), pointB);
        }
    }
}

