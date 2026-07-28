// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP15Tests.cs
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
    /// The im plot 15 tests class
    /// </summary>
    public class ImPlotP15Tests
    {
        /// <summary>
        /// Tests that plot bar groups u 32 with group size should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U32_WithGroupSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 32 with group size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U32_WithGroupSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 32 with group size shift and flags should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U32_WithGroupSizeShiftAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(uint[]), typeof(int), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarGroupsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups s 64 default should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_S64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups s 64 with group size should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_S64_WithGroupSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups s 64 with group size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_S64_WithGroupSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups s 64 with group size shift and flags should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_S64_WithGroupSizeShiftAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(long[]), typeof(int), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarGroupsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 64 default should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 64 with group size should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U64_WithGroupSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 64 with group size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U64_WithGroupSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups u 64 with group size shift and flags should be void
        /// </summary>
        [Fact]
        public void PlotBarGroups_U64_WithGroupSizeShiftAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarGroups", new[] { typeof(string[]), typeof(ulong[]), typeof(int), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarGroupsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bar groups should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotBarGroups_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBarGroups");
            Assert.True(overloads.Length >= 11);
        }

        /// <summary>
        /// Tests that plot bars float ref default should be void
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars float ref with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars float ref with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]).MakeByRefType(), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars float with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_Float_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars float ref with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]).MakeByRefType(), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars float ref with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_FloatRef_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(float[]).MakeByRefType(), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double default should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars double with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_Double_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 8 with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_S8_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 8 with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_U8_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 16 with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_S16_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 16 with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_U16_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 with bar size should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 with bar size and shift should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_WithBarSizeAndShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 with flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars s 32 with full should be void
        /// </summary>
        [Fact]
        public void PlotBars_S32_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 32 default should be void
        /// </summary>
        [Fact]
        public void PlotBars_U32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[] { typeof(string), typeof(uint[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotBars_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBars");
            Assert.True(overloads.Length >= 44);
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
