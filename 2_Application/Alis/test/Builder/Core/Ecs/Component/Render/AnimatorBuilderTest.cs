// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimatorBuilderTest.cs
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
    /// The animator builder test class
    /// </summary>
    public class AnimatorBuilderTest
    {
        /// <summary>
        /// Tests that animator builder default constructor valid input
        /// </summary>
        [Fact]
        public void AnimatorBuilder_DefaultConstructor_ValidInput()
        {
            AnimatorBuilder animatorBuilder = new AnimatorBuilder();
            
            Assert.NotNull(animatorBuilder);
        }
        
        /// <summary>
        /// Tests that build valid input
        /// </summary>
        [Fact]
        public void Build_ValidInput()
        {
            AnimatorBuilder animatorBuilder = new AnimatorBuilder();
            
            Animator animator = animatorBuilder.Build();
            
            Assert.NotNull(animator);
        }
        
        /// <summary>
        /// Tests that add animation valid input
        /// </summary>
        [Fact]
        public void AddAnimation_ValidInput()
        {
            AnimatorBuilder animatorBuilder = new AnimatorBuilder();
            Func<AnimationBuilder, Animation> animationFunc = ab => ab.Build();
            
            animatorBuilder.AddAnimation(animationFunc);
            
            Animator animator = animatorBuilder.Build();
            
            Assert.Single(animator.Animations);
        }
    }
}