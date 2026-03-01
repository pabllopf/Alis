// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdsManager.cs
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
using Alis.Core.Ecs.Systems.Manager;
using Alis.Core.Ecs.Systems.Scope;

namespace Alis.Extension.Ads.GoogleAds
{
    /// <summary>
    ///     The ads manager class
    /// </summary>
    /// <seealso cref="AManager" />
    /// <seealso cref="IAdsManager" />
    public class AdsManager : AManager, IAdsManager, IDisposable
    {
        /// <summary>
        ///     The ads configuration
        /// </summary>
        private AdConfiguration _configuration;

        /// <summary>
        ///     Flag indicating if banner ad is loaded
        /// </summary>
        private bool _isBannerAdLoaded;

        /// <summary>
        ///     Flag indicating if banner ad is visible
        /// </summary>
        internal bool _isBannerAdVisible;

        /// <summary>
        ///     Flag indicating if the manager is initialized
        /// </summary>
        private bool _isInitialized;

        /// <summary>
        ///     Flag indicating if interstitial ad is loaded
        /// </summary>
        private bool _isInterstitialAdLoaded;

        /// <summary>
        ///     Flag indicating if rewarded video ad is loaded
        /// </summary>
        private bool _isRewardedVideoAdLoaded;

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdsManager" /> class
        /// </summary>
        /// <param name="context">The context</param>
        public AdsManager(Context context) : base(context)
        {
            Name = "AdsManager";
            Tag = "Ads";
            _isBannerAdVisible = false;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdsManager" /> class
        /// </summary>
        /// <param name="id">The id</param>
        /// <param name="name">The name</param>
        /// <param name="tag">The tag</param>
        /// <param name="isEnable">The is enable</param>
        /// <param name="context">The context</param>
        public AdsManager(string id, string name, string tag, bool isEnable, Context context) : base(id, name, tag, isEnable, context)
        {
        }

        /// <summary>
        ///     Gets a value indicating whether the manager is initialized
        /// </summary>
        public bool IsInitialized => _isInitialized;

        /// <summary>
        ///     Gets a value indicating whether a banner ad is loaded
        /// </summary>
        public bool IsBannerAdLoaded => _isBannerAdLoaded;

        /// <summary>
        ///     Gets a value indicating whether an interstitial ad is loaded
        /// </summary>
        public bool IsInterstitialAdLoaded => _isInterstitialAdLoaded;

        /// <summary>
        ///     Gets a value indicating whether a rewarded video ad is loaded
        /// </summary>
        public bool IsRewardedVideoAdLoaded => _isRewardedVideoAdLoaded;

        /// <summary>
        ///     Event triggered when a banner ad is loaded
        /// </summary>
        public event Action<string> OnBannerAdLoaded;

        /// <summary>
        ///     Event triggered when a banner ad fails to load
        /// </summary>
        public event Action<string> OnBannerAdFailedToLoad;

        /// <summary>
        ///     Event triggered when an interstitial ad is loaded
        /// </summary>
        public event Action<string> OnInterstitialAdLoaded;

        /// <summary>
        ///     Event triggered when an interstitial ad fails to load
        /// </summary>
        public event Action<string> OnInterstitialAdFailedToLoad;

        /// <summary>
        ///     Event triggered when a rewarded video ad is loaded
        /// </summary>
        public event Action<string> OnRewardedVideoAdLoaded;

        /// <summary>
        ///     Event triggered when a rewarded video ad fails to load
        /// </summary>
        public event Action<string> OnRewardedVideoAdFailedToLoad;

        /// <summary>
        ///     Event triggered when a rewarded video ad is completed
        /// </summary>
        public event Action<AdRewardEventArgs> OnAdRewarded;

        /// <summary>
        ///     Event triggered when an ad is clicked
        /// </summary>
        public event Action<string> OnAdClicked;

        /// <summary>
        ///     Event triggered when an ad is closed
        /// </summary>
        public event Action<string> OnAdClosed;

        /// <summary>
        ///     Initializes the ads manager with the given configuration
        /// </summary>
        /// <param name="configuration">The ads configuration</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task InitializeAsync(AdConfiguration configuration)
        {
            return Task.Run(() => Initialize(configuration));
        }

        /// <summary>
        ///     Loads a banner ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the banner</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task LoadBannerAdAsync(string adUnitId)
        {
            return Task.Run(() => LoadBannerAd(adUnitId));
        }

        /// <summary>
        ///     Shows the loaded banner ad
        /// </summary>
        public void ShowBannerAd()
        {
            if (!_isInitialized)
            {
                Logger.Error("AdsManager not initialized. Call InitializeAsync first.");
                return;
            }

            if (!_isBannerAdLoaded)
            {
                Logger.Error("Banner ad not loaded. Call LoadBannerAdAsync first.");
                return;
            }

            _isBannerAdVisible = true;
            Logger.Info("Banner ad shown");
        }

        /// <summary>
        ///     Hides the current banner ad
        /// </summary>
        public void HideBannerAd()
        {
            if (!_isInitialized)
            {
                Logger.Error("AdsManager not initialized.");
                return;
            }

            _isBannerAdVisible = false;
            Logger.Info("Banner ad hidden");
        }

        /// <summary>
        ///     Loads an interstitial ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the interstitial</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task LoadInterstitialAdAsync(string adUnitId)
        {
            return Task.Run(() => LoadInterstitialAd(adUnitId));
        }

        /// <summary>
        ///     Shows the loaded interstitial ad
        /// </summary>
        public void ShowInterstitialAd()
        {
            if (!_isInitialized)
            {
                Logger.Error("AdsManager not initialized. Call InitializeAsync first.");
                return;
            }

            if (!_isInterstitialAdLoaded)
            {
                Logger.Error("Interstitial ad not loaded. Call LoadInterstitialAdAsync first.");
                return;
            }

            Logger.Info("Interstitial ad shown");
            OnAdClicked?.Invoke("interstitial");

            // Reset the loaded state after showing
            _isInterstitialAdLoaded = false;
        }

        /// <summary>
        ///     Loads a rewarded video ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the rewarded video</param>
        /// <returns>A task representing the asynchronous operation</returns>
        public Task LoadRewardedVideoAdAsync(string adUnitId)
        {
            return Task.Run(() => LoadRewardedVideoAd(adUnitId));
        }

        /// <summary>
        ///     Shows the loaded rewarded video ad
        /// </summary>
        public void ShowRewardedVideoAd()
        {
            if (!_isInitialized)
            {
                Logger.Error("AdsManager not initialized. Call InitializeAsync first.");
                return;
            }

            if (!_isRewardedVideoAdLoaded)
            {
                Logger.Error("Rewarded video ad not loaded. Call LoadRewardedVideoAdAsync first.");
                return;
            }

            Logger.Info("Rewarded video ad shown");
            OnAdClicked?.Invoke("rewarded_video");

            // Simulate reward
            OnAdRewarded?.Invoke(new AdRewardEventArgs("coins", 10, "rewarded_video_unit"));

            // Reset the loaded state after showing
            _isRewardedVideoAdLoaded = false;
        }

        /// <summary>
        /// Disposes this instance
        /// </summary>
        public void Dispose()
        {
            // Clean up any resources if necessary
            Logger.Info("AdsManager disposed");
            if (OnAdClosed != null)
            {
                OnAdClosed.Invoke("all");
            }

            GC.SuppressFinalize(this);
        }

        /// <summary>
        ///     Initialize the ads manager
        /// </summary>
        /// <param name="configuration">The ads configuration</param>
        private void Initialize(AdConfiguration configuration)
        {
            if (configuration == null)
            {
                throw new ArgumentNullException(nameof(configuration), "Configuration cannot be null");
            }

            if (string.IsNullOrEmpty(configuration.AppId))
            {
                throw new ArgumentException("AppId cannot be null or empty", nameof(configuration));
            }

            _configuration = configuration;
            _isInitialized = true;

            Logger.Info($"AdsManager initialized with AppId: {configuration.AppId}");
            Logger.Info($"Test mode: {configuration.IsTestMode}");
        }

        /// <summary>
        ///     Load banner ad
        /// </summary>
        /// <param name="adUnitId">The ad unit ID</param>
        private void LoadBannerAd(string adUnitId)
        {
            if (!_isInitialized)
            {
                throw new InvalidOperationException("AdsManager not initialized. Call InitializeAsync first.");
            }

            if (string.IsNullOrEmpty(adUnitId))
            {
                throw new ArgumentException("Ad unit ID cannot be null or empty", nameof(adUnitId));
            }

            if (!_configuration.IsEnabled)
            {
                Logger.Warning("Ads are disabled in configuration");
                OnBannerAdFailedToLoad?.Invoke(adUnitId);
                return;
            }

            try
            {
                // Simulate ad loading
                Logger.Info($"Loading banner ad with unit ID: {adUnitId}");
                _isBannerAdLoaded = true;
                OnBannerAdLoaded?.Invoke(adUnitId);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load banner ad: {ex.Message}");
                OnBannerAdFailedToLoad?.Invoke(adUnitId);
            }
        }

        /// <summary>
        ///     Load interstitial ad
        /// </summary>
        /// <param name="adUnitId">The ad unit ID</param>
        private void LoadInterstitialAd(string adUnitId)
        {
            if (!_isInitialized)
            {
                throw new InvalidOperationException("AdsManager not initialized. Call InitializeAsync first.");
            }

            if (string.IsNullOrEmpty(adUnitId))
            {
                throw new ArgumentException("Ad unit ID cannot be null or empty", nameof(adUnitId));
            }

            if (!_configuration.IsEnabled)
            {
                Logger.Warning("Ads are disabled in configuration");
                OnInterstitialAdFailedToLoad?.Invoke(adUnitId);
                return;
            }

            try
            {
                // Simulate ad loading
                Logger.Info($"Loading interstitial ad with unit ID: {adUnitId}");
                _isInterstitialAdLoaded = true;
                OnInterstitialAdLoaded?.Invoke(adUnitId);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load interstitial ad: {ex.Message}");
                OnInterstitialAdFailedToLoad?.Invoke(adUnitId);
            }
        }

        /// <summary>
        ///     Load rewarded video ad
        /// </summary>
        /// <param name="adUnitId">The ad unit ID</param>
        private void LoadRewardedVideoAd(string adUnitId)
        {
            if (!_isInitialized)
            {
                throw new InvalidOperationException("AdsManager not initialized. Call InitializeAsync first.");
            }

            if (string.IsNullOrEmpty(adUnitId))
            {
                throw new ArgumentException("Ad unit ID cannot be null or empty", nameof(adUnitId));
            }

            if (!_configuration.IsEnabled)
            {
                Logger.Warning("Ads are disabled in configuration");
                OnRewardedVideoAdFailedToLoad?.Invoke(adUnitId);
                return;
            }

            try
            {
                // Simulate ad loading
                Logger.Info($"Loading rewarded video ad with unit ID: {adUnitId}");
                _isRewardedVideoAdLoaded = true;
                OnRewardedVideoAdLoaded?.Invoke(adUnitId);
            }
            catch (Exception ex)
            {
                Logger.Error($"Failed to load rewarded video ad: {ex.Message}");
                OnRewardedVideoAdFailedToLoad?.Invoke(adUnitId);
            }
        }
    }
}