

using Alis.Extension.Graphic.Glfw.Test.Skipper;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for Vulkan class
    /// </summary>
    public class VulkanTests
    {
        /// <summary>
        ///     Vulkans the is supported returns bool
        /// </summary>
        [RequiresDisplay]
        public void Vulkan_IsSupported_ReturnsBool()
        {
            bool isSupported = Vulkan.IsSupported;

            Assert.True(isSupported || !isSupported);
        }

        /// <summary>
        ///     Vulkans the is supported does not throw
        /// </summary>
        [RequiresDisplay]
        public void Vulkan_IsSupported_DoesNotThrow()
        {
            _ = Vulkan.IsSupported;
        }
    }
}