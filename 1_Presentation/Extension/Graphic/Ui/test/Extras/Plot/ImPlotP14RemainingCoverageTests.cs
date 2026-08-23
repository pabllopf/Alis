// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14RemainingCoverageTests.cs
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
    /// The ImPlotP14 remaining coverage tests class
    /// </summary>
    public class ImPlotP14RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(short[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ushort[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(int[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(uint[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(long[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_41_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_42_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_43_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_44_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(ulong[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_45_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_46_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_47_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_48_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_49_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_50_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_51_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_52_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_53_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_54_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_55_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_56_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_57_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_58_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_59_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_60_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_61_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_62_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_63_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_64_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_65_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_66_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_67_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_68_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_69_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotStems_70_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", ref xs, ref ys, 0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP14RemainingCoverageTests).Assembly.Location);
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
