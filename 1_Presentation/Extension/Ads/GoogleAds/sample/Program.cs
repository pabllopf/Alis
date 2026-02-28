// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:Program.cs
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

            // Sample 1: Basic initialization and banner ads
            await Sample1_BasicBannerAds();

            Logger.Info("\n");

            // Sample 2: Interstitial ads
            await Sample2_InterstitialAds();

            Logger.Info("\n");

            // Sample 3: Rewarded video ads
            await Sample3_RewardedVideoAds();

            Logger.Info("\n");

            // Sample 4: Complete game integration example
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

            // Create a mock context (in real usage, you'd use your actual game engine context)
            var mockContext = new Mock<Context>();

            // Initialize the ads manager
            var adsManager = new AdsManager(mockContext.Object);

            // Create configuration
            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true, // Always use test mode in development
                IsEnabled = true
            };

            // Initialize the manager
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

            // Subscribe to banner ad events
            adsManager.OnBannerAdLoaded += (unitId) =>
            {
                Logger.Info($"✓ Banner ad loaded: {unitId}");
            };

            adsManager.OnBannerAdFailedToLoad += (unitId) =>
            {
                Logger.Warning($"✗ Banner ad failed to load: {unitId}");
            };

            // Load banner ad
            Logger.Info("Loading banner ad...");
            try
            {
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
                
                // Show the banner ad
                adsManager.ShowBannerAd();
                Logger.Info("✓ Banner ad displayed");

                // Later in the game, you can hide it
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

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);

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

            // Subscribe to interstitial ad events
            adsManager.OnInterstitialAdLoaded += (unitId) =>
            {
                Logger.Info($"✓ Interstitial ad loaded: {unitId}");
            };

            adsManager.OnInterstitialAdFailedToLoad += (unitId) =>
            {
                Logger.Warning($"✗ Interstitial ad failed to load: {unitId}");
            };

            adsManager.OnAdClicked += (adType) =>
            {
                Logger.Info($"✓ Ad clicked: {adType}");
            };

            adsManager.OnAdClosed += (adType) =>
            {
                Logger.Info($"✓ Ad closed: {adType}");
            };

            // Load interstitial ad (typically shown between game levels)
            Logger.Info("Loading interstitial ad...");
            try
            {
                await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);

                // Show the ad when appropriate (e.g., between levels)
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

            var mockContext = new Mock<Context>();
            var adsManager = new AdsManager(mockContext.Object);

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

            // Subscribe to rewarded video events
            adsManager.OnRewardedVideoAdLoaded += (unitId) =>
            {
                Logger.Info($"✓ Rewarded video ad loaded: {unitId}");
            };

            adsManager.OnRewardedVideoAdFailedToLoad += (unitId) =>
            {
                Logger.Warning($"✗ Rewarded video ad failed to load: {unitId}");
            };

            // This is the key event - when the user completes watching the ad
            adsManager.OnAdRewarded += (rewardArgs) =>
            {
                Logger.Info($"✓ User earned reward!");
                Logger.Info($"  Reward Type: {rewardArgs.RewardType}");
                Logger.Info($"  Reward Amount: {rewardArgs.RewardAmount}");
                Logger.Info($"  Ad Unit: {rewardArgs.AdUnitId}");

                // Give the player their reward here
                // player.AddCoins(rewardArgs.RewardAmount);
            };

            // Load rewarded video ad (shown when player opts-in)
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

            var mockContext = new Mock<Context>();
            var gameState = new GameStateExample();
            var adsManager = new AdsManager(mockContext.Object);

            // Configure ads based on game settings
            var config = new AdConfiguration(
                appId: "ca-app-pub-xxxxxxxxxxxxxxxx~yyyyyyyyyy",
                bannerAdUnitId: "ca-app-pub-3940256099942544/6300978111",
                interstitialAdUnitId: "ca-app-pub-3940256099942544/1033173712",
                rewardedVideoAdUnitId: "ca-app-pub-3940256099942544/5224354917"
            )
            {
                IsTestMode = true,
                IsEnabled = !gameState.IsPremium // Only show ads to non-premium players
            };

            await adsManager.InitializeAsync(config);

            // Setup event handlers that integrate with game
            adsManager.OnAdRewarded += (rewardArgs) =>
            {
                gameState.AddCoins(rewardArgs.RewardAmount);
                Logger.Info($"Player now has {gameState.Coins} coins");
            };

            adsManager.OnInterstitialAdLoaded += (unitId) =>
            {
                Logger.Info("Ready to show interstitial between levels");
            };

            // Simulate game flow
            Logger.Info($"Game started - Player is Premium: {gameState.IsPremium}");
            Logger.Info($"Ads enabled: {config.IsEnabled}");

            // Load different ads at different game points
            if (config.IsEnabled)
            {
                // Load banner ad to display during gameplay
                Logger.Info("Loading persistent banner ad...");
                await adsManager.LoadBannerAdAsync(config.DefaultBannerAdUnitId);
                adsManager.ShowBannerAd();

                // Simulate level completion
                gameState.CurrentLevel++;
                Logger.Info($"Level {gameState.CurrentLevel} completed!");

                // Show interstitial between levels
                if (gameState.CurrentLevel % 3 == 0) // Every 3 levels
                {
                    Logger.Info("Loading interstitial between levels...");
                    await adsManager.LoadInterstitialAdAsync(config.DefaultInterstitialAdUnitId);
                    if (adsManager.IsInterstitialAdLoaded)
                    {
                        adsManager.ShowInterstitialAd();
                    }
                }

                // Offer rewarded video for bonus coins
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

    /// <summary>
    ///     Example game state class for integration demonstration
    /// </summary>
    public class GameStateExample
    {
        /// <summary>
        ///     Gets or sets whether the player has premium status
        /// </summary>
        public bool IsPremium { get; set; }

        /// <summary>
        ///     Gets or sets the current game level
        /// </summary>
        public int CurrentLevel { get; set; }

        /// <summary>
        ///     Gets or sets the player's coins
        /// </summary>
        public int Coins { get; set; }

        /// <summary>
        ///     Initializes a new instance of the <see cref="GameStateExample" /> class
        /// </summary>
        public GameStateExample()
        {
            IsPremium = false;
            CurrentLevel = 1;
            Coins = 100;
        }

        /// <summary>
        ///     Adds coins to the player's balance
        /// </summary>
        /// <param name="amount">The amount to add</param>
        public void AddCoins(int amount)
        {
            Coins += amount;
        }
    }
}