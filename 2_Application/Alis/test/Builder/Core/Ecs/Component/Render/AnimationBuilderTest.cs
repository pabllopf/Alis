// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimationBuilderTest.cs
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
using Alis.Builder.Core.Ecs.Component.Render;
using Alis.Core.Ecs.Component.Render;
using Xunit;

namespace Alis.Test.Builder.Core.Ecs.Component.Render
{
    /// <summary>
    /// The animation builder test class
    /// </summary>
    public class AnimationBuilderTest
    {
        /// <summary>
        /// Tests that animation builder default constructor valid input
        /// </summary>
        [Fact]
        public void AnimationBuilder_DefaultConstructor_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            
            Assert.NotNull(animationBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            
            Animation animation = animationBuilder.Build();
            
            Assert.NotNull(animation);
        }
        
        /// <summary>
        /// Tests that name valid input
        /// </summary>
        [Fact]
        public void Name_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            string name = "testName";
            
            animationBuilder.Name(name);
            
            Assert.Equal(name, animationBuilder.Build().Name);
        }
        
        /// <summary>
        /// Tests that order valid input
        /// </summary>
        [Fact]
        public void Order_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            int order = 1;
            
            animationBuilder.Order(order);
            
            Assert.Equal(order, animationBuilder.Build().Order);
        }
        
        /// <summary>
        /// Tests that speed valid input
        /// </summary>
        [Fact]
        public void Speed_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            float speed = 1.0f;
            
            animationBuilder.Speed(speed);
            
            Assert.Equal(speed, animationBuilder.Build().Speed);
        }
        
        /// <summary>
        /// Tests that add frame valid input
        /// </summary>
        [Fact]
        public void AddFrame_ValidInput()
        {
            AnimationBuilder animationBuilder = new AnimationBuilder();
            Func<FrameBuilder, Frame> frameFunc = fb => fb.Build();
            
            animationBuilder.AddFrame(frameFunc);
            
            Animation animation = animationBuilder.Build();
            
            Assert.Single(animation.Frames);
        }
    }
}