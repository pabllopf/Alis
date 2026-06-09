using Xunit;
using System;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The img animation test class
    /// </summary>
    public class ImgAnimationTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            ImgAnimation anim = new ImgAnimation();
            Assert.Equal(0, anim.W);
            Assert.Equal(0, anim.H);
            Assert.Equal(IntPtr.Zero, anim.Frames);
            Assert.Equal(IntPtr.Zero, anim.Delays);
        }
    }
}
