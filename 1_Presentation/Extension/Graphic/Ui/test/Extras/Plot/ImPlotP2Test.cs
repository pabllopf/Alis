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
        ///     Verifies that <c>EndDragDropTarget</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void EndDragDropTarget_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("EndDragDropTarget");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>EndLegendPopup</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void EndLegendPopup_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("EndLegendPopup");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>EndPlot</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void EndPlot_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("EndPlot");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>EndSubplots</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void EndSubplots_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("EndSubplots");

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetColormapColor</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void GetColormapColor_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("GetColormapColor");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(int));
            Assert.Contains(overloads, method => method.GetParameters().Length == 2 && method.GetParameters()[1].ParameterType.Name == "ImPlotColormap");
        }

        /// <summary>
        ///     Verifies that <c>GetColormapCount</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetColormapCount_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetColormapCount");

            Assert.NotNull(method);
            Assert.Equal(typeof(int), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetColormapIndex</c> is a public static method with a string parameter.
        /// </summary>
        [Fact]
        public void GetColormapIndex_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetColormapIndex");

            Assert.NotNull(method);
            Assert.Equal(1, method.GetParameters().Length);
            Assert.Equal(typeof(string), method.GetParameters()[0].ParameterType);
        }

        /// <summary>
        ///     Verifies that <c>GetColormapName</c> is a public static method with an ImPlotColormap parameter.
        /// </summary>
        [Fact]
        public void GetColormapName_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetColormapName");

            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
            Assert.Equal(1, method.GetParameters().Length);
        }

        /// <summary>
        ///     Verifies that <c>GetColormapSize</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void GetColormapSize_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("GetColormapSize");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that <c>GetCurrentContext</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetCurrentContext_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetCurrentContext");

            Assert.NotNull(method);
            Assert.Equal(typeof(IntPtr), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetInputMap</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetInputMap_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetInputMap");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetLastItemColor</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetLastItemColor_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetLastItemColor");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetMarkerName</c> is a public static method with an ImPlotMarker parameter.
        /// </summary>
        [Fact]
        public void GetMarkerName_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetMarkerName");

            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
            Assert.Equal(1, method.GetParameters().Length);
        }

        /// <summary>
        ///     Verifies that <c>GetPlotDrawList</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetPlotDrawList_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetPlotDrawList");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetPlotLimits</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void GetPlotLimits_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("GetPlotLimits");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that <c>GetPlotMousePos</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void GetPlotMousePos_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("GetPlotMousePos");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that <c>GetPlotPos</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetPlotPos_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetPlotPos");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetPlotSelection</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void GetPlotSelection_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("GetPlotSelection");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that <c>GetPlotSize</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetPlotSize_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetPlotSize");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetStyle</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void GetStyle_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetStyle");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>GetStyleColorName</c> is a public static method with an ImPlotCol parameter.
        /// </summary>
        [Fact]
        public void GetStyleColorName_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("GetStyleColorName");

            Assert.NotNull(method);
            Assert.Equal(typeof(string), method.ReturnType);
            Assert.Equal(1, method.GetParameters().Length);
        }

        /// <summary>
        ///     Verifies that <c>HideNextItem</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void HideNextItem_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("HideNextItem");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1 && method.GetParameters()[0].ParameterType == typeof(bool));
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that <c>IsAxisHovered</c> is a public static method with an ImAxis parameter.
        /// </summary>
        [Fact]
        public void IsAxisHovered_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("IsAxisHovered");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            Assert.Equal(1, method.GetParameters().Length);
        }

        /// <summary>
        ///     Verifies that <c>IsLegendEntryHovered</c> is a public static method with a string parameter.
        /// </summary>
        [Fact]
        public void IsLegendEntryHovered_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("IsLegendEntryHovered");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            Assert.Equal(1, method.GetParameters().Length);
            Assert.Equal(typeof(string), method.GetParameters()[0].ParameterType);
        }

        /// <summary>
        ///     Verifies that <c>IsPlotHovered</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void IsPlotHovered_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("IsPlotHovered");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>IsPlotSelected</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void IsPlotSelected_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("IsPlotSelected");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>IsSubplotsHovered</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void IsSubplotsHovered_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("IsSubplotsHovered");

            Assert.NotNull(method);
            Assert.Equal(typeof(bool), method.ReturnType);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>ItemIcon</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void ItemIcon_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ItemIcon");

            Assert.Equal(2, overloads.Length);
        }

        /// <summary>
        ///     Verifies that <c>MapInputDefault</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void MapInputDefault_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("MapInputDefault");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that <c>MapInputReverse</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void MapInputReverse_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("MapInputReverse");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that <c>NextColormapColor</c> is a public static method with no parameters.
        /// </summary>
        [Fact]
        public void NextColormapColor_ShouldBePublicStaticMethod()
        {
            MethodInfo method = GetPublicStaticMethod("NextColormapColor");

            Assert.NotNull(method);
            Assert.Empty(method.GetParameters());
        }

        /// <summary>
        ///     Verifies that <c>PixelsToPlot</c> exposes the expected overloads.
        /// </summary>
        [Fact]
        public void PixelsToPlot_ShouldExposeExpectedOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PixelsToPlot");

            Assert.True(overloads.Length >= 5);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
        }

        /// <summary>
        ///     Verifies that <c>PixelsToPlot</c> includes overloads accepting Vector2F and separate float parameters.
        /// </summary>
        [Fact]
        public void PixelsToPlot_ShouldAcceptVector2FAndFloatOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PixelsToPlot");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.Name == "Vector2F"));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(float)));
        }

        /// <summary>
        ///     Verifies that <c>PlotBarGroups</c> exposes a large number of overloads.
        /// </summary>
        [Fact]
        public void PlotBarGroups_ShouldExposeManyOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBarGroups");

            Assert.True(overloads.Length >= 28);
        }

        /// <summary>
        ///     Verifies that <c>PlotBarGroups</c> includes overloads for all expected numeric array types.
        /// </summary>
        [Fact]
        public void PlotBarGroups_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBarGroups");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
        }

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
