// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:ImPlotRectTest.cs
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
using Alis.Extension.Graphic.Ui.Test.Attributes;
using Xunit;

namespace Alis.Extension.Graphic.Ui.Test.Extras.Plot
{
    /// <summary>
    ///     Provides unit coverage for <see cref="ImPlotRect" /> struct.
    /// </summary>
    public class ImPlotRectTest
    {
        /// <summary>
        ///     Tests that X and Y should be initialized correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void XAndY_ShouldBeInitializedCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 200.0 }
            };

            Assert.Equal(0.0, rect.X.Min, 5);
            Assert.Equal(100.0, rect.X.Max, 5);
            Assert.Equal(0.0, rect.Y.Min, 5);
            Assert.Equal(200.0, rect.Y.Max, 5);
        }

        /// <summary>
        ///     Tests that X should be set correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void X_ShouldBeSetCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = -50.5, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 200.0 }
            };

            Assert.Equal(-50.5, rect.X.Min, 5);
            Assert.Equal(100.0, rect.X.Max, 5);
        }

        /// <summary>
        ///     Tests that Y should be set correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Y_ShouldBeSetCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 999.99 }
            };

            Assert.Equal(0.0, rect.Y.Min, 5);
            Assert.Equal(999.99, rect.Y.Max, 5);
        }

        /// <summary>
        ///     Tests that X and Y can be modified after initialization.
        /// </summary>
        [RequireCImguiSystemFact]
        public void XAndY_ShouldBeModifiable()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 200.0 }
            };

            rect.X = new ImPlotRange { Min = -100.0, Max = 50.0 };
            rect.Y = new ImPlotRange { Min = -200.0, Max = 300.0 };

            Assert.Equal(-100.0, rect.X.Min, 5);
            Assert.Equal(50.0, rect.X.Max, 5);
            Assert.Equal(-200.0, rect.Y.Min, 5);
            Assert.Equal(300.0, rect.Y.Max, 5);
        }

        /// <summary>
        ///     Tests that default struct initialization sets X and Y to default ImPlotRange.
        /// </summary>
        [RequireCImguiSystemFact]
        public void DefaultInitialization_ShouldSetXAndYToDefault()
        {
            ImPlotRect rect = new ImPlotRect();

            Assert.Equal(default(ImPlotRange), rect.X);
            Assert.Equal(default(ImPlotRange), rect.Y);
        }

        /// <summary>
        ///     Tests that struct equality works correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void Equality_ShouldWorkCorrectly()
        {
            ImPlotRect rect1 = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 200.0 }
            };
            ImPlotRect rect2 = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 200.0 }
            };
            ImPlotRect rect3 = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 100.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 300.0 }
            };

            Assert.Equal(rect1, rect2);
            Assert.NotEqual(rect1, rect3);
        }

        /// <summary>
        ///     Tests that negative values can be used for X and Y ranges.
        /// </summary>
        [RequireCImguiSystemFact]
        public void NegativeValues_ShouldBeSupported()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = -1000.0, Max = -500.0 },
                Y = new ImPlotRange { Min = -2000.0, Max = -1000.0 }
            };

            Assert.Equal(-1000.0, rect.X.Min, 5);
            Assert.Equal(-500.0, rect.X.Max, 5);
            Assert.Equal(-2000.0, rect.Y.Min, 5);
            Assert.Equal(-1000.0, rect.Y.Max, 5);
        }

        /// <summary>
        ///     Tests that large double values are supported for X and Y ranges.
        /// </summary>
        [RequireCImguiSystemFact]
        public void LargeDoubleValues_ShouldBeSupported()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = double.MinValue, Max = double.MaxValue },
                Y = new ImPlotRange { Min = double.MinValue, Max = double.MaxValue }
            };

            Assert.Equal(double.MinValue, rect.X.Min);
            Assert.Equal(double.MaxValue, rect.X.Max);
            Assert.Equal(double.MinValue, rect.Y.Min);
            Assert.Equal(double.MaxValue, rect.Y.Max);
        }

        /// <summary>
        ///     Tests that zero values are supported for X and Y ranges.
        /// </summary>
        [RequireCImguiSystemFact]
        public void ZeroValues_ShouldBeSupported()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 0.0, Max = 0.0 },
                Y = new ImPlotRange { Min = 0.0, Max = 0.0 }
            };

            Assert.Equal(0.0, rect.X.Min, 5);
            Assert.Equal(0.0, rect.X.Max, 5);
            Assert.Equal(0.0, rect.Y.Min, 5);
            Assert.Equal(0.0, rect.Y.Max, 5);
        }

        /// <summary>
        ///     Tests that struct with only X set works correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void OnlyXSet_ShouldWorkCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                X = new ImPlotRange { Min = 10.0, Max = 20.0 }
            };

            Assert.Equal(10.0, rect.X.Min, 5);
            Assert.Equal(20.0, rect.X.Max, 5);
            Assert.Equal(default(ImPlotRange), rect.Y);
        }

        /// <summary>
        ///     Tests that struct with only Y set works correctly.
        /// </summary>
        [RequireCImguiSystemFact]
        public void OnlyYSet_ShouldWorkCorrectly()
        {
            ImPlotRect rect = new ImPlotRect
            {
                Y = new ImPlotRange { Min = 30.0, Max = 40.0 }
            };

            Assert.Equal(default(ImPlotRange), rect.X);
            Assert.Equal(30.0, rect.Y.Min, 5);
            Assert.Equal(40.0, rect.Y.Max, 5);
        }
    }
}