using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// Provides unit coverage for plot-specific <see cref="ImGuiDragDropFlags"/> values.
    /// </summary>
    public class ImGuiDragDropFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiDragDropFlags.None);
        }

        /// <summary>
        /// Verifies that source and accept flags remain distinct.
        /// </summary>
        [Fact]
        public void SourceAndAcceptFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiDragDropFlags.SourceExtern, (int) ImGuiDragDropFlags.AcceptBeforeDelivery);
            Assert.NotEqual((int) ImGuiDragDropFlags.SourceAutoExpirePayload, (int) ImGuiDragDropFlags.AcceptNoPreviewTooltip);
        }

        /// <summary>
        /// Verifies that accept-peek-only matches expected composition.
        /// </summary>
        [Fact]
        public void AcceptPeekOnly_ShouldMatchExpectedComposition()
        {
            ImGuiDragDropFlags expected = ImGuiDragDropFlags.AcceptBeforeDelivery | ImGuiDragDropFlags.AcceptNoDrawDefaultRect;

            Assert.Equal(expected, ImGuiDragDropFlags.AcceptPeekOnly);
        }
    }
}

