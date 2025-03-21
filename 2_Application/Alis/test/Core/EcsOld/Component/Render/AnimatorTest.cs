// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimatorTest.cs
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
using System.Threading;
using Alis.Builder.Core.EcsOld.Component.Render;
using Alis.Core.EcsOld.Component.Render;
using Alis.Core.EcsOld.System;
using Xunit;

namespace Alis.Test.Core.EcsOld.Component.Render
{
    /// <summary>
    ///     The animator test class
    /// </summary>
    public class AnimatorTest
    {
        /// <summary>
        ///     Tests that builder should return animator builder
        /// </summary>
        [Fact]
        public void Builder_ShouldReturnAnimatorBuilder()
        {
            Animator animator = new Animator();
            AnimatorBuilder result = animator.Builder();
            Assert.NotNull(result);
            Assert.IsType<AnimatorBuilder>(result);
        }

        /// <summary>
        ///     Tests that on init should set current animation
        /// </summary>
        [Fact]
        public void OnInit_ShouldSetCurrentAnimation()
        {
            List<Animation> animations = new List<Animation> {new Animation(new List<Frame>())};
            Animator animator = new Animator(animations);
            animator.OnInit();
            Assert.Equal(animations[0], animator.GetCurrentAnimation());
        }

        /// <summary>
        ///     Tests that on awake should start timer
        /// </summary>
        [Fact]
        public void OnAwake_ShouldStartTimer()
        {
            Animator animator = new Animator();
            animator.OnAwake();
            Assert.True(animator.Timer.IsRunning);
        }

        /// <summary>
        ///     Tests that on update should change sprite image
        /// </summary>
        [Fact]
        public void OnUpdate_ShouldChangeSpriteImage()
        {
            VideoGame videoGame = new VideoGame();
            List<Animation> animations = new List<Animation> {new Animation(new List<Frame>())};
            Animator animator = new Animator(animations);
            animator.OnInit();
            animator.OnAwake();
            animator.Timer.Restart();
            Thread.Sleep((int) (animations[0].Speed * 1000) + 1);
            animator.OnUpdate();
        }

        /// <summary>
        ///     Tests that on exit should stop timer
        /// </summary>
        [Fact]
        public void OnExit_ShouldStopTimer()
        {
            Animator animator = new Animator();
            animator.OnAwake();
            animator.OnExit();
            Assert.True(animator.Timer.IsRunning);
        }

        /// <summary>
        ///     Tests that add animation should add animation to list
        /// </summary>
        [Fact]
        public void AddAnimation_ShouldAddAnimationToList()
        {
            Animator animator = new Animator();
            Animation animation = new Animation(new List<Frame>());
            animator.AddAnimation(animation);
            Assert.Contains(animation, animator.Animations);
        }

        /// <summary>
        ///     Tests that change animation to should change current animation
        /// </summary>
        [Fact]
        public void ChangeAnimationTo_ShouldChangeCurrentAnimation()
        {
            List<Animation> animations = new List<Animation> {new Animation(new List<Frame>())};
            Animator animator = new Animator(animations);
            animator.OnInit();
            animator.ChangeAnimationTo("Test2");
        }

        /// <summary>
        ///     Tests that animations get value should return value
        /// </summary>
        [Fact]
        public void Animations_GetValue_ShouldReturnValue()
        {
            List<Animation> animations = new List<Animation> {new Animation(new List<Frame>())};
            Animator animator = new Animator(animations);
            Assert.Equal(animations, animator.Animations);
        }
    }
}