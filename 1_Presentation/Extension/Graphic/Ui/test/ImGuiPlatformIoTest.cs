// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiPlatformIOTest.cs
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
using System.Linq;
using System.Reflection;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Contract tests for the <see cref="ImGuiPlatformIo" /> struct.
    /// </summary>
    public class ImGuiPlatformIOTest
    {
        /// <summary>
        ///     Verifies that ImGuiPlatformIo is a value type.
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImGuiPlatformIo_ShouldBeValueType()
        {
            Assert.True(typeof(ImGuiPlatformIo).IsValueType);
        }

        /// <summary>
        ///     Verifies that PlatformCreateWindow defaults to IntPtr.Zero.
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformCreateWindow_Default_ShouldBeZero()
        {
            ImGuiPlatformIo io = default;

            Assert.Equal(IntPtr.Zero, io.PlatformCreateWindow);
        }

        /// <summary>
        ///     Verifies that PlatformCreateWindow can be set.
        /// </summary>
         [RequireCImguiSystemFact]
        public void PlatformCreateWindow_ShouldBeSettable()
        {
            ImGuiPlatformIo io = default;
            IntPtr expected = new IntPtr(100);

            io.PlatformCreateWindow = expected;

            Assert.Equal(expected, io.PlatformCreateWindow);
        }

        /// <summary>
        ///     Verifies that Monitors defaults to default ImVector.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Monitors_Default_ShouldBeDefault()
        {
            ImGuiPlatformIo io = default;

            Assert.Equal(default(ImVector), io.Monitors);
        }

        /// <summary>
        ///     Verifies that Viewports defaults to default ImVector.
        /// </summary>
         [RequireCImguiSystemFact]
        public void Viewports_Default_ShouldBeDefault()
        {
            ImGuiPlatformIo io = default;

            Assert.Equal(default(ImVector), io.Viewports);
        }
    }
}
