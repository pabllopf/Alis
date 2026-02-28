// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFmpegProfileTest.cs
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
using System.Collections.Generic;
using Alis.Extension.Media.FFmpeg.Encoding.Builders;
using Xunit;

namespace Alis.Extension.Media.FFmpeg.Test.Encoding.Builders
{
    /// <summary>
    ///     The ffmpeg profile test class
    /// </summary>
    /// <seealso cref="FFmpegProfile" />
    public class FFmpegProfileTest
    {
        /// <summary>
        ///     Tests that ffmpeg profile auto should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_Auto_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.Auto;

            // Assert
            Assert.Equal(0, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile baseline should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_Baseline_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.Baseline;

            // Assert
            Assert.Equal(1, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile main should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_Main_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.Main;

            // Assert
            Assert.Equal(2, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile high should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_High_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.High;

            // Assert
            Assert.Equal(3, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile high 10 should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_High10_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.High10;

            // Assert
            Assert.Equal(4, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile high 442 should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_High442_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.High442;

            // Assert
            Assert.Equal(5, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile high 444 should have correct value
        /// </summary>
        [Fact]
        public void FFmpegProfile_High444_ShouldHaveCorrectValue()
        {
            // Arrange & Act
            FFmpegProfile profile = FFmpegProfile.High444;

            // Assert
            Assert.Equal(6, (int) profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile enum should have seven values
        /// </summary>
        [Fact]
        public void FFmpegProfile_Enum_ShouldHaveSevenValues()
        {
            // Arrange & Act
            FFmpegProfile[] values = (FFmpegProfile[]) Enum.GetValues(typeof(FFmpegProfile));

            // Assert
            Assert.Equal(7, values.Length);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should be convertible to string
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldBeConvertibleToString()
        {
            // Arrange
            FFmpegProfile auto = FFmpegProfile.Auto;
            FFmpegProfile baseline = FFmpegProfile.Baseline;
            FFmpegProfile high = FFmpegProfile.High;

            // Act
            string autoStr = auto.ToString();
            string baselineStr = baseline.ToString();
            string highStr = high.ToString();

            // Assert
            Assert.Equal("Auto", autoStr);
            Assert.Equal("Baseline", baselineStr);
            Assert.Equal("High", highStr);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should be parseable from string
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldBeParseableFromString()
        {
            // Arrange & Act
            FFmpegProfile main = (FFmpegProfile) Enum.Parse(typeof(FFmpegProfile), "Main");
            FFmpegProfile high10 = (FFmpegProfile) Enum.Parse(typeof(FFmpegProfile), "High10");

            // Assert
            Assert.Equal(FFmpegProfile.Main, main);
            Assert.Equal(FFmpegProfile.High10, high10);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should support equality comparison
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldSupportEqualityComparison()
        {
            // Arrange
            FFmpegProfile high1 = FFmpegProfile.High;
            FFmpegProfile high2 = FFmpegProfile.High;
            FFmpegProfile main = FFmpegProfile.Main;

            // Act & Assert
            Assert.Equal(high1, high2);
            Assert.NotEqual(high1, main);
        }

        /// <summary>
        ///     Tests that ffmpeg profile to lower invariant should work correctly
        /// </summary>
        [Fact]
        public void FFmpegProfile_ToLowerInvariant_ShouldWorkCorrectly()
        {
            // Arrange
            FFmpegProfile baseline = FFmpegProfile.Baseline;
            FFmpegProfile high = FFmpegProfile.High;
            FFmpegProfile high444 = FFmpegProfile.High444;

            // Act
            string baselineLower = baseline.ToString().ToLowerInvariant();
            string highLower = high.ToString().ToLowerInvariant();
            string high444Lower = high444.ToString().ToLowerInvariant();

            // Assert
            Assert.Equal("baseline", baselineLower);
            Assert.Equal("high", highLower);
            Assert.Equal("high444", high444Lower);
        }

        /// <summary>
        ///     Tests that ffmpeg profile all values should be defined
        /// </summary>
        [Fact]
        public void FFmpegProfile_AllValues_ShouldBeDefined()
        {
            // Arrange & Act & Assert
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.Auto));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.Baseline));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.Main));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.High));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.High10));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.High442));
            Assert.True(Enum.IsDefined(typeof(FFmpegProfile), FFmpegProfile.High444));
        }

        /// <summary>
        ///     Tests that ffmpeg profile should have unique values
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldHaveUniqueValues()
        {
            // Arrange
            int[] values = new[]
            {
                (int) FFmpegProfile.Auto,
                (int) FFmpegProfile.Baseline,
                (int) FFmpegProfile.Main,
                (int) FFmpegProfile.High,
                (int) FFmpegProfile.High10,
                (int) FFmpegProfile.High442,
                (int) FFmpegProfile.High444
            };

            // Act & Assert
            Assert.Equal(values.Length, new HashSet<int>(values).Count);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should be castable to int
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldBeCastableToInt()
        {
            // Arrange
            FFmpegProfile profile = FFmpegProfile.High10;

            // Act
            int value = (int) profile;

            // Assert
            Assert.Equal(4, value);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should be castable from int
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldBeCastableFromInt()
        {
            // Arrange
            int value = 3;

            // Act
            FFmpegProfile profile = (FFmpegProfile) value;

            // Assert
            Assert.Equal(FFmpegProfile.High, profile);
        }

        /// <summary>
        ///     Tests that ffmpeg profile should be usable in switch statement
        /// </summary>
        [Fact]
        public void FFmpegProfile_ShouldBeUsableInSwitchStatement()
        {
            // Arrange
            FFmpegProfile profile = FFmpegProfile.Baseline;
            string result = string.Empty;

            // Act
            switch (profile)
            {
                case FFmpegProfile.Auto:
                    result = "Auto";
                    break;
                case FFmpegProfile.Baseline:
                    result = "Baseline";
                    break;
                case FFmpegProfile.Main:
                    result = "Main";
                    break;
                case FFmpegProfile.High:
                    result = "High";
                    break;
                case FFmpegProfile.High10:
                    result = "High10";
                    break;
                case FFmpegProfile.High442:
                    result = "High442";
                    break;
                case FFmpegProfile.High444:
                    result = "High444";
                    break;
            }

            // Assert
            Assert.Equal("Baseline", result);
        }
    }
}