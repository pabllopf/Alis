using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class MouseButtonEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new MouseButtonEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0u, evt.which);
            Assert.Equal(0, evt.button);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.clicks);
            Assert.Equal(0, evt.x);
            Assert.Equal(0, evt.y);
        }
    }
}
