using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class JoyHatEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            JoyHatEvent evt = new JoyHatEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
            Assert.Equal(0, evt.hat);
            Assert.Equal(0, evt.hatValue);
        }
    }
}
