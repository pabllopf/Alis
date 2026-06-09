using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The quit event test class
    /// </summary>
    public class QuitEventTest
    {
        /// <summary>
        /// Tests that should default to zero
        /// </summary>
        [Fact]
        public void ShouldDefaultToZero()
        {
            QuitEvent evt = new QuitEvent();
            Assert.Equal(0u, evt.timestamp);
        }
    }
}
