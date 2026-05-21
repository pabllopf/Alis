

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures advertising and monetization settings
    ///     for a game entity or application.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The ads configuration type, typically containing ad placement IDs and display settings.</typeparam>
    /// <remarks>
    ///     Use this interface to configure banner ads, interstitial ads, rewarded videos,
    ///     or other monetization channels. The argument type typically includes ad unit IDs
    ///     for platforms such as Google AdMob, Unity Ads, or similar services.
    /// </remarks>
    public interface IAds<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures advertising settings on the builder.
        /// </summary>
        /// <param name="value">The ads configuration object containing placement IDs, test mode flags, and display options.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Ads(TArgument value);
    }
}