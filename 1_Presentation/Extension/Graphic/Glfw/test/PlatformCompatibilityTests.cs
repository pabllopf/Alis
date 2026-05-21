

using System.Runtime.InteropServices;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for platform compatibility (Windows, Linux, macOS)
    /// </summary>
    public class PlatformCompatibilityTests
    {
        /// <summary>
        ///     Test platform detection
        /// </summary>
        [Fact]
        public void PlatformDetection_ShouldIdentifyOS()
        {
            bool isWindows = RuntimeInformation.IsOSPlatform(OSPlatform.Windows);
            bool isLinux = RuntimeInformation.IsOSPlatform(OSPlatform.Linux);
            bool isMacOS = RuntimeInformation.IsOSPlatform(OSPlatform.OSX);

            Assert.True(isWindows || isLinux || isMacOS);
        }
    }
}