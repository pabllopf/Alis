// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP5Tests.cs
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
    public class ImPlotP5Tests
    {
        /// <summary>
        /// Tests that plot error bars s 8 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 8 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 8 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 8 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 8 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 8 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 16 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 16 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 16 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 16 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 16 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 16 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U16_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 16 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U16_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 16 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U16_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 32 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 32 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 32 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 32 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 32 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 32 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U32_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 32 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U32_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 32 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U32_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 64 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 64 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 64 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars s 64 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 64 default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 64 with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U64_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 64 with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U64_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars u 64 with all should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_U64_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float default should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with scale min should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with scale min max should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with scale min max format should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithScaleMinMaxFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with bounds min should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithBoundsMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with bounds min max should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithBoundsMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap float with all should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Float_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string),
                typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(ImPlotHeatmapFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap double default should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap double with scale min should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_WithScaleMin_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap double with scale min max should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_WithScaleMinMax_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int),
                typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot heatmap double with scale min max format should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_Double_WithScaleMinMaxFormat_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHeatmap", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(int),
                typeof(double), typeof(double), typeof(string)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotErrorBars_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.True(overloads.Length >= 32);
        }

        /// <summary>
        /// Tests that plot error bars all overloads should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_AllOverloads_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.All(overloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot error bars should expose all expected ref types
        /// </summary>
        [Fact]
        public void PlotErrorBars_ShouldExposeAllExpectedRefTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.Contains(overloads, method => HasRefParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasRefParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot heatmap should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.True(overloads.Length >= 11);
        }

        /// <summary>
        /// Tests that plot heatmap all overloads should be void
        /// </summary>
        [Fact]
        public void PlotHeatmap_AllOverloads_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.All(overloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot heatmap should expose float array and double array families
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShouldExposeFloatArrayAndDoubleArrayFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
        }

        /// <summary>
        /// Tests that plot heatmap should expose im plot point and flags parameters
        /// </summary>
        [Fact]
        public void PlotHeatmap_ShouldExposeImPlotPointAndFlagsParameters()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHeatmap");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotPoint)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotHeatmapFlags)));
        }

        /// <summary>
        /// Tests that plot error bars s 8 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys = 2;
            sbyte neg = 3;
            sbyte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        /// Tests that plot error bars s 8 with flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8WithFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys = 2;
            sbyte neg = 3;
            sbyte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        /// Tests that plot error bars s 8 with flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8WithFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys = 2;
            sbyte neg = 3;
            sbyte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot error bars s 8 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys = 2;
            sbyte neg = 3;
            sbyte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0, sizeof(sbyte)));
        }

        /// <summary>
        /// Tests that plot error bars u 8 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8Default_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys = 2;
            byte neg = 3;
            byte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        /// Tests that plot error bars u 8 with flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8WithFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys = 2;
            byte neg = 3;
            byte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        /// Tests that plot error bars u 8 with flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8WithFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys = 2;
            byte neg = 3;
            byte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot error bars u 8 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_U8WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys = 2;
            byte neg = 3;
            byte pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0, sizeof(byte)));
        }

        /// <summary>
        /// Tests that plot error bars s 16 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16Default_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys = 2;
            short neg = 3;
            short pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        /// Tests that plot error bars s 16 with flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16WithFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys = 2;
            short neg = 3;
            short pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        /// Tests that plot error bars s 16 with flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16WithFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys = 2;
            short neg = 3;
            short pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot error bars s 16 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S16WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys = 2;
            short neg = 3;
            short pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0, sizeof(short)));
        }

        /// <summary>
        /// Tests that plot error bars s 32 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32Default_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            int neg = 3;
            int pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        /// Tests that plot error bars s 32 with flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32WithFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            int neg = 3;
            int pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        /// Tests that plot error bars s 32 with flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32WithFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            int neg = 3;
            int pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot error bars s 32 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S32WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys = 2;
            int neg = 3;
            int pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0, sizeof(int)));
        }

        /// <summary>
        /// Tests that plot error bars s 64 default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64Default_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            long neg = 3;
            long pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        /// Tests that plot error bars s 64 with flags with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64WithFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            long neg = 3;
            long pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        /// Tests that plot error bars s 64 with flags offset with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64WithFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            long neg = 3;
            long pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        /// Tests that plot error bars s 64 with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_S64WithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys = 2;
            long neg = 3;
            long pos = 4;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotErrorBars(null, ref xs, ref ys, ref neg, ref pos, 1, ImPlotErrorBarsFlags.None, 0, sizeof(long)));
        }

        /// <summary>
        /// Tests that plot heatmap float default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap float with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap float with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap float with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
        }

        /// <summary>
        /// Tests that plot heatmap float with bounds min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithBoundsMin_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }));
        }

        /// <summary>
        /// Tests that plot heatmap float with bounds min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithBoundsMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }));
        }

        /// <summary>
        /// Tests that plot heatmap float with all with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_FloatWithAll_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f", new ImPlotPoint { X = 0, Y = 0 }, new ImPlotPoint { X = 1, Y = 1 }, ImPlotHeatmapFlags.None));
        }

        /// <summary>
        /// Tests that plot heatmap double default with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1));
        }

        /// <summary>
        /// Tests that plot heatmap double with scale min with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleWithScaleMin_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0));
        }

        /// <summary>
        /// Tests that plot heatmap double with scale min max with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleWithScaleMinMax_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0));
        }

        /// <summary>
        /// Tests that plot heatmap double with format with null label throws argument null exception
        /// </summary>
        [Fact]
        public void PlotHeatmap_DoubleWithFormat_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotHeatmap(null, values, 2, 1, 0.0, 1.0, "%.1f"));
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
        /// Hases the ref parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == elementType);
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
