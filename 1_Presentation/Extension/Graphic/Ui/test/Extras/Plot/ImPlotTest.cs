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
using Alis.Core.Aspect.Math.Vector;
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
        public void PublicMethods_ShouldBeStatic()
        {
            MethodInfo[] methods = typeof(ImPlot).GetMethods(BindingFlags.Public | BindingFlags.Static);

            Assert.NotEmpty(methods);
            Assert.All(methods, method => Assert.True(method.IsStatic));
        }

        /// <summary>
        ///     Verifies that PlotStems exposes a broad set of overloads for different numeric types.
        /// </summary>
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireCImguiSystemFact]
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
        [RequireImNodesSystemFact]
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
        ///     Verifies that PopColormap exposes both default and explicit overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopColormap_ShouldExposeDefaultAndCountOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PopColormap");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(int)));
        }

        /// <summary>
        ///     Verifies that PopPlotClipRect is a parameterless method.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopPlotClipRect_ShouldBeParameterless()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("PopPlotClipRect", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that PopStyleColor exposes both default and explicit overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopStyleColor_ShouldExposeDefaultAndCountOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PopStyleColor");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(int)));
        }

        /// <summary>
        ///     Verifies that PopStyleVar exposes both default and explicit overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PopStyleVar_ShouldExposeDefaultAndCountOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PopStyleVar");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(int)));
        }

        /// <summary>
        ///     Verifies that PushColormap exposes both enum and string overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushColormap_ShouldExposeEnumAndStringOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PushColormap");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(ImPlotColormap));
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(string));
        }

        /// <summary>
        ///     Verifies that PushPlotClipRect exposes both default and explicit overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushPlotClipRect_ShouldExposeDefaultAndExpandOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PushPlotClipRect");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => (method.GetParameters().Length == 1) && (method.GetParameters()[0].ParameterType == typeof(float)));
        }

        /// <summary>
        ///     Verifies that PushStyleColor exposes both U32 and Vec4 overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleColor_ShouldExposeU32AndVec4Overloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PushStyleColor");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(uint));
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(Vector4F));
        }

        /// <summary>
        ///     Verifies that PushStyleVar exposes Float, Int, and Vec2 overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PushStyleVar_ShouldExposeFloatIntAndVec2Overloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PushStyleVar");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(float));
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(int));
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(Vector2F));
        }

        /// <summary>
        ///     Verifies that SampleColormap exposes both default and explicit colormap overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SampleColormap_ShouldExposeDefaultAndCustomOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SampleColormap");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that SetAxes is a two-parameter method.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAxes_ShouldAcceptTwoAxisParameters()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetAxes", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ImAxis), typeof(ImAxis) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetAxis is a single-parameter method.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetAxis_ShouldAcceptSingleAxisParameter()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetAxis", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ImAxis) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetImGuiContext accepts an IntPtr.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetImGuiContext_ShouldAcceptIntPtr()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetImGuiContext", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(IntPtr) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetNextAxesLimits exposes both with and without condition overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextAxesLimits_ShouldExposeDefaultAndConditionOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextAxesLimits");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
        }

        /// <summary>
        ///     Verifies that SetNextAxesToFit is parameterless.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextAxesToFit_ShouldBeParameterless()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetNextAxesToFit", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetNextAxisLinks exposes a with-ref overload.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextAxisLinks_ShouldAcceptAxisAndRefDoubles()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextAxisLinks");

            Assert.NotEmpty(overloads);
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.GetElementType() == typeof(double)));
        }

        /// <summary>
        ///     Verifies that SetNextAxisToFit accepts a single ImAxis.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextAxisToFit_ShouldAcceptSingleAxis()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetNextAxisToFit", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ImAxis) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetNextErrorBarStyle exposes four overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextErrorBarStyle_ShouldExposeMultipleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextErrorBarStyle");

            Assert.Equal(4, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
        }

        /// <summary>
        ///     Verifies that SetNextFillStyle exposes three overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextFillStyle_ShouldExposeThreeOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextFillStyle");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that SetNextLineStyle exposes three overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextLineStyle_ShouldExposeThreeOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextLineStyle");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
        }

        /// <summary>
        ///     Verifies that SetNextMarkerStyle exposes six overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetNextMarkerStyle_ShouldExposeSixOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetNextMarkerStyle");

            Assert.Equal(6, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
            Assert.Contains(overloads, method => method.GetParameters().Length == 2);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
        }

        /// <summary>
        ///     Verifies that SetupAxes exposes three overloads with string parameters.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxes_ShouldExposeStringAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxes");

            Assert.Equal(3, overloads.Length);
            Assert.All(overloads, method => Assert.True(method.GetParameters()[0].ParameterType == typeof(string)));
            Assert.All(overloads, method => Assert.True(method.GetParameters()[1].ParameterType == typeof(string)));
        }

        /// <summary>
        ///     Verifies that SetupAxesLimits exposes both with and without condition overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxesLimits_ShouldExposeDefaultAndConditionOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxesLimits");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
        }

        /// <summary>
        ///     Verifies that SetupAxisFormat exposes string and IntPtr overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisFormat_ShouldExposeStringAndIntPtrOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxisFormat");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(string)));
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(IntPtr)));
        }

        /// <summary>
        ///     Verifies that SetupAxisLimitsConstraints accepts axis and two doubles.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisLimitsConstraints_ShouldAcceptAxisAndTwoDoubles()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetupAxisLimitsConstraints", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ImAxis), typeof(double), typeof(double) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetupAxisLinks accepts axis and ref doubles.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisLinks_ShouldAcceptAxisAndRefDoubles()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxisLinks");

            Assert.NotEmpty(overloads);
            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.GetElementType() == typeof(double)));
        }

        /// <summary>
        ///     Verifies that SetupAxisScale exposes PlotScale and IntPtr overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisScale_ShouldExposeEnumAndIntPtrOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("SetupAxisScale");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(ImPlotScale));
            Assert.Contains(overloads, method => method.GetParameters()[1].ParameterType == typeof(IntPtr));
        }

        /// <summary>
        ///     Verifies that SetupAxisZoomConstraints accepts axis and two doubles.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupAxisZoomConstraints_ShouldAcceptAxisAndTwoDoubles()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetupAxisZoomConstraints", BindingFlags.Public | BindingFlags.Static, null, new[] { typeof(ImAxis), typeof(double), typeof(double) }, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that SetupFinish is parameterless.
        /// </summary>
        [RequireCImguiSystemFact]
        public void SetupFinish_ShouldBeParameterless()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("SetupFinish", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that ShowColormapSelector accepts a string and returns bool.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowColormapSelector_ShouldAcceptAndReturnBool()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowColormapSelector");

            Assert.NotEmpty(overloads);
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(string));
            Assert.Contains(overloads, method => method.ReturnType == typeof(bool));
        }

        /// <summary>
        ///     Verifies that ShowInputMapSelector accepts a string and returns bool.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowInputMapSelector_ShouldAcceptStringAndReturnBool()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowInputMapSelector");

            Assert.NotEmpty(overloads);
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(string));
            Assert.Contains(overloads, method => method.ReturnType == typeof(bool));
        }

        /// <summary>
        ///     Verifies that ShowStyleEditor exposes both default and ImPlotStyle overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowStyleEditor_ShouldExposeDefaultAndStyleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowStyleEditor");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that ShowStyleSelector accepts a string and returns bool.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowStyleSelector_ShouldAcceptStringAndReturnBool()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("ShowStyleSelector");

            Assert.NotEmpty(overloads);
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(string));
            Assert.Contains(overloads, method => method.ReturnType == typeof(bool));
        }

        /// <summary>
        ///     Verifies that ShowUserGuide is parameterless.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ShowUserGuide_ShouldBeParameterless()
        {
            MethodInfo method = typeof(ImPlot).GetMethod("ShowUserGuide", BindingFlags.Public | BindingFlags.Static, null, Type.EmptyTypes, null);

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        ///     Verifies that StyleColorsAuto exposes both default and ImPlotStyle overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsAuto_ShouldExposeDefaultAndStyleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("StyleColorsAuto");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that StyleColorsClassic exposes both default and ImPlotStyle overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsClassic_ShouldExposeDefaultAndStyleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("StyleColorsClassic");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that StyleColorsDark exposes both default and ImPlotStyle overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsDark_ShouldExposeDefaultAndStyleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("StyleColorsDark");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that StyleColorsLight exposes both default and ImPlotStyle overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void StyleColorsLight_ShouldExposeDefaultAndStyleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("StyleColorsLight");

            Assert.Equal(2, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 0);
            Assert.Contains(overloads, method => method.GetParameters().Length == 1);
        }

        /// <summary>
        ///     Verifies that PlotToPixels exposes the expected set of overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotToPixels_ShouldExposePointAndDoubleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotToPixels");

            Assert.Equal(6, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(ImPlotPoint));
            Assert.Contains(overloads, method => method.GetParameters()[0].ParameterType == typeof(double));
            Assert.Contains(overloads, method => method.ReturnType == typeof(Vector2F));
        }

        /// <summary>
        ///     Verifies that PlotText exposes the expected three overloads.
        /// </summary>
        [RequireCImguiSystemFact]
        public void PlotText_ShouldExposeStringAndVectorAndFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotText");

            Assert.Equal(3, overloads.Length);
            Assert.Contains(overloads, method => method.GetParameters().Length == 3);
            Assert.Contains(overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(overloads, method => method.GetParameters().Length == 5);
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