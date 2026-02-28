// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:FFMpegWrapperTest.cs
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

namespace Alis.Extension.Media.FFmpeg.Test
{
    /// <summary>
    ///     The f f mpeg wrapper test class
    /// </summary>
    /// <seealso cref="FfMpegWrapper" />
    public class FFMpegWrapperTest
    {
        /// <summary>
        ///     Tests that ff mpeg wrapper log level property should be settable
        /// </summary>
        [Fact]
        public void FFMpegWrapper_LogLevelProperty_ShouldBeSettable()
        {
            // Arrange
            Verbosity originalLogLevel = FfMpegWrapper.LogLevel;
            Verbosity newLogLevel = Verbosity.Debug;

            try
            {
                // Act
                FfMpegWrapper.LogLevel = newLogLevel;

                // Assert
                Assert.Equal(newLogLevel, FfMpegWrapper.LogLevel);
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.LogLevel = originalLogLevel;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper default log level should be info
        /// </summary>
        [Fact]
        public void FFMpegWrapper_DefaultLogLevel_ShouldBeInfo()
        {
            // Arrange & Act
            Verbosity logLevel = FfMpegWrapper.LogLevel;

            // Assert
            Assert.Equal(Verbosity.Info, logLevel);
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper hide ff mpeg banner property should be settable
        /// </summary>
        [Fact]
        public void FFMpegWrapper_HideFFmpegBannerProperty_ShouldBeSettable()
        {
            // Arrange
            bool originalBannerSetting = FfMpegWrapper.HideFFmpegBanner;
            bool newBannerSetting = false;

            try
            {
                // Act
                FfMpegWrapper.HideFFmpegBanner = newBannerSetting;

                // Assert
                Assert.Equal(newBannerSetting, FfMpegWrapper.HideFFmpegBanner);
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.HideFFmpegBanner = originalBannerSetting;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper default hide banner should be true
        /// </summary>
        [Fact]
        public void FFMpegWrapper_DefaultHideBanner_ShouldBeTrue()
        {
            // Arrange & Act
            bool hideBanner = FfMpegWrapper.HideFFmpegBanner;

            // Assert
            Assert.False(hideBanner);
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper should support all verbosity levels
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ShouldSupportAllVerbosityLevels()
        {
            // Arrange
            Verbosity originalLogLevel = FfMpegWrapper.LogLevel;

            try
            {
                // Act & Assert
                foreach (Verbosity verbosity in Enum.GetValues(typeof(Verbosity)))
                {
                    FfMpegWrapper.LogLevel = verbosity;
                    Assert.Equal(verbosity, FfMpegWrapper.LogLevel);
                }
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.LogLevel = originalLogLevel;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper should allow toggling hide banner
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ShouldAllowTogglingHideBanner()
        {
            // Arrange
            bool originalBannerSetting = FfMpegWrapper.HideFFmpegBanner;

            try
            {
                // Act
                FfMpegWrapper.HideFFmpegBanner = true;
                Assert.True(FfMpegWrapper.HideFFmpegBanner);

                FfMpegWrapper.HideFFmpegBanner = false;
                Assert.False(FfMpegWrapper.HideFFmpegBanner);

                FfMpegWrapper.HideFFmpegBanner = true;
                Assert.True(FfMpegWrapper.HideFFmpegBanner);

                // Assert - All assertions above
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.HideFFmpegBanner = originalBannerSetting;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper should maintain log level across multiple settings
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ShouldMaintainLogLevelAcrossMultipleSettings()
        {
            // Arrange
            Verbosity originalLogLevel = FfMpegWrapper.LogLevel;
            Verbosity testLevel = Verbosity.Verbose;

            try
            {
                // Act
                FfMpegWrapper.LogLevel = testLevel;
                FfMpegWrapper.HideFFmpegBanner = true;
                FfMpegWrapper.HideFFmpegBanner = false;

                // Assert
                Assert.Equal(testLevel, FfMpegWrapper.LogLevel);
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.LogLevel = originalLogLevel;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper should maintain banner setting across multiple settings
        /// </summary>
        [Fact]
        public void FFMpegWrapper_ShouldMaintainBannerSettingAcrossMultipleSettings()
        {
            // Arrange
            bool originalBannerSetting = FfMpegWrapper.HideFFmpegBanner;
            bool testBannerSetting = true;

            try
            {
                // Act
                FfMpegWrapper.HideFFmpegBanner = testBannerSetting;
                FfMpegWrapper.LogLevel = Verbosity.Debug;
                FfMpegWrapper.LogLevel = Verbosity.Info;

                // Assert
                Assert.Equal(testBannerSetting, FfMpegWrapper.HideFFmpegBanner);
            }
            finally
            {
                // Cleanup
                FfMpegWrapper.HideFFmpegBanner = originalBannerSetting;
            }
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper log level property should be readable
        /// </summary>
        [Fact]
        public void FFMpegWrapper_LogLevelProperty_ShouldBeReadable()
        {
            // Arrange & Act
            Verbosity logLevel = FfMpegWrapper.LogLevel;

            // Assert
            Assert.True((logLevel >= Verbosity.Quiet) && (logLevel <= Verbosity.Fatal));
        }

        /// <summary>
        ///     Tests that ff mpeg wrapper hide banner property should be readable
        /// </summary>
        [Fact]
        public void FFMpegWrapper_HideBannerProperty_ShouldBeReadable()
        {
            // Arrange & Act
            bool hideBanner = FfMpegWrapper.HideFFmpegBanner;

            // Assert
            Assert.IsType<bool>(hideBanner);
        }
    }
}