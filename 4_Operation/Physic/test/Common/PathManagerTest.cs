// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PathManagerTest.cs
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
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Common
{
    /// <summary>
    ///     The path manager test class
    /// </summary>
    public class PathManagerTest
    {
        /// <summary>
        ///     Tests that convert path to edges should create edges for open path
        /// </summary>
        [Fact]
        public void ConvertPathToEdges_ShouldCreateEdges_ForOpenPath()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(10, 0)})
                {
                    Closed = false
                };

            PathManager.ConvertPathToEdges(path, body, 2);

            Assert.True(body.FixtureList.Count > 0);
        }

        /// <summary>
        ///     Tests that convert path to edges should create chain for closed path
        /// </summary>
        [Fact]
        public void ConvertPathToEdges_ShouldCreateChain_ForClosedPath()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            Path path = new Path(new[]
            {
                new Vector2F(0, 0),
                new Vector2F(5, 0),
                new Vector2F(5, 5),
                new Vector2F(0, 5)
            })
            {
                Closed = true
            };

            PathManager.ConvertPathToEdges(path, body, 2);

            Assert.True(body.FixtureList.Count > 0);
        }

        /// <summary>
        ///     Tests that convert path to polygon should create polygon fixtures
        /// </summary>
        [Fact]
        public void ConvertPathToPolygon_ShouldCreatePolygonFixtures()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            Path path = new Path(new[]
            {
                new Vector2F(0, 0),
                new Vector2F(2, 0),
                new Vector2F(2, 2),
                new Vector2F(0, 2)
            })
            {
                Closed = true
            };

            PathManager.ConvertPathToPolygon(path, body, 1.0f, 4);

            Assert.True(body.FixtureList.Count > 0);
        }

        /// <summary>
        ///     Tests that convert path to polygon should throw exception for open path
        /// </summary>
        [Fact]
        public void ConvertPathToPolygon_ShouldThrowException_ForOpenPath()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(5, 0)})
                {
                    Closed = false
                };

            Assert.Throws<InvalidOperationException>(() => PathManager.ConvertPathToPolygon(path, body, 1.0f, 2));
        }

        /// <summary>
        ///     Tests that evenly distribute shapes should create bodies along path
        /// </summary>
        [Fact]
        public void EvenlyDistributeShapes_ShouldCreateBodiesAlongPath()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Path path = new Path(new[]
            {
                new Vector2F(0, 0),
                new Vector2F(10, 0),
                new Vector2F(20, 0)
            });
            List<Shape> shapes = new List<Shape> {new CircleShape(1.0f, 1.0f)};

            List<Body> bodies = PathManager.EvenlyDistributeShapesAlongPath(world, path, shapes, BodyType.Dynamic, 5);

            Assert.NotNull(bodies);
            Assert.NotEmpty(bodies);
        }

        /// <summary>
        ///     Tests that evenly distribute shapes should set user data
        /// </summary>
        [Fact]
        public void EvenlyDistributeShapes_ShouldSetUserData()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(10, 0)});
            List<Shape> shapes = new List<Shape> {new CircleShape(1.0f, 1.0f)};
            object userData = new object();

            List<Body> bodies = PathManager.EvenlyDistributeShapesAlongPath(world, path, shapes, BodyType.Dynamic, 2, userData);

            Assert.All(bodies, b => Assert.Equal(userData, b.Tag));
        }

        /// <summary>
        ///     Tests that link type revolute should be defined
        /// </summary>
        [Fact]
        public void LinkTypeRevolute_ShouldBeDefined()
        {
            PathManager.LinkType linkType = PathManager.LinkType.Revolute;

            Assert.Equal(PathManager.LinkType.Revolute, linkType);
        }

        /// <summary>
        ///     Tests that link type slider should be defined
        /// </summary>
        [Fact]
        public void LinkTypeSlider_ShouldBeDefined()
        {
            PathManager.LinkType linkType = PathManager.LinkType.Slider;

            Assert.Equal(PathManager.LinkType.Slider, linkType);
        }

        /// <summary>
        ///     Tests that evenly distribute shapes should handle multiple shapes
        /// </summary>
        [Fact]
        public void EvenlyDistributeShapes_ShouldHandleMultipleShapes()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(20, 0)});
            List<Shape> shapes = new List<Shape>
            {
                new CircleShape(1.0f, 1.0f),
                new CircleShape(0.5f, 1.0f)
            };

            List<Body> bodies = PathManager.EvenlyDistributeShapesAlongPath(world, path, shapes, BodyType.Dynamic, 3);

            Assert.NotEmpty(bodies);
            Assert.All(bodies, b => Assert.Equal(2, b.FixtureList.Count));
        }

        /// <summary>
        ///     Tests that MoveBodyOnPath sets linear velocity on the body when body is away from path
        /// </summary>
        [Fact]
        public void MoveBodyOnPath_ShouldSetLinearVelocity()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            body.GetBodyType = BodyType.Dynamic;
            body.Position = new Vector2F(100f, 100f);
            Path path = new Path(new[] {new Vector2F(0f, 0f), new Vector2F(10f, 0f)});

            PathManager.MoveBodyOnPath(path, body, 0.5f, 1.0f, 1.0f / 60.0f);

            Assert.NotEqual(Vector2F.Zero, body.LinearVelocity);
        }

        /// <summary>
        ///     Tests that MoveBodyOnPath produces different velocities at different body positions
        /// </summary>
        [Fact]
        public void MoveBodyOnPath_DifferentBodyPositions_ChangesVelocity()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body1 = world.CreateBody();
            body1.GetBodyType = BodyType.Dynamic;
            body1.Position = new Vector2F(0f, 0f);
            Body body2 = world.CreateBody();
            body2.GetBodyType = BodyType.Dynamic;
            body2.Position = new Vector2F(20f, 20f);

            Path path = new Path(new[] {new Vector2F(0f, 0f), new Vector2F(10f, 0f)});

            PathManager.MoveBodyOnPath(path, body1, 0.5f, 1.0f, 1.0f / 60.0f);
            PathManager.MoveBodyOnPath(path, body2, 0.5f, 1.0f, 1.0f / 60.0f);

            Assert.NotEqual(body1.LinearVelocity, body2.LinearVelocity);
        }

        /// <summary>
        ///     Tests that MoveBodyOnPath uses strength to scale the velocity
        /// </summary>
        [Fact]
        public void MoveBodyOnPath_StrongerStrength_IncreasesVelocity()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body1 = world.CreateBody();
            body1.GetBodyType = BodyType.Dynamic;
            body1.Position = new Vector2F(100f, 0f);
            Body body2 = world.CreateBody();
            body2.GetBodyType = BodyType.Dynamic;
            body2.Position = new Vector2F(100f, 0f);

            Path path = new Path(new[] {new Vector2F(0f, 0f), new Vector2F(10f, 0f)});

            PathManager.MoveBodyOnPath(path, body1, 0f, 1.0f, 1.0f / 60.0f);
            PathManager.MoveBodyOnPath(path, body2, 0f, 2.0f, 1.0f / 60.0f);

            float len1 = body1.LinearVelocity.Length();
            float len2 = body2.LinearVelocity.Length();
            Assert.True(len1 > 0f);
            Assert.True(len2 > len1);
        }

        /// <summary>
        ///     Tests that EvenlyDistributeShapesAlongPath single-shape overload creates bodies along path
        /// </summary>
        [Fact]
        public void EvenlyDistributeShapes_SingleShapeOverload_CreatesBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Path path = new Path(new[] {new Vector2F(0f, 0f), new Vector2F(10f, 0f)});
            Shape shape = new CircleShape(1.0f, 1.0f);

            List<Body> bodies = PathManager.EvenlyDistributeShapesAlongPath(world, path, shape, BodyType.Dynamic, 3);

            Assert.NotNull(bodies);
            Assert.NotEmpty(bodies);
        }

        /// <summary>
        ///     Tests that EvenlyDistributeShapesAlongPath single-shape overload sets user data
        /// </summary>
        [Fact]
        public void EvenlyDistributeShapes_SingleShapeOverload_SetsUserData()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Path path = new Path(new[] {new Vector2F(0f, 0f), new Vector2F(10f, 0f)});
            Shape shape = new CircleShape(1.0f, 1.0f);
            object userData = new object();

            List<Body> bodies = PathManager.EvenlyDistributeShapesAlongPath(world, path, shape, BodyType.Dynamic, 2, userData);

            Assert.All(bodies, b => Assert.Equal(userData, b.Tag));
        }

        /// <summary>
        ///     Tests that AttachBodiesWithRevoluteJoint creates joints between consecutive bodies
        /// </summary>
        [Fact]
        public void AttachBodiesWithRevoluteJoint_ShouldCreateJoints()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            List<Body> bodies = new List<Body>();
            for (int i = 0; i < 3; i++)
            {
                Body body = world.CreateBody();
                body.Position = new Vector2F(i * 2f, 0f);
                bodies.Add(body);
            }

            List<RevoluteJoint> joints = PathManager.AttachBodiesWithRevoluteJoint(
                world, bodies, new Vector2F(0f, 0f), new Vector2F(0f, 0f), false, false);

            Assert.NotNull(joints);
            Assert.Equal(2, joints.Count);
            Assert.All(joints, j => Assert.False(j.CollideConnected));
        }

        /// <summary>
        ///     Tests that AttachBodiesWithRevoluteJoint with connectFirstAndLast creates an extra joint
        /// </summary>
        [Fact]
        public void AttachBodiesWithRevoluteJoint_ConnectFirstAndLast_CreatesExtraJoint()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            List<Body> bodies = new List<Body>();
            for (int i = 0; i < 3; i++)
            {
                Body body = world.CreateBody();
                body.Position = new Vector2F(i * 2f, 0f);
                bodies.Add(body);
            }

            List<RevoluteJoint> joints = PathManager.AttachBodiesWithRevoluteJoint(
                world, bodies, new Vector2F(0f, 0f), new Vector2F(0f, 0f), true, false);

            Assert.NotNull(joints);
            Assert.Equal(3, joints.Count);
        }

        /// <summary>
        ///     Tests that AttachBodiesWithRevoluteJoint sets CollideConnected property
        /// </summary>
        [Fact]
        public void AttachBodiesWithRevoluteJoint_CollideConnected_SetsProperty()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            List<Body> bodies = new List<Body>();
            for (int i = 0; i < 2; i++)
            {
                Body body = world.CreateBody();
                body.Position = new Vector2F(i * 2f, 0f);
                bodies.Add(body);
            }

            List<RevoluteJoint> joints = PathManager.AttachBodiesWithRevoluteJoint(
                world, bodies, new Vector2F(0f, 0f), new Vector2F(0f, 0f), false, true);

            Assert.NotNull(joints);
            Assert.Single(joints);
            Assert.True(joints[0].CollideConnected);
        }

        /// <summary>
        ///     Tests that AttachBodiesWithRevoluteJoint with single body still creates expected joints
        /// </summary>
        [Fact]
        public void AttachBodiesWithRevoluteJoint_SingleBody_ReturnsEmptyList()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            List<Body> bodies = new List<Body> { world.CreateBody() };

            List<RevoluteJoint> joints = PathManager.AttachBodiesWithRevoluteJoint(
                world, bodies, new Vector2F(0f, 0f), new Vector2F(0f, 0f), false, false);

            Assert.NotNull(joints);
            Assert.Empty(joints);
        }
    }
}