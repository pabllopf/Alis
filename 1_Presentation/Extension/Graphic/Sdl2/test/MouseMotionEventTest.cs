using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class MouseMotionEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new MouseMotionEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0u, evt.which);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.x);
            Assert.Equal(0, evt.y);
            Assert.Equal(0, evt.xRel);
            Assert.Equal(0, evt.yRel);
        }
    }
}
