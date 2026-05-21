

using Alis.Extension.Graphic.Glfw.Enums;
using Xunit;

namespace Alis.Extension.Graphic.Glfw.Test
{
    /// <summary>
    ///     Tests for MouseButtonEventArgs class
    /// </summary>
    public class MouseButtonEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor with valid parameters sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            MouseButton button = MouseButton.Left;
            InputState state = InputState.Press;
            ModifierKeys modifiers = ModifierKeys.Shift;

            MouseButtonEventArgs args = new MouseButtonEventArgs(button, state, modifiers);

            Assert.Equal(button, args.Button);
            Assert.Equal(state, args.Action);
            Assert.Equal(modifiers, args.Modifiers);
        }

        /// <summary>
        ///     Tests that button property returns correct value
        /// </summary>
        [Fact]
        public void Button_Property_ReturnsCorrectValue()
        {
            MouseButton expectedButton = MouseButton.Right;
            MouseButtonEventArgs args = new MouseButtonEventArgs(expectedButton, InputState.Press, ModifierKeys.None);

            MouseButton result = args.Button;

            Assert.Equal(expectedButton, result);
        }

        /// <summary>
        ///     Tests that action property returns correct value
        /// </summary>
        [Fact]
        public void Action_Property_ReturnsCorrectValue()
        {
            InputState expectedState = InputState.Release;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, expectedState, ModifierKeys.None);

            InputState result = args.Action;

            Assert.Equal(expectedState, result);
        }

        /// <summary>
        ///     Tests that modifiers property returns correct value
        /// </summary>
        [Fact]
        public void Modifiers_Property_ReturnsCorrectValue()
        {
            ModifierKeys expectedModifiers = ModifierKeys.Control | ModifierKeys.Alt;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, expectedModifiers);

            ModifierKeys result = args.Modifiers;

            Assert.Equal(expectedModifiers, result);
        }

        /// <summary>
        ///     Tests that constructor with middle button sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithMiddleButton_SetsButtonCorrectly()
        {
            MouseButton middleButton = MouseButton.Middle;
            MouseButtonEventArgs args = new MouseButtonEventArgs(middleButton, InputState.Press, ModifierKeys.None);

            MouseButton result = args.Button;

            Assert.Equal(middleButton, result);
        }

        /// <summary>
        ///     Tests that constructor with button 4 sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithButton4_SetsButtonCorrectly()
        {
            MouseButton button4 = MouseButton.Button4;
            MouseButtonEventArgs args = new MouseButtonEventArgs(button4, InputState.Press, ModifierKeys.None);

            MouseButton result = args.Button;

            Assert.Equal(button4, result);
        }

        /// <summary>
        ///     Tests that constructor with button 5 sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithButton5_SetsButtonCorrectly()
        {
            MouseButton button5 = MouseButton.Button5;
            MouseButtonEventArgs args = new MouseButtonEventArgs(button5, InputState.Press, ModifierKeys.None);

            MouseButton result = args.Button;

            Assert.Equal(button5, result);
        }

        /// <summary>
        ///     Tests that constructor with no modifiers sets modifiers to none
        /// </summary>
        [Fact]
        public void Constructor_WithNoModifiers_SetsModifiersToNone()
        {
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, ModifierKeys.None);

            ModifierKeys result = args.Modifiers;

            Assert.Equal(ModifierKeys.None, result);
        }

        /// <summary>
        ///     Tests that constructor with multiple modifiers stores all modifiers
        /// </summary>
        [Fact]
        public void Constructor_WithMultipleModifiers_StoresAllModifiers()
        {
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, modifiers);

            ModifierKeys result = args.Modifiers;

            Assert.Equal(modifiers, result);
        }
    }
}