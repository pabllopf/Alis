// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP11.cs
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
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP11
    {
        /// <summary>
        ///     Tests that plot pie chart u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_UShort_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ushort[] {1}, 1, 0.0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot pie chart u short throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotPieChart_UShort_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ushort[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0));
        }

        /// <summary>
        ///     Tests that plot pie chart u short throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotPieChart_UShort_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ushort[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Tests that plot pie chart int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new[] {1}, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart int throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotPieChart_Int_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new[] {1}, 1, 0.0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot pie chart int throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotPieChart_Int_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0));
        }

        /// <summary>
        ///     Tests that plot pie chart u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_UInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new uint[] {1}, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart u int throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotPieChart_UInt_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new uint[] {1}, 1, 0.0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot pie chart u int throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotPieChart_UInt_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new uint[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0));
        }

        /// <summary>
        ///     Tests that plot pie chart long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Long_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new long[] {1}, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart long throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotPieChart_Long_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new long[] {1}, 1, 0.0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot pie chart long throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotPieChart_Long_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new long[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0));
        }

        /// <summary>
        ///     Tests that plot pie chart u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ULong_ThrowsDllNotFoundException()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ulong[] {1}, 1, 0.0, 0.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot pie chart u long throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotPieChart_ULong_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ulong[] {1}, 1, 0.0, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        ///     Tests that plot pie chart u long throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotPieChart_ULong_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(new[] {"A"}, new ulong[] {1}, 1, 0.0, 0.0, 1.0, "%.1f", 90.0));
        }

        /// <summary>
        ///     Tests that plot scatter float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_Float_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0f}, 1));
        }

        /// <summary>
        ///     Tests that plot scatter float throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_Float_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0f}, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter float throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_Float_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0f}, 1, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0}, 1));
        }

        /// <summary>
        ///     Tests that plot scatter double throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_Double_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0}, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter double throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_Double_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new[] {1.0}, 1, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_SByte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new sbyte[] {1}, 1));
        }

        /// <summary>
        ///     Tests that plot scatter s byte throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_SByte_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new sbyte[] {1}, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter s byte throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_SByte_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new sbyte[] {1}, 1, 1.0, 0.0));
        }

        /// <summary>
        ///     Tests that plot scatter byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotScatter_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new byte[] {1}, 1));
        }

        /// <summary>
        ///     Tests that plot scatter byte throws dll not found exception v 2
        /// </summary>
        [Fact]
        public void PlotScatter_Byte_ThrowsDllNotFoundException_v2()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new byte[] {1}, 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot scatter byte throws dll not found exception v 3
        /// </summary>
        [Fact]
        public void PlotScatter_Byte_ThrowsDllNotFoundException_v3()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotScatter("A", new byte[] {1}, 1, 1.0, 0.0));
        }
    }
}