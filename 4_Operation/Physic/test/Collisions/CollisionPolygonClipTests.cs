using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     Tests the clipping failures of <see cref="Collision.CollidePolygons" />.
    /// </summary>
    public class CollisionPolygonClipTests
    {
        /// <summary>
        ///     Verifies that an incident edge lying completely outside the first side plane
        ///     discards the contact even though both polygons overlap.
        /// </summary>
        [Fact]
        public void CollidePolygons_WhenIncidentEdgeLiesBeyondFirstClipPlane_ReturnsEmptyManifold()
        {
            PolygonShape polygonA = CreateTriangle(0.0f, 0.0f, 0.5f, -1.0f, 1.0f, 0.0f);
            PolygonShape polygonB = CreateTriangle(1.125f, -0.01f, 1.5f, -0.01f, -0.5f, 0.001f);
            ControllerTransform transformA = ControllerTransform.Identity;
            ControllerTransform transformB = ControllerTransform.Identity;
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polygonA, ref transformA, polygonB, ref transformB);

            Assert.True(Collision.TestOverlap(polygonA, 0, polygonB, 0, ref transformA, ref transformB));
            Assert.Equal(0, manifold.PointCount);
            Assert.Equal(ManifoldType.FaceA, manifold.Type);
            Assert.Equal(Vector2F.Zero, manifold.LocalNormal);
            Assert.Equal(Vector2F.Zero, manifold.LocalPoint);
        }

        /// <summary>
        ///     Verifies that an incident edge lying completely outside the second side plane
        ///     discards the contact even though both polygons overlap.
        /// </summary>
        [Fact]
        public void CollidePolygons_WhenIncidentEdgeLiesBeyondSecondClipPlane_ReturnsEmptyManifold()
        {
            PolygonShape polygonA = CreateTriangle(0.0f, 0.0f, 0.5f, -1.0f, 1.0f, 0.0f);
            PolygonShape polygonB = CreateTriangle(2.0f, 0.002f, -0.5f, -0.02f, -0.125f, -0.02f);
            ControllerTransform transformA = ControllerTransform.Identity;
            ControllerTransform transformB = ControllerTransform.Identity;
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polygonA, ref transformA, polygonB, ref transformB);

            Assert.True(Collision.TestOverlap(polygonA, 0, polygonB, 0, ref transformA, ref transformB));
            Assert.Equal(0, manifold.PointCount);
            Assert.Equal(ManifoldType.FaceA, manifold.Type);
            Assert.Equal(Vector2F.Zero, manifold.LocalNormal);
            Assert.Equal(Vector2F.Zero, manifold.LocalPoint);
        }

        /// <summary>
        ///     Creates a triangle polygon from the given vertex coordinates.
        /// </summary>
        private static PolygonShape CreateTriangle(float x0, float y0, float x1, float y1, float x2, float y2)
        {
            Vertices vertices = new Vertices(new[]
            {
                new Vector2F(x0, y0),
                new Vector2F(x1, y1),
                new Vector2F(x2, y2)
            });

            return new PolygonShape(vertices, 1.0f);
        }
    }
}
