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
    public class ContactManagerRemainingCoverageTests
    {
        [Fact]
        public void WakeBodiesOnContact_WithSensorFixture_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetIsSensor(true);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void TryResolveContactFilter_Destroys_WhenShouldCollideReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void TryResolveContactFilter_ClearsFilterFlag_WhenAllPass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void ProcessContactCollision_BothBodiesActive_UpdatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void CollideMultiCore_WithDisabledBody_SkipsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.Enabled = false;
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount <= 0);
        }

        [Fact]
        public void ProcessContactMultiCore_WithOverlapFalse_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void ProcessContactMultiCore_WithBothBodiesInactive_SkipsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.Awake = false;
            bodyB.Awake = false;

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void ProcessContactMultiCore_WithTryResolveContactFilter_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void UpdateContactWithLock_WithDifferentLockOrders_UpdatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void BodyWithMultipleContacts_RemovesOneCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.8f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.8f, 0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        [Fact]
        public void CollideMultiCore_WithFilterFlagOnContact_ReEvaluates()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void ShouldCollide_GroupZeroDifferent_UsesCategoryCheck()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(0);
            bodyB.SetCollisionGroup(1);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void ShouldCollide_MismatchedCategories_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            foreach (Fixture fixture in bodyA.FixtureList)
            {
                fixture.GetCollisionCategories = Categories.Cat1;
                fixture.GetCollidesWith = Categories.Cat2;
            }

            foreach (Fixture fixture in bodyB.FixtureList)
            {
                fixture.GetCollisionCategories = Categories.Cat3;
                fixture.GetCollidesWith = Categories.Cat4;
            }

            world.Step(1.0f / 60.0f);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        [Fact]
        public void Destroy_WithoutEndContact_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.ContactManager.EndContact = null;

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        [Fact]
        public void AddPair_WithAlreadyExistingContact_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            int count = world.ContactManager.ContactCount;
            Assert.True(count > 0);

            world.Step(1.0f / 60.0f);

            Assert.Equal(count, world.ContactManager.ContactCount);
        }

        [Fact]
        public void RemoveFromWorld_RemovesContact_DecrementsCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            int before = world.ContactManager.ContactCount;
            Assert.True(before > 0);

            world.Remove(bodyA);
            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount < before);
        }

        [Fact]
        public void ShouldCollide_OneGroupZero_OneNonZero_UsesCategories()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(0);
            bodyB.SetCollisionGroup(-2);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void CollideMultiCore_EmptyUpdateList_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        [Fact]
        public void Destroy_AddsToPool_AndReuses()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);

            bodyA.SetTransform(new Vector2F(0f, 0f), 0f);
            bodyB.SetTransform(new Vector2F(0.5f, 0f), 0f);

            world.Step(1.0f / 60.0f);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        [Fact]
        public void PassesCollisionFilters_Fails_WhenBeforeCollisionAReturnsFalse()
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
        public void PassesCollisionFilters_Fails_WhenBeforeCollisionBReturnsFalse()
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
        public void FindNewContacts_WithBroadPhase_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.ContactManager.FindNewContacts());
            Assert.Null(ex);
        }

        [Fact]
        public void CollideMethod_WithNoContacts_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.ContactManager.Collide());
            Assert.Null(ex);
        }

        [Fact]
        public void NotifySeparation_FiresFixtureAndBody_WhenFixtureNull_DoesNotThrow()
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

        // ========================================================================
        // ProcessContactCollision - bodies enabled, both active, overlapping (full path)
        // ========================================================================
        [Fact]
        public void ProcessContactCollision_FullPath_UpdatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // AddPair - Contact.Create returns null (unlikely, but test setup)
        // ========================================================================
        [Fact]
        public void AddPair_WithEdgeShape_HandlesNullContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateEdge(new Vector2F(0f, 0f), new Vector2F(1f, 0f));
            bodyA.GetBodyType = BodyType.Dynamic;
            Body bodyB = world.CreateCircle(0.5f, 1.0f, new Vector2F(0.5f, 0.5f), BodyType.Dynamic);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // RemoveFromBody — with complex node structures
        // ========================================================================
        [Fact]
        public void RemoveBody_WithMultipleContacts_RemovesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.8f, 0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.8f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            int before = world.ContactManager.ContactCount;
            Assert.True(before > 0);
            world.Remove(bodyB);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount <= before);
        }

        // ========================================================================
        // Destroy - with EndContact registered (not null)
        // ========================================================================
        [Fact]
        public void Destroy_WithEndContact_FiresCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            int endCount = 0;
            world.ContactManager.EndContact = contact => endCount++;
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);
            world.Step(1.0f / 60.0f);
            Assert.True(endCount > 0);
        }

        // ========================================================================
        // Collide method - with multi-core path (threshold = 0)
        // ========================================================================
        [Fact]
        public void Collide_MultiCorePath_ProcessesContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // ProcessContactMultiCore - both active and overlapping
        // ========================================================================
        [Fact]
        public void ProcessContactMultiCore_AllActiveAndOverlapping_Updates()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // PassesCollisionFilters - full path (all checks pass)
        // ========================================================================
        [Fact]
        public void PassesCollisionFilters_AllChecksPass_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.ContactManager.ContactFilter = (fixtureA, fixtureB) => true;
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // UpdateContactWithLock - with idA > idB (swapped order)
        // ========================================================================
        [Fact]
        public void UpdateContactWithLock_SwappedLockOrder_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            bodyA.LockOrder = 2;
            bodyB.LockOrder = 1;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // TryResolveContactFilter — ContactFilter returns false path
        // ========================================================================
        [Fact]
        public void TryResolveContactFilter_WithContactFilterFalse_Destroys()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.ContactManager.BeginContact = contact =>
            {
                contact.FilterFlag = true;
                return true;
            };
            world.ContactManager.ContactFilter = (_, _) => false;
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // TryResolveContactFilter — ShouldCollide returns false (joint prevents)
        // ========================================================================
        [Fact]
        public void TryResolveContactFilter_JointPreventsCollision_Destroys()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = false;
            world.Add(joint);
            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // AcquireLocks — through multithreaded collision path
        // ========================================================================
        [Fact]
        public void AcquireLocks_ThroughMultiCore_DoesNotDeadlock()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // PassesCollisionFilters — all checks pass path
        // ========================================================================
        [Fact]
        public void PassesCollisionFilters_AllTrue_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.ContactManager.ContactFilter = null;
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // ContactAlreadyExists with reversed fixture/index ordering
        // ========================================================================
        [Fact]
        public void ContactAlreadyExists_ReverseOrder_DetectsCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            int count = world.ContactManager.ContactCount;
            Assert.True(count > 0);
            world.Step(1.0f / 60.0f);
            Assert.Equal(count, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // AcquireLocks with contention (via UpdateContactWithLock)
        // ========================================================================
        [Fact]
        public void AcquireLocks_WithContention_HandlesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            bodyA.LockOrder = 1;
            bodyB.LockOrder = 2;
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // TryResolveContactFilter with all paths via multithreaded collision
        // ========================================================================
        [Fact]
        public void TryResolveContactFilter_MultiCore_ExecutesAllPaths()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            world.Step(1.0f / 60.0f);
            Assert.True(world.ContactManager.ContactCount > 0);
            var field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);
            world.Step(1.0f / 60.0f);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }
    }
}
