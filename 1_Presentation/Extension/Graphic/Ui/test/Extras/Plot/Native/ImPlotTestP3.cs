// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP3.cs
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
    public class ImPlotTestP3
    {
        /// <summary>
        ///     Tests that plot error bars double throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Double_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double err = 0.0;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars double with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Double_WithFlags_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double err = 0.0;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1, ImPlotErrorBarsFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot error bars s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_SByte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte @sbyte = 0;
                ImPlot.PlotErrorBars("label", ref @sbyte, ref @sbyte, ref @sbyte, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars byte throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Byte_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte b = 0;
                ImPlot.PlotErrorBars("label", ref b, ref b, ref b, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Short_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short s = 0;
                ImPlot.PlotErrorBars("label", ref s, ref s, ref s, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars u short throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UShort_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort @ushort = 0;
                ImPlot.PlotErrorBars("label", ref @ushort, ref @ushort, ref @ushort, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars int throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Int_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int err = 0;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars u int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_UInt_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint err = 0u;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Long_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long err = 0L;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars u long throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_ULong_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong err = 0UL;
                ImPlot.PlotErrorBars("label", ref err, ref err, ref err, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars float neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Float_NegPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                float neg = 0f;
                ImPlot.PlotErrorBars("label", ref neg, ref neg, ref neg, ref neg, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars double neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Double_NegPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                double neg = 0.0;
                ImPlot.PlotErrorBars("label", ref neg, ref neg, ref neg, ref neg, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars s byte neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_SByte_NegPos_ThrowsDllNotFoundException()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                sbyte @sbyte = 0;
                ImPlot.PlotErrorBars("label", ref @sbyte, ref @sbyte, ref @sbyte, ref @sbyte, 1);
            });
        }

        /// <summary>
        ///     Tests that plot error bars float throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Float_ThrowsDllNotFoundException()
        {
            float xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1, ImPlotErrorBarsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot error bars float with stride throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Float_WithStride_ThrowsDllNotFoundException()
        {
            float xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1, ImPlotErrorBarsFlags.None, 0, 4));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars double throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Double_ThrowsDllNotFoundException()
        {
            double xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars double with flags throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Double_WithFlags_ThrowsDllNotFoundException()
        {
            double xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1, ImPlotErrorBarsFlags.None));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars s byte throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_SByte_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars byte throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Byte_ThrowsDllNotFoundException()
        {
            byte xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars short throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Short_ThrowsDllNotFoundException()
        {
            short xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars u short throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_UShort_ThrowsDllNotFoundException()
        {
            ushort xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that plot error bars int throws dll not found exception
        /// </summary>
        [Fact]
        public void PlotErrorBars_Int_ThrowsDllNotFoundException()
        {
            int xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars u int throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_UInt_ThrowsDllNotFoundException()
        {
            uint xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars long throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Long_ThrowsDllNotFoundException()
        {
            long xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars u long throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_ULong_ThrowsDllNotFoundException()
        {
            ulong xs = 0, ys = 0, err = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref err, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars float neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Float_NegPos_ThrowsDllNotFoundException()
        {
            float xs = 0, ys = 0, neg = 0, pos = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars double neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_Double_NegPos_ThrowsDllNotFoundException()
        {
            double xs = 0, ys = 0, neg = 0, pos = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 1));
        }

        /// <summary>
        ///     Tests that v 2 plot error bars s byte neg pos throws dll not found exception
        /// </summary>
        [Fact]
        public void V2_PlotErrorBars_SByte_NegPos_ThrowsDllNotFoundException()
        {
            sbyte xs = 0, ys = 0, neg = 0, pos = 0;
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotErrorBars("label", ref xs, ref ys, ref neg, ref pos, 1));
        }
    }
}