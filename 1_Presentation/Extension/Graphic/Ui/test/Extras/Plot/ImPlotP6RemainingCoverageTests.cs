// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6RemainingCoverageTests.cs
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
    /// The ImPlotP6 remaining coverage tests class
    /// </summary>
    public class ImPlotP6RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(byte[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(short[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(short[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(short[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(short[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ushort[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ushort[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ushort[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ushort[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(int[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(int[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(int[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(int[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(uint[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(uint[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(uint[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(uint[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(long[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(long[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(long[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(long[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ulong[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ulong[]), 0, (ImPlotInfLinesFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ulong[]), 0, (ImPlotInfLinesFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(ulong[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(float[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(double[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(sbyte[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(byte[]), 0, 0, 0, (ImPlotLineFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0, 0, 0, (ImPlotLineFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotLine throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotLine_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotLine("label", default(short[]), 0, 0, 0, (ImPlotLineFlags)0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP6RemainingCoverageTests).Assembly.Location);
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
