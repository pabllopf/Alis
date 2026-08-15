// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardExecutionTests.cs
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

using Alis.Extension.Graphic.Sfml.Test.Attributes;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     Executes the <see cref="Keyboard" /> native query members against the real CSFML window
    ///     library. Both calls are read-only state queries on desktop (the virtual keyboard call is a
    ///     no-op outside mobile platforms).
    /// </summary>
    public class KeyboardExecutionTests
    {
        /// <summary>
        ///     Tests that the key pressed query executes without throwing.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void IsKeyPressed_ExecutesWithoutThrowing()
        {
            bool pressed = Keyboard.IsKeyPressed(Keyboard.Key.Space);
            Assert.IsType<bool>(pressed);
        }

        /// <summary>
        ///     Tests that toggling the virtual keyboard visibility executes without throwing.
        /// </summary>
        [RequireCSfmlWindowsFact]
        public void SetVirtualKeyboardVisible_ExecutesWithoutThrowing()
        {
            Keyboard.SetVirtualKeyboardVisible(true);
            Keyboard.SetVirtualKeyboardVisible(false);
        }
    }
}
