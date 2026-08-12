// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP18RemainingCoverageTests.cs
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
    /// The ImPlotP18 remaining coverage tests class
    /// </summary>
    public class ImPlotP18RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect)); });
            }
        }

        /// <summary>
        /// Tests that PlotHistogram2D throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotHistogram2D_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotHistogram2D("label", ref xs, ref ys, 0, 0, 0, default(ImPlotRect), (ImPlotHistogramFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotImage_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotImage("label", IntPtr.Zero, default(ImPlotPoint), default(ImPlotPoint)); });
            }
        }

        /// <summary>
        /// Tests that PlotImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotImage_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotImage("label", IntPtr.Zero, default(ImPlotPoint), default(ImPlotPoint), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PlotImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotImage_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotImage("label", IntPtr.Zero, default(ImPlotPoint), default(ImPlotPoint), default(Vector2F), default(Vector2F)); });
            }
        }

        /// <summary>
        /// Tests that PlotImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotImage_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotImage("label", IntPtr.Zero, default(ImPlotPoint), default(ImPlotPoint), default(Vector2F), default(Vector2F), default(Vector4F)); });
            }
        }

        /// <summary>
        /// Tests that PlotImage throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotImage_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotImage("label", IntPtr.Zero, default(ImPlotPoint), default(ImPlotPoint), default(Vector2F), default(Vector2F), default(Vector4F), (ImPlotImageFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotInfLines throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotInfLines_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(float[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(float[]), 0, (ImPlotInfLinesFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(float[]), 0, (ImPlotInfLinesFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(float[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(double[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(double[]), 0, (ImPlotInfLinesFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(double[]), 0, (ImPlotInfLinesFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(double[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(sbyte[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(sbyte[]), 0, (ImPlotInfLinesFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(sbyte[]), 0, (ImPlotInfLinesFlags)0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(sbyte[]), 0, (ImPlotInfLinesFlags)0, 0, 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(byte[]), 0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(byte[]), 0, (ImPlotInfLinesFlags)0); });
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
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotInfLines("label", default(byte[]), 0, (ImPlotInfLinesFlags)0, 0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP18RemainingCoverageTests).Assembly.Location);
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
