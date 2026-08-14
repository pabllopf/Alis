// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11RemainingCoverageTests.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The ImPlotP11 remaining coverage tests class
    /// </summary>
    public class ImPlotP11RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ushort[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ushort[]), 0, 0, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ushort[]), 0, 0, 0, 0, "label", 0, (ImPlotPieChartFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(int[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(int[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(int[]), 0, 0, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(int[]), 0, 0, 0, 0, "label", 0, (ImPlotPieChartFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(uint[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(uint[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(uint[]), 0, 0, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(uint[]), 0, 0, 0, 0, "label", 0, (ImPlotPieChartFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(long[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(long[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(long[]), 0, 0, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(long[]), 0, 0, 0, 0, "label", 0, (ImPlotPieChartFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ulong[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ulong[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ulong[]), 0, 0, 0, 0, "label", 0); });
            }
        }

        /// <summary>
        /// Tests that PlotPieChart throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotPieChart(default(string[]), default(ulong[]), 0, 0, 0, 0, "label", 0, (ImPlotPieChartFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(float[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(double[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(sbyte[]), 0, 0, 0, (ImPlotScatterFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0, 0, 0, (ImPlotScatterFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotScatter throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotScatter_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotScatter("label", default(byte[]), 0, 0, 0, (ImPlotScatterFlags)0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP11RemainingCoverageTests).Assembly.Location);
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
