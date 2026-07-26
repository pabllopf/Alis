// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP3Tests.cs
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
    public class ImPlotP3Tests
    {
        [Fact]
        public void PlotErrorBars_FloatPtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_FloatPtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S8Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S8Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U8Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U8Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(byte).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S16Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S16Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(short).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U16Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U16Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(ushort).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S32Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S32Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U32Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U32Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(uint).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S64Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S64Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(long).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U64Ptr_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_U64Ptr_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(ulong).MakeByRefType(), typeof(int), typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_FloatPtrNegPos_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_FloatPtrNegPos_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_FloatPtrNegPos_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_FloatPtrNegPos_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(),
                typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtrNegPos_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtrNegPos_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtrNegPos_WithFlagsOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_DoublePtrNegPos_WithAll_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(),
                typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int),
                typeof(ImPlotErrorBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_S8PtrNegPos_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotErrorBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeExpectedOverloadCount()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.True(overloads.Length >= 47);
        }

        [Fact]
        public void PlotErrorBars_AllOverloads_ShouldBeVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.All(overloads, method => Assert.Equal(typeof(void), method.ReturnType));
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeFloatPtrFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] floatOverloads = overloads.Where(m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float))).ToArray();

            Assert.True(floatOverloads.Length >= 6);
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeDoublePtrFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] doubleOverloads = overloads.Where(m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(double))).ToArray();

            Assert.True(doubleOverloads.Length >= 4);
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeS8PtrFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] s8Overloads = overloads.Where(m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(sbyte))).ToArray();

            Assert.True(s8Overloads.Length >= 5);
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeU8PtrFamily()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] u8Overloads = overloads.Where(m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(byte))).ToArray();

            Assert.True(u8Overloads.Length >= 4);
        }

        [Fact]
        public void PlotErrorBars_ShouldExposeAllNumericPtrTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(float)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(double)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(sbyte)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(byte)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(short)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(ushort)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(int)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(uint)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(long)));
            Assert.Contains(overloads, m => HasByRefParameter(m, typeof(ulong)));
        }

        [Fact]
        public void PlotErrorBars_ShouldAcceptImPlotErrorBarsFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] withFlags = overloads.Where(m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotErrorBarsFlags))).ToArray();

            Assert.True(withFlags.Length >= 12);
        }

        [Fact]
        public void PlotErrorBars_OverloadsWithOffset_ShouldExist()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] withOffset = overloads.Where(m => m.GetParameters().Any(p =>
                p.Name != null && p.Name.Contains("offset"))).ToArray();

            Assert.True(withOffset.Length >= 12);
        }

        [Fact]
        public void PlotErrorBars_OverloadsWithStride_ShouldExist()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotErrorBars");

            MethodInfo[] withStride = overloads.Where(m => m.GetParameters().Any(p =>
                p.Name != null && p.Name.Contains("stride"))).ToArray();

            Assert.True(withStride.Length >= 10);
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
            return method.GetParameters().Any(p =>
                p.ParameterType.IsByRef &&
                p.ParameterType.HasElementType &&
                p.ParameterType.GetElementType() == elementType);
        }
    }
}
