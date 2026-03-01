using System;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformSetWindowFocus"/> delegate behavior.
    /// </summary>
    public class PlatformSetWindowFocusTest
    {
        /// <summary>
        /// Verifies that the delegate can be invoked and receives a viewport.
        /// </summary>
        [Fact]
        public void Invoke_ShouldCallAssignedCallback()
        {
            bool called = false;
            PlatformSetWindowFocus callback = _ => called = true;

            callback(new ImGuiViewportPtr(IntPtr.Zero));

            Assert.True(called);
        }
    }
}

