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
    public class AnimatorTest
    {
        [Fact]
        public void Animator_DefaultConstructor_ShouldCreateWithDefaultValues()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator.Animations);
            Assert.Empty(animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        [Fact]
        public void Animator_ShouldImplementIAnimatorInterface()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IAnimator>(animator);
        }

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

        [Fact]
        public void Animator_Methods_ShouldBeCallable()
        {
            Animator animator = new Animator();

            animator.AddAnimation(new Animation("test", 0, 1f));
            animator.Play("test");
            animator.NextFrame();
            animator.GetCurrentFrame();
        }

        [Fact]
        public void Animator_Constructor_ShouldNotThrow()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator);
        }

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

        [Fact]
        public void Animator_DefaultState_ShouldBeValid()
        {
            Animator animator = new Animator();

            Assert.NotNull(animator.Animations);
            Assert.IsType<List<Animation>>(animator.Animations);
            Assert.Equal(0, animator.CurrentAnimationIndex);
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

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

        [Fact]
        public void Animator_Play_WithNonExistentName_ShouldNotChangeIndex()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("idle", 0, 1f));

            animator.Play("nonexistent");

            Assert.Equal(0, animator.CurrentAnimationIndex);
        }

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

        [Fact]
        public void Animator_NextFrame_WithEmptyFrames_ShouldNotCrash()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("empty", 0, 1f));

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        [Fact]
        public void Animator_NextFrame_WithNoAnimations_ShouldNotCrash()
        {
            Animator animator = new Animator();

            animator.NextFrame();

            Assert.Equal(0, animator.CurrentFrameIndex);
        }

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

        [Fact]
        public void Animator_GetCurrentFrame_WithEmptyFrames_ShouldReturnDefault()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("empty", 0, 1f));

            Frame frame = animator.GetCurrentFrame();

            Assert.Null(frame.NameFile);
        }

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

        [Fact]
        public void Animator_Context_ShouldBeSettable()
        {
            Animator animator = new Animator();
            Context context = new Context();

            animator.Context = context;

            Assert.Same(context, animator.Context);
        }

        [Fact]
        public void Animator_OnStart_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnStart(null!);
        }

        [Fact]
        public void Animator_OnExit_ShouldNotThrow()
        {
            Animator animator = new Animator();

            animator.OnExit(null!);
        }

        [Fact]
        public void Animator_ShouldImplementLifecycleInterfaces()
        {
            Animator animator = new Animator();

            Assert.IsAssignableFrom<IOnStart>(animator);
            Assert.IsAssignableFrom<IOnUpdate>(animator);
        }

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

        [Fact]
        public void Animator_OnUpdate_WithDefaultStruct_ShouldNotThrow()
        {
            Animator animator = default;

            animator.OnUpdate(null!);
        }

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

        [Fact]
        public void Animator_CurrentAnimation_WithDefaultStruct_ShouldThrowNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => _ = animator.CurrentAnimation);
        }

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

        [Fact]
        public void Animator_GetCurrentFrame_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => _ = animator.GetCurrentFrame());
        }

        [Fact]
        public void Animator_Play_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => animator.Play("test"));
        }

        [Fact]
        public void Animator_NextFrame_OnDefaultStruct_ThrowsNullReference()
        {
            Animator animator = default;

            Assert.Throws<NullReferenceException>(() => animator.NextFrame());
        }

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
