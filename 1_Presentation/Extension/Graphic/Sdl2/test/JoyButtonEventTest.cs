using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class JoyButtonEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new JoyButtonEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
            Assert.Equal(0, evt.button);
            Assert.Equal(0, evt.state);
        }
    }
}
