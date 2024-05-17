// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderBuilderTest.cs
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

using Alis.Builder.Core.Ecs.Component.Collider;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Collider
{
    /// <summary>
    /// The box collider builder test class
    /// </summary>
    public class BoxColliderBuilderTest
    {
        /// <summary>
        /// Tests that box collider builder default constructor valid input
        /// </summary>
        [Fact]
        public void BoxColliderBuilder_DefaultConstructor_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            
            Assert.NotNull(boxColliderBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            
            BoxCollider boxCollider = boxColliderBuilder.Build();
            
            Assert.NotNull(boxCollider);
        }
        
        /// <summary>
        /// Tests that angular velocity valid input
        /// </summary>
        [Fact]
        public void AngularVelocity_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float angularVelocity = 1.0f;
            
            boxColliderBuilder.AngularVelocity(angularVelocity);
            
            Assert.Equal(angularVelocity, boxColliderBuilder.Build().AngularVelocity);
        }
        
        /// <summary>
        /// Tests that auto tilling valid input
        /// </summary>
        [Fact]
        public void AutoTilling_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            bool autoTilling = true;
            
            boxColliderBuilder.AutoTilling(autoTilling);
            
            Assert.Equal(autoTilling, boxColliderBuilder.Build().AutoTilling);
        }
        
        /// <summary>
        /// Tests that body type valid input
        /// </summary>
        [Fact]
        public void BodyType_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            BodyType bodyType = BodyType.Dynamic;
            
            boxColliderBuilder.BodyType(bodyType);
            
            Assert.Equal(bodyType, boxColliderBuilder.Build().BodyType);
        }
        
        /// <summary>
        /// Tests that fixed rotation valid input
        /// </summary>
        [Fact]
        public void FixedRotation_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            bool fixedRotation = true;
            
            boxColliderBuilder.FixedRotation(fixedRotation);
            
            Assert.Equal(fixedRotation, boxColliderBuilder.Build().FixedRotation);
        }
        
        /// <summary>
        /// Tests that friction valid input
        /// </summary>
        [Fact]
        public void Friction_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float friction = 0.5f;
            
            boxColliderBuilder.Friction(friction);
            
            Assert.Equal(friction, boxColliderBuilder.Build().Friction);
        }
        
        /// <summary>
        /// Tests that gravity scale valid input
        /// </summary>
        [Fact]
        public void GravityScale_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float gravityScale = 1.0f;
            
            boxColliderBuilder.GravityScale(gravityScale);
            
            Assert.Equal(gravityScale, boxColliderBuilder.Build().GravityScale);
        }
        
        /// <summary>
        /// Tests that is active valid input
        /// </summary>
        [Fact]
        public void IsActive_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            bool isActive = true;
            
            boxColliderBuilder.IsActive(isActive);
            
            Assert.Equal(isActive, boxColliderBuilder.Build().IsEnable);
        }
        
        /// <summary>
        /// Tests that is trigger valid input
        /// </summary>
        [Fact]
        public void IsTrigger_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            bool isTrigger = true;
            
            boxColliderBuilder.IsTrigger(isTrigger);
            
            Assert.Equal(isTrigger, boxColliderBuilder.Build().IsTrigger);
        }
        
        /// <summary>
        /// Tests that linear velocity valid input
        /// </summary>
        [Fact]
        public void LinearVelocity_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            Vector2 linearVelocity = new Vector2(1.0f, 1.0f);
            
            boxColliderBuilder.LinearVelocity(linearVelocity.X, linearVelocity.Y);
            
            Assert.Equal(linearVelocity, boxColliderBuilder.Build().LinearVelocity);
        }
        
        /// <summary>
        /// Tests that mass valid input
        /// </summary>
        [Fact]
        public void Mass_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float mass = 1.0f;
            
            boxColliderBuilder.Mass(mass);
            
            Assert.Equal(mass, boxColliderBuilder.Build().Mass);
        }
        
        /// <summary>
        /// Tests that relative position valid input
        /// </summary>
        [Fact]
        public void RelativePosition_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            Vector2 relativePosition = new Vector2(1.0f, 1.0f);
            
            boxColliderBuilder.RelativePosition(relativePosition.X, relativePosition.Y);
            
            Assert.Equal(relativePosition, boxColliderBuilder.Build().RelativePosition);
        }
        
        /// <summary>
        /// Tests that restitution valid input
        /// </summary>
        [Fact]
        public void Restitution_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float restitution = 0.5f;
            
            boxColliderBuilder.Restitution(restitution);
            
            Assert.Equal(restitution, boxColliderBuilder.Build().Restitution);
        }
        
        /// <summary>
        /// Tests that rotation valid input
        /// </summary>
        [Fact]
        public void Rotation_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float rotation = 45.0f;
            
            boxColliderBuilder.Rotation(rotation);
            
            Assert.Equal(rotation, boxColliderBuilder.Build().Rotation);
        }
        
        /// <summary>
        /// Tests that size valid input
        /// </summary>
        [Fact]
        public void Size_ValidInput()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            Vector2 size = new Vector2(1.0f, 1.0f);
            
            boxColliderBuilder.Size(size.X, size.Y);
            
            Assert.Equal(size.X, boxColliderBuilder.Build().Width);
            Assert.Equal(size.Y, boxColliderBuilder.Build().Height);
        }
        
        /// <summary>
        /// Tests that box collider builder default constructor valid input v 2
        /// </summary>
        [Fact]
        public void BoxColliderBuilder_DefaultConstructor_ValidInput_v2()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            
            Assert.NotNull(boxColliderBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input v 2
        /// </summary>
        [Fact]
        public void Build_ValidInput_v2()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            
            BoxCollider boxCollider = boxColliderBuilder.Build();
            
            Assert.NotNull(boxCollider);
        }
        
        /// <summary>
        /// Tests that is active valid input v 2
        /// </summary>
        [Fact]
        public void IsActive_ValidInput_v2()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            bool isActive = true;
            
            boxColliderBuilder.IsActive(isActive);
            
            Assert.Equal(isActive, boxColliderBuilder.Build().IsEnable);
        }
        
        /// <summary>
        /// Tests that is trigger valid input v 2
        /// </summary>
        [Fact]
        public void IsTrigger_ValidInput_v2()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            
            boxColliderBuilder.IsTrigger();
            
            Assert.True(boxColliderBuilder.Build().IsTrigger);
        }
        
        /// <summary>
        /// Tests that size valid input v 2
        /// </summary>
        [Fact]
        public void Size_ValidInput_v2()
        {
            BoxColliderBuilder boxColliderBuilder = new BoxColliderBuilder();
            float x = 1.0f;
            float y = 1.0f;
            
            boxColliderBuilder.Size(x, y);
            
            Assert.Equal(x, boxColliderBuilder.Build().Width);
            Assert.Equal(y, boxColliderBuilder.Build().Height);
        }
    }
}