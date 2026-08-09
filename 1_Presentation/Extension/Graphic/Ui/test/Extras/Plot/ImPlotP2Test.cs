// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP2Test.cs
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
    ///     Provides focused unit coverage for API members implemented in <c>ImPlotP2.cs</c>.
    /// </summary>
    public class ImPlotP2Test
    {

        /// <summary>
        ///     Verifies that passing a null labels array to <c>PlotBarGroups</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithNullLabelsArray_ShouldThrowNullReferenceException()
        {
            float[] values = { 1f, 2f };

            Assert.Throws<NullReferenceException>((Action)(() => ImPlot.PlotBarGroups(null, values, 2, 1)));
        }

        /// <summary>
        ///     Verifies that passing a null label item in <c>PlotBarGroups</c> throws before native invocation.
        /// </summary>
        [Fact]
        public void PlotBarGroups_WithNullLabelItem_ShouldThrowArgumentNullException()
        {
            string[] labels = { "A", null };
            float[] values = { 1f, 2f };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotBarGroups(labels, values, 2, 1)));
        }

        /// <summary>
        ///     Gets all public static methods with the requested name.
        /// </summary>
        /// <param name="name">The method name.</param>
        /// <returns>The matching method array.</returns>
        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        /// <summary>
        ///     Gets a single public static method with the requested name.
        /// </summary>
        /// <param name="name">The method name.</param>
        /// <returns>The matching method or null.</returns>
        private static MethodInfo GetPublicStaticMethod(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .FirstOrDefault(method => method.Name == name);
        }

        /// <summary>
        ///     Determines whether a method has an array parameter whose element type matches the provided type.
        /// </summary>
        /// <param name="method">The method to inspect.</param>
        /// <param name="elementType">The target array element type.</param>
        /// <returns><c>true</c> when a matching array parameter exists; otherwise <c>false</c>.</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
        }
    }
}
