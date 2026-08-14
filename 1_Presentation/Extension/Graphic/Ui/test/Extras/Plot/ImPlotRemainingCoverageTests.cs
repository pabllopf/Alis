// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRemainingCoverageTests.cs
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
    /// The ImPlot remaining coverage tests class
    /// </summary>
    public class ImPlotRemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotText throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotText_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotText("label", 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotText throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotText_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotText("label", 0, 0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PlotText throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotText_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotText("label", 0, 0, default(Vector2F), (ImPlotTextFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(default(ImPlotPoint), (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(default(ImPlotPoint), (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(0, 0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PlotToPixels throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotToPixels_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotToPixels(0, 0, (ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that PopColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopColormap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopColormap(); });
            }
        }

        /// <summary>
        /// Tests that PopColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopColormap_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopColormap(0); });
            }
        }

        /// <summary>
        /// Tests that PopPlotClipRect throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopPlotClipRect_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopPlotClipRect(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopStyleColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopStyleColor(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopStyleColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopStyleColor(0); });
            }
        }

        /// <summary>
        /// Tests that PopStyleVar throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopStyleVar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopStyleVar(); });
            }
        }

        /// <summary>
        /// Tests that PopStyleVar throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PopStyleVar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PopStyleVar(0); });
            }
        }

        /// <summary>
        /// Tests that PushColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushColormap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushColormap((ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that PushColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushColormap_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushColormap("label"); });
            }
        }

        /// <summary>
        /// Tests that PushPlotClipRect throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushPlotClipRect_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushPlotClipRect(); });
            }
        }

        /// <summary>
        /// Tests that PushPlotClipRect throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushPlotClipRect_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushPlotClipRect(0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushStyleColor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushStyleColor((ImPlotCol)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleColor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushStyleColor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushStyleColor((ImPlotCol)0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that PushStyleVar throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushStyleVar_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushStyleVar((ImPlotStyleVar)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleVar throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushStyleVar_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushStyleVar((ImPlotStyleVar)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PushStyleVar throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PushStyleVar_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PushStyleVar((ImPlotStyleVar)0, default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that SampleColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SampleColormap_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SampleColormap(0); });
            }
        }

        /// <summary>
        /// Tests that SampleColormap throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SampleColormap_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SampleColormap(0, (ImPlotColormap)0); });
            }
        }

        /// <summary>
        /// Tests that SetAxes throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetAxes_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetAxes((ImAxis)0, (ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that SetAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetAxis_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetAxis((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that SetCurrentContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetCurrentContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetCurrentContext(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetImGuiContext throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetImGuiContext_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetImGuiContext(IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxesLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxesLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxesLimits(0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxesLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxesLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxesLimits(0, 0, 0, 0, (ImPlotCond)0); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxesToFit throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxesToFit_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxesToFit(); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxisLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxisLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxisLimits((ImAxis)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxisLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxisLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxisLimits((ImAxis)0, 0, 0, (ImPlotCond)0); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxisLinks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxisLinks_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double linkMin = default; double linkMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxisLinks((ImAxis)0, ref linkMin, ref linkMax); });
            }
        }

        /// <summary>
        /// Tests that SetNextAxisToFit throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextAxisToFit_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextAxisToFit((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that SetNextErrorBarStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextErrorBarStyle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextErrorBarStyle(); });
            }
        }

        /// <summary>
        /// Tests that SetNextErrorBarStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextErrorBarStyle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextErrorBarStyle(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextErrorBarStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextErrorBarStyle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextErrorBarStyle(default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextErrorBarStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextErrorBarStyle_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextErrorBarStyle(default(Vector4F), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextFillStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextFillStyle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextFillStyle(); });
            }
        }

        /// <summary>
        /// Tests that SetNextFillStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextFillStyle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextFillStyle(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextFillStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextFillStyle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextFillStyle(default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextLineStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextLineStyle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextLineStyle(); });
            }
        }

        /// <summary>
        /// Tests that SetNextLineStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextLineStyle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextLineStyle(default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextLineStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextLineStyle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextLineStyle(default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle(); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle((ImPlotMarker)0); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle((ImPlotMarker)0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle((ImPlotMarker)0, 0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle((ImPlotMarker)0, 0, default(Vector4F), 0); });
            }
        }

        /// <summary>
        /// Tests that SetNextMarkerStyle throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetNextMarkerStyle_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetNextMarkerStyle((ImPlotMarker)0, 0, default(Vector4F), 0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that SetupAxes throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxes_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxes("label", "label"); });
            }
        }

        /// <summary>
        /// Tests that SetupAxes throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxes_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxes("label", "label", (ImPlotAxisFlags)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxes throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxes_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxes("label", "label", (ImPlotAxisFlags)0, (ImPlotAxisFlags)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxesLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxesLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxesLimits(0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxesLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxesLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxesLimits(0, 0, 0, 0, (ImPlotCond)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxis_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxis((ImAxis)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxis_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxis((ImAxis)0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SetupAxis throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxis_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxis((ImAxis)0, "label", (ImPlotAxisFlags)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisFormat throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisFormat_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisFormat((ImAxis)0, "label"); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisFormat throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisFormat_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisFormat((ImAxis)0, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisFormat throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisFormat_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisFormat((ImAxis)0, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisLimits_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisLimits((ImAxis)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisLimits throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisLimits_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisLimits((ImAxis)0, 0, 0, (ImPlotCond)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisLimitsConstraints throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisLimitsConstraints_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisLimitsConstraints((ImAxis)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisLinks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisLinks_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double linkMin = default; double linkMax = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisLinks((ImAxis)0, ref linkMin, ref linkMax); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisScale_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisScale((ImAxis)0, (ImPlotScale)0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisScale_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisScale((ImAxis)0, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisScale throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisScale_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisScale((ImAxis)0, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, default(double[]), 0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, default(double[]), 0, default(string[])); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, default(double[]), 0, default(string[]), false); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, 0, 0, 0, default(string[])); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisTicks throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisTicks_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisTicks((ImAxis)0, 0, 0, 0, default(string[]), false); });
            }
        }

        /// <summary>
        /// Tests that SetupAxisZoomConstraints throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupAxisZoomConstraints_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupAxisZoomConstraints((ImAxis)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that SetupFinish throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupFinish_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupFinish(); });
            }
        }

        /// <summary>
        /// Tests that SetupLegend throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupLegend_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupLegend((ImPlotLocation)0); });
            }
        }

        /// <summary>
        /// Tests that SetupLegend throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupLegend_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupLegend((ImPlotLocation)0, (ImPlotLegendFlags)0); });
            }
        }

        /// <summary>
        /// Tests that SetupMouseText throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupMouseText_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupMouseText((ImPlotLocation)0); });
            }
        }

        /// <summary>
        /// Tests that SetupMouseText throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void SetupMouseText_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.SetupMouseText((ImPlotLocation)0, (ImPlotMouseTextFlags)0); });
            }
        }

        /// <summary>
        /// Tests that ShowColormapSelector throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowColormapSelector_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowColormapSelector("label"); });
            }
        }

        /// <summary>
        /// Tests that ShowDemoWindow throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowDemoWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowDemoWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowDemoWindow throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowDemoWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pOpen = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowDemoWindow(ref pOpen); });
            }
        }

        /// <summary>
        /// Tests that ShowInputMapSelector throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowInputMapSelector_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowInputMapSelector("label"); });
            }
        }

        /// <summary>
        /// Tests that ShowMetricsWindow throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowMetricsWindow_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowMetricsWindow(); });
            }
        }

        /// <summary>
        /// Tests that ShowMetricsWindow throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowMetricsWindow_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 bool pPopen = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowMetricsWindow(ref pPopen); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleEditor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowStyleEditor_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowStyleEditor(); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleEditor throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowStyleEditor_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowStyleEditor(default(ImPlotStyle)); });
            }
        }

        /// <summary>
        /// Tests that ShowStyleSelector throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowStyleSelector_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowStyleSelector("label"); });
            }
        }

        /// <summary>
        /// Tests that ShowUserGuide throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void ShowUserGuide_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.ShowUserGuide(); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsAuto throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsAuto_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsAuto(); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsAuto throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsAuto_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsAuto(default(ImPlotStyle)); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsClassic throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsClassic_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsClassic(); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsClassic throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsClassic_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsClassic(default(ImPlotStyle)); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsDark throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsDark_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsDark(); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsDark throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsDark_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsDark(default(ImPlotStyle)); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsLight throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsLight_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsLight(); });
            }
        }

        /// <summary>
        /// Tests that StyleColorsLight throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void StyleColorsLight_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.StyleColorsLight(default(ImPlotStyle)); });
            }
        }

        /// <summary>
        /// Tests that TagX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagX_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagX(0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that TagX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagX_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagX(0, default(Vector4F), false); });
            }
        }

        /// <summary>
        /// Tests that TagX throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagX_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagX(0, default(Vector4F), "label"); });
            }
        }

        /// <summary>
        /// Tests that TagY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagY_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagY(0, default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that TagY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagY_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagY(0, default(Vector4F), false); });
            }
        }

        /// <summary>
        /// Tests that TagY throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void TagY_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.TagY(0, default(Vector4F), "label"); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotRemainingCoverageTests).Assembly.Location);
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
