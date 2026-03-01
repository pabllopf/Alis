// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastInputTest.cs
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

using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ray cast input test class
    /// </summary>
    public class RayCastInputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            RayCastInput input = new RayCastInput();
            
            Assert.Equal(0.0f, input.MaxFraction);
            Assert.Equal(Vector2F.Zero, input.Point1);
            Assert.Equal(Vector2F.Zero, input.Point2);
        }

        /// <summary>
        ///     Tests that max fraction should set and get correctly
        /// </summary>
        [Fact]
        public void MaxFraction_ShouldSetAndGetCorrectly()
        {
            RayCastInput input = new RayCastInput
            {
                MaxFraction = 0.75f
            };
            
            Assert.Equal(0.75f, input.MaxFraction);
        }

        /// <summary>
        ///     Tests that point 1 should set and get correctly
        /// </summary>
        [Fact]
        public void Point1_ShouldSetAndGetCorrectly()
        {
            Vector2F point = new Vector2F(1.0f, 2.0f);
            RayCastInput input = new RayCastInput
            {
                Point1 = point
            };
            
            Assert.Equal(point, input.Point1);
        }

        /// <summary>
        ///     Tests that point 2 should set and get correctly
        /// </summary>
        [Fact]
        public void Point2_ShouldSetAndGetCorrectly()
        {
            Vector2F point = new Vector2F(5.0f, 10.0f);
            RayCastInput input = new RayCastInput
            {
                Point2 = point
            };
            
            Assert.Equal(point, input.Point2);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(0.0f, 0.0f),
                Point2 = new Vector2F(10.0f, 10.0f),
                MaxFraction = 1.0f
            };
            
            Assert.Equal(new Vector2F(0.0f, 0.0f), input.Point1);
            Assert.Equal(new Vector2F(10.0f, 10.0f), input.Point2);
            Assert.Equal(1.0f, input.MaxFraction);
        }

        /// <summary>
        ///     Tests that max fraction of zero should be valid
        /// </summary>
        [Fact]
        public void MaxFraction_OfZero_ShouldBeValid()
        {
            RayCastInput input = new RayCastInput
            {
                MaxFraction = 0.0f
            };
            
            Assert.Equal(0.0f, input.MaxFraction);
        }

        /// <summary>
        ///     Tests that max fraction of one should be valid
        /// </summary>
        [Fact]
        public void MaxFraction_OfOne_ShouldBeValid()
        {
            RayCastInput input = new RayCastInput
            {
                MaxFraction = 1.0f
            };
            
            Assert.Equal(1.0f, input.MaxFraction);
        }

        /// <summary>
        ///     Tests that points with negative coordinates should work
        /// </summary>
        [Fact]
        public void Points_WithNegativeCoordinates_ShouldWork()
        {
            RayCastInput input = new RayCastInput
            {
                Point1 = new Vector2F(-5.0f, -10.0f),
                Point2 = new Vector2F(-1.0f, -2.0f)
            };
            
            Assert.Equal(new Vector2F(-5.0f, -10.0f), input.Point1);
            Assert.Equal(new Vector2F(-1.0f, -2.0f), input.Point2);
        }
    }
}

