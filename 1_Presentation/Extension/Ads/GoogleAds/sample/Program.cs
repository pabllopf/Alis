

using System;
using System.Threading.Tasks;
using Alis.Core.Aspect.Logging;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Ads.GoogleAds.Sample
{
    /// <summary>
    ///     The program class with Google Ads integration samples
    /// </summary>
    public static class Program
    {
        /// <summary>
        ///     Main
        /// </summary>
        public static async Task Main()
        {
            Logger.Info("Google Ads Sample Application");
            Logger.Info("==============================\n");

            await Sample1_BasicBannerAds();

            Logger.Info("\n");

            await Sample2_InterstitialAds();

            Logger.Info("\n");

            await Sample3_RewardedVideoAds();

            Logger.Info("\n");

            await Sample4_GameIntegration();

            Logger.Info("\nEnd program.");
        }

        /// <summary>
        ///     Sample 1: Basic banner ads setup
        /// </summary>
        private static async Task Sample1_BasicBannerAds()
        {
            Logger.Info("Sample 1: Basic Banner Ads Setup");
            Logger.Info("--------------------------------");

            Context mockContext = new Context();

            AdsManager adsManager = new AdsManager(mockContext);

            AdConfiguration config = new AdConfiguration(
                "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                "ca-app-pub-3940256099942544/6300978111",
                "ca-app-pub-3940256099942544/1033173712",
                "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true, // Always use test mode in development
                IsEnabled = true
            };

            try
            {
                await adsManager.InitializeAsync(config);
                Logger.Info("✓ AdsManager initialized successfully");
            }
            catch (Exception ex)
            {
                Logger.Error($"✗ Failed to initialize AdsManager: {ex.Message}");
                return;
            }

            adsManager.OnBannerAdLoaded += unitId => { Logger.Info($"✓ Banner ad loaded: {unitId}"); };

            adsManager.OnBannerAdFailedToLoad += unitId => { Logger.Warning($"✗ Banner ad failed to load: {unitId}"); };

            Logger.Info("Loading banner ad...");
            try
            {
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);

                adsManager.ShowBannerAd();
                Logger.Info("✓ Banner ad displayed");

                adsManager.HideBannerAd();
                Logger.Info("✓ Banner ad hidden");
            }
            catch (Exception ex)
            {
                Logger.Error($"✗ Error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Sample 2: Interstitial ads (full-screen ads)
        /// </summary>
        private static async Task Sample2_InterstitialAds()
        {
            Logger.Info("Sample 2: Interstitial Ads");
            Logger.Info("---------------------------");

            Context mockContext = new Context();
            AdsManager adsManager = new AdsManager(mockContext);

            AdConfiguration config = new AdConfiguration(
                "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                "ca-app-pub-3940256099942544/6300978111",
                "ca-app-pub-3940256099942544/1033173712",
                "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = true
            };

            await adsManager.InitializeAsync(config);

            adsManager.OnInterstitialAdLoaded += unitId => { Logger.Info($"✓ Interstitial ad loaded: {unitId}"); };

            adsManager.OnInterstitialAdFailedToLoad += unitId => { Logger.Warning($"✗ Interstitial ad failed to load: {unitId}"); };

            adsManager.OnAdClicked += adType => { Logger.Info($"✓ Ad clicked: {adType}"); };

            adsManager.OnAdClosed += adType => { Logger.Info($"✓ Ad closed: {adType}"); };

            Logger.Info("Loading interstitial ad...");
            try
            {
                await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);

                if (adsManager.IsInterstitialAdLoaded)
                {
                    Logger.Info("Showing interstitial ad...");
                    adsManager.ShowInterstitialAd();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"✗ Error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Sample 3: Rewarded video ads (user watches for in-game reward)
        /// </summary>
        private static async Task Sample3_RewardedVideoAds()
        {
            Logger.Info("Sample 3: Rewarded Video Ads");
            Logger.Info("-----------------------------");

            Context mockContext = new Context();
            AdsManager adsManager = new AdsManager(mockContext);

            AdConfiguration config = new AdConfiguration(
                "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                "ca-app-pub-3940256099942544/6300978111",
                "ca-app-pub-3940256099942544/1033173712",
                "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = true
            };

            await adsManager.InitializeAsync(config);

            adsManager.OnRewardedVideoAdLoaded += unitId => { Logger.Info($"✓ Rewarded video ad loaded: {unitId}"); };

            adsManager.OnRewardedVideoAdFailedToLoad += unitId => { Logger.Warning($"✗ Rewarded video ad failed to load: {unitId}"); };

            adsManager.OnAdRewarded += rewardArgs =>
            {
                Logger.Info("✓ User earned reward!");
                Logger.Info($"  Reward Type: {rewardArgs.RewardType}");
                Logger.Info($"  Reward Amount: {rewardArgs.RewardAmount}");
                Logger.Info($"  Ad Unit: {rewardArgs.AdUnitId}");

            };

            Logger.Info("Loading rewarded video ad...");
            try
            {
                await adsManager.LoadRewardedVideoAdAsync(config.DefaultRewardedVideoAdUnitId);

                if (adsManager.IsRewardedVideoAdLoaded)
                {
                    Logger.Info("Showing rewarded video ad...");
                    adsManager.ShowRewardedVideoAd();
                }
            }
            catch (Exception ex)
            {
                Logger.Error($"✗ Error: {ex.Message}");
            }
        }

        /// <summary>
        ///     Sample 4: Complete game integration example
        /// </summary>
        private static async Task Sample4_GameIntegration()
        {
            Logger.Info("Sample 4: Complete Game Integration");
            Logger.Info("====================================");

            Context mockContext = new Context();
            GameStateExample gameState = new GameStateExample();
            AdsManager adsManager = new AdsManager(mockContext);

            AdConfiguration config = new AdConfiguration(
                "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                "ca-app-pub-3940256099942544/6300978111",
                "ca-app-pub-3940256099942544/1033173712",
                "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = !gameState.IsPremium // Only show ads to non-premium players
            };

            await adsManager.InitializeAsync(config);

            adsManager.OnAdRewarded += rewardArgs =>
            {
                gameState.AddCoins(rewardArgs.RewardAmount);
                Logger.Info($"Player now has {gameState.Coins} coins");
            };

            adsManager.OnInterstitialAdLoaded += unitId => { Logger.Info("Ready to show interstitial between levels"); };

            Logger.Info($"Game started - Player is Premium: {gameState.IsPremium}");
            Logger.Info($"Ads enabled: {config.IsEnabled}");

            if (config.IsEnabled)
            {
                Logger.Info("Loading persistent banner ad...");
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
                adsManager.ShowBannerAd();

                gameState.CurrentLevel++;
                Logger.Info($"Level {gameState.CurrentLevel} completed!");

                if (gameState.CurrentLevel % 3 == 0) // Every 3 levels
                {
                    Logger.Info("Loading interstitial between levels...");
                    await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);
                    if (adsManager.IsInterstitialAdLoaded)
                    {
                        adsManager.ShowInterstitialAd();
                    }
                }

                Logger.Info("Offering bonus coins via rewarded video...");
                await adsManager.LoadRewardedVideoAdAsync(config.DefaultRewardedVideoAdUnitId);
                if (adsManager.IsRewardedVideoAdLoaded)
                {
                    adsManager.ShowRewardedVideoAd();
                }
            }

            Logger.Info($"Game state - Level: {gameState.CurrentLevel}, Coins: {gameState.Coins}");
        }
    }
}