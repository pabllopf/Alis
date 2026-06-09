using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The joy axis event test class
    /// </summary>
    public class JoyAxisEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            JoyAxisEvent evt = new JoyAxisEvent();
            Assert.Equal(0u, evt.timestamp);
            Assert.Equal(0, evt.which);
            Assert.Equal(0, evt.axis);
        }
    }
}
