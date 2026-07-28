// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP10Test.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The im plot 10 test class
    /// </summary>
    public class ImPlotP10Test
    {
        /// <summary>
        /// Tests that plot scatter should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            Assert.True(overloads.Length >= 23);
        }

        /// <summary>
        /// Tests that plot scatter should expose all expected by ref numeric families
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeAllExpectedByRefNumericFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot scatter should expose flags offset and stride overloads
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotScatterFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 6) && (method.GetParameters()[5].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 7) && (method.GetParameters()[6].ParameterType == typeof(int)));
        }

        /// <summary>
        /// Tests that plot scatter should expose by ref short overloads
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeByRefShortOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            MethodInfo[] shortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(short))).ToArray();

            Assert.True(shortOverloads.Length >= 3);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot scatter should expose by ref int overloads
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExposeByRefIntOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatter");

            MethodInfo[] intOverloads = overloads.Where(method => HasByRefParameter(method, typeof(int))).ToArray();

            Assert.True(intOverloads.Length >= 4);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot scatter g should expose expected overloads
        /// </summary>
        [Fact]
        public void PlotScatterG_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotScatterG");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 5) && method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotScatterFlags)));
        }

        /// <summary>
        /// Tests that plot shaded should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            Assert.True(overloads.Length >= 80);
        }

        /// <summary>
        /// Tests that plot shaded should expose all expected array types
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot shaded should expose by ref float and double overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeByRefFloatAndDoubleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(double)));
        }

        /// <summary>
        /// Tests that plot shaded should expose flags offset and stride overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotShadedFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 8) && (method.GetParameters()[7].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 9) && (method.GetParameters()[8].ParameterType == typeof(int)));
        }

        /// <summary>
        /// Tests that plot shaded should expose yref xscale xstart overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeYrefXscaleXstartOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => (parameter.Name == "yref" || parameter.ParameterType == typeof(double))));
        }

        /// <summary>
        /// Tests that plot shaded should expose seven float overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeSevenFloatOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            MethodInfo[] floatOverloads = overloads.Where(method => HasArrayParameter(method, typeof(float))).ToArray();

            Assert.True(floatOverloads.Length >= 7);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 9);
        }

        /// <summary>
        /// Tests that plot shaded should expose five by ref float overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeFiveByRefFloatOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            MethodInfo[] refFloatOverloads = overloads.Where(method => HasByRefParameter(method, typeof(float))).ToArray();

            Assert.True(refFloatOverloads.Length >= 5);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot shaded should expose five by ref double overloads
        /// </summary>
        [Fact]
        public void PlotShaded_ShouldExposeFiveByRefDoubleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotShaded");

            MethodInfo[] refDoubleOverloads = overloads.Where(method => HasByRefParameter(method, typeof(double))).ToArray();

            Assert.True(refDoubleOverloads.Length >= 5);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Plots the scatter with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotScatter_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 1;
            short ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatter(null, ref xs, ref ys, 1, ImPlotScatterFlags.None)));
        }

        /// <summary>
        /// Plots the scatter g with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotScatterG_WithNullLabel_ShouldThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotScatterG(null, IntPtr.Zero, IntPtr.Zero, 1)));
        }

        /// <summary>
        /// Plots the shaded array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotShaded_ArrayWithNullLabel_ShouldThrowArgumentNullException()
        {
            float[] values = { 1f, 2f };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, values, 2)));
        }

        /// <summary>
        /// Plots the shaded ref float with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotShaded_RefFloatWithNullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 1f;
            float ys = 2f;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the shaded ref double with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotShaded_RefDoubleWithNullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 1.0;
            double ys = 2.0;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotShaded(null, ref xs, ref ys, 1)));
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
        /// Hases the by ref parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasByRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsByRef && (parameter.ParameterType.GetElementType() == elementType));
        }

        /// <summary>
        /// Hases the array parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && (parameter.ParameterType.GetElementType() == elementType));
        }
    }
}
