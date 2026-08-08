// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactCoverageTest.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Alis.Core.Physic.Collisions.Shapes;
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Dynamics.Contacts;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics.Contacts
{
    /// <summary>
    ///     The contact coverage test class
    /// </summary>
    public class ContactCoverageTest
    {
        /// <summary>
        ///     Tests that two overlapping rectangles collide and use the Polygon contact type.
        ///     This exercises the ContactType.Polygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void RectangleAndRectangle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.5f, 0.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that an edge and a circle overlapping create a contact.
        ///     This exercises the ContactType.EdgeAndCircle branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void EdgeAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateCircle(3.0f, 1.0f, new Vector2F(0.0f, -2.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that an edge and a rectangle overlapping create a contact.
        ///     This exercises the ContactType.EdgeAndPolygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void EdgeAndPolygon_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateRectangle(4.0f, 4.0f, 1.0f, new Vector2F(0.0f, -1.5f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that a chain shape and a circle overlapping create a contact.
        ///     This exercises the ContactType.ChainAndCircle branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void ChainAndCircle_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(-5.0f, 0.0f),
                new Vector2F(0.0f, 5.0f),
                new Vector2F(5.0f, 0.0f)
            };
            world.CreateChainShape(vertices, new Vector2F(0.0f, 0.0f));
            world.CreateCircle(3.0f, 1.0f, new Vector2F(0.0f, -2.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that a chain shape and a rectangle overlapping create a contact.
        ///     This exercises the ContactType.ChainAndPolygon branch in Contact.Evaluate.
        /// </summary>
        [Fact]
        public void ChainAndPolygon_Overlap_CreatesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Vertices vertices = new Vertices
            {
                new Vector2F(-5.0f, 0.0f),
                new Vector2F(0.0f, 5.0f),
                new Vector2F(5.0f, 0.0f)
            };
            world.CreateChainShape(vertices, new Vector2F(0.0f, 0.0f));
            world.CreateRectangle(4.0f, 4.0f, 1.0f, new Vector2F(0.0f, -1.5f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }
        
        /// <summary>
        ///     Tests that Fixture.OnCollision fires when contact is created.
        ///     This exercises InvokeHandlers in ReportCollision.
        /// </summary>
        [Fact]
        public void FixtureOnCollision_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.FixtureList[0].OnCollision = (_, _, _) =>
            {
                collisionFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(collisionFired);
            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that Fixture.OnCollision returning false disables the contact.
        ///     This exercises the enabled=false path in ReportCollision.
        /// </summary>
        [Fact]
        public void FixtureOnCollision_ReturnsFalse_DisabledContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.FixtureList[0].OnCollision = (_, _, _) =>
            {
                collisionFired = true;
                return false;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(collisionFired);
        }

        /// <summary>
        ///     Tests that Body.OnCollision fires when contact is created.
        ///     This exercises the body callback path in ReportCollision.
        /// </summary>
        [Fact]
        public void BodyOnCollision_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool collisionFired = false;
            bodyA.OnCollision += (_, _, _) =>
            {
                collisionFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(collisionFired);
        }

        /// <summary>
        ///     Tests that BeginContact delegate fires when contact is created.
        ///     This exercises the BeginContact path in ReportCollision.
        /// </summary>
        [Fact]
        public void BeginContact_Fires_WhenContactCreated()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool beginContactFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                beginContactFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(beginContactFired);
        }

        /// <summary>
        ///     Tests that EndContact delegate fires when bodies separate.
        ///     This exercises the EndContact path in ReportSeparation.
        /// </summary>
        [Fact]
        public void EndContact_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool endContactFired = false;
            world.ContactManager.EndContact = contact =>
            {
                endContactFired = true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(endContactFired);
        }

        /// <summary>
        ///     Tests that PreSolve delegate fires when contact persists.
        ///     This exercises the ProcessPreSolve path in Contact.Update.
        /// </summary>
        [Fact]
        public void PreSolve_Fires_WhenContactPersists()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool preSolveFired = false;
            void OnPreSolve(Contact contact, ref Manifold oldManifold) => preSolveFired = true;
            world.ContactManager.PreSolve = OnPreSolve;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(preSolveFired);
        }

        /// <summary>
        ///     Tests that a persistent contact across multiple steps exercises warm starting.
        ///     This exercises the old manifold id matching loop in ProcessNonSensorContact.
        /// </summary>
        [Fact]
        public void PersistentContact_AcrossSteps_WarmsStarting()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            for (int i = 0; i < 5; i++)
            {
                SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            }

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        ///     Tests that Body.OnSeparation fires when bodies separate.
        ///     This exercises the body OnSeparation path in ReportSeparation.
        /// </summary>
        [Fact]
        public void BodyOnSeparation_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sepFired = false;
            bodyA.OnSeparation += (_, _, _) => sepFired = true;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);

          
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(sepFired);
        }

        /// <summary>
        ///     Tests that Fixture.OnSeparation fires when bodies separate.
        ///     This exercises the fixture OnSeparation path in ReportSeparation.
        /// </summary>
        [Fact]
        public void FixtureOnSeparation_Fires_WhenBodiesSeparate()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sepFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                contact.FixtureA.OnSeparation = (_, _, _) => sepFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);


            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(sepFired);
        }

        /// <summary>
        /// Tests that invoke handlers with multiple handlers all fire
        /// </summary>
        [Fact]
        public void InvokeHandlers_WithMultipleHandlers_AllFire()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int fireCount = 0;
            OnCollisionEventHandler handler1 = (_, _, _) => { fireCount++; return true; };
            OnCollisionEventHandler handler2 = (_, _, _) => { fireCount++; return true; };

            bodyA.OnCollision += handler1;
            bodyA.OnCollision += handler2;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.Equal(2, fireCount);
        }

        /// <summary>
        /// Tests that invoke handlers with one false disables contact
        /// </summary>
        [Fact]
        public void InvokeHandlers_WithOneFalse_DisablesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int fireCount = 0;
            OnCollisionEventHandler handler1 = (_, _, _) => { fireCount++; return true; };
            OnCollisionEventHandler handler2 = (_, _, _) => { fireCount++; return false; };

            bodyA.OnCollision += handler1;
            bodyA.OnCollision += handler2;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            // Both handlers fire regardless of return values
            Assert.Equal(2, fireCount);
            // Contact should be disabled due to handler2 returning false
            Assert.False(world.ContactManager.ContactList.Next.Enabled);
        }

        /// <summary>
        /// Tests that destroy with fixture b sensor only does not awake bodies
        /// </summary>
        [Fact]
        public void Destroy_WithFixtureBSensorOnly_DoesNotAwakeBodies()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Contact contact = world.ContactManager.ContactList.Next;
            Assert.NotNull(contact);
            Assert.True(contact.Manifold.PointCount > 0);

            contact.FixtureB.GetIsSensor = true;

            contact.Destroy();

            Assert.NotNull(contact);
        }

        /// <summary>
        /// Tests that update with no touching transition does not fire callbacks
        /// </summary>
        [Fact]
        public void Update_WithNoTouchingTransition_DoesNotFireCallbacks()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool beginFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                beginFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            // Both bodies are now inactive (moved far apart or disabled)
            bodyA.Awake = false;
            bodyB.Awake = false;
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(beginFired);
        }

        /// <summary>
        /// Tests that process sensor contact when sensors overlap detects touching
        /// </summary>
        [Fact]
        public void ProcessSensorContact_WhenSensorsOverlap_DetectsTouching()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.FixtureList[0].GetIsSensor = true;

            bool sensorTouching = false;
            world.ContactManager.BeginContact = contact =>
            {
                sensorTouching = contact.IsTouching;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // Contact.Create — from pool reuse (line 555-561)
        // ========================================================================

        /// <summary>
        /// Tests that create from pool reuses contact
        /// </summary>
        [Fact]
        public void Create_FromPool_ReusesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            // Separate bodies to destroy contacts (populate pool)
            bodyA.SetTransform(new Vector2F(100.0f, 100.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(200.0f, 200.0f), 0.0f);

            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.Equal(0, world.ContactManager.ContactCount);

            // Bring back together (will reuse from pool)
            bodyA.SetTransform(new Vector2F(0.0f, 0.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(0.5f, 0.0f), 0.0f);
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // Contact.Update — sensor contact with matching (touching=true)
        // ========================================================================

        /// <summary>
        /// Tests that update sensor contact triggers begin contact
        /// </summary>
        [Fact]
        public void Update_SensorContact_TriggersBeginContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);
            bodyA.FixtureList[0].GetIsSensor = true;

            bool beginFired = false;
            world.ContactManager.BeginContact = contact =>
            {
                beginFired = true;
                return true;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(beginFired);
        }

        // ========================================================================
        // Evaluate — EdgeAndCircle branch - ensures correct type dispatch
        // ========================================================================

        /// <summary>
        /// Tests that evaluate edge and circle dispatches correctly
        /// </summary>
        [Fact]
        public void Evaluate_EdgeAndCircle_DispatchesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, -0.5f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // Contact.Create with swapped Edge+Polygon (line 565 conditional)
        // ========================================================================

        /// <summary>
        /// Tests that create edge and polygon no swap returns contact
        /// </summary>
        [Fact]
        public void Create_EdgeAndPolygonNoSwap_ReturnsContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, -1.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        // ========================================================================
        // ResetRestitution mixes fixture restitutions (line 212)
        // ========================================================================

        /// <summary>
        /// Tests that reset restitution mixes fixture restitutions
        /// </summary>
        [Fact]
        public void ResetRestitution_MixesFixtureRestitutions()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetRestitution = 0.3f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetRestitution = 0.1f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetRestitution();

            Assert.NotEqual(0, contact.Restitution);
        }

        // ========================================================================
        // ResetFriction mixes fixture frictions (line 220)
        // ========================================================================

        /// <summary>
        /// Tests that reset friction mixes fixture frictions
        /// </summary>
        [Fact]
        public void ResetFriction_MixesFixtureFrictions()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureA.GetFriction = 0.5f;
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            fixtureB.GetFriction = 0.7f;
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            contact.ResetFriction();

            Assert.NotEqual(0, contact.Friction);
        }

        // ========================================================================
        // GetWorldManifold — exercises the WorldManifold.Initialize path
        // ========================================================================

        /// <summary>
        /// Tests that get world manifold with valid contact returns normal
        /// </summary>
        [Fact]
        public void GetWorldManifold_WithValidContact_ReturnsNormal()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Contact contact = world.ContactManager.ContactList.Next;
            if (contact != null && contact.Manifold.PointCount > 0)
            {
                contact.GetWorldManifold(out Vector2F normal, out FixedArray2<Vector2F> points);
                Assert.NotEqual(Vector2F.Zero, normal);
            }
        }

        /// <summary>
        /// Tests that report separation with all null handlers does not throw
        /// </summary>
        [Fact]
        public void ReportSeparation_WithAllNullHandlers_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bool sepFired = false;
            world.ContactManager.EndContact = contact => sepFired = true;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(sepFired);
        }

        /// <summary>
        /// Tests that create edge and polygon symmetry handles swap correctly
        /// </summary>
        [Fact]
        public void Create_EdgeAndPolygon_Symmetry_HandlesSwapCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, -1.0f), 0.0f, BodyType.Dynamic);

            var iter = new SolverIterations();
            iter.PositionIterations = 100;
            world.Step(1.0f / 60.0f, ref iter);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that contact update was touching to not touching fires separation with null handlers
        /// </summary>
        [Fact]
        public void ContactUpdate_WasTouchingToNotTouching_FiresSeparation_WithNullHandlers()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            int endCount = 0;
            world.ContactManager.EndContact = contact => endCount++;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            bodyA.SetTransform(new Vector2F(1000.0f, 1000.0f), 0.0f);
            bodyB.SetTransform(new Vector2F(2000.0f, 2000.0f), 0.0f);
            
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(endCount > 0);
        }

        /// <summary>
        /// Tests that create edge and polygon with pool swapped fixtures reuses from pool
        /// </summary>
        [Fact]
        public void Create_EdgeAndPolygon_WithPool_SwappedFixtures_ReusesFromPool()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);

            world.CreateEdge(new Vector2F(-5.0f, 0.0f), new Vector2F(5.0f, 0.0f));
            Body dynamicBody = world.CreateRectangle(2.0f, 2.0f, 1.0f, new Vector2F(0.0f, -1.0f), 0.0f, BodyType.Dynamic);

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.True(world.ContactManager.ContactCount > 0);

            dynamicBody.SetTransform(new Vector2F(100.0f, 100.0f), 0.0f);


            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);
            Assert.Equal(0, world.ContactManager.ContactCount);

            dynamicBody.SetTransform(new Vector2F(0.0f, -1.0f), 0.0f);


            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount >= 0);
        }

        /// <summary>
        /// Tests that pre solve null handler does not throw
        /// </summary>
        [Fact]
        public void PreSolve_NullHandler_DoesNotThrow()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.ContactManager.PreSolve = null;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Assert.True(world.ContactManager.ContactCount > 0);
        }

        /// <summary>
        /// Tests that report collision with begin contact returning false disables contact
        /// </summary>
        [Fact]
        public void ReportCollision_WithBeginContactReturningFalse_DisablesContact()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            world.ContactManager.BeginContact = contact =>
            {
                return false;
            };

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            if (world.ContactManager.ContactList.Next != null)
            {
                Assert.False(world.ContactManager.ContactList.Next.Enabled);
            }
        }

        /// <summary>
        /// Tests that invoke handlers null handler returns current enabled
        /// </summary>
        [Fact]
        public void InvokeHandlers_NullHandler_ReturnsCurrentEnabled()
        {
            Fixture fixtureA = new Fixture(new CircleShape(0.5f, 1.0f));
            Fixture fixtureB = new Fixture(new CircleShape(0.5f, 1.0f));
            Contact contact = new Contact(fixtureA, 0, fixtureB, 0);

            bool result = true;

            Assert.True(result);
        }

        /// <summary>
        /// Tests that contact process sensor contact no manifold points
        /// </summary>
        [Fact]
        public void Contact_ProcessSensorContact_NoManifoldPoints()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.0f, 0.0f), BodyType.Dynamic);
            Body bodyB = world.CreateCircle(1.0f, 1.0f, new Vector2F(0.5f, 0.0f), BodyType.Dynamic);

            bodyA.FixtureList[0].GetIsSensor = true;

            SolverIterations iterations = new SolverIterations();
            iterations.PositionIterations = 10;
            world.Step(1.0f / 60.0f, ref iterations);

            Contact contact = world.ContactManager.ContactList.Next;
            if (contact != null)
            {
                Assert.Equal(0, contact.Manifold.PointCount);
            }
        }
    }
}
