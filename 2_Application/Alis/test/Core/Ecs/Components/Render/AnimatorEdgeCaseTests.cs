// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimatorEdgeCaseTests.cs
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
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class AnimatorEdgeCaseTests
    {
        [Fact]
        public void Play_WithEmptyList_ShouldNotThrow()
        {
            Animator animator = new Animator();
            animator.Play("anything");
            Assert.Equal(0, animator.CurrentAnimationIndex);
        }

        [Fact]
        public void Play_WithMultipleAnimationsSameName_ShouldFindFirst()
        {
            Animator animator = new Animator();
            animator.AddAnimation(new Animation("dup", 0, 1f));
            animator.AddAnimation(new Animation("dup", 1, 1f));
            animator.Play("dup");
            Assert.Equal(0, animator.CurrentAnimationIndex);
        }

        [Fact]
        public void NextFrame_WithSingleFrame_ShouldStayOnZero()
        {
            Animation anim = new Animation("test", 0, 1f);
            anim.Frames.Add(new Frame { NameFile = "only.png" });
            Animator animator = new Animator(new List<Animation> { anim });
            animator.NextFrame();
            Assert.Equal(0, animator.CurrentFrameIndex);
        }

        [Fact]
        public void GetCurrentFrame_WithNoAnimations_ReturnsDefault()
        {
            Animator animator = new Animator();
            Frame frame = animator.GetCurrentFrame();
            Assert.Null(frame.NameFile);
        }

        [Fact]
        public void AddAnimation_Default_ShouldAddToList()
        {
            Animator animator = new Animator();
            animator.AddAnimation(default);
            Assert.Single(animator.Animations);
        }

        [Fact]
        public void OnUpdate_MultipleCycles_ShouldNotThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "Test",
                    Speed = 10000f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);

            for (int i = 0; i < 10; i++)
            {
                animator.OnUpdate(null!);
            }
        }

        [Fact]
        public void DrawAnimation_WithEmptyAnimationList_ShouldThrow()
        {
            Animator animator = new Animator();
            Sprite sprite = new Sprite(default, "test.png", 0);
            Assert.ThrowsAny<System.Exception>(() => animator.DrawAnimation(ref sprite));
        }

        [Fact]
        public void DrawAnimation_WithZeroFrameAnimation_ShouldThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "Empty",
                    Speed = 1f,
                    Frames = new List<Frame>()
                }
            };
            animator.Play("Empty");
            Sprite sprite = new Sprite(default, "test.png", 0);
            Assert.ThrowsAny<System.Exception>(() => animator.DrawAnimation(ref sprite));
        }

        [Fact]
        public void OnStart_ThenOnExit_ThenOnUpdate_ShouldNotThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "Test",
                    Speed = 1f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "f1" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);
            animator.OnExit(null!);
            animator.OnUpdate(null!);
        }

        [Fact]
        public void ListConstructor_WithNullAnimations_ShouldSetNull()
        {
            Animator animator = new Animator(null!);
            Assert.Null(animator.Animations);
        }

        [Fact]
        public void CurrentAnimation_OutOfRangeIndex_ShouldThrow()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation("a", 0, 1f)
            };
            animator.CurrentAnimationIndex = 5;
            Assert.ThrowsAny<System.Exception>(() => _ = animator.CurrentAnimation);
        }

        [Fact]
        public void OnUpdate_AfterPlayWithNoAnimations_ShouldNotThrow()
        {
            Animator animator = new Animator();
            animator.Play("nonexistent");
            animator.OnStart(null!);
            animator.OnUpdate(null!);
        }
    }
}
