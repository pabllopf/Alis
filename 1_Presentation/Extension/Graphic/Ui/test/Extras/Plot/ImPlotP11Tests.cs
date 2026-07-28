// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP11Tests.cs
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
    /// The im plot 11 tests class
    /// </summary>
    public class ImPlotP11Tests
    {
        /// <summary>
        /// Tests that plot pie chart should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotPieChart_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotPieChart");

            Assert.True(overloads.Length >= 19);
        }

        /// <summary>
        /// Tests that plot pie chart u 16 default should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 16 with angle 0 should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U16_WithAngle0_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 16 with flags should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U16_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double), typeof(ImPlotPieChartFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 32 default should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 32 with label fmt should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S32_WithLabelFmt_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 32 with angle 0 should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S32_WithAngle0_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 32 with flags should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S32_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double), typeof(ImPlotPieChartFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 32 default should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 32 with label fmt should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U32_WithLabelFmt_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 32 with angle 0 should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U32_WithAngle0_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 32 with flags should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U32_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double), typeof(ImPlotPieChartFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 64 default should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 64 with label fmt should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S64_WithLabelFmt_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 64 with angle 0 should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S64_WithAngle0_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart s 64 with flags should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_S64_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double), typeof(ImPlotPieChartFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 64 default should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 64 with label fmt should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U64_WithLabelFmt_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 64 with angle 0 should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U64_WithAngle0_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot pie chart u 64 with flags should be void
        /// </summary>
        [Fact]
        public void PlotPieChart_U64_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotPieChart", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(string), typeof(double), typeof(ImPlotPieChartFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            Assert.True(overloads.Length >= 23);
        }

        /// <summary>
        /// Tests that plot scatter float default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter float with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter float with xscale and xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_WithXscaleAndXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter float with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter float with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter float with full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Float_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double with xscale and xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_WithXscaleAndXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter double with full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_Double_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 with xscale and xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_WithXscaleAndXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 8 with full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S8_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 8 default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(byte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 8 with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 8 with xscale and xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8_WithXscaleAndXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 8 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotScatterFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
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
    }
}
