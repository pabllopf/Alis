// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP12Tests.cs
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
    /// The im plot 12 tests class
    /// </summary>
    public class ImPlotP12Tests
    {
        /// <summary>
        /// Tests that plot histogram should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotHistogram_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram");
            Assert.True(overloads.Length >= 32);
        }

        /// <summary>
        /// Tests that plot histogram u 8 ptr with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U8Ptr_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 8 ptr with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U8Ptr_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 16 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S16_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(short[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 16 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S16_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(short[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 16 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S16_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(short[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 16 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S16_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(short[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 16 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S16_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(short[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 16 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U16_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ushort[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 16 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U16_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 16 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U16_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 16 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U16_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 16 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U16_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 32 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S32_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(int[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 32 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S32_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(int[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 32 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S32_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(int[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 32 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S32_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(int[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 32 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S32_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(int[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 32 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U32_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(uint[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 32 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U32_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 32 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U32_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 32 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U32_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 32 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U32_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 64 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S64_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(long[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 64 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S64_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(long[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 64 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S64_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(long[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 64 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S64_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(long[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram s 64 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_S64_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(long[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 64 default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U64_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ulong[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 64 with bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U64_WithBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 64 with bins and bar scale should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U64_WithBinsAndBarScale_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 64 with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U64_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram u 64 with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram_U64_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(int), typeof(double), typeof(ImPlotRange), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram should expose five overloads for short
        /// </summary>
        [Fact]
        public void PlotHistogram_ShouldExposeFiveOverloadsForShort()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram");
            MethodInfo[] shortOverloads = overloads.Where(method => HasArrayParameter(method, typeof(short))).ToArray();
            Assert.True(shortOverloads.Length >= 5);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot histogram should expose all expected array types
        /// </summary>
        [Fact]
        public void PlotHistogram_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram");
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot histogram should expose flags overloads
        /// </summary>
        [Fact]
        public void PlotHistogram_ShouldExposeFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram");
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotHistogramFlags)));
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose sufficient overload count
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeSufficientOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.True(overloads.Length >= 18);
        }

        /// <summary>
        /// Tests that plot histogram 2 d float ref default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_FloatRef_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d float ref with x bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_FloatRef_WithXBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d float ref with x bins and y bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_FloatRef_WithXBinsAndYBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d float ref with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_FloatRef_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d float ref with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_FloatRef_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d double ref default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_DoubleRef_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d double ref with x bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_DoubleRef_WithXBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d double ref with x bins and y bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_DoubleRef_WithXBinsAndYBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d double ref with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_DoubleRef_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d double ref with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_DoubleRef_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d s 8 ref default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_S8Ref_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d s 8 ref with x bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_S8Ref_WithXBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d s 8 ref with x bins and y bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_S8Ref_WithXBinsAndYBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d s 8 ref with range should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_S8Ref_WithRange_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d s 8 ref with range and flags should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_S8Ref_WithRangeAndFlags_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d u 8 ref default should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_U8Ref_Default_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d u 8 ref with x bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_U8Ref_WithXBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d u 8 ref with x bins and y bins should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_U8Ref_WithXBinsAndYBins_ShouldReturnDouble()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType, 5);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose all expected by ref numeric families
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeAllExpectedByRefNumericFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(byte)));
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose flags overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeFlagsOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotHistogramFlags)));
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose five float ref overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeFiveFloatRefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] floatOverloads = overloads.Where(method => HasByRefParameter(method, typeof(float))).ToArray();
            Assert.True(floatOverloads.Length >= 5);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(floatOverloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose five double ref overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeFiveDoubleRefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] doubleOverloads = overloads.Where(method => HasByRefParameter(method, typeof(double))).ToArray();
            Assert.True(doubleOverloads.Length >= 5);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose five s 8 ref overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeFiveS8RefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] s8Overloads = overloads.Where(method => HasByRefParameter(method, typeof(sbyte))).ToArray();
            Assert.True(s8Overloads.Length >= 5);
            Assert.Contains(s8Overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(s8Overloads, method => method.GetParameters().Length == 5);
            Assert.Contains(s8Overloads, method => method.GetParameters().Length == 6);
            Assert.Contains(s8Overloads, method => method.GetParameters().Length == 7);
            Assert.Contains(s8Overloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose three u 8 ref overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeThreeU8RefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] u8Overloads = overloads.Where(method => HasByRefParameter(method, typeof(byte))).ToArray();
            Assert.True(u8Overloads.Length >= 3);
            Assert.Contains(u8Overloads, method => method.GetParameters().Length == 4);
            Assert.Contains(u8Overloads, method => method.GetParameters().Length == 5);
            Assert.Contains(u8Overloads, method => method.GetParameters().Length == 6);
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
