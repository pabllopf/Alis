// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:BoxColliderTest.cs
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
using Alis.Builder.Core.Ecs.Component.Collider;
using Alis.Core.Aspect.Logging;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Ecs.Component.Collider;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Collider
{
    /// <summary>
    /// The box collider test class
    /// </summary>
    public class BoxColliderTest
    {
        /// <summary>
        /// Tests that box collider default constructor valid input
        /// </summary>
        [Fact]
        public void BoxCollider_DefaultConstructor_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            Assert.NotNull(boxCollider);
            Assert.Equal(10.0f, boxCollider.Width);
            Assert.Equal(10.0f, boxCollider.Height);
            Assert.Equal(1.0f, boxCollider.Rotation);
            Assert.Equal(new Vector2(0, 0), boxCollider.RelativePosition);
            Assert.Equal(BodyType.Static, boxCollider.BodyType);
            Assert.Equal(10.0f, boxCollider.Mass);
            Assert.Equal(1.0f, boxCollider.GravityScale);
            Assert.Equal(Vector2.Zero, boxCollider.LinearVelocity);
        }
        
        /// <summary>
        /// Tests that box collider builder valid input
        /// </summary>
        [Fact]
        public void BoxCollider_Builder_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            BoxColliderBuilder boxColliderBuilder = boxCollider.Builder();
            
            Assert.NotNull(boxColliderBuilder);
        }
        
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            Assert.Throws<NullReferenceException>(() => boxCollider.OnInit());
        }
        
        /// <summary>
        /// Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            Assert.Throws<NullReferenceException>(() => boxCollider.OnAwake());
        }
        
        /// <summary>
        /// Tests that on start valid input
        /// </summary>
        [Fact]
        public void OnStart_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            boxCollider.OnStart();
        }
        
        /// <summary>
        /// Tests that on update valid input
        /// </summary>
        [Fact]
        public void OnUpdate_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            boxCollider.OnUpdate();
        }
        
        /// <summary>
        /// Tests that on draw valid input
        /// </summary>
        [Fact]
        public void OnDraw_ValidInput()
        {
            BoxCollider boxCollider = new BoxCollider();
            
            Assert.Throws<NullReferenceException>(() => boxCollider.OnDraw());
        }
        
        /// <summary>
        /// Tests that is trigger property set get returns correct value
        /// </summary>
        [Fact]
        public void IsTrigger_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.IsTrigger = true;
            Assert.True(boxCollider.IsTrigger);
        }
        
        /// <summary>
        /// Tests that width property set get returns correct value
        /// </summary>
        [Fact]
        public void Width_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Width = 10.0f;
            Assert.Equal(10.0f, boxCollider.Width);
        }
        
        /// <summary>
        /// Tests that height property set get returns correct value
        /// </summary>
        [Fact]
        public void Height_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Height = 20.0f;
            Assert.Equal(20.0f, boxCollider.Height);
        }
        
        /// <summary>
        /// Tests that rotation property set get returns correct value
        /// </summary>
        [Fact]
        public void Rotation_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Rotation = 1.0f;
            Assert.Equal(1.0f, boxCollider.Rotation);
        }
        
        /// <summary>
        /// Tests that relative position property set get returns correct value
        /// </summary>
        [Fact]
        public void RelativePosition_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.RelativePosition = new Vector2(10, 20);
            Assert.Equal(new Vector2(10, 20), boxCollider.RelativePosition);
        }
        
        /// <summary>
        /// Tests that auto tilling property set get returns correct value
        /// </summary>
        [Fact]
        public void AutoTilling_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.AutoTilling = true;
            Assert.True(boxCollider.AutoTilling);
        }
        
        /// <summary>
        /// Tests that body type property set get returns correct value
        /// </summary>
        [Fact]
        public void BodyType_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.BodyType = BodyType.Dynamic;
            Assert.Equal(BodyType.Dynamic, boxCollider.BodyType);
        }
        
        /// <summary>
        /// Tests that restitution property set get returns correct value
        /// </summary>
        [Fact]
        public void Restitution_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Restitution = 0.5f;
            Assert.Equal(0.5f, boxCollider.Restitution);
        }
        
        /// <summary>
        /// Tests that friction property set get returns correct value
        /// </summary>
        [Fact]
        public void Friction_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Friction = 0.5f;
            Assert.Equal(0.5f, boxCollider.Friction);
        }
        
        /// <summary>
        /// Tests that fixed rotation property set get returns correct value
        /// </summary>
        [Fact]
        public void FixedRotation_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.FixedRotation = true;
            Assert.True(boxCollider.FixedRotation);
        }
        
        /// <summary>
        /// Tests that mass property set get returns correct value
        /// </summary>
        [Fact]
        public void Mass_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.Mass = 10.0f;
            Assert.Equal(10.0f, boxCollider.Mass);
        }
        
        /// <summary>
        /// Tests that gravity scale property set get returns correct value
        /// </summary>
        [Fact]
        public void GravityScale_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.GravityScale = 1.0f;
            Assert.Equal(1.0f, boxCollider.GravityScale);
        }
        
        /// <summary>
        /// Tests that linear velocity property set get returns correct value
        /// </summary>
        [Fact]
        public void LinearVelocity_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.LinearVelocity = new Vector2(10, 20);
            Assert.Equal(new Vector2(10, 20), boxCollider.LinearVelocity);
        }
        
        /// <summary>
        /// Tests that angular velocity property set get returns correct value
        /// </summary>
        [Fact]
        public void AngularVelocity_PropertySet_GetReturnsCorrectValue()
        {
            BoxCollider boxCollider = new BoxCollider();
            boxCollider.AngularVelocity = 1.0f;
            Assert.Equal(1.0f, boxCollider.AngularVelocity);
        }
    }
}