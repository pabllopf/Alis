// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP22RemainingCoverageTests.cs
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
    /// The ImPlotP22 remaining coverage tests class
    /// </summary>
    public class ImPlotP22RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ushort[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(int[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(uint[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(long[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(ulong[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_51_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_52_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_53_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_54_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_55_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", ref xs, ref ys, 0, (ImPlotLineFlags)0, 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP22RemainingCoverageTests).Assembly.Location);
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
