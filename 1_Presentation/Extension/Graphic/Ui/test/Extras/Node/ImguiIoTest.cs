

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The io test class
    /// </summary>
    public class ImguiIoTest
    {
        /// <summary>
        ///     Tests that emulate three button mouse should be initialized
        /// </summary>
        [Fact]
        public void EmulateThreeButtonMouse_ShouldBeInitialized()
        {
            ImguiIo imguiIo = new ImguiIo();
            Assert.Equal(default(EmulateThreeButtonMouse), imguiIo.EmulateThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that link detach with modifier click should be initialized
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_ShouldBeInitialized()
        {
            ImguiIo imguiIo = new ImguiIo();
            Assert.Equal(default(LinkDetachWithModifierClick), imguiIo.LinkDetachWithModifierClick);
        }

        /// <summary>
        ///     Tests that emulate three button mouse should set and get correctly
        /// </summary>
        [Fact]
        public void EmulateThreeButtonMouse_Should_SetAndGetCorrectly()
        {
            ImguiIo imguiIo = new ImguiIo();
            EmulateThreeButtonMouse value = new EmulateThreeButtonMouse();
            imguiIo.EmulateThreeButtonMouse = value;
            Assert.Equal(value, imguiIo.EmulateThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that link detach with modifier click should set and get correctly
        /// </summary>
        [Fact]
        public void LinkDetachWithModifierClick_Should_SetAndGetCorrectly()
        {
            ImguiIo imguiIo = new ImguiIo();
            LinkDetachWithModifierClick value = new LinkDetachWithModifierClick();
            imguiIo.LinkDetachWithModifierClick = value;
            Assert.Equal(value, imguiIo.LinkDetachWithModifierClick);
        }
    }
}