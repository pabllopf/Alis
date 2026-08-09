// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP4Tests.cs
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
    /// The im plot tests class
    /// </summary>
    public class ImPlotP4Tests
    {

        /// <summary>
        /// Tests that plot heatmap double bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap double bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap double all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleAll_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap s 8 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap u 8 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16Default_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap s 16 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S16WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16Default_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap u 16 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_U16WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap s 32 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S32Default_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap s 32 with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S32WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 32 with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S32WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap s 32 with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S32WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap s 32 with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_S32WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Gets the public static method using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <param name="parameterTypes">The parameter types</param>
        /// <returns>The method info</returns>
        private static MethodInfo GetPublicStaticMethod(string name, Type[] parameterTypes)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method =>
                {
                    if (method.Name != name)
                    {
                        return false;
                    }
                    ParameterInfo[] parameters = method.GetParameters();
                    if (parameters.Length != parameterTypes.Length)
                    {
                        return false;
                    }
                    for (int i = 0; i < parameters.Length; i++)
                    {
                        if (parameters[i].ParameterType != parameterTypes[i])
                        {
                            return false;
                        }
                    }
                    return true;
                });
        }

        /// <summary>
        /// Gets the public static methods using the specified name
        /// </summary>
        /// <param name="name">The name</param>
        /// <returns>The method info array</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        /// Hases the array parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(p => p.ParameterType.IsArray && p.ParameterType.GetElementType() == elementType);
        }
    }
}
