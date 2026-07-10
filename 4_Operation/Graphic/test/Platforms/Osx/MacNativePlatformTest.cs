// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformTest.cs
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
using System.Collections.Generic;
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Tests for MacNativePlatform default behavior without native initialization.
    /// </summary>
    public class MacNativePlatformTest
    {
        [Fact]
        public void MacNativePlatform_DefaultState_IsSafe()
        {
            MacNativePlatform platform = new MacNativePlatform();

            Assert.False(platform.IsWindowVisible());
            Assert.Equal(0, platform.GetWindowWidth());
            Assert.Equal(0, platform.GetWindowHeight());
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
            Assert.False(platform.TryGetLastInputCharacters(out string chars));
            Assert.Equal(string.Empty, chars);
        }

        [Fact]
        public void TryGetLastKeyPressed_NoKey_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.False(result);
            Assert.Equal(default(ConsoleKey), key);
        }

        [Fact]
        public void TryGetLastKeyPressed_KeySet_ReturnsTrueAndClears()
        {
            MacNativePlatform platform = new MacNativePlatform();
            FieldInfo lastKeyPressedField = typeof(MacNativePlatform).GetField("lastKeyPressed", BindingFlags.NonPublic | BindingFlags.Instance);
            lastKeyPressedField.SetValue(platform, ConsoleKey.Enter);

            bool result = platform.TryGetLastKeyPressed(out ConsoleKey key);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Enter, key);

            bool secondResult = platform.TryGetLastKeyPressed(out ConsoleKey _);
            Assert.False(secondResult);
        }

        [Fact]
        public void GetMouseWheel_Default_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }

        [Fact]
        public void GetMouseWheel_InternalFieldSet_ReturnsValueAndResets()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = 42.5f;

            float result = platform.GetMouseWheel();
            Assert.Equal(42.5f, result, 5);
            Assert.Equal(0.0f, platform.mouseWheel, 5);
        }

        [Fact]
        public void GetMouseWheel_NegativeValue_ReturnsValueAndResets()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = -15.0f;

            float result = platform.GetMouseWheel();
            Assert.Equal(-15.0f, result, 5);
            Assert.Equal(0.0f, platform.mouseWheel, 5);
        }

        [Fact]
        public void IsKeyDown_KeyNotPressed_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
            Assert.False(platform.IsKeyDown(ConsoleKey.Spacebar));
            Assert.False(platform.IsKeyDown(ConsoleKey.Enter));
        }

        [Fact]
        public void IsKeyDown_KeyAddedViaReflection_ReturnsTrue()
        {
            MacNativePlatform platform = new MacNativePlatform();
            FieldInfo pressedKeysField = typeof(MacNativePlatform).GetField("pressedKeys", BindingFlags.NonPublic | BindingFlags.Instance);
            HashSet<ConsoleKey> pressedKeys = (HashSet<ConsoleKey>)pressedKeysField.GetValue(platform);

            pressedKeys.Add(ConsoleKey.Spacebar);
            Assert.True(platform.IsKeyDown(ConsoleKey.Spacebar));
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void IsKeyDown_MultipleKeys_ReturnsCorrectly()
        {
            MacNativePlatform platform = new MacNativePlatform();
            FieldInfo pressedKeysField = typeof(MacNativePlatform).GetField("pressedKeys", BindingFlags.NonPublic | BindingFlags.Instance);
            HashSet<ConsoleKey> pressedKeys = (HashSet<ConsoleKey>)pressedKeysField.GetValue(platform);

            pressedKeys.Add(ConsoleKey.W);
            pressedKeys.Add(ConsoleKey.A);
            pressedKeys.Add(ConsoleKey.S);
            pressedKeys.Add(ConsoleKey.D);

            Assert.True(platform.IsKeyDown(ConsoleKey.W));
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.IsKeyDown(ConsoleKey.S));
            Assert.True(platform.IsKeyDown(ConsoleKey.D));
            Assert.False(platform.IsKeyDown(ConsoleKey.LeftWindows));
        }

        [Fact]
        public void TryGetLastInputCharacters_ReturnsFalseAndEmptyString()
        {
            MacNativePlatform platform = new MacNativePlatform();
            bool result = platform.TryGetLastInputCharacters(out string chars);

            Assert.False(result);
            Assert.Equal(string.Empty, chars);
        }

        [Fact]
        public void IsWindowVisible_NotInitialized_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.False(platform.IsWindowVisible());
        }

        [Fact]
        public void GetWindowWidth_NotInitialized_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0, platform.GetWindowWidth());
        }

        [Fact]
        public void GetWindowHeight_NotInitialized_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(0, platform.GetWindowHeight());
        }

        [Fact]
        public void TryMapSpecialKey_LeftArrow_ReturnsLeftArrow()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 123, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.LeftArrow, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_RightArrow_ReturnsRightArrow()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 124, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.RightArrow, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_DownArrow_ReturnsDownArrow()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 125, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.DownArrow, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_UpArrow_ReturnsUpArrow()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 126, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.UpArrow, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Home_ReturnsHome()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 115, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Home, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_End_ReturnsEnd()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 119, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.End, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_PageUp_ReturnsPageUp()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 116, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.PageUp, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_PageDown_ReturnsPageDown()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 121, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.PageDown, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Backspace_ReturnsBackspace()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 51, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Backspace, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Delete_ReturnsDelete()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 117, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Delete, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Enter_ReturnsEnter()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 36, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Enter, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Tab_ReturnsTab()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 48, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Tab, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_Escape_ReturnsEscape()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 53, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.Escape, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F1_ReturnsF1()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 122, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F1, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F2_ReturnsF2()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 120, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F2, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F3_ReturnsF3()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 99, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F3, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F4_ReturnsF4()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 118, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F4, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F5_ReturnsF5()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 96, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F5, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F6_ReturnsF6()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 97, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F6, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F7_ReturnsF7()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 98, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F7, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F8_ReturnsF8()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 100, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F8, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F9_ReturnsF9()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 101, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F9, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F10_ReturnsF10()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 109, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F10, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F11_ReturnsF11()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 103, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F11, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_F12_ReturnsF12()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 111, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.F12, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_LeftWindows_ReturnsLeftWindows()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 55, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.True(result);
            Assert.Equal(ConsoleKey.LeftWindows, (ConsoleKey)parameters[1]);
        }

        [Fact]
        public void TryMapSpecialKey_UnknownKeyCode_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { -1, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.False(result);
        }

        [Fact]
        public void TryMapSpecialKey_ZeroKeyCode_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("TryMapSpecialKey", BindingFlags.NonPublic | BindingFlags.Static);
            object[] parameters = new object[] { 0, null };
            bool result = (bool)method.Invoke(null, parameters);
            Assert.False(result);
        }

        [Fact]
        public void MapSymbolKey_Space_ReturnsSpacebar()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { ' ' });
            Assert.Equal(ConsoleKey.Spacebar, result);
        }

        [Fact]
        public void MapSymbolKey_NewLine_ReturnsEnter()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '\n' });
            Assert.Equal(ConsoleKey.Enter, result);
        }

        [Fact]
        public void MapSymbolKey_CarriageReturn_ReturnsEnter()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '\r' });
            Assert.Equal(ConsoleKey.Enter, result);
        }

        [Fact]
        public void MapSymbolKey_Tab_ReturnsTab()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '\t' });
            Assert.Equal(ConsoleKey.Tab, result);
        }

        [Fact]
        public void MapSymbolKey_Escape_ReturnsEscape()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { (char)27 });
            Assert.Equal(ConsoleKey.Escape, result);
        }

        [Fact]
        public void MapSymbolKey_Backspace_ReturnsBackspace()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { (char)8 });
            Assert.Equal(ConsoleKey.Backspace, result);
        }

        [Fact]
        public void MapSymbolKey_Delete_ReturnsDelete()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { (char)127 });
            Assert.Equal(ConsoleKey.Delete, result);
        }

        [Fact]
        public void MapSymbolKey_Minus_ReturnsOemMinus()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '-' });
            Assert.Equal(ConsoleKey.OemMinus, result);
        }

        [Fact]
        public void MapSymbolKey_Plus_ReturnsOemPlus()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '+' });
            Assert.Equal(ConsoleKey.OemPlus, result);
        }

        [Fact]
        public void MapSymbolKey_Comma_ReturnsOemComma()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { ',' });
            Assert.Equal(ConsoleKey.OemComma, result);
        }

        [Fact]
        public void MapSymbolKey_Period_ReturnsOemPeriod()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '.' });
            Assert.Equal(ConsoleKey.OemPeriod, result);
        }

        [Fact]
        public void MapSymbolKey_Slash_ReturnsOem2()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '/' });
            Assert.Equal(ConsoleKey.Oem2, result);
        }

        [Fact]
        public void MapSymbolKey_Semicolon_ReturnsOem1()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { ';' });
            Assert.Equal(ConsoleKey.Oem1, result);
        }

        [Fact]
        public void MapSymbolKey_Backslash_ReturnsOem5()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '\\' });
            Assert.Equal(ConsoleKey.Oem5, result);
        }

        [Fact]
        public void MapSymbolKey_OpenBracket_ReturnsOem4()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '[' });
            Assert.Equal(ConsoleKey.Oem4, result);
        }

        [Fact]
        public void MapSymbolKey_CloseBracket_ReturnsOem6()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { ']' });
            Assert.Equal(ConsoleKey.Oem6, result);
        }

        [Fact]
        public void MapSymbolKey_Backtick_ReturnsOem3()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '`' });
            Assert.Equal(ConsoleKey.Oem3, result);
        }

        [Fact]
        public void MapSymbolKey_UnknownChar_ReturnsNull()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '~' });
            Assert.Null(result);
        }

        [Fact]
        public void MapSymbolKey_Letter_ReturnsNull()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { 'x' });
            Assert.Null(result);
        }

        [Fact]
        public void MapSymbolKey_Digit_ReturnsNull()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapSymbolKey", BindingFlags.NonPublic | BindingFlags.Static);
            ConsoleKey? result = (ConsoleKey?)method.Invoke(null, new object[] { '5' });
            Assert.Null(result);
        }

        [Fact]
        public void MapCharacterKey_Digit_WhenKeyDown_SetsLastKeyPressedAndAddsToPressedKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { '5', true });

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.D5, key);
            Assert.True(platform.IsKeyDown(ConsoleKey.D5));
        }

        [Fact]
        public void MapCharacterKey_UppercaseLetter_WhenKeyDown_SetsLastKeyPressedAndAddsToPressedKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { 'M', true });

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.M, key);
            Assert.True(platform.IsKeyDown(ConsoleKey.M));
        }

        [Fact]
        public void MapCharacterKey_LowercaseLetter_WhenKeyDown_SetsLastKeyPressedAndAddsToPressedKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { 'z', true });

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.Z, key);
            Assert.True(platform.IsKeyDown(ConsoleKey.Z));
        }

        [Fact]
        public void MapCharacterKey_Symbol_WhenKeyDown_SetsLastKeyPressedAndAddsToPressedKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { ',', true });

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.OemComma, key);
            Assert.True(platform.IsKeyDown(ConsoleKey.OemComma));
        }

        [Fact]
        public void MapCharacterKey_WhenKeyUp_RemovesFromPressedKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { 'A', true });
            Assert.True(platform.IsKeyDown(ConsoleKey.A));

            method.Invoke(platform, new object[] { 'A', false });
            Assert.False(platform.IsKeyDown(ConsoleKey.A));
        }

        [Fact]
        public void MapCharacterKey_KeyUp_DoesNotSetLastKeyPressed()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { 'A', false });

            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
        }

        [Fact]
        public void MapCharacterKey_UnknownChar_DoesNothing()
        {
            MacNativePlatform platform = new MacNativePlatform();
            MethodInfo method = typeof(MacNativePlatform).GetMethod("MapCharacterKey", BindingFlags.NonPublic | BindingFlags.Instance);

            method.Invoke(platform, new object[] { '~', true });

            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.False(platform.IsKeyDown(ConsoleKey.Oem3));
        }

        [Fact]
        public void TryGetLastKeyPressed_AfterConsume_ReturnsFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            FieldInfo field = typeof(MacNativePlatform).GetField("lastKeyPressed", BindingFlags.NonPublic | BindingFlags.Instance);
            field.SetValue(platform, ConsoleKey.Escape);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key1));
            Assert.Equal(ConsoleKey.Escape, key1);

            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey key2));
            Assert.Equal(default(ConsoleKey), key2);
        }

        [Fact]
        public void GetMouseWheel_ConsecutiveCalls_SecondReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseWheel = 7.0f;

            Assert.Equal(7.0f, platform.GetMouseWheel(), 5);
            Assert.Equal(0.0f, platform.GetMouseWheel(), 5);
        }
    }
}
#endif
