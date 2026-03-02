using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiTreeNodeFlags"/> values and aliases.
    /// </summary>
    public class ImGuiTreeNodeFlagsTest
    {
        /// <summary>
        /// Verifies that collapsing-header alias matches its documented composition.
        /// </summary>
        [Fact]
        public void CollapsingHeader_ShouldMatchComposition()
        {
            ImGuiTreeNodeFlags expected = ImGuiTreeNodeFlags.Framed
                                          | ImGuiTreeNodeFlags.NoTreePushOnOpen
                                          | ImGuiTreeNodeFlags.NoAutoOpenOnLog;

            Assert.Equal(expected, ImGuiTreeNodeFlags.CollapsingHeader);
        }
    }
}

