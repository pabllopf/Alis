using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The world physic test class
    /// </summary>
    public class WorldPhysicTest
    {
        /// <summary>
        /// Tests that constructor with gravity should set gravity
        /// </summary>
        [Fact]
        public void Constructor_WithGravity_ShouldSetGravity()
        {
            Vector2F gravity = new Vector2F(0.0f, -5.0f);
            WorldPhysic world = new WorldPhysic(gravity);

            Assert.Equal(gravity, world.GetGravity);
        }

        /// <summary>
        /// Tests that create body and remove body should update body list
        /// </summary>
        [Fact]
        public void CreateBody_AndRemoveBody_ShouldUpdateBodyList()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.0f, BodyType.Dynamic);

            Assert.Single(world.BodyList);

            world.Remove(body);

            Assert.Empty(world.BodyList);
        }

        /// <summary>
        /// Tests that step when world disabled should not integrate bodies
        /// </summary>
        [Fact]
        public void Step_WhenWorldDisabled_ShouldNotIntegrateBodies()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));
            Body body = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.0f, 4.0f), BodyType.Dynamic);
            Vector2F initialPosition = body.Position;
            world.GetEnabled = false;

            world.Step(1.0f / 30.0f);

            Assert.Equal(initialPosition, body.Position);
        }

        /// <summary>
        /// Tests that query aabb should find fixtures inside region
        /// </summary>
        [Fact]
        public void QueryAabb_ShouldFindFixturesInsideRegion()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(0.5f, 0.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);
            world.CreateCircle(0.5f, 0.0f, new Vector2F(5.0f, 0.0f), BodyType.Static);

            Aabb area = new Aabb(new Vector2F(0.0f, 0.0f), 3.0f, 3.0f);
            int hits = 0;
            world.QueryAabb(_ =>
            {
                hits++;
                return true;
            }, ref area);

            Assert.Equal(1, hits);
        }

        /// <summary>
        /// Tests that ray cast should report at least one hit when crossing fixture
        /// </summary>
        [Fact]
        public void RayCast_ShouldReportAtLeastOneHit_WhenCrossingFixture()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 0.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Static);

            int hitCount = 0;
            world.RayCast((fixture, point, normal, fraction) =>
            {
                hitCount++;
                return 1.0f;
            }, new Vector2F(-4.0f, 0.0f), new Vector2F(4.0f, 0.0f));

            Assert.True(hitCount > 0);
        }

        /// <summary>
        /// Tests that test point should return fixture when point is inside shape
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnFixture_WhenPointIsInsideShape()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 0.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);

            Fixture fixture = world.TestPoint(new Vector2F(0.0f, 0.0f));

            Assert.NotNull(fixture);
        }

        /// <summary>
        /// Tests that shift origin should translate body positions
        /// </summary>
        [Fact]
        public void ShiftOrigin_ShouldTranslateBodyPositions()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(10.0f, 4.0f), 0.0f, BodyType.Dynamic);

            world.ShiftOrigin(new Vector2F(2.0f, 1.0f));

            Assert.Equal(new Vector2F(8.0f, 3.0f), body.Position);
        }

        /// <summary>
        /// Tests that set gravity should update gravity without lock checks
        /// </summary>
        [Fact]
        public void SetGravity_ShouldUpdateGravityWithoutLockChecks()
        {
            WorldPhysic world = new WorldPhysic(new Vector2F(0.0f, -9.81f));

            world.SetGravity(new Vector2F(1.0f, -2.0f));

            Assert.Equal(new Vector2F(1.0f, -2.0f), world.GetGravity);
        }
    }
}

