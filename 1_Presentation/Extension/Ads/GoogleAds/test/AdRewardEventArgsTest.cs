// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdRewardEventArgsTest.cs
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
using Xunit;

namespace Alis.Extension.Ads.GoogleAds.Test
{
    /// <summary>
    ///     Tests for AdRewardEventArgs class
    /// </summary>
    public class AdRewardEventArgsTest
    {
        /// <summary>
        ///     Tests that constructor sets all properties correctly
        /// </summary>
        [Fact]
        public void Constructor_ShouldSetAllProperties()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", 100, "rewarded-unit-123");

            Assert.Equal("coins", args.RewardType);
            Assert.Equal(100, args.RewardAmount);
            Assert.Equal("rewarded-unit-123", args.AdUnitId);
        }

        /// <summary>
        ///     Tests that properties are read-only (get-only)
        /// </summary>
        [Fact]
        public void Properties_ShouldBeReadOnly()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("gems", 50, "unit-456");

            // Verify we can read the properties
            string rewardType = args.RewardType;
            int rewardAmount = args.RewardAmount;
            string adUnitId = args.AdUnitId;

            Assert.Equal("gems", rewardType);
            Assert.Equal(50, rewardAmount);
            Assert.Equal("unit-456", adUnitId);
        }

        /// <summary>
        ///     Tests that reward amount can be zero
        /// </summary>
        [Fact]
        public void Constructor_WithZeroRewardAmount_ShouldPreserveZero()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", 0, "unit-0");

            Assert.Equal(0, args.RewardAmount);
        }

        /// <summary>
        ///     Tests that reward amount can be negative (edge case)
        /// </summary>
        [Fact]
        public void Constructor_WithNegativeRewardAmount_ShouldPreserveNegative()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", -10, "unit-neg");

            Assert.Equal(-10, args.RewardAmount);
        }

        /// <summary>
        ///     Tests that reward amount can be Int32.MaxValue
        /// </summary>
        [Fact]
        public void Constructor_WithMaxRewardAmount_ShouldPreserveMaxValue()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", int.MaxValue, "unit-max");

            Assert.Equal(int.MaxValue, args.RewardAmount);
        }

        /// <summary>
        ///     Tests that reward amount can be Int32.MinValue
        /// </summary>
        [Fact]
        public void Constructor_WithMinRewardAmount_ShouldPreserveMinValue()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", int.MinValue, "unit-min");

            Assert.Equal(int.MinValue, args.RewardAmount);
        }

        /// <summary>
        ///     Tests that reward type can be empty string
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyRewardType_ShouldPreserveEmpty()
        {
            AdRewardEventArgs args = new AdRewardEventArgs(string.Empty, 10, "unit-1");

            Assert.Equal(string.Empty, args.RewardType);
        }

        /// <summary>
        ///     Tests that ad unit ID can be empty string
        /// </summary>
        [Fact]
        public void Constructor_WithEmptyAdUnitId_ShouldPreserveEmpty()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", 10, string.Empty);

            Assert.Equal(string.Empty, args.AdUnitId);
        }

        /// <summary>
        ///     Tests that all properties can be null or empty simultaneously
        /// </summary>
        [Fact]
        public void Constructor_WithAllEmptyStrings_ShouldPreserveAllEmpty()
        {
            AdRewardEventArgs args = new AdRewardEventArgs(string.Empty, 0, string.Empty);

            Assert.Equal(string.Empty, args.RewardType);
            Assert.Equal(0, args.RewardAmount);
            Assert.Equal(string.Empty, args.AdUnitId);
        }

        /// <summary>
        ///     Tests that AdRewardEventArgs is not null after construction
        /// </summary>
        [Fact]
        public void Constructor_ShouldNeverReturnNull()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("coins", 10, "unit");

            Assert.NotNull(args);
        }

        /// <summary>
        ///     Tests that AdRewardEventArgs can be created with special characters in strings
        /// </summary>
        [Fact]
        public void Constructor_WithSpecialCharacters_ShouldPreserveSpecialChars()
        {
            AdRewardEventArgs args = new AdRewardEventArgs("c01ns_@#$%", 999, "unit/with/slashes");

            Assert.Equal("c01ns_@#$%", args.RewardType);
            Assert.Equal(999, args.RewardAmount);
            Assert.Equal("unit/with/slashes", args.AdUnitId);
        }

    }
}
