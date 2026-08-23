// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12RemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The ImPlotP12 remaining coverage tests class
    /// </summary>
    public class ImPlotP12RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(byte[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(byte[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(short[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(short[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(short[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(short[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(short[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ushort[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ushort[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ushort[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ushort[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ushort[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(int[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(int[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(int[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(int[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(int[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(uint[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(uint[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(long[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(long[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ulong[]), 0, 0, 0, default(ImPlotRange)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(ulong[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram2D_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP12RemainingCoverageTests).Assembly.Location);
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
