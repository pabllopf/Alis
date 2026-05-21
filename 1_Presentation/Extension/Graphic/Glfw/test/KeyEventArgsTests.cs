// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyEventArgsTests.cs
// 
//  Author:Pablo Perdomo Falcón
//  Web:https://www.pabllopf.dev/
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
    ///     Tests for KeyEventArgs class
    /// </summary>
    public class KeyEventArgsTests
    {
        /// <summary>
        ///     Tests that constructor with valid parameters sets properties
        /// </summary>
        [Fact]
        public void Constructor_WithValidParameters_SetsProperties()
        {
            Keys key = Keys.A;
            int scanCode = 30;
            InputState state = InputState.Press;
            ModifierKeys modifiers = ModifierKeys.Shift;

            KeyEventArgs args = new KeyEventArgs(key, scanCode, state, modifiers);

            Assert.Equal(key, args.Key);
            Assert.Equal(scanCode, args.ScanCode);
            Assert.Equal(state, args.State);
            Assert.Equal(modifiers, args.Modifiers);
        }

        /// <summary>
        ///     Tests that key property returns correct value
        /// </summary>
        [Fact]
        public void Key_Property_ReturnsCorrectValue()
        {
            Keys expectedKey = Keys.Escape;
            KeyEventArgs args = new KeyEventArgs(expectedKey, 1, InputState.Press, ModifierKeys.None);

            Keys result = args.Key;

            Assert.Equal(expectedKey, result);
        }

        /// <summary>
        ///     Tests that scan code property returns correct value
        /// </summary>
        [Fact]
        public void ScanCode_Property_ReturnsCorrectValue()
        {
            int expectedScanCode = 42;
            KeyEventArgs args = new KeyEventArgs(Keys.A, expectedScanCode, InputState.Press, ModifierKeys.None);

            int result = args.ScanCode;

            Assert.Equal(expectedScanCode, result);
        }

        /// <summary>
        ///     Tests that state property returns correct value
        /// </summary>
        [Fact]
        public void State_Property_ReturnsCorrectValue()
        {
            InputState expectedState = InputState.Release;
            KeyEventArgs args = new KeyEventArgs(Keys.A, 30, expectedState, ModifierKeys.None);

            InputState result = args.State;

            Assert.Equal(expectedState, result);
        }

        /// <summary>
        ///     Tests that modifiers property returns correct value
        /// </summary>
        [Fact]
        public void Modifiers_Property_ReturnsCorrectValue()
        {
            ModifierKeys expectedModifiers = ModifierKeys.Control | ModifierKeys.Alt;
            KeyEventArgs args = new KeyEventArgs(Keys.A, 30, InputState.Press, expectedModifiers);

            ModifierKeys result = args.Modifiers;

            Assert.Equal(expectedModifiers, result);
        }

        /// <summary>
        ///     Tests that constructor with repeat state sets state correctly
        /// </summary>
        [Fact]
        public void Constructor_WithRepeatState_SetsStateCorrectly()
        {
            InputState repeatState = InputState.Repeat;
            KeyEventArgs args = new KeyEventArgs(Keys.Space, 57, repeatState, ModifierKeys.None);

            InputState result = args.State;

            Assert.Equal(repeatState, result);
        }

        /// <summary>
        ///     Tests that constructor with unknown key sets key correctly
        /// </summary>
        [Fact]
        public void Constructor_WithUnknownKey_SetsKeyCorrectly()
        {
            Keys unknownKey = Keys.Unknown;
            KeyEventArgs args = new KeyEventArgs(unknownKey, 0, InputState.Press, ModifierKeys.None);

            Keys result = args.Key;

            Assert.Equal(unknownKey, result);
        }

        /// <summary>
        ///     Tests that constructor with multiple modifiers stores all modifiers
        /// </summary>
        [Fact]
        public void Constructor_WithMultipleModifiers_StoresAllModifiers()
        {
            ModifierKeys modifiers = ModifierKeys.Shift | ModifierKeys.Control | ModifierKeys.Alt | ModifierKeys.Super;
            KeyEventArgs args = new KeyEventArgs(Keys.A, 30, InputState.Press, modifiers);

            ModifierKeys result = args.Modifiers;

            Assert.Equal(modifiers, result);
        }
    }
}