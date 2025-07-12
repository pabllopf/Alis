// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotTestP8.cs
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
    public class ImPlotTestP8
    {
        /// <summary>
        ///     Tests that plot shaded byte 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded byte 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Byte_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                byte minValue = byte.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Short_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Short_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Short_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded short 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Short_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                short minValue = short.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u short 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UShort_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ushort minValue = ushort.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Int_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Int_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Int_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded int 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Int_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                int minValue = int.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u int 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_UInt_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                uint minValue = uint.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Long_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Long_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Long_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded long 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_Long_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                long minValue = long.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long 5 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0);
            });
        }

        /// <summary>
        ///     Tests that plot shaded u long 8 params v 1
        /// </summary>
        [Fact]
        public void PlotShaded_ULong_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() =>
            {
                ulong minValue = ulong.MinValue;
                ImPlot.PlotShaded("label", ref minValue, ref minValue, ref minValue, 1, ImPlotShadedFlags.None, 0, 1);
            });
        }

        /// <summary>
        ///     Tests that plot shaded g 6 params v 1
        /// </summary>
        [Fact]
        public void PlotShadedG_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 1));
        }

        /// <summary>
        ///     Tests that plot shaded g 7 params v 1
        /// </summary>
        [Fact]
        public void PlotShadedG_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotShadedG("label", IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, IntPtr.Zero, 1, ImPlotShadedFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs float 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1));
        }

        /// <summary>
        ///     Tests that plot stairs float 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs float 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1, 1.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs float 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1, 1.0, 1.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs float 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs float 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Float_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new float[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot stairs double 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1));
        }

        /// <summary>
        ///     Tests that plot stairs double 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs double 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1, 1.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs double 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1, 1.0, 1.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs double 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs double 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Double_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new double[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1, 1.0, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 6 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_6Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1, 1.0, 1.0, ImPlotStairsFlags.None));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 7 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_7Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0));
        }

        /// <summary>
        ///     Tests that plot stairs s byte 8 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_SByte_8Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new sbyte[1], 1, 1.0, 1.0, ImPlotStairsFlags.None, 0, 1));
        }

        /// <summary>
        ///     Tests that plot stairs byte 3 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_3Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[1], 1));
        }

        /// <summary>
        ///     Tests that plot stairs byte 4 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_4Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[1], 1, 1.0));
        }

        /// <summary>
        ///     Tests that plot stairs byte 5 params v 1
        /// </summary>
        [Fact]
        public void PlotStairs_Byte_5Params_v1()
        {
            Assert.Throws<DllNotFoundException>(() => ImPlot.PlotStairs("label", new byte[1], 1, 1.0, 1.0));
        }
    }
}