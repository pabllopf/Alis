using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformGetWindowMinimized"/> delegate behavior.
    /// </summary>
    public class PlatformGetWindowMinimizedTest
    {
        /// <summary>
        /// Verifies that the delegate can return an expected byte result.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedValue()
        {
            PlatformGetWindowMinimized callback = _ => 0;

            byte result = callback(new ImGuiViewportPtr(IntPtr.Zero));

            Assert.Equal((byte)0, result);
        }
    }
}

