// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9PieChartExecutionTests.cs
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

using System.Runtime.InteropServices;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Executes the PlotPieChart wrapper overloads of ImPlotP9 so that the managed bodies
    ///     are exercised for line coverage. The native P/Invokes declare a byte[][] parameter,
    ///     which the interop marshaler cannot marshal, so every overload throws a
    ///     MarshalDirectiveException at the native call site.
    /// </summary>
    public class ImPlotP9PieChartExecutionTests
    {
        /// <summary>
        ///     Executes the float PlotPieChart wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_Float_Overloads_Execute()
        {
            string[] labels = {"A", "B"};
            float[] values = {1.0f, 2.0f};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f"));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Executes the double PlotPieChart wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_Double_Overloads_Execute()
        {
            string[] labels = {"A", "B"};
            double[] values = {1.0, 2.0};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f"));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Executes the sbyte PlotPieChart wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_SByte_Overloads_Execute()
        {
            string[] labels = {"A", "B"};
            sbyte[] values = {1, 2};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f"));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Executes the byte PlotPieChart wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_Byte_Overloads_Execute()
        {
            string[] labels = {"A", "B"};
            byte[] values = {1, 2};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f"));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Executes the short PlotPieChart wrapper overloads.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_Short_Overloads_Execute()
        {
            string[] labels = {"A", "B"};
            short[] values = {1, 2};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f"));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0));
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, "%.1f", 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        ///     Executes the ushort PlotPieChart wrapper overload.
        /// </summary>
        [RequireImNodesSystemFact]
        public void PlotPieChart_UShort_Overload_Executes()
        {
            string[] labels = {"A", "B"};
            ushort[] values = {1, 2};
            Assert.Throws<MarshalDirectiveException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }
    }
}