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
        /// Tests that plot line should expose short array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeShortArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] shortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(short[]))).ToArray();

            Assert.True(shortOverloads.Length >= 1);
        }

        /// <summary>
        /// Tests that plot line should expose ushort array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeUshortArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] ushortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ushort[]))).ToArray();

            Assert.True(ushortOverloads.Length >= 6);
        }

        /// <summary>
        /// Tests that plot line should expose int array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeIntArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] intOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(int[]))).ToArray();

            Assert.True(intOverloads.Length >= 6);
        }

        /// <summary>
        /// Tests that plot line should expose uint array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeUintArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] uintOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(uint[]))).ToArray();

            Assert.True(uintOverloads.Length >= 6);
        }

        /// <summary>
        /// Tests that plot line should expose long array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeLongArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] longOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(long[]))).ToArray();

            Assert.True(longOverloads.Length >= 6);
        }

        /// <summary>
        /// Tests that plot line should expose ulong array family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeUlongArrayFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] ulongOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ulong[]))).ToArray();

            Assert.True(ulongOverloads.Length >= 6);
        }

        /// <summary>
        /// Tests that plot line should expose all expected array types
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot line should expose by ref float family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefFloatFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refFloatOverloads = overloads.Where(method => HasByRefParameter(method, typeof(float))).ToArray();

            Assert.True(refFloatOverloads.Length >= 4);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose by ref double family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefDoubleFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refDoubleOverloads = overloads.Where(method => HasByRefParameter(method, typeof(double))).ToArray();

            Assert.True(refDoubleOverloads.Length >= 4);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose by ref sbyte family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefSbyteFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refSbyteOverloads = overloads.Where(method => HasByRefParameter(method, typeof(sbyte))).ToArray();

            Assert.True(refSbyteOverloads.Length >= 4);
            Assert.Contains(refSbyteOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refSbyteOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refSbyteOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refSbyteOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose by ref byte family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefByteFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refByteOverloads = overloads.Where(method => HasByRefParameter(method, typeof(byte))).ToArray();

            Assert.True(refByteOverloads.Length >= 4);
            Assert.Contains(refByteOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refByteOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refByteOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refByteOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose by ref short family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefShortFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refShortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(short))).ToArray();

            Assert.True(refShortOverloads.Length >= 4);
            Assert.Contains(refShortOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refShortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refShortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refShortOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose by ref ushort family
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeByRefUshortFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refUshortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(ushort))).ToArray();

            Assert.True(refUshortOverloads.Length >= 4);
            Assert.Contains(refUshortOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refUshortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refUshortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refUshortOverloads, method => method.GetParameters().Length == 7);
        }

        /// <summary>
        /// Tests that plot line should expose all expected by ref types
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeAllExpectedByRefTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ushort)));
        }

        /// <summary>
        /// Tests that plot line should expose flags offset and stride overloads
        /// </summary>
        [Fact]
        public void PlotLine_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            Assert.Contains(overloads, method => method.GetParameters().Any(p => p.ParameterType == typeof(ImPlotLineFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 7) && (method.GetParameters()[6].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 8) && (method.GetParameters()[7].ParameterType == typeof(int)));
        }

        /// <summary>
        /// Tests that plot line short array full overload should be void
        /// </summary>
        [Fact]
        public void PlotLine_ShortArray_FullOverload_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array default should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array default should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line int array with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array default should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line uint array with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_UintArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array default should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line long array with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array default should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ulong array with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_UlongArray_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref float default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefFloat_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref float with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefFloat_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref float with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefFloat_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref float with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefFloat_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref double default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefDouble_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref double with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefDouble_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref double with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefDouble_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref double with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefDouble_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref sbyte default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefSbyte_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref sbyte with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefSbyte_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref sbyte with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefSbyte_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref sbyte with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefSbyte_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref byte default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefByte_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref byte with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefByte_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref byte with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefByte_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref byte with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefByte_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref short default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefShort_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref short with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefShort_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref short with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefShort_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref short with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefShort_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref ushort default should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefUshort_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref ushort with flags should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefUshort_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref ushort with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefUshort_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ref ushort with all should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefUshort_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotLine", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotLineFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot line ushort array return type should be void
        /// </summary>
        [Fact]
        public void PlotLine_UshortArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] ushortOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ushort[]))).ToArray();

            Assert.All(ushortOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line int array return type should be void
        /// </summary>
        [Fact]
        public void PlotLine_IntArray_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] intOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(int[]))).ToArray();

            Assert.All(intOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line long array uint array ulong array return types should be void
        /// </summary>
        [Fact]
        public void PlotLine_LongArray_UintArray_UlongArray_ReturnTypes_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] longOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(long[]))).ToArray();
            MethodInfo[] uintOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(uint[]))).ToArray();
            MethodInfo[] ulongOverloads = overloads.Where(method => method.GetParameters().Any(p => p.ParameterType == typeof(ulong[]))).ToArray();

            Assert.All(longOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
            Assert.All(uintOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
            Assert.All(ulongOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line ref float return type should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefFloat_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refFloatOverloads = overloads.Where(method => HasByRefParameter(method, typeof(float))).ToArray();

            Assert.All(refFloatOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line ref double return type should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefDouble_ReturnType_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refDoubleOverloads = overloads.Where(method => HasByRefParameter(method, typeof(double))).ToArray();

            Assert.All(refDoubleOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line ref sbyte ref byte return types should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefSbyte_RefByte_ReturnTypes_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refSbyteOverloads = overloads.Where(method => HasByRefParameter(method, typeof(sbyte))).ToArray();
            MethodInfo[] refByteOverloads = overloads.Where(method => HasByRefParameter(method, typeof(byte))).ToArray();

            Assert.All(refSbyteOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
            Assert.All(refByteOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        /// <summary>
        /// Tests that plot line ref short ref ushort return types should be void
        /// </summary>
        [Fact]
        public void PlotLine_RefShort_RefUshort_ReturnTypes_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotLine");

            MethodInfo[] refShortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(short))).ToArray();
            MethodInfo[] refUshortOverloads = overloads.Where(method => HasByRefParameter(method, typeof(ushort))).ToArray();

            Assert.All(refShortOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
            Assert.All(refUshortOverloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

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
