using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiNavInput"/> enum values.
    /// </summary>
    public class ImGuiNavInputTest
    {
        /// <summary>
        /// Verifies that navigation input values are defined.
        /// </summary>
        [Fact]
        public void Activate_ShouldBeDefined()
        {
            ImGuiNavInput input = ImGuiNavInput.Activate;
            Assert.Equal(0, (int)input);
        }
    }
}

