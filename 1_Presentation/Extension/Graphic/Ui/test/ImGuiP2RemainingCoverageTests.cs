// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuiP2RemainingCoverageTests.cs
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
    /// The ImGuiP2 remaining coverage tests class
    /// </summary>
    public class ImGuiP2RemainingCoverageTests
    {
        /// <summary>
        /// Tests that DragInt_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragInt_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragInt2_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt2_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt2("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragInt3_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt3_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt3("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragInt4_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragInt4_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int v = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragInt4("label", ref v, 0, 0, 0, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label", "label"); });
            }
        }

        /// <summary>
        /// Tests that DragIntRange2_7 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragIntRange2_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                int vCurrentMin = default; int vCurrentMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragIntRange2("label", ref vCurrentMin, ref vCurrentMax, 0, 0, 0, "label", "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero, 0, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_4 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_5 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label"); });
            }
        }

        /// <summary>
        /// Tests that DragScalar_6 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalar_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalar("label", default, IntPtr.Zero, 0, IntPtr.Zero, IntPtr.Zero, "label", default); });
            }
        }

        /// <summary>
        /// Tests that DragScalarN_1 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", default, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that DragScalarN_2 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", default, IntPtr.Zero, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that DragScalarN_3 throws when native library is unavailable
        /// </summary>
        [Fact]
        public void DragScalarN_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                
                Assert.Throws<DllNotFoundException>(() => { ImGui.DragScalarN("label", default, IntPtr.Zero, 0, 0, IntPtr.Zero); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuiP2RemainingCoverageTests).Assembly.Location);
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
