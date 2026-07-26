// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP19Tests.cs
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
    public class ImPlotP19Tests
    {
        [Fact]
        public void PlotStairs_ShouldExposeAllOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.True(overloads.Length >= 99);
        }

        [Fact]
        public void PlotStairs_ShouldExposeByteArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] byteOverloads = overloads.Where(m => HasArrayParameter(m, typeof(byte))).ToArray();
            Assert.Equal(6, byteOverloads.Length);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeShortArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] shortOverloads = overloads.Where(m => HasArrayParameter(m, typeof(short))).ToArray();
            Assert.True(shortOverloads.Length >= 6);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeUShortArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] ushortOverloads = overloads.Where(m => HasArrayParameter(m, typeof(ushort))).ToArray();
            Assert.True(ushortOverloads.Length >= 6);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeIntArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] intOverloads = overloads.Where(m => HasArrayParameter(m, typeof(int))).ToArray();
            Assert.True(intOverloads.Length >= 6);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeUIntArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] uintOverloads = overloads.Where(m => HasArrayParameter(m, typeof(uint))).ToArray();
            Assert.True(uintOverloads.Length >= 6);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeLongArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] longOverloads = overloads.Where(m => HasArrayParameter(m, typeof(long))).ToArray();
            Assert.True(longOverloads.Length >= 6);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeULongArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] ulongOverloads = overloads.Where(m => HasArrayParameter(m, typeof(ulong))).ToArray();
            Assert.True(ulongOverloads.Length >= 6);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 8);
        }

        [Fact]
        public void PlotStairs_ShouldExposeRefFloatOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] refFloatOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(float)))
                .ToArray();
            Assert.True(refFloatOverloads.Length >= 4);
            Assert.Contains(refFloatOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(refFloatOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(refFloatOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(refFloatOverloads, m => m.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeRefDoubleOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] refDoubleOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(double)))
                .ToArray();
            Assert.True(refDoubleOverloads.Length >= 4);
            Assert.Contains(refDoubleOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(refDoubleOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(refDoubleOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(refDoubleOverloads, m => m.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeRefSByteOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] refSbyteOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(sbyte)))
                .ToArray();
            Assert.True(refSbyteOverloads.Length >= 4);
            Assert.Contains(refSbyteOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(refSbyteOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(refSbyteOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(refSbyteOverloads, m => m.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_ShouldExposeRefByteOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            MethodInfo[] refByteOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(byte)))
                .ToArray();
            Assert.True(refByteOverloads.Length >= 4);
            Assert.Contains(refByteOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(refByteOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(refByteOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(refByteOverloads, m => m.GetParameters().Length == 7);
        }

        [Fact]
        public void PlotStairs_AllOverloads_ShouldReturnVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.All(overloads, m => Assert.Equal(typeof(void), m.ReturnType));
        }

        [Fact]
        public void PlotStairs_AllOverloads_ShouldBePublicStatic()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.All(overloads, m => Assert.True(m.IsPublic && m.IsStatic));
        }

        [Fact]
        public void PlotStairs_AllOverloads_ShouldHaveStringLabelIdAsFirstParam()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.All(overloads, m => Assert.Equal(typeof(string), m.GetParameters()[0].ParameterType));
        }

        [Fact]
        public void PlotStairs_ShouldAcceptImPlotStairsFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotStairsFlags)));
        }

        [Fact]
        public void PlotStairs_ShouldAcceptOffsetAndStride()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(int)));
            Assert.Contains(overloads, m =>
            {
                int intCount = m.GetParameters().Count(p => p.ParameterType == typeof(int));
                return intCount >= 2;
            });
        }

        [Fact]
        public void PlotStairs_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(byte)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(short)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(ushort)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(int)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(uint)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(long)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(ulong)));
        }

        [Fact]
        public void PlotStairs_ShouldExposeAllExpectedRefTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotStairs");
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(float)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(double)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(sbyte)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(byte)));
        }

        [Fact]
        public void PlotStairs_ByteArray_OverloadWithFlags_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double), typeof(ImPlotStairsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ShortArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(short[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_UShortArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(ushort[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_IntArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(int[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_UIntArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(uint[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_LongArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(long[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ULongArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(ulong[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefFloat_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float).MakeByRefType(), typeof(float).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefDouble_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double).MakeByRefType(), typeof(double).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefSByte_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_RefByte_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
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

        private static bool HasRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsByRef &&
                parameter.ParameterType.HasElementType &&
                parameter.ParameterType.GetElementType() == elementType);
        }
    }
}
