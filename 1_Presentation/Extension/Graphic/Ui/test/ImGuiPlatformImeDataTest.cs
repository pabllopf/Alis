

using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui platform ime data test class
    /// </summary>
    public class ImGuiPlatformImeDataTest
    {
        /// <summary>
        ///     Tests that want visible should set and get correctly
        /// </summary>
        [Fact]
        public void WantVisible_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            platformImeData.WantVisible = 1;
            Assert.Equal(1, platformImeData.WantVisible);
        }

        /// <summary>
        ///     Tests that input pos should set and get correctly
        /// </summary>
        [Fact]
        public void InputPos_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            Vector2F inputPos = new Vector2F(1.0f, 2.0f);
            platformImeData.InputPos = inputPos;
            Assert.Equal(inputPos, platformImeData.InputPos);
        }

        /// <summary>
        ///     Tests that input line height should set and get correctly
        /// </summary>
        [Fact]
        public void InputLineHeight_Should_SetAndGetCorrectly()
        {
            ImGuiPlatformImeData platformImeData = new ImGuiPlatformImeData();
            platformImeData.InputLineHeight = 15.5f;
            Assert.Equal(15.5f, platformImeData.InputLineHeight);
        }
    }
}