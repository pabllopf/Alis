// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP20RemainingCoverageTests.cs
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
    /// The ImPlotP20 remaining coverage tests class
    /// </summary>
    public class ImPlotP20RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(int[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(int[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint), (ImPlotHeatmapFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0, 0, "label", default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(uint[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint), (ImPlotHeatmapFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0, 0, "label", default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(long[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint), (ImPlotHeatmapFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0, 0, "label"); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0, 0, "label", default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(ulong[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint), (ImPlotHeatmapFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHistogram_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(float[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(float[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(float[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(float[]), 0, 0, 0, default(ImPlotRange)); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(float[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(double[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(double[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(double[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(double[]), 0, 0, 0, default(ImPlotRange)); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(double[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(sbyte[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(sbyte[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(sbyte[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(sbyte[]), 0, 0, 0, default(ImPlotRange)); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(sbyte[]), 0, 0, 0, default(ImPlotRange), (ImPlotHistogramFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(byte[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(byte[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram("label", default(byte[]), 0, 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP20RemainingCoverageTests).Assembly.Location);
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
