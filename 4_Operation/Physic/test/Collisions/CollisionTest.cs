using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class CollisionTest
    {
        [Fact]
        public void TestOverlap_ShouldReturnTrue_ForOverlappingCircles()
        {
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.5f, 0.0f), 0.0f);

            bool overlap = Collision.TestOverlap(shapeA, 0, shapeB, 0, ref xfA, ref xfB);

            Assert.True(overlap);
        }

        [Fact]
        public void CollideCircles_ShouldProduceSingleContact_WhenIntersecting()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideCircles(ref manifold, circleA, ref xfA, circleB, ref xfB);

            Assert.Equal(1, manifold.PointCount);
            Assert.Equal(ManifoldType.Circles, manifold.Type);
        }

        [Fact]
        public void CollidePolygonAndCircle_ShouldProduceContact_ForCircleInsidePolygon()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = ControllerTransform.Identity;
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.True(manifold.PointCount >= 1);
        }

        [Fact]
        public void CollidePolygons_ShouldGenerateManifold_ForOverlappingRectangles()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        [Fact]
        public void GetPointStates_ShouldMarkPersistAndAddCorrectly()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 1;
            ManifoldPoint oldPoint = oldManifold.Points[0];
            oldPoint.Id.Key = 11;
            oldManifold.Points[0] = oldPoint;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 2;
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 11;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 22;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Persist, state1[0]);
            Assert.Equal(PointState.Persist, state2[0]);
            Assert.Equal(PointState.Add, state2[1]);
        }
    }
}


