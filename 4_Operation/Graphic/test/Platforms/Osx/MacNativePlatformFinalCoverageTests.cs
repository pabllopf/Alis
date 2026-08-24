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
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Alis.Core.Graphic.Platforms.Osx;
using Alis.Core.Graphic.Platforms.Osx.Native;
using Alis.Core.Graphic.Test.Attributes;
using Xunit;

namespace Alis.Core.Graphic.Test.Platforms.Osx
{
    /// <summary>
    ///     Covers the remaining MacNativePlatform behaviors: mouse state clone semantics,
    ///     multi-key pressed state and synthesized key event handling.
    /// </summary>
    public class MacNativePlatformFinalCoverageTests
    {
        /// <summary>
        ///     The core graphics path
        /// </summary>
        private const string CoreGraphicsPath = "/System/Library/Frameworks/CoreGraphics.framework/CoreGraphics";

        /// <summary>
        ///     The app kit path
        /// </summary>
        private const string AppKitPath = "/System/Library/Frameworks/AppKit.framework/AppKit";

        /// <summary>
        ///     The right arrow key code
        /// </summary>
        private const ushort LeftArrowKeyCode = 123;

        /// <summary>
        ///     The ansi a key code
        /// </summary>
        private const ushort AnsiAKeyCode = 0;

        /// <summary>
        ///     Creates a keyboard event using the specified key code
        /// </summary>
        /// <param name="source">The source</param>
        /// <param name="virtualKey">The virtual key</param>
        /// <param name="keyDown">The key down</param>
        /// <returns>The int ptr</returns>
        [ExcludeFromCodeCoverage]
        [DllImport(CoreGraphicsPath)]
        private static extern IntPtr CGEventCreateKeyboardEvent(IntPtr source, ushort virtualKey, bool keyDown);

        /// <summary>
        ///     Sets the unicode string using the specified event
        /// </summary>
        /// <param name="eventRef">The event ref</param>
        /// <param name="stringLength">The string length</param>
        /// <param name="unicodeString">The unicode string</param>
        /// <param name="flags">The flags</param>
        [ExcludeFromCodeCoverage]
        [DllImport(CoreGraphicsPath)]
        private static extern void CGEventKeyboardSetUnicodeString(IntPtr eventRef, ulong stringLength, IntPtr unicodeString, ulong flags);

        /// <summary>
        ///     Verifies that GetMouseState returns a cloned array so callers cannot corrupt the internal state.
        /// </summary>
        [Fact]
        public void GetMouseState_ReturnedButtons_AreIsolatedFromInternalState()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.mouseButtons[0] = true;

            platform.GetMouseState(out int _, out int _, out bool[] first);
            first[0] = false;
            first[1] = true;

            platform.GetMouseState(out int _, out int _, out bool[] second);
            Assert.True(second[0]);
            Assert.False(second[1]);
        }

        /// <summary>
        ///     Verifies that GetMouseState forwards the internal button states.
        /// </summary>
        [Fact]
        public void GetMouseState_WithInternalButtonsSet_ForwardsAllStates()
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

        /// <summary>
        ///     Verifies that releasing a digit key removes only that digit from the pressed set.
        /// </summary>
        [Fact]
        public void MapCharacterKey_DigitKeyUp_RemovesOnlyThatDigit()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('7', true);
            platform.MapCharacterKey('9', true);

