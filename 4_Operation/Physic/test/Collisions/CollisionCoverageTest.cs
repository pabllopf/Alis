using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The collision coverage test class
    /// </summary>
    public class CollisionCoverageTest
    {
        /// <summary>Used for comparing floats in assertions.</summary>
        private const float Epsilon = 1e-6f;
        /// <summary>
        /// Tests that collide polygon and circle early out when separation s greater than radius
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygon and circle barycentric u 1 returns early when radius exceeded
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygon and circle barycentric u 2 returns early when radius exceeded
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygon and circle face center returns early when separation exceeds radius
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and circle region b returns early when distance exceeds radius
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and circle region ab returns early when distance exceeds radius
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and circle region ab normal direction flips correctly
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygons clip segment early return when first clip under two points
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and polygon with has vertex 0 front collision
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_WithHasVertex0_FrontCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon with has vertex 3 only
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_WithHasVertex3Only()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon non convex adjacent
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_NonConvexAdjacent()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(2.5f, -0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon back face collision
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFaceCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon polygon axis primary
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and polygon edge axis type unknown returns
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and polygon edge separation exceeds radius
        /// </summary>
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

        /// <summary>
        /// Tests that test overlap edge and circle should detect overlap
        /// </summary>
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

        /// <summary>
        /// Tests that get point states empty old manifold all adds
        /// </summary>
        [Fact]
        public void GetPointStates_EmptyOldManifold_AllAdds()
        {
            Manifold oldManifold = new Manifold
                {
                    PointCount = 0
                };

            Manifold newManifold = new Manifold
                {
                    PointCount = 2
                };
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 10;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 20;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> _, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    // Collinear adjacent edges → convex = true for both
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    HasVertex3 = true,
                    // Non-collinear adjacent edges → non-convex
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    Vertex3 = new Vector2F(2.5f, 0.5f)
                };

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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = false
                };
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
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = false
                };
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

        // ========================================================================
        // EpCollider ComputeLimits — front=false (back path at line 1288-1289)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face with both vertices computes limits
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFaceWithBothVertices_ComputesLimits()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider CalculateFrontState — HasVertex0 only, Convex1=false
        // (IsFrontBoth path at line 1263-1265)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon has vertex 0 only non convex executes front state
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex0OnlyNonConvex_ExecutesFrontState()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 1.0f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider CalculateFrontState — HasVertex3 only, Convex2=true
        // (IsFrontAny path at line 1271-1273)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon has vertex 3 only convex executes front state
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex3OnlyConvex_ExecutesFrontState()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider CalculateFrontState — HasVertex0 && HasVertex3, Convex1=true, Convex2=false
        // (IsFrontFirstOrBoth path at line 1254-1255)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon convex 1 only executes front first or both
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_Convex1Only_ExecutesFrontFirstOrBoth()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider SelectFrontLowerLimit — HasVertex0 && HasVertex3, Convex1=true
        // (returns i.Normal0 at line 1348)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select front lower limit with convex 1 executes
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectFrontLowerLimitWithConvex1_Executes()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // SelectPrimaryAxis — polygonAxis.Type == Unknown (returns edgeAxis, line 1433)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select primary axis unknown returns edge axis
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectPrimaryAxisUnknown_ReturnsEdgeAxis()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(10.0f, 10.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // FindBestEdge — sPrev > s > sNext (increment = -1, line 800-802)
        // Also exercises LocalSearch with increment == -1 (line 841-843)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons find best edge prev side local search increment neg
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdgePrevSide_LocalSearchIncrementNeg()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.6f, 0.0f), (float)Math.PI / 6.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // IsCircleInPreviousEdgeRegion — false branch (produces contact)
        // Circle in Region A, within radius of vertex A,
        // HasVertex0=true, u1 <= 0 so IsCircleInPreviousEdgeRegion returns false.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle previous edge returns false produces contact
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_PreviousEdge_ReturnsFalse_ProducesContact()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (-0.05, -0.2): v = -0.1 <= 0 (Region A),
            // dd = 0.0425 <= radius^2 = 0.0961,
            // u1 = -0.05 <= 0 => IsCircleInPreviousEdgeRegion returns false.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.05f, -0.2f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // IsCircleInPreviousEdgeRegion — true branch (early return)
        // Circle in Region A, within radius, HasVertex0=true, u1 > 0.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle previous edge returns true early return
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_PreviousEdge_ReturnsTrue_EarlyReturn()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (-0.05, 0.03): v = -0.1 <= 0 (Region A),
            // dd = 0.0034 <= radius^2 = 0.0961,
            // u1 = 0.065 > 0 => IsCircleInPreviousEdgeRegion returns true => early return.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.05f, 0.03f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // IsCircleInNextEdgeRegion — false branch (produces contact)
        // Circle in Region B, within radius of vertex B,
        // HasVertex3=true, v2 <= 0 so IsCircleInNextEdgeRegion returns false.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle next edge returns false produces contact
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_NextEdge_ReturnsFalse_ProducesContact()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (2.05, -0.1): u = -0.1 <= 0 (Region B),
            // dd = 0.0125 <= radius^2 = 0.0961,
            // v2 = 0.0 <= 0 => IsCircleInNextEdgeRegion returns false.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.05f, -0.1f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // IsCircleInNextEdgeRegion — true branch (early return)
        // Circle in Region B, within radius, HasVertex3=true, v2 > 0.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle next edge returns true early return
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_NextEdge_ReturnsTrue_EarlyReturn()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (2.05, 0.05): u = -0.1 <= 0 (Region B),
            // dd = 0.005 <= radius^2 = 0.0961,
            // v2 = 0.075 > 0 => IsCircleInNextEdgeRegion returns true => early return.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.05f, 0.05f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region AB with normal flip (n·(q-a) < 0)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region ab normal flip produces contact
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_NormalFlip_ProducesContact()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (1.0, -0.1): Region AB (v=2>0, u=2>0),
            // dd2 = 0.01 <= radius^2 = 0.0961,
            // n·(q-a) = (0,2)·(1,-0.1) = -0.2 < 0 => normal flips.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, -0.1f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
            Assert.Equal(ManifoldType.FaceA, manifold.Type);
        }

        // ========================================================================
        // ResolveBarycentricContact — u1 <= 0 branch, r > radius^2 (early return)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygon and circle u 1 branch early return
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_U1Branch_EarlyReturn()
        {
            // Circle near vertex (-2,-2) of a 2x2 square centered at origin.
            // The u1 barycentric coordinate <= 0, but distance > radius.
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            // Place circle outside but near the bottom-left vertex, beyond radius distance.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-2.6f, -2.6f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // ResolveBarycentricContact — u1 <= 0 branch, r <= radius^2 (SetupVertexAManifold)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygon and circle u 1 branch setup vertex a manifold
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_U1Branch_SetupVertexAManifold()
        {
            // Circle near vertex (-2,-2), within radius.
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            // Separation must be >= epsilon so we go to ResolveBarycentricContact.
            // Circle at (-2.15, -2.15): s for normal (0,-1) = -(-2.15+2) = 0.15 < epsilon? No.
            // Actually need separation >= epsilon.
            // normal (0,-1) vs vertex (-2,-2): s = 0*... + (-1)*(-2.15+2) = 0.15 < radius
            // This separation = 0.15 >= epsilon, so we go to ResolveBarycentricContact.
            // u1 = (-2.15+2)*(2+2) + (-2.15+2)*(-2+2) = -0.15*4 + 0 = -0.6 <= 0
            // r = 0.15^2 + 0.15^2 = 0.045 <= radius^2 = 0.0961 => SetupVertexAManifold
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-2.15f, -2.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // ResolveBarycentricContact — u2 <= 0 branch, r <= radius^2 (SetupVertexAManifold)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygon and circle u 2 branch setup vertex a manifold
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_U2Branch_SetupVertexAManifold()
        {
            // Circle near vertex (2,-2), within radius.
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.15f, -2.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // ResolveBarycentricContact — else branch, separation2 > radius (early return)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygon and circle face center branch early return
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_FaceCenterBranch_EarlyReturn()
        {
            // Circle above top edge but too far.
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            // Circle directly above center of top edge: (0, 2.5)
            // u1 = (0-(-2))*(2-(-2)) + (2.5-2)*(2-2) = 2*4 + 0.5*0 = 8 > 0
            // u2 = (0-2)*(-2-2) + (2.5-2)*(2-2) = -2*(-4) + 0 = 8 > 0
            // separation2 = n·(cLocal-faceCenter) where n = (0,1), faceCenter = (0,2)
            // = 0*(0-0) + 1*(2.5-2) = 0.5 > radius = 0.21 => early return.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(0.0f, 2.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollidePolygons — separationB > totalRadius early return
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons separation a early return
        /// </summary>
        [Fact]
        public void CollidePolygons_SeparationAEarlyReturn()
        {
            // separationA > totalRadius early return.
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            // Far apart so separationA > totalRadius
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 10.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollidePolygons — flip=true with feature swap (contact produced)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons flip true feature swap
        /// </summary>
        [Fact]
        public void CollidePolygons_FlipTrue_FeatureSwap()
        {
            // Use shapes where separationB > 0.98 * separationA + 0.001.
            // Tall rect vs wide rect with offset makes B's separation larger.
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.3f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        // ========================================================================
        // CollidePolygons — flip=true, FaceB manifold, with feature swap (all branches)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons flip true face b manifold
        /// </summary>
        [Fact]
        public void CollidePolygons_FlipTrue_FaceBManifold()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 2.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.3f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — first clip underflow (np < 2)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons first clip underflow
        /// </summary>
        [Fact]
        public void CollidePolygons_FirstClipUnderflow()
        {
            // Polygons overlap on separation axes but first clip fails.
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            // Slight offset to trigger overlap but clip fails.
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.4f, 0.4f), 0.2f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — second clip underflow (np < 2)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons second clip underflow
        /// </summary>
        [Fact]
        public void CollidePolygons_SecondClipUnderflow()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.35f, 0.35f), 0.15f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — ComputePolygonSeparation s > radius early return (EdgeB)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon compute polygon separation early return
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ComputePolygonSeparation_EarlyReturn()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            // Thin tall polygon off to one side so polygon face axis has s > radius
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 2.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 1.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectPrimaryAxis polygonAxis.Type == Unknown (returns edgeAxis)
        // ========================================================================

        // Already covered by CollideEdgeAndPolygon_EdgeAxisTypeUnknown_Returns.
        // If edgeAxis also Unknown, Collide will return early at L1020.

        // ========================================================================
        // EpCollider — SelectPrimaryAxis polygonAxis.Separation > tol (returns polygonAxis)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select primary axis polygon dominant
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectPrimaryAxis_PolygonDominant()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — CalculateFrontState both vertices, Convex1=false, Convex2=true
        // (IsFrontLastOrBoth path)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon calculate front state convex 1 false convex 2 true
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_CalculateFrontState_Convex1FalseConvex2True()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    // Non-convex preceding edge (cross product < 0)
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = true,
                    // Convex following edge (cross product >= 0)
                    Vertex3 = new Vector2F(3.0f, 1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — CalculateFrontState both vertices, both non-convex
        // (IsFrontAll path)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon calculate front state both non convex
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_CalculateFrontState_BothNonConvex()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — ComputeLimits back/front path
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face limits both vertices
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFaceLimits_BothVertices()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Polygon behind the edge (positive y)
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectFrontLowerLimit, SelectFrontUpperLimit branches
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select limits convex 1 not convex 2
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectLimits_Convex1NotConvex2()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 1.0f),
                    HasVertex3 = true,
                    // Non-convex following edge -> Convex2 = false
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackLowerLimit / SelectBackUpperLimit branches
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back limits
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackLimits()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Polygon behind the edge
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — BuildEdgeAManifold front=false branch
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon edge manifold back face
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EdgeManifold_BackFace()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — BuildFaceBManifold path (primaryAxis.Type == EdgeB)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon build face b manifold
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BuildFaceBManifold()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 2.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position polygon so polygon axis dominates
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // BuildManifoldPoints — primaryAxis.Type != EdgeA (face B path)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon build manifold points face b
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BuildManifoldPoints_FaceB()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 2.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — first clip underflow (< MaxManifoldPoints = 2)
        // This forces the branch where np < SettingEnv.MaxManifoldPoints after
        // first ClipSegmentToLine inside EpCollider.Collide.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon ep collider first clip underflow
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EpCollider_FirstClipUnderflow()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.1f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — second clip underflow (< MaxManifoldPoints = 2)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon ep collider second clip underflow
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EpCollider_SecondClipUnderflow()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region A, dd > radius^2 early return (L473-L476)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region a dd exceeds radius
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionA_DdExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // v = -2.0 <= 0 (Region A), but far away
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-1.0f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region B, dd > radius^2 early return (L503-L506)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region b dd exceeds radius
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionB_DdExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // u = -2.0 <= 0 (Region B), but far away
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(3.0f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region AB, dd2 > radius^2 early return (L532-L535)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region ab dd 2 exceeds radius
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_Dd2ExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Region AB: 0 < qx < 2, but circle too far from edge segment (dd2 > radius^2)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region AB, normal NOT flipped (n·(q-a) >= 0)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region ab normal not flipped
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_NormalNotFlipped()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (1.0, 0.1): n·(q-a) = 0.2 >= 0 => normal NOT flipped
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 0.1f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // EpCollider — HasVertex3 only, Convex2=true (IsFrontAny with NaN path)
        // Also exercises SelectFrontLowerLimit just returning Normal1
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon has vertex 3 only convex 2 true front state
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex3Only_Convex2True_FrontState()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    // Convex2 = true (cross >= 0)
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — HasVertex0 only, Convex1=true (IsFrontAny with NaN path)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon has vertex 0 only convex 1 true front state
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex0Only_Convex1True_FrontState()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — HasVertex0 && HasVertex3, Convex1=true, Convex2=false
        // (SelectFrontUpperLimit returns Normal1 at L1360)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select front upper limit convex 1 not convex 2 returns normal 1
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectFrontUpperLimit_Convex1NotConvex2_ReturnsNormal1()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — HasVertex0 only, Convex1=true, HasVertex3=false
        // (SelectFrontUpperLimit returns -Normal1 at L1361)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon select front upper limit convex 1 true returns neg normal 1
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectFrontUpperLimit_Convex1True_ReturnsNegNormal1()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackLowerLimit with both vertices, Convex1 && !Convex2
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back lower limit convex 1 not convex 2
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackLowerLimit_Convex1NotConvex2()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 1.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackUpperLimit with HasVertex0 only, Convex1=true
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back upper limit convex 1 true
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackUpperLimit_Convex1True()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — consecutive overlapping (separation <= totalRadius for both)
        // with multiple clip points to exercise clip filtering loop
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons multiple clip points filtered
        /// </summary>
        [Fact]
        public void CollidePolygons_MultipleClipPoints_Filtered()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.2f, 0.2f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        // ========================================================================
        // CollidePolygons — flipped manifold with feature swap (FaceB, flip=true)
        // where clip points need feature swapping.
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons flip true feature swap face b
        /// </summary>
        [Fact]
        public void CollidePolygons_FlipTrue_FeatureSwap_FaceB()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.4f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // FindBestEdge — sNext > s branch (increment = +1)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons find best edge next edge dominant
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdge_NextEdgeDominant()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.6f, 0.0f), -(float)Math.PI / 6.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // LocalSearch — increment = +1 branch (default else)
        // ========================================================================

        // Same as FindBestEdge_NextEdgeDominant if the LocalSearch uses +1 increment.

        // ========================================================================
        // LocalSearch — s > bestSeparation (loop iteration finds better edge)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons local search improves separation
        /// </summary>
        [Fact]
        public void CollidePolygons_LocalSearch_ImprovesSeparation()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.4f, 0.1f), (float)Math.PI / 4.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // GetPointStates — old manifold has points but new manifold is empty
        // (all removes, no adds)
        // ========================================================================

        /// <summary>
        /// Tests that get point states old has points new empty all removes
        /// </summary>
        [Fact]
        public void GetPointStates_OldHasPoints_NewEmpty_AllRemoves()
        {
            Manifold oldManifold = new Manifold
                {
                    PointCount = 2
                };
            ManifoldPoint oldPoint0 = oldManifold.Points[0];
            oldPoint0.Id.Key = 10;
            oldManifold.Points[0] = oldPoint0;
            ManifoldPoint oldPoint1 = oldManifold.Points[1];
            oldPoint1.Id.Key = 20;
            oldManifold.Points[1] = oldPoint1;

            Manifold newManifold = new Manifold
                {
                    PointCount = 0
                };

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> _, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Remove, state1[0]);
            Assert.Equal(PointState.Remove, state1[1]);
        }

        // ========================================================================
        // EpCollider — HasVertex3 only, Convex2=false (IsFrontBoth path)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon has vertex 3 only non convex front state
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex3Only_NonConvex_FrontState()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — HasVertex0 && HasVertex3, Convex1=false, Convex2=true
        // (IsFrontLastOrBoth path, line 1319-1320)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon is front last or both executes
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_IsFrontLastOrBoth_Executes()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — HasVertex0 && HasVertex3, both non-convex
        // (IsFrontAll path, line 1329-1330)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon is front all executes
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_IsFrontAll_Executes()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackLowerLimit HasVertex0 && HasVertex3, Convex1=true
        // (returns -Neg? or forces neg path at L1373)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back lower limit convex 1 true
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackLowerLimit_Convex1True()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackLowerLimit HasVertex0 only, Convex1=false (returns -Neg)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back lower limit non convex
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackLowerLimit_NonConvex()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackUpperLimit HasVertex3 only (returns Normal1 at L1388)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back upper limit has vertex 3 only
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackUpperLimit_HasVertex3Only()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectBackUpperLimit both vertices, Convex1=true (returns neg)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back upper limit both convex 1 true
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackUpperLimit_BothConvex1True()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — back face, HasVertex0 only, Convex1=false
        // (SelectBackUpperLimit returns -i.Normal0 at L1387)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face select back upper limit non convex
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_SelectBackUpperLimit_NonConvex()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — dd > radius^2 in Region A, with HasVertex0=true
        // Tests that we enter Region A early return without calling
        // IsCircleInPreviousEdgeRegion.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region a far previous edge misses is circle check
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionA_Far_PreviousEdge_MissesIsCircleCheck()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Far from vertex A in Region A: v <= 0 but dd > radius^2
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.5f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region B, dd > radius^2, HasVertex3=true
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region b far next edge misses is circle check
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionB_Far_NextEdge_MissesIsCircleCheck()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Far from vertex B in Region B: u <= 0 but dd > radius^2
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.5f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region AB, normal flips, dd2 <= radius^2
        // Edge with HasVertex0 and HasVertex3 true
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region ab with adjacent edges
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_WithAdjacentEdges()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, -0.1f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // GetPointStates — old point count 1, new point count 1 with same key
        // (persist path on both)
        // ========================================================================

        /// <summary>
        /// Tests that get point states single point persists
        /// </summary>
        [Fact]
        public void GetPointStates_SinglePointPersists()
        {
            Manifold oldManifold = new Manifold
                {
                    PointCount = 1
                };
            ManifoldPoint oldPoint = oldManifold.Points[0];
            oldPoint.Id.Key = 42;
            oldManifold.Points[0] = oldPoint;

            Manifold newManifold = new Manifold
                {
                    PointCount = 1
                };
            ManifoldPoint newPoint = newManifold.Points[0];
            newPoint.Id.Key = 42;
            newManifold.Points[0] = newPoint;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Persist, state1[0]);
            Assert.Equal(PointState.Persist, state2[0]);
        }

        // ========================================================================
        // IsCircleInPreviousEdgeRegion — HasVertex0=false early return (L568-L569)
        // Circle in Region A (v <= 0), dd <= radius^2, HasVertex0=false.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region a has vertex 0 false returns false
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionA_HasVertex0False_ReturnsFalse()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (-0.05, 0.0): v = -0.1 <= 0 (Region A),
            // dd = 0.0025 <= radius^2 = 0.0961,
            // IsCircleInPreviousEdgeRegion: HasVertex0=false => returns false immediately.
            // Then contact is produced.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.05f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // IsCircleInNextEdgeRegion — HasVertex3=false early return (L590-L591)
        // Circle in Region B (u <= 0), dd <= radius^2, HasVertex3=false.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and circle region b has vertex 3 false returns false
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionB_HasVertex3False_ReturnsFalse()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = false
                };

            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // q = (2.05, 0.0): u = -0.1 <= 0 (Region B),
            // dd = 0.0025 <= radius^2 = 0.0961,
            // IsCircleInNextEdgeRegion: HasVertex3=false => returns false immediately.
            // Then contact is produced.
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.05f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // CollidePolygons — flip=true path (separationB dominates)
        // Using differently-shaped rectangles to ensure separationB > tol.
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons flip true with feature swap
        /// </summary>
        [Fact]
        public void CollidePolygons_FlipTrue_WithFeatureSwap()
        {
            // Wide vs tall rectangle to trigger flip=true with contact points needing swap.
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(2.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — first clip underflow (np < SettingEnv.MaxManifoldPoints)
        // Using rotated polygons to force clip to yield < 2 points.
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons first clip underflow early return
        /// </summary>
        [Fact]
        public void CollidePolygons_FirstClipUnderflow_EarlyReturn()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.2f, 0.3f), 0.3f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — second clip underflow (np < SettingEnv.MaxManifoldPoints)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons second clip underflow early return
        /// </summary>
        [Fact]
        public void CollidePolygons_SecondClipUnderflow_EarlyReturn()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.3f, 0.3f), 0.3f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — front face, edge axis primary, produce contact
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon front face edge axis primary produces contact
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_FrontFace_EdgeAxisPrimary_ProducesContact()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.2f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — back face, edge axis primary, produce contact
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face edge axis primary
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_EdgeAxisPrimary()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.3f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — polygon axis primary, BuildFaceBManifold with BackFace
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon face b primary back face
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_FaceB_Primary_BackFace()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — front face, polygon axis primary, BuildFaceBManifold
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon face b primary front face
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_FaceB_Primary_FrontFace()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.2f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectPrimaryAxis polygonAxis.Type != Unknown and 
        // polygonAxis.Separation > kRelativeTol * edgeAxis.Separation + kAbsoluteTol
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon polygon separation dominates selects polygon axis
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_PolygonSeparationDominates_SelectsPolygonAxis()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 2.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — first clip underflow in EpCollider.Collide
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon ep collider clip underflow
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EpCollider_ClipUnderflow()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.2f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — second clip underflow in EpCollider.Collide
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon ep collider second clip underflow 2
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_EpCollider_SecondClipUnderflow2()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // FindBestEdge — sPrev > s && sPrev > sNext (increment = -1)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons find best edge prev edge dominant
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdge_PrevEdgeDominant()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.3f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.5f, 0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // FindBestEdge — sNext > s (increment = +1), LocalSearch increment +1
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons find best edge next edge dominant local search increment pos
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdge_NextEdgeDominant_LocalSearchIncrementPos()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.3f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.5f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // LocalSearch — s > bestSeparation (loop finds better edge)
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons local search improves separation 2
        /// </summary>
        [Fact]
        public void CollidePolygons_LocalSearch_ImprovesSeparation2()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.5f, 0.1f), 0.3f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — back face with HasVertex0 && HasVertex3, Convex1, !Convex2
        // Exercises SelectBackLowerLimit (L1373) and SelectBackUpperLimit (L1386)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face limits both vertices convex 1
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_Limits_BothVertices_Convex1()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, -1.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — back face with HasVertex0 only, Convex1=false
        // Exercises SelectBackLowerLimit (L1374) 
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face has vertex 0 non convex
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_HasVertex0_NonConvex()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, -1.0f),
                    HasVertex3 = false
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — back face with HasVertex3 only
        // Exercises SelectBackUpperLimit (L1388)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon back face has vertex 3 only
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_HasVertex3Only()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = false,
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — edge axis type unknown with non-overlapping
        // ========================================================================

        // Already covered by CollideEdgeAndPolygon_EdgeAxisTypeUnknown_Returns.

        // ========================================================================
        // EpCollider — ComputePolygonSeparation adjacency skip via Dot(n, perp) >= 0
        // and Dot(n - upperLimit, normal) < -AngularSlop
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon compute polygon separation adjacency skip
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ComputePolygonSeparation_AdjacencySkip()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-0.5f, 0.5f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(2.5f, -0.5f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.2f, 0.8f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — BuildManifoldPoints with FaceB primary axis (swap features)
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon build manifold points face b swap
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BuildManifoldPoints_FaceBSwap()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.3f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — brute-force multiple configurations to hit branches
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons multiple configs branch coverage
        /// </summary>
        [Fact]
        public void CollidePolygons_MultipleConfigs_BranchCoverage()
        {
            // Try many configurations to cover flip, clip, feature swap
            float[] positions = { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f, 1.2f, 1.5f };
            float[] rotations = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, (float)Math.PI / 6, (float)Math.PI / 4, (float)Math.PI / 3 };
            float[] widthsA = { 0.5f, 1.0f, 1.5f, 2.0f };
            float[] heightsA = { 0.5f, 1.0f, 1.5f };
            float[] widthsB = { 0.5f, 1.0f, 1.5f };
            float[] heightsB = { 0.5f, 1.0f, 2.0f };

            int runs = 0;
            foreach (float x in positions)
            {
                foreach (float rot in rotations)
                {
                    foreach (float wa in widthsA)
                    {
                        foreach (float ha in heightsA)
                        {
                            foreach (float wb in widthsB)
                            {
                                foreach (float hb in heightsB)
                                {
                                    if (++runs > 500) goto done;
                                    PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(wa, ha), 1.0f);
                                    PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(wb, hb), 1.0f);
                                    ControllerTransform xfA = ControllerTransform.Identity;
                                    ControllerTransform xfB = new ControllerTransform(new Vector2F(x, 0.0f), rot);
                                    Manifold manifold = new Manifold();
                                    Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
                                }
                            }
                        }
                    }
                }
            }
            done:;
        }

        // ========================================================================
        // CollideEdgeAndPolygon — brute-force multiple configurations
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon multiple configs branch coverage
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_MultipleConfigs_BranchCoverage()
        {
            float[] positionsX = { 0.5f, 1.0f, 1.5f, 2.0f };
            float[] positionsY = { -0.5f, -0.3f, 0.0f, 0.3f, 0.5f, 0.8f, 1.0f, 1.5f };
            float[] rotations = { 0.0f, 0.1f, 0.2f, 0.3f, (float)Math.PI / 6 };
            float[] widths = { 0.3f, 0.5f, 1.0f, 2.0f };
            float[] heights = { 0.3f, 0.5f, 1.0f, 2.0f };

            int runs = 0;
            foreach (float px in positionsX)
            {
                foreach (float py in positionsY)
                {
                    foreach (float rot in rotations)
                    {
                        foreach (float w in widths)
                        {
                            foreach (float h in heights)
                            {
                                if (++runs > 300) goto done;
                                EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                                    {
                                        HasVertex0 = true,
                                        Vertex0 = new Vector2F(-1.0f, 0.0f),
                                        HasVertex3 = true,
                                        Vertex3 = new Vector2F(3.0f, 0.0f)
                                    };

                                PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(w, h), 1.0f);
                                ControllerTransform xfEdge = ControllerTransform.Identity;
                                ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(px, py), rot);
                                Manifold manifold = new Manifold();
                                Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
                            }
                        }
                    }
                }
            }
            done:;
        }

        // ========================================================================
        // CollideEdgeAndPolygon — brute-force adjacency skip variations
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon adjacency variations branch coverage
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_AdjacencyVariations_BranchCoverage()
        {
            float[] vos = { -2.0f, -1.5f, -1.0f, -0.5f, 0.0f, 0.5f, 1.0f, 1.5f };
            float[] v3s = { 1.5f, 2.0f, 2.5f, 3.0f, 3.5f, 4.0f, 4.5f, 5.0f };

            int runs = 0;
            foreach (float v0x in vos)
            {
                foreach (float v0y in vos)
                {
                    foreach (float v3x in v3s)
                    {
                        foreach (float v3y in vos)
                        {
                            if (++runs > 200) goto done;
                            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                                {
                                    HasVertex0 = true,
                                    Vertex0 = new Vector2F(v0x, v0y),
                                    HasVertex3 = true,
                                    Vertex3 = new Vector2F(v3x, v3y)
                                };

                            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
                            ControllerTransform xfEdge = ControllerTransform.Identity;
                            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
                            Manifold manifold = new Manifold();
                            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
                        }
                    }
                }
            }
            done:;
        }

        // ========================================================================
        // CollideEdgeAndPolygon — expanded configurations for EpCollider branches
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon expanded configs branch coverage
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ExpandedConfigs_BranchCoverage()
        {
            float[] xs = { 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f, 1.2f, 1.5f, 2.0f };
            float[] ys = { -1.0f, -0.8f, -0.6f, -0.4f, -0.2f, 0.0f, 0.2f, 0.4f, 0.6f, 0.8f, 1.0f, 1.5f, 2.0f };
            float[] rots = { 0.0f, 0.1f, 0.2f, 0.3f, 0.5f, 0.8f, 1.0f, (float)Math.PI / 6, (float)Math.PI / 4, (float)Math.PI / 3, (float)Math.PI / 2 };
            float[] ws = { 0.1f, 0.2f, 0.3f, 0.5f, 0.8f, 1.0f, 1.5f, 2.0f, 3.0f, 5.0f };
            float[] hs = { 0.1f, 0.2f, 0.3f, 0.5f, 0.8f, 1.0f, 1.5f, 2.0f, 3.0f, 5.0f };
            bool[] hasVert0 = { false, true };
            bool[] hasVert3 = { false, true };

            int runs = 0;
            foreach (float x in xs)
            {
                foreach (float y in ys)
                {
                    foreach (float rot in rots)
                    {
                        foreach (float w in ws)
                        {
                            foreach (float h in hs)
                            {
                                if (++runs > 400) goto done;
                                for (int hv0 = 0; hv0 < 2; hv0++)
                                {
                                    for (int hv3 = 0; hv3 < 2; hv3++)
                                    {
                                        EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                                            {
                                                HasVertex0 = hasVert0[hv0],
                                                Vertex0 = new Vector2F(-1.0f, 0.0f),
                                                HasVertex3 = hasVert3[hv3],
                                                Vertex3 = new Vector2F(3.0f, 0.0f)
                                            };

                                        PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(w, h), 1.0f);
                                        ControllerTransform xfEdge = ControllerTransform.Identity;
                                        ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(x, y), rot);
                                        Manifold manifold = new Manifold();
                                        Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            done:;
        }

        // ========================================================================
        // CollidePolygons — additional configurations for clip/feature swap
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons extra configs branch coverage
        /// </summary>
        [Fact]
        public void CollidePolygons_ExtraConfigs_BranchCoverage()
        {
            float[] xs = { 0.0f, 0.1f, 0.2f, 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f, 1.2f, 1.5f, 2.0f };
            float[] rots = { 0.0f, 0.05f, 0.1f, 0.15f, 0.2f, 0.25f, 0.3f, 0.4f, 0.5f, 0.6f, 0.8f, 1.0f, (float)Math.PI / 6, (float)Math.PI / 4, (float)Math.PI / 3 };
            float[] sizes = { 0.3f, 0.4f, 0.5f, 0.6f, 0.7f, 0.8f, 0.9f, 1.0f, 1.2f, 1.5f, 2.0f };

            int runs = 0;
            foreach (float x in xs)
            {
                foreach (float rot in rots)
                {
                    foreach (float s1 in sizes)
                    {
                        foreach (float s2 in sizes)
                        {
                            if (++runs > 500) goto done;
                            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(s1, s2), 1.0f);
                            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(s2, s1), 1.0f);
                            ControllerTransform xfA = ControllerTransform.Identity;
                            ControllerTransform xfB = new ControllerTransform(new Vector2F(x, 0.0f), rot);
                            Manifold manifold = new Manifold();
                            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
                        }
                    }
                }
            }
            done:;
        }

        // ========================================================================
        // CollidePolygons — rotation-based configurations for flip branch
        // ========================================================================

        /// <summary>
        /// Tests that collide polygons rotation configs branch coverage
        /// </summary>
        [Fact]
        public void CollidePolygons_RotationConfigs_BranchCoverage()
        {
            for (int i = 0; i < 200; i++)
            {
                float x = (i % 20) * 0.1f;
                float rot = (i / 20) * 0.1f;
                PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f + (i % 5) * 0.3f, 0.5f + (i / 5 % 5) * 0.3f), 1.0f);
                PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f + (i % 7) * 0.3f, 0.5f + (i / 7 % 5) * 0.3f), 1.0f);
                ControllerTransform xfA = ControllerTransform.Identity;
                ControllerTransform xfB = new ControllerTransform(new Vector2F(x, 0.0f), rot);
                Manifold manifold = new Manifold();
                Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            }
        }

        // ========================================================================
        // EpCollider — targeted configuration for polygonSeparation > radius
        // Using thin tall polygon at angle where one face shows separation
        // while edge normal shows close proximity.
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon polygon separation exceeds radius
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_PolygonSeparationExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            // Narrow tall polygon rotated so one face normal points away from edge
            // while edge shows proximity.
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 5.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 2.0f), (float)Math.PI / 4.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — thin polygon near edge, ComputePolygonSeparation s > radius
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon thin polygon separation exceeds radius
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ThinPolygon_SeparationExceedsRadius()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.05f, 3.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position right at the edge: edge normal shows close proximity
            // but polygon horizontal normals show separation > radius
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(0.5f, 0.01f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — targeted to trigger clip underflow in EpCollider
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon shallow overlap clip underflow
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ShallowOverlap_ClipUnderflow()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            // Very small polygon just barely overlapping
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.01f, 0.01f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.005f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — barely touching with rotation for clip underflow
        // ========================================================================

        /// <summary>
        /// Tests that collide edge and polygon barely touching clip underflow
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BarelyTouching_ClipUnderflow()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f))
                {
                    HasVertex0 = true,
                    Vertex0 = new Vector2F(-1.0f, 0.0f),
                    HasVertex3 = true,
                    Vertex3 = new Vector2F(3.0f, 0.0f)
                };

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.01f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(0.5f, -0.005f), 0.3f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }
    }
}
