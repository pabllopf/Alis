using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;
using Xunit.Abstractions;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class WorldPhysicScratchTests
    {
        private readonly ITestOutputHelper _output;

        public WorldPhysicScratchTests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Dense_WithToiAwareDisable()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            for (int row = 0; row < 16; row++)
            {
                for (int col = 0; col < 12; col++)
                {
                    world.CreateCircle(0.1f, 1.0f, new Vector2F(12 + col * 0.2f, 0.25f + row * 0.2f), BodyType.Static);
                }
            }

            world.CreateCircle(0.1f, 1.0f, new Vector2F(12, 1.375f), BodyType.Dynamic);
            world.CreateCircle(0.1f, 1.0f, new Vector2F(13, 1.775f), BodyType.Dynamic);
            world.CreateCircle(0.1f, 1.0f, new Vector2F(12.8f, 1.2f), BodyType.Dynamic);

            Body bulletA = world.CreateCircle(1.5f, 1.0f, new Vector2F(0, 1.375f), BodyType.Dynamic);
            bulletA.IsBullet = true;
            bulletA.LinearVelocity = new Vector2F(50, 0);

            Body bulletB = world.CreateCircle(1.5f, 1.0f, new Vector2F(16, 1.375f), BodyType.Dynamic);
            bulletB.IsBullet = true;
            bulletB.LinearVelocity = new Vector2F(-50, 0);

            Body sensorBody = world.CreateBody(new Vector2F(12, 3.5f), 0, BodyType.Static);
            Fixture sensorFixture = sensorBody.CreateFixture(new CircleShape(2.0f, 0.0f));
            sensorFixture.GetIsSensor = true;

            bulletA.FixtureList.List[0].OnCollision += (a, b, c) => false;

            for (int i = 0; i < 100; i++)
            {
                world.Step(1.0f / 60.0f);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
            Assert.True(bulletA.Position.X > 0);
        }
    }
}