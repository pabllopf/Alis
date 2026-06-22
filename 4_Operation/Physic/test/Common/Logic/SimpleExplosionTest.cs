// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:SimpleExplosionTest.cs
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

using System.Collections.Generic;
using Alis.Core.Aspect.Math.Vector;
using Alis.Core.Physic.Common.Logic;
using Alis.Core.Physic.Dynamics;
using Xunit;

namespace Alis.Core.Physic.Test.Common.Logic
{
    /// <summary>
    ///     The simple explosion test class
    /// </summary>
    public class SimpleExplosionTest
    {
        /// <summary>
        ///     Tests that constructor initializes power to 1
        /// </summary>
        [Fact]
        public void Constructor_ShouldInitializePowerToOne()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);

            Assert.Equal(1f, explosion.Power);
        }

        /// <summary>
        ///     Tests that Power property can be set and retrieved
        /// </summary>
        [Fact]
        public void Power_ShouldGetAndSetCorrectly()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 2f;

            Assert.Equal(2f, explosion.Power);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when distance equals radius and power is 1
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceEqualsRadius_ShouldReturnZero()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(10f, 10f);

            Assert.Equal(0f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent returns 1 when distance is 0
        /// </summary>
        [Fact]
        public void GetPercent_WhenDistanceIsZero_ShouldReturnOne()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(0f, 10f);

            Assert.Equal(1f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent returns clamped value between 0 and 1
        /// </summary>
        [Fact]
        public void GetPercent_ShouldReturnClampedValue()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(5f, 10f);

            Assert.True(percent >= 0f && percent <= 1f);
        }

        /// <summary>
        ///     Tests that GetPercent returns 0 when result is NaN
        /// </summary>
        [Fact]
        public void GetPercent_WhenResultIsNaN_ShouldReturnZero()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            float percent = explosion.GetPercent(float.NaN, 10f);

            Assert.Equal(0f, percent);
        }

        /// <summary>
        ///     Tests that GetPercent with power 2 returns different value than power 1
        /// </summary>
        [Fact]
        public void GetPercent_WithPowerTwo_ShouldReturnDifferentValue()
        {
            WorldPhysic world = new WorldPhysic();

            SimpleExplosion explosion = new SimpleExplosion(world);
            explosion.Power = 2f;

            float percentPower1 = new SimpleExplosion(world).GetPercent(5f, 10f);
            float percentPower2 = explosion.GetPercent(5f, 10f);

            Assert.NotEqual(percentPower1, percentPower2);
        }
    }
}
