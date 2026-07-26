// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP16Tests.cs
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
    public class ImPlotP16Tests
    {
        [Fact]
        public void PlotBars_U32PtrInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrInt_WithShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrInt_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrInt_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_WithShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrInt_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_WithBarSize_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_WithShift_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U64PtrInt_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_FloatPtrFloatPtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_FloatPtrFloatPtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_FloatPtrFloatPtr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_FloatPtrFloatPtr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_DoublePtrDoublePtr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_DoublePtrDoublePtr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_DoublePtrDoublePtr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_DoublePtrDoublePtr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S8PtrS8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S8PtrS8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S8PtrS8Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S8PtrS8Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U8PtrU8Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U8PtrU8Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U8PtrU8Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U8PtrU8Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S16PtrS16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S16PtrS16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S16PtrS16Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S16PtrS16Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U16PtrU16Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U16PtrU16Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U16PtrU16Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U16PtrU16Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S32PtrS32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S32PtrS32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S32PtrS32Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S32PtrS32Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrU32Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrU32Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrU32Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_U32PtrU32Ptr_WithStride_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrS64Ptr_Default_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(double)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrS64Ptr_WithFlags_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_S64PtrS64Ptr_WithOffset_ShouldBeVoid()
        {
            MethodInfo method = GetPublicStaticMethod("PlotBars", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int), typeof(double), typeof(ImPlotBarsFlags), typeof(int)
            });

            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotBars_AllRefPtrOverloads_ShouldIncludeAllPrimitiveTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBars");

            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(double)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(sbyte)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(byte)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(short)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ushort)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(int)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(uint)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(long)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p =>
                p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ulong)));
        }

        [Fact]
        public void PlotBars_ArrayOverloads_ShouldIncludeU32S64U64()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotBars");

            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(uint[])));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(long[])));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ulong[])));
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
    }
}
