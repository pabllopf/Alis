// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdvancedSample.cs
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
using Alis.Core.Aspect.Logging;
using Alis.Extension.Ads.GoogleAds;
using Moq;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Ads.GoogleAds.Sample
{
    /// <summary>
    ///     Advanced usage examples for Google Ads Manager
    /// </summary>
    public static class AdvancedSample
    {
        /// <summary>
        ///     Example 1: Conditional ads based on user status
        /// </summary>
        public static async Task Example1_ConditionalAdDisplay()
        {
            Logger.Info("Example 1: Conditional Ad Display");
            Logger.Info("----------------------------------");

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);

            // Create user profile
            var user = new UserProfile
            {
                IsPremium = false,
                DailyAdLimit = 5,
                AdsShownToday = 2
            };

            // Configure ads based on user status
            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsEnabled = !user.IsPremium,
                IsTestMode = true
            };

            await adsManager.InitializeAsync(config);

            // Only show banner if not premium
            if (!user.IsPremium)
            {
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
                adsManager.ShowBannerAd();
                Logger.Info("✓ Banner ad shown to free user");
            }
            else
            {
                Logger.Info("✓ Premium user - no ads shown");
            }

            // Check daily limit before showing interstitial
            if (user.AdsShownToday < user.DailyAdLimit)
            {
                await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);
                if (adsManager.IsInterstitialAdLoaded)
                {
                    adsManager.ShowInterstitialAd();
                    user.AdsShownToday++;
                    Logger.Info($"✓ Interstitial shown ({user.AdsShownToday}/{user.DailyAdLimit})");
                }
            }
            else
            {
                Logger.Info("✓ Daily ad limit reached");
            }
        }

        /// <summary>
        ///     Example 2: Ad monetization strategy
        /// </summary>
        public static async Task Example2_MonetizationStrategy()
        {
            Logger.Info("Example 2: Ad Monetization Strategy");
            Logger.Info("-----------------------------------");

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);
            var gameEconomy = new GameEconomy();

            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = true
            };

            await adsManager.InitializeAsync(config);

            // Strategy 1: Persistent banner for passive income
            await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
            adsManager.ShowBannerAd();
            gameEconomy.RegisterBannerAdShown();

            // Strategy 2: Rewarded ads for premium currency
            adsManager.OnAdRewarded += (args) =>
            {
                Logger.Info($"✓ Rewarding player with {args.RewardAmount} {args.RewardType}");
                gameEconomy.AddPremiumCurrency(args.RewardAmount);
            };

            await adsManager.LoadRewardedVideoAdAsync(config.DefaultRewardedVideoAdUnitId);
            if (adsManager.IsRewardedVideoAdLoaded)
            {
                adsManager.ShowRewardedVideoAd();
            }

            // Strategy 3: Interstitial after key events
            await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);
            if (adsManager.IsInterstitialAdLoaded)
            {
                gameEconomy.RegisterInterstitialAdShown();
                adsManager.ShowInterstitialAd();
            }

            Logger.Info($"Total revenue events: {gameEconomy.RevenueEventCount}");
        }

        /// <summary>
        ///     Example 3: Error handling and fallback strategy
        /// </summary>
        public static async Task Example3_ErrorHandlingStrategy()
        {
            Logger.Info("Example 3: Error Handling Strategy");
            Logger.Info("----------------------------------");

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);
            var adController = new AdControllerWithFallback(adsManager);

            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsEnabled = true,
                IsTestMode = true
            };

            await adsManager.InitializeAsync(config);

            // Subscribe to failure events
            adsManager.OnBannerAdFailedToLoad += (unitId) =>
            {
                Logger.Warning($"✗ Banner ad failed, using fallback");
                adController.ShowFallbackBannerMessage();
            };

            adsManager.OnInterstitialAdFailedToLoad += (unitId) =>
            {
                Logger.Warning($"✗ Interstitial failed, continuing game");
                adController.ContinueGameWithoutInterstitial();
            };

            // Try to load with fallback
            try
            {
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
                if (adsManager.IsBannerAdLoaded)
                {
                    adsManager.ShowBannerAd();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"Banner loading error: {ex.Message}");
                adController.ShowFallbackBannerMessage();
            }
        }

        /// <summary>
        ///     Example 4: A/B testing ad placements
        /// </summary>
        public static async Task Example4_ABTestingAdPlacements()
        {
            Logger.Info("Example 4: A/B Testing Ad Placements");
            Logger.Info("-------------------------------------");

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);
            var abTester = new AdABTester();

            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = true
            };

            await adsManager.InitializeAsync(config);

            // A/B Test: Variant A - Interstitial at level completion
            if (abTester.GetVariant() == "A")
            {
                Logger.Info("✓ Testing Variant A: Interstitial at level end");
                await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);
                if (adsManager.IsInterstitialAdLoaded)
                {
                    adsManager.ShowInterstitialAd();
                    abTester.RecordVariantAShown();
                }
            }
            // A/B Test: Variant B - Rewarded ad instead
            else
            {
                Logger.Info("✓ Testing Variant B: Rewarded ad at level end");
                await adsManager.LoadRewardedVideoAdAsync(config.DefaultRewardedVideoAdUnitId);
                if (adsManager.IsRewardedVideoAdLoaded)
                {
                    adsManager.ShowRewardedVideoAd();
                    abTester.RecordVariantBShown();
                }
            }

            Logger.Info($"Variant A shows: {abTester.VariantAShows}, Variant B shows: {abTester.VariantBShows}");
        }
    }

    /// <summary>
    ///     User profile for ad targeting
    /// </summary>
    public class UserProfile
    {
        /// <summary>
        ///     Gets or sets whether user is premium
        /// </summary>
        public bool IsPremium { get; set; }

        /// <summary>
        ///     Gets or sets daily ad limit
        /// </summary>
        public int DailyAdLimit { get; set; }

        /// <summary>
        ///     Gets or sets ads shown today
        /// </summary>
        public int AdsShownToday { get; set; }
    }

    /// <summary>
    ///     Game economy manager
    /// </summary>
    public class GameEconomy
    {
        /// <summary>
        ///     Gets revenue event count
        /// </summary>
        public int RevenueEventCount { get; private set; }

        /// <summary>
        ///     Gets premium currency
        /// </summary>
        public int PremiumCurrency { get; private set; }

        /// <summary>
        ///     Registers banner ad shown
        /// </summary>
        public void RegisterBannerAdShown()
        {
            RevenueEventCount++;
        }

        /// <summary>
        ///     Registers interstitial ad shown
        /// </summary>
        public void RegisterInterstitialAdShown()
        {
            RevenueEventCount++;
        }

        /// <summary>
        ///     Adds premium currency
        /// </summary>
        /// <param name="amount">The amount</param>
        public void AddPremiumCurrency(int amount)
        {
            PremiumCurrency += amount;
        }
    }

    /// <summary>
    ///     Ad controller with fallback strategy
    /// </summary>
    public class AdControllerWithFallback
    {
        /// <summary>
        ///     The ads manager
        /// </summary>
        private readonly AdsManager _adsManager;

        /// <summary>
        ///     Initializes a new instance
        /// </summary>
        /// <param name="adsManager">The ads manager</param>
        public AdControllerWithFallback(AdsManager adsManager)
        {
            _adsManager = adsManager;
        }

        /// <summary>
        ///     Shows fallback banner message
        /// </summary>
        public void ShowFallbackBannerMessage()
        {
            Logger.Info("Showing fallback banner message instead of ad");
        }

        /// <summary>
        ///     Continues game without interstitial
        /// </summary>
        public void ContinueGameWithoutInterstitial()
        {
            Logger.Info("Game continues without interstitial ad");
        }
    }

    /// <summary>
    ///     A/B testing utility for ads
    /// </summary>
    public class AdABTester
    {
        /// <summary>
        ///     Gets variant A shows
        /// </summary>
        public int VariantAShows { get; private set; }

        /// <summary>
        ///     Gets variant B shows
        /// </summary>
        public int VariantBShows { get; private set; }

        /// <summary>
        ///     Gets variant for testing
        /// </summary>
        /// <returns>Variant A or B</returns>
        public string GetVariant()
        {
            return Guid.NewGuid().GetHashCode() % 2 == 0 ? "A" : "B";
        }

        /// <summary>
        ///     Records variant A shown
        /// </summary>
        public void RecordVariantAShown()
        {
            VariantAShows++;
        }

        /// <summary>
        ///     Records variant B shown
        /// </summary>
        public void RecordVariantBShown()
        {
            VariantBShows++;
        }
    }
}
