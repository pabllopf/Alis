// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManagerCoverageTest.cs
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
    ///     Coverage tests for AdsManager error-handling paths.
    ///     Targets the catch blocks in LoadBannerAd, LoadInterstitialAd, and
    ///     LoadRewardedVideoAd when a subscriber throws, and the Dispose(false) path.
    /// </summary>
    public class AdsManagerCoverageTest
    {
        /// <summary>
        ///     Creates the default ad configuration
        /// </summary>
        /// <returns>The ad configuration</returns>
        private static AdConfiguration CreateConfig()
        {
            return new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
        }

        /// <summary>
        ///     Creates the context
        /// </summary>
        /// <returns>A mock of context</returns>
        private static Mock<Context> CreateContext()
        {
            return new Mock<Context>();
        }

        /// <summary>
        ///     Tests that LoadBannerAdAsync invokes the catch block when
        ///     OnBannerAdLoaded subscriber throws, and the FailedToLoad event fires.
        ///     This covers the catch branch in LoadBannerAd (lines 369-373).
        /// </summary>
        [Fact]
        public async Task LoadBannerAdAsync_WhenSubscriberThrows_ShouldTriggerFailedToLoad()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            string failedUnitId = null;
            manager.OnBannerAdFailedToLoad += id => failedUnitId = id;
            manager.OnBannerAdLoaded += _ => throw new InvalidOperationException("Simulated banner load failure");

            await manager.LoadBannerAdAsync("banner-id");

            Assert.Equal("banner-id", failedUnitId);
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that LoadInterstitialAdAsync invokes the catch block when
        ///     OnInterstitialAdLoaded subscriber throws, and the FailedToLoad event fires.
        ///     This covers the catch branch in LoadInterstitialAd (lines 405-409).
        /// </summary>
        [Fact]
        public async Task LoadInterstitialAdAsync_WhenSubscriberThrows_ShouldTriggerFailedToLoad()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            string failedUnitId = null;
            manager.OnInterstitialAdFailedToLoad += id => failedUnitId = id;
            manager.OnInterstitialAdLoaded += _ => throw new InvalidOperationException("Simulated interstitial load failure");

            await manager.LoadInterstitialAdAsync("interstitial-id");

            Assert.Equal("interstitial-id", failedUnitId);
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that LoadRewardedVideoAdAsync invokes the catch block when
        ///     OnRewardedVideoAdLoaded subscriber throws, and the FailedToLoad event fires.
        ///     This covers the catch branch in LoadRewardedVideoAd (lines 441-445).
        /// </summary>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WhenSubscriberThrows_ShouldTriggerFailedToLoad()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            string failedUnitId = null;
            manager.OnRewardedVideoAdFailedToLoad += id => failedUnitId = id;
            manager.OnRewardedVideoAdLoaded += _ => throw new InvalidOperationException("Simulated rewarded load failure");

            await manager.LoadRewardedVideoAdAsync("rewarded-id");

            Assert.Equal("rewarded-id", failedUnitId);
            manager.Dispose();
        }

        /// <summary>
        ///     Tests that Dispose(false) can be called without throwing.
        ///     This covers the else branch of if (disposing) in Dispose(bool).
        /// </summary>
        [Fact]
        public void Dispose_WithFalse_ShouldNotThrow()
        {
            Mock<Context> mockContext = CreateContext();
            using AdsManagerDisposeFalseWrapper manager = new AdsManagerDisposeFalseWrapper(mockContext.Object);

            // Should not throw
            manager.CallDisposeFalse();
        }

        /// <summary>
        ///     Tests that Dispose(false) after initialization does not fire OnAdClosed.
        /// </summary>
        [Fact]
        public async Task Dispose_WithFalse_AfterInitialization_ShouldNotThrow()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManagerDisposeFalseWrapper manager = new AdsManagerDisposeFalseWrapper(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            bool eventFired = false;
            manager.OnAdClosed += _ => eventFired = true;

            manager.CallDisposeFalse();

            Assert.False(eventFired);
            manager.Dispose();
        }
    }

    /// <summary>
    ///     Wrapper to expose the protected Dispose(bool) method for testing
    /// </summary>
    public class AdsManagerDisposeFalseWrapper : AdsManager
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdsManagerDisposeFalseWrapper" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AdsManagerDisposeFalseWrapper(Context context) : base(context)
        {
        }

        /// <summary>
        ///     Calls Dispose with disposing=false to test the non-disposing path
        /// </summary>
        public void CallDisposeFalse()
        {
            Dispose(false);
        }
    }
}
