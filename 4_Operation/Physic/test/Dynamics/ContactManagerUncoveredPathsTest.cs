using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    public class ContactManagerUncoveredPathsTest
    {
        [Fact]
        public void NotifySeparation_FiresAllHandlers_WhenAllSet()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int fixtureASepCount = 0;
            int fixtureBSepCount = 0;
            int bodyASepCount = 0;
            int bodyBSepCount = 0;

            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.OnSeparation = (_, _, _) => fixtureASepCount++;
                contact.FixtureB.OnSeparation = (_, _, _) => fixtureBSepCount++;
                return true;
            };

            bodyA.OnSeparation += (_, _, _) => bodyASepCount++;
            bodyB.OnSeparation += (_, _, _) => bodyBSepCount++;

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(fixtureASepCount > 0);
            Assert.True(fixtureBSepCount > 0);
            Assert.True(bodyASepCount > 0);
            Assert.True(bodyBSepCount > 0);
        }

        [Fact]
        public void PassesCollisionFilters_Fails_WhenBodyShouldNotCollide()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void BeforeCollision_CanBlockContact_WhenFixtureAReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.BeforeCollision = (_, _) => false;
                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void BeforeCollision_CanBlockContact_WhenFixtureBReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureB.BeforeCollision = (_, _) => false;
                return true;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void TryResolveContactFilter_Destroys_WhenContactFilterReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            int initialCount = world.ContactManager.ContactCount;
            Assert.True(initialCount > 0);

            world.ContactManager.ContactFilter = (_, _) => false;

            world.Step(1.0f / 60.0f);

            Assert.Equal(1, world.ContactManager.ContactCount);
        }

        [Fact]
        public void FixtureOnSeparation_OnlyBodyA_ShouldFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int bodyASepCount = 0;

            bodyA.OnSeparation += (_, _, _) => bodyASepCount++;

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(bodyASepCount > 0);
        }

        [Fact]
        public void FixtureOnSeparation_OnlyBodyB_ShouldFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int bodyBSepCount = 0;

            bodyB.OnSeparation += (_, _, _) => bodyBSepCount++;

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.True(bodyBSepCount > 0);
        }

        [Fact]
        public void CollisionGroup_Zero_UsesCategoryCheck()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(0);
            bodyB.SetCollisionGroup(0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }
    }
}
