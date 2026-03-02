using Alis.Extension.Graphic.Ui;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// Provides unit coverage for <see cref="ImGuiInputTextFlags"/> values.
    /// </summary>
    public class ImGuiInputTextFlagsTest
    {
        /// <summary>
        /// Verifies that none is zero.
        /// </summary>
        [Fact]
        public void None_ShouldBeZero()
        {
            Assert.Equal(0, (int) ImGuiInputTextFlags.None);
        }

        /// <summary>
        /// Verifies representative flags use distinct bit values.
        /// </summary>
        [Fact]
        public void RepresentativeFlags_ShouldBeDistinct()
        {
            Assert.NotEqual((int) ImGuiInputTextFlags.CharsDecimal, (int) ImGuiInputTextFlags.CharsHexadecimal);
            Assert.NotEqual((int) ImGuiInputTextFlags.ReadOnly, (int) ImGuiInputTextFlags.Password);
            Assert.NotEqual((int) ImGuiInputTextFlags.CallbackResize, (int) ImGuiInputTextFlags.CallbackEdit);
        }
    }
}

