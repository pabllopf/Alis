// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancedAdsManagerTest.cs
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
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Ads.GoogleAds.Test
{
    /// <summary>
    ///     Advanced test cases for AdsManager
    /// </summary>
    public class AdvancedAdsManagerTest
    {
        /// <summary>
        ///     Tests that banner ad without initialization shows error
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithoutInitialization_ShouldThrowException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Act & Assert
            await Assert.ThrowsAsync<InvalidOperationException>(() => manager.LoadBannerAdAsync("banner-id")
            );
        }

        /// <summary>
        ///     Tests that null ad unit ID throws exception
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithNullUnitId_ShouldThrowArgumentException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadBannerAdAsync(null)
            );
        }

        /// <summary>
        ///     Tests that empty ad unit ID throws exception
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WithEmptyUnitId_ShouldThrowArgumentException()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act & Assert
            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadBannerAdAsync(string.Empty)
            );
        }

        /// <summary>
        ///     Tests that interstitial ad state resets after showing
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_ShouldResetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadInterstitialAdAsync("interstitial-id");

            Assert.True(manager.IsInterstitialAdLoaded);

            // Act
            manager.ShowInterstitialAd();

            // Assert
            Assert.False(manager.IsInterstitialAdLoaded);
        }

        /// <summary>
        ///     Tests that rewarded video state resets after showing
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_ShouldResetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            Assert.True(manager.IsRewardedVideoAdLoaded);

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        /// <summary>
        ///     Tests hiding banner ad without showing it first
        /// </summary>
        [Fact]
        public async Task HideBannerAd_WithoutShowingFirst_ShouldNotThrow()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act & Assert - Should not throw
            manager.HideBannerAd();
        }

        /// <summary>
        ///     Tests that configuration properties are preserved
        /// </summary>
        [Fact]
        public async Task Initialize_ShouldPreserveConfigurationProperties()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration(
                "test-app-id",
                "banner-123",
                "interstitial-456",
                "rewarded-789"
            )
            {
                IsTestMode = true,
                IsEnabled = true
            };

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests reward event args contain correct information
        /// </summary>
        [Fact]
        public async Task OnAdRewarded_ShouldProvideCorrectRewardArgs()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            AdRewardEventArgs capturedArgs = null;
            manager.OnAdRewarded += args => capturedArgs = args;

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.NotNull(capturedArgs);
            Assert.NotNull(capturedArgs.RewardType);
            Assert.NotNull(capturedArgs.AdUnitId);
            Assert.True(capturedArgs.RewardAmount > 0);
        }

        /// <summary>
        ///     Tests multiple load and show cycles
        /// </summary>
        [Fact]
        public async Task MultipleBannerLoadAndShowCycles_ShouldWork()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act & Assert - Multiple cycles
            for (int i = 0; i < 3; i++)
            {
                await manager.LoadBannerAdAsync("banner-id");
                Assert.True(manager.IsBannerAdLoaded);

                manager.ShowBannerAd();
                manager.HideBannerAd();
            }
        }

        /// <summary>
        ///     Tests interstitial ad cannot be shown without loading
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_WithoutLoading_ShouldNotThrow()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            // Act & Assert - Should log error but not throw
            manager.ShowInterstitialAd();
        }

        /// <summary>
        ///     Tests banner ad visibility state is independent of load state
        /// </summary>
        [Fact]
        public async Task BannerAdVisibility_ShouldBeIndependentOfLoadState()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");

            // Act
            manager.ShowBannerAd(); // Show it
            manager.HideBannerAd(); // Hide it
            manager.ShowBannerAd(); // Show again

            // Assert
            Assert.True(manager.IsBannerAdLoaded); // Should still be loaded
        }

        /// <summary>
        ///     Tests configuration with logging level
        /// </summary>
        [Fact]
        public async Task Initialize_WithDifferentLoggingLevels_ShouldWork()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Test each logging level
            foreach (AdLoggingLevel level in Enum.GetValues(typeof(AdLoggingLevel)))
            {
                AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id")
                {
                    LoggingLevel = level
                };

                // Act
                await manager.InitializeAsync(config);

                // Assert
                Assert.True(manager.IsInitialized);
            }
        }

        /// <summary>
        ///     Tests that events can be unsubscribed
        /// </summary>
        [Fact]
        public async Task UnsubscribeFromEvent_ShouldNotTriggerEvent()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
            await manager.InitializeAsync(config);

            bool eventTriggered = false;
            Action<string> handler = unitId => { eventTriggered = true; };

            manager.OnBannerAdLoaded += handler;
            await manager.LoadBannerAdAsync("banner-id");

            Assert.True(eventTriggered);

            // Act
            eventTriggered = false;
            manager.OnBannerAdLoaded -= handler;
            await manager.LoadBannerAdAsync("banner-id-2");

            // Assert
            Assert.False(eventTriggered);
        }

        /// <summary>
        ///     Tests manager with custom ID, name and tag
        /// </summary>
        [Fact]
        public async Task CustomManagerProperties_ShouldBeSet()
        {
            // Arrange
            Mock<Context> mockContext = new Mock<Context>();
            string customId = "custom-ads-manager-id";
            string customName = "CustomAdsManager";
            string customTag = "CustomAds";

            AdsManager manager = new AdsManager(customId, customName, customTag, true, mockContext.Object);
            AdConfiguration config = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");

            // Act
            await manager.InitializeAsync(config);

            // Assert
            Assert.Equal(customId, manager.Id);
            Assert.Equal(customName, manager.Name);
            Assert.Equal(customTag, manager.Tag);
            Assert.True(manager.IsInitialized);
        }
    }
}