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
    }
}