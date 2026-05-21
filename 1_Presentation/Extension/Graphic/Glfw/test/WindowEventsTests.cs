

using Alis.Core.Graphic.OpenGL;
using Alis.Extension.Graphic.Glfw.Enums;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for window events and callbacks
    /// </summary>
    [Collection("GLFW")]
    public class WindowEventsTests
    {
        /// <summary>
        ///     Disposes the window with subscribed events should succeed
        /// </summary>
        [RequiresDisplay]
        public void DisposeWindowWithSubscribedEvents_ShouldSucceed()
        {
            GlfwNative.Init();

            Gl.Initialize(GlfwNative.GetProcAddress);

            GlfwNative.WindowHint(Hint.ContextVersionMajor, 3);
            GlfwNative.WindowHint(Hint.ContextVersionMinor, 2);
            GlfwNative.WindowHint(Hint.OpenglProfile, GlfwProfile.Core);
            GlfwNative.WindowHint(Hint.OpenglForwardCompatible, true);
            GlfwNative.WindowHint(Hint.Doublebuffer, true);
            GlfwNative.WindowHint(Hint.DepthBits, 24);
            GlfwNative.WindowHint(Hint.AlphaBits, 8);
            GlfwNative.WindowHint(Hint.StencilBits, 8);

            NativeWindow window = new NativeWindow(800, 600, "Test");
            window.Closed += (s, e) => { };
            window.FocusChanged += (s, e) => { };
            window.Dispose();
            Assert.NotNull(window);
        }
    }
}