// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimationTest.cs
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

using System.Collections.Generic;
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Component.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Component.Render
{
    /// <summary>
    /// The animation test class
    /// </summary>
    public class AnimationTest
    {
        /// <summary>
        /// Tests that animator default constructor valid input
        /// </summary>
        [Fact]
        public void Animator_DefaultConstructor_ValidInput()
        {
            Animator animator = new Animator();
            
            Assert.NotNull(animator);
            Assert.Empty(animator.Animations);
        }
        
        /// <summary>
        /// Tests that animator constructor with parameters valid input
        /// </summary>
        [Fact]
        public void Animator_ConstructorWithParameters_ValidInput()
        {
            List<Animation> animations = new List<Animation> {new Animation()};
            Animator animator = new Animator(animations);
            
            Assert.NotNull(animator);
            Assert.Equal(animations, animator.Animations);
        }
        
        /// <summary>
        /// Tests that add animation valid input
        /// </summary>
        [Fact]
        public void AddAnimation_ValidInput()
        {
            Animator animator = new Animator();
            Animation animation = new Animation();
            
            animator.AddAnimation(animation);
            
            Assert.Contains(animation, animator.Animations);
        }
        
        /// <summary>
        /// Tests that on init valid input
        /// </summary>
        [Fact]
        public void OnInit_ValidInput()
        {
            List<Animation> animations = new List<Animation> {new Animation()};
            Animator animator = new Animator(animations);
            
            animator.OnInit();
            
            Assert.Equal(animations[0], animator.GetCurrentAnimation());
        }
        
        /// <summary>
        /// Tests that on awake valid input
        /// </summary>
        [Fact]
        public void OnAwake_ValidInput()
        {
            Animator animator = new Animator();
            
            animator.OnAwake();
            
            Assert.True(animator.Timer.IsRunning);
        }
        
        /// <summary>
        /// Tests that change animation to valid input
        /// </summary>
        [Fact]
        public void ChangeAnimationTo_ValidInput()
        {
            List<Animation> animations = new List<Animation> {new Animation {Name = "Test"}};
            Animator animator = new Animator(animations);
            
            animator.ChangeAnimationTo("Test");
            
            Assert.Equal(animations[0], animator.GetCurrentAnimation());
        }
        
        /// <summary>
        /// Tests that get current animation valid input
        /// </summary>
        [Fact]
        public void GetCurrentAnimation_ValidInput()
        {
            List<Animation> animations = new List<Animation> {new Animation {Name = "Test"}};
            Animator animator = new Animator(animations);
            
            Animation currentAnimation = animator.GetCurrentAnimation();
            
            Assert.Equal(animations[0], currentAnimation);
        }
        
        /// <summary>
        /// Tests that name property set get returns correct value
        /// </summary>
        [Fact]
        public void Name_PropertySet_GetReturnsCorrectValue()
        {
            Animation animation = new Animation();
            animation.Name = "TestAnimation";
            Assert.Equal("TestAnimation", animation.Name);
        }
        
        /// <summary>
        /// Tests that order property set get returns correct value
        /// </summary>
        [Fact]
        public void Order_PropertySet_GetReturnsCorrectValue()
        {
            Animation animation = new Animation();
            animation.Order = 1;
            Assert.Equal(1, animation.Order);
        }
        
        /// <summary>
        /// Tests that speed property set get returns correct value
        /// </summary>
        [Fact]
        public void Speed_PropertySet_GetReturnsCorrectValue()
        {
            Animation animation = new Animation();
            animation.Speed = 1.0f;
            Assert.Equal(1.0f, animation.Speed);
        }
        
        /// <summary>
        /// Tests that has next when frames not empty returns true
        /// </summary>
        [Fact]
        public void HasNext_WhenFramesNotEmpty_ReturnsTrue()
        {
            Animation animation = new Animation();
            animation.AddFrame(new Frame());
            Assert.True(animation.HasNext());
        }
        
        /// <summary>
        /// Tests that has next when frames empty returns false
        /// </summary>
        [Fact]
        public void HasNext_WhenFramesEmpty_ReturnsFalse()
        {
            Animation animation = new Animation();
            Assert.False(animation.HasNext());
        }
        
        /// <summary>
        /// Tests that next texture when called changes index
        /// </summary>
        [Fact]
        public void NextTexture_WhenCalled_ChangesIndex()
        {
            Animation animation = new Animation();
            Frame frame = new Frame();
            animation.AddFrame(frame);
            Frame result = animation.NextTexture();
            Assert.Equal(frame, result);
        }
        
        /// <summary>
        /// Tests that add frame when called adds frame to frames
        /// </summary>
        [Fact]
        public void AddFrame_WhenCalled_AddsFrameToFrames()
        {
            Animation animation = new Animation();
            Frame frame = new Frame();
            animation.AddFrame(frame);
            Assert.Contains(frame, animation.Frames);
        }
        
        /// <summary>
        /// Tests that builder when called returns animator builder
        /// </summary>
        [Fact]
        public void Builder_WhenCalled_ReturnsAnimatorBuilder()
        {
            Animation animation = new Animation();
            AnimatorBuilder result = animation.Builder();
            Assert.IsType<AnimatorBuilder>(result);
        }
    }
}