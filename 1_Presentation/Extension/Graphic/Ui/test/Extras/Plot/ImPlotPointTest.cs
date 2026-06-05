// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotPointTest.cs
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
    ///     Provides unit coverage for <see cref="ImPlotPoint" /> struct.
    /// </summary>
    public class ImPlotPointTest
    {
        /// <summary>
        ///     Tests that X and Y should be initialized correctly.
        /// </summary>
        [Fact]
        public void XAndY_ShouldBeInitializedCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint { X = 10.0, Y = 20.0 };

            Assert.Equal(10.0, point.X);
            Assert.Equal(20.0, point.Y);
        }

        /// <summary>
        ///     Tests that X should be set correctly.
        /// </summary>
        [Fact]
        public void X_ShouldBeSetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint { X = -50.5, Y = 100.0 };

            Assert.Equal(-50.5, point.X);
        }

        /// <summary>
        ///     Tests that Y should be set correctly.
        /// </summary>
        [Fact]
        public void Y_ShouldBeSetCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint { X = 0.0, Y = 999.99 };

            Assert.Equal(999.99, point.Y);
        }

        /// <summary>
        ///     Tests that X and Y can be modified after initialization.
        /// </summary>
        [Fact]
        public void XAndY_ShouldBeModifiable()
        {
            ImPlotPoint point = new ImPlotPoint { X = 0.0, Y = 100.0 };

            point.X = -100.0;
            point.Y = 200.0;

            Assert.Equal(-100.0, point.X);
            Assert.Equal(200.0, point.Y);
        }

        /// <summary>
        ///     Tests that default struct initialization sets X and Y to 0.
        /// </summary>
        [Fact]
        public void DefaultInitialization_ShouldSetXAndYToZero()
        {
            ImPlotPoint point = new ImPlotPoint();

            Assert.Equal(0.0, point.X);
            Assert.Equal(0.0, point.Y);
        }

        /// <summary>
        ///     Tests that negative values can be used for X and Y.
        /// </summary>
        [Fact]
        public void NegativeValues_ShouldBeSupported()
        {
            ImPlotPoint point = new ImPlotPoint { X = -1000.0, Y = -500.0 };

            Assert.Equal(-1000.0, point.X);
            Assert.Equal(-500.0, point.Y);
        }

        /// <summary>
        ///     Tests that struct equality works correctly.
        /// </summary>
        [Fact]
        public void Equality_ShouldWorkCorrectly()
        {
            ImPlotPoint point1 = new ImPlotPoint { X = 0.0, Y = 100.0 };
            ImPlotPoint point2 = new ImPlotPoint { X = 0.0, Y = 100.0 };
            ImPlotPoint point3 = new ImPlotPoint { X = 0.0, Y = 200.0 };

            Assert.Equal(point1, point2);
            Assert.NotEqual(point1, point3);
        }

        /// <summary>
        ///     Tests that large double values are supported.
        /// </summary>
        [Fact]
        public void LargeDoubleValues_ShouldBeSupported()
        {
            ImPlotPoint point = new ImPlotPoint 
            { 
                X = double.MaxValue, 
                Y = double.MinValue 
            };

            Assert.Equal(double.MaxValue, point.X);
            Assert.Equal(double.MinValue, point.Y);
        }

        /// <summary>
        ///     Tests that zero values are supported.
        /// </summary>
        [Fact]
        public void ZeroValues_ShouldBeSupported()
        {
            ImPlotPoint point = new ImPlotPoint { X = 0.0, Y = 0.0 };

            Assert.Equal(0.0, point.X);
            Assert.Equal(0.0, point.Y);
        }

        /// <summary>
        ///     Tests that struct with only X set works correctly.
        /// </summary>
        [Fact]
        public void OnlyXSet_ShouldWorkCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint { X = 42.0 };

            Assert.Equal(42.0, point.X);
            Assert.Equal(0.0, point.Y);
        }

        /// <summary>
        ///     Tests that struct with only Y set works correctly.
        /// </summary>
        [Fact]
        public void OnlyYSet_ShouldWorkCorrectly()
        {
            ImPlotPoint point = new ImPlotPoint { Y = 42.0 };

            Assert.Equal(0.0, point.X);
            Assert.Equal(42.0, point.Y);
        }
    }
}
