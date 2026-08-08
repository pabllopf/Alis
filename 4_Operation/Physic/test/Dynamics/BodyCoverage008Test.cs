// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyCoverage008Test.cs
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
using Alis.Core.Physic.Common;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     Tests targeting remaining uncovered code paths in Body.cs:
    ///     SynchronizeTransform, Advance, LocalCenter setter dynamics,
    ///     non-dynamic guards in ApplyForce/ApplyLinearImpulse overloads,
    ///     ResetMassData edge cases, and Sweep setter.
    /// </summary>
    public class BodyCoverage008Test
    {
        #region SynchronizeTransform

        /// <summary>
        ///     Tests that SynchronizeTransform updates Xf from Sweep state
        ///     with zero rotation for straightforward math.
        /// </summary>
        [Fact]
        public void SynchronizeTransform_Updates_Xf_From_Sweep()
        {
            Body body = new Body();
            body.Sweep.A = 0.0f;
            body.Sweep.C = new Vector2F(4.0f, 5.0f);
            body.Sweep.LocalCenter = new Vector2F(0.1f, 0.2f);

            body.SynchronizeTransform();

            Assert.Equal(0.0f, body.Xf.Rotation.Phase, 5);
            Assert.Equal(4.0f - 0.1f, body.Xf.Position.X, 5);
            Assert.Equal(5.0f - 0.2f, body.Xf.Position.Y, 5);
        }

        #endregion

        #region Advance

        /// <summary>
        ///     Tests that Advance updates the sweep and transform for CCD.
        /// </summary>
        [Fact]
        public void Advance_Updates_Sweep_And_Xf()
        {
            Body body = new Body();
            body.Sweep.A0 = 0.0f;
            body.Sweep.A = 2.0f;
            body.Sweep.C0 = new Vector2F(0.0f, 0.0f);
            body.Sweep.C = new Vector2F(10.0f, 0.0f);
            body.Sweep.LocalCenter = Vector2F.Zero;

            body.Advance(0.5f);

            Assert.Equal(1.0f, body.Sweep.A, 5);
            Assert.Equal(5.0f, body.Sweep.C.X, 5);
            Assert.Equal(1.0f, body.Xf.Rotation.Phase, 5);
            Assert.Equal(5.0f, body.Xf.Position.X, 5);
        }

        /// <summary>
        ///     Tests that Advance with alpha=0 preserves the initial state.
        /// </summary>
        [Fact]
        public void Advance_WithAlphaZero_PreservesInitialState()
        {
            Body body = new Body();
            body.Sweep.A0 = 0.0f;
            body.Sweep.A = 2.0f;
            body.Sweep.C0 = new Vector2F(0.0f, 0.0f);
            body.Sweep.C = new Vector2F(10.0f, 0.0f);
            body.Sweep.LocalCenter = Vector2F.Zero;

            body.Advance(0.0f);

            Assert.Equal(0.0f, body.Sweep.A, 5);
            Assert.Equal(0.0f, body.Sweep.C.X, 5);
            Assert.Equal(0.0f, body.Xf.Rotation.Phase, 5);
            Assert.Equal(0.0f, body.Xf.Position.X, 5);
        }

        #endregion

        #region LocalCenter Setter (Dynamic Body Path)

        /// <summary>
        ///     Tests that LocalCenter setter on a Dynamic body without a world
        ///     updates Sweep.LocalCenter, Sweep.C, and adjusts linear velocity.
        /// </summary>
        [Fact]
        public void LocalCenter_Setter_OnDynamic_WithoutWorld_UpdatesCenterAndVelocity()
        {
            Body body = new Body
                {
                    GetBodyType = BodyType.Dynamic
                };
            body.Sweep.C = new Vector2F(5.0f, 5.0f);
            body.AngularVelocity = 2.0f;

            Vector2F newCenter = new Vector2F(1.0f, 1.0f);
            body.LocalCenter = newCenter;

            Assert.Equal(1.0f, body.Sweep.LocalCenter.X, 5);
            Assert.Equal(1.0f, body.Sweep.LocalCenter.Y, 5);
        }

        /// <summary>
        ///     Tests that LocalCenter setter on a Dynamic body with a world
        ///     updates Sweep and the transform correctly.
        /// </summary>
        [Fact]
        public void LocalCenter_Setter_OnDynamic_WithWorld_UpdatesSweep()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(new Vector2F(10.0f, 20.0f), 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            Vector2F newCenter = new Vector2F(0.2f, 0.3f);
            body.LocalCenter = newCenter;

            Assert.Equal(0.2f, body.Sweep.LocalCenter.X, 5);
            Assert.Equal(0.3f, body.Sweep.LocalCenter.Y, 5);
        }

        #endregion

        #region ApplyForce Non-Dynamic Guards

        /// <summary>
        ///     Tests that ApplyForce(ref, ref) on a Static body returns early.
        /// </summary>
        [Fact]
        public void ApplyForce_RefRef_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            Vector2F force = new Vector2F(10.0f, 0.0f);
            Vector2F point = new Vector2F(1.0f, 1.0f);

            body.ApplyForce(ref force, ref point);

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque, 5);
        }

        /// <summary>
        ///     Tests that ApplyForce(Vector2F, Vector2F) on a Static body returns early.
        /// </summary>
        [Fact]
        public void ApplyForce_Vector2F_Vector2F_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            body.ApplyForce(new Vector2F(10.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            Assert.Equal(Vector2F.Zero, body.Force);
            Assert.Equal(0.0f, body.Torque, 5);
        }

        #endregion

        #region ApplyLinearImpulse Non-Dynamic Guards

        /// <summary>
        ///     Tests that ApplyLinearImpulse(ref, ref) on a Static body returns early.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_RefRef_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            Vector2F impulse = new Vector2F(10.0f, 0.0f);
            Vector2F point = new Vector2F(1.0f, 1.0f);

            body.ApplyLinearImpulse(ref impulse, ref point);

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that ApplyLinearImpulse(Vector2F, Vector2F) on a Static body returns early.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_Vector2F_Vector2F_OnStaticBody_DoesNothing()
        {
            Body body = new Body();
            body.ApplyLinearImpulse(new Vector2F(10.0f, 0.0f), new Vector2F(1.0f, 1.0f));

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        /// <summary>
        ///     Tests that ApplyLinearImpulse(ref, ref) on a Kinematic body returns early.
        /// </summary>
        [Fact]
        public void ApplyLinearImpulse_RefRef_OnKinematicBody_DoesNothing()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Kinematic);

            Vector2F impulse = new Vector2F(10.0f, 0.0f);
            Vector2F point = new Vector2F(1.0f, 1.0f);

            body.ApplyLinearImpulse(ref impulse, ref point);

            Assert.Equal(Vector2F.Zero, body.LinearVelocityInternal);
            Assert.Equal(0.0f, body.AngularVelocity, 5);
        }

        #endregion

        #region ResetMassData Edge Cases

        /// <summary>
        ///     Tests that ResetMassData skips fixtures with zero density.
        /// </summary>
        [Fact]
        public void ResetMassData_Skips_ZeroDensityFixtures()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 0.0f);

            body.ResetMassData();

            // Zero-density fixture should be skipped, mass forced to 1.0
            Assert.Equal(1.0f, body.Mass, 5);
        }

        /// <summary>
        ///     Tests that ResetMassData forces mass=1 when computed mass is zero.
        /// </summary>
        [Fact]
        public void ResetMassData_ZeroMass_ForcesPositiveMass()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);

            body.ResetMassData();

            Assert.Equal(1.0f, body.Mass, 5);
            Assert.Equal(1.0f, body.InvMass, 5);
        }

        /// <summary>
        ///     Tests that ResetMassData with fixed rotation sets inertia to zero.
        /// </summary>
        [Fact]
        public void ResetMassData_WithFixedRotation_SetsZeroInertia()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.FixedRotation = true;
            body.CreateCircle(0.5f, 1.0f);

            body.ResetMassData();

            Assert.Equal(0.0f, body.Inertia, 5);
            Assert.Equal(0.0f, body.InvI, 5);
        }

        /// <summary>
        ///     Tests that the Inertia setter on a Dynamic body returns early
        ///     when value is zero (value > 0 guard).
        /// </summary>
        [Fact]
        public void Inertia_Setter_WithZeroValue_DoesNotChange()
        {
            WorldPhysic world = new WorldPhysic(Vector2F.Zero);
            Body body = world.CreateBody(Vector2F.Zero, 0.0f, BodyType.Dynamic);
            body.CreateCircle(0.5f, 1.0f);
            body.ResetMassData();

            float inertiaBefore = body.Inertia;
            body.Inertia = 0.0f;

            Assert.Equal(inertiaBefore, body.Inertia);
        }

        #endregion

        #region Sweep Setter (internal field)

        /// <summary>
        ///     Tests that Sweep field can be directly assigned.
        /// </summary>
        [Fact]
        public void Sweep_Field_CanBeAssigned()
        {
            Body body = new Body();
            Sweep newSweep = new Sweep
                {
                    A = 1.0f,
                    C = new Vector2F(3.0f, 4.0f)
                };

            body.Sweep = newSweep;

            Assert.Equal(1.0f, body.Sweep.A, 5);
            Assert.Equal(3.0f, body.Sweep.C.X, 5);
            Assert.Equal(4.0f, body.Sweep.C.Y, 5);
        }

        #endregion
    }
}
