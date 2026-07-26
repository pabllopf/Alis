// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotP8Tests.cs
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
    public class ImPlotP8Tests
    {
        [Fact]
        public void PlotShaded_SByteFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_SByteFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(), typeof(sbyte).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ByteDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ByteFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ByteFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ByteFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(), typeof(byte).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ShortDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ShortFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ShortFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ShortFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(), typeof(short).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UShortDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UShortFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UShortFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UShortFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(), typeof(ushort).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_IntDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_IntFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_IntFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_IntFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(), typeof(int).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UIntDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UIntFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UIntFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_UIntFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(), typeof(uint).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_LongDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_LongFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_LongFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_LongFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(), typeof(long).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ULongDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ULongFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ULongFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_ULongFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShaded", new[]
            {
                typeof(string), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(), typeof(ulong).MakeByRefType(),
                typeof(int), typeof(ImPlotShadedFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShadedG_Default_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShadedG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(IntPtr), typeof(IntPtr), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShadedG_Flags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotShadedG", new[]
            {
                typeof(string), typeof(IntPtr), typeof(IntPtr), typeof(IntPtr), typeof(IntPtr), typeof(int),
                typeof(ImPlotShadedFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatXscale_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatXscaleXstart_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_FloatFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(float[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleXscale_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleXscaleXstart_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_DoubleFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(double[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteXscale_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteXscaleXstart_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteFlags_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteFlagsOffset_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_SByteFlagsOffsetStride_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(sbyte[]), typeof(int), typeof(double), typeof(double),
                typeof(ImPlotStairsFlags), typeof(int), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ByteDefault_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(byte[]), typeof(int)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ByteXscale_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotStairs_ByteXscaleXstart_ShouldExist()
        {
            MethodInfo method = GetPublicStaticMethod("PlotStairs", new[]
            {
                typeof(string), typeof(byte[]), typeof(int), typeof(double), typeof(double)
            });
            Assert.NotNull(method);
            Assert.Equal(typeof(void), method.ReturnType);
        }

        [Fact]
        public void PlotShaded_SByteFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys1 = 2;
            sbyte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_SByteFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte xs = 1;
            sbyte ys1 = 2;
            sbyte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(sbyte)));
        }

        [Fact]
        public void PlotShaded_ByteDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys1 = 2;
            byte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_ByteFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys1 = 2;
            byte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_ByteFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys1 = 2;
            byte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_ByteFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            byte xs = 1;
            byte ys1 = 2;
            byte ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(byte)));
        }

        [Fact]
        public void PlotShaded_ShortDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys1 = 2;
            short ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_ShortFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys1 = 2;
            short ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_ShortFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys1 = 2;
            short ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_ShortFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            short xs = 1;
            short ys1 = 2;
            short ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(short)));
        }

        [Fact]
        public void PlotShaded_UShortDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 1;
            ushort ys1 = 2;
            ushort ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_UShortFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 1;
            ushort ys1 = 2;
            ushort ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_UShortFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 1;
            ushort ys1 = 2;
            ushort ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_UShortFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            ushort xs = 1;
            ushort ys1 = 2;
            ushort ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(ushort)));
        }

        [Fact]
        public void PlotShaded_IntDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys1 = 2;
            int ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_IntFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys1 = 2;
            int ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_IntFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys1 = 2;
            int ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_IntFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            int xs = 1;
            int ys1 = 2;
            int ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(int)));
        }

        [Fact]
        public void PlotShaded_UIntDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1;
            uint ys1 = 2;
            uint ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_UIntFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1;
            uint ys1 = 2;
            uint ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_UIntFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1;
            uint ys1 = 2;
            uint ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_UIntFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            uint xs = 1;
            uint ys1 = 2;
            uint ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(uint)));
        }

        [Fact]
        public void PlotShaded_LongDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys1 = 2;
            long ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_LongFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys1 = 2;
            long ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_LongFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys1 = 2;
            long ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_LongFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            long xs = 1;
            long ys1 = 2;
            long ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(long)));
        }

        [Fact]
        public void PlotShaded_ULongDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1;
            ulong ys1 = 2;
            ulong ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1));
        }

        [Fact]
        public void PlotShaded_ULongFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1;
            ulong ys1 = 2;
            ulong ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotShaded_ULongFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1;
            ulong ys1 = 2;
            ulong ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0));
        }

        [Fact]
        public void PlotShaded_ULongFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            ulong xs = 1;
            ulong ys1 = 2;
            ulong ys2 = 3;
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShaded(null, ref xs, ref ys1, ref ys2, 1, ImPlotShadedFlags.None, 0, sizeof(ulong)));
        }

        [Fact]
        public void PlotShadedG_Default_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShadedG(null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 1));
        }

        [Fact]
        public void PlotShadedG_Flags_WithNullLabel_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotShadedG(null, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 1, ImPlotShadedFlags.None));
        }

        [Fact]
        public void PlotStairs_FloatDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2));
        }

        [Fact]
        public void PlotStairs_FloatXscale_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0));
        }

        [Fact]
        public void PlotStairs_FloatXscaleXstart_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0));
        }

        [Fact]
        public void PlotStairs_FloatFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        [Fact]
        public void PlotStairs_FloatFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        [Fact]
        public void PlotStairs_FloatFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            float[] values = { 1f, 2f };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(float)));
        }

        [Fact]
        public void PlotStairs_DoubleDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2));
        }

        [Fact]
        public void PlotStairs_DoubleXscale_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0));
        }

        [Fact]
        public void PlotStairs_DoubleXscaleXstart_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0));
        }

        [Fact]
        public void PlotStairs_DoubleFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        [Fact]
        public void PlotStairs_DoubleFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        [Fact]
        public void PlotStairs_DoubleFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            double[] values = { 1.0, 2.0 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(double)));
        }

        [Fact]
        public void PlotStairs_SByteDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2));
        }

        [Fact]
        public void PlotStairs_SByteXscale_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0));
        }

        [Fact]
        public void PlotStairs_SByteXscaleXstart_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0));
        }

        [Fact]
        public void PlotStairs_SByteFlags_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None));
        }

        [Fact]
        public void PlotStairs_SByteFlagsOffset_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0));
        }

        [Fact]
        public void PlotStairs_SByteFlagsOffsetStride_WithNullLabel_ThrowsArgumentNullException()
        {
            sbyte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0, ImPlotStairsFlags.None, 0, sizeof(sbyte)));
        }

        [Fact]
        public void PlotStairs_ByteDefault_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2));
        }

        [Fact]
        public void PlotStairs_ByteXscale_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0));
        }

        [Fact]
        public void PlotStairs_ByteXscaleXstart_WithNullLabel_ThrowsArgumentNullException()
        {
            byte[] values = { 1, 2 };
            Assert.Throws<ArgumentNullException>(() => ImPlot.PlotStairs(null, values, 2, 1.0, 0.0));
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
    }
}
