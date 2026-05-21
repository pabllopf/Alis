

using Alis.Extension.Graphic.Ui.Extras.Node;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Node
{
    /// <summary>
    ///     The im nodes io test class
    /// </summary>
    public class ImNodesIoTest
    {
        /// <summary>
        ///     Tests that three button mouse should be initialized
        /// </summary>
        [Fact]
        public void ThreeButtonMouse_ShouldBeInitialized()
        {
            ImNodesIo io = new ImNodesIo();
            Assert.Equal(default(EmulateThreeButtonMouse), io.ThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that detach with modifier click should be initialized
        /// </summary>
        [Fact]
        public void DetachWithModifierClick_ShouldBeInitialized()
        {
            ImNodesIo io = new ImNodesIo();
            Assert.Equal(default(LinkDetachWithModifierClick), io.DetachWithModifierClick);
        }

        /// <summary>
        ///     Tests that select modifier should be initialized
        /// </summary>
        [Fact]
        public void SelectModifier_ShouldBeInitialized()
        {
            ImNodesIo io = new ImNodesIo();
            Assert.Equal(default(MultipleSelectModifier), io.SelectModifier);
        }

        /// <summary>
        ///     Tests that alt mouse button should be initialized
        /// </summary>
        [Fact]
        public void AltMouseButton_ShouldBeInitialized()
        {
            ImNodesIo io = new ImNodesIo();
            Assert.Equal(default(int), io.AltMouseButton);
        }

        /// <summary>
        ///     Tests that auto panning speed should be initialized
        /// </summary>
        [Fact]
        public void AutoPanningSpeed_ShouldBeInitialized()
        {
            ImNodesIo io = new ImNodesIo();
            Assert.Equal(default(float), io.AutoPanningSpeed);
        }

        /// <summary>
        ///     Tests that three button mouse should set and get correctly
        /// </summary>
        [Fact]
        public void ThreeButtonMouse_Should_SetAndGetCorrectly()
        {
            ImNodesIo io = new ImNodesIo();
            EmulateThreeButtonMouse value = new EmulateThreeButtonMouse();
            io.ThreeButtonMouse = value;
            Assert.Equal(value, io.ThreeButtonMouse);
        }

        /// <summary>
        ///     Tests that detach with modifier click should set and get correctly
        /// </summary>
        [Fact]
        public void DetachWithModifierClick_Should_SetAndGetCorrectly()
        {
            ImNodesIo io = new ImNodesIo();
            LinkDetachWithModifierClick value = new LinkDetachWithModifierClick();
            io.DetachWithModifierClick = value;
            Assert.Equal(value, io.DetachWithModifierClick);
        }

        /// <summary>
        ///     Tests that select modifier should set and get correctly
        /// </summary>
        [Fact]
        public void SelectModifier_Should_SetAndGetCorrectly()
        {
            ImNodesIo io = new ImNodesIo();
            MultipleSelectModifier value = new MultipleSelectModifier();
            io.SelectModifier = value;
            Assert.Equal(value, io.SelectModifier);
        }

        /// <summary>
        ///     Tests that alt mouse button should set and get correctly
        /// </summary>
        [Fact]
        public void AltMouseButton_Should_SetAndGetCorrectly()
        {
            ImNodesIo io = new ImNodesIo();
            int value = 1;
            io.AltMouseButton = value;
            Assert.Equal(value, io.AltMouseButton);
        }

        /// <summary>
        ///     Tests that auto panning speed should set and get correctly
        /// </summary>
        [Fact]
        public void AutoPanningSpeed_Should_SetAndGetCorrectly()
        {
            ImNodesIo io = new ImNodesIo();
            float value = 1.0f;
            io.AutoPanningSpeed = value;
            Assert.Equal(value, io.AutoPanningSpeed);
        }
    }
}