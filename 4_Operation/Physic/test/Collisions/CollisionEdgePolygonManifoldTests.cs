using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     Tests the manifold produced by the edge and polygon collider
    ///     (<see cref="Collision.CollideEdgeAndPolygon" />), both for degenerate inputs,
    ///     where no valid separation normal can be found, and for regular collisions.
    /// </summary>
    public class CollisionEdgePolygonManifoldTests
    {
        /// <summary>
        ///     Verifies that a polygon without vertices cannot produce a valid separation
        ///     normal, therefore no contact point is generated and the manifold keeps its
        ///     default values.
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_WhenPolygonHasNoVertices_ReturnsEmptyManifold()
        {
            // Arrange
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            PolygonShape polygon = new PolygonShape(1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.2f), 0.0f);
            Manifold manifold = new Manifold();

            // Act
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            // Assert
            Assert.Equal(0, manifold.PointCount);
            Assert.Equal(Vector2F.Zero, manifold.LocalNormal);
            Assert.Equal(Vector2F.Zero, manifold.LocalPoint);
            Assert.Equal(ManifoldType.Circles, manifold.Type);
        }

        /// <summary>
        ///     Verifies that a polygon placed behind the edge reference face produces a
        ///     face A manifold with the edge normal pointing towards the polygon and the
        ///     edge end vertex as the local contact point.
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_WhenPolygonIsBehindTheEdge_ProducesFaceAManifold()
        {
            // Arrange
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.2f), 0.0f);
            Manifold manifold = new Manifold();

            // Act
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            // Assert
            Assert.Equal(ManifoldType.FaceA, manifold.Type);
            Assert.Equal(2, manifold.PointCount);
            Assert.Equal(new Vector2F(0.0f, 1.0f), manifold.LocalNormal);
            Assert.Equal(new Vector2F(2.0f, 0.0f), manifold.LocalPoint);
        }
    }
}
