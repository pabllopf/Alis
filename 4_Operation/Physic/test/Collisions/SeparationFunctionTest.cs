using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class SeparationFunctionTest
    {
        [Fact]
        public void Set_WithOneCachePoint_ShouldConfigurePointsModeAndEvaluateFiniteSeparation()
        {
            CircleShape shapeA = new CircleShape(0.5f, 1.0f);
            CircleShape shapeB = new CircleShape(0.5f, 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            Sweep sweepA = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            Sweep sweepB = new Sweep { C0 = new Vector2F(2.0f, 0.0f), C = new Vector2F(2.0f, 0.0f), LocalCenter = Vector2F.Zero };

            SimplexCache cache = new SimplexCache { Count = 1 };
            cache.IndexA[0] = 0;
            cache.IndexB[0] = 0;

            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float separation = SeparationFunction.FindMinSeparation(out int indexA, out int indexB, 0.0f);

            Assert.True(separation > 0.0f);
            Assert.Equal(0, indexA);
            Assert.Equal(0, indexB);
        }

        [Fact]
        public void Evaluate_ShouldReturnFiniteValue_AfterSet()
        {
            PolygonShape shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            Sweep sweepA = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            Sweep sweepB = new Sweep { C0 = new Vector2F(3.0f, 0.0f), C = new Vector2F(3.0f, 0.0f), LocalCenter = Vector2F.Zero };

            SimplexCache cache = new SimplexCache { Count = 2 };
            cache.IndexA[0] = 0;
            cache.IndexA[1] = 1;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 1;

            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float s = SeparationFunction.Evaluate(0, 0, 0.0f);

            Assert.False(float.IsNaN(s));
            Assert.False(float.IsInfinity(s));
        }
    }
}

