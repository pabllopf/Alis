// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:MacNativePlatformFinalCoverageTests.cs
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
using System.Reflection;
using Alis.Core.Graphic.Platforms.Osx;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    public class MacNativePlatformFinalCoverageTests
    {
        [Fact]
        public void IsMouseEvent_Type1_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 1 }));
        }

        [Fact]
        public void IsMouseEvent_Type2_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 2 }));
        }

        [Fact]
        public void IsMouseEvent_Type3_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 3 }));
        }

        [Fact]
        public void IsMouseEvent_Type4_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 4 }));
        }

        [Fact]
        public void IsMouseEvent_Type5_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 5 }));
        }

        [Fact]
        public void IsMouseEvent_Type22_ReturnsTrue()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.True((bool)method.Invoke(null, new object[] { 22 }));
        }

        [Fact]
        public void IsMouseEvent_Type10_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.False((bool)method.Invoke(null, new object[] { 10 }));
        }

        [Fact]
        public void IsMouseEvent_Type11_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.False((bool)method.Invoke(null, new object[] { 11 }));
        }

        [Fact]
        public void IsMouseEvent_Type0_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.False((bool)method.Invoke(null, new object[] { 0 }));
        }

        [Fact]
        public void IsMouseEvent_NegativeType_ReturnsFalse()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("IsMouseEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.False((bool)method.Invoke(null, new object[] { -1 }));
        }

        [Fact]
        public void ExtractCharacterFromEvent_NullEvent_ReturnsNullChar()
        {
            MethodInfo method = typeof(MacNativePlatform).GetMethod("ExtractCharacterFromEvent", BindingFlags.NonPublic | BindingFlags.Static);
            Assert.Equal('\0', (char)method.Invoke(null, new object[] { IntPtr.Zero }));
        }

        [Fact]
        public void HandleKeyDownEvent_NullEvent_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.HandleKeyDownEvent(IntPtr.Zero);
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.Equal(0, platform.pressedKeys.Count);
        }

        [Fact]
        public void HandleKeyUpEvent_NullEvent_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.HandleKeyUpEvent(IntPtr.Zero);
            Assert.False(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.Equal(0, platform.pressedKeys.Count);
        }

        [Fact]
        public void HandleKeyUpEvent_NullEvent_DoesNotRemoveExistingKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.pressedKeys.Add(ConsoleKey.Enter);
            platform.HandleKeyUpEvent(IntPtr.Zero);
            Assert.Single(platform.pressedKeys);
        }

        [Fact]
        public void GetMousePositionInView_NullWindow_ReturnsZero()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetMousePositionInView(out float x, out float y);
            Assert.Equal(0f, x, 5);
            Assert.Equal(0f, y, 5);
        }

        [Fact]
        public void GetProcAddress_ValidFunction_ReturnsNonZero()
        {
            FieldInfo handleField = typeof(MacNativePlatform).GetField("_openGlHandle", BindingFlags.NonPublic | BindingFlags.Static);
            handleField.SetValue(null, IntPtr.Zero);
            MacNativePlatform platform = new MacNativePlatform();
            Assert.NotEqual(IntPtr.Zero, platform.GetProcAddress("glClear"));
        }

        [Fact]
        public void GetProcAddress_InvalidFunction_ReturnsZero()
        {
            FieldInfo handleField = typeof(MacNativePlatform).GetField("_openGlHandle", BindingFlags.NonPublic | BindingFlags.Static);
            handleField.SetValue(null, IntPtr.Zero);
            MacNativePlatform platform = new MacNativePlatform();
            Assert.Equal(IntPtr.Zero, platform.GetProcAddress("NonExistentFunctionName12345"));
        }

        [Fact]
        public void GetProcAddress_CachesOpenGLHandle()
        {
            FieldInfo handleField = typeof(MacNativePlatform).GetField("_openGlHandle", BindingFlags.NonPublic | BindingFlags.Static);
            handleField.SetValue(null, IntPtr.Zero);
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetProcAddress("glClear");
            Assert.NotEqual(IntPtr.Zero, (IntPtr)handleField.GetValue(null));
        }

        [Fact]
        public void GetProcAddress_UsesCachedHandleOnSecondCall()
        {
            FieldInfo handleField = typeof(MacNativePlatform).GetField("_openGlHandle", BindingFlags.NonPublic | BindingFlags.Static);
            handleField.SetValue(null, IntPtr.Zero);
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetProcAddress("glClear");
            Assert.NotEqual(IntPtr.Zero, platform.GetProcAddress("glViewport"));
        }

        [Fact]
        public void SetWindowIcon_InvalidPath_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetWindowIcon("/nonexistent/path/icon.png");
        }

        [Fact]
        public void SetWindowIcon_EmptyPath_DoesNotThrow()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.SetWindowIcon(string.Empty);
        }

        [Fact]
        public void GetMouseState_WithSetButtons_ReturnsCorrectState()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseButtons[0] = true;
            platform.mouseButtons[2] = true;
            platform.mouseButtons[4] = true;
            platform.GetMouseState(out int _, out int _, out bool[] buttons);
            Assert.True(buttons[0]);
            Assert.False(buttons[1]);
            Assert.True(buttons[2]);
            Assert.False(buttons[3]);
            Assert.True(buttons[4]);
        }

        [Fact]
        public void GetMouseState_AllButtonsFalse_ReturnsAllFalse()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.GetMouseState(out int _, out int _, out bool[] buttons);
            for (int i = 0; i < buttons.Length; i++)
            {
                Assert.False(buttons[i]);
            }
        }

        [Fact]
        public void GetMouseState_ClonesArray_DoesNotLeakReference()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseButtons[1] = true;
            platform.GetMouseState(out int _, out int _, out bool[] buttons);
            buttons[1] = false;
            Assert.True(platform.mouseButtons[1]);
        }
    }
}
#endif
