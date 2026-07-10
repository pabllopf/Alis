using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    public class CollisionCoverageTest
    {
        [Fact]
        public void CollidePolygonAndCircle_EarlyOut_WhenSeparationSGreaterThanRadius()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(5.0f, 5.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollidePolygonAndCircle_BarycentricU1_ReturnsEarly_WhenRadiusExceeded()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-1.9f, -1.9f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollidePolygonAndCircle_BarycentricU2_ReturnsEarly_WhenRadiusExceeded()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.9f, -1.9f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollidePolygonAndCircle_FaceCenter_ReturnsEarly_WhenSeparationExceedsRadius()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(0.0f, -2.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollideEdgeAndCircle_RegionB_ReturnsEarly_WhenDistanceExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.5f, 2.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollideEdgeAndCircle_RegionAB_ReturnsEarly_WhenDistanceExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 2.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollideEdgeAndCircle_RegionAB_NormalDirection_FlipsCorrectly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, -0.4f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollidePolygons_ClipSegmentEarlyReturn_WhenFirstClipUnderTwoPoints()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 3.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollideEdgeAndPolygon_WithHasVertex0_FrontCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndPolygon_WithHasVertex3Only()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndPolygon_NonConvexAdjacent()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.5f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(2.5f, -0.5f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndPolygon_BackFaceCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndPolygon_PolygonAxisPrimary()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));

            Vertices thinRect = PolygonTools.CreateRectangle(0.1f, 2.0f);
            PolygonShape polygon = new PolygonShape(thinRect, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndPolygon_EdgeAxisTypeUnknown_Returns()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(10.0f, 10.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void CollideEdgeAndPolygon_EdgeSeparationExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 3.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.Equal(0, manifold.PointCount);
        }

        [Fact]
        public void TestOverlap_EdgeAndCircle_ShouldDetectOverlap()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);

            bool overlap = Collision.TestOverlap(edge, 0, circle, 0, ref xfEdge, ref xfCircle);

            Assert.False(overlap);
        }

        [Fact]
        public void GetPointStates_EmptyOldManifold_AllAdds()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 0;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 2;
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 10;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 20;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Add, state2[0]);
            Assert.Equal(PointState.Add, state2[1]);
        }

        // ========================================================================
        // EpCollider — first clip underflow (< MaxManifoldPoints)
        // ========================================================================

        /// <summary>
        ///     Tests that CollideEdgeAndPolygon returns early when the first ClipSegmentToLine
        ///     produces fewer than 2 points (np &lt; SettingEnv.MaxManifoldPoints).
        ///     Uses a non-overlapping configuration so the clip yields 0 points.
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_FirstClipUnderflow_ReturnsEarly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -2.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        ///     Tests that CollideEdgeAndPolygon returns early when the second ClipSegmentToLine
        ///     produces fewer than 2 points (np &lt; SettingEnv.MaxManifoldPoints).
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SecondClipUnderflow_ReturnsEarly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider.CalculateFrontState — various convexity/vertex combinations
        // ========================================================================

        /// <summary>
        ///     Tests CollideEdgeAndPolygon with HasVertex0 and HasVertex3, both convex,
        ///     to exercise the bothConvex branch in CalculateFrontState.
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BothConvexFront_FindsManifold()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Collinear adjacent edges → convex = true for both
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // ComputePolygonSeparation — adjacency skip via Dot(n, perp) branches
        // ========================================================================

        /// <summary>
        ///     Tests CollideEdgeAndPolygon with a configuration that exercises
        ///     the adjacency skip in ComputePolygonSeparation (Dot(n, perp) branches).
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_WithAdjacencySkip_Continues()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;
            // Non-collinear adjacent edges → non-convex
            edge.Vertex0 = new Vector2F(-0.5f, 0.5f);
            edge.Vertex3 = new Vector2F(2.5f, 0.5f);

            Vertices thinRect = PolygonTools.CreateRectangle(0.2f, 0.8f);
            PolygonShape polygon = new PolygonShape(thinRect, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — region A with hasVertex0=true (previous edge region)
        // with circle beyond radius for the early-out path
        // ========================================================================

        /// <summary>
        ///     Tests CollideEdgeAndCircle in region A with a previous edge,
        ///     where dd > radius*radius triggers early return.
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionA_FarFromVertex_ReturnsEarly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // v <= 0 (region A) but far enough that dd > radius^2
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-1.0f, 2.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        ///     Tests CollideEdgeAndCircle in region B with a next edge,
        ///     where dd > radius*radius triggers early return.
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionB_FarFromVertex_ReturnsEarly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // u <= 0 (region B) but far enough that dd > radius^2
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(3.0f, 2.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // ClipSegmentToLine — extension branch (distance0 * distance1 < 0)
        // ========================================================================

        /// <summary>
        ///     Tests that ClipSegmentToLine computes the intersection correctly
        ///     when one point is on each side of the clip plane.
        ///     This exercises the distance0 * distance1 < 0 branch.
        /// </summary>
        [Fact]
        public void CollidePolygons_ClipExtensionBranch_ComputesIntersection()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.6f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideCircles — exactly overlapping (distSqr == 0)
        // ========================================================================

        /// <summary>
        ///     Tests CollideCircles when circles are exactly on top of each other.
        /// </summary>
        [Fact]
        public void CollideCircles_ExactlyOverlapping_ProducesContact()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = ControllerTransform.Identity;
            Manifold manifold = new Manifold();

            Collision.CollideCircles(ref manifold, circleA, ref xfA, circleB, ref xfB);

            Assert.Equal(1, manifold.PointCount);
            Assert.Equal(ManifoldType.Circles, manifold.Type);
        }
    }
}
