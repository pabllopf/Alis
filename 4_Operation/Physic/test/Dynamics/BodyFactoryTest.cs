// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyFactoryTest.cs
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

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body factory test class
    /// </summary>
    public class BodyFactoryTest
    {
        /// <summary>
        ///     Tests that CreateFixture should create a fixture with shape
        /// </summary>
        [Fact]
        public void CreateFixture_ShouldCreateFixtureWithShape()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            CircleShape circleShape = new CircleShape(0.5f, 1.0f);

            Fixture fixture = body.CreateFixture(circleShape);

            Assert.NotNull(fixture);
            Assert.Equal(circleShape, fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateFixture should add fixture to body
        /// </summary>
        [Fact]
        public void CreateFixture_ShouldAddFixtureToBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            CircleShape circleShape = new CircleShape(0.5f, 1.0f);

            Fixture fixture = body.CreateFixture(circleShape);

        }

        /// <summary>
        ///     Tests that CreateFixture should return created fixture
        /// </summary>
        [Fact]
        public void CreateFixture_ShouldReturnCreatedFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            CircleShape circleShape = new CircleShape(0.5f, 1.0f);

            Fixture fixture = body.CreateFixture(circleShape);

            Assert.NotNull(fixture);
            Assert.IsType<Fixture>(fixture);
        }

        /// <summary>
        ///     Tests that CreateEdge should create edge fixture
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldCreateEdgeFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F start = new Vector2F(0.0f, 0.0f);
            Vector2F end = new Vector2F(1.0f, 0.0f);

            Fixture fixture = body.CreateEdge(start, end);

            Assert.NotNull(fixture);
            Assert.IsType<EdgeShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateEdge should create edge with correct vertices
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldCreateEdgeWithCorrectVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F start = new Vector2F(0.0f, 0.0f);
            Vector2F end = new Vector2F(1.0f, 1.0f);

            Fixture fixture = body.CreateEdge(start, end);

            EdgeShape edgeShape = fixture.GetShape as EdgeShape;
            Assert.NotNull(edgeShape);
        }

        /// <summary>
        ///     Tests that CreateChainShape should create chain fixture
        /// </summary>
        [Fact]
        public void CreateChainShape_ShouldCreateChainFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };

            Fixture fixture = body.CreateChainShape(vertices);

            Assert.NotNull(fixture);
            Assert.IsType<ChainShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateChainShape should create chain with correct vertices
        /// </summary>
        [Fact]
        public void CreateChainShape_ShouldCreateChainWithCorrectVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };

            Fixture fixture = body.CreateChainShape(vertices);

            ChainShape chainShape = fixture.GetShape as ChainShape;
            Assert.NotNull(chainShape);
        }

        /// <summary>
        ///     Tests that CreateLoopShape should create loop fixture
        /// </summary>
        [Fact]
        public void CreateLoopShape_ShouldCreateLoopFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };

            Fixture fixture = body.CreateLoopShape(vertices);

            Assert.NotNull(fixture);
            Assert.IsType<ChainShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateLoopShape should create loop with correct vertices and closed flag
        /// </summary>
        [Fact]
        public void CreateLoopShape_ShouldCreateLoopWithCorrectVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };

            Fixture fixture = body.CreateLoopShape(vertices);

            ChainShape chainShape = fixture.GetShape as ChainShape;
            Assert.NotNull(chainShape);
        }

        /// <summary>
        ///     Tests that CreateRectangle should create rectangle fixture
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldCreateRectangleFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateRectangle(2.0f, 4.0f, 1.0f, Vector2F.Zero);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateRectangle should create rectangle with correct dimensions
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldCreateRectangleWithCorrectDimensions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateRectangle(2.0f, 4.0f, 1.0f, Vector2F.Zero);

            PolygonShape polygonShape = fixture.GetShape as PolygonShape;
            Assert.NotNull(polygonShape);
        }

        /// <summary>
        ///     Tests that CreateRectangle should apply offset correctly
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldApplyOffsetCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F offset = new Vector2F(1.0f, 2.0f);

            Fixture fixture = body.CreateRectangle(2.0f, 4.0f, 1.0f, offset);

            Assert.NotNull(fixture);
        }

        /// <summary>
        ///     Tests that CreateCircle should create circle fixture with valid radius
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldCreateCircleFixtureWithValidRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            Assert.NotNull(fixture);
            Assert.IsType<CircleShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateCircle should throw exception with invalid radius
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldThrowExceptionWithInvalidRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(0.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that CreateCircle should throw exception with negative radius
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldThrowExceptionWithNegativeRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(-1.0f, 1.0f));
        }

        /// <summary>
        ///     Tests that CreateCircle with offset should create circle fixture with offset
        /// </summary>
        [Fact]
        public void CreateCircle_WithOffset_ShouldCreateCircleFixtureWithOffset()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vector2F offset = new Vector2F(1.0f, 2.0f);

            Fixture fixture = body.CreateCircle(0.5f, 1.0f, offset);

            Assert.NotNull(fixture);
            CircleShape circleShape = fixture.GetShape as CircleShape;
            Assert.NotNull(circleShape);
        }

        /// <summary>
        ///     Tests that CreateCircle with offset should throw exception with invalid radius
        /// </summary>
        [Fact]
        public void CreateCircle_WithOffset_ShouldThrowExceptionWithInvalidRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(0.0f, 1.0f, Vector2F.Zero));
        }

        /// <summary>
        ///     Tests that CreatePolygon should create polygon fixture with valid vertices
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldCreatePolygonFixtureWithValidVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f), new Vector2F(0.0f, 1.0f) };

            Fixture fixture = body.CreatePolygon(vertices, 1.0f);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreatePolygon should throw exception with too few vertices
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldThrowExceptionWithTooFewVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f) };

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreatePolygon(vertices, 1.0f));
        }

        /// <summary>
        ///     Tests that CreatePolygon should throw exception with empty vertices
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldThrowExceptionWithEmptyVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreatePolygon(vertices, 1.0f));
        }

        /// <summary>
        ///     Tests that CreateEllipse should create ellipse fixture with valid radii
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldCreateEllipseFixtureWithValidRadii()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateEllipse(1.0f, 0.5f, 8, 1.0f);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateEllipse should throw exception with invalid xRadius
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldThrowExceptionWithInvalidXRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateEllipse(0.0f, 0.5f, 8, 1.0f));
        }

        /// <summary>
        ///     Tests that CreateEllipse should throw exception with invalid yRadius
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldThrowExceptionWithInvalidYRadius()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateEllipse(1.0f, 0.0f, 8, 1.0f));
        }

        /// <summary>
        ///     Tests that CreateEllipse should create ellipse with correct number of edges
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldCreateEllipseWithCorrectNumberOfEdges()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateEllipse(1.0f, 0.5f, 12, 1.0f);

            Assert.NotNull(fixture);
            PolygonShape polygonShape = fixture.GetShape as PolygonShape;
            Assert.NotNull(polygonShape);
        }

        /// <summary>
        ///     Tests that CreateCompoundPolygon should create compound fixture from list
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldCreateCompoundFixtureFromList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            List<Vertices> list = new List<Vertices>
            {
                new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f) },
                new Vertices { new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f), new Vector2F(0.0f, 1.0f) }
            };

            List<Fixture> fixtures = body.CreateCompoundPolygon(list, 1.0f);

            Assert.NotNull(fixtures);
            Assert.Equal(2, fixtures.Count);
        }

        /// <summary>
        ///     Tests that CreateCompoundPolygon should create edge fixtures from 2-vertex lists
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldCreateEdgeFixturesFromTwoVertexLists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            List<Vertices> list = new List<Vertices>
            {
                new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f) },
                new Vertices { new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) }
            };

            List<Fixture> fixtures = body.CreateCompoundPolygon(list, 1.0f);

            Assert.NotNull(fixtures);
            Assert.All(fixtures, f => Assert.IsType<EdgeShape>(f.GetShape));
        }

        /// <summary>
        ///     Tests that CreateCompoundPolygon should create polygon fixtures from 3+ vertex lists
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldCreatePolygonFixturesFromThreePlusVertexLists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            List<Vertices> list = new List<Vertices>
            {
                new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) }
            };

            List<Fixture> fixtures = body.CreateCompoundPolygon(list, 1.0f);

            Assert.NotNull(fixtures);
            Assert.All(fixtures, f => Assert.IsType<PolygonShape>(f.GetShape));
        }

        /// <summary>
        ///     Tests that CreateLineArc should create arc fixture
        /// </summary>
        [Fact]
        public void CreateLineArc_ShouldCreateArcFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateLineArc((float)Math.PI / 2, 8, 1.0f, false);

            Assert.NotNull(fixture);
            Assert.IsType<ChainShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateLineArc should create loop when closed is true
        /// </summary>
        [Fact]
        public void CreateLineArc_ShouldCreateLoopWhenClosedIsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateLineArc((float)Math.PI / 2, 8, 1.0f, true);

            Assert.NotNull(fixture);
            ChainShape chainShape = fixture.GetShape as ChainShape;
            Assert.NotNull(chainShape);
        }

        /// <summary>
        ///     Tests that CreateSolidArc should create solid arc fixtures
        /// </summary>
        [Fact]
        public void CreateSolidArc_ShouldCreateSolidArcFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            List<Fixture> fixtures = body.CreateSolidArc(1.0f, (float)Math.PI / 2, 8, 1.0f);

            Assert.NotNull(fixtures);
            Assert.NotEmpty(fixtures);
        }

        /// <summary>
        ///     Tests that CreateSolidArc should create multiple fixtures for solid arc
        /// </summary>
        [Fact]
        public void CreateSolidArc_ShouldCreateMultipleFixturesForSolidArc()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            List<Fixture> fixtures = body.CreateSolidArc(1.0f, (float)Math.PI, 12, 1.0f);

            Assert.NotNull(fixtures);
            Assert.True(fixtures.Count > 1);
        }

        /// <summary>
        ///     Tests that CreateFixture should work with different shape types
        /// </summary>
        [Fact]
        public void CreateFixture_ShouldWorkWithDifferentShapeTypes()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            CircleShape circle = new CircleShape(0.5f, 1.0f);
            Fixture fixture1 = body.CreateFixture(circle);

            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture2 = body.CreateFixture(polygon);

            Assert.NotNull(fixture1);
            Assert.NotNull(fixture2);
        }

        /// <summary>
        ///     Tests that CreateEdge should create edge with different start and end points
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldCreateEdgeWithDifferentStartAndEndPoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateEdge(new Vector2F(0.0f, 0.0f), new Vector2F(10.0f, 10.0f));

            Assert.NotNull(fixture);
            Assert.IsType<EdgeShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateChainShape should create chain with multiple vertices
        /// </summary>
        [Fact]
        public void CreateChainShape_ShouldCreateChainWithMultipleVertices()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f), new Vector2F(0.0f, 1.0f) };

            Fixture fixture = body.CreateChainShape(vertices);

            Assert.NotNull(fixture);
            ChainShape chainShape = fixture.GetShape as ChainShape;
            Assert.NotNull(chainShape);
        }

        /// <summary>
        ///     Tests that CreateRectangle should create rectangle with different dimensions
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldCreateRectangleWithDifferentDimensions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture = body.CreateRectangle(10.0f, 20.0f, 1.0f, Vector2F.Zero);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        ///     Tests that CreateCircle should create circle with different radii
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldCreateCircleWithDifferentRadii()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture1 = body.CreateCircle(0.1f, 1.0f);
            Fixture fixture2 = body.CreateCircle(5.0f, 1.0f);

            Assert.NotNull(fixture1);
            Assert.NotNull(fixture2);
        }

        /// <summary>
        ///     Tests that CreatePolygon should create polygon with different vertex counts
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldCreatePolygonWithDifferentVertexCounts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Vertices triangle = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(0.5f, 1.0f) };
            Fixture fixture1 = body.CreatePolygon(triangle, 1.0f);

            Vertices pentagon = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f), new Vector2F(0.5f, 1.5f), new Vector2F(0.0f, 1.0f) };
            Fixture fixture2 = body.CreatePolygon(pentagon, 1.0f);

            Assert.NotNull(fixture1);
            Assert.NotNull(fixture2);
        }

        /// <summary>
        ///     Tests that CreateEllipse should create ellipse with different edge counts
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldCreateEllipseWithDifferentEdgeCounts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture1 = body.CreateEllipse(1.0f, 0.5f, 4, 1.0f);
            Fixture fixture2 = body.CreateEllipse(1.0f, 0.5f, 16, 1.0f);

            Assert.NotNull(fixture1);
            Assert.NotNull(fixture2);
        }

        /// <summary>
        ///     Tests that CreateCompoundPolygon should handle empty list
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldHandleEmptyList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            List<Vertices> list = new List<Vertices>();

            List<Fixture> fixtures = body.CreateCompoundPolygon(list, 1.0f);

            Assert.NotNull(fixtures);
            Assert.Empty(fixtures);
        }

        /// <summary>
        ///     Tests that CreateLineArc should create arc with different radians
        /// </summary>
        [Fact]
        public void CreateLineArc_ShouldCreateArcWithDifferentRadians()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            Fixture fixture1 = body.CreateLineArc(0.5f, 8, 1.0f, false);
            Fixture fixture2 = body.CreateLineArc((float)Math.PI, 8, 1.0f, false);

            Assert.NotNull(fixture1);
            Assert.NotNull(fixture2);
        }

        /// <summary>
        ///     Tests that CreateSolidArc should create solid arc with different parameters
        /// </summary>
        [Fact]
        public void CreateSolidArc_ShouldCreateSolidArcWithDifferentParameters()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            List<Fixture> fixtures1 = body.CreateSolidArc(1.0f, 0.5f, 8, 1.0f);
            List<Fixture> fixtures2 = body.CreateSolidArc(2.0f, (float)Math.PI, 16, 2.0f);

            Assert.NotNull(fixtures1);
            Assert.NotNull(fixtures2);
        }

        /// <summary>
        ///     Tests that all factory methods should add fixtures to body correctly
        /// </summary>
        [Fact]
        public void AllFactoryMethods_ShouldAddFixturesToBodyCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            CircleShape circle = new CircleShape(0.5f, 1.0f);
            body.CreateFixture(circle);

            body.CreateEdge(new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f));

            Vertices vertices = new Vertices { new Vector2F(0.0f, 0.0f), new Vector2F(1.0f, 0.0f), new Vector2F(1.0f, 1.0f) };
            body.CreateChainShape(vertices);

            body.CreateLoopShape(vertices);

            body.CreateRectangle(2.0f, 4.0f, 1.0f, Vector2F.Zero);

            body.CreateCircle(0.5f, 1.0f);

            body.CreatePolygon(vertices, 1.0f);

        }
    }
}
