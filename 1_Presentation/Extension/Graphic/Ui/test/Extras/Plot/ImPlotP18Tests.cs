// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP18Tests.cs
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
using Alis.Core.Aspect.Math.Vector;
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    /// The im plot 18 tests class
    /// </summary>
    public class ImPlotP18Tests
    {
        /// <summary>
        /// Tests that plot histogram 2 d should expose all overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeAllOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.True(overloads.Length >= 32);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref byte overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefByteOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] byteOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(byte)))
                .ToArray();
            Assert.True(byteOverloads.Length >= 2);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref short overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefShortOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] shortOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(short)))
                .ToArray();
            Assert.True(shortOverloads.Length >= 5);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(shortOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref u short overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefUShortOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] ushortOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ushort)))
                .ToArray();
            Assert.True(ushortOverloads.Length >= 5);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(ushortOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref int overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefIntOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] intOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(int)))
                .ToArray();
            Assert.True(intOverloads.Length >= 5);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(intOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref u int overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefUIntOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] uintOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(uint)))
                .ToArray();
            Assert.True(uintOverloads.Length >= 5);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(uintOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref long overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefLongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] longOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(long)))
                .ToArray();
            Assert.True(longOverloads.Length >= 5);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(longOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose ref u long overloads
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeRefULongOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            MethodInfo[] ulongOverloads = overloads.Where(m =>
                m.GetParameters().Any(p => p.ParameterType.IsByRef && p.ParameterType.HasElementType && p.ParameterType.GetElementType() == typeof(ulong)))
                .ToArray();
            Assert.True(ulongOverloads.Length >= 5);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 6);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 7);
            Assert.Contains(ulongOverloads, m => m.GetParameters().Length == 8);
        }

        /// <summary>
        /// Tests that plot histogram 2 d all overloads should return double
        /// </summary>
        [Fact]
        public void PlotHistogram2D_AllOverloads_ShouldReturnDouble()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.All(overloads, m => Assert.Equal(typeof(double), m.ReturnType));
        }

        /// <summary>
        /// Tests that plot histogram 2 d all overloads should be public static
        /// </summary>
        [Fact]
        public void PlotHistogram2D_AllOverloads_ShouldBePublicStatic()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.All(overloads, m => Assert.True(m.IsPublic && m.IsStatic));
        }

        /// <summary>
        /// Tests that plot histogram 2 d all overloads should have string label id as first param
        /// </summary>
        [Fact]
        public void PlotHistogram2D_AllOverloads_ShouldHaveStringLabelIdAsFirstParam()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.All(overloads, m => Assert.Equal(typeof(string), m.GetParameters()[0].ParameterType));
        }

        /// <summary>
        /// Tests that plot histogram 2 d should accept im plot rect and flags
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldAcceptImPlotRectAndFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotRect)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotHistogramFlags)));
        }

        /// <summary>
        /// Tests that plot histogram 2 d should expose all expected ref types
        /// </summary>
        [Fact]
        public void PlotHistogram2D_ShouldExposeAllExpectedRefTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotHistogram2D");
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(byte)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(short)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(ushort)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(int)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(uint)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(long)));
            Assert.Contains(overloads, m => HasRefParameter(m, typeof(ulong)));
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref byte minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefByte_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref byte full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefByte_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref short minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefShort_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref short full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefShort_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u short minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefUShort_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u short full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefUShort_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref int minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefInt_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref int full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefInt_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u int minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefUInt_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u int full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefUInt_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref long minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefLong_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref long full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefLong_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u long minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefULong_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot histogram 2 d ref u long full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotHistogram2D_RefULong_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotHistogram2D", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(int),
                typeof(int), typeof(int), typeof(ImPlotRect), typeof(ImPlotHistogramFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(double), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot image should expose all overloads
        /// </summary>
        [Fact]
        public void PlotImage_ShouldExposeAllOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.True(overloads.Length >= 5);
        }

        /// <summary>
        /// Tests that plot image all overloads should return void
        /// </summary>
        [Fact]
        public void PlotImage_AllOverloads_ShouldReturnVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.All(overloads, m => Assert.Equal(typeof(void), m.ReturnType));
        }

        /// <summary>
        /// Tests that plot image all overloads should be public static
        /// </summary>
        [Fact]
        public void PlotImage_AllOverloads_ShouldBePublicStatic()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.All(overloads, m => Assert.True(m.IsPublic && m.IsStatic));
        }

        /// <summary>
        /// Tests that plot image all overloads should have string label id as first param
        /// </summary>
        [Fact]
        public void PlotImage_AllOverloads_ShouldHaveStringLabelIdAsFirstParam()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.All(overloads, m => Assert.Equal(typeof(string), m.GetParameters()[0].ParameterType));
        }

        /// <summary>
        /// Tests that plot image should accept int ptr and im plot point and vector 2 f
        /// </summary>
        [Fact]
        public void PlotImage_ShouldAcceptIntPtrAndImPlotPointAndVector2F()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(IntPtr)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotPoint)));
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(Vector2F)));
        }

        /// <summary>
        /// Tests that plot image should accept vector 4 f
        /// </summary>
        [Fact]
        public void PlotImage_ShouldAcceptVector4F()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(Vector4F)));
        }

        /// <summary>
        /// Tests that plot image should accept im plot image flags
        /// </summary>
        [Fact]
        public void PlotImage_ShouldAcceptImPlotImageFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotImage");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotImageFlags)));
        }

        /// <summary>
        /// Tests that plot image minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotImage_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotImage", new[]
            {
                typeof(string), typeof(IntPtr), typeof(ImPlotPoint), typeof(ImPlotPoint)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot image with uv 0 should have correct signature
        /// </summary>
        [Fact]
        public void PlotImage_WithUv0_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotImage", new[]
            {
                typeof(string), typeof(IntPtr), typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(Vector2F)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot image with uv 0 uv 1 should have correct signature
        /// </summary>
        [Fact]
        public void PlotImage_WithUv0Uv1_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotImage", new[]
            {
                typeof(string), typeof(IntPtr), typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(Vector2F), typeof(Vector2F)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot image with uv 0 uv 1 tint col should have correct signature
        /// </summary>
        [Fact]
        public void PlotImage_WithUv0Uv1TintCol_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotImage", new[]
            {
                typeof(string), typeof(IntPtr), typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(Vector2F), typeof(Vector2F), typeof(Vector4F)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot image full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotImage_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotImage", new[]
            {
                typeof(string), typeof(IntPtr), typeof(ImPlotPoint), typeof(ImPlotPoint),
                typeof(Vector2F), typeof(Vector2F), typeof(Vector4F), typeof(ImPlotImageFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines should expose all overloads
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeAllOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.True(overloads.Length >= 15);
        }

        /// <summary>
        /// Tests that plot inf lines all overloads should return void
        /// </summary>
        [Fact]
        public void PlotInfLines_AllOverloads_ShouldReturnVoid()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.All(overloads, m => Assert.Equal(typeof(void), m.ReturnType));
        }

        /// <summary>
        /// Tests that plot inf lines all overloads should be public static
        /// </summary>
        [Fact]
        public void PlotInfLines_AllOverloads_ShouldBePublicStatic()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.All(overloads, m => Assert.True(m.IsPublic && m.IsStatic));
        }

        /// <summary>
        /// Tests that plot inf lines all overloads should have string label id as first param
        /// </summary>
        [Fact]
        public void PlotInfLines_AllOverloads_ShouldHaveStringLabelIdAsFirstParam()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.All(overloads, m => Assert.Equal(typeof(string), m.GetParameters()[0].ParameterType));
        }

        /// <summary>
        /// Tests that plot inf lines should expose float array overloads
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeFloatArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            MethodInfo[] floatOverloads = overloads.Where(m => HasArrayParameter(m, typeof(float))).ToArray();
            Assert.True(floatOverloads.Length >= 4);
            Assert.Contains(floatOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(floatOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(floatOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(floatOverloads, m => m.GetParameters().Length == 6);
        }

        /// <summary>
        /// Tests that plot inf lines should expose double array overloads
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeDoubleArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            MethodInfo[] doubleOverloads = overloads.Where(m => HasArrayParameter(m, typeof(double))).ToArray();
            Assert.True(doubleOverloads.Length >= 4);
            Assert.Contains(doubleOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(doubleOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(doubleOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(doubleOverloads, m => m.GetParameters().Length == 6);
        }

        /// <summary>
        /// Tests that plot inf lines should expose s byte array overloads
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeSByteArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            MethodInfo[] sbyteOverloads = overloads.Where(m => HasArrayParameter(m, typeof(sbyte))).ToArray();
            Assert.True(sbyteOverloads.Length >= 4);
            Assert.Contains(sbyteOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(sbyteOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(sbyteOverloads, m => m.GetParameters().Length == 5);
            Assert.Contains(sbyteOverloads, m => m.GetParameters().Length == 6);
        }

        /// <summary>
        /// Tests that plot inf lines should expose byte array overloads
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeByteArrayOverloads()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            MethodInfo[] byteOverloads = overloads.Where(m => HasArrayParameter(m, typeof(byte))).ToArray();
            Assert.True(byteOverloads.Length >= 3);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 3);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 4);
            Assert.Contains(byteOverloads, m => m.GetParameters().Length == 5);
        }

        /// <summary>
        /// Tests that plot inf lines should accept im plot inf lines flags
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldAcceptImPlotInfLinesFlags()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.Contains(overloads, m => m.GetParameters().Any(p => p.ParameterType == typeof(ImPlotInfLinesFlags)));
        }

        /// <summary>
        /// Tests that plot inf lines should accept offset and stride
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldAcceptOffsetAndStride()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.Contains(overloads, m =>
            {
                int intCount = m.GetParameters().Count(p => p.ParameterType == typeof(int));
                return intCount >= 2;
            });
        }

        /// <summary>
        /// Tests that plot inf lines should expose all expected array types
        /// </summary>
        [Fact]
        public void PlotInfLines_ShouldExposeAllExpectedArrayTypes()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(float)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(double)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(sbyte)));
            Assert.Contains(overloads, m => HasArrayParameter(m, typeof(byte)));
        }

        /// <summary>
        /// Tests that plot inf lines float array minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_FloatArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(float[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines float array full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_FloatArray_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(float[]), typeof(int),
                typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines double array minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_DoubleArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(double[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines double array full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_DoubleArray_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(double[]), typeof(int),
                typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines s byte array minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_SByteArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines s byte array full overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_SByteArray_FullOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int),
                typeof(ImPlotInfLinesFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines byte array minimal overload should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_ByteArray_MinimalOverload_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(byte[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines byte array with flags offset should have correct signature
        /// </summary>
        [Fact]
        public void PlotInfLines_ByteArray_WithFlagsOffset_ShouldHaveCorrectSignature()
        {
            MethodInfo method = GetPublicStaticMethod("PlotInfLines", new[]
            {
                typeof(string), typeof(byte[]), typeof(int),
                typeof(ImPlotInfLinesFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        /// <summary>
        /// Tests that plot inf lines all overloads should have correct method name
        /// </summary>
        [Fact]
        public void PlotInfLines_AllOverloadsShouldHaveCorrectMethodName()
        {
            MethodInfo[] overloads = GetPublicStaticMethods("PlotInfLines");
            Assert.All(overloads, m => Assert.Equal("PlotInfLines", m.Name));
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
        /// Hases the array parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasArrayParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter => parameter.ParameterType.IsArray && parameter.ParameterType.GetElementType() == elementType);
        }

        /// <summary>
        /// Hases the ref parameter using the specified method
        /// </summary>
        /// <param name="method">The method</param>
        /// <param name="elementType">The element type</param>
        /// <returns>The bool</returns>
        private static bool HasRefParameter(MethodInfo method, Type elementType)
        {
            return method.GetParameters().Any(parameter =>
                parameter.ParameterType.IsByRef &&
                parameter.ParameterType.HasElementType &&
                parameter.ParameterType.GetElementType() == elementType);
        }
    }
}
