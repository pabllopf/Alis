

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui mod flags test class
    /// </summary>
    public class ImGuiModFlagsTest
    {
        /// <summary>
        ///     Tests that none should be initialized correctly
        /// </summary>
        [Fact]
        public void None_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.None;

            Assert.Equal(0, (int) flag);
        }

        /// <summary>
        ///     Tests that ctrl should be initialized correctly
        /// </summary>
        [Fact]
        public void Ctrl_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Ctrl;

            Assert.Equal(1, (int) flag);
        }

        /// <summary>
        ///     Tests that shift should be initialized correctly
        /// </summary>
        [Fact]
        public void Shift_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Shift;

            Assert.Equal(2, (int) flag);
        }

        /// <summary>
        ///     Tests that alt should be initialized correctly
        /// </summary>
        [Fact]
        public void Alt_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Alt;

            Assert.Equal(4, (int) flag);
        }

        /// <summary>
        ///     Tests that super should be initialized correctly
        /// </summary>
        [Fact]
        public void Super_ShouldBeInitializedCorrectly()
        {
            ImGuiModFlags flag = ImGuiModFlags.Super;

            Assert.Equal(8, (int) flag);
        }
    }
}