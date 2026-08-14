// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5RemainingCoverageTests.cs
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
    /// The ImPlotP5 remaining coverage tests class
    /// </summary>
    public class ImPlotP5RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default; sbyte neg = default; sbyte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default; sbyte neg = default; sbyte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default; sbyte neg = default; sbyte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default; byte neg = default; byte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default; byte neg = default; byte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default; byte neg = default; byte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default; byte neg = default; byte pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default; short neg = default; short pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default; short neg = default; short pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default; short neg = default; short pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default; short neg = default; short pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default; ushort neg = default; ushort pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default; ushort neg = default; ushort pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default; ushort neg = default; ushort pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default; ushort neg = default; ushort pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default; int neg = default; int pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default; int neg = default; int pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default; int neg = default; int pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default; int neg = default; int pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default; uint neg = default; uint pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default; uint neg = default; uint pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default; uint neg = default; uint pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default; uint neg = default; uint pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default; long neg = default; long pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default; long neg = default; long pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default; long neg = default; long pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default; long neg = default; long pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default; ulong neg = default; ulong pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default; ulong neg = default; ulong pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default; ulong neg = default; ulong pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotErrorBars_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default; ulong neg = default; ulong pos = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 0, (ImPlotErrorBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHeatmap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotHeatmap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0, 0, "label"); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0, 0, "label", default(ImPlotPoint)); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint)); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(float[]), 0, 0, 0, 0, "label", default(ImPlotPoint), default(ImPlotPoint), (ImPlotHeatmapFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(double[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(double[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(double[]), 0, 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHeatmap("label", default(double[]), 0, 0, 0, 0, "label"); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP5RemainingCoverageTests).Assembly.Location);
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
