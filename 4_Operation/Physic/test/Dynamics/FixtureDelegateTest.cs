

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The fixture delegate test class
    /// </summary>
    public class FixtureDelegateTest
    {
        /// <summary>
        ///     Tests that fixture delegate should be invokable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeInvokable()
        {
            bool invoked = false;
            FixtureDelegate callback = (sender, body, fixture) => { invoked = true; };

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            callback(world, body, fixture);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive world parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveWorldParameter()
        {
            WorldPhysic capturedWorld = null;
            FixtureDelegate callback = (sender, body, fixture) => { capturedWorld = sender; };

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            callback(world, body, fixture);

            Assert.Equal(world, capturedWorld);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive body parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveBodyParameter()
        {
            Body capturedBody = null;
            FixtureDelegate callback = (sender, body, fixture) => { capturedBody = body; };

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            callback(world, body, fixture);

            Assert.Equal(body, capturedBody);
        }

        /// <summary>
        ///     Tests that fixture delegate should receive fixture parameter
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldReceiveFixtureParameter()
        {
            Fixture capturedFixture = null;
            FixtureDelegate callback = (sender, body, fixture) => { capturedFixture = fixture; };

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            callback(world, body, fixture);

            Assert.Equal(fixture, capturedFixture);
        }

        /// <summary>
        ///     Tests that fixture delegate should be chainable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeChainable()
        {
            int callCount = 0;
            FixtureDelegate callback1 = (sender, body, fixture) => callCount++;
            FixtureDelegate callback2 = (sender, body, fixture) => callCount++;

            FixtureDelegate combined = callback1 + callback2;

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            combined(world, body, fixture);

            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that fixture delegate should be removable
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldBeRemovable()
        {
            int callCount = 0;
            FixtureDelegate callback1 = (sender, body, fixture) => callCount++;
            FixtureDelegate callback2 = (sender, body, fixture) => callCount++;

            FixtureDelegate combined = callback1 + callback2;
            combined -= callback1;

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            combined(world, body, fixture);

            Assert.Equal(1, callCount);
        }

        /// <summary>
        ///     Tests that fixture delegate should handle null parameters
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldHandleNullParameters()
        {
            bool invoked = false;
            FixtureDelegate callback = (sender, body, fixture) => { invoked = true; };

            callback(null, null, null);

            Assert.True(invoked);
        }

        /// <summary>
        ///     Tests that fixture delegate should support multiple invocations
        /// </summary>
        [Fact]
        public void FixtureDelegate_ShouldSupportMultipleInvocations()
        {
            int count = 0;
            FixtureDelegate callback = (sender, body, fixture) => count++;

            WorldPhysic world = new WorldPhysic(new Vector2F(0, -10));
            Body body = world.CreateBody();
            CircleShape shape = new CircleShape(1.0f, 1.0f);
            Fixture fixture = body.CreateFixture(shape);

            callback(world, body, fixture);
            callback(world, body, fixture);
            callback(world, body, fixture);

            Assert.Equal(3, count);
        }
    }
}