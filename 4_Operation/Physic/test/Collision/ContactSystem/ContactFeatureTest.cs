// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ContactFeatureTest.cs
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
using Alis.Core.Physic.Collision.ContactSystem;
using Alis.Core.Physic.Dynamics;
using Alis.Core.Physic.Test.Collision.BroadPhase.Sample;
using Xunit;

namespace Alis.Core.Physic.Test.Collision.ContactSystem
{
    /// <summary>
    ///     The contact feature test class
    /// </summary>
    public class ContactFeatureTest
    {
        /// <summary>
        ///     Tests that test set transform
        /// </summary>
        [Fact]
        public void Test_SetTransform()
        {
            ContactManager contactManager = new ContactManager(
                new BroadPhaseImplementation()
            );
            
            // Arrange
            Vector2 position = new Vector2(1, 2);
            Vector2 linearVelocity = new Vector2(0, 1);
            Body body = new Body(
                position,
                linearVelocity
            );
            
            float rotation = 1.0f;
            
            // Act
            body.SetTransform(position, rotation);
            
            // Assert
            Assert.NotEqual(new Vector2(0, 0), body.Position);
        }
        
        /// <summary>
        ///     Tests that test apply force
        /// </summary>
        [Fact]
        public void Test_ApplyForce()
        {
            // Arrange
            // Arrange
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            Body body = new Body(
                position,
                linearVelocity,
                BodyType.Dynamic
            );
            Vector2 force = new Vector2(1, 1);
            Vector2 point = new Vector2(1, 1);
            
            // Act
            body.ApplyForce(force, point);
            
            // Assert
            Assert.Equal(force, body.Force);
        }
        
        /// <summary>
        ///     Tests that test apply torque
        /// </summary>
        [Fact]
        public void Test_ApplyTorque()
        {
            // Arrange
            // Arrange
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            Body body = new Body(
                position,
                linearVelocity,
                BodyType.Dynamic
            );
            float torque = 1.0f;
            
            // Act
            body.ApplyTorque(torque);
            
            // Assert
            Assert.Equal(torque, body.Torque);
        }
        
        /// <summary>
        ///     Tests that test apply linear impulse
        /// </summary>
        [Fact]
        public void Test_ApplyLinearImpulse()
        {
            // Arrange
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            Body body = new Body(
                position,
                linearVelocity,
                BodyType.Dynamic
            );
            Vector2 impulse = new Vector2(1, 1);
            
            // Act
            body.ApplyLinearImpulse(impulse);
            
            // Assert
            Assert.Equal(body.InvMass * impulse, body.LinearVelocity);
        }
        
        /// <summary>
        ///     Tests that test apply angular impulse
        /// </summary>
        [Fact]
        public void Test_ApplyAngularImpulse()
        {
            // Arrange
            // Arrange
            Vector2 position = new Vector2(0, 0);
            Vector2 linearVelocity = new Vector2(0, 0);
            Body body = new Body(
                position,
                linearVelocity,
                BodyType.Dynamic
            );
            float impulse = 1.0f;
            
            // Act
            body.ApplyAngularImpulse(impulse);
            
            // Assert
            Assert.Equal(body.InvI * impulse, body.AngularVelocity);
        }
        
        /// <summary>
        ///     Tests that test index a property
        /// </summary>
        [Fact]
        public void TestIndexAProperty()
        {
            // Arrange
            ContactFeature contactFeature = new ContactFeature();
            byte indexA = 1;
            
            // Act
            contactFeature.IndexA = indexA;
            
            // Assert
            Assert.Equal(indexA, contactFeature.IndexA);
        }
        
        /// <summary>
        ///     Tests that test index b property
        /// </summary>
        [Fact]
        public void TestIndexBProperty()
        {
            // Arrange
            ContactFeature contactFeature = new ContactFeature();
            byte indexB = 1;
            
            // Act
            contactFeature.IndexB = indexB;
            
            // Assert
            Assert.Equal(indexB, contactFeature.IndexB);
        }
        
        /// <summary>
        ///     Tests that test type a property
        /// </summary>
        [Fact]
        public void TestTypeAProperty()
        {
            // Arrange
            ContactFeature contactFeature = new ContactFeature();
            ContactFeatureType typeA = ContactFeatureType.Face;
            
            // Act
            contactFeature.TypeA = typeA;
            
            // Assert
            Assert.Equal(typeA, contactFeature.TypeA);
        }
        
        /// <summary>
        ///     Tests that test type b property
        /// </summary>
        [Fact]
        public void TestTypeBProperty()
        {
            // Arrange
            ContactFeature contactFeature = new ContactFeature();
            ContactFeatureType typeB = ContactFeatureType.Face;
            
            // Act
            contactFeature.TypeB = typeB;
            
            // Assert
            Assert.Equal(typeB, contactFeature.TypeB);
        }
    }
}