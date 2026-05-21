

using Alis.Extension.Graphic.Glfw.Structs;
using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for GlfwNative monitor-related methods
    /// </summary>
    public class GlfwNativeMonitorTests
    {
        /// <summary>
        ///     Gets the monitors returns non null array
        /// </summary>
        [RequiresDisplay]
        public void GetMonitors_ReturnsNonNullArray()
        {
            Monitor[] monitors = GlfwNative.Monitors;

            Assert.NotNull(monitors);
        }

        /// <summary>
        ///     Gets the primary monitor returns monitor
        /// </summary>
        [RequiresDisplay]
        public void GetPrimaryMonitor_ReturnsMonitor()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;

            Assert.True(monitor == Monitor.None || monitor != Monitor.None);
        }

        /// <summary>
        ///     Gets the monitor physical size with valid monitor returns size
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorPhysicalSize_WithValidMonitor_ReturnsSize()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorPhysicalSize(monitor, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }

        /// <summary>
        ///     Gets the monitor position with valid monitor returns position
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorPosition_WithValidMonitor_ReturnsPosition()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorPosition(monitor, out int x, out int y);

            Assert.True(x != int.MinValue);
            Assert.True(y != int.MinValue);
        }

        /// <summary>
        ///     Gets the monitor work area with valid monitor returns work area
        /// </summary>
        [RequiresDisplay]
        public void GetMonitorWorkArea_WithValidMonitor_ReturnsWorkArea()
        {
            Monitor monitor = GlfwNative.PrimaryMonitor;
            if (monitor == Monitor.None)
            {
                return;
            }

            GlfwNative.GetMonitorWorkArea(monitor, out int x, out int y, out int width, out int height);

            Assert.True(width > 0);
            Assert.True(height > 0);
        }
    }
}