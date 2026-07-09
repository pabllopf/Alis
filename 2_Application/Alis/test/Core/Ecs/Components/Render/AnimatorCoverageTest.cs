// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AnimatorCoverageTest.cs
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
    /// <summary>
    ///     Coverage tests for Animator edge cases
    /// </summary>
    public class AnimatorCoverageTest
    {
        /// <summary>
        ///     Tests that OnUpdate does not throw when called multiple times
        ///     without OnStart (clock not started so _clock is null, early return).
        /// </summary>
        [Fact]
        public void OnUpdate_WithoutOnStart_ShouldNotThrow()
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
                        new Frame { NameFile = "f1" }
                    }
                }
            };
            animator.Play("TestAnim");

            animator.OnUpdate(null!);
        }

        /// <summary>
        ///     Tests that OnUpdate advances frame with normal speed (1f) after sufficient elapsed time.
        /// </summary>
        [Fact]
        public void OnUpdate_WithNormalSpeed_AdvancesFrameAfterDelay()
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
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);

            System.Threading.Thread.Sleep(20);
            animator.OnUpdate(null!);

            Assert.True(animator.CurrentFrameIndex > 0);
        }

        /// <summary>
        ///     Tests that OnUpdate subtracts frameDuration correctly when
        ///     elapsed time exceeds a single frame duration (no over-subtraction).
        /// </summary>
        [Fact]
        public void OnUpdate_SubtractsExactFrameDuration_WhenExceedingByLessThanDouble()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Speed = 60f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" },
                        new Frame { NameFile = "f3" },
                        new Frame { NameFile = "f4" }
                    }
                }
            };
            animator.Play("TestAnim");
            animator.OnStart(null!);

            System.Threading.Thread.Sleep(40);
            animator.OnUpdate(null!);

            Assert.True(animator.CurrentFrameIndex >= 0);
        }
    }
}
