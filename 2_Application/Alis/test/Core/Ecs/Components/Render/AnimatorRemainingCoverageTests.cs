using System.Collections.Generic;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator remaining coverage tests class
    /// </summary>
    public class AnimatorRemainingCoverageTests
    {
        /// <summary>
        /// Tests that get current frame with empty animation list returns default frame
        /// </summary>
        [Fact]
        public void GetCurrentFrame_WithEmptyAnimationList_ReturnsDefaultFrame()
        {
            Animator animator = new Animator();

            Frame frame = animator.GetCurrentFrame();

            Assert.Null(frame.NameFile);
        }

        /// <summary>
        /// Tests that on update with internal elapsed time advances frame
        /// </summary>
        [Fact]
        public void OnUpdate_WithInternalElapsedTime_AdvancesFrame()
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
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);

            float frameDuration = 1f / (1f * 60f);
            animator._elapsedTime = frameDuration * 1.5f;

            animator.OnUpdate(null!);

            Assert.Equal(1, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that on update with exact frame duration advances frame
        /// </summary>
        [Fact]
        public void OnUpdate_WithExactFrameDuration_AdvancesFrame()
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
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);

            float frameDuration = 1f / (1f * 60f);
            animator._elapsedTime = frameDuration;

            animator.OnUpdate(null!);

            Assert.Equal(1, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that on update advances multiple frames when elapsed time is large
        /// </summary>
        [Fact]
        public void OnUpdate_AdvancesMultipleFrames_WhenElapsedTimeIsLarge()
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
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" },
                        new Frame { NameFile = "f3" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);

            float frameDuration = 1f / (1f * 60f);
            animator._elapsedTime = frameDuration * 2.5f;

            animator.OnUpdate(null!);

            Assert.Equal(1, animator.CurrentFrameIndex);
        }

        /// <summary>
        /// Tests that on update with empty animation list does not throw
        /// </summary>
        [Fact]
        public void OnUpdate_WithEmptyAnimationList_DoesNotThrow()
        {
            Animator animator = new Animator();
            animator.OnStart(null!);

            animator.OnUpdate(null!);
        }

        /// <summary>
        /// Tests that on update with zero speed and elapsed time does not advance
        /// </summary>
        [Fact]
        public void OnUpdate_WithZeroSpeedAndElapsedTime_DoesNotAdvance()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "Test",
                    Speed = 0f,
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "f1" },
                        new Frame { NameFile = "f2" }
                    }
                }
            };
            animator.Play("Test");
            animator.OnStart(null!);

            animator._elapsedTime = 10f;

            animator.OnUpdate(null!);

            Assert.Equal(0, animator.CurrentFrameIndex);
        }
    }
}
