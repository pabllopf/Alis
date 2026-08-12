// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP7RemainingCoverageTests.cs
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
    /// The ImPlotP7 remaining coverage tests class
    /// </summary>
    public class ImPlotP7RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(short[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ushort[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(int[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(uint[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(long[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(ulong[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_51_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_52_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_53_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotScatter_54_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", ref xs, ref ys, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP7RemainingCoverageTests).Assembly.Location);
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
