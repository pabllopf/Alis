using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTableRowFlags"/> values.
    /// </summary>
    public class ImGuiTableRowFlagsTest
    {
        /// <summary>
        /// Verifies that headers row flag keeps value one.
        /// </summary>
        [Fact]
        public void Headers_ShouldBeOne()
        {
            Assert.Equal(1, (int) ImGuiTableRowFlags.Headers);
        }
    }
}

