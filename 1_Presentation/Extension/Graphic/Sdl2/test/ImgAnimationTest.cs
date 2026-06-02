using Xunit;
using System;
using Alis.Extension.Graphic.Sdl2.Sdl2Image;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class ImgAnimationTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var anim = new ImgAnimation();
            Assert.Equal(0, anim.W);
            Assert.Equal(0, anim.H);
            Assert.Equal(IntPtr.Zero, anim.Frames);
            Assert.Equal(IntPtr.Zero, anim.Delays);
        }
    }
}
