// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP13Tests.cs
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
    public class ImPlotP13Tests
    {
        [Fact]
        public void PlotStairs_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.True(overloads.Length >= 55);
        }

        [Fact]
        public void PlotStairs_RefByte_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefShort_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefShort_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefShort_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefShort_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUShort_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUShort_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUShort_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUShort_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefInt_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefInt_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUInt_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefUInt_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefLong_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefLong_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefLong_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefLong_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefULong_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefULong_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefULong_WithFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefULong_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[] { typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotStairsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ShouldExposeAllExpectedRefNumericFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ulong)));
        }

        [Fact]
        public void PlotStairs_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotStairsFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 6) && (method.GetParameters()[5].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 7) && (method.GetParameters()[6].ParameterType == typeof(int)));
        }

        [Fact]
        public void PlotStairs_ShouldExposeFourShortRefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] shortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(short))).ToArray();
            Assert.True(shortOverloads.Length >= 4);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeFourIntRefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] intOverloads = overloads.Where(method => HasByRefParameter(method, typeof(int))).ToArray();
            Assert.True(intOverloads.Length >= 4);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeFourLongRefOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] longOverloads = overloads.Where(method => HasByRefParameter(method, typeof(long))).ToArray();
            Assert.True(longOverloads.Length >= 4);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeAtLeastOneByteRefOverload()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] byteOverloads = overloads.Where(method => HasByRefParameter(method, typeof(byte))).ToArray();
            Assert.True(byteOverloads.Length >= 1);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairsG_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairsG", new[] { typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairsG_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairsG", new[] { typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int), typeof(ImPlotStairsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairsG_ShouldExposeTwoOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairsG");
            Assert.True(overloads.Length >= 2);
        }

        [Fact]
        public void PlotStems_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.True(overloads.Length >= 70);
        }

        [Fact]
        public void PlotStems_FloatArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_FloatArray_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_DoubleArray_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_S8Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_U8Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_U8Array_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_U8Array_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_U8Array_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_U8Array_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStems_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
        }

        [Fact]
        public void PlotStems_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotStemsFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 8) && (method.GetParameters()[7].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 9) && (method.GetParameters()[8].ParameterType == typeof(int)));
        }

        [Fact]
        public void PlotStems_ShouldExposeSevenFloatArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
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

        [Fact]
        public void PlotStems_ShouldExposeSevenDoubleArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] doubleOverloads = overloads.Where(method => HasArrayParameter(method, typeof(double))).ToArray();
            Assert.True(doubleOverloads.Length >= 7);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(doubleOverloads, method => method.GetParameters().Length == 9);
        }

        [Fact]
        public void PlotStems_ShouldExposeSevenSByteArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] sbyteOverloads = overloads.Where(method => HasArrayParameter(method, typeof(sbyte))).ToArray();
            Assert.True(sbyteOverloads.Length >= 7);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(sbyteOverloads, method => method.GetParameters().Length == 9);
        }

        [Fact]
        public void PlotStems_ShouldExposeAtLeastFiveByteArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] byteOverloads = overloads.Where(method => HasArrayParameter(method, typeof(byte))).ToArray();
            Assert.True(byteOverloads.Length >= 5);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(byteOverloads, method => method.GetParameters().Length == 7);
        }

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

        private static MethodInfo[] GetPublicStaticMethods(string name)
        {
            return typeof(ImPlot)
                .GetMethods(BindingFlags.Public | BindingFlags.Static)
                .Where(method => method.Name == name)
                .ToArray();
        }

        private static bool HasByRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsByRef && (parameter.ParameterType.GetElementType() == elementType));
        }

        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && (parameter.ParameterType.GetElementType() == elementType));
        }
    }
}
