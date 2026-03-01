using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformGetWindowSize"/> delegate behavior.
    /// </summary>
    public class PlatformGetWindowSizeTest
    {
        /// <summary>
        /// Verifies that the delegate can return a size through an out parameter.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedOutSize()
        {
            Vector2F expected = new Vector2F(1920.0f, 1080.0f);
            PlatformGetWindowSize callback = (ImGuiViewportPtr _, out Vector2F outSize) => outSize = expected;

            callback(new ImGuiViewportPtr(IntPtr.Zero), out Vector2F result);

            Assert.Equal(expected, result);
        }
    }
}

