using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The joy device event test class
    /// </summary>
    public class JoyDeviceEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            JoyDeviceEvent evt = new JoyDeviceEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
        }
    }
}
