using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformGetWindowPos"/> delegate behavior.
    /// </summary>
    public class PlatformGetWindowPosTest
    {
        /// <summary>
        /// Verifies that the delegate can return a position through an out parameter.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReturnExpectedOutPosition()
        {
            Vector2F expected = new Vector2F(10.0f, 20.0f);
            PlatformGetWindowPos callback = (ImGuiViewportPtr _, out Vector2F outPos) => outPos = expected;

            callback(new ImGuiViewportPtr(IntPtr.Zero), out Vector2F result);

            Assert.Equal(expected, result);
        }
    }
}

