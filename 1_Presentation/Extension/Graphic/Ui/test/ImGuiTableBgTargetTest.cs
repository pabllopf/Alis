using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTableBgTarget"/> values.
    /// </summary>
    public class ImGuiTableBgTargetTest
    {
        /// <summary>
        /// Verifies that row and cell background targets keep stable ordinals.
        /// </summary>
        [Fact]
        public void Targets_ShouldKeepExpectedOrder()
        {
            Assert.Equal(0, (int) ImGuiTableBgTarget.None);
            Assert.Equal(1, (int) ImGuiTableBgTarget.RowBg0);
            Assert.Equal(2, (int) ImGuiTableBgTarget.RowBg1);
            Assert.Equal(3, (int) ImGuiTableBgTarget.CellBg);
        }
    }
}

