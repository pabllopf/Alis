// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardTests.cs
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

using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    public class KeyboardTests
    {
        [Fact]
        public void IsKeyPressed_WithAKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.A);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsKeyPressed_WithSpaceKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.Space);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsKeyPressed_WithEnterKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.Enter);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsKeyPressed_WithEscapeKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.Escape);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsKeyPressed_WithUnknownKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.Unknown);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void IsKeyPressed_WithShiftKey_ReturnsBool()
        {
            bool result = Keyboard.IsKeyPressed(Keyboard.Key.LShift);

            Assert.IsType<bool>(result);
        }

        [Fact]
        public void SetVirtualKeyboardVisible_WithTrue_DoesNotThrow()
        {
            Keyboard.SetVirtualKeyboardVisible(true);
        }

        [Fact]
        public void SetVirtualKeyboardVisible_WithFalse_DoesNotThrow()
        {
            Keyboard.SetVirtualKeyboardVisible(false);
        }

        [Fact]
        public void IsKeyPressed_Method_Exists()
        {
            Assert.NotNull(typeof(Keyboard).GetMethod("IsKeyPressed"));
        }

        [Fact]
        public void SetVirtualKeyboardVisible_Method_Exists()
        {
            Assert.NotNull(typeof(Keyboard).GetMethod("SetVirtualKeyboardVisible"));
        }
    }
}
