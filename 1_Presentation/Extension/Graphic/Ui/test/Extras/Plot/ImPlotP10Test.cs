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
