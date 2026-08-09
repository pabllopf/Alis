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

using System;
using System.Collections.Generic;
using System.Threading;
using Alis.Core.Aspect.Fluent.Components;
using Alis.Core.Ecs.Components.Render;
using Alis.Core.Ecs.Systems.Scope;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator test class
    /// </summary>
    public class AnimatorTest
    {
        /// <summary>
        /// Tests that animator default constructor should create with default values
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
        /// Tests that animator should implement i animator interface
        /// </summary>
        [Fact]
        public void Animator_ShouldImplementIAnimatorInterface()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IAnimator>(animator);
        }

        /// <summary>
        /// Tests that animator properties should be get and settable
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
        /// Tests that animator methods should be callable
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
        /// Tests that animator constructor should not throw
        /// </summary>
        [Fact]
        public void Animator_Constructor_ShouldNotThrow()
        {
            Animator animator = new Animator();
        }

        /// <summary>
        /// Tests that animator properties should be modifiable
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
        /// Tests that animator default state should be valid
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
        /// Tests that animator should have expected public members
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
        /// Tests that animator list constructor should set animations
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
        /// Tests that animator add animation should grow list
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
        /// Tests that animator play should find by name
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
        /// Tests that animator play with non existent name should not change index
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
        /// Tests that animator next frame should advance frame index
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
        /// Tests that animator next frame should wrap around
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
        /// Tests that animator next frame with empty frames should not crash
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
        /// Tests that animator next frame with no animations should not crash
        /// </summary>
        [Fact]
        public void Animator_NextFrame_WithNoAnimations_ShouldNotCrash()
        {
            Animator animator = new Animator();

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that animator get current frame should return current frame
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
        /// Tests that animator get current frame with empty frames should return default
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
        /// Tests that animator current animation should return active animation
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
            Assert.Equal(1f, current.Speed, 5);

            animator.Play("walk");

            current = animator.CurrentAnimation;

            Assert.Equal("walk", current.Name);
            Assert.Equal(2f, current.Speed, 5);
        }

        /// <summary>
        /// Tests that animator current animation with empty list should return default
        /// </summary>
        [Fact]
        public void Animator_CurrentAnimation_WithEmptyList_ShouldReturnDefault()
        {
            Animator animator = new Animator();

            Animation current = animator.CurrentAnimation;

            Assert.Null(current.Name);
            Assert.Equal(0, current.Order);
            Assert.Equal(0f, current.Speed, 5);
            Assert.Null(current.Frames);
        }

        /// <summary>
        /// Tests that animator context should be settable
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
        /// Tests that animator on start should not throw
        /// </summary>
        [Fact]
        public void Animator_OnStart_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnStart(null!);
        }

        /// <summary>
        /// Tests that animator on exit should not throw
        /// </summary>
        [Fact]
        public void Animator_OnExit_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnExit(null!);
        }

        /// <summary>
        /// Tests that animator should implement lifecycle interfaces
        /// </summary>
        [Fact]
        public void Animator_ShouldImplementLifecycleInterfaces()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IOnStart>(animator);
            Assert.IsAssignableFrom<IOnUpdate>(animator);
        }

        /// <summary>
        /// Tests that animator on update should advance frame when elapsed time exceeds frame duration
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
            Thread.Sleep(1);
            animator.OnUpdate(null!);

            Assert.True(animator.CurrentFrameIndex > 0, "OnUpdate should have advanced the frame");
        }

        /// <summary>
        /// Tests that animator on update with zero speed should not advance frame
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
            Thread.Sleep(1);
            animator.OnUpdate(null!);

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that animator on update should wrap around after last frame
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
            Thread.Sleep(1);
            animator.OnUpdate(null!);
            int frameAfterFirst = animator.CurrentFrameIndex;

            Thread.Sleep(1);
            animator.OnUpdate(null!);

            Assert.NotEqual(frameAfterFirst, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that animator on update with default struct should not throw
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_WithDefaultStruct_ShouldNotThrow()
        {
            Animator animator = default;

            animator.OnUpdate(null!);
        }

        /// <summary>
        /// Tests that animator draw animation with matching name file should not throw
        /// </summary>
        [Fact]
        public void Animator_DrawAnimation_WithMatchingNameFile_ShouldNotThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "sprite.png" }
                    }
                }
            };
            animator.Play("TestAnim");

            Context context = new Context();
            Sprite sprite = new Sprite(context, "sprite.png", 0);

            animator.DrawAnimation(ref sprite);
        }

        /// <summary>
        /// Tests that animator draw animation with different name file should throw
        /// </summary>
        [Fact]
        public void Animator_DrawAnimation_WithDifferentNameFile_ShouldThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame_texture.png" }
                    }
                }
            };
            animator.Play("TestAnim");

            Context context = new Context();
            Sprite sprite = new Sprite(context, "different_sprite.png", 0);

            Assert.ThrowsAny<Exception>(() => animator.DrawAnimation(ref sprite));
        }

        /// <summary>
        /// Tests that animator on update immediately after on start should not advance frame
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_ImmediatelyAfterOnStart_ShouldNotAdvanceFrame()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1" },
                        new Frame { NameFile = "frame2" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);

            animator.OnUpdate(null!);

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that animator current animation with default struct should throw null reference
        /// </summary>
        [Fact]
        public void Animator_CurrentAnimation_WithDefaultStruct_ShouldThrowNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => _ = animator.CurrentAnimation);
        }

        /// <summary>
        /// Tests that animator draw animation with null frame texture should throw
        /// </summary>
        [Fact]
        public void Animator_DrawAnimation_WithNullFrameTexture_ShouldThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame()
                    }
                }
            };
            animator.Play("TestAnim");

            Context context = new Context();
            Sprite sprite = new Sprite(context, "sprite.png", 0);

            Assert.ThrowsAny<Exception>(() => animator.DrawAnimation(ref sprite));
        }

        /// <summary>
        /// Tests that animator get current frame on default struct throws null reference
        /// </summary>
        [Fact]
        public void Animator_GetCurrentFrame_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => _ = animator.GetCurrentFrame());
        }

        /// <summary>
        /// Tests that animator play on default struct throws null reference
        /// </summary>
        [Fact]
        public void Animator_Play_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => animator.Play("test"));
        }

        /// <summary>
        /// Tests that animator next frame on default struct throws null reference
        /// </summary>
        [Fact]
        public void Animator_NextFrame_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => animator.NextFrame());
        }

        /// <summary>
        /// Tests that animator on start after on exit clock restarts
        /// </summary>
        [Fact]
        public void Animator_OnStart_AfterOnExit_ClockRestarts()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1" },
                        new Frame { NameFile = "frame2" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);
            animator.OnExit(null!);
            animator.OnStart(null!);

            animator.OnUpdate(null!);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that animator on update with high speed multiple updates
        /// </summary>
        [Fact]
        public void Animator_OnUpdate_WithHighSpeed_MultipleUpdates()
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
                        new Frame { NameFile = "frame2" },
                        new Frame { NameFile = "frame3" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);
            Thread.Sleep(1);
            animator.OnUpdate(null!);

            Assert.InRange(animator.CurrentFrameIndex, 1, 2);
        }

        /// <summary>
        /// Tests that animator add animation with multiple animations orders correctly
        /// </summary>
        [Fact]
        public void Animator_AddAnimation_WithMultipleAnimations_OrdersCorrectly()
        {
            Animator animator = new Animator();
            Animation first = new Animation("first", 0, 1f);
            Animation second = new Animation("second", 1, 2f);
            Animation third = new Animation("third", 2, 3f);

            animator.AddAnimation(first);
            animator.AddAnimation(second);
            animator.AddAnimation(third);

            Assert.Equal(3, animator.Animations.Count);
            Assert.Equal("first", animator.Animations[0].Name);
            Assert.Equal("second", animator.Animations[1].Name);
            Assert.Equal("third", animator.Animations[2].Name);
        }
    }
}
