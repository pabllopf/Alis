// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiRemainingCoverageTests.cs
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
    /// The im gui remaining coverage tests class
    /// </summary>
    public class ImGuiRemainingCoverageTests
    {
        /// <summary>
        /// Tests that SliderFloat4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderFloat4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderFloat4("label", ref v, 0, 0, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt("label", ref v, 0, 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt("label", ref v, 0, 0, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderInt_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt("label", ref v, 0, 0, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt2_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt2("label", ref v, 0, 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt2_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt2("label", ref v, 0, 0, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderInt2_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt2("label", ref v, 0, 0, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt3_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt3("label", ref v, 0, 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt3_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt3("label", ref v, 0, 0, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderInt3_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt3_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt3("label", ref v, 0, 0, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt4_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt4("label", ref v, 0, 0));
            }
        }

        /// <summary>
        /// Tests that SliderInt4_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt4("label", ref v, 0, 0, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderInt4_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderInt4_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderInt4("label", ref v, 0, 0, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderScalar_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalar("label", 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero));
            }
        }

        /// <summary>
        /// Tests that SliderScalar_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalar("label", 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderScalar_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalar("label", 0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SliderScalarN_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalarN_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalarN("label", 0, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero));
            }
        }

        /// <summary>
        /// Tests that SliderScalarN_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalarN_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalarN("label", 0, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label"));
            }
        }

        /// <summary>
        /// Tests that SliderScalarN_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SliderScalarN_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SliderScalarN("label", 0, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label", 0));
            }
        }

        /// <summary>
        /// Tests that SmallButton throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SmallButton_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.SmallButton("label"));
            }
        }

        /// <summary>
        /// Tests that Spacing throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Spacing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.Spacing());
            }
        }

        /// <summary>
        /// Tests that StyleColorsClassic_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsClassic_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsClassic());
            }
        }

        /// <summary>
        /// Tests that StyleColorsClassic_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsClassic_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsClassic(default));
            }
        }

        /// <summary>
        /// Tests that StyleColorsDark_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsDark_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsDark());
            }
        }

        /// <summary>
        /// Tests that StyleColorsDark_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsDark_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsDark(default));
            }
        }

        /// <summary>
        /// Tests that StyleColorsLight_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsLight_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsLight());
            }
        }

        /// <summary>
        /// Tests that StyleColorsLight_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void StyleColorsLight_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.StyleColorsLight(default));
            }
        }

        /// <summary>
        /// Tests that TabItemButton_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TabItemButton_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TabItemButton("label"));
            }
        }

        /// <summary>
        /// Tests that TabItemButton_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TabItemButton_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TabItemButton("label", 0));
            }
        }

        /// <summary>
        /// Tests that TableGetColumnCount throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnCount_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnCount());
            }
        }

        /// <summary>
        /// Tests that TableGetColumnFlags_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnFlags_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnFlags());
            }
        }

        /// <summary>
        /// Tests that TableGetColumnFlags_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnFlags_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnFlags(0));
            }
        }

        /// <summary>
        /// Tests that TableGetColumnIndex throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnIndex());
            }
        }

        /// <summary>
        /// Tests that TableGetColumnName_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnName_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnName());
            }
        }

        /// <summary>
        /// Tests that TableGetColumnName_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetColumnName_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetColumnName(0));
            }
        }

        /// <summary>
        /// Tests that TableGetRowIndex throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetRowIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetRowIndex());
            }
        }

        /// <summary>
        /// Tests that TableGetSortSpecs throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableGetSortSpecs_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableGetSortSpecs());
            }
        }

        /// <summary>
        /// Tests that TableHeader throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableHeader_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableHeader("label"));
            }
        }

        /// <summary>
        /// Tests that TableHeadersRow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableHeadersRow_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableHeadersRow());
            }
        }

        /// <summary>
        /// Tests that TableNextColumn throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableNextColumn_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableNextColumn());
            }
        }

        /// <summary>
        /// Tests that TableNextRow_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableNextRow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableNextRow());
            }
        }

        /// <summary>
        /// Tests that TableNextRow_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableNextRow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableNextRow(0));
            }
        }

        /// <summary>
        /// Tests that TableNextRow_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableNextRow_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableNextRow(0, 0));
            }
        }

        /// <summary>
        /// Tests that TableSetBgColor_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSetBgColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableSetBgColor(0, 0));
            }
        }

        /// <summary>
        /// Tests that TableSetBgColor_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSetBgColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableSetBgColor(0, 0, 0));
            }
        }

        /// <summary>
        /// Tests that TableSetColumnEnabled throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSetColumnEnabled_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableSetColumnEnabled(0, false));
            }
        }

        /// <summary>
        /// Tests that TableSetColumnIndex throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSetColumnIndex_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableSetColumnIndex(0));
            }
        }

        /// <summary>
        /// Tests that TableSetupColumn throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void TableSetupColumn_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.TableSetupColumn("label"));
            }
        }

        /// <summary>
        /// Tests that MenuItem throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void MenuItem_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.MenuItem("label", false));
            }
        }

        /// <summary>
        /// Tests that ImFontConfig throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ImFontConfig_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.ImFontConfig());
            }
        }

        /// <summary>
        /// Tests that DockBuilderRemoveNode throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderRemoveNode_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderRemoveNode(0));
            }
        }

        /// <summary>
        /// Tests that DockBuilderAddNode throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderAddNode_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderAddNode(0, 0));
            }
        }

        /// <summary>
        /// Tests that DockBuilderSetNodeSize throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderSetNodeSize_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderSetNodeSize(0, default));
            }
        }

        /// <summary>
        /// Tests that DockBuilderSplitNode throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderSplitNode_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                uint dockIdRight = default;
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderSplitNode(0, 0, 0, null, out dockIdRight));
            }
        }

        /// <summary>
        /// Tests that DockBuilderDockWindow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderDockWindow_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderDockWindow("label", 0));
            }
        }

        /// <summary>
        /// Tests that DockBuilderFinish throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderFinish_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderFinish(0));
            }
        }

        /// <summary>
        /// Tests that DockBuilderSetNodeFlags throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockBuilderSetNodeFlags_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => ImGui.DockBuilderSetNodeFlags(0, 0));
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiRemainingCoverageTests).Assembly.Location);
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
