// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:PlatformCreateWindowTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="PlatformCreateWindow" /> delegate behavior.
    /// </summary>
    public class PlatformCreateWindowTest
    {
        /// <summary>
        ///     Verifies that the delegate can be invoked with a viewport parameter.
        /// </summary>
        [Fact]
        public void Invoke_ShouldCallAssignedCallback()
        {
            bool called = false;
            PlatformCreateWindow callback = _ => called = true;

            callback(new ImGuiViewportPtr(IntPtr.Zero));

            Assert.True(called);
        }

        /// <summary>
        ///     Verifies platform-specific execution for Windows-only tests.
        /// </summary>
        [WindowsOnly]
        public void WindowsOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Verifies platform-specific execution for macOS-only tests.
        /// </summary>
        [MacOsOnly]
        public void MacOsOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }

        /// <summary>
        ///     Verifies platform-specific execution for Linux-only tests.
        /// </summary>
        [LinuxOnly]
        public void LinuxOnly_ShouldRunIndependently()
        {
            Assert.True(true);
        }
    }
}