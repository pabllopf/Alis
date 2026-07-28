// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP7Tests.cs
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
    /// The im plot tests class
    /// </summary>
    public class ImPlotP7Tests
    {
        /// <summary>
        /// Tests that plot scatter u 8 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U8Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 16 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S16Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 16 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U16Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 32 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S32Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 32 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U32Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter s 64 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_S64Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array with xscale should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_WithXscale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array with xscale xstart should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_WithXscaleXstart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter u 64 array full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_U64Array_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref float default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefFloat_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref float with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefFloat_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref float with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefFloat_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref float full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefFloat_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref double default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefDouble_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref double with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefDouble_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref double with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefDouble_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref double full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefDouble_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref s byte default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefSByte_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref s byte with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefSByte_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref s byte with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefSByte_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref s byte full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefSByte_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref byte default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefByte_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref byte with flags should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefByte_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref byte with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefByte_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref byte full should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefByte_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotScatterFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot scatter ref short default should be void
        /// </summary>
        [Fact]
        public void PlotScatter_RefShort_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotScatter", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
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
