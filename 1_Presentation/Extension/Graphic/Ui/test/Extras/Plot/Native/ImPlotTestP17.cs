// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP17.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP17
    {
        /// <summary>
        ///     Tests that plot bars throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBars_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 1, 1.0, ImPlotBarsFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot bars throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotBars_ThrowsDllNotFoundException_v2()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot bars throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotBars_ThrowsDllNotFoundException_v3()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 1, 1.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot bars throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotBars_ThrowsDllNotFoundException_v4()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBars("label", ref xs, ref ys, 1, 1.0, ImPlotBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot bars g throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotBarsG_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBarsG("label", IntPtr.Zero, IntPtr.Zero, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot bars g throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotBarsG_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotBarsG("label", IntPtr.Zero, IntPtr.Zero, 1, 1.0, ImPlotBarsFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException()
        {
            float xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v2()
        {
            float xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v3()
        {
            float xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 4
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v4()
        {
            float xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 5
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v5()
        {
            double xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 6
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v6()
        {
            double xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 7
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v7()
        {
            double xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 8
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v8()
        {
            double xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 9
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v9()
        {
            sbyte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 10
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v10()
        {
            sbyte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 11
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v11()
        {
            sbyte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 12
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v12()
        {
            sbyte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 13
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v13()
        {
            byte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 14
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v14()
        {
            byte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 15
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v15()
        {
            byte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 16
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v16()
        {
            byte xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 17
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v17()
        {
            short xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 18
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v18()
        {
            short xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 19
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v19()
        {
            short xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 20
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v20()
        {
            short xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 21
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v21()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 22
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v22()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 23
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v23()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 24
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v24()
        {
            ushort xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 25
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v25()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 26
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v26()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 27
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v27()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 28
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v28()
        {
            int xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 29
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v29()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 30
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v30()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 31
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v31()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 32
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v32()
        {
            uint xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 33
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v33()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 34
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v34()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 35
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v35()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 36
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v36()
        {
            long xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 37
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v37()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 38
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v38()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 39
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v39()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot digital throws dll not found exception v 40
        /// </summary>
        [Fact]
        public void PlotDigital_ThrowsDllNotFoundException_v40()
        {
            ulong xs = 0, ys = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigital("label", ref xs, ref ys, 1, ImPlotDigitalFlags.None, 0, 0));
        }

        /// <summary>
        ///     Tests that plot digital g throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotDigitalG_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigitalG("label", IntPtr.Zero, IntPtr.Zero, 1));
        }

        /// <summary>
        ///     Tests that plot digital g throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotDigitalG_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDigitalG("label", IntPtr.Zero, IntPtr.Zero, 1, ImPlotDigitalFlags.None));
        }

        /// <summary>
        ///     Tests that plot dummy throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotDummy_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDummy("label"));
        }

        /// <summary>
        ///     Tests that plot dummy throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotDummy_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotDummy("label", ImPlotDummyFlags.None));
        }

        /// <summary>
        ///     Tests that plot error bars throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ThrowsDllNotFoundException()
        {
            float xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that plot error bars throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotErrorBars_ThrowsDllNotFoundException_v2()
        {
            float xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1, ImPlotErrorBarsFlags.None));
        }
    }
}