using System.Collections.Generic;
using Alis.Core.Ecs.Components.Render;
using Xunit;

namespace Alis.Test.Core.Ecs.Components.Render
{
    public class AnimatorDrawAnimationTest
    {
        [Fact]
        public void DrawAnimation_WhenNameFileDiffers_ShouldNotThrow()
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

            Assert.Throws<Alis.Core.Graphic.OpenGL.GlException>(() => animator.DrawAnimation(ref sprite));
        }

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
