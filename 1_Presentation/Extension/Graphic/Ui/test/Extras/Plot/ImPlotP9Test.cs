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
    public class ImPlotP9Test
    {
        [Fact]
        public void PlotLine_ShouldExposeAll16Overloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            Assert.True(overloads.Length >= 16);
        }

        [Fact]
        public void PlotLine_ShouldExposeByRefIntOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            MethodInfo[] intOverloads = overloads.Where(m => HasByRefParameter(m, typeof(int))).ToArray();
            Assert.True(intOverloads.Length >= 4);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotLine_ShouldExposeByRefUintOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(uint)));
        }

        [Fact]
        public void PlotLine_ShouldExposeByRefLongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(long)));
        }

        [Fact]
        public void PlotLine_ShouldExposeByRefUlongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(ulong)));
        }

        [Fact]
        public void PlotLine_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotLineFlags)));
            Assert.Contains(overloads, m => m.GetParameters().Length >= 6 && m.GetParameters()[5].ParameterType == typeof(int));
            Assert.Contains(overloads, m => m.GetParameters().Length >= 7 && m.GetParameters()[6].ParameterType == typeof(int));
        }

        [Fact]
        public void PlotLineG_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLineG");
            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, m => m.GetParameters().Length == 4);
            Assert.Contains(overloads, m => m.GetParameters().Length == 5 && m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotLineFlags)));
        }

        [Fact]
        public void PlotPieChart_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");
            Assert.True(overloads.Length >= 21);
        }

        [Fact]
        public void PlotPieChart_ShouldExposeAllExpectedValueArrayFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(float)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(double)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(sbyte)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(byte)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(short)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(ushort)));
        }

        [Fact]
        public void PlotPieChart_ShouldExposeLabelFormatAngleAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotPieChartFlags)));
        }

        [Fact]
        public void PlotLine_Int32Base_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        [Fact]
        public void PlotLine_Int32Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        [Fact]
        public void PlotLine_Int32FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        [Fact]
        public void PlotLine_Int32FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1; int ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(int)));
        }

        [Fact]
        public void PlotLine_Uint32Base_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        [Fact]
        public void PlotLine_Uint32Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        [Fact]
        public void PlotLine_Uint32FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        [Fact]
        public void PlotLine_Uint32FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1; uint ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(uint)));
        }

        [Fact]
        public void PlotLine_Int64Base_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        [Fact]
        public void PlotLine_Int64Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        [Fact]
        public void PlotLine_Int64FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        [Fact]
        public void PlotLine_Int64FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1; long ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(long)));
        }

        [Fact]
        public void PlotLine_Uint64Base_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1));
        }

        [Fact]
        public void PlotLine_Uint64Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None));
        }

        [Fact]
        public void PlotLine_Uint64FlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0));
        }

        [Fact]
        public void PlotLine_Uint64FlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1; ulong ys = 2;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(ulong)));
        }

        [Fact]
        public void PlotLineG_Base_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLineG(null, IntPtr.Zero, IntPtr.Zero, 1));
        }

        [Fact]
        public void PlotLineG_Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotLineG(null, IntPtr.Zero, IntPtr.Zero, 1, ImPlotLineFlags.None));
        }

        [Fact]
        public void PlotPieChart_Float_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        [Fact]
        public void PlotPieChart_FloatLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        [Fact]
        public void PlotPieChart_FloatAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        [Fact]
        public void PlotPieChart_FloatFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        [Fact]
        public void PlotPieChart_Double_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        [Fact]
        public void PlotPieChart_DoubleLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        [Fact]
        public void PlotPieChart_DoubleAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        [Fact]
        public void PlotPieChart_DoubleFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        [Fact]
        public void PlotPieChart_SByte_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        [Fact]
        public void PlotPieChart_SByteLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        [Fact]
        public void PlotPieChart_SByteAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        [Fact]
        public void PlotPieChart_SByteFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        [Fact]
        public void PlotPieChart_Byte_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        [Fact]
        public void PlotPieChart_ByteLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        [Fact]
        public void PlotPieChart_ByteAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        [Fact]
        public void PlotPieChart_ByteFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        [Fact]
        public void PlotPieChart_Short_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        [Fact]
        public void PlotPieChart_ShortLabelFmt_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null));
        }

        [Fact]
        public void PlotPieChart_ShortAngle0_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0));
        }

        [Fact]
        public void PlotPieChart_ShortFlags_WithNullLabelFmt_ThrowsArgumentNullException()
        {
            string[] labels = { "A", "B" };
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0, null, 90.0, ImPlotPieChartFlags.None));
        }

        [Fact]
        public void PlotPieChart_UShort_WithNullLabelItem_ThrowsArgumentNullException()
        {
            string[] labels = { "A", null };
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotPieChart(labels, values, 2, 0.0, 0.0, 1.0));
        }

        private static MethodInfo[] GetPublicStaticMethods(string name) =>
            typeof(ImPlot).GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();

        private static bool HasByRefParameter(MethodInfo method, Type elementType) =>
            method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsByRef && parameter.ParameterType.GetElementType() == elementType);

        private static bool HasArrayParameter(MethodInfo method, Type elementType) =>
            method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
    }
}
