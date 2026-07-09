using System;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Ads.GoogleAds.Test
{
    /// <summary>
    /// The ads manager remaining coverage tests class
    /// </summary>
    public class AdsManagerRemainingCoverageTests
    {
        /// <summary>
        /// Creates the config
        /// </summary>
        /// <returns>The ad configuration</returns>
        private static AdConfiguration CreateConfig()
        {
            return new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
        }

        /// <summary>
        /// Creates the context
        /// </summary>
        /// <returns>A mock of context</returns>
        private static Mock<Context> CreateContext()
        {
            return new Mock<Context>();
        }

        /// <summary>
        /// Tests that load banner ad async when subscriber throws and failed to load has no subscribers should not throw
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated banner load failure</exception>
        [Fact]
        public async Task LoadBannerAdAsync_WhenSubscriberThrowsAndFailedToLoadHasNoSubscribers_ShouldNotThrow()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            manager.OnBannerAdLoaded += _ => throw new InvalidOperationException("Simulated banner load failure");

            Exception exception = await Record.ExceptionAsync(() => manager.LoadBannerAdAsync("banner-id"));

            Assert.Null(exception);
            manager.Dispose();
        }

        /// <summary>
        /// Tests that load interstitial ad async when subscriber throws and failed to load has no subscribers should not throw
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated interstitial load failure</exception>
        [Fact]
        public async Task LoadInterstitialAdAsync_WhenSubscriberThrowsAndFailedToLoadHasNoSubscribers_ShouldNotThrow()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            manager.OnInterstitialAdLoaded += _ => throw new InvalidOperationException("Simulated interstitial load failure");

            Exception exception = await Record.ExceptionAsync(() => manager.LoadInterstitialAdAsync("interstitial-id"));

            Assert.Null(exception);
            manager.Dispose();
        }

        /// <summary>
        /// Tests that load rewarded video ad async when subscriber throws and failed to load has no subscribers should not throw
        /// </summary>
        /// <exception cref="InvalidOperationException">Simulated rewarded load failure</exception>
        [Fact]
        public async Task LoadRewardedVideoAdAsync_WhenSubscriberThrowsAndFailedToLoadHasNoSubscribers_ShouldNotThrow()
        {
            Mock<Context> mockContext = CreateContext();
            AdsManager manager = new AdsManager(mockContext.Object);
            await manager.InitializeAsync(CreateConfig());

            manager.OnRewardedVideoAdLoaded += _ => throw new InvalidOperationException("Simulated rewarded load failure");

            Exception exception = await Record.ExceptionAsync(() => manager.LoadRewardedVideoAdAsync("rewarded-id"));

            Assert.Null(exception);
            manager.Dispose();
        }
    }
}
