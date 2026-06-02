using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class JoyDeviceEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            JoyDeviceEvent evt = new JoyDeviceEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
        }
    }
}
