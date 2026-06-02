// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiConfigFlagsTest.cs
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

using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImGuiConfigFlags" /> enum values.
    /// </summary>
    public class ImGuiConfigFlagsTest
    {
        /// <summary>
        ///     Verifies that None has the expected value of 0.
        /// </summary>
        [Fact]
        public void None_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.None;
            Assert.Equal(0, (int)flag);
        }

        /// <summary>
        ///     Verifies that NavEnableKeyboard has the expected value of 1.
        /// </summary>
        [Fact]
        public void NavEnableKeyboard_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NavEnableKeyboard;
            Assert.Equal(1, (int)flag);
        }

        /// <summary>
        ///     Verifies that NavEnableGamepad has the expected value of 2.
        /// </summary>
        [Fact]
        public void NavEnableGamepad_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NavEnableGamepad;
            Assert.Equal(2, (int)flag);
        }

        /// <summary>
        ///     Verifies that NavEnableSetMousePos has the expected value of 4.
        /// </summary>
        [Fact]
        public void NavEnableSetMousePos_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NavEnableSetMousePos;
            Assert.Equal(4, (int)flag);
        }

        /// <summary>
        ///     Verifies that NavNoCaptureKeyboard has the expected value of 8.
        /// </summary>
        [Fact]
        public void NavNoCaptureKeyboard_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NavNoCaptureKeyboard;
            Assert.Equal(8, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoMouse has the expected value of 16.
        /// </summary>
        [Fact]
        public void NoMouse_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NoMouse;
            Assert.Equal(16, (int)flag);
        }

        /// <summary>
        ///     Verifies that NoMouseCursorChange has the expected value of 32.
        /// </summary>
        [Fact]
        public void NoMouseCursorChange_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.NoMouseCursorChange;
            Assert.Equal(32, (int)flag);
        }

        /// <summary>
        ///     Verifies that DockingEnable has the expected value of 64.
        /// </summary>
        [Fact]
        public void DockingEnable_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.DockingEnable;
            Assert.Equal(64, (int)flag);
        }

        /// <summary>
        ///     Verifies that ViewportsEnable has the expected value of 1024.
        /// </summary>
        [Fact]
        public void ViewportsEnable_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.ViewportsEnable;
            Assert.Equal(1024, (int)flag);
        }

        /// <summary>
        ///     Verifies that DpiEnableScaleViewports has the expected value of 16384.
        /// </summary>
        [Fact]
        public void DpiEnableScaleViewports_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.DpiEnableScaleViewports;
            Assert.Equal(16384, (int)flag);
        }

        /// <summary>
        ///     Verifies that DpiEnableScaleFonts has the expected value of 32768.
        /// </summary>
        [Fact]
        public void DpiEnableScaleFonts_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.DpiEnableScaleFonts;
            Assert.Equal(32768, (int)flag);
        }

        /// <summary>
        ///     Verifies that IsSrgb has the expected value of 1048576.
        /// </summary>
        [Fact]
        public void IsSrgb_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.IsSrgb;
            Assert.Equal(1048576, (int)flag);
        }

        /// <summary>
        ///     Verifies that IsTouchScreen has the expected value of 2097152.
        /// </summary>
        [Fact]
        public void IsTouchScreen_ShouldHaveCorrectValue()
        {
            ImGuiConfigFlags flag = ImGuiConfigFlags.IsTouchScreen;
            Assert.Equal(2097152, (int)flag);
        }

        /// <summary>
        ///     Verifies that flags can be combined with bitwise OR.
        /// </summary>
        [Fact]
        public void Flags_ShouldBeCombinable()
        {
            ImGuiConfigFlags combined = ImGuiConfigFlags.NavEnableKeyboard | ImGuiConfigFlags.DockingEnable;
            int expected = 1 | 64;
            Assert.Equal(expected, (int)combined);
        }
    }
}
