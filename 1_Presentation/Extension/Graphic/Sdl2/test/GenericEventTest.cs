using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class GenericEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            var evt = new GenericEvent();
            Assert.Equal(0u, evt.timestamp);
        }
    }
}
