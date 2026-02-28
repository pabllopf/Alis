// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManagerTest.cs
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
using System.Threading.Tasks;
using Moq;
using Xunit;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Ads.GoogleAds.Test
{
    /// <summary>
    ///     The ads manager test class
    /// </summary>
    public class AdsManagerTest
    {
        /// <summary>
        ///     Tests that ads manager initialization works correctly
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithValidConfiguration_ShouldInitializeSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration(
                "test-app-id",
                "banner-unit-id",
                "interstitial-unit-id",
                "rewarded-unit-id"
            );

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that ads manager throws on null configuration
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullConfiguration_ShouldThrowArgumentNullException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentNullException>(async () => await manager.InitializeAsync(null));
        }

        /// <summary>
        ///     Tests that ads manager throws on null app id
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullAppId_ShouldThrowArgumentException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration(null, "banner-id", "interstitial-id", "rewarded-id");

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(async () => await manager.InitializeAsync(config));
        }

        /// <summary>
        ///     Tests that banner ad loading works correctly
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithValidUnitId_ShouldLoadSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            bool eventTriggered = false;
            manager.OnBannerAdLoaded += (unitId) => { eventTriggered = true; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.True(manager.IsBannerAdLoaded);
            Assert.True(eventTriggered);
        }

        /// <summary>
        ///     Tests that loading banner ad without initialization throws
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithoutInitialization_ShouldThrowInvalidOperationException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(async () => await manager.LoadBannerAdAsync("banner-id"));
        }

        /// <summary>
        ///     Tests that showing banner ad works correctly
        /// </summary>
        [Fact]
        public async Task ShowBannerAd_WithLoadedAd_ShouldShowSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");

            // Act
            manager.ShowBannerAd();

            // Assert - no exception should be thrown
            Assert.True(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that hiding banner ad works correctly
        /// </summary>
        [Fact]
        public async Task HideBannerAd_WithVisibleAd_ShouldHideSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");
            manager.ShowBannerAd();

            // Act
            manager.HideBannerAd();

            // Assert - no exception should be thrown
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that interstitial ad loading works correctly
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WithValidUnitId_ShouldLoadSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            bool eventTriggered = false;
            manager.OnInterstitialAdLoaded += (unitId) => { eventTriggered = true; };

            // Act
            await manager.LoadInterstitialAdAsync("interstitial-id");

            // Assert
            Assert.True(manager.IsInterstitialAdLoaded);
            Assert.True(eventTriggered);
        }

        /// <summary>
        ///     Tests that showing interstitial ad works correctly
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_WithLoadedAd_ShouldShowSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadInterstitialAdAsync("interstitial-id");

            bool clickEventTriggered = false;
            manager.OnAdClicked += (adType) => { clickEventTriggered = true; };

            // Act
            manager.ShowInterstitialAd();

            // Assert
            Assert.False(manager.IsInterstitialAdLoaded); // Should reset after showing
            Assert.True(clickEventTriggered);
        }

        /// <summary>
        ///     Tests that rewarded video ad loading works correctly
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WithValidUnitId_ShouldLoadSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            bool eventTriggered = false;
            manager.OnRewardedVideoAdLoaded += (unitId) => { eventTriggered = true; };

            // Act
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Assert
            Assert.True(manager.IsRewardedVideoAdLoaded);
            Assert.True(eventTriggered);
        }

        /// <summary>
        ///     Tests that showing rewarded video ad triggers reward event
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_WithLoadedAd_ShouldTriggerRewardEvent()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            bool rewardEventTriggered = false;
            AdRewardEventArgs rewardArgs = null;
            manager.OnAdRewarded += (args) =>
            {
                rewardEventTriggered = true;
                rewardArgs = args;
            };

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.True(rewardEventTriggered);
            Assert.NotNull(rewardArgs);
            Assert.Equal("coins", rewardArgs.RewardType);
            Assert.Equal(10, rewardArgs.RewardAmount);
        }

        /// <summary>
        ///     Tests that showing banner ad without loading fails gracefully
        /// </summary>
        [Fact]
        public async Task ShowBannerAd_WithoutLoadingAd_ShouldLogErrorAndNotShow()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act - Should not throw, just log
            manager.ShowBannerAd();

            // Assert
            Assert.False(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that loading ad with disabled ads triggers failure event
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithDisabledAds_ShouldTriggerFailureEvent()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id")
            {
                IsEnabled = false
            };
            await manager.InitializeAsync(config);

            bool failureEventTriggered = false;
            manager.OnBannerAdFailedToLoad += (unitId) => { failureEventTriggered = true; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.True(failureEventTriggered);
            Assert.False(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that multiple ad types can be loaded simultaneously
        /// </summary>
        [Fact]
        public async Task LoadMultipleAdTypes_ShouldLoadAllSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act
            await manager.LoadBannerAdAsync("banner-id");
            await manager.LoadInterstitialAdAsync("interstitial-id");
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Assert
            Assert.True(manager.IsBannerAdLoaded);
            Assert.True(manager.IsInterstitialAdLoaded);
            Assert.True(manager.IsRewardedVideoAdLoaded);
        }

        /// <summary>
        ///     Tests that ad event chains work correctly
        /// </summary>
        [Fact]
        public async Task AdEventChain_WithMultipleSubscribers_ShouldFireForAllSubscribers()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            bool subscriber1Triggered = false;
            bool subscriber2Triggered = false;

            manager.OnBannerAdLoaded += (unitId) => { subscriber1Triggered = true; };
            manager.OnBannerAdLoaded += (unitId) => { subscriber2Triggered = true; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.True(subscriber1Triggered);
            Assert.True(subscriber2Triggered);
        }

        /// <summary>
        ///     Tests configuration with test mode
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithTestModeEnabled_ShouldInitializeInTestMode()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id")
            {
                IsTestMode = true
            };

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that constructor with all parameters works correctly
        /// </summary>
        [Fact]
        public void Constructor_WithAllParameters_ShouldCreateManagerSuccessfully()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();

            // Act
            AdsManager manager = new AdsManager("test-id", "TestAdsManager", "Ads", true, mockContext.Object);

            // Assert
            Assert.NotNull(manager);
            Assert.Equal("test-id", manager.Id);
            Assert.Equal("TestAdsManager", manager.Name);
            Assert.Equal("Ads", manager.Tag);
        }
    }
}