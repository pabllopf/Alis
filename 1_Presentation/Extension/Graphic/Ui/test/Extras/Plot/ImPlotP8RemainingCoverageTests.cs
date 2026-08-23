// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8RemainingCoverageTests.cs
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
    /// The ImPlotP8 remaining coverage tests class
    /// </summary>
    public class ImPlotP8RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys1 = default; sbyte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys1 = default; sbyte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys1 = default; byte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys1 = default; byte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys1 = default; byte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys1 = default; byte ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys1 = default; short ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys1 = default; short ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys1 = default; short ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys1 = default; short ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys1 = default; ushort ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys1 = default; ushort ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys1 = default; ushort ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys1 = default; ushort ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys1 = default; int ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys1 = default; int ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys1 = default; int ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys1 = default; int ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys1 = default; uint ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys1 = default; uint ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys1 = default; uint ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys1 = default; uint ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys1 = default; long ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys1 = default; long ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys1 = default; long ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys1 = default; long ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys1 = default; ulong ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys1 = default; ulong ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys1 = default; ulong ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShaded throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShaded_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys1 = default; ulong ys2 = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref ys1, ref ys2, 0, (ImPlotShadedFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShadedG throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShadedG_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotShadedG throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotShadedG_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 0, (ImPlotShadedFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(float[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(double[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(sbyte[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0, 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP8RemainingCoverageTests).Assembly.Location);
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