            platform.MapCharacterKey('7', false);
            Assert.False(platform.IsKeyDown(ConsoleKey.D7));
            Assert.True(platform.IsKeyDown(ConsoleKey.D9));
        }

        /// <summary>
        ///     Verifies that releasing a symbol key removes only that symbol from the pressed set.
        /// </summary>
        [Fact]
        public void MapCharacterKey_SymbolKeyUp_RemovesOnlyThatSymbol()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey(' ', true);
            platform.MapCharacterKey('.', true);

            platform.MapCharacterKey(' ', false);
            Assert.False(platform.IsKeyDown(ConsoleKey.Spacebar));
            Assert.True(platform.IsKeyDown(ConsoleKey.OemPeriod));
        }

        /// <summary>
        ///     Verifies that multiple keys can be held down at the same time.
        /// </summary>
        [Fact]
        public void MapCharacterKey_MultipleKeysDown_KeepsAllKeys()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('A', true);
            platform.MapCharacterKey('B', true);
            platform.MapCharacterKey('C', true);

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.IsKeyDown(ConsoleKey.B));
            Assert.True(platform.IsKeyDown(ConsoleKey.C));
        }

        /// <summary>
        ///     Verifies that the last pressed key is the most recently mapped key.
        /// </summary>
        [Fact]
        public void TryGetLastKeyPressed_MultipleKeysDown_ReturnsMostRecentKey()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('A', true);
            platform.MapCharacterKey('B', true);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.B, key);
        }

        /// <summary>
        ///     Verifies that consuming the last key press does not clear the pressed set.
        /// </summary>
        [Fact]
        public void TryGetLastKeyPressed_ConsumeKeepsPressedState()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('A', true);

            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey _));
            Assert.True(platform.IsKeyDown(ConsoleKey.A));
        }

        /// <summary>
        ///     Verifies that releasing an unmapped character does nothing.
        /// </summary>
        [Fact]
        public void MapCharacterKey_UnmappedKeyUp_DoesNothing()
        {
            MacNativePlatform platform = new MacNativePlatform();
            platform.MapCharacterKey('~', false);

            Assert.False(platform.IsKeyDown(ConsoleKey.Oem3));
            Assert.False(platform.TryGetLastKeyPressed(out _));
        }

        /// <summary>
        ///     Verifies that a synthesized key down event for a letter key updates the pressed state.
        /// </summary>
        [MacOsOnly]
        public void HandleKeyDownEvent_LetterKey_AddsKeyToPressedState()
        {
            IntPtr nsEvent = CreateKeyboardEvent(AnsiAKeyCode, 'a', true);

            MacNativePlatform platform = new MacNativePlatform();
            platform.HandleKeyDownEvent(nsEvent);

            Assert.True(platform.IsKeyDown(ConsoleKey.A));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.A, key);
        }

        /// <summary>
        ///     Verifies that a synthesized key down event for a special key adds the mapped key.
        /// </summary>
        [MacOsOnly]
        public void HandleKeyDownEvent_SpecialKey_AddsMappedKey()
        {
            IntPtr nsEvent = CreateKeyboardEvent(LeftArrowKeyCode, '\0', true);

            MacNativePlatform platform = new MacNativePlatform();
            platform.HandleKeyDownEvent(nsEvent);

            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));
            Assert.True(platform.TryGetLastKeyPressed(out ConsoleKey key));
            Assert.Equal(ConsoleKey.LeftArrow, key);
        }

        /// <summary>
        ///     Verifies that a synthesized key up event for a special key removes the mapped key.
        /// </summary>
        [MacOsOnly]
        public void HandleKeyUpEvent_SpecialKey_RemovesMappedKey()
        {
            IntPtr keyDownEvent = CreateKeyboardEvent(LeftArrowKeyCode, '\0', true);
            IntPtr keyUpEvent = CreateKeyboardEvent(LeftArrowKeyCode, '\0', false);

            MacNativePlatform platform = new MacNativePlatform();
            platform.HandleKeyDownEvent(keyDownEvent);
            Assert.True(platform.IsKeyDown(ConsoleKey.LeftArrow));

            platform.HandleKeyUpEvent(keyUpEvent);
            Assert.False(platform.IsKeyDown(ConsoleKey.LeftArrow));
        }

        /// <summary>
        ///     Creates a native key event without initializing the application
        /// </summary>
        /// <param name="keyCode">The key code</param>
        /// <param name="character">The character</param>
        /// <param name="isKeyDown">The is key down</param>
        /// <returns>The int ptr</returns>
        private static IntPtr CreateKeyboardEvent(ushort keyCode, char character, bool isKeyDown)
        {
            IntPtr appKit = ObjectiveCInterop.Dlopen(AppKitPath, 1);
            if (appKit == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            IntPtr cgEvent = CGEventCreateKeyboardEvent(IntPtr.Zero, keyCode, isKeyDown);
            if (cgEvent == IntPtr.Zero)
            {
                return IntPtr.Zero;
            }

            if (character != '\0')
            {
                IntPtr unicode = Marshal.StringToHGlobalUni(character.ToString());
                CGEventKeyboardSetUnicodeString(cgEvent, 1, unicode, 0);
                Marshal.FreeHGlobal(unicode);
            }

            try
            {
                return ObjectiveCInterop.objc_msgSend_IntPtr(
                    ObjectiveCInterop.Class("NSEvent"),
                    ObjectiveCInterop.Sel("eventWithCGEvent:"),
                    cgEvent);
            }
            finally
            {
                ObjectiveCInterop.CFRelease(cgEvent);
            }
        }
    }
}
#endif
