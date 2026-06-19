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
using Alis.Builder.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test
{
    /// <summary>
    /// The animator builder test class
    /// </summary>
    public class AnimatorBuilderTest
    {
        /// <summary>
        /// Tests that constructor with context creates builder
        /// </summary>
        [Fact]
        public void Constructor_WithContext_CreatesBuilder()
        {
            Context context = new Context();
            AnimatorBuilder builder = new AnimatorBuilder(context);
            Assert.NotNull(builder);
        }

        /// <summary>
        /// Tests that build returns animator instance
        /// </summary>
        [Fact]
        public void Build_ReturnsAnimatorInstance()
        {
            Context context = new Context();
            AnimatorBuilder builder = new AnimatorBuilder(context);
            Animator animator = builder.Build();
            Assert.NotNull(animator);
        }

        /// <summary>
        /// Tests that build sets context on animator
        /// </summary>
        [Fact]
        public void Build_SetsContextOnAnimator()
        {
            Context context = new Context();
            AnimatorBuilder builder = new AnimatorBuilder(context);
            Animator animator = builder.Build();
            Assert.NotNull(animator);
        }

        /// <summary>
        /// Tests that add animation with valid func returns builder
        /// </summary>
        [Fact]
        public void AddAnimation_WithValidFunc_ReturnsBuilder()
        {
            Context context = new Context();
            AnimatorBuilder builder = new AnimatorBuilder(context);
            AnimatorBuilder result = builder.AddAnimation(ab => ab.Name("test").Speed(1).Order(0).Build());
            Assert.Same(builder, result);
        }

        /// <summary>
        /// Tests that add animation animation is added to animator
        /// </summary>
        [Fact]
        public void AddAnimation_AnimationIsAddedToAnimator()
        {
            Context context = new Context();
            AnimatorBuilder builder = new AnimatorBuilder(context);
            builder.AddAnimation(ab => ab.Name("test").Speed(1).Order(0).Build());
            Animator animator = builder.Build();
            Assert.NotNull(animator);
        }
    }
}
