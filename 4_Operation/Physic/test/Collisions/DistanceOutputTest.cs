// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:DistanceOutputTest.cs
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
    ///     The distance output test class
    /// </summary>
    public class DistanceOutputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            DistanceOutput output = new DistanceOutput();
            
            Assert.Equal(0.0f, output.Distance);
            Assert.Equal(0, output.Iterations);
            Assert.Equal(Vector2F.Zero, output.PointA);
            Assert.Equal(Vector2F.Zero, output.PointB);
        }

        /// <summary>
        ///     Tests that distance should set and get correctly
        /// </summary>
        [Fact]
        public void Distance_ShouldSetAndGetCorrectly()
        {
            DistanceOutput output = new DistanceOutput
            {
                Distance = 5.0f
            };
            
            Assert.Equal(5.0f, output.Distance);
        }

        /// <summary>
        ///     Tests that iterations should set and get correctly
        /// </summary>
        [Fact]
        public void Iterations_ShouldSetAndGetCorrectly()
        {
            DistanceOutput output = new DistanceOutput
            {
                Iterations = 10
            };
            
            Assert.Equal(10, output.Iterations);
        }

        /// <summary>
        ///     Tests that point a should set and get correctly
        /// </summary>
        [Fact]
        public void PointA_ShouldSetAndGetCorrectly()
        {
            DistanceOutput output = new DistanceOutput
            {
                PointA = new Vector2F(1.0f, 2.0f)
            };
            
            Assert.Equal(new Vector2F(1.0f, 2.0f), output.PointA);
        }

        /// <summary>
        ///     Tests that point b should set and get correctly
        /// </summary>
        [Fact]
        public void PointB_ShouldSetAndGetCorrectly()
        {
            DistanceOutput output = new DistanceOutput
            {
                PointB = new Vector2F(3.0f, 4.0f)
            };
            
            Assert.Equal(new Vector2F(3.0f, 4.0f), output.PointB);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            DistanceOutput output = new DistanceOutput
            {
                Distance = 7.5f,
                Iterations = 15,
                PointA = new Vector2F(1.0f, 2.0f),
                PointB = new Vector2F(3.0f, 4.0f)
            };
            
            Assert.Equal(7.5f, output.Distance);
            Assert.Equal(15, output.Iterations);
            Assert.Equal(new Vector2F(1.0f, 2.0f), output.PointA);
            Assert.Equal(new Vector2F(3.0f, 4.0f), output.PointB);
        }

        /// <summary>
        ///     Tests that distance with negative value should work
        /// </summary>
        [Fact]
        public void Distance_WithNegativeValue_ShouldWork()
        {
            DistanceOutput output = new DistanceOutput
            {
                Distance = -1.0f
            };
            
            Assert.Equal(-1.0f, output.Distance);
        }

        /// <summary>
        ///     Tests that iterations with zero should work
        /// </summary>
        [Fact]
        public void Iterations_WithZero_ShouldWork()
        {
            DistanceOutput output = new DistanceOutput
            {
                Iterations = 0
            };
            
            Assert.Equal(0, output.Iterations);
        }
    }
}

