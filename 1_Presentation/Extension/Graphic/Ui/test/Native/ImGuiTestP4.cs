// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiTestP4.cs
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

namespace Alis.Extension.Graphic.Ui.Test.Native
{
    /// <summary>
    ///     The im gui test class
    /// </summary>
    public class ImGuiTestP4
    {
        /// <summary>
        ///     Tests that table setup column throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TableSetupColumn("label", ImGuiTableColumnFlags.None));
        }

        /// <summary>
        ///     Tests that table setup column with init width or weight throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_WithInitWidthOrWeight_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TableSetupColumn("label", ImGuiTableColumnFlags.None, 0.0f));
        }

        /// <summary>
        ///     Tests that table setup column with init width or weight and user id throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetupColumn_WithInitWidthOrWeightAndUserId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TableSetupColumn("label", ImGuiTableColumnFlags.None, 0.0f, 0));
        }

        /// <summary>
        ///     Tests that table setup scroll freeze throws dll not found exception
        /// </summary>
        [Fact]
        public void TableSetupScrollFreeze_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TableSetupScrollFreeze(1, 1));
        }

        /// <summary>
        ///     Tests that text throws dll not found exception
        /// </summary>
        [Fact]
        public void Text_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Text("fmt"));
        }

        /// <summary>
        ///     Tests that text colored throws dll not found exception
        /// </summary>
        [Fact]
        public void TextColored_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TextColored(new Vector4F(), "fmt"));
        }

        /// <summary>
        ///     Tests that text disabled throws dll not found exception
        /// </summary>
        [Fact]
        public void TextDisabled_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TextDisabled("fmt"));
        }

        /// <summary>
        ///     Tests that text unformatted throws dll not found exception
        /// </summary>
        [Fact]
        public void TextUnformatted_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TextUnformatted("text"));
        }

        /// <summary>
        ///     Tests that text wrapped throws dll not found exception
        /// </summary>
        [Fact]
        public void TextWrapped_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TextWrapped("fmt"));
        }

        /// <summary>
        ///     Tests that tree node throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNode_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNode("label"));
        }

        /// <summary>
        ///     Tests that tree node with str id and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNode_WithStrIdAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNode("strId", "fmt"));
        }

        /// <summary>
        ///     Tests that tree node with ptr id and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNode_WithPtrIdAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNode(IntPtr.Zero, "fmt"));
        }

        /// <summary>
        ///     Tests that tree node ex throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNodeEx("label"));
        }

        /// <summary>
        ///     Tests that tree node ex with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNodeEx("label", ImGuiTreeNodeFlags.None));
        }

        /// <summary>
        ///     Tests that tree node ex with str id flags and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_WithStrIdFlagsAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNodeEx("strId", ImGuiTreeNodeFlags.None, "fmt"));
        }

        /// <summary>
        ///     Tests that tree node ex with ptr id flags and fmt throws dll not found exception
        /// </summary>
        [Fact]
        public void TreeNodeEx_WithPtrIdFlagsAndFmt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreeNodeEx(IntPtr.Zero, ImGuiTreeNodeFlags.None, "fmt"));
        }

        /// <summary>
        ///     Tests that tree pop throws dll not found exception
        /// </summary>
        [Fact]
        public void TreePop_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreePop());
        }

        /// <summary>
        ///     Tests that tree push with str id throws dll not found exception
        /// </summary>
        [Fact]
        public void TreePush_WithStrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreePush("strId"));
        }

        /// <summary>
        ///     Tests that tree push with ptr id throws dll not found exception
        /// </summary>
        [Fact]
        public void TreePush_WithPtrId_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.TreePush(IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that unindent throws dll not found exception
        /// </summary>
        [Fact]
        public void Unindent_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Unindent());
        }

        /// <summary>
        ///     Tests that unindent with indent w throws dll not found exception
        /// </summary>
        [Fact]
        public void Unindent_WithIndentW_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Unindent(0.0f));
        }

        /// <summary>
        ///     Tests that update platform windows throws dll not found exception
        /// </summary>
        [Fact]
        public void UpdatePlatformWindows_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.UpdatePlatformWindows());
        }

        /// <summary>
        ///     Tests that value with bool throws dll not found exception
        /// </summary>
        [Fact]
        public void Value_WithBool_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Value("prefix", true));
        }

        /// <summary>
        ///     Tests that value with int throws dll not found exception
        /// </summary>
        [Fact]
        public void Value_WithInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Value("prefix", 0));
        }

        /// <summary>
        ///     Tests that value with uint throws dll not found exception
        /// </summary>
        [Fact]
        public void Value_WithUint_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Value("prefix", 0u));
        }

        /// <summary>
        ///     Tests that value with float throws dll not found exception
        /// </summary>
        [Fact]
        public void Value_WithFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Value("prefix", 0.0f));
        }

        /// <summary>
        ///     Tests that value with float and format throws dll not found exception
        /// </summary>
        [Fact]
        public void Value_WithFloatAndFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Value("prefix", 0.0f, "format"));
        }

        /// <summary>
        ///     Tests that v slider float throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderFloat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float minValue = float.MinValue;
                return ImGui.VSliderFloat("label", new Vector2F(), ref minValue, 0.0f, 1.0f);
            });
        }

        /// <summary>
        ///     Tests that v slider float with format throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderFloat_WithFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float minValue = float.MinValue;
                return ImGui.VSliderFloat("label", new Vector2F(), ref minValue, 0.0f, 1.0f, "format");
            });
        }

        /// <summary>
        ///     Tests that v slider float with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderFloat_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float minValue = float.MinValue;
                return ImGui.VSliderFloat("label", new Vector2F(), ref minValue, 0.0f, 1.0f, "format", ImGuiSliderFlags.None);
            });
        }

        /// <summary>
        ///     Tests that v slider int throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                return ImGui.VSliderInt("label", new Vector2F(), ref minValue, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that v slider int with format throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderInt_WithFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                return ImGui.VSliderInt("label", new Vector2F(), ref minValue, 0, 1, "format");
            });
        }

        /// <summary>
        ///     Tests that v slider int with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderInt_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                return ImGui.VSliderInt("label", new Vector2F(), ref minValue, 0, 1, "format", ImGuiSliderFlags.None);
            });
        }

        /// <summary>
        ///     Tests that v slider scalar throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderScalar_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.VSliderScalar("label", new Vector2F(), ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that v slider scalar with format throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderScalar_WithFormat_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.VSliderScalar("label", new Vector2F(), ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "format"));
        }

        /// <summary>
        ///     Tests that v slider scalar with format and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void VSliderScalar_WithFormatAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.VSliderScalar("label", new Vector2F(), ImGuiDataType.S32, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "format", ImGuiSliderFlags.None));
        }

        /// <summary>
        ///     Tests that input text throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", new byte[0], 0u));
        }

        /// <summary>
        ///     Tests that input text with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", new byte[0], 0u, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input text with flags and callback throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithFlagsAndCallback_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", new byte[0], 0u, ImGuiInputTextFlags.None, null));
        }

        /// <summary>
        ///     Tests that input text with flags callback and user data throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithFlagsCallbackAndUserData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", new byte[0], 0u, ImGuiInputTextFlags.None, null, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input text with string throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithString_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", ref input, 0u));
        }

        /// <summary>
        ///     Tests that input text with string and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithStringAndFlags_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", ref input, 0u, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input text with string flags and callback throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithStringFlagsAndCallback_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", ref input, 0u, ImGuiInputTextFlags.None, null));
        }

        /// <summary>
        ///     Tests that input text with string flags callback and user data throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithStringFlagsCallbackAndUserData_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", ref input, 0u, ImGuiInputTextFlags.None, null, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input text multiline throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextMultiline("label", ref input, 0u, new Vector2F()));
        }

        /// <summary>
        ///     Tests that input text multiline with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_WithFlags_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextMultiline("label", ref input, 0u, new Vector2F(), ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input text multiline with flags and callback throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_WithFlagsAndCallback_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextMultiline("label", ref input, 0u, new Vector2F(), ImGuiInputTextFlags.None, null));
        }

        /// <summary>
        ///     Tests that input text multiline with flags callback and user data throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextMultiline_WithFlagsCallbackAndUserData_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextMultiline("label", ref input, 0u, new Vector2F(), ImGuiInputTextFlags.None, null, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that input text with hint throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextWithHint("label", "hint", input, 0u));
        }

        /// <summary>
        ///     Tests that input text with hint with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_WithFlags_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextWithHint("label", "hint", input, 0u, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input text with hint with flags and callback throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_WithFlagsAndCallback_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextWithHint("label", "hint", input, 0u, ImGuiInputTextFlags.None, null));
        }

        /// <summary>
        ///     Tests that input text with hint with flags callback and user data throws dll not found exception
        /// </summary>
        [Fact]
        public void InputTextWithHint_WithFlagsCallbackAndUserData_ThrowsDllNotFoundException()
        {
            string input = string.Empty;
            Assert.Throws<DllNotFoundException>(() => ImGui.InputTextWithHint("label", "hint", input, 0u, ImGuiInputTextFlags.None, null, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that calc text size throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text"));
        }

        /// <summary>
        ///     Tests that calc text size with start throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStart_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0));
        }

        /// <summary>
        ///     Tests that calc text size with wrap width throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithWrapWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0.0f));
        }

        /// <summary>
        ///     Tests that calc text size with hide text after double hash throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithHideTextAfterDoubleHash_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", true));
        }

        /// <summary>
        ///     Tests that calc text size with start and length throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartAndLength_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, 0));
        }

        /// <summary>
        ///     Tests that calc text size with start and hide text after double hash throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartAndHideTextAfterDoubleHash_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, true));
        }

        /// <summary>
        ///     Tests that calc text size with start and wrap width throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartAndWrapWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, 0.0f));
        }

        /// <summary>
        ///     Tests that calc text size with hide text after double hash and wrap width throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithHideTextAfterDoubleHashAndWrapWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", true, 0.0f));
        }

        /// <summary>
        ///     Tests that calc text size with start length and hide text after double hash throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartLengthAndHideTextAfterDoubleHash_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, 0, true));
        }

        /// <summary>
        ///     Tests that calc text size with start length and wrap width throws dll not found exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartLengthAndWrapWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, 0, 0.0f));
        }

        /// <summary>
        ///     Tests that calc text size with start length hide text after double hash and wrap width throws dll not found
        ///     exception
        /// </summary>
        [Fact]
        public void CalcTextSize_WithStartLengthHideTextAfterDoubleHashAndWrapWidth_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.CalcTextSize("text", 0, 0, true, 0.0f));
        }

        /// <summary>
        ///     Tests that input text with int ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithIntPtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", IntPtr.Zero, 0u));
        }

        /// <summary>
        ///     Tests that input text with int ptr and flags throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithIntPtrAndFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", IntPtr.Zero, 0u, ImGuiInputTextFlags.None));
        }

        /// <summary>
        ///     Tests that input text with int ptr flags and callback throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithIntPtrFlagsAndCallback_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", IntPtr.Zero, 0u, ImGuiInputTextFlags.None, null));
        }

        /// <summary>
        ///     Tests that input text with int ptr flags callback and user data throws dll not found exception
        /// </summary>
        [Fact]
        public void InputText_WithIntPtrFlagsCallbackAndUserData_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.InputText("label", IntPtr.Zero, 0u, ImGuiInputTextFlags.None, null, IntPtr.Zero));
        }

        /// <summary>
        ///     Tests that begin throws dll not found exception
        /// </summary>
        [Fact]
        public void Begin_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImGui.Begin("name", ImGuiWindowFlags.None));
        }
    }
}