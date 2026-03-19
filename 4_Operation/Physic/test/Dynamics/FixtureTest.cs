using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The fixture test class
    /// </summary>
    public class FixtureTest
    {
        /// <summary>
        /// Tests that constructor with shape should clone shape and setup proxies
        /// </summary>
        [Fact]
        public void Constructor_WithShape_ShouldCloneShapeAndSetupProxies()
        {
            CircleShape shape = new CircleShape(0.5f, 1.0f);

            Fixture fixture = new Fixture(shape);

            Assert.NotSame(shape, fixture.GetShape);
            Assert.Equal(shape.ChildCount, fixture.Proxies.Length);
            Assert.Equal(0, fixture.ProxyCount);
        }

        /// <summary>
        /// Tests that sensor flag when set should wake body
        /// </summary>
        [Fact]
        public void SensorFlag_WhenSet_ShouldWakeBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            fixture.GetIsSensor = true;

            Assert.True(body.Awake);
            Assert.True(fixture.GetIsSensor);
        }

        /// <summary>
        /// Tests that collision category properties should set and get values
        /// </summary>
        [Fact]
        public void CollisionCategoryProperties_ShouldSetAndGetValues()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            fixture.GetCollisionGroup = 2;
            fixture.GetCollisionCategories = Category.Cat4;
            fixture.GetCollidesWith = Category.Cat2 | Category.Cat3;

            Assert.Equal((short)2, fixture.GetCollisionGroup);
            Assert.Equal(Category.Cat4, fixture.GetCollisionCategories);
            Assert.Equal(Category.Cat2 | Category.Cat3, fixture.GetCollidesWith);
        }

        /// <summary>
        /// Tests that test point should return true when point inside circle
        /// </summary>
        [Fact]
        public void TestPoint_ShouldReturnTrue_WhenPointInsideCircle()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 1.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(1.0f, 1.0f);
            Vector2F point = new Vector2F(1.2f, 1.1f);

            bool isInside = fixture.TestPoint(ref point);

            Assert.True(isInside);
        }

        /// <summary>
        /// Tests that friction and restitution should persist assigned values
        /// </summary>
        [Fact]
        public void FrictionAndRestitution_ShouldPersistAssignedValues()
        {
            Fixture fixture = new Fixture(new CircleShape(0.4f, 1.0f));

            fixture.GetFriction = 0.9f;
            fixture.GetRestitution = 0.2f;

            Assert.Equal(0.9f, fixture.GetFriction);
            Assert.Equal(0.2f, fixture.GetRestitution);
        }
    }
}

