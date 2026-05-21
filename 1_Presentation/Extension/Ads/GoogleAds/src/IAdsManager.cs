// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:IAdsManager.cs
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

namespace Alis.Extension.Ads.GoogleAds
{
    /// <summary>
    ///     The ads manager interface
    /// </summary>
    public interface IAdsManager
    {
        /// <summary>
        ///     Gets a value indicating whether the manager is initialized
        /// </summary>
        bool IsInitialized { get; }

        /// <summary>
        ///     Gets a value indicating whether a banner ad is loaded
        /// </summary>
        bool IsBannerAdLoaded { get; }

        /// <summary>
        ///     Gets a value indicating whether an interstitial ad is loaded
        /// </summary>
        bool IsInterstitialAdLoaded { get; }

        /// <summary>
        ///     Gets a value indicating whether a rewarded video ad is loaded
        /// </summary>
        bool IsRewardedVideoAdLoaded { get; }

        /// <summary>
        ///     Initializes the ads manager with the given configuration
        /// </summary>
        /// <param name="configuration">The ads configuration</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task InitializeAsync(AdConfiguration configuration);

        /// <summary>
        ///     Loads a banner ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the banner</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task LoadBannerAdAsync(string adUnitId);

        /// <summary>
        ///     Shows the loaded banner ad
        /// </summary>
        void ShowBannerAd();

        /// <summary>
        ///     Hides the current banner ad
        /// </summary>
        void HideBannerAd();

        /// <summary>
        ///     Loads an interstitial ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the interstitial</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task LoadInterstitialAdAsync(string adUnitId);

        /// <summary>
        ///     Shows the loaded interstitial ad
        /// </summary>
        void ShowInterstitialAd();

        /// <summary>
        ///     Loads a rewarded video ad asynchronously
        /// </summary>
        /// <param name="adUnitId">The ad unit ID for the rewarded video</param>
        /// <returns>A task representing the asynchronous operation</returns>
        Task LoadRewardedVideoAdAsync(string adUnitId);

        /// <summary>
        ///     Shows the loaded rewarded video ad
        /// </summary>
        void ShowRewardedVideoAd();

        /// <summary>
        ///     Event triggered when a banner ad is loaded
        /// </summary>
        event Action<string> OnBannerAdLoaded;

        /// <summary>
        ///     Event triggered when a banner ad fails to load
        /// </summary>
        event Action<string> OnBannerAdFailedToLoad;

        /// <summary>
        ///     Event triggered when an interstitial ad is loaded
        /// </summary>
        event Action<string> OnInterstitialAdLoaded;

        /// <summary>
        ///     Event triggered when an interstitial ad fails to load
        /// </summary>
        event Action<string> OnInterstitialAdFailedToLoad;

        /// <summary>
        ///     Event triggered when a rewarded video ad is loaded
        /// </summary>
        event Action<string> OnRewardedVideoAdLoaded;

        /// <summary>
        ///     Event triggered when a rewarded video ad fails to load
        /// </summary>
        event Action<string> OnRewardedVideoAdFailedToLoad;

        /// <summary>
        ///     Event triggered when a rewarded video ad is completed
        /// </summary>
        event Action<AdRewardEventArgs> OnAdRewarded;

        /// <summary>
        ///     Event triggered when an ad is clicked
        /// </summary>
        event Action<string> OnAdClicked;

        /// <summary>
        ///     Event triggered when an ad is closed
        /// </summary>
        event Action<string> OnAdClosed;
    }
}