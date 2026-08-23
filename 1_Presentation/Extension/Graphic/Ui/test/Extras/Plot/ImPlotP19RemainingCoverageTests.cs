// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19RemainingCoverageTests.cs
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
    /// The ImPlotP19 remaining coverage tests class
    /// </summary>
    public class ImPlotP19RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0, 0, 0, (ImPlotStairsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(byte[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0, 0, 0, (ImPlotStairsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(short[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0, 0, 0, (ImPlotStairsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ushort[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0, 0, 0, (ImPlotStairsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(int[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(uint[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(long[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0, 0, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0, 0, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", default(ulong[]), 0, 0, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_51_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_52_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_53_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStairs_54_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP19RemainingCoverageTests).Assembly.Location);
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
