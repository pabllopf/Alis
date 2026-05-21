

using System;
using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
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
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(5, 0), new Vector2F(10, 0)});
            path.Closed = false;

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
            });
            path.Closed = true;

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
            });
            path.Closed = true;

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
            Path path = new Path(new[] {new Vector2F(0, 0), new Vector2F(5, 0)});
            path.Closed = false;

            Assert.Throws<Exception>(() => PathManager.ConvertPathToPolygon(path, body, 1.0f, 2));
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
    }
}