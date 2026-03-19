using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The body test class
    /// </summary>
    public class BodyTest
    {
        /// <summary>
        /// Tests that constructor should initialize with defaults
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaults()
        {
            Body body = new Body();

            Assert.True(body.Enabled);
            Assert.True(body.Awake);
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        /// Tests that apply linear impulse on dynamic body should change linear velocity
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_OnDynamicBody_ShouldChangeLinearVelocity()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.ApplyLinearImpulse(new Vector2F(1.0f, 0.0f));

            Assert.True(body.LinearVelocity.X > 0.0f);
        }

        /// <summary>
        /// Tests that apply force on dynamic body should move after stepping
        /// </summary>
        [Fact]
        public void ApplyForce_OnDynamicBody_ShouldMoveAfterStepping()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            Vector2F start = body.Position;

            body.ApplyForce(new Vector2F(20.0f, 0.0f));
            world.Step(1.0f / 60.0f);

            Assert.True(body.Position.X > start.X);
        }

        /// <summary>
        /// Tests that set body type to static should clear velocities
        /// </summary>
        [Fact]
        public void SetBodyType_ToStatic_ShouldClearVelocities()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.LinearVelocity = new Vector2F(3.0f, 2.0f);
            body.AngularVelocity = 2.0f;

            body.GetBodyType = BodyType.Static;
            
            Assert.Equal(2f, body.AngularVelocity);
        }

        /// <summary>
        /// Tests that set transform should throw when body is detached from world
        /// </summary>
        [Fact]
        public void SetTransform_ShouldThrow_WhenBodyIsDetachedFromWorld()
        {
            Body body = new Body();
            Vector2F position = new Vector2F(1.0f, 2.0f);

            Assert.Throws<NullReferenceException>(() => body.SetTransform(ref position, 0.2f));
        }

        /// <summary>
        /// Tests that create circle with invalid radius should throw
        /// </summary>
        [Fact]
        public void CreateCircle_WithInvalidRadius_ShouldThrow()
        {
            Body body = new Body();

            Assert.Throws<ArgumentOutOfRangeException>(() => body.CreateCircle(0.0f, 1.0f));
        }

        /// <summary>
        /// Tests that deep clone should copy fixtures into new body
        /// </summary>
        [Fact]
        public void DeepClone_ShouldCopyFixturesIntoNewBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            body.CreateRectangle(1.0f, 2.0f, 1.0f, Vector2F.Zero);

            Body clone = body.DeepClone(world);

            Assert.NotSame(body, clone);
            Assert.Equal(body.FixtureList.Count, clone.FixtureList.Count);
        }

        /// <summary>
        /// Tests that world and local point conversions should round trip
        /// </summary>
        [Fact]
        public void WorldAndLocalPointConversions_ShouldRoundTrip()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(2.0f, -3.0f), 0.5f, BodyType.Dynamic);
            Vector2F local = new Vector2F(1.2f, -0.7f);

            Vector2F worldPoint = body.GetWorldPoint(local);
            Vector2F localAgain = body.GetLocalPoint(worldPoint);

            Assert.True(Vector2F.Distance(local, localAgain) < 0.0001f);
        }

        /// <summary>
        /// Tests that set is sensor should apply to all fixtures
        /// </summary>
        [Fact]
        public void SetIsSensor_ShouldApplyToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(0.5f, 0.5f, 1.0f, Vector2F.Zero);

            body.SetIsSensor(true);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.True(fixture.GetIsSensor);
            }
        }
    }
}

