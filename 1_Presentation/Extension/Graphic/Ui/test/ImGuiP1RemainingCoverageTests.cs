// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP1RemainingCoverageTests.cs
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
    /// The ImGuiP1 remaining coverage tests class
    /// </summary>
    public class ImGuiP1RemainingCoverageTests
    {
        /// <summary>
        /// Tests that Combo_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Combo_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Combo("label", ref currentItem, "label"); });
            }
        }

        /// <summary>
        /// Tests that Combo_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Combo_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int currentItem = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.Combo("label", ref currentItem, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that CreateContext_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CreateContext_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CreateContext(); });
            }
        }

        /// <summary>
        /// Tests that CreateContext_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void CreateContext_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.CreateContext(default); });
            }
        }

        /// <summary>
        /// Tests that DebugCheckVersionAndDataLayout throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DebugCheckVersionAndDataLayout_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DebugCheckVersionAndDataLayout("label", 0, 0, 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DebugTextEncoding throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DebugTextEncoding_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DebugTextEncoding("label"); });
            }
        }

        /// <summary>
        /// Tests that DockSpace_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpace_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpace(0); });
            }
        }

        /// <summary>
        /// Tests that DockSpace_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpace_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpace(0, default); });
            }
        }

        /// <summary>
        /// Tests that DockSpace_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpace_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpace(0, default, default); });
            }
        }

        /// <summary>
        /// Tests that DockSpace_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpace_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpace(0, default, default, default); });
            }
        }

        /// <summary>
        /// Tests that DockSpaceOverViewport_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpaceOverViewport_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpaceOverViewport(); });
            }
        }

        /// <summary>
        /// Tests that DockSpaceOverViewport_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpaceOverViewport_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpaceOverViewport(default); });
            }
        }

        /// <summary>
        /// Tests that DockSpaceOverViewport_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpaceOverViewport_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpaceOverViewport(default, default); });
            }
        }

        /// <summary>
        /// Tests that DockSpaceOverViewport_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DockSpaceOverViewport_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DockSpaceOverViewport(default, default, default); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloat_6 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloat2_6 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat2_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat2("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloat3_6 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat3_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat3("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloat4_6 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloat4_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloat4("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_1 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_2 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_3 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_4 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_5 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_6 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label", "label"); });
            }
        }

        /// <summary>
        /// Tests that DragFloatRange2_7 throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragFloatRange2_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vCurrentMin = default; float vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragFloatRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label", "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragInt throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DragInt_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP1RemainingCoverageTests).Assembly.Location);
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
