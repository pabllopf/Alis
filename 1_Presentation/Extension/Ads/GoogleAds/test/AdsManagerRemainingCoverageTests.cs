using System;
using System.Threading.Tasks;
using Alis.Core.Ecs.Systems.Scope;
using Moq;
using Xunit;

namespace Alis.Extension.Ads.GoogleAds.Test
{
    public class AdsManagerRemainingCoverageTests
    {
        private static AdConfiguration CreateConfig()
        {
            return new AdConfiguration("app-id", "banner-id", "interstitial-id", "rewarded-id");
        }

        private static Mock<Context> CreateContext()
        {
            return new Mock<Context>();
        }

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
