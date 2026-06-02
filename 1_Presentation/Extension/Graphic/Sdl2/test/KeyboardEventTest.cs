using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class KeyboardEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new KeyboardEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0u, evt.windowID);
            Assert.Equal(0, evt.state);
            Assert.Equal(0, evt.repeat);
        }
    }
}
