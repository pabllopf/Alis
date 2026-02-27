// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RayCastOutputTest.cs
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
    ///     The ray cast output test class
    /// </summary>
    public class RayCastOutputTest
    {
        /// <summary>
        ///     Tests that constructor should initialize with default values
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializeWithDefaultValues()
        {
            RayCastOutput output = new RayCastOutput();
            
            Assert.Equal(0.0f, output.Fraction);
            Assert.Equal(Vector2F.Zero, output.Normal);
        }

        /// <summary>
        ///     Tests that fraction should set and get correctly
        /// </summary>
        [Fact]
        public void Fraction_ShouldSetAndGetCorrectly()
        {
            RayCastOutput output = new RayCastOutput
            {
                Fraction = 0.5f
            };
            
            Assert.Equal(0.5f, output.Fraction);
        }

        /// <summary>
        ///     Tests that normal should set and get correctly
        /// </summary>
        [Fact]
        public void Normal_ShouldSetAndGetCorrectly()
        {
            Vector2F normal = new Vector2F(0.0f, 1.0f);
            RayCastOutput output = new RayCastOutput
            {
                Normal = normal
            };
            
            Assert.Equal(normal, output.Normal);
        }

        /// <summary>
        ///     Tests that all properties should set correctly
        /// </summary>
        [Fact]
        public void AllProperties_ShouldSetCorrectly()
        {
            RayCastOutput output = new RayCastOutput
            {
                Fraction = 0.75f,
                Normal = new Vector2F(1.0f, 0.0f)
            };
            
            Assert.Equal(0.75f, output.Fraction);
            Assert.Equal(new Vector2F(1.0f, 0.0f), output.Normal);
        }

        /// <summary>
        ///     Tests that fraction of zero should be valid
        /// </summary>
        [Fact]
        public void Fraction_OfZero_ShouldBeValid()
        {
            RayCastOutput output = new RayCastOutput
            {
                Fraction = 0.0f
            };
            
            Assert.Equal(0.0f, output.Fraction);
        }

        /// <summary>
        ///     Tests that fraction of one should be valid
        /// </summary>
        [Fact]
        public void Fraction_OfOne_ShouldBeValid()
        {
            RayCastOutput output = new RayCastOutput
            {
                Fraction = 1.0f
            };
            
            Assert.Equal(1.0f, output.Fraction);
        }

        /// <summary>
        ///     Tests that normal with unit length should work
        /// </summary>
        [Fact]
        public void Normal_WithUnitLength_ShouldWork()
        {
            RayCastOutput output = new RayCastOutput
            {
                Normal = new Vector2F(0.707f, 0.707f)
            };
            
            Assert.NotEqual(Vector2F.Zero, output.Normal);
        }

        /// <summary>
        ///     Tests that normal with negative values should work
        /// </summary>
        [Fact]
        public void Normal_WithNegativeValues_ShouldWork()
        {
            RayCastOutput output = new RayCastOutput
            {
                Normal = new Vector2F(-1.0f, 0.0f)
            };
            
            Assert.Equal(new Vector2F(-1.0f, 0.0f), output.Normal);
        }
    }
}

