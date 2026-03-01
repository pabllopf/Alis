using System;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformSetWindowSize"/> delegate behavior.
    /// </summary>
    public class PlatformSetWindowSizeTest
    {
        /// <summary>
        /// Verifies that the delegate receives the requested size.
        /// </summary>
        [Fact]
        public void Invoke_ShouldReceiveExpectedSize()
        {
            Vector2F expected = new Vector2F(1280.0f, 720.0f);
            Vector2F captured = default;
            PlatformSetWindowSize callback = (_, size) => captured = size;

            callback(new ImGuiViewportPtr(IntPtr.Zero), expected);

            Assert.Equal(expected, captured);
        }
    }
}

