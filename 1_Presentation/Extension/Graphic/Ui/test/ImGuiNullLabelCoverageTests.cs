// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiNullLabelCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;
using Alis.Extension.Graphic.Ui;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    ///     The im gui null label coverage tests class
    /// </summary>
    public class ImGuiNullLabelCoverageTests
    {
        /// <summary>
        ///     Tests the slider float 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderFloat4_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderFloat4((string)null, ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt((string)null, ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt((string)null, ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt((string)null, ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the slider int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt2_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt2((string)null, ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the slider int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt2_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt2((string)null, ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the slider int 2 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt2_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt2((string)null, ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the slider int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt3_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt3((string)null, ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the slider int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt3_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt3((string)null, ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the slider int 3 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt3_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt3((string)null, ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the slider int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt4_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt4((string)null, ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the slider int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt4_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt4((string)null, ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the slider int 4 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderInt4_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderInt4((string)null, ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalar_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalar((string)null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero)));

        /// <summary>
        ///     Tests the slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalar_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalar((string)null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (string)null)));

        /// <summary>
        ///     Tests the slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalar_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalar((string)null, (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (string)null, ImGuiSliderFlags.None)));

        /// <summary>
        ///     Tests the slider scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalarN_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalarN((string)null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero)));

        /// <summary>
        ///     Tests the slider scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalarN_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalarN((string)null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero, (string)null)));

        /// <summary>
        ///     Tests the slider scalar n null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SliderScalarN_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SliderScalarN((string)null, (ImGuiDataType)0, IntPtr.Zero, 1, IntPtr.Zero, IntPtr.Zero, (string)null, ImGuiSliderFlags.None)));

        /// <summary>
        ///     Tests the small button null label should throw argument null exception
        /// </summary>
        [Fact]
        public void SmallButton_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.SmallButton((string)null)));

        /// <summary>
        ///     Tests the tab item button null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TabItemButton_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TabItemButton((string)null)));

        /// <summary>
        ///     Tests the tab item button null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TabItemButton_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TabItemButton((string)null, ImGuiTabItemFlags.None)));

        /// <summary>
        ///     Tests the table header null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TableHeader_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TableHeader((string)null)));

        /// <summary>
        ///     Tests the table setup column null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TableSetupColumn((string)null)));

        /// <summary>
        ///     Tests the dock builder dock window null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DockBuilderDockWindow_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DockBuilderDockWindow((string)null, 0u)));
    }
}