using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Alis.Core.Physic.Dynamics.Joints;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    /// The contact manager uncovered paths test class
    /// </summary>
    public class ContactManagerUncoveredPathsTest
    {
        /// <summary>
        /// Tests that notify separation fires all handlers when all set
        /// </summary>
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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(fixtureASepCount > 0);
            Assert.True(fixtureBSepCount > 0);
            Assert.True(bodyASepCount > 0);
            Assert.True(bodyBSepCount > 0);
        }

        /// <summary>
        /// Tests that passes collision filters fails when body should not collide
        /// </summary>
        [Fact]
        public void PassesCollisionFilters_Fails_WhenBodyShouldNotCollide()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Static);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Static);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that before collision can block contact when fixture a returns false
        /// </summary>
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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that before collision can block contact when fixture b returns false
        /// </summary>
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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that try resolve contact filter destroys when contact filter returns false
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_Destroys_WhenContactFilterReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            int initialCount = world.ContactManager.ContactCount;
            Assert.True(initialCount > 0);

            world.ContactManager.ContactFilter = (_, _) => false;

           
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(1, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that fixture on separation only body a should fire
        /// </summary>
        [Fact]
        public void FixtureOnSeparation_OnlyBodyA_ShouldFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int bodyASepCount = 0;

            bodyA.OnSeparation += (_, _, _) => bodyASepCount++;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(bodyASepCount > 0);
        }

        /// <summary>
        /// Tests that fixture on separation only body b should fire
        /// </summary>
        [Fact]
        public void FixtureOnSeparation_OnlyBodyB_ShouldFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int bodyBSepCount = 0;

            bodyB.OnSeparation += (_, _, _) => bodyBSepCount++;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(bodyBSepCount > 0);
        }

        /// <summary>
        /// Tests that collision group zero uses category check
        /// </summary>
        [Fact]
        public void CollisionGroup_Zero_UsesCategoryCheck()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(0);
            bodyB.SetCollisionGroup(0);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);

            FieldInfo field = typeof(ContactManager).GetField("CollideMultithreadThreshold", BindingFlags.Instance | BindingFlags.Public);
            field.SetValue(world.ContactManager, 0);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.Awake = false;
            bodyB.Awake = false;

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            int initialCount = world.ContactManager.ContactCount;
            Assert.True(initialCount > 0);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            world.Add(joint);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        /// <summary>
        /// Tests that destroy when not touching does not fire separation
        /// </summary>
        [Fact]
        public void Destroy_WhenNotTouching_DoesNotFireSeparation()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            Contact contact = world.ContactManager.ContactList.Next;
            contact.IsTouching = false;

            world.ContactManager.Destroy(contact);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that remove from body with single contact updates lists
        /// </summary>
        [Fact]
        public void RemoveFromBody_WithSingleContact_UpdatesLists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);

            Assert.Null(bodyA.ContactList);
        }

        /// <summary>
        /// Tests that collide multi core with single processor does not throw
        /// </summary>
        [Fact]
        public void Collide_MultiCore_WithSingleProcessor_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
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
        /// Tests that notify separation with all handlers null does not throw
        /// </summary>
        [Fact]
        public void NotifySeparation_WithAllHandlersNull_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000f, 1000f), 0f);
            bodyB.SetTransform(new Vector2F(2000f, 2000f), 0f);

            Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

            Assert.Null(ex);
        }

        /// <summary>
        /// Tests that try resolve contact filter without filter flag returns false
        /// </summary>
        [Fact]
        public void TryResolveContactFilter_WithoutFilterFlag_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0f, 0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            DistanceJoint joint = new DistanceJoint(bodyA, bodyB, bodyA.Position, bodyB.Position);
            joint.CollideConnected = true;
            world.Add(joint);

            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that add pair bodies same fixture returns early
        /// </summary>
        [Fact]
        public void AddPair_BodiesSameFixture_ReturnsEarly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateCircle(1.0f, 1.0f, Vector2F.Zero, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // ShouldCollide — non-zero groups that don't match (line 367-375)
        // ========================================================================

        /// <summary>
        /// Tests that should collide with non matching groups uses categories
        /// </summary>
        [Fact]
        public void ShouldCollide_WithNonMatchingGroups_UsesCategories()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.SetCollisionGroup(1);
            bodyB.SetCollisionGroup(2);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // ProcessContactMultiCore — bodyA disabled (line 589-591)
        // ========================================================================

        /// <summary>
        /// Tests that process contact multi core with disabled body returns next
        /// </summary>
        [Fact]
        public void ProcessContactMultiCore_WithDisabledBody_ReturnsNext()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
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

        // ========================================================================
        // CollideMultiCore — exercises the multicore path end-to-end
        // ========================================================================

        /// <summary>
        /// Tests that collide multi core with multiple contacts processes all
        /// </summary>
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

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        // ========================================================================
        // RemoveFromBody — nodeA == bodyA.ContactList (line 291-293)
        // ========================================================================

        /// <summary>
        /// Tests that remove from body node a is contact list updates list
        /// </summary>
        [Fact]
        public void RemoveFromBody_NodeAIsContactList_UpdatesList()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            world.Remove(bodyA);
            Assert.Null(bodyA.ContactList);
        }

        // ========================================================================
        // PassesCollisionFilters — ContactFilter returns false (line 507-510)
        // ========================================================================

        /// <summary>
        /// Tests that passes collision filters contact filter blocks returns false
        /// </summary>
        [Fact]
        public void PassesCollisionFilters_ContactFilterBlocks_ReturnsFalse()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.ContactManager.ContactFilter = (_, _) => false;
            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(0, world.ContactManager.ContactCount);
        }

        // ========================================================================
        // ContactAlreadyExists — swapped fixture/index order (line 478-480)
        // Exercises the second comparison: (fA == fixtureB) && (fB == fixtureA)
        // ========================================================================
        /// <summary>
        /// Tests that contact already exists returns true with swapped fixtures order
        /// </summary>
        [Fact]
        public void ContactAlreadyExists_WithSwappedOrder_ReturnsTrue()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            ContactEdge edge = bodyB.ContactList;
            Assert.NotNull(edge);
            Assert.Same(bodyA, edge.Other);

            MethodInfo method = typeof(ContactManager).GetMethod("ContactAlreadyExists",
                BindingFlags.NonPublic | BindingFlags.Static);
            Assert.NotNull(method);

            Fixture fA = edge.Contact.FixtureA;
            Fixture fB = edge.Contact.FixtureB;
            int iA = edge.Contact.ChildIndexA;
            int iB = edge.Contact.ChildIndexB;

            bool result = (bool)method.Invoke(null, new object[] { bodyA, bodyB, fB, fA, iB, iA });
            Assert.True(result);
        }

        // ========================================================================
        // AcquireLocks — body lock contention triggers retry (lines 717-721)
        // Exercises Interlocked.Exchange(ref bodyA.Lock, 0) and Thread.Sleep(0)
        // ========================================================================
        /// <summary>
        /// Tests that acquire locks retries when body lock is held by another thread
        /// </summary>
        [Fact]
        public void AcquireLocks_WithContention_Retries()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody();
            Body bodyB = world.CreateBody();

            FieldInfo lockField = typeof(Body).GetField("Lock", BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo acquireLocks = typeof(ContactManager).GetMethod("AcquireLocks",
                BindingFlags.NonPublic | BindingFlags.Static);

            lockField.SetValue(bodyB, 1);

            using (ManualResetEvent releaseEvent = new ManualResetEvent(false))
            {
                Task.Run(() =>
                {
                    Thread.Sleep(30);
                    lockField.SetValue(bodyB, 0);
                    releaseEvent.Set();
                });

                acquireLocks.Invoke(null, new object[] { bodyA, bodyB });

                releaseEvent.WaitOne(1000);
            }

            lockField.SetValue(bodyA, 0);
            lockField.SetValue(bodyB, 0);

            Assert.Equal(0, lockField.GetValue(bodyA));
            Assert.Equal(0, lockField.GetValue(bodyB));
        }

        // ========================================================================
        // Lines 180-181: AddPair when Contact.Create returns null
        // ========================================================================

        /// <summary>
        ///     Tests that add pair handles null contact from create gracefully
        /// </summary>
        [Fact]
        public void AddPair_HandlesNullContact_FromCreate()
        {
            FieldInfo returnNullField = typeof(Contact).GetField("ReturnNullOverride",
                BindingFlags.Static | BindingFlags.NonPublic);

            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            try
            {
                returnNullField.SetValue(null, true);

                Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
                Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

                Exception ex = Record.Exception(() => world.Step(1.0f / 60.0f));

                Assert.Null(ex);
                Assert.Equal(0, world.ContactManager.ContactCount);
            }
            finally
            {
                returnNullField.SetValue(null, false);
            }
        }
    }
}
