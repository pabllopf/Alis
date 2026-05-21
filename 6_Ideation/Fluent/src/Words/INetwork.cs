

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures network replication,
    ///     multiplayer synchronization, or remote communication settings.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The network configuration type — replication mode, authority settings, or connection parameters.</typeparam>
    /// <remarks>
    ///     Used for multiplayer games to configure which entities are replicated,
    ///     who has authority (server vs client), and how state is synchronized.
    ///     Relevant only in networked/multiplayer contexts.
    /// </remarks>
    public interface INetwork<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures network replication/communication settings on the builder.
        /// </summary>
        /// <param name="value">The network configuration — replication mode, authority, or connection parameters.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Network(TArgument value);
    }
}