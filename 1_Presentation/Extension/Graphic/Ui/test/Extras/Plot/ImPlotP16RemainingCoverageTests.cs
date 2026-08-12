// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP16RemainingCoverageTests.cs
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
    /// The ImPlotP16 remaining coverage tests class
    /// </summary>
    public class ImPlotP16RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(uint[]), 0, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(uint[]), 0, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(uint[]), 0, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(long[]), 0, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", default(ulong[]), 0, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_51_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_52_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP16RemainingCoverageTests).Assembly.Location);
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
