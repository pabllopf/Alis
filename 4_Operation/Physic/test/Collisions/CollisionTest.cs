// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CollisionTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    /// The collision test class
    /// </summary>
    public class CollisionTest
    {
        /// <summary>
        /// Tests that test overlap should return true for overlapping circles
        /// </summary>
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

        /// <summary>
        /// Tests that collide circles should produce single contact when intersecting
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygon and circle should produce contact for circle inside polygon
        /// </summary>
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

        /// <summary>
        /// Tests that collide polygons should generate manifold for overlapping rectangles
        /// </summary>
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

        /// <summary>
        /// Tests that get point states should mark persist and add correctly
        /// </summary>
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

        /// <summary>
        /// Tests that collide edge and circle should produce contact when circle touches edge
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldProduceContact_WhenCircleTouchesEdge()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 0.4f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide edge and polygon should produce contact when polygon overlaps edge
        /// </summary>
        [Fact]
        public void CollideEdgeAndPolygon_ShouldProduceContact_WhenPolygonOverlapsEdge()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            PolygonShape polygon = new PolygonShape(PolygonTools.CreateRectangle(0.5f, 0.5f), 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(1.0f, -0.2f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndPolygon(ref manifold, edge, ref xfEdge, polygon, ref xfPolygon);

            Assert.True(manifold.PointCount >= 1);
        }

        /// <summary>
        /// Tests that test overlap should return false for non overlapping circles
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnFalse_ForNonOverlappingShapes()
        {
            CircleShape shapeA = new CircleShape(1.0f, 1.0f);
            CircleShape shapeB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(10.0f, 0.0f), 0.0f);

            bool overlap = Collision.TestOverlap(shapeA, 0, shapeB, 0, ref xfA, ref xfB);

            Assert.False(overlap);
        }

        /// <summary>
        /// Tests that get point states should mark remove correctly
        /// </summary>
        [Fact]
        public void GetPointStates_ShouldMarkRemoveCorrectly()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 1;
            ManifoldPoint oldPoint = oldManifold.Points[0];
            oldPoint.Id.Key = 11;
            oldManifold.Points[0] = oldPoint;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 1;
            ManifoldPoint newPoint = newManifold.Points[0];
            newPoint.Id.Key = 22;
            newManifold.Points[0] = newPoint;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Remove, state1[0]);
            Assert.Equal(PointState.Add, state2[0]);
        }

        // ========================================================================
        // ADDITIONAL TESTS — Branch coverage for uncovered paths
        // ========================================================================

        #region CollideCircles — Non-intersecting and tangent cases

        /// <summary>
        /// Tests that collide circles should produce zero contacts when non-intersecting
        /// </summary>
        [Fact]
        public void CollideCircles_ShouldProduceZeroContacts_WhenNonIntersecting()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            ControllerTransform xfB = new ControllerTransform(new Vector2F(5.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideCircles(ref manifold, circleA, ref xfA, circleB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide circles should produce single contact when tangent (boundary case)
        /// </summary>
        [Fact]
        public void CollideCircles_ShouldProduceSingleContact_WhenTangent()
        {
            CircleShape circleA = new CircleShape(1.0f, 1.0f);
            CircleShape circleB = new CircleShape(1.0f, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            // Distance = 2.0f = radiusA + radiusB (exactly tangent)
            ControllerTransform xfB = new ControllerTransform(new Vector2F(2.0f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideCircles(ref manifold, circleA, ref xfA, circleB, ref xfB);

            Assert.Equal(1, manifold.PointCount);
            Assert.Equal(ManifoldType.Circles, manifold.Type);
        }

        #endregion

        #region CollidePolygonAndCircle — Early out, barycentric branches

        /// <summary>
        /// Tests that collide polygon and circle should produce zero contacts when circle is outside
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_ShouldProduceZeroContacts_WhenCircleOutsidePolygon()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            // Circle far outside polygon
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(10.0f, 10.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide polygon and circle produces face manifold when circle is nearly at boundary
        /// </summary>
        [Fact]
        public void CollidePolygonAndCircle_ShouldProduceFaceManifold_WhenCircleAtBoundary()
        {
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            ControllerTransform xfPolygon = ControllerTransform.Identity;
            // Position circle at boundary (near epsilon threshold for separation < epsilon)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(0.95f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygonAndCircle(ref manifold, polygon, ref xfPolygon, circle, ref xfCircle);

            Assert.True(manifold.PointCount >= 1);
        }

        #endregion

        #region CollidePolygons — Non-overlapping, FaceB, zero contacts

        /// <summary>
        /// Tests that collide polygons should produce zero contacts when non-overlapping (separationA > totalRadius)
        /// </summary>
        [Fact]
        public void CollidePolygons_ShouldProduceZeroContacts_WhenNonOverlappingA()
        {
            PolygonShape polyA = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            PolygonShape polyB = new PolygonShape(PolygonTools.CreateRectangle(1.0f, 1.0f), 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            // Far apart so separationA > totalRadius
            ControllerTransform xfB = new ControllerTransform(new Vector2F(10.0f, 10.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests that collide polygons should produce FaceB manifold type when B has greater separation
        /// </summary>
        [Fact]
        public void CollidePolygons_ShouldProduceFaceBManifold_WhenPolygonBSeparationDominates()
        {
            // Create two overlapping polygons where B's separation is larger
            Vertices rectA = PolygonTools.CreateRectangle(2.0f, 0.5f);
            Vertices rectB = PolygonTools.CreateRectangle(0.5f, 2.0f);
            PolygonShape polyA = new PolygonShape(rectA, 1.0f);
            PolygonShape polyB = new PolygonShape(rectB, 1.0f);
            ControllerTransform xfA = ControllerTransform.Identity;
            // Offset so B's separation dominates
            ControllerTransform xfB = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollidePolygons(ref manifold, polyA, ref xfA, polyB, ref xfB);

            Assert.True(manifold.PointCount >= 1);
        }

        #endregion

        #region CollideEdgeAndCircle — Region A, B, AB, and edge connectivity

        /// <summary>
        /// Tests that collide edge and circle returns zero contacts when non-intersecting (distance > radius)
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldProduceZeroContacts_WhenNonIntersecting()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Circle far from edge
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 5.0f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests collide edge and circle in region A (v <= 0) near vertex 1 without previous edge
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldProduceContact_InRegionA_NoPreviousEdge()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Isolated edge: HasVertex0 = false, HasVertex3 = false
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position in region A (near vertex 1)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(0.2f, 0.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests collide edge and circle returns early when circle is in previous edge region
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldReturnEarly_WhenCircleInPreviousEdgeRegion()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Connected edge before: HasVertex0 = true with previous vertex
            edge.HasVertex0 = true;
            edge.Vertex0 = new Vector2F(-1.0f, 1.0f);
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position in region A and inside previous edge area (triggers early return)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(-0.3f, 0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            // Should return early with zero contacts (circle in previous edge region)
            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests collide edge and circle in region B (u <= 0) near vertex 2 without next edge
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldProduceContact_InRegionB_NoNextEdge()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Isolated edge
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position in region B (near vertex 2)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.8f, 0.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        /// <summary>
        /// Tests collide edge and circle returns early when circle is in next edge region
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldReturnEarly_WhenCircleInNextEdgeRegion()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Connected edge after: HasVertex3 = true with next vertex
            edge.HasVertex0 = false;
            edge.HasVertex3 = true;
            edge.Vertex3 = new Vector2F(3.0f, 1.0f);
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position in region B and inside next edge area (triggers early return)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(2.3f, 0.3f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            // Should return early with zero contacts (circle in next edge region)
            Assert.Equal(0, manifold.PointCount);
        }

        /// <summary>
        /// Tests collide edge and circle in region AB (face contact) when circle is above the edge segment
        /// </summary>
        [Fact]
        public void CollideEdgeAndCircle_ShouldProduceFaceManifold_InRegionAB()
        {
            EdgeShape edge = new EdgeShape(new Vector2F(0.0f, 0.0f), new Vector2F(2.0f, 0.0f));
            // Isolated edge (no connectivity)
            edge.HasVertex0 = false;
            edge.HasVertex3 = false;
            CircleShape circle = new CircleShape(0.3f, 1.0f);
            ControllerTransform xfEdge = ControllerTransform.Identity;
            // Position in region AB (between vertices, above edge)
            ControllerTransform xfCircle = new ControllerTransform(new Vector2F(1.0f, 0.15f), 0.0f);
            Manifold manifold = new Manifold();

            Collision.CollideEdgeAndCircle(ref manifold, edge, ref xfEdge, circle, ref xfCircle);

            Assert.Equal(1, manifold.PointCount);
        }

        #endregion

        #region GetPointStates — All removes, all adds, mixed multi-point

        /// <summary>
        /// Tests that get point states should mark all removes when no contacts persist
        /// </summary>
        [Fact]
        public void GetPointStates_ShouldMarkAllRemoves_WhenNoContactsPersist()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 2;
            ManifoldPoint oldPoint0 = oldManifold.Points[0];
            oldPoint0.Id.Key = 11;
            oldManifold.Points[0] = oldPoint0;
            ManifoldPoint oldPoint1 = oldManifold.Points[1];
            oldPoint1.Id.Key = 22;
            oldManifold.Points[1] = oldPoint1;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 2;
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 33;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 44;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Remove, state1[0]);
            Assert.Equal(PointState.Remove, state1[1]);
            Assert.Equal(PointState.Add, state2[0]);
            Assert.Equal(PointState.Add, state2[1]);
        }

        /// <summary>
        /// Tests that get point states should mark all adds when no old contacts exist
        /// </summary>
        [Fact]
        public void GetPointStates_ShouldMarkAllAdds_WhenNoOldContacts()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 0;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 2;
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 33;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 44;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Add, state2[0]);
            Assert.Equal(PointState.Add, state2[1]);
        }

        /// <summary>
        /// Tests that get point states handles mixed persist and add with two points
        /// </summary>
        [Fact]
        public void GetPointStates_ShHandleMixedStates_WithTwoPoints()
        {
            Manifold oldManifold = new Manifold();
            oldManifold.PointCount = 2;
            ManifoldPoint oldPoint0 = oldManifold.Points[0];
            oldPoint0.Id.Key = 11;
            oldManifold.Points[0] = oldPoint0;
            ManifoldPoint oldPoint1 = oldManifold.Points[1];
            oldPoint1.Id.Key = 22;
            oldManifold.Points[1] = oldPoint1;

            Manifold newManifold = new Manifold();
            newManifold.PointCount = 2;
            ManifoldPoint newPoint0 = newManifold.Points[0];
            newPoint0.Id.Key = 11;
            newManifold.Points[0] = newPoint0;
            ManifoldPoint newPoint1 = newManifold.Points[1];
            newPoint1.Id.Key = 44;
            newManifold.Points[1] = newPoint1;

            Collision.GetPointStates(out FixedArray2<PointState> state1, out FixedArray2<PointState> state2, ref oldManifold, ref newManifold);

            Assert.Equal(PointState.Persist, state1[0]);
            Assert.Equal(PointState.Remove, state1[1]);
            Assert.Equal(PointState.Persist, state2[0]);
            Assert.Equal(PointState.Add, state2[1]);
        }

        #endregion

        #region TestOverlap — Different shape types

        /// <summary>
        /// Tests that test overlap returns true for overlapping circle and polygon
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnTrue_ForOverlappingCircleAndPolygon()
        {
            CircleShape circle = new CircleShape(1.0f, 1.0f);
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform xfCircle = ControllerTransform.Identity;
            // Overlapping position
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(0.5f, 0.0f), 0.0f);

            bool overlap = Collision.TestOverlap(circle, 0, polygon, 0, ref xfCircle, ref xfPolygon);

            Assert.True(overlap);
        }

        /// <summary>
        /// Tests that test overlap returns false for non-overlapping circle and polygon
        /// </summary>
        [Fact]
        public void TestOverlap_ShouldReturnFalse_ForNonOverlappingCircleAndPolygon()
        {
            CircleShape circle = new CircleShape(0.5f, 1.0f);
            Vertices vertices = PolygonTools.CreateRectangle(2.0f, 2.0f);
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            ControllerTransform xfCircle = ControllerTransform.Identity;
            // Far apart
            ControllerTransform xfPolygon = new ControllerTransform(new Vector2F(10.0f, 10.0f), 0.0f);

            bool overlap = Collision.TestOverlap(circle, 0, polygon, 0, ref xfCircle, ref xfPolygon);

            Assert.False(overlap);
        }

        #endregion
    }
}


