// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:EpAxisTest.cs
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

using Alis.Core.Physic.Collisions;
using Xunit;

namespace Alis.Core.Physic.Test.Collisions
{
    /// <summary>
    ///     The ep axis test class
    /// </summary>
    public class EpAxisTest
    {

        /// <summary>
        ///     Tests that index should set and get correctly
        /// </summary>
        [Fact]
        public void Index_ShouldSetAndGetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = 5
            };

            Assert.Equal(5, epAxis.Index);
        }

        /// <summary>
        ///     Tests that index with negative value should work
        /// </summary>
        [Fact]
        public void Index_WithNegativeValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = -10
            };

            Assert.Equal(-10, epAxis.Index);
        }

        /// <summary>
        ///     Tests that index with max int value should work
        /// </summary>
        [Fact]
        public void Index_WithMaxIntValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Index = int.MaxValue
            };

            Assert.Equal(int.MaxValue, epAxis.Index);
        }

        /// <summary>
        ///     Tests that separation should set and get correctly
        /// </summary>
        [Fact]
        public void Separation_ShouldSetAndGetCorrectly()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = 3.14f
            };

            Assert.Equal(3.14f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with negative value should work
        /// </summary>
        [Fact]
        public void Separation_WithNegativeValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = -2.5f
            };

            Assert.Equal(-2.5f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with zero should work
        /// </summary>
        [Fact]
        public void Separation_WithZero_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = 0.0f
            };

            Assert.Equal(0.0f, epAxis.Separation);
        }

        /// <summary>
        ///     Tests that separation with very small value should work
        /// </summary>
        [Fact]
        public void Separation_WithVerySmallValue_ShouldWork()
        {
            EpAxis epAxis = new EpAxis
            {
                Separation = SettingEnv.Epsilon
            };

            Assert.Equal(SettingEnv.Epsilon, epAxis.Separation);
        }

      
        /// <summary>
        ///     Tests that default ep axis should have zero index
        /// </summary>
        [Fact]
        public void DefaultEpAxis_ShouldHaveZeroIndex()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(0, epAxis.Index);
        }

        /// <summary>
        ///     Tests that default ep axis should have zero separation
        /// </summary>
        [Fact]
        public void DefaultEpAxis_ShouldHaveZeroSeparation()
        {
            EpAxis epAxis = new EpAxis();

            Assert.Equal(0.0f, epAxis.Separation);
        }
    }
}
