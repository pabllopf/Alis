// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP4RemainingCoverageTests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test
{
    /// <summary>
    /// The ImGuiP4 remaining coverage tests class
    /// </summary>
    public class ImGuiP4RemainingCoverageTests
    {
        /// <summary>
        /// Tests that TableSetupColumn_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TableSetupColumn_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TableSetupColumn("label", default); });
            }
        }

        /// <summary>
        /// Tests that TableSetupColumn_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TableSetupColumn_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TableSetupColumn("label", default, 0); });
            }
        }

        /// <summary>
        /// Tests that TableSetupColumn_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TableSetupColumn_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TableSetupColumn("label", default, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that TableSetupScrollFreeze throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TableSetupScrollFreeze_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TableSetupScrollFreeze(0, 0); });
            }
        }

        /// <summary>
        /// Tests that Text throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Text_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Text("label"); });
            }
        }

        /// <summary>
        /// Tests that TextColored throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TextColored_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TextColored(default, "label"); });
            }
        }

        /// <summary>
        /// Tests that TextDisabled throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TextDisabled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TextDisabled("label"); });
            }
        }

        /// <summary>
        /// Tests that TextUnformatted throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TextUnformatted_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TextUnformatted("label"); });
            }
        }

        /// <summary>
        /// Tests that TextWrapped throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TextWrapped_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TextWrapped("label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNode_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNode_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNode("label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNode_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNode_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNode("label", "label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNode_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNode_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNode(IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNodeEx_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNodeEx_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNodeEx("label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNodeEx_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNodeEx_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNodeEx("label", default); });
            }
        }

        /// <summary>
        /// Tests that TreeNodeEx_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNodeEx_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNodeEx("label", default, "label"); });
            }
        }

        /// <summary>
        /// Tests that TreeNodeEx_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreeNodeEx_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreeNodeEx(IntPtr.Zero, default, "label"); });
            }
        }

        /// <summary>
        /// Tests that TreePop throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreePop_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreePop(); });
            }
        }

        /// <summary>
        /// Tests that TreePush_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreePush_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreePush("label"); });
            }
        }

        /// <summary>
        /// Tests that TreePush_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void TreePush_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.TreePush(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that Unindent_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Unindent_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Unindent(); });
            }
        }

        /// <summary>
        /// Tests that Unindent_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Unindent_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Unindent(0); });
            }
        }

        /// <summary>
        /// Tests that UpdatePlatformWindows throws when native library is unavailable
        /// </summary>
        [Fact]
        public void UpdatePlatformWindows_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.UpdatePlatformWindows(); });
            }
        }

        /// <summary>
        /// Tests that Value_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Value_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Value("label", false); });
            }
        }

        /// <summary>
        /// Tests that Value_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Value_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Value("label", 0); });
            }
        }

        /// <summary>
        /// Tests that Value_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Value_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Value("label", 0); });
            }
        }

        /// <summary>
        /// Tests that Value_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Value_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Value("label", 0); });
            }
        }

        /// <summary>
        /// Tests that Value_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Value_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Value("label", 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that VSliderFloat_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderFloat_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderFloat("label", default, ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that VSliderFloat_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderFloat_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderFloat("label", default, ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that VSliderFloat_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderFloat_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderFloat("label", default, ref v, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that VSliderInt_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderInt_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderInt("label", default, ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that VSliderInt_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderInt_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderInt("label", default, ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that VSliderInt_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderInt_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderInt("label", default, ref v, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that VSliderScalar_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderScalar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderScalar("label", default, default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that VSliderScalar_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderScalar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderScalar("label", default, default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that VSliderScalar_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void VSliderScalar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.VSliderScalar("label", default, default, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label", default); });
            }
        }

        /// <summary>
        /// Tests that InputText_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", null, 0); });
            }
        }

        /// <summary>
        /// Tests that InputText_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", null, 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", null, 0, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", null, 0, default, default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputText_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", ref input, 0); });
            }
        }

        /// <summary>
        /// Tests that InputText_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", ref input, 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_7 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", ref input, 0, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", ref input, 0, default, default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputTextMultiline_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextMultiline_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextMultiline("label", ref input, 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputTextMultiline_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextMultiline_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextMultiline("label", ref input, 0, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputTextMultiline_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextMultiline_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextMultiline("label", ref input, 0, default, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputTextMultiline_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextMultiline_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                string input = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextMultiline("label", ref input, 0, default, default, default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that InputTextWithHint_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextWithHint_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextWithHint("label", "label", "label", 0); });
            }
        }

        /// <summary>
        /// Tests that InputTextWithHint_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextWithHint_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextWithHint("label", "label", "label", 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputTextWithHint_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextWithHint_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextWithHint("label", "label", "label", 0, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputTextWithHint_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputTextWithHint_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputTextWithHint("label", "label", "label", 0, default, default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label"); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", false); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, false); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_7 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_8 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", false, 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_9 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, 0, false); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_10 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that CalcTextSize_11 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void CalcTextSize_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CalcTextSize("label", 0, 0, false, 0); });
            }
        }

        /// <summary>
        /// Tests that InputText_9 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that InputText_10 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", IntPtr.Zero, 0, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_11 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", IntPtr.Zero, 0, default, default); });
            }
        }

        /// <summary>
        /// Tests that InputText_12 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void InputText_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.InputText("label", IntPtr.Zero, 0, default, default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that Begin throws when native library is unavailable
        /// </summary>
        [Fact]
        public void Begin_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.Begin("label", default); });
            }
        }
        /// <summary>
        /// Determines whether the cimgui native library can be loaded
        /// </summary>
        /// <returns>True if the library can be loaded</returns>
        private static bool CanLoadCImguiLibrary()
        {
            if (NativeLibrary.TryLoad("cimgui", out _))
            {
                return true;
            }

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP4RemainingCoverageTests).Assembly.Location);
            if (assemblyDir == null)
            {
                return false;
            }

            string[] candidates = new[]
            {
                System.IO.Path.Combine(assemblyDir, "cimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui"),
                System.IO.Path.Combine(assemblyDir, "libcimgui.dylib")
            };

            foreach (string candidate in candidates)
            {
                if (System.IO.File.Exists(candidate) && NativeLibrary.TryLoad(candidate, out _))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
