

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