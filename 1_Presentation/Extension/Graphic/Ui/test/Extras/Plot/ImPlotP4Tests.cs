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
    public class ImPlotP4Tests
    {
        [Fact]
        public void PlotHeatmap_Double_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_Double_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_Double_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S8_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U8_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S16_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_U16_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S32_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S32_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S32_WithFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_S32_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.True(overloads.Length >= 47);
        }

        [Fact]
        public void PlotHeatmap_AllOverloads_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.All(overloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeAllArrayFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeS8Family()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            MethodInfo[] s8Overloads = overloads.Where(m => HasArrayParameter(m, typeof(sbyte))).ToArray();

            Assert.True(s8Overloads.Length >= 7);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeU8Family()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            MethodInfo[] u8Overloads = overloads.Where(m => HasArrayParameter(m, typeof(byte))).ToArray();

            Assert.True(u8Overloads.Length >= 7);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeS16Family()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            MethodInfo[] s16Overloads = overloads.Where(m => HasArrayParameter(m, typeof(short))).ToArray();

            Assert.True(s16Overloads.Length >= 7);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeU16Family()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            MethodInfo[] u16Overloads = overloads.Where(m => HasArrayParameter(m, typeof(ushort))).ToArray();

            Assert.True(u16Overloads.Length >= 7);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeS32Family()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            MethodInfo[] s32Overloads = overloads.Where(m => HasArrayParameter(m, typeof(int))).ToArray();

            Assert.True(s32Overloads.Length >= 5);
        }

        [Fact]
        public void PlotHeatmap_ShouldExposeImPlotPointAndFlagsParameters()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotPoint)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotHeatmapFlags)));
        }

        [Fact]
        public void PlotHeatmap_DoubleBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        [Fact]
        public void PlotHeatmap_DoubleBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        [Fact]
        public void PlotHeatmap_DoubleAll_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        [Fact]
        public void PlotHeatmap_S8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        [Fact]
        public void PlotHeatmap_S8WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        [Fact]
        public void PlotHeatmap_S8WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        [Fact]
        public void PlotHeatmap_S8WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        [Fact]
        public void PlotHeatmap_S8WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        [Fact]
        public void PlotHeatmap_S8WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        [Fact]
        public void PlotHeatmap_S8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        [Fact]
        public void PlotHeatmap_U8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        [Fact]
        public void PlotHeatmap_U8WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        [Fact]
        public void PlotHeatmap_U8WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        [Fact]
        public void PlotHeatmap_U8WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        [Fact]
        public void PlotHeatmap_U8WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        [Fact]
        public void PlotHeatmap_U8WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        [Fact]
        public void PlotHeatmap_U8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        [Fact]
        public void PlotHeatmap_S16Default_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        [Fact]
        public void PlotHeatmap_S16WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        [Fact]
        public void PlotHeatmap_S16WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        [Fact]
        public void PlotHeatmap_S16WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        [Fact]
        public void PlotHeatmap_S16WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        [Fact]
        public void PlotHeatmap_S16WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        [Fact]
        public void PlotHeatmap_S16WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            short[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        [Fact]
        public void PlotHeatmap_U16Default_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        [Fact]
        public void PlotHeatmap_U16WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        [Fact]
        public void PlotHeatmap_U16WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        [Fact]
        public void PlotHeatmap_U16WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        [Fact]
        public void PlotHeatmap_U16WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        [Fact]
        public void PlotHeatmap_U16WithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        [Fact]
        public void PlotHeatmap_U16WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        [Fact]
        public void PlotHeatmap_S32Default_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        [Fact]
        public void PlotHeatmap_S32WithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        [Fact]
        public void PlotHeatmap_S32WithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        [Fact]
        public void PlotHeatmap_S32WithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        [Fact]
        public void PlotHeatmap_S32WithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            int[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

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

        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(p => p.ParameterType.IsArray && p.ParameterType.GetElementType() == elementType);
        }
    }
}
