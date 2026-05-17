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
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    ///     Tests for the Animator component struct
    /// </summary>
    public class AnimatorTest
    {
        /// <summary>
        ///     Tests that the constructor creates an Animator with default values
        /// </summary>
        [Fact]
        public void Animator_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator.Animations);
            Assert.Empty(animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that Animator implements IAnimator interface
        /// </summary>
        [Fact]
        public void Animator_ShouldImplementIAnimatorInterface()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IAnimator>(animator);
        }

        /// <summary>
        ///     Tests that Animator properties are gettable and settable
        /// </summary>
        [Fact]
        public void Animator_Properties_ShouldBeGetAndSettable()
        {
            Animator animator = new Animator();

            List<Animation> animations = new List<Animation>();
            animator.Animations = animations;
            Assert.Same(animations, animator.Animations);

            animator.CurrentAnimationIndex = 5;
            Assert.Equal(5, animator.CurrentAnimationIndex);

            animator.CurrentFrameIndex = 3;
            Assert.Equal(3, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that Animator methods are callable
        /// </summary>
        [Fact]
        public void Animator_Methods_ShouldBeCallable()
        {
            Animator animator = new Animator();

            animator.AddAnimation(new Animation("test", 0, 1f));
            animator.Play("test");
            animator.NextFrame();
            animator.GetCurrentFrame();
        }

        /// <summary>
        ///     Tests that Animator can be created without exceptions
        /// </summary>
        [Fact]
        public void Animator_Constructor_ShouldNotThrow()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator);
        }

        /// <summary>
        ///     Tests that Animator properties can be modified
        /// </summary>
        [Fact]
        public void Animator_Properties_ShouldBeModifiable()
        {
            Animator animator = new Animator();

            animator.CurrentAnimationIndex = 10;
            Assert.Equal(10, animator.CurrentAnimationIndex);

            animator.CurrentFrameIndex = 20;
            Assert.Equal(20, animator.CurrentFrameIndex);

            List<Animation> animations = new List<Animation>
            {
                new Animation("anim1", 0, 1f),
                new Animation("anim2", 1, 2f)
            };

            animator.Animations = animations;
            Assert.Equal(2, animator.Animations.Count);
        }

        /// <summary>
        ///     Tests that Animator default state is valid
        /// </summary>
        [Fact]
        public void Animator_DefaultState_ShouldBeValid()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator.Animations);
            Assert.IsType<List<Animation>>(animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that Animator has expected public members
        /// </summary>
        [Fact]
        public void Animator_ShouldHaveExpectedPublicMembers()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);

            Assert.NotNull(animator.AddAnimation);
            Assert.NotNull(animator.Play);
            Assert.NotNull(animator.NextFrame);
            Assert.NotNull(animator.GetCurrentFrame);
        }
    }
}
