using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformSetWindowPos"/> delegate behavior.
    /// </summary>
    public class PlatformSetWindowPosTest
    {
        /// <summary>
        /// Verifies that the delegate receives the requested position.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReceiveExpectedPosition()
        {
            Vector2F expected = new Vector2F(30.0f, 40.0f);
            Vector2F captured = default;
            PlatformSetWindowPos callback = (_, pos) => captured = pos;

            callback(new ImGuiViewportPtr(IntPtr.Zero), expected);

            Assert.Equal(expected, captured);
        }
    }
}

