using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;
using Alis.Extension.Graphic.Sdl2.Enums;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The generic event test class
    /// </summary>
    public class GenericEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            GenericEvent evt = new GenericEvent();
            Assert.Equal(0u, evt.timestamp);
        }

        /// <summary>
        /// Tests that should assign type and timestamp
        /// </summary>
        [Fact]
        public void ShouldAssignTypeAndTimestamp()
        {
            GenericEvent evt = new GenericEvent { type = EventType.MouseButtonDown, timestamp = 42u };
            Assert.Equal(EventType.MouseButtonDown, evt.type);
            Assert.Equal(42u, evt.timestamp);
        }
    }
}
