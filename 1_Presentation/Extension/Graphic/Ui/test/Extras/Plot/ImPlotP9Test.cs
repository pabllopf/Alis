// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP9Test.cs
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
using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The im plot test class
    /// </summary>
    public class ImPlotP9Test
    {

        /// <summary>
        /// Tests that plot line int 32 base with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int32Base_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        /// <summary>
        /// Tests that plot line int 32 flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int32Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        /// Tests that plot line int 32 flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int32FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot line int 32 flags offset stride with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int32FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(int)));
        }

        /// <summary>
        /// Tests that plot line uint 32 base with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint32Base_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        /// <summary>
        /// Tests that plot line uint 32 flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint32Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        /// Tests that plot line uint 32 flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint32FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot line uint 32 flags offset stride with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint32FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(uint)));
        }

        /// <summary>
        /// Tests that plot line int 64 base with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int64Base_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        /// <summary>
        /// Tests that plot line int 64 flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int64Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        /// Tests that plot line int 64 flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int64FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot line int 64 flags offset stride with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Int64FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(long)));
        }

        /// <summary>
        /// Tests that plot line uint 64 base with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint64Base_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        /// <summary>
        /// Tests that plot line uint 64 flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint64Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        /// Tests that plot line uint 64 flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint64FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot line uint 64 flags offset stride with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLine_Uint64FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(ulong)));
        }

        /// <summary>
        /// Tests that plot line g base with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLineG_Base_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLineG(null, IntPtr.Zero, IntPtr.Zero, 1));
        }

        /// <summary>
        /// Tests that plot line g flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotLineG_Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLineG(null, IntPtr.Zero, IntPtr.Zero, 1, ImPlotLineFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart float with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Float_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot pie chart float label fmt with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        /// <summary>
        /// Tests that plot pie chart float angle 0 with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        /// <summary>
        /// Tests that plot pie chart float flags with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_FloatFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart double with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Double_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot pie chart double label fmt with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoubleLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        /// <summary>
        /// Tests that plot pie chart double angle 0 with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoubleAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        /// <summary>
        /// Tests that plot pie chart double flags with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_DoubleFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart s byte with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_SByte_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot pie chart s byte label fmt with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_SByteLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        /// <summary>
        /// Tests that plot pie chart s byte angle 0 with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_SByteAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        /// <summary>
        /// Tests that plot pie chart s byte flags with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_SByteFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart byte with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Byte_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot pie chart byte label fmt with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ByteLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        /// <summary>
        /// Tests that plot pie chart byte angle 0 with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ByteAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        /// <summary>
        /// Tests that plot pie chart byte flags with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ByteFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart short with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_Short_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot pie chart short label fmt with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ShortLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        /// <summary>
        /// Tests that plot pie chart short angle 0 with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ShortAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        /// <summary>
        /// Tests that plot pie chart short flags with null label fmt throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_ShortFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        /// <summary>
        /// Tests that plot pie chart u short with null label item throws argument null exception
        /// </summary>
        [Fact]
        public void PlotPieChart_UShort_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        /// <summary>
        /// Gets the public static methods using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info array</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name) =>
            typeof(ImPlot).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();

        /// <summary>
        /// Hases the by ref parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasByRefParameter(MethodInfo method, Type elementType) =>
            method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsByRef && parameter.ParameterType.GetElementType() == elementType);

        /// <summary>
        /// Hases the array parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType) =>
            method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
    }
}
