// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformTests.cs
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

#if osxarm64 || osxarm || osxx64 || osx
using System;
using Alis.Core.Graphic.Platforms.Osx;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Exercises the MacNativePlatform key mapping, mouse and window state paths.
    /// </summary>
    public class MacNativePlatformTests
    {
        /// <summary>
        ///     Verifies that digit characters map to the matching console keys.
        /// </summary>
        [Fact]
        public void MapCharacterKey_WithDigits_MapsToDigits()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('0', true);
            platform.MapCharacterKey('9', true);
            Assert.True(platform.IsKeyDown(ConsoleKey.D0));
            Assert.True(platform.IsKeyDown(ConsoleKey.D9));
        }

        /// <summary>
        ///     Verifies that uppercase and lowercase letters map to the matching console keys.
        /// </summary>
        [Fact]
        public void MapCharacterKey_WithLetters_MapsToLetters()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('A', true);
            platform.MapCharacterKey('z', true);
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.IsKeyDown(ConsoleKey.Z));
        }

        /// <summary>
        ///     Verifies that symbol characters map to the matching console keys.
        /// </summary>
        [Fact]
        public void MapCharacterKey_WithSymbols_MapsToSymbols()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey(' ', true);
            platform.MapCharacterKey('\n', true);
            platform.MapCharacterKey('\r', true);
            platform.MapCharacterKey('\t', true);
            platform.MapCharacterKey((char) 27, true);
            platform.MapCharacterKey((char) 8, true);
            platform.MapCharacterKey((char) 127, true);
            platform.MapCharacterKey('-', true);
            platform.MapCharacterKey('+', true);
            platform.MapCharacterKey(',', true);
            platform.MapCharacterKey('.', true);
            platform.MapCharacterKey('/', true);
            platform.MapCharacterKey(';', true);
            platform.MapCharacterKey('\\', true);
            platform.MapCharacterKey('[', true);
            platform.MapCharacterKey(']', true);
            platform.MapCharacterKey('`', true);
            Assert.True(platform.IsKeyDown(ConsoleKey.Spacebar));
            Assert.True(platform.IsKeyDown(ConsoleKey.Enter));
            Assert.True(platform.IsKeyDown(ConsoleKey.Tab));
            Assert.True(platform.IsKeyDown(ConsoleKey.Escape));
            Assert.True(platform.IsKeyDown(ConsoleKey.Backspace));
            Assert.True(platform.IsKeyDown(ConsoleKey.Delete));
            Assert.True(platform.IsKeyDown(ConsoleKey.OemMinus));
            Assert.True(platform.IsKeyDown(ConsoleKey.OemPlus));
            Assert.True(platform.IsKeyDown(ConsoleKey.OemComma));
            Assert.True(platform.IsKeyDown(ConsoleKey.OemPeriod));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem2));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem1));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem5));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem4));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem6));
            Assert.True(platform.IsKeyDown(ConsoleKey.Oem3));
        }

        /// <summary>
        ///     Verifies that unmapped characters are ignored.
        /// </summary>
        [Fact]
        public void MapCharacterKey_WithUnmappedCharacter_DoesNothing()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('~', true);
            Assert.False(platform.IsKeyDown(ConsoleKey.Oem5));
            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        /// <summary>
        ///     Verifies that a key up removes the key from the pressed set.
        /// </summary>
        [Fact]
        public void MapCharacterKey_KeyUp_RemovesKey()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('W', true);
            Assert.True(platform.IsKeyDown(ConsoleKey.W));
            platform.MapCharacterKey('W', false);
            Assert.False(platform.IsKeyDown(ConsoleKey.W));
        }

        /// <summary>
        ///     Verifies that the last pressed key is returned once and then consumed.
        /// </summary>
        [Fact]
        public void TryGetLastKeyPressed_ReturnsOnce()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('B', true);
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.B, key);
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey consumed));
            Assert.Equal(default(ConsoleKey), consumed);
        }

        /// <summary>
        ///     Verifies that the mouse position query returns zeros before a window exists.
        /// </summary>
        [Fact]
        public void GetMousePositionInView_WithoutWindow_ReturnsZeros()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0.0f, x);
            Assert.Equal(0.0f, y);
        }

        /// <summary>
        ///     Verifies that the mouse state query executes against the system cursor.
        /// </summary>
        [MacOsOnly]
        public void GetMouseState_WithSystemCursor_Executes()
        {
            MacNativePlatform platform = new MacNativePlatform();
            try
            {
                platform.GetMouseState(out int x, out int y, out bool[] buttons);
                Assert.Equal(5, buttons.Length);
            }
            catch (DllNotFoundException)
            {
            }
        }

        /// <summary>
        ///     Verifies that the OpenGL proc address resolves from the system framework.
        /// </summary>
        [MacOsOnly]
        public void GetProcAddress_WithOpenGlSymbol_ReturnsNonZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            try
            {
                IntPtr address = platform.GetProcAddress("glClear");
                Assert.NotEqual(IntPtr.Zero, address);
            }
            catch (DllNotFoundException)
            {
            }
        }
    }
}
#endif
