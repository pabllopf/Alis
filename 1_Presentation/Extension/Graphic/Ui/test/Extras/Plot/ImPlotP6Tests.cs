// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP6Tests.cs
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
    public class ImPlotP6Tests
    {
        [Fact]
        public void PlotInfLines_BytePtr_FullOverload_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_ShortPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(short[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_ShortPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_ShortPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_ShortPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UshortPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UshortPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UshortPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UshortPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_IntPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(int[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_IntPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_IntPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_IntPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UintPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(uint[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UintPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UintPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UintPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_LongPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(long[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_LongPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_LongPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_LongPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UlongPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UlongPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(ImPlotInfLinesFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UlongPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_UlongPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            Assert.True(overloads.Length >= 25);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeByteArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] byteOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(byte[]))).ToArray();

            Assert.True(byteOverloads.Length >= 1);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeShortArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] shortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(short[]))).ToArray();

            Assert.True(shortOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeUshortArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] ushortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ushort[]))).ToArray();

            Assert.True(ushortOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeIntArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] intOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(int[]))).ToArray();

            Assert.True(intOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeUintArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] uintOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(uint[]))).ToArray();

            Assert.True(uintOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeLongArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] longOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(long[]))).ToArray();

            Assert.True(longOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_ShouldExposeUlongArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            MethodInfo[] ulongOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ulong[]))).ToArray();

            Assert.True(ulongOverloads.Length >= 4);
        }

        [Fact]
        public void PlotInfLines_AllOverloads_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            Assert.All(overloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotInfLines_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ulong)));
        }

        [Fact]
        public void PlotLine_FloatArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_FloatArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_FloatArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_FloatArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_FloatArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_FloatArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_DoubleArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_SbyteArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ByteArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShortArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShortArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShortArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShortArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShortArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotLine_ShouldExposeFloatArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] floatOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(float[]))).ToArray();

            Assert.True(floatOverloads.Length >= 6);
        }

        [Fact]
        public void PlotLine_ShouldExposeDoubleArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] doubleOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(double[]))).ToArray();

            Assert.True(doubleOverloads.Length >= 6);
        }

        [Fact]
        public void PlotLine_ShouldExposeSbyteArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] sbyteOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(sbyte[]))).ToArray();

            Assert.True(sbyteOverloads.Length >= 6);
        }

        [Fact]
        public void PlotLine_ShouldExposeByteArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] byteOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(byte[]))).ToArray();

            Assert.True(byteOverloads.Length >= 6);
        }

        [Fact]
        public void PlotLine_ShouldExposeShortArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] shortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(short[]))).ToArray();

            Assert.True(shortOverloads.Length >= 5);
        }

        [Fact]
        public void PlotLine_FloatArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] floatOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(float[]))).ToArray();

            Assert.All(floatOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotLine_DoubleArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] doubleOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(double[]))).ToArray();

            Assert.All(doubleOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotLine_SbyteArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] sbyteOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(sbyte[]))).ToArray();

            Assert.All(sbyteOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotLine_ByteArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] byteOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(byte[]))).ToArray();

            Assert.All(byteOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotLine_ShortArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] shortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(short[]))).ToArray();

            Assert.All(shortOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
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

        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
        }
    }
}
