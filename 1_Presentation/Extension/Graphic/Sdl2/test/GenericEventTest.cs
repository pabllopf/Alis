using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    public class GenericEventTest
    {
        [Fact]
        public void ShouldDefaultToZero()
        {
            GenericEvent evt = new GenericEvent();
            Assert.Equal(0u, evt.timestamp);
        }

        [Fact]
        public void ShouldAssignTypeAndTimestamp()
        {
            GenericEvent evt = new GenericEvent { type = EventType.MouseButtonDown, timestamp = 42u };
            Assert.Equal(EventType.MouseButtonDown, evt.type);
            Assert.Equal(42u, evt.timestamp);
        }
    }
}
