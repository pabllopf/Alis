// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP17RemainingCoverageTests.cs
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
    /// The ImPlotP17 remaining coverage tests class
    /// </summary>
    public class ImPlotP17RemainingCoverageTests
    {
        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBars_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBars("label", ref xs, ref ys, 0, 0, (ImPlotBarsFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarsG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBarsG_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarsG("label", IntPtr.Zero, IntPtr.Zero, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotBarsG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotBarsG_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotBarsG("label", IntPtr.Zero, IntPtr.Zero, 0, 0, (ImPlotBarsFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_3_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_4_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_5_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_6_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_7_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_8_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 double xs = default; double ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_9_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_10_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_11_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_12_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 sbyte xs = default; sbyte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_13_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_14_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_15_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_16_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 byte xs = default; byte ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_17_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_18_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_19_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_20_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 short xs = default; short ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_21_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_22_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_23_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_24_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ushort xs = default; ushort ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_25_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_26_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_27_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_28_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 int xs = default; int ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_29_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_30_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_31_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_32_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 uint xs = default; uint ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_33_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_34_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_35_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_36_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 long xs = default; long ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_37_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_38_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_39_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigital throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigital_40_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 ulong xs = default; ulong ys = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigital("label", ref xs, ref ys, 0, (ImPlotDigitalFlags)0, 0, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigitalG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigitalG_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigitalG("label", IntPtr.Zero, IntPtr.Zero, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotDigitalG throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDigitalG_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDigitalG("label", IntPtr.Zero, IntPtr.Zero, 0, (ImPlotDigitalFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotDummy throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDummy_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDummy("label"); });
            }
        }

        /// <summary>
        /// Tests that PlotDummy throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotDummy_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotDummy("label", (ImPlotDummyFlags)0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotErrorBars_1_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default; float err = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 0); });
            }
        }

        /// <summary>
        /// Tests that PlotErrorBars throws when native library is unavailable
        /// </summary>
        [Fact]
        public void PlotErrorBars_2_WithoutNativeLibrary_Throws()
        {
            if (!CanLoadCImguiLibrary())
            {
                 float xs = default; float ys = default; float err = default;
                Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 0, (ImPlotErrorBarsFlags)0); });
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

            string assemblyDir = System.IO.Path.GetDirectoryName(typeof(ImPlotP17RemainingCoverageTests).Assembly.Location);
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
