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
    /// </summary>
    public class ImGuiNativeIntegrationTest
    {
        /// <summary>
        ///     Verifies the native cimgui library can be loaded and returns a version string.
        ///     igGetVersion is a safe entry point that does NOT require an ImGui context.
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
    }
}
