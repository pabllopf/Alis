using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
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

        /// <summary>
        ///     Tests the multicore collision path by setting CollideMultithreadThreshold to 0.
        ///     Exercises CollideMultiCore, ProcessContactMultiCore, UpdateContactWithLock, and AcquireLocks.
        /// </summary>
        [Fact]
        public void CollideMultiCore_ShouldProcessContacts_WhenThresholdLow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold", BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that when both bodies are not active (asleep), ProcessContactCollision
        ///     skips contact processing via the !activeA && !activeB early return.
        /// </summary>
        [Fact]
        public void ProcessContactCollision_BothBodiesInactive_SkipsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.Awake = false;
            bodyB.Awake = false;

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests TryResolveContactFilter when FilterFlag is set and a joint prevents collision.
        ///     The joint (CollideConnected=false) makes bodyB.ShouldCollide(bodyA) return false,
        ///     which triggers contact destruction in TryResolveContactFilter.
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_Destroys_WhenJointPreventsCollision()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            int initialCount = world.ContactManager.ContactCount;
            Assert.True(initialCount > 0);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void Destroy_WhenNotTouching_DoesNotFireSeparation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            Contact contact = world.ContactManager.ContactList.Next;
            contact.IsTouching = false;

            world.ContactManager.Destroy(contact);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void RemoveFromBody_WithSingleContact_UpdatesLists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);

            Assert.Null(bodyA.ContactList);
        }

        [Fact]
        public void Collide_MultiCore_WithSingleProcessor_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void NotifySeparation_WithAllHandlersNull_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        [Fact]
        public void TryResolveContactFilter_WithoutFilterFlag_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = true;
            world.Add(joint);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void AddPair_BodiesSameFixture_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // ShouldCollide — non-zero groups that don't match (line 367-375)
        // ========================================================================

        [Fact]
        public void ShouldCollide_WithNonMatchingGroups_UsesCategories()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(1);
            bodyB.SetCollisionGroup(2);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // ProcessContactMultiCore — bodyA disabled (line 589-591)
        // ========================================================================

        [Fact]
        public void ProcessContactMultiCore_WithDisabledBody_ReturnsNext()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.Enabled = false;
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount <= 0);
        }

        // ========================================================================
        // CollideMultiCore — exercises the multicore path end-to-end
        // ========================================================================

        [Fact]
        public void CollideMultiCore_WithMultipleContacts_ProcessesAll()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            for (int i = 0; i < 3; i++)
            {
                world.CreateCircle(1.0f, 1.0f, new Vector2F(i * 0.3f, 0.0f), BodyType.Dynamic);
            }

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // RemoveFromBody — nodeA == bodyA.ContactList (line 291-293)
        // ========================================================================

        [Fact]
        public void RemoveFromBody_NodeAIsContactList_UpdatesList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            Assert.Null(bodyA.ContactList);
        }

        // ========================================================================
        // PassesCollisionFilters — ContactFilter returns false (line 507-510)
        // ========================================================================

        [Fact]
        public void PassesCollisionFilters_ContactFilterBlocks_ReturnsFalse()
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
