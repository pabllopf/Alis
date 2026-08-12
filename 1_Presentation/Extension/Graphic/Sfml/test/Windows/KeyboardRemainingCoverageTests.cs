// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:KeyboardRemainingCoverageTests.cs
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

using System;
using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Sfml.Windows;
using Xunit;

namespace Alis.Extension.Graphic.Sfml.Test.Windows
{
    /// <summary>
    ///     The keyboard remaining coverage tests class
    /// </summary>
    public class KeyboardRemainingCoverageTests
    {
        /// <summary>
        ///     Tests that key enum letter values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_Letters_AreSequential()
        {
            Assert.Equal(-1, (int) Keyboard.Key.Unknown);
            Assert.Equal(0, (int) Keyboard.Key.A);
            Assert.Equal(25, (int) Keyboard.Key.Z);
        }

        /// <summary>
        ///     Tests that key enum number values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_Numbers_AreSequential()
        {
            Assert.Equal(26, (int) Keyboard.Key.Num0);
            Assert.Equal(35, (int) Keyboard.Key.Num9);
        }

        /// <summary>
        ///     Tests that key enum control values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_ControlValues_AreSequential()
        {
            Assert.Equal(36, (int) Keyboard.Key.Escape);
            Assert.Equal(37, (int) Keyboard.Key.LControl);
            Assert.Equal(38, (int) Keyboard.Key.LShift);
            Assert.Equal(39, (int) Keyboard.Key.LAlt);
            Assert.Equal(40, (int) Keyboard.Key.LSystem);
            Assert.Equal(41, (int) Keyboard.Key.RControl);
            Assert.Equal(42, (int) Keyboard.Key.RShift);
            Assert.Equal(43, (int) Keyboard.Key.RAlt);
            Assert.Equal(44, (int) Keyboard.Key.RSystem);
            Assert.Equal(45, (int) Keyboard.Key.Menu);
        }

        /// <summary>
        ///     Tests that key enum punctuation values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_Punctuation_AreSequential()
        {
            Assert.Equal(46, (int) Keyboard.Key.LBracket);
            Assert.Equal(47, (int) Keyboard.Key.RBracket);
            Assert.Equal(48, (int) Keyboard.Key.Semicolon);
            Assert.Equal(49, (int) Keyboard.Key.Comma);
            Assert.Equal(50, (int) Keyboard.Key.Period);
            Assert.Equal(51, (int) Keyboard.Key.Quote);
            Assert.Equal(52, (int) Keyboard.Key.Slash);
            Assert.Equal(53, (int) Keyboard.Key.Backslash);
            Assert.Equal(54, (int) Keyboard.Key.Tilde);
            Assert.Equal(55, (int) Keyboard.Key.Equal);
            Assert.Equal(56, (int) Keyboard.Key.Hyphen);
        }

        /// <summary>
        ///     Tests that key enum navigation values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_Navigation_AreSequential()
        {
            Assert.Equal(57, (int) Keyboard.Key.Space);
            Assert.Equal(58, (int) Keyboard.Key.Enter);
            Assert.Equal(59, (int) Keyboard.Key.Backspace);
            Assert.Equal(60, (int) Keyboard.Key.Tab);
            Assert.Equal(61, (int) Keyboard.Key.PageUp);
            Assert.Equal(62, (int) Keyboard.Key.PageDown);
            Assert.Equal(63, (int) Keyboard.Key.End);
            Assert.Equal(64, (int) Keyboard.Key.Home);
            Assert.Equal(65, (int) Keyboard.Key.Insert);
            Assert.Equal(66, (int) Keyboard.Key.Delete);
            Assert.Equal(67, (int) Keyboard.Key.Add);
            Assert.Equal(68, (int) Keyboard.Key.Subtract);
            Assert.Equal(69, (int) Keyboard.Key.Multiply);
            Assert.Equal(70, (int) Keyboard.Key.Divide);
            Assert.Equal(71, (int) Keyboard.Key.Left);
            Assert.Equal(72, (int) Keyboard.Key.Right);
            Assert.Equal(73, (int) Keyboard.Key.Up);
            Assert.Equal(74, (int) Keyboard.Key.Down);
        }

        /// <summary>
        ///     Tests that key enum numpad and function values are sequential
        /// </summary>
        [Fact]
        public void Key_Enum_NumpadAndFunction_AreSequential()
        {
            Assert.Equal(75, (int) Keyboard.Key.Numpad0);
            Assert.Equal(84, (int) Keyboard.Key.Numpad9);
            Assert.Equal(85, (int) Keyboard.Key.F1);
            Assert.Equal(96, (int) Keyboard.Key.F12);
        }

        /// <summary>
        ///     Tests that is key pressed throws when native library is unavailable
        /// </summary>
        [Fact]
        public void IsKeyPressed_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => Keyboard.IsKeyPressed(Keyboard.Key.A));
            }
        }

        /// <summary>
        ///     Tests that set virtual keyboard visible throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SetVirtualKeyboardVisible_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadWindowLibrary())
            {
                Assert.Throws<DllNotFoundException>(() => Keyboard.SetVirtualKeyboardVisible(true));
            }
        }

        /// <summary>
        ///     Determines whether the csfml window native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadWindowLibrary()
        {
            if (NativeLibrary.TryLoad("csfml-window", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(Alis.Extension.Graphic.Sfml.Test.Attributes.RequireCSfmlSystemFactAttribute).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "csfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window"),
                System.IO.Path.Combine(assemblyDir, "libcsfml-window.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
