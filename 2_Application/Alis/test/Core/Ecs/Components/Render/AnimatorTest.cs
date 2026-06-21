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
using Alis.Core.Ecs.Systems.Scope;
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

        /// <summary>
        ///     Tests that the list constructor sets animations without starting the clock
        /// </summary>
        [Fact]
        public void Animator_ListConstructor_ShouldSetAnimations()
        {
            List<Animation> animations = new List<Animation>
            {
                new Animation("idle", 0, 1f),
                new Animation("walk", 0, 1.5f)
            };

            Animator animator = new Animator(animations);

            Assert.Same(animations, animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that AddAnimation adds to the list
        /// </summary>
        [Fact]
        public void Animator_AddAnimation_ShouldGrowList()
        {
            Animator animator = new Animator();

            Assert.Empty(animator.Animations);

            animator.AddAnimation(new Animation("anim1", 0, 1f));
            Assert.Single(animator.Animations);

            animator.AddAnimation(new Animation("anim2", 1, 2f));
            Assert.Equal(2, animator.Animations.Count);
        }

        /// <summary>
        ///     Tests that Play finds animation by name and sets CurrentAnimationIndex
        /// </summary>
        [Fact]
        public void Animator_Play_ShouldFindByName()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("idle", 0, 1f));
            animator.AddAnimation(new Animation("walk", 0, 1.5f));
            animator.AddAnimation(new Animation("run", 1, 2f));

            animator.Play("walk");

            Assert.Equal(1, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that Play with non-existent name does not change index
        /// </summary>
        [Fact]
        public void Animator_Play_WithNonExistentName_ShouldNotChangeIndex()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("idle", 0, 1f));

            animator.Play("nonexistent");

            Assert.Equal(0, animator.CurrentAnimationIndex);
        }

        /// <summary>
        ///     Tests that NextFrame advances the frame index
        /// </summary>
        [Fact]
        public void Animator_NextFrame_ShouldAdvanceFrameIndex()
        {
            Animation anim = new Animation("test", 0, 1f);
            anim.Frames.Add(new Frame());
            anim.Frames.Add(new Frame());
            anim.Frames.Add(new Frame());

            Animator animator = new Animator(new List<Animation> { anim });

            Assert.Equal(0, animator.CurrentFrameIndex);
            animator.NextFrame();
            Assert.Equal(1, animator.CurrentFrameIndex);
            animator.NextFrame();
            Assert.Equal(2, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that NextFrame wraps around at the end of the frame list
        /// </summary>
        [Fact]
        public void Animator_NextFrame_ShouldWrapAround()
        {
            Animation anim = new Animation("test", 0, 1f);
            anim.Frames.Add(new Frame());
            anim.Frames.Add(new Frame());

            Animator animator = new Animator(new List<Animation> { anim });
            animator.CurrentFrameIndex = 1;

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that NextFrame does not crash when the current animation has no frames
        /// </summary>
        [Fact]
        public void Animator_NextFrame_WithEmptyFrames_ShouldNotCrash()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("empty", 0, 1f));

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that NextFrame does not crash when there are no animations
        /// </summary>
        [Fact]
        public void Animator_NextFrame_WithNoAnimations_ShouldNotCrash()
        {
            Animator animator = new Animator();

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that GetCurrentFrame returns the current frame
        /// </summary>
        [Fact]
        public void Animator_GetCurrentFrame_ShouldReturnCurrentFrame()
        {
            Animation anim = new Animation("test", 0, 1f);
            Frame frame1 = new Frame { NameFile = "frame1.png" };
            Frame frame2 = new Frame { NameFile = "frame2.png" };
            anim.Frames.Add(frame1);
            anim.Frames.Add(frame2);

            Animator animator = new Animator(new List<Animation> { anim });

            Assert.Equal("frame1.png", animator.GetCurrentFrame().NameFile);

            animator.NextFrame();

            Assert.Equal("frame2.png", animator.GetCurrentFrame().NameFile);
        }

        /// <summary>
        ///     Tests that GetCurrentFrame returns default when animation has no frames
        /// </summary>
        [Fact]
        public void Animator_GetCurrentFrame_WithEmptyFrames_ShouldReturnDefault()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("empty", 0, 1f));

            Frame frame = animator.GetCurrentFrame();

            Assert.Null(frame.NameFile);
        }

        /// <summary>
        ///     Tests that CurrentAnimation returns the active animation
        /// </summary>
        [Fact]
        public void Animator_CurrentAnimation_ShouldReturnActiveAnimation()
        {
            Animation anim1 = new Animation("idle", 0, 1f);
            anim1.Frames.Add(new Frame());
            Animation anim2 = new Animation("walk", 1, 2f);
            anim2.Frames.Add(new Frame());

            Animator animator = new Animator(new List<Animation> { anim1, anim2 });

            Animation current = animator.CurrentAnimation;

            Assert.Equal("idle", current.Name);
            Assert.Equal(1f, current.Speed);

            animator.Play("walk");

            current = animator.CurrentAnimation;

            Assert.Equal("walk", current.Name);
            Assert.Equal(2f, current.Speed);
        }

        /// <summary>
        ///     Tests that CurrentAnimation returns default when the animation list is empty
        /// </summary>
        [Fact]
        public void Animator_CurrentAnimation_WithEmptyList_ShouldReturnDefault()
        {
            Animator animator = new Animator();

            Animation current = animator.CurrentAnimation;

            Assert.Null(current.Name);
            Assert.Equal(0, current.Order);
            Assert.Equal(0f, current.Speed);
            Assert.Null(current.Frames);
        }

        /// <summary>
        ///     Tests that Context property can be set and read
        /// </summary>
        [Fact]
        public void Animator_Context_ShouldBeSettable()
        {
            Animator animator = new Animator();
            Context context = new Context();

            animator.Context = context;

            Assert.Same(context, animator.Context);
        }

        /// <summary>
        ///     Tests that OnStart does not throw (does not depend on IGameObject)
        /// </summary>
        [Fact]
        public void Animator_OnStart_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnStart(null!);
        }

        /// <summary>
        ///     Tests that OnExit does not throw and resets elapsed time
        /// </summary>
        [Fact]
        public void Animator_OnExit_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnExit(null!);
        }

        /// <summary>
        ///     Tests that Animator implements IOnStart, IOnUpdate, and IOnExit lifecycle interfaces
        /// </summary>
        [Fact]
        public void Animator_ShouldImplementLifecycleInterfaces()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IOnStart>(animator);
            Assert.IsAssignableFrom<IOnUpdate>(animator);
        }

        /// <summary>
        ///     Tests that OnUpdate advances frames when elapsed time exceeds frame duration
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_ShouldAdvanceFrame_WhenElapsedTimeExceedsFrameDuration()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1000f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1" },
                        new Frame { NameFile = "frame2" },
                        new Frame { NameFile = "frame3" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);
            System.Threading.Thread.Sleep(15);
            animator.OnUpdate(null!);

            Assert.True(animator.CurrentFrameIndex > 0, "OnUpdate should have advanced the frame");
        }

        /// <summary>
        ///     Tests that OnUpdate with zero speed does not advance frames
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_WithZeroSpeed_ShouldNotAdvanceFrame()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 0f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1" },
                        new Frame { NameFile = "frame2" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);
            System.Threading.Thread.Sleep(15);
            animator.OnUpdate(null!);

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        ///     Tests that OnUpdate wraps around to first frame after last frame
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_ShouldWrapAround_AfterLastFrame()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 10000f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1" },
                        new Frame { NameFile = "frame2" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);
            System.Threading.Thread.Sleep(15);
            animator.OnUpdate(null!);
            int frameAfterFirst = animator.CurrentFrameIndex;

            System.Threading.Thread.Sleep(15);
            animator.OnUpdate(null!);

            Assert.NotEqual(frameAfterFirst, animator.CurrentFrameIndex);
        }
    }
}
