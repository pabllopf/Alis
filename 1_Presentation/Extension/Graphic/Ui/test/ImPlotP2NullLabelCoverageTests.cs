// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2NullLabelCoverageTests.cs
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
using Xunit;
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui;
using Alis.Extension.Graphic.Ui.Extras.Plot;

namespace Alis.Extension.Graphic.Ui.Extras.Plot.Test
{
    /// <summary>
    ///     The im plot p2 null label coverage tests class
    /// </summary>
    public class ImPlotP2NullLabelCoverageTests
    {
        /// <summary>
        ///     tests the get colormap index null name should throw argument null exception
        /// </summary>
        [Fact]
        public void GetColormapIndex_NullName_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.GetColormapIndex((string)null)));
        }

        /// <summary>
        ///     tests the is legend entry hovered null label should throw argument null exception
        /// </summary>
        [Fact]
        public void IsLegendEntryHovered_NullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.IsLegendEntryHovered((string)null)));
        }

        /// <summary>
        ///     tests the plot bar groups float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_0_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_1_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_2_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups float null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_float_3_NullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 1f };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups double null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_0_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups double null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_1_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups double null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_2_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups double null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_double_3_NullLabel_ShouldThrowArgumentNullException()
        {
            double[] values = { 1.0, 1.0 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups sbyte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_0_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups sbyte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_1_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups sbyte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_2_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups sbyte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_sbyte_3_NullLabel_ShouldThrowArgumentNullException()
        {
            sbyte[] values = { (sbyte)1, (sbyte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups byte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_0_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups byte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_1_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups byte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_2_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups byte null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_byte_3_NullLabel_ShouldThrowArgumentNullException()
        {
            byte[] values = { (byte)1, (byte)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups short null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_0_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups short null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_1_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups short null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_2_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups short null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_short_3_NullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = { (short)1, (short)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups ushort null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_0_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups ushort null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_1_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups ushort null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_2_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups ushort null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_ushort_3_NullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = { (ushort)1, (ushort)1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }

        /// <summary>
        ///     tests the plot bar groups int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_0_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1)));
        }

        /// <summary>
        ///     tests the plot bar groups int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_1_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67)));
        }

        /// <summary>
        ///     tests the plot bar groups int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_2_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0)));
        }

        /// <summary>
        ///     tests the plot bar groups int null label should throw argument null exception
        /// </summary>
        [Fact]
        public void PlotBarGroups_int_3_NullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 1 };
            string[] labelIds = { "A", null };
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labelIds, values, 1, 1, 0.67, 0.0, ImPlotBarGroupsFlags.None)));
        }
    }
}