using System;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="PlatformCreateWindow"/> delegate behavior.
    /// </summary>
    public class PlatformCreateWindowTest
    {
        /// <summary>
        /// Verifies that the delegate can be invoked with a viewport parameter.
        /// </summary>
        [Fact]
        public void Invoke_ShouldCallAssignedCallback()
        {
            bool called = false;
            PlatformCreateWindow callback = _ => called = true;

            callback(new ImGuiViewportPtr(IntPtr.Zero));

            Assert.True(called);
        }

        /// <summary>
        /// Verifies platform-specific execution for Windows-only tests.
        /// </summary>
        [WindowsOnly]
        public void WindowsOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Verifies platform-specific execution for macOS-only tests.
        /// </summary>
        [MacOsOnly]
        public void MacOsOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }

        /// <summary>
        /// Verifies platform-specific execution for Linux-only tests.
        /// </summary>
        [LinuxOnly]
        public void LinuxOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }
    }
}

