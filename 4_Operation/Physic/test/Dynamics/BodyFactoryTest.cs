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
    /// The body factory test class
    /// </summary>
    public class BodyFactoryTest
    {
        /// <summary>
        /// Tests that create fixture should add fixture to body
        /// </summary>
        [Fact]
        public void CreateFixture_ShouldAddFixtureToBody()
        {
            Body body = new Body();
            CircleShape shape = new CircleShape(1f, 1f);

            Fixture fixture = body.CreateFixture(shape);

            Assert.NotNull(fixture);
            Assert.Single(body.FixtureList);
            Assert.Same(fixture, body.FixtureList[0]);
        }

        /// <summary>
        /// Tests that create edge should create edge shape fixture
        /// </summary>
        [Fact]
        public void CreateEdge_ShouldCreateEdgeShapeFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateEdge(new Vector2F(0, 0), new Vector2F(5, 5));

            Assert.NotNull(fixture);
            Assert.IsType<EdgeShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create chain shape should create chain shape fixture
        /// </summary>
        [Fact]
        public void CreateChainShape_ShouldCreateChainShapeFixture()
        {
            Body body = new Body();
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(5, 5), new Vector2F(10, 0) };

            Fixture fixture = body.CreateChainShape(vertices);

            Assert.NotNull(fixture);
            Assert.IsType<ChainShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create loop shape should create loop shape fixture
        /// </summary>
        [Fact]
        public void CreateLoopShape_ShouldCreateLoopShapeFixture()
        {
            Body body = new Body();
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(5, 5), new Vector2F(10, 0) };

            Fixture fixture = body.CreateLoopShape(vertices);

            Assert.NotNull(fixture);
            Assert.IsType<ChainShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create rectangle should create polygon shape fixture
        /// </summary>
        [Fact]
        public void CreateRectangle_ShouldCreatePolygonShapeFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateRectangle(4, 6, 1f, Vector2F.Zero);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create circle should create circle shape fixture
        /// </summary>
        [Fact]
        public void CreateCircle_ShouldCreateCircleShapeFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateCircle(1f, 1f);

            Assert.NotNull(fixture);
            Assert.IsType<CircleShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create circle with zero radius should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreateCircle_WithZeroRadius_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(0f, 1f));
        }

        /// <summary>
        /// Tests that create circle with negative radius should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreateCircle_WithNegativeRadius_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(-1f, 1f));
        }

        /// <summary>
        /// Tests that create circle with offset should create circle shape at offset
        /// </summary>
        [Fact]
        public void CreateCircle_WithOffset_ShouldCreateCircleShapeAtOffset()
        {
            Body body = new Body();

            Fixture fixture = body.CreateCircle(1f, 1f, new Vector2F(3, 4));

            Assert.NotNull(fixture);
            Assert.IsType<CircleShape>(fixture.GetShape);
            CircleShape circle = (CircleShape)fixture.GetShape;
            Assert.Equal(3, circle.Position.X);
            Assert.Equal(4, circle.Position.Y);
        }

        /// <summary>
        /// Tests that create polygon should create polygon shape fixture
        /// </summary>
        [Fact]
        public void CreatePolygon_ShouldCreatePolygonShapeFixture()
        {
            Body body = new Body();
            Vertices vertices = new Vertices { new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 5), new Vector2F(0, 5) };

            Fixture fixture = body.CreatePolygon(vertices, 1f);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create polygon with single vertex should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreatePolygon_WithSingleVertex_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();
            Vertices vertices = new Vertices { new Vector2F(0, 0) };

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreatePolygon(vertices, 1f));
        }

        /// <summary>
        /// Tests that create polygon with no vertices should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreatePolygon_WithNoVertices_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();
            Vertices vertices = new Vertices();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreatePolygon(vertices, 1f));
        }

        /// <summary>
        /// Tests that create ellipse should create polygon shape fixture
        /// </summary>
        [Fact]
        public void CreateEllipse_ShouldCreatePolygonShapeFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateEllipse(2f, 1f, 16, 1f);

            Assert.NotNull(fixture);
            Assert.IsType<PolygonShape>(fixture.GetShape);
        }

        /// <summary>
        /// Tests that create ellipse with zero x radius should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreateEllipse_WithZeroXRadius_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateEllipse(0f, 1f, 16, 1f));
        }

        /// <summary>
        /// Tests that create ellipse with zero y radius should throw argument out of range exception
        /// </summary>
        [Fact]
        public void CreateEllipse_WithZeroYRadius_ShouldThrowArgumentOutOfRangeException()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateEllipse(1f, 0f, 16, 1f));
        }

        /// <summary>
        /// Tests that create compound polygon should create fixtures for each vertex list
        /// </summary>
        [Fact]
        public void CreateCompoundPolygon_ShouldCreateFixturesForEachVertexList()
        {
            Body body = new Body();
            List<Vertices> list = new List<Vertices>
            {
                new Vertices { new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(5, 5), new Vector2F(0, 5) },
                new Vertices { new Vector2F(10, 0), new Vector2F(15, 0), new Vector2F(15, 5), new Vector2F(10, 5) }
            };

            List<Fixture> fixtures = body.CreateCompoundPolygon(list, 1f);

            Assert.Equal(2, fixtures.Count);
            Assert.Equal(2, body.FixtureList.Count);
        }

        /// <summary>
        /// Tests that create line arc should create fixture
        /// </summary>
        [Fact]
        public void CreateLineArc_ShouldCreateFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateLineArc(Constant.Pi, 8, 5f, false);

            Assert.NotNull(fixture);
        }

        /// <summary>
        /// Tests that create line arc closed should create fixture
        /// </summary>
        [Fact]
        public void CreateLineArc_Closed_ShouldCreateFixture()
        {
            Body body = new Body();

            Fixture fixture = body.CreateLineArc(Constant.Pi, 8, 5f, true);

            Assert.NotNull(fixture);
        }

        /// <summary>
        /// Tests that create solid arc should create fixture list
        /// </summary>
        [Fact]
        public void CreateSolidArc_ShouldCreateFixtureList()
        {
            Body body = new Body();

            List<Fixture> fixtures = body.CreateSolidArc(1f, Constant.Pi, 8, 5f);

            Assert.NotEmpty(fixtures);
        }
    }
}
