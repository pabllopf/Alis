// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BodyTest.cs
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
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Dynamics
{
    /// <summary>
    ///     The body test class
    /// </summary>
    public class BodyTest
    {
        /// <summary>
        ///     Tests that constructor test
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(1, 1);
            BodyType bodyType = BodyType.Dynamic;
            float angle = 0.0f;
            float angularVelocity = 0.0f;
            float linearDamping = 0.0f;
            float angularDamping = 0.0f;
            bool allowSleep = true;
            bool awake = true;
            bool fixedRotation = false;
            bool isBullet = false;
            bool enabled = true;
            float gravityScale = 1.0f;
            
            Body body = new Body(position, linearVelocity, bodyType, angle, angularVelocity, linearDamping, angularDamping, allowSleep, awake, fixedRotation, isBullet, enabled, gravityScale);
            
            Assert.NotNull(body);
            Assert.Equal(position, body.Position);
            Assert.Equal(new Vector2(0, 0), body.LinearVelocity);
            Assert.Equal(bodyType, body.BodyType);
            Assert.Equal(angle, body.Rotation);
            Assert.Equal(angularVelocity, body.AngularVelocity);
            Assert.Equal(linearDamping, body.LinearDamping);
            Assert.Equal(angularDamping, body.AngularDamping);
            Assert.Equal(allowSleep, body.SleepingAllowed);
            Assert.Equal(awake, body.Awake);
            Assert.Equal(fixedRotation, body.FixedRotation);
            Assert.Equal(isBullet, body.IsBullet);
            Assert.Equal(enabled, body.Enabled);
            Assert.Equal(gravityScale, body.GravityScale);
        }
        
        /// <summary>
        ///     Tests that apply force test
        /// </summary>
        [Fact]
        public void ApplyForceTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Vector2 initialForce = body.Force;
            
            body.ApplyForce(new Vector2(1, 1));
            
            Assert.Equal(initialForce, body.Force);
        }
        
        /// <summary>
        ///     Tests that apply torque test
        /// </summary>
        [Fact]
        public void ApplyTorqueTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialTorque = body.Torque;
            
            body.ApplyTorque(1.0f);
            
            Assert.Equal(initialTorque, body.Torque);
        }
        
        /// <summary>
        ///     Tests that apply linear impulse test
        /// </summary>
        [Fact]
        public void ApplyLinearImpulseTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            Vector2 initialVelocity = body.LinearVelocity;
            
            body.ApplyLinearImpulse(new Vector2(1, 1));
            
            Assert.Equal(initialVelocity, body.LinearVelocity);
        }
        
        /// <summary>
        ///     Tests that apply angular impulse test
        /// </summary>
        [Fact]
        public void ApplyAngularImpulseTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialAngularVelocity = body.AngularVelocity;
            
            body.ApplyAngularImpulse(1.0f);
            
            Assert.Equal(initialAngularVelocity, body.AngularVelocity);
        }
        
        /// <summary>
        ///     Tests that reset mass data test
        /// </summary>
        [Fact]
        public void ResetMassDataTest()
        {
            Body body = new Body(new Vector2(0, 0), new Vector2(0, 0));
            float initialMass = body.Mass;
            float initialInertia = body.Inertia;
            
            body.ResetMassData();
            
            Assert.Equal(initialMass, body.Mass);
            Assert.Equal(initialInertia, body.Inertia);
        }
    }
}