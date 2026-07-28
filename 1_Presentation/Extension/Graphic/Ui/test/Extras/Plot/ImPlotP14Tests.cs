// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP14Tests.cs
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
    /// The im plot 14 tests class
    /// </summary>
    public class ImPlotP14Tests
    {
        /// <summary>
        /// Tests that plot stems should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.True(overloads.Length >= 70);
        }

        /// <summary>
        /// Tests that plot stems u 8 ptr int with offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8PtrInt_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ptr int with offset and stride should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8PtrInt_WithOffsetAndStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 32 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_S32_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(int[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 32 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_U32_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 64 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_S64_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 default should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with ref and scale should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithRefAndScale_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with ref scale and start should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithRefScaleAndStart_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with ref scale start and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithRefScaleStartAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with ref scale start flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithRefScaleStartFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 64 with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_U64_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems float ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems float ref with ref and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_WithRefAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems float ref with ref flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_WithRefFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems float ref with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_FloatRef_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems double ref default should be void
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems double ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems double ref with ref and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_WithRefAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems double ref with ref flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_WithRefFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems double ref with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_DoubleRef_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 8 ref default should be void
        /// </summary>
        [Fact]
        public void PlotStems_S8Ref_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 8 ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_S8Ref_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 8 ref with ref and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_S8Ref_WithRefAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 8 ref with ref flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_S8Ref_WithRefFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 8 ref with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_S8Ref_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ref default should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8Ref_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8Ref_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ref with ref and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8Ref_WithRefAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ref with ref flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8Ref_WithRefFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 8 ref with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_U8Ref_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 ref default should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16Ref_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16Ref_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 ref with ref and flags should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16Ref_WithRefAndFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 ref with ref flags and offset should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16Ref_WithRefFlagsAndOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems s 16 ref with full should be void
        /// </summary>
        [Fact]
        public void PlotStems_S16Ref_WithFull_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotStemsFlags), typeof(int), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 ref default should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16Ref_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems u 16 ref with ref should be void
        /// </summary>
        [Fact]
        public void PlotStems_U16Ref_WithRef_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStems", new[] { typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(double) });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot stems should expose all expected array types
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ushort)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(int)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(uint)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(long)));
            Assert.Contains(overloads, method => HasArrayParameter(method, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot stems should expose all expected by ref numeric families
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeAllExpectedByRefNumericFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(float)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(double)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(sbyte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(byte)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(short)));
            Assert.Contains(overloads, method => HasByRefParameter(method, typeof(ushort)));
        }

        /// <summary>
        /// Tests that plot stems should expose flags offset and stride overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeFlagsOffsetAndStrideOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            Assert.Contains(overloads, method => method.GetParameters().Any(parameter => parameter.ParameterType == typeof(ImPlotStemsFlags)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 8) && (method.GetParameters()[7].ParameterType == typeof(int)));
            Assert.Contains(overloads, method => (method.GetParameters().Length >= 9) && (method.GetParameters()[8].ParameterType == typeof(int)));
        }

        /// <summary>
        /// Tests that plot stems should expose seven short overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeSevenShortOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] shortOverloads = overloads.Where(method => HasArrayParameter(method, typeof(short))).ToArray();
            Assert.True(shortOverloads.Length >= 7);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(shortOverloads, method => method.GetParameters().Length == 9);
        }

        /// <summary>
        /// Tests that plot stems should expose seven int overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeSevenIntOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] intOverloads = overloads.Where(method => HasArrayParameter(method, typeof(int))).ToArray();
            Assert.True(intOverloads.Length >= 7);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(intOverloads, method => method.GetParameters().Length == 9);
        }

        /// <summary>
        /// Tests that plot stems should expose seven long overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeSevenLongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] longOverloads = overloads.Where(method => HasArrayParameter(method, typeof(long))).ToArray();
            Assert.True(longOverloads.Length >= 7);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(longOverloads, method => method.GetParameters().Length == 9);
        }

        /// <summary>
        /// Tests that plot stems should expose seven ulong overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeSevenUlongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] ulongOverloads = overloads.Where(method => HasArrayParameter(method, typeof(ulong))).ToArray();
            Assert.True(ulongOverloads.Length >= 7);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 3);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 8);
            Assert.Contains(ulongOverloads, method => method.GetParameters().Length == 9);
        }

        /// <summary>
        /// Tests that plot stems should expose five by ref float overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeFiveByRefFloatOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] refFloatOverloads = overloads.Where(method => HasByRefParameter(method, typeof(float))).ToArray();
            Assert.True(refFloatOverloads.Length >= 4);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(refFloatOverloads, method => method.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot stems should expose five by ref double overloads
        /// </summary>
        [Fact]
        public void PlotStems_ShouldExposeFiveByRefDoubleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStems");
            MethodInfo[] refDoubleOverloads = overloads.Where(method => HasByRefParameter(method, typeof(double))).ToArray();
            Assert.True(refDoubleOverloads.Length >= 5);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 4);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 5);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 6);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 7);
            Assert.Contains(refDoubleOverloads, method => method.GetParameters().Length == 8);
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
