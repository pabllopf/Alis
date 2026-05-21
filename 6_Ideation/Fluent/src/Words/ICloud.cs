

namespace Alis.Core.Aspect.Fluent.Words
{
/// <summary>
    ///     Fluent builder interface that configures cloud save, sync,
    ///     or remote storage settings for game data and profiles.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The cloud configuration type — provider, sync policy, or encryption settings.</typeparam>
    /// <remarks>
    ///     Enables cross-device save synchronization, leaderboard integration,
    ///     or cloud-based content delivery. Configuration varies by provider
    ///     (Google Play Games, Game Center, Steam Cloud, etc.).
    /// </remarks>
    public interface ICloud<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures cloud sync/storage settings on the builder.
        /// </summary>
        /// <param name="value">The cloud configuration — provider, sync policy, or storage parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Cloud(TArgument value);
    }
}