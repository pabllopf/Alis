using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class MultiGestureEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new MultiGestureEvent();
            Assert.Equal(0u, evt.type);
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0L, evt.touchId);
            Assert.Equal(0f, evt.dTheta);
            Assert.Equal(0f, evt.dDist);
            Assert.Equal(0f, evt.x);
            Assert.Equal(0f, evt.y);
            Assert.Equal(0, evt.numFingers);
            Assert.Equal(0, evt.padding);
        }
    }
}
