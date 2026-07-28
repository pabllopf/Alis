// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP17Tests.cs
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
    /// The im plot 17 tests class
    /// </summary>
    public class ImPlotP17Tests
    {
        /// <summary>
        /// Tests that plot bars s 64 ptr s 64 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotBars_S64PtrS64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int),
                typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 64 ptr u 64 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotBars_U64PtrU64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 64 ptr u 64 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotBars_U64PtrU64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 64 ptr u 64 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotBars_U64PtrU64Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars u 64 ptr u 64 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotBars_U64PtrU64Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars g default should be void
        /// </summary>
        [Fact]
        public void PlotBarsG_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarsG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars g with flags should be void
        /// </summary>
        [Fact]
        public void PlotBarsG_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBarsG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int), typeof(double),
                typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital float ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_FloatPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital float ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_FloatPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital float ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_FloatPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital float ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_FloatPtr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital double ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_DoublePtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital double ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_DoublePtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital double ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_DoublePtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital double ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_DoublePtr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 8 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 8 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 8 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S8Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 8 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S8Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 8 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 8 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 8 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U8Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 8 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U8Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 16 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 16 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 16 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S16Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 16 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S16Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 16 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 16 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 16 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U16Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 16 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U16Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 32 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 32 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 32 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S32Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 32 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S32Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 32 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 32 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 32 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U32Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 32 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U32Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 64 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 64 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 64 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S64Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital s 64 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_S64Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 64 ptr default should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 64 ptr with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 64 ptr with flags offset should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U64Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital u 64 ptr full should be void
        /// </summary>
        [Fact]
        public void PlotDigital_U64Ptr_Full_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigital", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(ImPlotDigitalFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital g default should be void
        /// </summary>
        [Fact]
        public void PlotDigitalG_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigitalG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot digital g with flags should be void
        /// </summary>
        [Fact]
        public void PlotDigitalG_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDigitalG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(int),
                typeof(ImPlotDigitalFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot dummy default should be void
        /// </summary>
        [Fact]
        public void PlotDummy_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDummy", new[]
            {
                typeof(string)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot dummy with flags should be void
        /// </summary>
        [Fact]
        public void PlotDummy_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotDummy", new[]
            {
                typeof(string), typeof(ImPlotDummyFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars float ptr float ptr float ptr int default should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_FloatPtrFloatPtrFloatPtrInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot error bars float ptr float ptr float ptr int with flags should be void
        /// </summary>
        [Fact]
        public void PlotErrorBars_FloatPtrFloatPtrFloatPtrInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot bars should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotBars_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBars");

            Assert.True(overloads.Length >= 5);
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(long)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ulong)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotBarsFlags)));
        }

        /// <summary>
        /// Tests that plot bars should accept ref long and ref u long families
        /// </summary>
        [Fact]
        public void PlotBars_ShouldAcceptRefLongAndRefULongFamilies()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBars");

            Assert.Contains(overloads, m => m.GetParameters().Count(p => p.ParameterType.IsByRef) == 2
                && m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(long)));
            Assert.Contains(overloads, m => m.GetParameters().Count(p => p.ParameterType.IsByRef) == 2
                && m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot bars g should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotBarsG_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBarsG");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, m => m.GetParameters().Length == 5);
            Assert.Contains(overloads, m => m.GetParameters().Length == 6);
        }

        /// <summary>
        /// Tests that plot bars g should accept int ptr and im plot bars flags
        /// </summary>
        [Fact]
        public void PlotBarsG_ShouldAcceptIntPtrAndImPlotBarsFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBarsG");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(IntPtr)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotBarsFlags)));
        }

        /// <summary>
        /// Tests that plot digital should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotDigital_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDigital");

            Assert.True(overloads.Length >= 36);
        }

        /// <summary>
        /// Tests that plot digital should accept all primitive by ref types
        /// </summary>
        [Fact]
        public void PlotDigital_ShouldAcceptAllPrimitiveByRefTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDigital");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(double)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(sbyte)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(byte)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(short)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ushort)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(int)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(uint)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(long)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot digital overloads should have 4 overloads per type
        /// </summary>
        [Fact]
        public void PlotDigital_OverloadsShouldHave4OverloadsPerType()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDigital");

            foreach (Type type in new[] { typeof(float), typeof(double), typeof(sbyte), typeof(byte), typeof(short), typeof(ushort), typeof(int), typeof(uint), typeof(long), typeof(ulong) })
            {
                int count = overloads.Count(m => m.GetParameters().Any(p =>
                    p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == type));
                Assert.True(count >= 4, $"Expected at least 4 overloads for {type.Name}, got {count}");
            }
        }

        /// <summary>
        /// Tests that plot digital g should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotDigitalG_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDigitalG");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, m => m.GetParameters().Length == 4);
            Assert.Contains(overloads, m => m.GetParameters().Length == 5);
        }

        /// <summary>
        /// Tests that plot digital g should accept int ptr and im plot digital flags
        /// </summary>
        [Fact]
        public void PlotDigitalG_ShouldAcceptIntPtrAndImPlotDigitalFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDigitalG");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(IntPtr)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotDigitalFlags)));
        }

        /// <summary>
        /// Tests that plot dummy should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotDummy_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDummy");

            Assert.True(overloads.Length >= 2);
            Assert.Contains(overloads, m => m.GetParameters().Length == 1);
            Assert.Contains(overloads, m => m.GetParameters().Length == 2);
        }

        /// <summary>
        /// Tests that plot dummy should accept string and flags
        /// </summary>
        [Fact]
        public void PlotDummy_ShouldAcceptStringAndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotDummy");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(string)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotDummyFlags)));
        }

        /// <summary>
        /// Tests that plot error bars should expose expected overload count
        /// </summary>
        [Fact]
        public void PlotErrorBars_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.True(overloads.Length >= 2);
        }

        /// <summary>
        /// Tests that plot error bars should accept by ref float and flags
        /// </summary>
        [Fact]
        public void PlotErrorBars_ShouldAcceptByRefFloatAndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.Contains(overloads, m => m.GetParameters().Count(p => p.ParameterType.IsByRef) >= 3
                && m.GetParameters().All(p => !p.ParameterType.IsByRef || p.ParameterType.GetElementType() == typeof(float)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotErrorBarsFlags)));
        }

        /// <summary>
        /// Tests that plot error bars should accept by ref float with count 4
        /// </summary>
        [Fact]
        public void PlotErrorBars_ShouldAcceptByRefFloatWithCount4()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(float).MakeByRefType()));
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
