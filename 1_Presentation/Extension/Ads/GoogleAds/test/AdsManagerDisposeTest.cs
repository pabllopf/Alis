// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManagerDisposeTest.cs
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
    ///     Tests for AdsManager dispose pattern and remaining edge cases
    /// </summary>
    public class AdsManagerDisposeTest : IDisposable
    {
        /// <summary>
        /// The default config
        /// </summary>
        private AdConfiguration _defaultConfig;

        /// <summary>
        /// Initializes a new instance of the <see cref="AdsManagerDisposeTest"/> class
        /// </summary>
        public AdsManagerDisposeTest() => _defaultConfig = new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            // Cleanup if needed
        }

        #region Dispose Pattern Tests

        /// <summary>
        ///     Tests that Dispose can be called without throwing
        /// </summary>
        [Fact]
        public void Dispose_ShouldNotThrowException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Should not throw
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose can be called multiple times without throwing
        /// </summary>
        [Fact]
        public void Dispose_MultipleCalls_ShouldNotThrowException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            manager.Dispose();
            manager.Dispose();
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose works after initialization
        /// </summary>
        [Fact]
        public async Task Dispose_AfterInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            manager.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose works after loading ads
        /// </summary>
        [Fact]
        public async Task Dispose_AfterLoadingAds_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);
            await manager.LoadBannerAdAsync("banner-id");
            await manager.LoadInterstitialAdAsync("interstitial-id");
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            manager.Dispose();
        }

        /// <summary>
        ///     Tests that OnAdClosed event fires on Dispose
        /// </summary>
        [Fact]
        public async Task Dispose_ShouldTriggerOnAdClosedEvent()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            string closedSource = null;
            manager.OnAdClosed += source => { closedSource = source; };

            manager.Dispose();

            Assert.NotNull(closedSource);
            Assert.Equal("all", closedSource);
        }

        /// <summary>
        ///     Tests that Dispose(true) is protected virtual and can be overridden conceptually
        /// </summary>
        [Fact]
        public async Task Dispose_Pattern_ShouldFollowStandardDisposePattern()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            // The standard dispose pattern calls Dispose(true) then GC.SuppressFinalize
            // We verify this doesn't throw and the manager remains in a valid state
            manager.Dispose();

            // After dispose, IsInitialized should still be accessible (no null ref)
            Assert.True(manager.IsInitialized);
        }

        #endregion

        #region Sync Method Error Path Tests

        /// <summary>
        ///     Tests that ShowInterstitialAd without initialization logs error and does not throw
        /// </summary>
        [Fact]
        public void ShowInterstitialAd_WithoutInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Should not throw - just logs error
            manager.ShowInterstitialAd();

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that ShowRewardedVideoAd without initialization logs error and does not throw
        /// </summary>
        [Fact]
        public void ShowRewardedVideoAd_WithoutInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Should not throw - just logs error
            manager.ShowRewardedVideoAd();

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that ShowBannerAd without initialization logs error and does not throw
        /// </summary>
        [Fact]
        public void ShowBannerAd_WithoutInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Should not throw - just logs error
            manager.ShowBannerAd();

            Assert.False(manager.IsInitialized);
        }

        /// <summary>
        ///     Tests that HideBannerAd without initialization logs error and does not throw
        /// </summary>
        [Fact]
        public void HideBannerAd_WithoutInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            // Should not throw - just logs error
            manager.HideBannerAd();

            Assert.False(manager.IsInitialized);
        }

        #endregion

        #region LoadInterstitialAdAsync / LoadRewardedVideoAdAsync Validation Tests

        /// <summary>
        ///     Tests that LoadInterstitialAdAsync with null ad unit ID throws
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WithNullUnitId_ShouldThrowArgumentException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadInterstitialAdAsync(null));
        }

        /// <summary>
        ///     Tests that LoadInterstitialAdAsync with empty ad unit ID throws
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WithEmptyUnitId_ShouldThrowArgumentException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadInterstitialAdAsync(string.Empty));
        }

        /// <summary>
        ///     Tests that LoadInterstitialAdAsync without initialization throws
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WithoutInitialization_ShouldThrowInvalidOperationException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => manager.LoadInterstitialAdAsync("interstitial-id"));
        }

        /// <summary>
        ///     Tests that LoadRewardedVideoAdAsync with null ad unit ID throws
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WithNullUnitId_ShouldThrowArgumentException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadRewardedVideoAdAsync(null));
        }

        /// <summary>
        ///     Tests that LoadRewardedVideoAdAsync with empty ad unit ID throws
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WithEmptyUnitId_ShouldThrowArgumentException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            await Assert.ThrowsAsync<ArgumentException>(() => manager.LoadRewardedVideoAdAsync(string.Empty));
        }

        /// <summary>
        ///     Tests that LoadRewardedVideoAdAsync without initialization throws
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WithoutInitialization_ShouldThrowInvalidOperationException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            await Assert.ThrowsAsync<InvalidOperationException>(() => manager.LoadRewardedVideoAdAsync("rewarded-id"));
        }

        #endregion

        #region Show Without Load Tests

        /// <summary>
        ///     Tests that ShowRewardedVideoAd without loading logs error and does not throw
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_WithoutLoading_ShouldNotThrow()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);

            // Should not throw - just logs error
            manager.ShowRewardedVideoAd();

            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        #endregion

        #region Null Configuration Tests

        /// <summary>
        ///     Tests that InitializeAsync with null configuration throws
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithNullConfiguration_ShouldThrowArgumentNullException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);

            await Assert.ThrowsAsync<ArgumentNullException>(() => manager.InitializeAsync(null));
        }

        /// <summary>
        ///     Tests that InitializeAsync with empty AppId throws
        /// </summary>
        [Fact]
        public async Task InitializeAsync_WithEmptyAppId_ShouldThrowArgumentException()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            AdConfiguration config = new AdConfiguration(string.Empty, "banner", "interstitial", "rewarded");

            await Assert.ThrowsAsync<ArgumentException>(() => manager.InitializeAsync(config));
        }

        #endregion

        #region State Isolation Tests

        /// <summary>
        ///     Tests that two managers have independent state
        /// </summary>
        [Fact]
        public async Task TwoManagers_ShouldHaveIndependentState()
        {
            Mock<Context> mockContext1 = new Mock<Context>();
            Mock<Context> mockContext2 = new Mock<Context>();

            AdsManager manager1 = new AdsManager(mockContext1.Object);
            AdsManager manager2 = new AdsManager(mockContext2.Object);

            await manager1.InitializeAsync(_defaultConfig);
            await manager2.InitializeAsync(_defaultConfig);

            await manager1.LoadBannerAdAsync("banner-1");
            // manager2 does not load banner

            Assert.True(manager1.IsBannerAdLoaded);
            Assert.False(manager2.IsBannerAdLoaded);
        }

        /// <summary>
        ///     Tests that manager state is reset after showing interstitial
        /// </summary>
        [Fact]
        public async Task ShowInterstitialAd_ShouldResetLoadedState()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);
            await manager.LoadInterstitialAdAsync("interstitial-id");

            Assert.True(manager.IsInterstitialAdLoaded);

            manager.ShowInterstitialAd();

            Assert.False(manager.IsInterstitialAdLoaded);
        }

        /// <summary>
        ///     Tests that manager state is reset after showing rewarded video
        /// </summary>
        [Fact]
        public async Task ShowRewardedVideoAd_ShouldResetLoadedState()
        {
            Mock<Context> mockContext = new Mock<Context>();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(_defaultConfig);
            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            Assert.True(manager.IsRewardedVideoAdLoaded);

            manager.ShowRewardedVideoAd();

            Assert.False(manager.IsRewardedVideoAdLoaded);
        }

        #endregion
    }
}
