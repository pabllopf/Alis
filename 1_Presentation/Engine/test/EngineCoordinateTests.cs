// --------------------------------------------------------------------------
//
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
//
//  --------------------------------------------------------------------------
//  File:EngineCoordinateTests.cs
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

using Xunit;

namespace Alis.App.Engine.Test
{
    /// <summary>
    ///     Verifies the pure coordinate conversion helpers of <see cref="Engine" />.
    /// </summary>
    public class EngineCoordinateTests
    {
        /// <summary>
        ///     Invalid window dimensions cannot produce a valid logical mouse position.
        /// </summary>
        [Fact]
        public void ScaleMousePosition_WithNonPositiveDimensions_SetsMinusOne()
        {
            float x = 10;
            float y = 20;

            Engine.ScaleMousePosition(ref x, ref y, 0, 600);

            Assert.Equal(-1, x);
            Assert.Equal(-1, y);

            x = 10;
            y = 20;
            Engine.ScaleMousePosition(ref x, ref y, 800, -1);

            Assert.Equal(-1, x);
            Assert.Equal(-1, y);
        }

        /// <summary>
        ///     Normalized coordinates are scaled to the window and the vertical axis is inverted.
        /// </summary>
        [Fact]
        public void ScaleMousePosition_WithNormalizedCoordinates_ScalesInvertsAndClamps()
        {
            float x = 0.5f;
            float y = 0.25f;

            Engine.ScaleMousePosition(ref x, ref y, 800, 600, true, true);

            Assert.Equal(400, x);
            Assert.Equal(450, y);
        }

        /// <summary>
        ///     Absolute coordinates are left untouched when neither scaling nor inversion is requested.
        /// </summary>
        [Fact]
        public void ScaleMousePosition_WithAbsoluteCoordinates_DoesNotScaleOrInvert()
        {
            float x = 120;
            float y = 340;

            Engine.ScaleMousePosition(ref x, ref y, 800, 600, false, false);

            Assert.Equal(120, x);
            Assert.Equal(340, y);
        }

        /// <summary>
        ///     The convenience overload uses normalized and inverted coordinates.
        /// </summary>
        [Fact]
        public void ScaleMousePosition_DefaultOverload_UsesNormalizedAndInvertedCoordinates()
        {
            float x = 0.1f;
            float y = 0.9f;

            Engine.ScaleMousePosition(ref x, ref y, 100, 100);

            Assert.Equal(10, x);
            Assert.Equal(10, y);
        }

        /// <summary>
        ///     Coordinates outside the window are clamped to its bounds.
        /// </summary>
        [Fact]
        public void ScaleMousePosition_WithOutOfRangeCoordinates_ClampsToWindow()
        {
            float x = -5;
            float y = 1000;

            Engine.ScaleMousePosition(ref x, ref y, 800, 600, false, false);

            Assert.Equal(0, x);
            Assert.Equal(600, y);
        }
    }
}
