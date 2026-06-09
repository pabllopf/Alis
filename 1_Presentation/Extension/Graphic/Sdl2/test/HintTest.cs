using Xunit;
using Alis.Extension.Graphic.Sdl2.Structs;

namespace Alis.Extension.Graphic.Sdl2.Test
{
    /// <summary>
    /// The hint test class
    /// </summary>
    public class HintTest
    {
        /// <summary>
        /// Tests that should have non empty constants
        /// </summary>
        [Fact]
        public void ShouldHaveNonEmptyConstants()
        {
            Assert.Equal("SDL_FRAMEBUFFER_ACCELERATION", Hint.HintFramebufferAcceleration);
            Assert.Equal("SDL_RENDER_DRIVER", Hint.HintRenderDriver);
            Assert.Equal("SDL_RENDER_VSYNC", Hint.HintRenderVsync);
            Assert.Equal("SDL_GRAB_KEYBOARD", Hint.HintGrabKeyboard);
        }
    }
}
