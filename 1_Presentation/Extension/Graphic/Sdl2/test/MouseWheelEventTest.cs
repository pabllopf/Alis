using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class MouseWheelEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            MouseWheelEvent evt = new MouseWheelEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0u, evt.which);
            Assert.Equal(0, evt.x);
            Assert.Equal(0, evt.y);
            Assert.Equal(0u, evt.direction);
            Assert.Equal(0f, evt.preciseX);
            Assert.Equal(0f, evt.preciseY);
        }
    }
}
