// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdConfigurationTest.cs
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
    ///     Tests for AdConfiguration class and AdLoggingLevel enum
    /// </summary>
    public class AdConfigurationTest
    {
        /// <summary>
        ///     Tests that default constructor creates configuration with sensible defaults
        /// </summary>
        [Fact]
        public void DefaultConstructor_ShouldSetDefaults()
        {
            AdConfiguration config = new AdConfiguration();

            Assert.Null(config.AppId);
            Assert.Null(config.DefaultBannerAdUnitId);
            Assert.Null(config.DefaultInterstitialAdUnitId);
            Assert.Null(config.DefaultRewardedVideoAdUnitId);
            Assert.True(config.IsEnabled);
            Assert.False(config.IsTestMode);
            Assert.Equal(AdLoggingLevel.Info, config.LoggingLevel);
        }

        /// <summary>
        ///     Tests that parameterized constructor sets all properties correctly
        /// </summary>
        [Fact]
        public void ParameterizedConstructor_ShouldSetAllProperties()
        {
            AdConfiguration config = new AdConfiguration(
                "app-123",
                "banner-456",
                "interstitial-789",
                "rewarded-012"
            );

            Assert.Equal("app-123", config.AppId);
            Assert.Equal("banner-456", config.DefaultBannerAdUnitId);
            Assert.Equal("interstitial-789", config.DefaultInterstitialAdUnitId);
            Assert.Equal("rewarded-012", config.DefaultRewardedVideoAdUnitId);
        }

        /// <summary>
        ///     Tests that IsEnabled property can be toggled
        /// </summary>
        [Fact]
        public void IsEnabled_ShouldBeTogglable()
        {
            AdConfiguration config = new AdConfiguration();

            config.IsEnabled = false;
            Assert.False(config.IsEnabled);

            config.IsEnabled = true;
            Assert.True(config.IsEnabled);
        }

        /// <summary>
        ///     Tests that IsTestMode property can be toggled
        /// </summary>
        [Fact]
        public void IsTestMode_ShouldBeTogglable()
        {
            AdConfiguration config = new AdConfiguration();

            config.IsTestMode = true;
            Assert.True(config.IsTestMode);

            config.IsTestMode = false;
            Assert.False(config.IsTestMode);
        }

        /// <summary>
        ///     Tests that LoggingLevel property can be set to any enum value
        /// </summary>
        [Fact]
        public void LoggingLevel_ShouldAcceptAllEnumValues()
        {
            AdConfiguration config = new AdConfiguration();

            config.LoggingLevel = AdLoggingLevel.None;
            Assert.Equal(AdLoggingLevel.None, config.LoggingLevel);

            config.LoggingLevel = AdLoggingLevel.Info;
            Assert.Equal(AdLoggingLevel.Info, config.LoggingLevel);

            config.LoggingLevel = AdLoggingLevel.Debug;
            Assert.Equal(AdLoggingLevel.Debug, config.LoggingLevel);

            config.LoggingLevel = AdLoggingLevel.Verbose;
            Assert.Equal(AdLoggingLevel.Verbose, config.LoggingLevel);
        }

        /// <summary>
        ///     Tests that individual properties can be set after construction
        /// </summary>
        [Fact]
        public void Properties_ShouldBeSettableAfterConstruction()
        {
            AdConfiguration config = new AdConfiguration("app-id", "banner", "interstitial", "rewarded");

            config.AppId = "new-app-id";
            config.DefaultBannerAdUnitId = "new-banner";
            config.DefaultInterstitialAdUnitId = "new-interstitial";
            config.DefaultRewardedVideoAdUnitId = "new-rewarded";

            Assert.Equal("new-app-id", config.AppId);
            Assert.Equal("new-banner", config.DefaultBannerAdUnitId);
            Assert.Equal("new-interstitial", config.DefaultInterstitialAdUnitId);
            Assert.Equal("new-rewarded", config.DefaultRewardedVideoAdUnitId);
        }

        /// <summary>
        ///     Tests that properties can be set to null or empty strings
        /// </summary>
        [Fact]
        public void StringProperties_ShouldAcceptNullAndEmptyValues()
        {
            AdConfiguration config = new AdConfiguration("app-id", "banner", "interstitial", "rewarded");

            config.AppId = null;
            config.DefaultBannerAdUnitId = string.Empty;
            config.DefaultInterstitialAdUnitId = null;
            config.DefaultRewardedVideoAdUnitId = string.Empty;

            Assert.Null(config.AppId);
            Assert.Equal(string.Empty, config.DefaultBannerAdUnitId);
            Assert.Null(config.DefaultInterstitialAdUnitId);
            Assert.Equal(string.Empty, config.DefaultRewardedVideoAdUnitId);
        }

        /// <summary>
        ///     Tests that AdLoggingLevel enum has expected values
        /// </summary>
        [Fact]
        public void AdLoggingLevel_Enum_ShouldHaveExpectedValues()
        {
            Assert.Equal(0, (int)AdLoggingLevel.None);
            Assert.Equal(1, (int)AdLoggingLevel.Info);
            Assert.Equal(2, (int)AdLoggingLevel.Debug);
            Assert.Equal(3, (int)AdLoggingLevel.Verbose);
        }

        /// <summary>
        ///     Tests that AdLoggingLevel enum has all expected members
        /// </summary>
        [Fact]
        public void AdLoggingLevel_Enum_ShouldHaveAllExpectedMembers()
        {
            AdLoggingLevel[] expectedValues = { AdLoggingLevel.None, AdLoggingLevel.Info, AdLoggingLevel.Debug, AdLoggingLevel.Verbose };
            AdLoggingLevel[] actualValues = (AdLoggingLevel[])Enum.GetValues(typeof(AdLoggingLevel));

            Assert.Equal(expectedValues.Length, actualValues.Length);
        }

        /// <summary>
        ///     Tests configuration with all properties set to non-default values
        /// </summary>
        [Fact]
        public void Configuration_WithAllNonDefaultValues_ShouldPreserveAll()
        {
            AdConfiguration config = new AdConfiguration("my-app", "my-banner", "my-interstitial", "my-rewarded")
            {
                IsEnabled = false,
                IsTestMode = true,
                LoggingLevel = AdLoggingLevel.Verbose
            };

            Assert.Equal("my-app", config.AppId);
            Assert.Equal("my-banner", config.DefaultBannerAdUnitId);
            Assert.Equal("my-interstitial", config.DefaultInterstitialAdUnitId);
            Assert.Equal("my-rewarded", config.DefaultRewardedVideoAdUnitId);
            Assert.False(config.IsEnabled);
            Assert.True(config.IsTestMode);
            Assert.Equal(AdLoggingLevel.Verbose, config.LoggingLevel);
        }
    }
}
