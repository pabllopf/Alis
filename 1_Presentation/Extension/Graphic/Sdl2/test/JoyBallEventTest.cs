using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class JoyBallEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            JoyBallEvent evt = new JoyBallEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
            Assert.Equal(0, evt.ball);
        }
    }
}
