using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class QuitEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            QuitEvent evt = new QuitEvent();
            Assert.Equal(0u, evt.timestamp);
        }
    }
}
