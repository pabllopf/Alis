

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui key data test class
    /// </summary>
    public class ImGuiKeyDataTest
    {
        /// <summary>
        ///     Tests that down should set and get correctly
        /// </summary>
        [Fact]
        public void Down_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.Down = 1;
            Assert.Equal(1, keyData.Down);
        }

        /// <summary>
        ///     Tests that down duration should set and get correctly
        /// </summary>
        [Fact]
        public void DownDuration_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.DownDuration = 1.5f;
            Assert.Equal(1.5f, keyData.DownDuration);
        }

        /// <summary>
        ///     Tests that down duration prev should set and get correctly
        /// </summary>
        [Fact]
        public void DownDurationPrev_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.DownDurationPrev = 2.5f;
            Assert.Equal(2.5f, keyData.DownDurationPrev);
        }

        /// <summary>
        ///     Tests that analog value should set and get correctly
        /// </summary>
        [Fact]
        public void AnalogValue_Should_SetAndGetCorrectly()
        {
            ImGuiKeyData keyData = new ImGuiKeyData();
            keyData.AnalogValue = 3.5f;
            Assert.Equal(3.5f, keyData.AnalogValue);
        }
    }
}