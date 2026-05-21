// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTest.cs
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
    ///     Provides API-surface unit coverage for the <see cref="ImPlot" /> static wrapper class.
    /// </summary>
    public class ImPlotTest
    {
        /// <summary>
        ///     Verifies that ImPlot is generated as a static class.
        /// </summary>
        [Fact]
        public void Type_ShouldBeStaticClass()
        {
            Type type = typeof(ImPlot);

            Assert.True(type.IsClass);
            Assert.True(type.IsAbstract);
            Assert.True(type.IsSealed);
        }

        /// <summary>
        ///     Verifies that all public ImPlot methods are static API wrappers.
        /// </summary>
        [Fact]
        public void PublicMethods_ShouldBeStatic()
        {
            MethodInfo[] methods = typeof(ImPlot).GetMethods(BindingFlags.Public | BindingFlags.Static);

            Assert.NotEmpty(methods);
            Assert.All(methods, method => Assert.True(method.IsStatic));
        }

        /// <summary>
        ///     Verifies that PlotStems exposes a broad set of overloads for different numeric types.
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeMultipleNumericOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");

            Assert.True(overloads.Length >= 20);
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ulong)));
        }

        /// <summary>
        ///     Verifies that ShowDemoWindow includes both simple and ref-bool overloads.
        /// </summary>
        [Fact]
        public void ShowDemoWindow_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowDemoWindow");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(bool).MakeByRefType()));
        }

        /// <summary>
        ///     Verifies that ShowMetricsWindow includes both simple and ref-bool overloads.
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowMetricsWindow");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(bool).MakeByRefType()));
        }

        /// <summary>
        ///     Verifies that SetupLegend supports both default and custom flag configurations.
        /// </summary>
        [Fact]
        public void SetupLegend_ShouldExposeDefaultAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupLegend");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that SetupMouseText supports both default and custom flag configurations.
        /// </summary>
        [Fact]
        public void SetupMouseText_ShouldExposeDefaultAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupMouseText");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that TagX includes bool and formatting-string overloads.
        /// </summary>
        [Fact]
        public void TagX_ShouldExposeBooleanAndStringOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("TagX");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(bool)));
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(string)));
        }

        /// <summary>
        ///     Verifies that TagY includes bool and formatting-string overloads.
        /// </summary>
        [Fact]
        public void TagY_ShouldExposeBooleanAndStringOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("TagY");

            Assert.True(overloads.Length >= 3);
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(bool)));
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(string)));
        }

        /// <summary>
        ///     Verifies that SetupAxisTicks includes the overload accepting labels.
        /// </summary>
        [Fact]
        public void SetupAxisTicks_ShouldExposeLabelOverload()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxisTicks");

            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(string[])));
        }

        /// <summary>
        ///     Verifies that Windows-only tests can be isolated when needed.
        /// </summary>
        [WindowsOnly]
        public void WindowsOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImPlot));
        }

        /// <summary>
        ///     Verifies that macOS-only tests can be isolated when needed.
        /// </summary>
        [MacOsOnly]
        public void MacOsOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImPlot));
        }

        /// <summary>
        ///     Verifies that Linux-only tests can be isolated when needed.
        /// </summary>
        [LinuxOnly]
        public void LinuxOnly_SurfaceCheck_ShouldRunIsolated()
        {
            Assert.NotNull(typeof(ImPlot));
        }

        /// <summary>
        ///     Gets all public static methods with the specified name.
        /// </summary>
        /// <param name="name">The target method name.</param>
        /// <returns>An array of matching methods.</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        ///     Determines whether a method contains a by-reference parameter for a specific element type.
        /// </summary>
        /// <param name="method">The method to inspect.</param>
        /// <param name="elementType">The expected by-reference element type.</param>
        /// <returns><c>true</c> when a matching by-reference parameter exists; otherwise, <c>false</c>.</returns>
        private static bool HasByRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsByRef && (parameter.ParameterType.GetElementType() == elementType));
        }
    }
}