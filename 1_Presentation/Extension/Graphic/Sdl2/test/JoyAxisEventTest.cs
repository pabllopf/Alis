using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class JoyAxisEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new JoyAxisEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
            Assert.Equal(0, evt.axis);
        }
    }
}
