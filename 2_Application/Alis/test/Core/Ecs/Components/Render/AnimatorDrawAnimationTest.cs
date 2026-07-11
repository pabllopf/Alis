using System;
using System.Collections.Generic;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    /// <summary>
    /// The animator draw animation test class
    /// </summary>
    public class AnimatorDrawAnimationTest
    {
        /// <summary>
        /// Tests that draw animation when name file differs should call load texture
        /// </summary>
        [Fact]
        public void DrawAnimation_WhenNameFileDiffers_ShouldCallLoadTexture()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "frame1.png" }
                    }
                }
            };
            animator.Play("TestAnim");

            Sprite sprite = new Sprite(default, "different.png", 0);

            Assert.ThrowsAny<Exception>(() => animator.DrawAnimation(ref sprite));
        }

        /// <summary>
        /// Tests that draw animation when name file is same should not call load texture
        /// </summary>
        [Fact]
        public void DrawAnimation_WhenNameFileIsSame_ShouldNotCallLoadTexture()
        {
            Animator animator = new Animator();
            animator.Animations = new List<Animation>
            {
                new Animation
                {
                    Name = "TestAnim",
                    Frames = new List<Frame>
                    {
                        new Frame { NameFile = "same.png" }
                    }
                }
            };
            animator.Play("TestAnim");

            Sprite sprite = new Sprite(default, "same.png", 0);

            animator.DrawAnimation(ref sprite);
        }
    }
}
