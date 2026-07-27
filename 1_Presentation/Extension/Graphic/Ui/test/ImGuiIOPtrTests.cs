// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiIOPtrTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui io ptr tests class
    /// </summary>
    public class ImGuiIOPtrTests : IDisposable
    {
        /// <summary>
        ///     The native ptr
        /// </summary>
        internal readonly IntPtr _nativePtr;

        /// <summary>
        ///     The io ptr
        /// </summary>
        private ImGuiIoPtr _ioPtr;

        /// <summary>
        ///     The context
        /// </summary>
        internal readonly IntPtr _context;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ImGuiIOPtrTests" /> class
        /// </summary>
        public ImGuiIOPtrTests()
        {
            _context = ImGuiNative.igCreateContext(IntPtr.Zero);
            ImGuiNative.igSetCurrentContext(_context);

            IntPtr ioPtr = ImGuiNative.igGetIO();
            _nativePtr = ioPtr;
            _ioPtr = new ImGuiIoPtr(_nativePtr);
        }

        /// <summary>
        ///     Disposes this instance
        /// </summary>
        public void Dispose()
        {
            if (_context != IntPtr.Zero)
            {
                ImGuiNative.igDestroyContext(_context);
            }
        }

        /// <summary>
        ///     Tests that add focus event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddFocusEvent_ShouldNotThrow()
        {
            _ioPtr.AddFocusEvent(true);
            _ioPtr.AddFocusEvent(false);
        }

        /// <summary>
        ///     Tests that add input character should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddInputCharacter_ShouldNotThrow()
        {
            _ioPtr.AddInputCharacter(65);
        }

        /// <summary>
        ///     Tests that add input characters utf 8 should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddInputCharactersUtf8_ShouldNotThrow()
        {
            _ioPtr.AddInputCharactersUtf8("hello");
        }

        /// <summary>
        ///     Tests that add input character utf 16 should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddInputCharacterUtf16_ShouldNotThrow()
        {
            _ioPtr.AddInputCharacterUtf16(65);
        }

        /// <summary>
        ///     Tests that add key analog event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddKeyAnalogEvent_ShouldNotThrow()
        {
            _ioPtr.AddKeyAnalogEvent(ImGuiKey.A, true, 0.5f);
            _ioPtr.AddKeyAnalogEvent(ImGuiKey.A, false, 0.0f);
        }

        /// <summary>
        ///     Tests that add key event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddKeyEvent_ShouldNotThrow()
        {
            _ioPtr.AddKeyEvent(ImGuiKey.A, true);
            _ioPtr.AddKeyEvent(ImGuiKey.A, false);
        }

        /// <summary>
        ///     Tests that add mouse button event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddMouseButtonEvent_ShouldNotThrow()
        {
            _ioPtr.AddMouseButtonEvent(0, true);
            _ioPtr.AddMouseButtonEvent(0, false);
        }

        /// <summary>
        ///     Tests that add mouse pos event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddMousePosEvent_ShouldNotThrow()
        {
            _ioPtr.AddMousePosEvent(100.0f, 200.0f);
        }

        /// <summary>
        ///     Tests that add mouse viewport event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddMouseViewportEvent_ShouldNotThrow()
        {
            _ioPtr.BackendFlags |= ImGuiBackendFlags.HasMouseHoveredViewport;
            _ioPtr.AddMouseViewportEvent(1u);
        }

        /// <summary>
        ///     Tests that add mouse wheel event should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void AddMouseWheelEvent_ShouldNotThrow()
        {
            _ioPtr.AddMouseWheelEvent(1.0f, 2.0f);
        }

        /// <summary>
        ///     Tests that clear input characters should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearInputCharacters_ShouldNotThrow()
        {
            _ioPtr.ClearInputCharacters();
        }

        /// <summary>
        ///     Tests that clear input keys should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void ClearInputKeys_ShouldNotThrow()
        {
            _ioPtr.ClearInputKeys();
        }

        /// <summary>
        ///     Tests that set app accepting events should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAppAcceptingEvents_ShouldNotThrow()
        {
            _ioPtr.SetAppAcceptingEvents(true);
            _ioPtr.SetAppAcceptingEvents(false);
        }

        /// <summary>
        ///     Tests that set key event native data should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetKeyEventNativeData_ShouldNotThrow()
        {
            _ioPtr.SetKeyEventNativeData(ImGuiKey.A, 65, 4);
        }

        /// <summary>
        ///     Tests that set key event native data with legacy index should not throw
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetKeyEventNativeData_WithLegacyIndex_ShouldNotThrow()
        {
            _ioPtr.SetKeyEventNativeData(ImGuiKey.A, 65, 4, 0);
        }
    }
}
