// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImGuizMoRemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.GuizMo;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.GuizMo
{
    /// <summary>
    /// The ImGuizMo remaining coverage tests class
    /// </summary>
    public class ImGuizMoRemainingCoverageTests
    {
        /// <summary>
        /// Tests that AllowAxisFlip throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void AllowAxisFlip_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.AllowAxisFlip(false); });
            }
        }

        /// <summary>
        /// Tests that BeginFrame throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void BeginFrame_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.BeginFrame(); });
            }
        }

        /// <summary>
        /// Tests that DecomposeMatrixToComponents throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DecomposeMatrixToComponents_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float[] matrix = default; float[] translation = default; float[] rotation = default; float[] scale = default;
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.DecomposeMatrixToComponents(ref matrix, ref translation, ref rotation, ref scale); });
            }
        }

        /// <summary>
        /// Tests that DrawCubes throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DrawCubes_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float view = default; float projection = default; float matrices = default;
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.DrawCubes(ref view, ref projection, ref matrices, 0); });
            }
        }

        /// <summary>
        /// Tests that DrawGrid throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void DrawGrid_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float[] view = default; float[] projection = default; float[] matrix = default;
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.DrawGrid(ref view, ref projection, ref matrix, 0); });
            }
        }

        /// <summary>
        /// Tests that Enable throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Enable_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.Enable(false); });
            }
        }

        /// <summary>
        /// Tests that IsOver throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsOver_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.IsOver(); });
            }
        }

        /// <summary>
        /// Tests that IsOver throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsOver_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.IsOver((Operations)0); });
            }
        }

        /// <summary>
        /// Tests that IsUsing throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void IsUsing_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.IsUsing(); });
            }
        }

        /// <summary>
        /// Tests that Manipulate throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void Manipulate_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.Manipulate(default(float[]), default(float[]), (Operations)0, (Mode)0, default(float[])); });
            }
        }

        /// <summary>
        /// Tests that RecomposeMatrixFromComponents throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void RecomposeMatrixFromComponents_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float[] translation = default; float[] rotation = default; float[] scale = default; float[] matrix = default;
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.RecomposeMatrixFromComponents(ref translation, ref rotation, ref scale, ref matrix); });
            }
        }

        /// <summary>
        /// Tests that SetDrawList throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetDrawList_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetDrawList(); });
            }
        }

        /// <summary>
        /// Tests that SetDrawList throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetDrawList_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetDrawList(default(ImDrawList)); });
            }
        }

        /// <summary>
        /// Tests that SetGizmoSizeClipSpace throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetGizmoSizeClipSpace_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetGizmoSizeClipSpace(0); });
            }
        }

        /// <summary>
        /// Tests that SetId throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetId_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetId(0); });
            }
        }

        /// <summary>
        /// Tests that SetImGuiContext throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetImGuiContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetImGuiContext(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetOrthographic throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetOrthographic_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetOrthographic(false); });
            }
        }

        /// <summary>
        /// Tests that SetRect throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void SetRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.SetRect(0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that ViewManipulate throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ViewManipulate_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float[] view = default;
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.ViewManipulate(ref view, 0, default(Vector2F), default(Vector2F), 0); });
            }
        }

        /// <summary>
        /// Tests that ShowDemoWindow throws when native library is unavailable
        /// </summary>
         [RequireCImguiSystemFact]
        public void ShowDemoWindow_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImGuizMo.ShowDemoWindow(); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImGuizMoRemainingCoverageTests).Assembly.Location);
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
