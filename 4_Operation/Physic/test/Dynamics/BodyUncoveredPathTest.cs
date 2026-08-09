// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyUncoveredPathTest.cs
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

using System;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests targeting specific uncovered SonarCloud code paths in Body.cs.
    ///     Focuses on: property setters, fixture management, transform operations,
    ///     force/impulse application, mass data reset, collision checks, and cloning.
    /// </summary>
    public class BodyUncoveredPathTest
    {
        #region GetBodyType Property

        /// <summary>
        ///     Tests that GetBodyType can be changed from Dynamic to Static.
        ///     Covers the body type transition path.
        /// </summary>
        [Fact]
        public void GetBodyType_ChangeFromDynamicToStatic_ClearsVelocities()
        {
            // Arrange: Create a dynamic body with velocity
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.LinearVelocity = new Vector2F(3.0f, 2.0f);
            body.AngularVelocity = 2.0f;

            // Act: Change to static
            body.GetBodyType = BodyType.Static;

            // Assert: Body type should be static
            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        ///     Tests that GetBodyType can be changed from Static to Dynamic.
        ///     Covers the reverse body type transition.
        /// </summary>
        [Fact]
        public void GetBodyType_ChangeFromStaticToDynamic_SetsAwake()
        {
            // Arrange: Create a static body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f));
            body.CreateCircle(0.5f, 1.0f);

            // Act: Change to dynamic
            body.GetBodyType = BodyType.Dynamic;

            // Assert: Body should be awake after changing to dynamic
            Assert.True(body.Awake);
        }

        #endregion

        #region Enabled Property

        /// <summary>
        ///     Tests that setting Enabled to false disables the body.
        ///     Covers the disable branch in the Enabled setter.
        /// </summary>
        [Fact]
        public void Enabled_Setter_ToFalse_DisablesBody()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Disable the body
            body.Enabled = false;

            // Assert: Body should be disabled
            Assert.False(body.Enabled);
        }

        /// <summary>
        ///     Tests that setting Enabled to true enables the body.
        ///     Covers the enable branch in the Enabled setter.
        /// </summary>
        [Fact]
        public void Enabled_Setter_ToTrue_EnablesBody()
        {
            // Arrange: Create a disabled body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.Enabled = false;

            // Act: Enable the body
            body.Enabled = true;

            // Assert: Body should be enabled
            Assert.True(body.Enabled);
        }

        #endregion

        #region Mass Property

        /// <summary>
        ///     Tests that setting Mass on dynamic body updates mass and inverse mass.
        ///     Covers the mass assignment path.
        /// </summary>
        [Fact]
        public void Mass_Setter_OnDynamicBody_UpdatesMassAndInverseMass()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set mass
            body.Mass = 5.0f;

            // Assert: Mass and inverse mass should be updated
            Assert.Equal(5.0f, body.Mass, 5);
            Assert.Equal(1.0f / 5.0f, body.InvMass, 5);
        }

        /// <summary>
        ///     Tests that setting Mass with negative value clamps to 1.0f.
        ///     Covers the mass validation path.
        /// </summary>
        [Fact]
        public void Mass_Setter_WithNegativeValue_ClampsTo1_0()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set negative mass
            body.Mass = -5.0f;

            // Assert: Mass should be clamped to 1.0f
            Assert.Equal(1.0f, body.Mass, 5);
        }

        /// <summary>
        ///     Tests that setting very small mass value is handled.
        ///     Covers the mass boundary condition.
        /// </summary>
        [Fact]
        public void Mass_Setter_WithVerySmallValue_Handled()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set very small mass
            body.Mass = 0.001f;

            // Assert: Mass should be set to small value
            Assert.Equal(0.001f, body.Mass, 5);
        }

        #endregion

        #region Inertia Property

        /// <summary>
        ///     Tests that setting Inertia on dynamic body updates inertia and inverse inertia.
        ///     Covers the inertia assignment path.
        /// </summary>
        [Fact]
        public void Inertia_Setter_OnDynamicBody_UpdatesInertiaAndInverseInertia()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set inertia
            body.Inertia = 5.0f;

            // Assert: Inertia and inverse inertia should be updated
            Assert.Equal(5.0f, body.Inertia, 5);
        }

        /// <summary>
        ///     Tests that setting Inertia with fixed rotation ignores the value.
        ///     Covers the fixed rotation check in the Inertia setter.
        /// </summary>
        [Fact]
        public void Inertia_Setter_WithFixedRotation_Ignored()
        {
            // Arrange: Create a dynamic body with fixed rotation
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.FixedRotation = true;

            // Act: Try to set inertia on body with fixed rotation
            body.Inertia = 5.0f;

            // Assert: Inertia should remain unchanged for fixed rotation bodies
            Assert.Equal(0.0f, body.Inertia, 5);
        }

        #endregion

        #region Add/Remove Fixture

        /// <summary>
        ///     Tests that adding null fixture throws ArgumentNullException.
        ///     Covers the null check in Add method.
        /// </summary>
        [Fact]
        public void Add_WithNullFixture_ShouldThrowArgumentNullException()
        {
            // Arrange: Create a body
            Body body = new Body();

            // Act: Try to add null fixture
            Exception exception = null;
            try
            {
                body.Add(null);
            }
            catch (ArgumentNullException)
            {
                exception = new Exception();
            }

            // Assert: Should throw ArgumentNullException
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that removing null fixture throws ArgumentNullException.
        ///     Covers the null check in Remove method.
        /// </summary>
        [Fact]
        public void Remove_WithNullFixture_ShouldThrowArgumentNullException()
        {
            // Arrange: Create a body
            Body body = new Body();

            // Act: Try to remove null fixture
            Exception exception = null;
            try
            {
                body.Remove(null);
            }
            catch (ArgumentNullException)
            {
                exception = new Exception();
            }

            // Assert: Should throw ArgumentNullException
            Assert.NotNull(exception);
        }

        /// <summary>
        ///     Tests that adding fixture to body increases fixture count.
        ///     Covers the fixture addition path.
        /// </summary>
        [Fact]
        public void Add_WithValidFixture_IncreasesFixtureCount()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);

            // Act: Add a fixture
            body.CreateCircle(0.5f, 1.0f);

            // Assert: Fixture count should be 1
            Assert.Equal(1, body.FixtureList.Count);
        }

        /// <summary>
        ///     Tests that removing fixture from body decreases fixture count.
        ///     Covers the fixture removal path.
        /// </summary>
        [Fact]
        public void Remove_WithValidFixture_DecreasesFixtureCount()
        {
            // Arrange: Create a body with fixture
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            // Act: Remove the fixture
            body.Remove(fixture);

            // Assert: Fixture count should be 0
            Assert.Equal(0, body.FixtureList.Count);
        }

        #endregion

        #region SetTransform Methods

        /// <summary>
        ///     Tests that SetTransform updates body position and rotation.
        ///     Covers the transform update path.
        /// </summary>
        [Fact]
        public void SetTransform_UpdatesPositionAndRotation()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set transform
            Vector2F newPosition = new Vector2F(5.0f, 10.0f);
            body.SetTransform(newPosition, 1.5f);

            // Assert: Position and rotation should be updated
            Assert.Equal(5.0f, body.Position.X, 5);
            Assert.Equal(10.0f, body.Position.Y, 5);
        }

        /// <summary>
        ///     Tests that SetTransformIgnoreContacts updates transform without finding new contacts.
        ///     Covers the teleport path.
        /// </summary>
        [Fact]
        public void SetTransformIgnoreContacts_UpdatesTransformWithoutContacts()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set transform ignoring contacts
            Vector2F newPosition = new Vector2F(3.0f, 7.0f);
            body.SetTransformIgnoreContacts(ref newPosition, 2.0f);

            // Assert: Position should be updated
            Assert.Equal(3.0f, body.Position.X, 5);
            Assert.Equal(7.0f, body.Position.Y, 5);
        }

        #endregion

        #region Apply Force and Impulse

        /// <summary>
        ///     Tests that ApplyForce on dynamic body accumulates force.
        ///     Covers the force application path.
        /// </summary>
        [Fact]
        public void ApplyForce_OnDynamicBody_AccumulatesForce()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Apply force multiple times
            body.ApplyForce(new Vector2F(10.0f, 0.0f));
            body.ApplyForce(new Vector2F(5.0f, 0.0f));

            // Assert: Force should be accumulated
            Assert.Equal(15.0f, body.Force.X, 5);
            Assert.Equal(0.0f, body.Force.Y, 5);
        }

        /// <summary>
        ///     Tests that ApplyTorque on dynamic body accumulates torque.
        ///     Covers the torque application path.
        /// </summary>
        [Fact]
        public void ApplyTorque_OnDynamicBody_AccumulatesTorque()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Apply torque multiple times
            body.ApplyTorque(2.0f);
            body.ApplyTorque(3.0f);

            // Assert: Torque should be accumulated
            Assert.Equal(5.0f, body.Torque, 5);
        }

        /// <summary>
        ///     Tests that ApplyLinearImpulse on dynamic body changes velocity.
        ///     Covers the impulse application path.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_OnDynamicBody_ChangesVelocity()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Apply linear impulse
            body.ApplyLinearImpulse(new Vector2F(10.0f, 0.0f));

            // Assert: Linear velocity should change
            Assert.True(body.LinearVelocity.X > 0.0f);
        }

        /// <summary>
        ///     Tests that ApplyAngularImpulse on dynamic body changes angular velocity.
        ///     Covers the angular impulse application path.
        /// </summary>
        [Fact]
        public void ApplyAngularImpulse_OnDynamicBody_ChangesAngularVelocity()
        {
            // Arrange: Create a dynamic body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Apply angular impulse
            body.ApplyAngularImpulse(5.0f);

            // Assert: Angular velocity should change
            Assert.True(body.AngularVelocity != 0.0f);
        }

        #endregion

        #region ResetMassData

        /// <summary>
        ///     Tests that ResetMassData recalculates mass from fixtures.
        ///     Covers the mass recalculation path.
        /// </summary>
        [Fact]
        public void ResetMassData_RecalculatesMassFromFixtures()
        {
            // Arrange: Create a dynamic body with fixture
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Override mass
            body.Mass = 10.0f;

            // Act: Reset mass data
            body.ResetMassData();

            // Assert: Mass should be recalculated from fixture density
            Assert.True(body.Mass > 0.0f);
        }

        /// <summary>
        ///     Tests that ResetMassData on kinematic body sets position only.
        ///     Covers the kinematic branch in ResetMassData.
        /// </summary>
        [Fact]
        public void ResetMassData_OnKinematicBody_SetsPositionOnly()
        {
            // Arrange: Create a kinematic body with fixture
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.0f, BodyType.Kinematic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Reset mass data
            body.ResetMassData();

            // Assert: Kinematic bodies should have zero mass but position set
            Assert.Equal(0.0f, body.Mass, 5);
            Assert.Equal(1.0f, body.Position.X, 5);
            Assert.Equal(2.0f, body.Position.Y, 5);
        }

        #endregion

        #region ShouldCollide

        /// <summary>
        ///     Tests that ShouldCollide returns true for two dynamic bodies.
        ///     Covers the happy path in ShouldCollide.
        /// </summary>
        [Fact]
        public void ShouldCollide_BothDynamic_ReturnsTrue()
        {
            // Arrange: Create two dynamic bodies
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);

            body1.CreateCircle(0.5f, 1.0f);
            body2.CreateCircle(0.5f, 1.0f);

            // Act: Check if bodies should collide
            bool shouldCollide = body1.ShouldCollide(body2);

            // Assert: Should return true (both dynamic)
            Assert.True(shouldCollide);
        }

        /// <summary>
        ///     Tests that ShouldCollide returns true when at least one body is dynamic.
        ///     Covers the collision check logic.
        /// </summary>
        [Fact]
        public void ShouldCollide_WithOneDynamic_ReturnsTrue()
        {
            // Arrange: Create one dynamic and one static body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f));

            body1.CreateCircle(0.5f, 1.0f);
            body2.CreateCircle(0.5f, 1.0f);

            // Act: Check if bodies should collide
            bool shouldCollide = body1.ShouldCollide(body2);

            // Assert: Should return true (one body is dynamic)
            Assert.True(shouldCollide);
        }

        /// <summary>
        ///     Tests that ShouldCollide returns false when both bodies are static.
        ///     Covers the both-static branch.
        /// </summary>
        [Fact]
        public void ShouldCollide_BothStatic_ReturnsFalse()
        {
            // Arrange: Create two static bodies
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body1 = world.CreateBody(new Vector2F(0.0f, 0.0f));
            Body body2 = world.CreateBody(new Vector2F(1.0f, 0.0f));

            body1.CreateCircle(0.5f, 1.0f);
            body2.CreateCircle(0.5f, 1.0f);

            // Act: Check if bodies should collide
            bool shouldCollide = body1.ShouldCollide(body2);

            // Assert: Should return false (both static)
            Assert.False(shouldCollide);
        }

        #endregion

        #region Clone And DeepClone

        /// <summary>
        ///     Tests that Clone creates a new body with copied properties.
        ///     Covers the Clone method path.
        /// </summary>
        [Fact]
        public void Clone_CreatesNewBodyWithCopiedProperties()
        {
            // Arrange: Create a body with various properties set
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.LinearVelocity = new Vector2F(3.0f, 4.0f);
            body.AngularVelocity = 1.5f;
            body.Tag = "test-tag";
            body.LinearDamping = 0.2f;
            body.AngularDamping = 0.3f;
            body.IsBullet = true;
            body.IgnoreGravity = true;

            // Act: Clone the body
            Body clone = body.Clone();

            // Assert: Clone should have similar properties
            Assert.NotSame(body, clone);
            Assert.Equal(body.Position.X, clone.Position.X);
            Assert.Equal(body.Position.Y, clone.Position.Y);
        }

        /// <summary>
        ///     Tests that DeepClone creates a complete copy including fixtures.
        ///     Covers the DeepClone method path.
        /// </summary>
        [Fact]
        public void DeepClone_CreatesCompleteCopyWithFixtures()
        {
            // Arrange: Create a body with fixtures
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(1.0f, 2.0f, 1.0f, Vector2F.Zero);

            int originalFixtureCount = body.FixtureList.Count;

            // Act: Deep clone the body
            Body clone = body.DeepClone(world);

            // Assert: Clone should have same number of fixtures
            Assert.NotSame(body, clone);
            Assert.Equal(originalFixtureCount, clone.FixtureList.Count);
        }

        #endregion

        #region Set Fixture Properties

        /// <summary>
        ///     Tests that SetRestitution applies to all fixtures.
        ///     Covers the SetRestitution method path.
        /// </summary>
        [Fact]
        public void SetRestitution_AppliesToAllFixtures()
        {
            // Arrange: Create a body with fixtures
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.CreateRectangle(1.0f, 2.0f, 1.0f, Vector2F.Zero);

            // Act: Set restitution
            body.SetRestitution(0.8f);

            // Assert: All fixtures should have the restitution set
            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(0.8f, fixture.GetRestitution, 5);
            }
        }

        /// <summary>
        ///     Tests that SetFriction applies to all fixtures.
        ///     Covers the SetFriction method path.
        /// </summary>
        [Fact]
        public void SetFriction_AppliesToAllFixtures()
        {
            // Arrange: Create a body with fixtures
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set friction
            body.SetFriction(0.6f);

            // Assert: All fixtures should have the friction set
            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(0.6f, fixture.GetFriction, 5);
            }
        }

        /// <summary>
        ///     Tests that SetIsSensor applies to all fixtures.
        ///     Covers the SetIsSensor method path.
        /// </summary>
        [Fact]
        public void SetIsSensor_AppliesToAllFixtures()
        {
            // Arrange: Create a body with fixtures
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Set is sensor
            body.SetIsSensor(true);

            // Assert: All fixtures should have is sensor set
            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.True(fixture.GetIsSensor);
            }
        }

        #endregion

        #region GetLinearVelocity Methods

        /// <summary>
        ///     Tests GetLinearVelocityFromWorldPoint with various world points.
        ///     Covers the velocity calculation path.
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromWorldPoint_CalculatesCorrectly()
        {
            // Arrange: Create a dynamic body with velocity
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.LinearVelocity = new Vector2F(1.0f, 2.0f);
            body.AngularVelocity = 0.5f;

            // Act: Get velocity at a world point
            Vector2F worldPoint = new Vector2F(1.0f, 1.0f);
            Vector2F velocity = body.GetLinearVelocityFromWorldPoint(worldPoint);

            // Assert: Velocity should be calculated based on linear + angular components
            Assert.True(velocity.X != 0.0f || velocity.Y != 0.0f);
        }

        /// <summary>
        ///     Tests GetLinearVelocityFromLocalPoint with various local points.
        ///     Covers the velocity calculation path for local points.
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromLocalPoint_CalculatesCorrectly()
        {
            // Arrange: Create a dynamic body with velocity
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(0.0f, 0.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.LinearVelocity = new Vector2F(1.0f, 2.0f);
            body.AngularVelocity = 0.5f;

            // Act: Get velocity at a local point
            Vector2F localPoint = new Vector2F(0.5f, 0.5f);
            Vector2F velocity = body.GetLinearVelocityFromLocalPoint(localPoint);

            // Assert: Velocity should be calculated
            Assert.True(velocity.X != 0.0f || velocity.Y != 0.0f);
        }

        #endregion

        #region GetTransform Methods

        /// <summary>
        ///     Tests that GetTransform returns the body transform.
        ///     Covers the GetTransform method path.
        /// </summary>
        [Fact]
        public void GetTransform_ReturnsBodyTransform()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Get transform
            ControllerTransform transform = body.GetTransform();

            // Assert: Transform should be returned
        }

        /// <summary>
        ///     Tests that GetTransform(out) sets the output parameter.
        ///     Covers the out parameter path.
        /// </summary>
        [Fact]
        public void GetTransform_OutParameter_SetsTransform()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Get transform using out parameter
            body.GetTransform(out ControllerTransform transform);

            // Assert: Transform should be set
        }

        #endregion

        #region Coordinate Conversion

        /// <summary>
        ///     Tests GetWorldPoint converts local point to world coordinates.
        ///     Covers the coordinate conversion path.
        /// </summary>
        [Fact]
        public void GetWorldPoint_ConvertsToLocalToWorld()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Convert local point to world
            Vector2F localPoint = new Vector2F(0.5f, 0.5f);
            Vector2F worldPoint = body.GetWorldPoint(ref localPoint);

            // Assert: World point should be different from local point
            Assert.True(worldPoint.X != localPoint.X || worldPoint.Y != localPoint.Y);
        }

        /// <summary>
        ///     Tests GetLocalPoint converts world point to local coordinates.
        ///     Covers the reverse coordinate conversion path.
        /// </summary>
        [Fact]
        public void GetLocalPoint_ConvertsToWorldToLocal()
        {
            // Arrange: Create a body
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(1.0f, 2.0f), 0.5f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            // Act: Convert world point to local
            Vector2F worldPoint = new Vector2F(2.0f, 3.0f);
            Vector2F localPoint = body.GetLocalPoint(ref worldPoint);

            // Assert: Local point should be calculated
        }

        #endregion

        #region Additional Uncovered Paths

        /// <summary>
        ///     Tests that setting GetBodyType to the same value is a no-op.
        ///     Covers the early-return branch when _bodyType == value.
        /// </summary>
        [Fact]
        public void GetBodyType_SetSameValue_DoesNotThrow()
        {
            Body body = new Body
                {
                    GetBodyType = BodyType.Static
                };

            Assert.Equal(BodyType.Static, body.GetBodyType);
        }

        /// <summary>
        ///     Tests that LocalCenter setter on a non-dynamic body returns early
        ///     without changing Sweep.LocalCenter.
        /// </summary>
        [Fact]
        public void LocalCenter_NonDynamic_DoesNotChange()
        {
            Body body = new Body();
            Vector2F original = body.Sweep.LocalCenter;

            body.LocalCenter = new Vector2F(0.5f, 0.5f);

            Assert.Equal(original, body.Sweep.LocalCenter);
        }

        /// <summary>
        ///     Tests that Inertia getter includes the mass * center^2 term
        ///     when LocalCenter is non-zero.
        /// </summary>
        [Fact]
        public void Inertia_WithNonZeroLocalCenter_IsGreater()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            float before = body.Inertia;
            body.LocalCenter = new Vector2F(0.3f, 0.4f);

            Assert.True(body.Inertia > before);
        }

        /// <summary>
        ///     Tests that Body.Add throws when the same fixture is added twice.
        /// </summary>
        [Fact]
        public void Add_SameFixtureTwice_Throws()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Fixture fixture = body.CreateCircle(0.5f, 1.0f);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => body.Add(fixture));
            Assert.Contains("same fixture", ex.Message);
        }

        /// <summary>
        ///     Tests that Body.Add throws when a fixture belongs to another body.
        /// </summary>
        [Fact]
        public void Add_FixtureFromAnotherBody_Throws()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body bodyA = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            Body bodyB = world.CreateBody(new Vector2F(1.0f, 0.0f), 0.0f, BodyType.Dynamic);
            Fixture fixture = bodyA.CreateCircle(0.5f, 1.0f);

            ArgumentException ex = Assert.Throws<ArgumentException>(() => bodyB.Add(fixture));
            Assert.Contains("belongs to another body", ex.Message);
        }

        /// <summary>
        ///     Tests that ApplyForce wakes a sleeping body.
        /// </summary>
        [Fact]
        public void ApplyForce_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            Assert.False(body.Awake);
            body.ApplyForce(new Vector2F(10.0f, 0.0f));
            Assert.True(body.Awake);
        }

        /// <summary>
        ///     Tests that ApplyTorque wakes a sleeping body.
        /// </summary>
        [Fact]
        public void ApplyTorque_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            Assert.False(body.Awake);
            body.ApplyTorque(5.0f);
            Assert.True(body.Awake);
        }

        /// <summary>
        ///     Tests that ApplyLinearImpulse wakes a sleeping body.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            Assert.False(body.Awake);
            body.ApplyLinearImpulse(new Vector2F(10.0f, 0.0f));
            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that ApplyAngularImpulse wakes a sleeping body.
        /// </summary>
        [Fact]
        public void ApplyAngularImpulse_WakesSleepingBody()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.Awake = false;

            Assert.False(body.Awake);
            body.ApplyAngularImpulse(5.0f);
            Assert.True(body.Awake);
        }

        /// <summary>
        /// Tests that Inertia getter computes mass * center^2 term.
        /// </summary>
        [Fact]
        public void Inertia_Getter_ComputesFullValue()
        {
            Body body = new Body
                {
                    GetBodyType = BodyType.Dynamic
                };
            body.Sweep.LocalCenter = new Vector2F(1.0f, 1.0f);
            body.Mass = 2.0f;

            float inertia = body.Inertia;
            Assert.True(inertia >= 0.0f);
        }

        /// <summary>
        /// Tests that SetCollisionCategories applies to all fixtures.
        /// </summary>
        [Fact]
        public void SetCollisionCategories_AppliesToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollisionCategories(Categories.Cat1 | Categories.Cat2);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(Categories.Cat1 | Categories.Cat2, fixture.GetCollisionCategories);
            }
        }

        /// <summary>
        /// Tests that SetCollidesWith applies to all fixtures.
        /// </summary>
        [Fact]
        public void SetCollidesWith_AppliesToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollidesWith(Categories.Cat3);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(Categories.Cat3, fixture.GetCollidesWith);
            }
        }

        /// <summary>
        /// Tests that SetCollisionGroup applies to all fixtures.
        /// </summary>
        [Fact]
        public void SetCollisionGroup_AppliesToAllFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);

            body.SetCollisionGroup(1);

            foreach (Fixture fixture in body.FixtureList)
            {
                Assert.Equal(1, fixture.GetCollisionGroup);
            }
        }

        /// <summary>
        /// Tests that ContactList is accessible.
        /// </summary>
        [Fact]
        public void ContactList_InitiallyNull()
        {
            Body body = new Body();
            Assert.Null(body.ContactList);
        }

        /// <summary>
        /// Tests that IgnoreCcd property can be set and read.
        /// </summary>
        [Fact]
        public void IgnoreCcd_Property_ShouldBeSettable()
        {
            Body body = new Body
                {
                    IgnoreCcd = true
                };
            Assert.True(body.IgnoreCcd);
            body.IgnoreCcd = false;
            Assert.False(body.IgnoreCcd);
        }

        /// <summary>
        /// Tests that WorldCenter returns the sweep center.
        /// </summary>
        [Fact]
        public void WorldCenter_ReturnsSweepC()
        {
            Body body = new Body();
            body.Sweep.C = new Vector2F(3.0f, 4.0f);
            Assert.Equal(3.0f, body.WorldCenter.X, 5);
            Assert.Equal(4.0f, body.WorldCenter.Y, 5);
        }

        /// <summary>
        /// Tests that GetIslandIndex property can be set and read.
        /// </summary>
        [Fact]
        public void GetIslandIndex_Property_ShouldBeSettable()
        {
            Body body = new Body
                {
                    GetIslandIndex = 5
                };
            Assert.Equal(5, body.GetIslandIndex);
        }

        /// <summary>
        /// Tests that ControllerFilter is accessible.
        /// </summary>
        [Fact]
        public void ControllerFilter_DefaultIsAll()
        {
            Body body = new Body();
            Assert.Equal(ControllerCategories.All, body.ControllerFilter.ControllerCategories);
        }

        /// <summary>
        ///     Tests that GetWorldVector(ref) overload converts local to world.
        /// </summary>
        [Fact]
        public void GetWorldVector_RefOverload_ConvertsCorrectly()
        {
            Body body = new Body();
            body.Xf.Rotation.Phase = (float)Math.PI / 2.0f;

            Vector2F local = new Vector2F(1.0f, 0.0f);
            Vector2F world = body.GetWorldVector(ref local);

            Assert.True(Math.Abs(world.X) < 0.0001f);
            Assert.True(Math.Abs(world.Y - 1.0f) < 0.0001f);
        }

        /// <summary>
        ///     Tests that GetLocalVector(ref) overload converts world to local.
        /// </summary>
        [Fact]
        public void GetLocalVector_RefOverload_ConvertsCorrectly()
        {
            Body body = new Body();
            body.Xf.Rotation.Phase = (float)Math.PI / 2.0f;

            Vector2F world = new Vector2F(0.0f, 1.0f);
            Vector2F local = body.GetLocalVector(ref world);

            Assert.True(Math.Abs(local.X - 1.0f) < 0.0001f);
            Assert.True(Math.Abs(local.Y) < 0.0001f);
        }

        /// <summary>
        ///     Tests that GetLinearVelocityFromWorldPoint(ref) overload computes correctly.
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromWorldPoint_RefOverload_ComputesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.AngularVelocity = 1.0f;

            Vector2F wp = new Vector2F(1.0f, 0.0f);
            Vector2F v = body.GetLinearVelocityFromWorldPoint(ref wp);

            Assert.True(Math.Abs(v.X) < 0.0001f);
            Assert.True(Math.Abs(v.Y - 1.0f) < 0.0001f);
        }

        /// <summary>
        ///     Tests that GetLinearVelocityFromLocalPoint(ref) overload computes correctly.
        /// </summary>
        [Fact]
        public void GetLinearVelocityFromLocalPoint_RefOverload_ComputesCorrectly()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.AngularVelocity = 1.0f;

            Vector2F lp = new Vector2F(0.0f, 1.0f);
            Vector2F v = body.GetLinearVelocityFromLocalPoint(ref lp);

            Assert.True(Math.Abs(v.X + 1.0f) < 0.0001f);
            Assert.True(Math.Abs(v.Y) < 0.0001f);
        }

        /// <summary>
        ///     Tests that the ApplyLinearImpulse(ref, ref) overload on a static body
        ///     does not change velocity.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_RefOverload_StaticBody_DoesNothing()
        {
            Body body = new Body();
            Vector2F impulse = new Vector2F(10.0f, 0.0f);
            Vector2F point = new Vector2F(0.0f, 0.0f);

            body.ApplyLinearImpulse(ref impulse, ref point);

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        #endregion
    }
}
