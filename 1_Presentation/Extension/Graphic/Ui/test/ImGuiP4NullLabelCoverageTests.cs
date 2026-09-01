// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4NullLabelCoverageTests.cs
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
    ///     The im gui p4 null label coverage tests class
    /// </summary>
    public class ImGuiP4NullLabelCoverageTests
    {
        /// <summary>
        ///     Tests the table setup column null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TableSetupColumn((string)null, ImGuiTableColumnFlags.None)));

        /// <summary>
        ///     Tests the table setup column null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TableSetupColumn((string)null, ImGuiTableColumnFlags.None, 0.0f)));

        /// <summary>
        ///     Tests the table setup column null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TableSetupColumn((string)null, ImGuiTableColumnFlags.None, 0.0f, 0u)));

        /// <summary>
        ///     Tests the text null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Text_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Text((string)null)));

        /// <summary>
        ///     Tests the text colored null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TextColored_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TextColored(new Vector4F(0, 0, 0, 1), (string)null)));

        /// <summary>
        ///     Tests the text disabled null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TextDisabled_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TextDisabled((string)null)));

        /// <summary>
        ///     Tests the text unformatted null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TextUnformatted_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TextUnformatted((string)null)));

        /// <summary>
        ///     Tests the text wrapped null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TextWrapped_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TextWrapped((string)null)));

        /// <summary>
        ///     Tests the tree node null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNode_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNode((string)null)));

        /// <summary>
        ///     Tests the tree node null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNode_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNode((string)null, "f")));

        /// <summary>
        ///     Tests the tree node null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNode_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNode(IntPtr.Zero, (string)null)));

        /// <summary>
        ///     Tests the tree node ex null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNodeEx((string)null)));

        /// <summary>
        ///     Tests the tree node ex null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNodeEx((string)null, ImGuiTreeNodeFlags.None)));

        /// <summary>
        ///     Tests the tree node ex null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNodeEx((string)null, ImGuiTreeNodeFlags.None, "f")));

        /// <summary>
        ///     Tests the tree node ex null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_3_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreeNodeEx(IntPtr.Zero, ImGuiTreeNodeFlags.None, (string)null)));

        /// <summary>
        ///     Tests the tree push null label should throw argument null exception
        /// </summary>
        [Fact]
        public void TreePush_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.TreePush((string)null)));

        /// <summary>
        ///     Tests the value bool null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Value_Bool_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Value((string)null, true)));

        /// <summary>
        ///     Tests the value int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Value_Int_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Value((string)null, 0)));

        /// <summary>
        ///     Tests the value uint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Value_Uint_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Value((string)null, 0u)));

        /// <summary>
        ///     Tests the value float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Value_Float_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Value((string)null, 0.0f)));

        /// <summary>
        ///     Tests the value float format null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Value_FloatFormat_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Value((string)null, 0.0f, (string)null)));

        /// <summary>
        ///     Tests the v slider float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderFloat_0_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderFloat((string)null, new Vector2F(0, 0), ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the v slider float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderFloat_1_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderFloat((string)null, new Vector2F(0, 0), ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the v slider float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderFloat_2_NullLabel_ShouldThrowArgumentNullException()
        {
            float v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderFloat((string)null, new Vector2F(0, 0), ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the v slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderInt_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderInt((string)null, new Vector2F(0, 0), ref v, 0, 1)));
        }

        /// <summary>
        ///     Tests the v slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderInt_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderInt((string)null, new Vector2F(0, 0), ref v, 0, 1, (string)null)));
        }

        /// <summary>
        ///     Tests the v slider int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderInt_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int v = 0;
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderInt((string)null, new Vector2F(0, 0), ref v, 0, 1, (string)null, ImGuiSliderFlags.None)));
        }

        /// <summary>
        ///     Tests the v slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderScalar_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderScalar((string)null, new Vector2F(0, 0), (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero)));

        /// <summary>
        ///     Tests the v slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderScalar_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderScalar((string)null, new Vector2F(0, 0), (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (string)null)));

        /// <summary>
        ///     Tests the v slider scalar null label should throw argument null exception
        /// </summary>
        [Fact]
        public void VSliderScalar_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.VSliderScalar((string)null, new Vector2F(0, 0), (ImGuiDataType)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, (string)null, ImGuiSliderFlags.None)));

        /// <summary>
        ///     Tests the input text byte array null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Buf_0_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] buf = new byte[1];
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, buf, 1)));
        }

        /// <summary>
        ///     Tests the input text byte array null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Buf_1_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] buf = new byte[1];
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, buf, 1, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     Tests the input text byte array null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Buf_2_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] buf = new byte[1];
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, buf, 1, ImGuiInputTextFlags.None, null)));
        }

        /// <summary>
        ///     Tests the input text byte array null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Buf_3_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] buf = new byte[1];
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, buf, 1, ImGuiInputTextFlags.None, null, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the input text int ptr null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_IntPtr_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, IntPtr.Zero, 1u, ImGuiInputTextFlags.None)));

        /// <summary>
        ///     Tests the input text int ptr null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_IntPtr_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, IntPtr.Zero, 1u, ImGuiInputTextFlags.None, null)));

        /// <summary>
        ///     Tests the input text int ptr null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_IntPtr_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, IntPtr.Zero, 1u, ImGuiInputTextFlags.None, null, IntPtr.Zero)));

        /// <summary>
        ///     Tests the input text ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Ref_0_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, ref input, 1u)));
        }

        /// <summary>
        ///     Tests the input text ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Ref_1_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, ref input, 1u, ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     Tests the input text ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Ref_2_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, ref input, 1u, ImGuiInputTextFlags.None, null)));
        }

        /// <summary>
        ///     Tests the input text ref null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputText_Ref_3_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputText((string)null, ref input, 1u, ImGuiInputTextFlags.None, null, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the input text multiline null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_0_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "i";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextMultiline((string)null, ref input, 1u, new Vector2F(0, 0), ImGuiInputTextFlags.None)));
        }

        /// <summary>
        ///     Tests the input text multiline null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_1_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "i";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextMultiline((string)null, ref input, 1u, new Vector2F(0, 0), ImGuiInputTextFlags.None, null)));
        }

        /// <summary>
        ///     Tests the input text multiline null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_2_NullLabel_ShouldThrowArgumentNullException()
        {
            string input = "i";
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextMultiline((string)null, ref input, 1u, new Vector2F(0, 0), ImGuiInputTextFlags.None, null, IntPtr.Zero)));
        }

        /// <summary>
        ///     Tests the input text with hint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextWithHint((string)null, "h", "i", 1u)));

        /// <summary>
        ///     Tests the input text with hint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextWithHint((string)null, "h", "i", 1u, ImGuiInputTextFlags.None)));

        /// <summary>
        ///     Tests the input text with hint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextWithHint((string)null, "h", "i", 1u, ImGuiInputTextFlags.None, null)));

        /// <summary>
        ///     Tests the input text with hint null label should throw argument null exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_3_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.InputTextWithHint((string)null, "h", "i", 1u, ImGuiInputTextFlags.None, null, IntPtr.Zero)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_1_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_2_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0.0f)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_3_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, true)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_4_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, 1)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_5_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, true)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_6_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, 0.0f)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_7_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, true, 0.0f)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_8_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, 1, true)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_9_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, 1, 0.0f)));

        /// <summary>
        ///     Tests the calc text size null label should throw argument null exception
        /// </summary>
        [Fact]
        public void CalcTextSize_10_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.CalcTextSize((string)null, 0, 1, true, 0.0f)));

        /// <summary>
        ///     Tests the begin null label should throw argument null exception
        /// </summary>
        [Fact]
        public void Begin_0_NullLabel_ShouldThrowArgumentNullException() =>
            Assert.Throws<ArgumentNullException>((Action)(() => ImGui.Begin((string)null, ImGuiWindowFlags.None)));
    }
}