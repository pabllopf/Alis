// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP21RemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Core.Aspect.Math.Vector;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The ImPlotP21 remaining coverage tests class
    /// </summary>
    public class ImPlotP21RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys, 0, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys1 = default; float ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys1 = default; float ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys1 = default; float ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys1 = default; float ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys1 = default; double ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys1 = default; double ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys1 = default; double ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys1 = default; double ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys1 = default; sbyte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotShaded_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys1 = default; sbyte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP21RemainingCoverageTests).Assembly.Location);
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
