// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP21.cs
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
using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot.Native
{
    /// <summary>
    ///     The im plot test class
    /// </summary>
    public class ImPlotTestP21
    {
        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte ys1 = default(sbyte);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte xs = default(sbyte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            sbyte xs = default(sbyte);
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags)); });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte xs = default(sbyte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte xs = default(sbyte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 8 ptr u 8 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U8PtrU8PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte ys1 = default(byte);
                ImPlot.PlotShaded("label", ref
                    ys1, ref
                    ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 8 ptr u 8 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U8PtrU8PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte xs = default(byte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 8 ptr u 8 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U8PtrU8PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte xs = default(byte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 8 ptr u 8 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U8PtrU8PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte xs = default(byte);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 8 ptr u 8 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U8PtrU8PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte xs = default(byte);
                ImPlot.PlotShaded("label", ref xs, ref
                    xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 16 ptr s 16 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S16PtrS16PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short ys1 = default(short);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 16 ptr s 16 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S16PtrS16PtrInt_Double_ThrowsDllNotFoundException()
        {
            short xs = default(short);
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0); });
        }

        /// <summary>
        ///     Tests that plot shaded s 16 ptr s 16 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S16PtrS16PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short xs = default(short);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 16 ptr s 16 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S16PtrS16PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short xs = default(short);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 16 ptr s 16 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S16PtrS16PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short xs = default(short);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 16 ptr u 16 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U16PtrU16PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort ys1 = default(ushort);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 16 ptr u 16 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U16PtrU16PtrInt_Double_ThrowsDllNotFoundException()
        {
            ushort xs = default(ushort);
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0); });
        }

        /// <summary>
        ///     Tests that plot shaded u 16 ptr u 16 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U16PtrU16PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            ushort xs = default(ushort);
            Assert.Throws<DllNotFoundException>(() => { ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags)); });
        }

        /// <summary>
        ///     Tests that plot shaded u 16 ptr u 16 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U16PtrU16PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort xs = default(ushort);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 16 ptr u 16 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U16PtrU16PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort xs = default(ushort);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 32 ptr s 32 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S32PtrS32PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int ys1 = default(int);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 32 ptr s 32 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S32PtrS32PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 32 ptr s 32 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S32PtrS32PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 32 ptr s 32 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S32PtrS32PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 32 ptr s 32 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S32PtrS32PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int xs = default(int);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 32 ptr u 32 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U32PtrU32PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint ys1 = default(uint);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 32 ptr u 32 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U32PtrU32PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 32 ptr u 32 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U32PtrU32PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 32 ptr u 32 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U32PtrU32PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 32 ptr u 32 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U32PtrU32PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint xs = default(uint);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 64 ptr s 64 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S64PtrS64PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long ys1 = default(long);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 64 ptr s 64 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S64PtrS64PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 64 ptr s 64 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S64PtrS64PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 64 ptr s 64 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S64PtrS64PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 64 ptr s 64 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S64PtrS64PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long xs = default(long);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 64 ptr u 64 ptr int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U64PtrU64PtrInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong ys1 = default(ulong);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 64 ptr u 64 ptr int double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U64PtrU64PtrInt_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 64 ptr u 64 ptr int double flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U64PtrU64PtrInt_Double_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 64 ptr u 64 ptr int double flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U64PtrU64PtrInt_Double_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u 64 ptr u 64 ptr int double flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_U64PtrU64PtrInt_Double_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong xs = default(ulong);
                ImPlot.PlotShaded("label", ref xs, ref xs, 0, 0.0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded float ptr float ptr float ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_FloatPtrFloatPtrFloatPtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float ys1 = default(float);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded float ptr float ptr float ptr flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_FloatPtrFloatPtrFloatPtr_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float ys1 = default(float);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded float ptr float ptr float ptr flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_FloatPtrFloatPtrFloatPtr_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float ys1 = default(float);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded float ptr float ptr float ptr flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_FloatPtrFloatPtrFloatPtr_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float ys1 = default(float);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded double ptrdouble ptrdouble ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_doublePtrdoublePtrdoublePtr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double ys1 = default(double);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded double ptrdouble ptrdouble ptr flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_doublePtrdoublePtrdoublePtr_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double ys1 = default(double);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags));
            });
        }

        /// <summary>
        ///     Tests that plot shaded double ptrdouble ptrdouble ptr flags int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_doublePtrdoublePtrdoublePtr_Flags_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double ys1 = default(double);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags), 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded double ptrdouble ptrdouble ptr flags int int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_doublePtrdoublePtrdoublePtr_Flags_Int_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double ys1 = default(double);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags), 0, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr s 8 ptr throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrS8Ptr_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte ys1 = default(sbyte);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded s 8 ptr s 8 ptr s 8 ptr flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotShaded_S8PtrS8PtrS8Ptr_Flags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte ys1 = default(sbyte);
                ImPlot.PlotShaded("label", ref ys1, ref ys1, ref ys1, 0, default(ImPlotShadedFlags));
            });
        }
    }
}