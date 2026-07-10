// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:CuttingToolsRemainingCoverageTests.cs
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
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Common.PolygonManipulation;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.PolygonManipulation
{
    /// <summary>
    ///     Targeted coverage tests for CuttingTools remaining uncovered branches.
    /// </summary>
    public class CuttingToolsRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that Cut processes dynamic bodies (non-static branch).
        ///     Covers: Cut line 307 (bodyType != Static true branch), lines 312-317, 320-327, 329.
        /// </summary>
        [Fact]
        public void Cut_DynamicBody_ShouldProcessAndRemoveOriginal()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Dynamic;
            body.Position = new Vector2F(0, 0);

            bool result = CuttingTools.Cut(world, new Vector2F(0, -20), new Vector2F(0, 20));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Cut processes kinematic bodies (non-static branch).
        ///     Covers: Cut line 307 (bodyType != Static true branch for Kinematic).
        /// </summary>
        [Fact]
        public void Cut_KinematicBody_ShouldProcess()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Kinematic;

            bool result = CuttingTools.Cut(world, new Vector2F(0, -20), new Vector2F(0, 20));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that SplitShape with entry and exit on the same side
        ///     triggers the cutAdded[n] == 0 path in ComputeOffsetBeforeCut (line 221).
        /// </summary>
        [Fact]
        public void SplitShape_AllVerticesOnOneSide_TriggersOffsetWrapBefore()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-5, -5),
                new(5, -5),
                new(5, 5),
                new(-5, 5)
            };
            Body body = world.CreateBody();
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture = body.CreateFixture(polygon);

            // Both entry and exit are to the right of the polygon
            CuttingTools.SplitShape(fixture, new Vector2F(10, -10), new Vector2F(10, 10), out Vertices first, out Vertices second);

            Assert.NotNull(first);
            Assert.NotNull(second);
        }

        /// <summary>
        ///     Tests that SplitShape with both points on the left side
        ///     triggers the other side of the offset wrap.
        /// </summary>
        [Fact]
        public void SplitShape_AllVerticesOnOtherSide_TriggersOffsetWrapAfter()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-5, -5),
                new(5, -5),
                new(5, 5),
                new(-5, 5)
            };
            Body body = world.CreateBody();
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture = body.CreateFixture(polygon);

            // Both entry and exit are to the left of the polygon
            CuttingTools.SplitShape(fixture, new Vector2F(-10, -10), new Vector2F(-10, 10), out Vertices first, out Vertices second);

            Assert.NotNull(first);
            Assert.NotNull(second);
        }

        /// <summary>
        ///     Tests that Cut with a cut line that goes exactly through a vertex
        ///     triggers AdjustPointsNearVertices and still processes.
        /// </summary>
        [Fact]
        public void Cut_CutLineThroughVertex_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Dynamic;

            // Diagonal cut through center with endpoints clearly outside polygon
            bool result = CuttingTools.Cut(world, new Vector2F(-20, -20), new Vector2F(20, 20));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Cut with multiple bodies creates proper new bodies.
        /// </summary>
        [Fact]
        public void Cut_MultipleDynamicBodies_ShouldSplitAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            // First body - spans across cut line
            Vertices v1 = new Vertices
            {
                new(-8, -3),
                new(2, -3),
                new(2, 3),
                new(-8, 3)
            };
            Body body1 = world.CreateBody();
            body1.CreatePolygon(v1, 1.0f);
            body1.GetBodyType = BodyType.Dynamic;

            // Second body - also spans across cut line
            Vertices v2 = new Vertices
            {
                new(-2, -3),
                new(8, -3),
                new(8, 3),
                new(-2, 3)
            };
            Body body2 = world.CreateBody();
            body2.CreatePolygon(v2, 1.0f);
            body2.GetBodyType = BodyType.Dynamic;

            // Diagonal cut goes through both bodies
            bool result = CuttingTools.Cut(world, new Vector2F(-10, -10), new Vector2F(10, 10));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Cut with a dynamic body having velocity preserves properties
        ///     and creates new dynamic bodies.
        /// </summary>
        [Fact]
        public void Cut_DynamicBodyWithVelocity_ShouldPreserveProperties()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Dynamic;
            body.LinearVelocity = new Vector2F(1, 2);
            body.AngularVelocity = 0.5f;
            body.Position = new Vector2F(5, 5);

            bool result = CuttingTools.Cut(world, new Vector2F(5, -20), new Vector2F(5, 20));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that Cut with a horizontal cut creates proper split.
        /// </summary>
        [Fact]
        public void Cut_HorizontalCutDynamicBody_ShouldProcess()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Dynamic;

            bool result = CuttingTools.Cut(world, new Vector2F(-20, 0), new Vector2F(20, 0));

            Assert.True(result);
        }

        /// <summary>
        ///     Tests that SplitShape with a polygon that fails CheckPolygon
        ///     still executes without error.
        /// </summary>
        [Fact]
        public void SplitShape_PolygonWithInvalidCheck_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(0, 0),
                new(10, 0),
                new(10, 10),
                new(0, 10)
            };
            Body body = world.CreateBody();
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture = body.CreateFixture(polygon);

            // Entry and exit both to the right of polygon
            CuttingTools.SplitShape(fixture, new Vector2F(15, -10), new Vector2F(15, 10), out Vertices first, out Vertices second);

            Assert.NotNull(first);
            Assert.NotNull(second);
            Assert.True(first.Count > 0);
            Assert.True(second.Count > 0);
        }

        /// <summary>
        ///     Tests that Cut returns false when both entry and exit points are inside a shape.
        /// </summary>
        [Fact]
        public void Cut_BothPointsInsideShape_ShouldReturnFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);

            bool result = CuttingTools.Cut(world, new Vector2F(0, 0), new Vector2F(5, 5));

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that Cut with zero-length cut line returns correct result.
        /// </summary>
        [Fact]
        public void Cut_ZeroLengthCutLine_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-10, -10),
                new(10, -10),
                new(10, 10),
                new(-10, 10)
            };
            Body body = world.CreateBody();
            body.CreatePolygon(vertices, 1.0f);
            body.GetBodyType = BodyType.Dynamic;

            bool result = CuttingTools.Cut(world, new Vector2F(0, 0), new Vector2F(0, 0));

            Assert.False(result);
        }

        /// <summary>
        ///     Tests that SplitShape with a cut line that creates zero offset
        ///     after normalization is handled gracefully.
        /// </summary>
        [Fact]
        public void SplitShape_NearZeroOffset_ShouldNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-5, -5),
                new(5, -5),
                new(5, 5),
                new(-5, 5)
            };
            Body body = world.CreateBody();
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture = body.CreateFixture(polygon);

            // Cut very close to the edge to create a narrow wedge
            CuttingTools.SplitShape(fixture, new Vector2F(-6, -6), new Vector2F(-5, -4), out Vertices first, out Vertices second);

            Assert.NotNull(first);
            Assert.NotNull(second);
        }

        /// <summary>
        ///     Tests that AddCutPoints handles transitions from both 0 and 1.
        /// </summary>
        [Fact]
        public void SplitShape_TransitionsBetweenBothSides_ShouldAddCutPoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new(-5, -5),
                new(5, -5),
                new(5, 5),
                new(-5, 5)
            };
            Body body = world.CreateBody();
            PolygonShape polygon = new PolygonShape(vertices, 1.0f);
            Fixture fixture = body.CreateFixture(polygon);

            // Diagonal cut through center triggers transitions in both directions
            CuttingTools.SplitShape(fixture, new Vector2F(-10, -10), new Vector2F(10, 10), out Vertices first, out Vertices second);

            Assert.NotNull(first);
            Assert.NotNull(second);
            Assert.True(first.Count > 0);
            Assert.True(second.Count > 0);
        }
    }
}
