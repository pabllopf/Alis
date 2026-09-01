// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP3NullLabelCoverageTests.cs
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
    ///     The im gui p3 null label coverage tests class
    /// </summary>
    public class ImGuiP3NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the dragscalarn_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, 0f, IntPtr.Zero, IntPtr.Zero)));
        }

        /// <summary>
        ///     tests the dragscalarn_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, 0f, IntPtr.Zero, IntPtr.Zero, "")));
        }

        /// <summary>
        ///     tests the dragscalarn_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void DragScalarN_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.DragScalarN(null, (ImGuiDataType)0, IntPtr.Zero, 1, 0f, IntPtr.Zero, IntPtr.Zero, "", (ImGuiSliderFlags)0)));
        }

        /// <summary>
        ///     tests the getid_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void GetId_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.GetId(null)));
        }

        /// <summary>
        ///     tests the imagebutton_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ImageButton_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ImageButton(null, IntPtr.Zero, new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the imagebutton_uv0 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ImageButton_Uv0_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ImageButton(null, IntPtr.Zero, new Vector2F(0, 0), new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the imagebutton_uv0_uv1 null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ImageButton_Uv0_Uv1_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ImageButton(null, IntPtr.Zero, new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0))));
        }

        /// <summary>
        ///     tests the imagebutton_uv0_uv1_bgcol null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ImageButton_Uv0_Uv1_BgCol_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ImageButton(null, IntPtr.Zero, new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0), new Vector4F(0, 0, 0, 1))));
        }

        /// <summary>
        ///     tests the imagebutton_uv0_uv1_bgtint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void ImageButton_Uv0_Uv1_BgTint_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.ImageButton(null, IntPtr.Zero, new Vector2F(0, 0), new Vector2F(0, 0), new Vector2F(0, 0), new Vector4F(0, 0, 0, 1), new Vector4F(0, 0, 0, 1))));
        }

        /// <summary>
        ///     tests the inputdouble_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputDouble_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputDouble(null, ref v)));
        }

        /// <summary>
        ///     tests the inputdouble_step null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputDouble_Step_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputDouble(null, ref v, 0.1)));
        }

        /// <summary>
        ///     tests the inputdouble_step_stepfast null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputDouble_Step_StepFast_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputDouble(null, ref v, 0.1, 1.0)));
        }

        /// <summary>
        ///     tests the inputdouble_step_stepfast_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputDouble_Step_StepFast_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputDouble(null, ref v, 0.1, 1.0, "%.1f")));
        }

        /// <summary>
        ///     tests the inputdouble_step_stepfast_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputDouble_Step_StepFast_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            double v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputDouble(null, ref v, 0.1, 1.0, "%.1f", (ImGuiInputTextFlags)0)));
        }

        /// <summary>
        ///     tests the inputfloat_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat(null, ref v)));
        }

        /// <summary>
        ///     tests the inputfloat_step null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat_Step_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat(null, ref v, 0.1f)));
        }

        /// <summary>
        ///     tests the inputfloat_step_stepfast null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat_Step_StepFast_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat(null, ref v, 0.1f, 1.0f)));
        }

        /// <summary>
        ///     tests the inputfloat_step_stepfast_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat_Step_StepFast_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat(null, ref v, 0.1f, 1.0f, "%.1f")));
        }

        /// <summary>
        ///     tests the inputfloat_step_stepfast_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat_Step_StepFast_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0f;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat(null, ref v, 0.1f, 1.0f, "%.1f", (ImGuiInputTextFlags)0)));
        }

        /// <summary>
        ///     tests the inputfloat2_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat2_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat2(null, ref v)));
        }

        /// <summary>
        ///     tests the inputfloat2_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat2_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat2(null, ref v, "%.1f")));
        }

        /// <summary>
        ///     tests the inputfloat2_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat2_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector2F v = new Vector2F(0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat2(null, ref v, "%.1f", (ImGuiInputTextFlags)0)));
        }

        /// <summary>
        ///     tests the inputfloat3_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat3_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat3(null, ref v)));
        }

        /// <summary>
        ///     tests the inputfloat3_format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat3_Format_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat3(null, ref v, "%.1f")));
        }

        /// <summary>
        ///     tests the inputfloat3_format_flags null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat3_Format_Flags_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector3F v = new Vector3F(0, 0, 0);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat3(null, ref v, "%.1f", (ImGuiInputTextFlags)0)));
        }

        /// <summary>
        ///     tests the inputfloat4_base null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputFloat4_Base_NullLabel_ShouldThrowArgumentNullException()
        {
            Vector4F v = new Vector4F(0, 0, 0, 1);
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputFloat4(null, ref v)));
        }

    }
}
