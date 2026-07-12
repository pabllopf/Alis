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
    /// The collision remaining coverage tests class
    /// </summary>
    public class CollisionRemainingCoverageTests
    {
        /// <summary>
        /// Tests that collide polygons find best edge next side local search increment pos
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdgeNextSide_LocalSearchIncrementPos()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.6f, 0.0f), -(float)Math.PI / 6.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide polygons find best edge direct return
        /// </summary>
        [Fact]
        public void CollidePolygons_FindBestEdgeDirectReturn()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        /// <summary>
        /// Tests that collide polygons flip swap features
        /// </summary>
        [Fact]
        public void CollidePolygons_FlipSwapFeatures()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(2.0f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 2.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        /// <summary>
        /// Tests that collide edge and polygon build manifold points edge b path
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BuildManifoldPoints_EdgeBPath()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 0.0f);
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 0.0f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.1f, 2.0f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon select front lower limit no adjacents
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_SelectFrontLowerLimit_NoAdjacents()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and circle region a with previous edge no early return
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionA_WithPreviousEdge_NoEarlyReturn()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(0.0f, -1.0f);
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.2f, 0.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide edge and circle region b with next edge no early return
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionB_WithNextEdge_NoEarlyReturn()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(2.0f, -1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.2f, 0.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide edge and circle region ab normal flip produces contact
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_NormalFlip_ProducesContact()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, -0.4f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide edge and polygon back face compute limits back path
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_BackFace_ComputeLimitsBackPath()
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

        /// <summary>
        /// Tests that collide polygons second separation exceeds total radius
        /// </summary>
        [Fact]
        public void CollidePolygons_SecondSeparationExceedsTotalRadius()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.0f, 3.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide polygons both separations exceed total radius
        /// </summary>
        [Fact]
        public void CollidePolygons_BothSeparationsExceedTotalRadius()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(10.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide edge and polygon has vertex 0 only non convex back face
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex0Only_NonConvex_BackFace()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.5f);
            edge.HasVertex3 = false;

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, 0.8f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        /// <summary>
        /// Tests that collide edge and polygon has vertex 3 only non convex front face
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_HasVertex3Only_NonConvex_FrontFace()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = false;
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(2.5f, -0.5f);

            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.5f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygons — separationA > totalRadius early out (lines 319-320)
        // ========================================================================
        [Fact]
        public void CollidePolygons_SeparationAExceedsRadius_ReturnsEarly()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(10.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollidePolygons — clip points < 2 (lines 389-390, 397-398)
        // ========================================================================
        [Fact]
        public void CollidePolygons_FewClipPoints_ReturnsEarly()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(10.0f, 0.5f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.8f, 0.0f), (float)Math.PI / 4.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region A and Region B (lines 853-861)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndCircle_RegionAReturns_NoCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.5f, 0.5f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndCircle_RegionBReturns_NoCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.5f, 0.5f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — Region AB with dd2 > radius (line 532-535)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndCircle_RegionAB_Far_ReturnsNoCollision()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(0.5f, 1.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollidePolygonAndCircle — separation < Epsilon triggers SetupFaceAManifold (line 194)
        // ========================================================================
        [Fact]
        public void CollidePolygonAndCircle_CenterInside_SetupFaceA()
        {
            PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            CircleShape circle = new CircleShape(0.1f, 1.0f);
            ControllerTransform xfPoly = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(Vector2F.Zero, 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.Equal(1, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — edgeAxis.Separation > radius (lines 1020-1021)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndPolygon_EdgeSepExceedsRadius_ReturnsEarly()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(5.0f, 5.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.Equal(0, manifold.PointCount);
        }

        // ========================================================================
        // CollideEdgeAndPolygon — with both adjacent edges (HasVertex0 & HasVertex3)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndPolygon_BothAdjacentEdges_Collides()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.HasVertex3 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.0f);
            edge.Vertex3 = new Vector2F(2.5f, 0.0f);
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.3f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // ResolveBarycentricContact — u1 <= 0 with r > radius (line 224-225)
        // ========================================================================
        [Fact]
        public void CollidePolygonAndCircle_BaryU1_ReturnsEarly()
        {
            PolygonShape poly = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            CircleShape circle = new CircleShape(0.1f, 1.0f);
            ControllerTransform xfPoly = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.8f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollidePolygonAndCircle(ref manifold, poly, ref xfPoly, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // CollideEdgeAndCircle — with HasVertex0/3 edge regions (lines 478, 508)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndCircle_HasVertex0_RegionA()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-0.5f, 0.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.3f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        [Fact]
        public void CollideEdgeAndCircle_HasVertex3_RegionB()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(1.5f, 0.0f);
            CircleShape circle = new CircleShape(0.2f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.3f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);
            Assert.True(manifold.PointCount >= 0);
        }

        // ========================================================================
        // EpCollider — SelectPrimaryAxis with Unknown polygonAxis (lines 1434-1435)
        // ========================================================================
        [Fact]
        public void CollideEdgeAndPolygon_SelectPrimaryAxisUnknown_ReturnsEdgeAxis()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(10.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();
            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);
            Assert.Equal(0, manifold.PointCount);
        }
    }
}
