using Alis.Core.Graphic.Platforms.Web;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Web
{
    /// <summary>
    ///     Tests for EGL constants.
    /// </summary>
    public class EGLTest
    {
        [Fact]
        public void EglConstants_HaveExpectedValues()
        {
            Assert.Equal(0x3038, EGL.EGL_NONE);
            Assert.Equal(0x3024, EGL.EGL_RED_SIZE);
            Assert.Equal(0x3023, EGL.EGL_GREEN_SIZE);
            Assert.Equal(0x3022, EGL.EGL_BLUE_SIZE);
            Assert.Equal(0x3025, EGL.EGL_DEPTH_SIZE);
            Assert.Equal(0x3026, EGL.EGL_STENCIL_SIZE);
            Assert.Equal(0x3033, EGL.EGL_SURFACE_TYPE);
            Assert.Equal(0x3040, EGL.EGL_RENDERABLE_TYPE);
            Assert.Equal(0x3031, EGL.EGL_SAMPLES);
            Assert.Equal(0x0004, EGL.EGL_WINDOW_BIT);
            Assert.Equal(0x0004, EGL.EGL_OPENGL_ES2_BIT);
            Assert.Equal(0x00000040, EGL.EGL_OPENGL_ES3_BIT);
            Assert.Equal(0x3098, EGL.EGL_CONTEXT_CLIENT_VERSION);
            Assert.Equal(0x0, EGL.EGL_NO_CONTEXT);
            Assert.Equal(0x302E, EGL.EGL_NATIVE_VISUAL_ID);
            Assert.Equal(0x30A0, EGL.EGL_OPENGL_ES_API);
        }

        [Fact]
        public void EglConstants_LibEgl_IsCorrectString()
        {
            Assert.Equal("libEGL", EGL.LibEgl);
        }
    }
}
