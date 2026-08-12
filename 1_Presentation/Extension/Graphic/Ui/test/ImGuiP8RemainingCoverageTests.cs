// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP8RemainingCoverageTests.cs
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
    /// The ImGuiP8 remaining coverage tests class
    /// </summary>
    public class ImGuiP8RemainingCoverageTests
    {
        /// <summary>
        /// Tests that ShowAboutWindow_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowAboutWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowAboutWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowAboutWindow_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowAboutWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowAboutWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowDebugLogWindow_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowDebugLogWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowDebugLogWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowDebugLogWindow_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowDebugLogWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowDebugLogWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowDemoWindow_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowDemoWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowDemoWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowDemoWindow_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowDemoWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowDemoWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowFontSelector throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowFontSelector_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowFontSelector("label"); });
            }
        }

        /// <summary>
        /// Tests that ShowMetricsWindow_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowMetricsWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowMetricsWindow_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowMetricsWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowStackToolWindow_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowStackToolWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowStackToolWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowStackToolWindow_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowStackToolWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowStackToolWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleEditor_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowStyleEditor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowStyleEditor(); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleEditor_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowStyleEditor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowStyleEditor(default); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleSelector throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowStyleSelector_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowStyleSelector("label"); });
            }
        }

        /// <summary>
        /// Tests that ShowUserGuide throws when native library is unavailable
        /// </summary>
        [Fact]
        public void ShowUserGuide_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.ShowUserGuide(); });
            }
        }

        /// <summary>
        /// Tests that SliderAngle_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderAngle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vRad = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderAngle("label", ref vRad); });
            }
        }

        /// <summary>
        /// Tests that SliderAngle_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderAngle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vRad = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderAngle("label", ref vRad, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderAngle_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderAngle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vRad = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderAngle("label", ref vRad, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderAngle_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderAngle_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vRad = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderAngle("label", ref vRad, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SliderAngle_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderAngle_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float vRad = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderAngle("label", ref vRad, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat("label", ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                float v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat("label", ref v, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat2_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat2("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat2_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat2("label", ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat2_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector2F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat2("label", ref v, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat3_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat3("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat3_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat3("label", ref v, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat3_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat3_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector3F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat3("label", ref v, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat4_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat4("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SliderFloat4_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void SliderFloat4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                Vector4F v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.SliderFloat4("label", ref v, 0, 0, "label"); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP8RemainingCoverageTests).Assembly.Location);
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
