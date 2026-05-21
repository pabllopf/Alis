

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The emulate three button mouse test class
    /// </summary>
    public class EmulateThreeButtonMouseTest
    {
        /// <summary>
        ///     Tests that modifier should be initialized
        /// </summary>
        [Fact]
        public void Modifier_ShouldBeInitialized()
        {
            EmulateThreeButtonMouse emulateThreeButtonMouse = new EmulateThreeButtonMouse();
            Assert.Null(emulateThreeButtonMouse.Modifier);
        }

        /// <summary>
        ///     Tests that modifier should set and get correctly
        /// </summary>
        [Fact]
        public void Modifier_Should_SetAndGetCorrectly()
        {
            EmulateThreeButtonMouse emulateThreeButtonMouse = new EmulateThreeButtonMouse();
            byte[] value = {1, 2, 3};
            emulateThreeButtonMouse.Modifier = value;
            Assert.Equal(value, emulateThreeButtonMouse.Modifier);
        }
    }
}