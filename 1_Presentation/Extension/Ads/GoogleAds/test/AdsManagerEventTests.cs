// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManagerEventTests.cs
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
    ///     Tests for AdsManager events and happy path scenarios.
    /// </summary>
    public class AdsManagerEventTests
    {
        private AdConfiguration CreateConfig(string appId = "app-id", string bannerId = "banner-id",
            string interstitialId = "interstitial-id", string rewardedId = "rewarded-id")
        {
            return new AdConfiguration(appId, bannerId, interstitialId, rewardedId);
        }

        private Mock<Context> CreateContext()
        {
            return new Mock<Context>();
        }

        #region ShowBannerAd Happy Path Tests

        /// <summary>
        ///     Tests that ShowBannerAd sets visibility to true when initialized and ad is loaded.
        /// </summary>
        [Fact]
        public async Task ShowBannerAd_HappyPath_ShouldSetVisibilityTrue()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");

            // Act
            manager.ShowBannerAd();

            // Assert
            Assert.True(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that ShowBannerAd without initialization does not set visibility.
        /// </summary>
        [Fact]
        public void ShowBannerAd_WithoutInitialization_ShouldNotSetVisibility()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Act
            manager.ShowBannerAd();

            // Assert
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that ShowBannerAd without loading does not set visibility.
        /// </summary>
        [Fact]
        public async Task ShowBannerAd_WithoutLoading_ShouldNotSetVisibility()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            // Act
            manager.ShowBannerAd();

            // Assert
            Assert.False(manager.IsBannerAdLoaded);
        }

        #endregion

        #region HideBannerAd Happy Path Tests

        /// <summary>
        ///     Tests that HideBannerAd sets visibility to false when initialized.
        /// </summary>
        [Fact]
        public async Task HideBannerAd_HappyPath_ShouldSetVisibilityFalse()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            // Act
            manager.HideBannerAd();

            // Assert
            Assert.True(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that HideBannerAd without initialization does not throw.
        /// </summary>
        [Fact]
        public void HideBannerAd_WithoutInitialization_ShouldNotThrow()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Act & Assert
            // Should not throw
            manager.HideBannerAd();
            Assert.False(manager.IsInitialized);
        }

        #endregion

        #region OnBannerAdLoaded Event Tests

        /// <summary>
        ///     Tests that OnBannerAdLoaded event fires with correct ad unit ID.
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_ShouldTriggerOnBannerAdLoadedEvent()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnBannerAdLoaded += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadBannerAdAsync("test-banner-unit");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("test-banner-unit", capturedAdUnitId);
        }

        /// <summary>
        ///     Tests that OnBannerAdLoaded event does not fire when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WhenAdsDisabled_ShouldNotTriggerOnBannerAdLoaded()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnBannerAdLoaded += _ => { eventFired = true; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.False(eventFired);
            Assert.False(manager.IsBannerAdLoaded);
        }

        #endregion

        #region OnBannerAdFailedToLoad Event Tests

        /// <summary>
        ///     Tests that OnBannerAdFailedToLoad event fires when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WhenAdsDisabled_ShouldTriggerOnBannerAdFailedToLoad()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnBannerAdFailedToLoad += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("banner-id", capturedAdUnitId);
        }

        /// <summary>
        ///     Tests that OnBannerAdFailedToLoad event does not fire on successful load.
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_Success_ShouldNotTriggerOnBannerAdFailedToLoad()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnBannerAdFailedToLoad += _ => { eventFired = true; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.False(eventFired);
            Assert.True(manager.IsBannerAdLoaded);
        }

        #endregion

        #region OnInterstitialAdLoaded Event Tests

        /// <summary>
        ///     Tests that OnInterstitialAdLoaded event fires with correct ad unit ID.
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_ShouldTriggerOnInterstitialAdLoadedEvent()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnInterstitialAdLoaded += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadInterstitialAdAsync("test-interstitial-unit");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("test-interstitial-unit", capturedAdUnitId);
        }

        /// <summary>
        ///     Tests that OnInterstitialAdLoaded event does not fire when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WhenAdsDisabled_ShouldNotTriggerOnInterstitialAdLoaded()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnInterstitialAdLoaded += _ => { eventFired = true; };

            // Act
            await manager.LoadInterstitialAdAsync("interstitial-id");

            // Assert
            Assert.False(eventFired);
            Assert.False(manager.IsInterstitialAdLoaded);
        }

        #endregion

        #region OnInterstitialAdFailedToLoad Event Tests

        /// <summary>
        ///     Tests that OnInterstitialAdFailedToLoad event fires when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WhenAdsDisabled_ShouldTriggerOnInterstitialAdFailedToLoad()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnInterstitialAdFailedToLoad += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadInterstitialAdAsync("interstitial-id");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("interstitial-id", capturedAdUnitId);
        }

        #endregion

        #region OnRewardedVideoAdLoaded Event Tests

        /// <summary>
        ///     Tests that OnRewardedVideoAdLoaded event fires with correct ad unit ID.
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_ShouldTriggerOnRewardedVideoAdLoadedEvent()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnRewardedVideoAdLoaded += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadRewardedVideoAdAsync("test-rewarded-unit");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("test-rewarded-unit", capturedAdUnitId);
        }

        /// <summary>
        ///     Tests that OnRewardedVideoAdLoaded event does not fire when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WhenAdsDisabled_ShouldNotTriggerOnRewardedVideoAdLoaded()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnRewardedVideoAdLoaded += _ => { eventFired = true; };

            // Act
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Assert
            Assert.False(eventFired);
            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        #endregion

        #region OnRewardedVideoAdFailedToLoad Event Tests

        /// <summary>
        ///     Tests that OnRewardedVideoAdFailedToLoad event fires when ads are disabled.
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WhenAdsDisabled_ShouldTriggerOnRewardedVideoAdFailedToLoad()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            string capturedAdUnitId = null;
            manager.OnRewardedVideoAdFailedToLoad += adUnitId => { capturedAdUnitId = adUnitId; };

            // Act
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Assert
            Assert.NotNull(capturedAdUnitId);
            Assert.Equal("rewarded-id", capturedAdUnitId);
        }

        #endregion

        #region OnAdClicked Event Tests

        /// <summary>
        ///     Tests that OnAdClicked event fires with "interstitial" when showing interstitial ad.
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_ShouldTriggerOnAdClickedWithInterstitial()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadInterstitialAdAsync("interstitial-id");

            string capturedSource = null;
            manager.OnAdClicked += source => { capturedSource = source; };

            // Act
            manager.ShowInterstitialAd();

            // Assert
            Assert.NotNull(capturedSource);
            Assert.Equal("interstitial", capturedSource);
        }

        /// <summary>
        ///     Tests that OnAdClicked event fires with "rewarded_video" when showing rewarded video ad.
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_ShouldTriggerOnAdClickedWithRewardedVideo()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            string capturedSource = null;
            manager.OnAdClicked += source => { capturedSource = source; };

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.NotNull(capturedSource);
            Assert.Equal("rewarded_video", capturedSource);
        }

        /// <summary>
        ///     Tests that OnAdClicked event does not fire when interstitial is not loaded.
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_WithoutLoading_ShouldNotTriggerOnAdClicked()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnAdClicked += _ => { eventFired = true; };

            // Act
            manager.ShowInterstitialAd();

            // Assert
            Assert.False(eventFired);
        }

        /// <summary>
        ///     Tests that OnAdClicked event does not fire when rewarded video is not loaded.
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_WithoutLoading_ShouldNotTriggerOnAdClicked()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnAdClicked += _ => { eventFired = true; };

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.False(eventFired);
        }

        #endregion

        #region OnAdClosed Event Tests

        /// <summary>
        ///     Tests that OnAdClosed event fires with "all" when disposing.
        /// </summary>
        [Fact]
        public async Task Dispose_ShouldTriggerOnAdClosedWithAll()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            string capturedSource = null;
            manager.OnAdClosed += source => { capturedSource = source; };

            // Act
            manager.Dispose();

            // Assert
            Assert.NotNull(capturedSource);
            Assert.Equal("all", capturedSource);
        }

        /// <summary>
        ///     Tests that OnAdClosed event does not fire without initialization.
        /// </summary>
        [Fact]
        public void Dispose_WithoutInitialization_ShouldNotTriggerOnAdClosed()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            bool eventFired = false;
            manager.OnAdClosed += _ => { eventFired = true; };

            // Act
            manager.Dispose();

            // Assert
            Assert.False(eventFired);
        }

        #endregion

        #region OnAdRewarded Event Tests

        /// <summary>
        ///     Tests that OnAdRewarded event fires with correct reward data.
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_ShouldTriggerOnAdRewardedWithCorrectData()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            AdRewardEventArgs capturedArgs = null;
            manager.OnAdRewarded += args => { capturedArgs = args; };

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.NotNull(capturedArgs);
            Assert.Equal("coins", capturedArgs.RewardType);
            Assert.Equal(10, capturedArgs.RewardAmount);
            Assert.Equal("rewarded_video_unit", capturedArgs.AdUnitId);
        }

        /// <summary>
        ///     Tests that OnAdRewarded event does not fire when rewarded video is not loaded.
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_WithoutLoading_ShouldNotTriggerOnAdRewarded()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            bool eventFired = false;
            manager.OnAdRewarded += _ => { eventFired = true; };

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.False(eventFired);
        }

        #endregion

        #region Multiple Event Subscriptions Tests

        /// <summary>
        ///     Tests that multiple subscribers to OnBannerAdLoaded all receive the event.
        /// </summary>
        [Fact]
        public async Task MultipleSubscribersToOnBannerAdLoaded_ShouldAllReceiveEvent()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            int callCount = 0;
            manager.OnBannerAdLoaded += _ => { callCount++; };
            manager.OnBannerAdLoaded += _ => { callCount++; };

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.Equal(2, callCount);
        }

        /// <summary>
        ///     Tests that events can be subscribed and unsubscribed multiple times.
        /// </summary>
        [Fact]
        public async Task SubscribeAndUnsubscribeMultipleTimes_ShouldWorkCorrectly()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            int callCount = 0;
            Action<string> handler = _ => { callCount++; };

            // Act - subscribe, fire, unsubscribe, fire again
            manager.OnBannerAdLoaded += handler;
            await manager.LoadBannerAdAsync("banner-1");
            Assert.Equal(1, callCount);

            manager.OnBannerAdLoaded -= handler;
            await manager.LoadBannerAdAsync("banner-2");

            // Assert
            Assert.Equal(1, callCount);
        }

        #endregion

        #region Banner Ad Visibility State Tests

        /// <summary>
        ///     Tests that banner ad visibility can be toggled multiple times.
        /// </summary>
        [Fact]
        public async Task BannerAdVisibility_ShouldBeTogglableMultipleTimes()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");

            // Act & Assert - show, hide, show, hide
            manager.ShowBannerAd();
            manager.HideBannerAd();
            manager.ShowBannerAd();
            manager.HideBannerAd();

            Assert.True(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that banner ad load state persists after hide.
        /// </summary>
        [Fact]
        public async Task HideBannerAd_ShouldNotAffectLoadState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadBannerAdAsync("banner-id");

            // Act
            manager.HideBannerAd();

            // Assert
            Assert.True(manager.IsBannerAdLoaded);
        }

        #endregion

        #region Interstitial Ad State Tests

        /// <summary>
        ///     Tests that interstitial ad load state is reset after show.
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_ShouldResetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadInterstitialAdAsync("interstitial-id");

            // Act
            manager.ShowInterstitialAd();

            // Assert
            Assert.False(manager.IsInterstitialAdLoaded);
        }

        /// <summary>
        ///     Tests that interstitial ad can be reloaded after being shown.
        /// </summary>
        [Fact]
        public async Task InterstitialAd_ShouldBeReloadableAfterShow()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            // Act - load, show, reload
            await manager.LoadInterstitialAdAsync("interstitial-id");
            manager.ShowInterstitialAd();
            await manager.LoadInterstitialAdAsync("interstitial-id-2");

            // Assert
            Assert.True(manager.IsInterstitialAdLoaded);
        }

        #endregion

        #region Rewarded Video Ad State Tests

        /// <summary>
        ///     Tests that rewarded video ad load state is reset after show.
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_ShouldResetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Act
            manager.ShowRewardedVideoAd();

            // Assert
            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        /// <summary>
        ///     Tests that rewarded video ad can be reloaded after being shown.
        /// </summary>
        [Fact]
        public async Task RewardedVideoAd_ShouldBeReloadableAfterShow()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            await manager.InitializeAsync(config);

            // Act - load, show, reload
            await manager.LoadRewardedVideoAdAsync("rewarded-id");
            manager.ShowRewardedVideoAd();
            await manager.LoadRewardedVideoAdAsync("rewarded-id-2");

            // Assert
            Assert.True(manager.IsRewardedVideoAdLoaded);
        }

        #endregion

        #region Disabled Ads Tests

        /// <summary>
        ///     Tests that loading banner ad when disabled does not set loaded state.
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WhenDisabled_ShouldNotSetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            // Act
            await manager.LoadBannerAdAsync("banner-id");

            // Assert
            Assert.False(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that loading interstitial ad when disabled does not set loaded state.
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WhenDisabled_ShouldNotSetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            // Act
            await manager.LoadInterstitialAdAsync("interstitial-id");

            // Assert
            Assert.False(manager.IsInterstitialAdLoaded);
        }

        /// <summary>
        ///     Tests that loading rewarded video ad when disabled does not set loaded state.
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WhenDisabled_ShouldNotSetLoadedState()
        {
            // Arrange
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = CreateConfig();
            config.IsEnabled = false;
            await manager.InitializeAsync(config);

            // Act
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            // Assert
            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        #endregion

        #region Initialization State Tests

        /// <summary>
        ///     Tests that IsInitialized is false before initialization.
        /// </summary>
        [Fact]
        public void IsInitialized_BeforeInitialization_ShouldBeFalse()
        {
            // Arrange & Act
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Assert
            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that IsBannerAdLoaded is false before loading.
        /// </summary>
        [Fact]
        public void IsBannerAdLoaded_BeforeLoading_ShouldBeFalse()
        {
            // Arrange & Act
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Assert
            Assert.False(manager.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that IsInterstitialAdLoaded is false before loading.
        /// </summary>
        [Fact]
        public void IsInterstitialAdLoaded_BeforeLoading_ShouldBeFalse()
        {
            // Arrange & Act
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Assert
            Assert.False(manager.IsInterstitialAdLoaded);
        }

        /// <summary>
        ///     Tests that IsRewardedVideoAdLoaded is false before loading.
        /// </summary>
        [Fact]
        public void IsRewardedVideoAdLoaded_BeforeLoading_ShouldBeFalse()
        {
            // Arrange & Act
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Assert
            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        #endregion
    }
}
