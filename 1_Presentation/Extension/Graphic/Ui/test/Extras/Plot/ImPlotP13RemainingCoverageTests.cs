// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13RemainingCoverageTests.cs
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
    /// The ImPlotP13 remaining coverage tests class
    /// </summary>
    public class ImPlotP13RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairs throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairs_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairs("label", ref xs, ref ys, 0, (ImPlotStairsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairsG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairsG_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairsG("label", IntPtr.Zero, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStairsG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStairsG_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStairsG("label", IntPtr.Zero, IntPtr.Zero, 0, (ImPlotStairsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(float[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(double[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(sbyte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotStems throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotStems_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotStems("label", default(byte[]), 0, 0, 0, 0, (ImPlotStemsFlags)0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP13RemainingCoverageTests).Assembly.Location);
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
