// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP22Tests.cs
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
    /// The im plot 22 tests class
    /// </summary>
    public class ImPlotP22Tests
    {

        /// <summary>
        /// Plots the line short array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_ShortArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1, 1.0, 0.0, ImPlotLineFlags.None, 0, 0)));
        }

        /// <summary>
        /// Plots the line ushort array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_UshortArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            ushort[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1)));
        }

        /// <summary>
        /// Plots the line int array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_IntArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            int[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1)));
        }

        /// <summary>
        /// Plots the line uint array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_UintArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            uint[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1)));
        }

        /// <summary>
        /// Plots the line long array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_LongArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            long[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1)));
        }

        /// <summary>
        /// Plots the line ulong array with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_UlongArray_WithNullLabel_ShouldThrowArgumentNullException()
        {
            ulong[] values = { 1, 2 };

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, values, 1)));
        }

        /// <summary>
        /// Plots the line ref float with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefFloat_WithNullLabel_ShouldThrowArgumentNullException()
        {
            float xs = 1f;
            float ys = 2f;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the line ref double with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefDouble_WithNullLabel_ShouldThrowArgumentNullException()
        {
            double xs = 1.0;
            double ys = 2.0;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the line ref sbyte with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefSbyte_WithNullLabel_ShouldThrowArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the line ref byte with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefByte_WithNullLabel_ShouldThrowArgumentNullException()
        {
            byte xs = 1;
            byte ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the line ref short with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefShort_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 1;
            short ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
        }

        /// <summary>
        /// Plots the line ref short with flags and null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefShort_WithFlags_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 1;
            short ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None)));
        }

        /// <summary>
        /// Plots the line ref short with flags and offset and null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefShort_WithFlagsAndOffset_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 1;
            short ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0)));
        }

        /// <summary>
        /// Plots the line ref short with flags offset and stride and null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefShort_WithFlagsOffsetAndStride_WithNullLabel_ShouldThrowArgumentNullException()
        {
            short xs = 1;
            short ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1, ImPlotLineFlags.None, 0, sizeof(short))));
        }

        /// <summary>
        /// Plots the line ref ushort with null label should throw argument null exception
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotLine_RefUshort_WithNullLabel_ShouldThrowArgumentNullException()
        {
            ushort xs = 1;
            ushort ys = 2;

            Assert.Throws<ArgumentNullException>((Action)(() => ImPlot.PlotLine(null, ref xs, ref ys, 1)));
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
