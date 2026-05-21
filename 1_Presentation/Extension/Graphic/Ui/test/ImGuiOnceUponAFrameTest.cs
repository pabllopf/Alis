

using System.Diagnostics.CodeAnalysis;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui once upon frame tets class
    /// </summary>
    [ExcludeFromCodeCoverage]
    public class ImGuiOnceUponAFrameTest
    {
        /// <summary>
        ///     Tests that ref frame should set and get correctly
        /// </summary>
        [Fact]
        public void RefFrame_Should_SetAndGetCorrectly()
        {
            ImGuiOnceUponAFrame onceUponAFrame = new ImGuiOnceUponAFrame();
            onceUponAFrame.RefFrame = 10;
            Assert.Equal(10, onceUponAFrame.RefFrame);
        }
    }
}