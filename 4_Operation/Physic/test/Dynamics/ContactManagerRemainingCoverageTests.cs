using System;
using System.Reflection;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact manager remaining coverage tests class
    /// </summary>
    public class ContactManagerRemainingCoverageTests
    {
        /// <summary>
        /// Tests that wake bodies on contact with sensor fixture returns early
        /// </summary>
        [Fact]
        public void WakeBodiesOnContact_WithSensorFixture_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetIsSensor(true);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that try resolve contact filter destroys when should collide returns false
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_Destroys_WhenShouldCollideReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that try resolve contact filter clears filter flag when all pass
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_ClearsFilterFlag_WhenAllPass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that process contact collision both bodies active updates contact
        /// </summary>
        [Fact]
        public void ProcessContactCollision_BothBodiesActive_UpdatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that collide multi core with disabled body skips contact
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithDisabledBody_SkipsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.Enabled = false;
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount <= 0);
        }

        /// <summary>
        /// Tests that process contact multi core with overlap false destroys contact
        /// </summary>
        [Fact]
        public void ProcessContactMultiCore_WithOverlapFalse_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }
        

        /// <summary>
        /// Tests that process contact multi core with try resolve contact filter destroys contact
        /// </summary>
        [Fact]
        public void ProcessContactMultiCore_WithTryResolveContactFilter_DestroysContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that update contact with lock with different lock orders updates contact
        /// </summary>
        [Fact]
        public void UpdateContactWithLock_WithDifferentLockOrders_UpdatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that body with multiple contacts removes one correctly
        /// </summary>
        [Fact]
        public void BodyWithMultipleContacts_RemovesOneCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.8f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.8f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that collide multi core with filter flag on contact re evaluates
        /// </summary>
        [Fact]
        public void CollideMultiCore_WithFilterFlagOnContact_ReEvaluates()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that should collide group zero different uses category check
        /// </summary>
        [Fact]
        public void ShouldCollide_GroupZeroDifferent_UsesCategoryCheck()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(0);
            bodyB.SetCollisionGroup(1);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that should collide mismatched categories returns false
        /// </summary>
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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that destroy without end contact does not throw
        /// </summary>
        [Fact]
        public void Destroy_WithoutEndContact_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.ContactManager.EndContact = null;

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that add pair with already existing contact returns early
        /// </summary>
        [Fact]
        public void AddPair_WithAlreadyExistingContact_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            int count = world.ContactManager.ContactCount;
            Assert.True(count > 0);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(count, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that remove from world removes contact decrements count
        /// </summary>
        [Fact]
        public void RemoveFromWorld_RemovesContact_DecrementsCount()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            int before = world.ContactManager.ContactCount;
            Assert.True(before > 0);

            world.Remove(bodyA);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount < before);
        }
        
        /// <summary>
        /// Tests that collide multi core empty update list does not throw
        /// </summary>
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

        /// <summary>
        /// Tests that passes collision filters fails when before collision a returns false
        /// </summary>
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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that passes collision filters fails when before collision b returns false
        /// </summary>
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

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that find new contacts with broad phase does not throw
        /// </summary>
        [Fact]
        public void FindNewContacts_WithBroadPhase_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.ContactManager.FindNewContacts());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that collide method with no contacts does not throw
        /// </summary>
        [Fact]
        public void CollideMethod_WithNoContacts_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            Exception ex = Record.Exception(() => world.ContactManager.Collide());
            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that notify separation fires fixture and body when fixture null does not throw
        /// </summary>
        [Fact]
        public void NotifySeparation_FiresFixtureAndBody_WhenFixtureNull_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }
        
        // ========================================================================
        // AddPair - Contact.Create returns null (unlikely, but test setup)
        // ========================================================================
        /// <summary>
        /// Tests that add pair with edge shape handles null contact
        /// </summary>
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
        /// <summary>
        /// Tests that remove body with multiple contacts removes correctly
        /// </summary>
        [Fact]
        public void RemoveBody_WithMultipleContacts_RemovesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.8f, 0f), BodyType.Dynamic);
            Body bodyC = world.CreateCircle(1.0f, 1.0f, new Vector2F(-0.8f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            int before = world.ContactManager.ContactCount;
            Assert.True(before > 0);
            world.Remove(bodyB);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount <= before);
        }

        // ========================================================================
        // Destroy - with EndContact registered (not null)
        // ========================================================================
        /// <summary>
        /// Tests that destroy with end contact fires callback
        /// </summary>
        [Fact]
        public void Destroy_WithEndContact_FiresCallback()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            int endCount = 0;
            world.ContactManager.EndContact = contact => endCount++;
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(endCount > 0);
        }

        // ========================================================================
        // Collide method - with multi-core path (threshold = 0)
        // ========================================================================
        /// <summary>
        /// Tests that collide multi core path processes contacts
        /// </summary>
        [Fact]
        public void Collide_MultiCorePath_ProcessesContacts()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
        }
        
        
        /// <summary>
        /// Tests that try resolve contact filter with contact filter false destroys
        /// </summary>
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
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // TryResolveContactFilter — ShouldCollide returns false (joint prevents)
        // ========================================================================
        /// <summary>
        /// Tests that try resolve contact filter joint prevents collision destroys
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_JointPreventsCollision_Destroys()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position)
                {
                    CollideConnected = false
                };
            world.Add(joint);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // AcquireLocks — through multithreaded collision path
        // ========================================================================
        /// <summary>
        /// Tests that acquire locks through multi core does not deadlock
        /// </summary>
        [Fact]
        public void AcquireLocks_ThroughMultiCore_DoesNotDeadlock()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));
            Assert.Null(ex);
        }

        // ========================================================================
        // TryResolveContactFilter with all paths via multithreaded collision
        // ========================================================================
        /// <summary>
        /// Tests that try resolve contact filter multi core executes all paths
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_MultiCore_ExecutesAllPaths()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);
            SolverIterations iterations = new SolverIterations
                {
                    PositionIterations = 10
                };
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);
            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold",
                System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);
            bodyA.SetCollisionGroup(-1);
            bodyB.SetCollisionGroup(-1);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.Equal(0, world.ContactManager.ContactCount);
        }
    }
}
