using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformGetWindowFocus"/> delegate behavior.
    /// </summary>
    public class PlatformGetWindowFocusTest
    {
        /// <summary>
        /// Verifies that the delegate can return an expected byte result.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedValue()
        {
            PlatformGetWindowFocus callback = _ => 1;

            byte result = callback(new ImGuiViewportPtr(IntPtr.Zero));

            Assert.Equal((byte)1, result);
        }
    }
}

