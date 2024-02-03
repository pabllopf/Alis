// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:RandomUtils.cs
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
using Alis.Core.Aspect.Math.Util;
using Xunit;

namespace Alis.Core.Aspect.Math.Test.Util
{
    /// <summary>
    /// The random utils test class
    /// </summary>
    public class RandomUtilsTest
    {
        /// <summary>
        /// Tests that get int 32 with min and max values should return within range
        /// </summary>
        [Fact]
        public void GetInt32_WithMinAndMaxValues_ShouldReturnWithinRange()
        {
            int minValue = 1;
            int maxValue = 10;
            int result = RandomUtils.GetInt32(minValue, maxValue);

            Assert.InRange(result, minValue, maxValue);
        }

        /// <summary>
        /// Tests that get int 32 with min and max values should throw argument exception when min value is greater than max value
        /// </summary>
        [Fact]
        public void GetInt32_WithMinAndMaxValues_ShouldThrowArgumentException_WhenMinValueIsGreaterThanMaxValue()
        {
            int minValue = 10;
            int maxValue = 1;

            Assert.Throws<ArgumentException>(() => RandomUtils.GetInt32(minValue, maxValue));
        }

        /// <summary>
        /// Tests that get int 32 with value should return within range
        /// </summary>
        [Fact]
        public void GetInt32_WithValue_ShouldReturnWithinRange()
        {
            int value = 10;
            int result = RandomUtils.GetInt32(value);

            Assert.InRange(result, 0, value);
        }

        /// <summary>
        /// Tests that get int 32 with value should throw argument exception when value is negative
        /// </summary>
        [Fact]
        public void GetInt32_WithValue_ShouldThrowArgumentException_WhenValueIsNegative()
        {
            int value = -1;

            Assert.Throws<ArgumentException>(() => RandomUtils.GetInt32(value));
        }
    }
}