

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui text filter test class
    /// </summary>
    public class ImGuiTextFilterTest
    {
        /// <summary>
        ///     Tests that input buf should set and get correctly
        /// </summary>
        [Fact]
        public void InputBuf_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            byte[] inputBuf = new byte[256];
            textFilter.InputBuf = inputBuf;
            Assert.Equal(inputBuf, textFilter.InputBuf);
        }

        /// <summary>
        ///     Tests that filters should set and get correctly
        /// </summary>
        [Fact]
        public void Filters_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            ImVector filters = new ImVector();
            textFilter.Filters = filters;
            Assert.Equal(filters, textFilter.Filters);
        }

        /// <summary>
        ///     Tests that count grep should set and get correctly
        /// </summary>
        [Fact]
        public void CountGrep_Should_SetAndGetCorrectly()
        {
            ImGuiTextFilter textFilter = new ImGuiTextFilter();
            textFilter.CountGrep = 5;
            Assert.Equal(5, textFilter.CountGrep);
        }
    }
}