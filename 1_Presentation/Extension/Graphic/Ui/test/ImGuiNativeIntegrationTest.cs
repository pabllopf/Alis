// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNativeIntegrationTest.cs
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
    ///     Integration tests that exercise the native cimgui library via P/Invoke.
    ///     These tests require the native library to be present at runtime
    ///     and only run on macOS (the current dev platform).
    ///     <br/><br/>
    ///     NOTE: Some native functions (igGetColumnIndex, igGetColumnsCount) crash
    ///     with SIGSEGV on the bundled cimgui build — likely a version mismatch
    ///     between the cimgui binary and the .NET struct layout. Those are excluded
    ///     from this test class.
    /// </summary>
    public class ImGuiNativeIntegrationTest : IDisposable
    {
        private readonly IntPtr _context;

        /// <summary>
        ///     Initializes a new instance, creating a fresh ImGui context for the test.
        /// </summary>
        public ImGuiNativeIntegrationTest()
        {
            if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
            {
                _context = ImGuiNative.igCreateContext(IntPtr.Zero);
                ImGuiNative.igSetCurrentContext(_context);
            }
        }

        /// <summary>
        ///     Cleans up the ImGui context after each test.
        /// </summary>
        public void Dispose()
        {
            if (_context != IntPtr.Zero)
            {
                ImGuiNative.igDestroyContext(_context);
            }
        }

        /// <summary>
        ///     Verifies the native cimgui library can be loaded and returns a version string.
        ///     igGetVersion does NOT require an ImGui context.
        /// </summary>
        [MacOsOnly]
        public void IgGetVersion_ShouldReturnNonEmptyString()
        {
            IntPtr versionPtr = ImGuiNative.igGetVersion();
            Assert.NotEqual(IntPtr.Zero, versionPtr);

            string version = Marshal.PtrToStringAnsi(versionPtr);
            Assert.NotNull(version);
            Assert.NotEmpty(version);
        }

        /// <summary>
        ///     Verifies igGetFrameCount returns a non-negative value with an active context.
        /// </summary>
        [MacOsOnly]
        public void GetFrameCount_WithContext_ShouldReturnNonNegative()
        {
            int frameCount = ImGuiNative.igGetFrameCount();
            Assert.True(frameCount >= 0);
        }

        /// <summary>
        ///     Verifies igGetCurrentContext returns the context set by igSetCurrentContext.
        /// </summary>
        [MacOsOnly]
        public void GetCurrentContext_ShouldReturnValidPointer()
        {
            IntPtr current = ImGuiNative.igGetCurrentContext();
            Assert.NotEqual(IntPtr.Zero, current);
        }

        /// <summary>
        ///     Verifies igGetStyle returns a reference to ImGuiStyle with default values.
        /// </summary>
        [MacOsOnly]
        public void GetStyle_ShouldReturnDefaultValues()
        {
            ref ImGuiStyle style = ref ImGuiNative.igGetStyle();
            Assert.True(style.Alpha > 0);
            Assert.True(style.WindowPadding.X >= 0);
        }

        /// <summary>
        ///     Verifies igGetIO returns a pointer to the ImGuiIO struct.
        /// </summary>
        [MacOsOnly]
        public void GetIO_ShouldReturnNonZeroPointer()
        {
            IntPtr io = ImGuiNative.igGetIO();
            Assert.NotEqual(IntPtr.Zero, io);
        }
    }
}
