using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The separation function remaining coverage tests class
    /// </summary>
    public class SeparationFunctionRemainingCoverageTests
    {
        /// <summary>
        /// Tests that set face a flip axis when point b above face
        /// </summary>
        [Fact]
        public void Set_FaceA_FlipAxis_WhenPointBAboveFace()
        {
            PolygonShape shapeA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape shapeB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            DistanceProxy proxyA = new DistanceProxy(shapeA, 0);
            DistanceProxy proxyB = new DistanceProxy(shapeB, 0);
            Sweep sweepA = new Sweep { C0 = Vector2F.Zero, C = Vector2F.Zero, LocalCenter = Vector2F.Zero };
            Sweep sweepB = new Sweep { C0 = new Vector2F(0.0f, 3.0f), C = new Vector2F(0.0f, 3.0f), LocalCenter = Vector2F.Zero };

            SimplexCache cache = new SimplexCache { Count = 2 };
            cache.IndexA[0] = 3;
            cache.IndexA[1] = 0;
            cache.IndexB[0] = 0;
            cache.IndexB[1] = 0;

            SeparationFunction.Set(ref cache, ref proxyA, ref sweepA, ref proxyB, ref sweepB, 0.0f);
            float separation = SeparationFunction.FindMinSeparation(out int _, out int _, 0.0f);

            Assert.False(float.IsNaN(separation));
            Assert.False(float.IsInfinity(separation));
        }

        
    }
}
