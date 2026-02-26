// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MouseButtonEventArgsTests.cs
// 
//  Author:GitHub Copilot
// 
//  Copyright (c) 2021 GNU General Public License v3.0
// 
//  This program is free software:you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
// 
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//  GNU General Public License for more details.
// 
//  You should have received a copy of the GNU General Public License
//  along with this program.If not, see <http://www.gnu.org/licenses/>.
// 
//  --------------------------------------------------------------------------

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
        /// Tests that constructor with valid parameters sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            // Arrange
            MouseButton button = MouseButton.Left;
            InputState state = InputState.Press;
            ModifierKeys modifiers = ModifierKeys.Shift;

            // Act
            MouseButtonEventArgs args = new MouseButtonEventArgs(button, state, modifiers);

            // Assert
            Assert.Equal(button, args.Button);
            Assert.Equal(state, args.Action);
            Assert.Equal(modifiers, args.Modifiers);
        }

        /// <summary>
        /// Tests that button property returns correct value
        /// </summary>
        [Fact]
        public void Button_Property_ReturnsCorrectValue()
        {
            // Arrange
            MouseButton expectedButton = MouseButton.Right;
            MouseButtonEventArgs args = new MouseButtonEventArgs(expectedButton, InputState.Press, ModifierKeys.None);

            // Act
            MouseButton result = args.Button;

            // Assert
            Assert.Equal(expectedButton, result);
        }

        /// <summary>
        /// Tests that action property returns correct value
        /// </summary>
        [Fact]
        public void Action_Property_ReturnsCorrectValue()
        {
            // Arrange
            InputState expectedState = InputState.Release;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, expectedState, ModifierKeys.None);

            // Act
            InputState result = args.Action;

            // Assert
            Assert.Equal(expectedState, result);
        }

        /// <summary>
        /// Tests that modifiers property returns correct value
        /// </summary>
        [Fact]
        public void Modifiers_Property_ReturnsCorrectValue()
        {
            // Arrange
            ModifierKeys expectedModifiers = ModifierKeys.Control | ModifierKeys.Alt;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, expectedModifiers);

            // Act
            ModifierKeys result = args.Modifiers;

            // Assert
            Assert.Equal(expectedModifiers, result);
        }

        /// <summary>
        /// Tests that constructor with middle button sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithMiddleButton_SetsButtonCorrectly()
        {
            // Arrange
            MouseButton middleButton = MouseButton.Middle;
            MouseButtonEventArgs args = new MouseButtonEventArgs(middleButton, InputState.Press, ModifierKeys.None);

            // Act
            MouseButton result = args.Button;

            // Assert
            Assert.Equal(middleButton, result);
        }

        /// <summary>
        /// Tests that constructor with button 4 sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithButton4_SetsButtonCorrectly()
        {
            // Arrange
            MouseButton button4 = MouseButton.Button4;
            MouseButtonEventArgs args = new MouseButtonEventArgs(button4, InputState.Press, ModifierKeys.None);

            // Act
            MouseButton result = args.Button;

            // Assert
            Assert.Equal(button4, result);
        }

        /// <summary>
        /// Tests that constructor with button 5 sets button correctly
        /// </summary>
        [Fact]
        public void Constructor_WithButton5_SetsButtonCorrectly()
        {
            // Arrange
            MouseButton button5 = MouseButton.Button5;
            MouseButtonEventArgs args = new MouseButtonEventArgs(button5, InputState.Press, ModifierKeys.None);

            // Act
            MouseButton result = args.Button;

            // Assert
            Assert.Equal(button5, result);
        }

        /// <summary>
        /// Tests that constructor with no modifiers sets modifiers to none
        /// </summary>
        [Fact]
        public void Constructor_WithNoModifiers_SetsModifiersToNone()
        {
            // Arrange
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, ModifierKeys.None);

            // Act
            ModifierKeys result = args.Modifiers;

            // Assert
            Assert.Equal(ModifierKeys.None, result);
        }

        /// <summary>
        /// Tests that constructor with multiple modifiers stores all modifiers
        /// </summary>
        [Fact]
        public void Constructor_WithMultipleModifiers_StoresAllModifiers()
        {
            // Arrange
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt;
            MouseButtonEventArgs args = new MouseButtonEventArgs(MouseButton.Left, InputState.Press, modifiers);

            // Act
            ModifierKeys result = args.Modifiers;

            // Assert
            Assert.Equal(modifiers, result);
        }
    }
}

