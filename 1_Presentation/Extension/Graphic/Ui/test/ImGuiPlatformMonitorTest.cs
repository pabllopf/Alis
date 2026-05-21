

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform monitor test class
    /// </summary>
    public class ImGuiPlatformMonitorTest
    {
        /// <summary>
        ///     Tests that main pos should be initialized correctly
        /// </summary>
        [Fact]
        public void MainPos_ShouldBeInitializedCorrectly()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {MainPos = new Vector2F(1, 2)};

            Vector2F result = monitor.MainPos;

            Assert.Equal(new Vector2F(1, 2), result);
        }

        /// <summary>
        ///     Tests that main size should be initialized correctly
        /// </summary>
        [Fact]
        public void MainSize_ShouldBeInitializedCorrectly()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {MainSize = new Vector2F(3, 4)};

            Vector2F result = monitor.MainSize;

            Assert.Equal(new Vector2F(3, 4), result);
        }

        /// <summary>
        ///     Tests that work pos should be initialized correctly
        /// </summary>
        [Fact]
        public void WorkPos_ShouldBeInitializedCorrectly()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {WorkPos = new Vector2F(5, 6)};

            Vector2F result = monitor.WorkPos;

            Assert.Equal(new Vector2F(5, 6), result);
        }

        /// <summary>
        ///     Tests that work size should be initialized correctly
        /// </summary>
        [Fact]
        public void WorkSize_ShouldBeInitializedCorrectly()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {WorkSize = new Vector2F(7, 8)};

            Vector2F result = monitor.WorkSize;

            Assert.Equal(new Vector2F(7, 8), result);
        }

        /// <summary>
        ///     Tests that dpi scale should be initialized correctly
        /// </summary>
        [Fact]
        public void DpiScale_ShouldBeInitializedCorrectly()
        {
            ImGuiPlatformMonitor monitor = new ImGuiPlatformMonitor {DpiScale = 1.5f};

            float result = monitor.DpiScale;

            Assert.Equal(1.5f, result);
        }
    }
}