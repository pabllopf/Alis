using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact manager test class
    /// </summary>
    public class ContactManagerTest
    {
        /// <summary>
        /// Tests that contact manager should create contacts when bodies overlap
        /// </summary>
        [Fact]
        public void ContactManager_ShouldCreateContacts_WhenBodiesOverlap()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that begin contact callback should be raised when new contact appears
        /// </summary>
        [Fact]
        public void BeginContactCallback_ShouldBeRaised_WhenNewContactAppears()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            int beginCount = 0;
            world.ContactManager.BeginContact = contact =>
            {
                beginCount++;
                return false;
            };

            world.Step(1.0f / 60.0f);

            Assert.True(beginCount > 0);
        }

        /// <summary>
        /// Tests that contact filter should be able to block contact creation
        /// </summary>
        [Fact]
        public void ContactFilter_ShouldBeAbleToBlockContactCreation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            world.ContactManager.ContactFilter = (_, _) => false;

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }
    }
}

