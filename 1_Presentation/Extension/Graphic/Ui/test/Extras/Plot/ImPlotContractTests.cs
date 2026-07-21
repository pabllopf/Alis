// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotContractTests.cs
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

using System.Linq;
using System.Reflection;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Extended API-surface contract tests covering all partial files of the <see cref="ImPlot" /> class.
    /// </summary>
    public class ImPlotContractTests
    {
        /// <summary>
        ///     Verifies that ImPlot exposes a large number of public static methods.
        /// </summary>
        [Fact]
        public void PublicStaticMethodCount_ShouldBeLarge()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.DeclaringType == typeof(ImPlot))
                .ToArray();

            Assert.True(methods.Length > 500);
        }

        /// <summary>
        ///     Verifies that the PlotStems method has the expected overloads.
        /// </summary>
        [Fact]
        public void PlotStems_ShouldHaveExpectedOverloads()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotStems")
                .ToArray();

            Assert.True(overloads.Length >= 10);
        }

        /// <summary>
        ///     Verifies that PlotLine method exists with expected overloads.
        /// </summary>
        [Fact]
        public void PlotLine_ShouldHaveExpectedOverloads()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotLine")
                .ToArray();

            Assert.True(overloads.Length >= 5);
        }

        /// <summary>
        ///     Verifies that BeginPlot method exists.
        /// </summary>
        [Fact]
        public void BeginPlot_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "BeginPlot")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that EndPlot method exists.
        /// </summary>
        [Fact]
        public void EndPlot_ShouldExist()
        {
            MethodInfo method = typeof(ImPlot)
                .GetMethod("EndPlot", BindingFlags.Public | BindingFlags.Static, null, System.Type.EmptyTypes, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetupAxis method exists with expected overloads.
        /// </summary>
        [Fact]
        public void SetupAxis_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetupAxis")
                .ToArray();

            Assert.True(overloads.Length >= 2);
        }

        /// <summary>
        ///     Verifies that SetupAxisLimits method exists.
        /// </summary>
        [Fact]
        public void SetupAxisLimits_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetupAxisLimits")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that SetNextAxisLimits method exists.
        /// </summary>
        [Fact]
        public void SetNextAxisLimits_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetNextAxisLimits")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that ShowDemoWindow method exists.
        /// </summary>
        [Fact]
        public void ShowDemoWindow_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "ShowDemoWindow")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that ShowMetricsWindow method exists.
        /// </summary>
        [Fact]
        public void ShowMetricsWindow_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "ShowMetricsWindow")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that CreateContext method exists.
        /// </summary>
        [Fact]
        public void CreateContext_ShouldExist()
        {
            MethodInfo method = typeof(ImPlot)
                .GetMethod("CreateContext", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Verifies that DestroyContext method exists.
        /// </summary>
        [Fact]
        public void DestroyContext_ShouldExist()
        {
            MethodInfo method = typeof(ImPlot)
                .GetMethod("DestroyContext", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Verifies that SetCurrentContext method exists.
        /// </summary>
        [Fact]
        public void SetCurrentContext_ShouldExist()
        {
            MethodInfo method = typeof(ImPlot)
                .GetMethod("SetCurrentContext", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Verifies that GetCurrentContext method exists.
        /// </summary>
        [Fact]
        public void GetCurrentContext_ShouldExist()
        {
            MethodInfo method = typeof(ImPlot)
                .GetMethod("GetCurrentContext", BindingFlags.Public | BindingFlags.Static);

            Assert.NotNull(method);
        }

        /// <summary>
        ///     Verifies that TagX method exists with expected overloads.
        /// </summary>
        [Fact]
        public void TagX_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "TagX")
                .ToArray();

            Assert.True(overloads.Length >= 3);
        }

        /// <summary>
        ///     Verifies that TagY method exists with expected overloads.
        /// </summary>
        [Fact]
        public void TagY_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "TagY")
                .ToArray();

            Assert.True(overloads.Length >= 3);
        }

        /// <summary>
        ///     Verifies that SetupLegend method exists.
        /// </summary>
        [Fact]
        public void SetupLegend_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetupLegend")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that SetupMouseText method exists.
        /// </summary>
        [Fact]
        public void SetupMouseText_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetupMouseText")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that SetupAxisTicks method exists.
        /// </summary>
        [Fact]
        public void SetupAxisTicks_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "SetupAxisTicks")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotScatter method exists.
        /// </summary>
        [Fact]
        public void PlotScatter_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotScatter")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotBars method exists.
        /// </summary>
        [Fact]
        public void PlotBars_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotBars")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotBarsH method exists.
        /// </summary>
        [Fact]
        public void PlotBarsH_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotBarsH")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotHistogram method exists.
        /// </summary>
        [Fact]
        public void PlotHistogram_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotHistogram")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotHistogram2D method exists.
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotHistogram2D")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotDigital method exists.
        /// </summary>
        [Fact]
        public void PlotDigital_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotDigital")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotImage method exists.
        /// </summary>
        [Fact]
        public void PlotImage_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotImage")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotText method exists.
        /// </summary>
        [Fact]
        public void PlotText_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotText")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that PlotDummy method exists.
        /// </summary>
        [Fact]
        public void PlotDummy_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PlotDummy")
                .ToArray();

            Assert.NotEmpty(overloads);
        }

        /// <summary>
        ///     Verifies that Colormap methods exist.
        /// </summary>
        [Fact]
        public void ColormapMethods_ShouldExist()
        {
            MethodInfo[] colormapMethods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name.StartsWith("Colormap"))
                .ToArray();

            Assert.True(colormapMethods.Length >= 5);
        }

        /// <summary>
        ///     Verifies that DragDropTarget variant methods exist.
        /// </summary>
        [Fact]
        public void DragDropTargetMethods_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name.StartsWith("BeginDragDropTarget") || m.Name == "EndDragDropTarget")
                .ToArray();

            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies that DragDropSource variant methods exist.
        /// </summary>
        [Fact]
        public void DragDropSourceMethods_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name.StartsWith("BeginDragDropSource") || m.Name == "EndDragDropSource")
                .ToArray();

            Assert.True(methods.Length >= 4);
        }

        /// <summary>
        ///     Verifies that LegendPopup methods exist.
        /// </summary>
        [Fact]
        public void LegendContextMethods_ShouldExist()
        {
            Assert.NotNull(typeof(ImPlot)
                .GetMethod("BeginLegendPopup", BindingFlags.Public | BindingFlags.Static));
            Assert.NotNull(typeof(ImPlot)
                .GetMethod("EndLegendPopup", BindingFlags.Public | BindingFlags.Static));
        }

        /// <summary>
        ///     Verifies that PushStyleColor and PopStyleColor methods exist.
        /// </summary>
        [Fact]
        public void StyleColorMethods_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PushStyleColor" || m.Name == "PopStyleColor")
                .ToArray();

            Assert.True(overloads.Length >= 2);
        }

        /// <summary>
        ///     Verifies that StyleVar methods exist.
        /// </summary>
        [Fact]
        public void StyleVarMethods_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PushStyleVar" || m.Name == "PopStyleVar")
                .ToArray();

            Assert.True(overloads.Length >= 2);
        }

        /// <summary>
        ///     Verifies that Axis methods with SetNext prefix exist.
        /// </summary>
        [Fact]
        public void SetNextAxisMethods_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name.StartsWith("SetNext"))
                .ToArray();

            Assert.True(methods.Length >= 3);
        }

        /// <summary>
        ///     Verifies that PixelsToPlot and PlotToPixels methods exist.
        /// </summary>
        [Fact]
        public void CoordinateConversionMethods_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "PixelsToPlot" || m.Name == "PlotToPixels")
                .ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies that GetPlotPos and GetPlotSize methods exist.
        /// </summary>
        [Fact]
        public void PlotQueryMethods_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "GetPlotPos" || m.Name == "GetPlotSize")
                .ToArray();

            Assert.True(methods.Length >= 2);
        }

        /// <summary>
        ///     Verifies that IsPlotHovered method exists.
        /// </summary>
        [Fact]
        public void IsPlotHovered_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "IsPlotHovered")
                .ToArray();

            Assert.NotEmpty(methods);
        }

        /// <summary>
        ///     Verifies that GetPlotLimits method exists.
        /// </summary>
        [Fact]
        public void GetPlotLimits_ShouldExist()
        {
            MethodInfo[] methods = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "GetPlotLimits")
                .ToArray();

            Assert.NotEmpty(methods);
        }

        /// <summary>
        ///     Verifies that Annotation methods exist.
        /// </summary>
        [Fact]
        public void AnnotationMethods_ShouldExist()
        {
            MethodInfo[] overloads = typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(m => m.Name == "Annotation")
                .ToArray();

            Assert.True(overloads.Length >= 2);
        }
    }
}
