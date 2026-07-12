// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRangeTest.cs
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

using Alis.Extension.Graphic.Ui.Extras.Plot;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotRange" /> struct.
    /// </summary>
    public class ImPlotRangeTest
    {
        /// <summary>
        ///     Tests that Min and Max should be initialized correctly.
        /// </summary>
        [Fact]
        public void MinAndMax_ShouldBeInitializedCorrectly()
        {
            ImPlotRange range = new ImPlotRange { Min = 0.0, Max = 100.0 };

            Assert.Equal(0.0, range.Min);
            Assert.Equal(100.0, range.Max);
        }

        /// <summary>
        ///     Tests that Min should be set correctly.
        /// </summary>
        [Fact]
        public void Min_ShouldBeSetCorrectly()
        {
            ImPlotRange range = new ImPlotRange { Min = -50.5, Max = 100.0 };

            Assert.Equal(-50.5, range.Min);
        }

        /// <summary>
        ///     Tests that Max should be set correctly.
        /// </summary>
        [Fact]
        public void Max_ShouldBeSetCorrectly()
        {
            ImPlotRange range = new ImPlotRange { Min = 0.0, Max = 999.99 };

            Assert.Equal(999.99, range.Max);
        }

        /// <summary>
        ///     Tests that Min and Max can be modified after initialization.
        /// </summary>
        [Fact]
        public void MinAndMax_ShouldBeModifiable()
        {
            ImPlotRange range = new ImPlotRange { Min = 0.0, Max = 100.0 };

            range.Min = -100.0;
            range.Max = 200.0;

            Assert.Equal(-100.0, range.Min);
            Assert.Equal(200.0, range.Max);
        }

        /// <summary>
        ///     Tests that default struct initialization sets Min and Max to 0.
        /// </summary>
        [Fact]
        public void DefaultInitialization_ShouldSetMinAndMaxToZero()
        {
            ImPlotRange range = new ImPlotRange();

            Assert.Equal(0.0, range.Min);
            Assert.Equal(0.0, range.Max);
        }

        /// <summary>
        ///     Tests that Min should be less than Max for valid range.
        /// </summary>
        [Fact]
        public void ValidRange_ShouldHaveMinLessThanMax()
        {
            ImPlotRange range = new ImPlotRange { Min = 10.0, Max = 20.0 };

            Assert.True(range.Min < range.Max);
        }

        /// <summary>
        ///     Tests that Min can equal Max for zero-width range.
        /// </summary>
        [Fact]
        public void ZeroWidthRange_ShouldAllowMinEqualToMax()
        {
            ImPlotRange range = new ImPlotRange { Min = 50.0, Max = 50.0 };

            Assert.Equal(50.0, range.Min);
            Assert.Equal(50.0, range.Max);
            Assert.Equal(range.Min, range.Max);
        }

        /// <summary>
        ///     Tests that negative values can be used for Min and Max.
        /// </summary>
        [Fact]
        public void NegativeValues_ShouldBeSupported()
        {
            ImPlotRange range = new ImPlotRange { Min = -1000.0, Max = -500.0 };

            Assert.Equal(-1000.0, range.Min);
            Assert.Equal(-500.0, range.Max);
        }

        /// <summary>
        ///     Tests that struct equality works correctly.
        /// </summary>
        [Fact]
        public void Equality_ShouldWorkCorrectly()
        {
            ImPlotRange range1 = new ImPlotRange { Min = 0.0, Max = 100.0 };
            ImPlotRange range2 = new ImPlotRange { Min = 0.0, Max = 100.0 };
            ImPlotRange range3 = new ImPlotRange { Min = 0.0, Max = 200.0 };

            Assert.Equal(range1, range2);
            Assert.NotEqual(range1, range3);
        }

        /// <summary>
        ///     Tests that large double values are supported.
        /// </summary>
        [Fact]
        public void LargeDoubleValues_ShouldBeSupported()
        {
            ImPlotRange range = new ImPlotRange 
            { 
                Min = double.MinValue, 
                Max = double.MaxValue 
            };

            Assert.Equal(double.MinValue, range.Min);
            Assert.Equal(double.MaxValue, range.Max);
        }

        /// <summary>
        ///     Tests that small double values are supported.
        /// </summary>
        [Fact]
        public void SmallDoubleValues_ShouldBeSupported()
        {
            ImPlotRange range = new ImPlotRange 
            { 
                Min = double.NegativeInfinity, 
                Max = double.PositiveInfinity 
            };

            Assert.Equal(double.NegativeInfinity, range.Min);
            Assert.Equal(double.PositiveInfinity, range.Max);
        }
    }
}
