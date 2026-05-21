// --------------------------------------------------------------------------
// 
//                               █▀▀█ ░█─── ▀█▀ ░█▀▀▀█
//                              ░█▄▄█ ░█─── ░█─ ─▀▀▀▄▄
//                              ░█─░█ ░█▄▄█ ▄█▄ ░█▄▄▄█
// 
//  --------------------------------------------------------------------------
//  File:AdConfiguration.cs
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

namespace Alis.Extension.Ads.GoogleAds
{
    /// <summary>
    ///     Configuration for Google Ads
    /// </summary>
    public class AdConfiguration
    {
        /// <summary>
        ///     Initializes a new instance of the <see cref="AdConfiguration" /> class
        /// </summary>
        public AdConfiguration()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="AdConfiguration" /> class
        /// </summary>
        /// <param name="appId">The app ID</param>
        /// <param name="bannerAdUnitId">The banner ad unit ID</param>
        /// <param name="interstitialAdUnitId">The interstitial ad unit ID</param>
        /// <param name="rewardedVideoAdUnitId">The rewarded video ad unit ID</param>
        public AdConfiguration(string appId, string bannerAdUnitId, string interstitialAdUnitId, string rewardedVideoAdUnitId)
        {
            AppId = appId;
            DefaultBannerAdUnitId = bannerAdUnitId;
            DefaultInterstitialAdUnitId = interstitialAdUnitId;
            DefaultRewardedVideoAdUnitId = rewardedVideoAdUnitId;
        }

        /// <summary>
        ///     Gets or sets the Google Mobile Ads App ID
        /// </summary>
        public string AppId { get; set; }

        /// <summary>
        ///     Gets or sets the default banner ad unit ID
        /// </summary>
        public string DefaultBannerAdUnitId { get; set; }

        /// <summary>
        ///     Gets or sets the default interstitial ad unit ID
        /// </summary>
        public string DefaultInterstitialAdUnitId { get; set; }

        /// <summary>
        ///     Gets or sets the default rewarded video ad unit ID
        /// </summary>
        public string DefaultRewardedVideoAdUnitId { get; set; }

        /// <summary>
        ///     Gets or sets a value indicating whether ads are enabled
        /// </summary>
        public bool IsEnabled { get; set; } = true;

        /// <summary>
        ///     Gets or sets a value indicating whether the ads are in test mode
        /// </summary>
        public bool IsTestMode { get; set; } = false;

        /// <summary>
        ///     Gets or sets the logging level for ads
        /// </summary>
        public AdLoggingLevel LoggingLevel { get; set; } = AdLoggingLevel.Info;
    }

    /// <summary>
    ///     Logging level for ads
    /// </summary>
    public enum AdLoggingLevel
    {
        /// <summary>
        ///     No logging
        /// </summary>
        None = 0,

        /// <summary>
        ///     Info level logging
        /// </summary>
        Info = 1,

        /// <summary>
        ///     Debug level logging
        /// </summary>
        Debug = 2,

        /// <summary>
        ///     Verbose level logging
        /// </summary>
        Verbose = 3
    }
}