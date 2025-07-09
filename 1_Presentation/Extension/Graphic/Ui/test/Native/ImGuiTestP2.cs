// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP2.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    public class ImGuiTestP2
    {
        /// <summary>
        ///     Tests that drag int throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 2 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 2 with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 2 with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 2 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 2 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt2_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt2("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 3 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 3 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 3 with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 3 with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 3 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 3 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt3_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt3("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int 4 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v));
        }

        /// <summary>
        ///     Tests that drag int 4 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithSpeed_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int 4 with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithMin_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int 4 with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithMinMax_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int 4 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithFormat_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int 4 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragInt4_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            int v = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragInt4("label", ref v, 1.0f, 0, 100, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag int range 2 throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max));
        }

        /// <summary>
        ///     Tests that drag int range 2 with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithSpeed_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max, 1.0f));
        }

        /// <summary>
        ///     Tests that drag int range 2 with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithMin_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max, 1.0f, 0));
        }

        /// <summary>
        ///     Tests that drag int range 2 with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithMinMax_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max, 1.0f, 0, 100));
        }

        /// <summary>
        ///     Tests that drag int range 2 with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithFormat_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max, 1.0f, 0, 100, "%d"));
        }

        /// <summary>
        ///     Tests that drag int range 2 with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragIntRange2_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            int min = 0, max = 0;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragIntRange2("label", ref min, ref max, 1.0f, 0, 100, "%d", ""));
        }

        /// <summary>
        ///     Tests that drag scalar throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData));
        }

        /// <summary>
        ///     Tests that drag scalar with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_WithSpeed_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData, 1.0f));
        }

        /// <summary>
        ///     Tests that drag scalar with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_WithMin_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that drag scalar with min max throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_WithMinMax_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that drag scalar with format throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_WithFormat_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero, "%d"));
        }

        /// <summary>
        ///     Tests that drag scalar with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalar_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalar("label", ImGuiDataType.S32, pData, 1.0f, IntPtr.Zero, IntPtr.Zero, "%d", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that drag scalar n throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalarN("label", ImGuiDataType.S32, pData, 1));
        }

        /// <summary>
        ///     Tests that drag scalar n with speed throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_WithSpeed_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalarN("label", ImGuiDataType.S32, pData, 1, 1.0f));
        }

        /// <summary>
        ///     Tests that drag scalar n with min throws dll not found exception
        /// </summary>
        [Fact]
        public void DragScalarN_WithMin_ThrowsDllNotFoundException()
        {
            IntPtr pData = IntPtr.Zero;
            Assert.Throws<DllNotFoundException>(() => ImGui.DragScalarN("label", ImGuiDataType.S32, pData, 1, 1.0f, IntPtr.Zero));
        }
    }
}