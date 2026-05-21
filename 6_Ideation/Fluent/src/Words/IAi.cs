

namespace Alis.Core.Aspect.Fluent.Words
{
    /// <summary>
    ///     Fluent builder interface that configures artificial intelligence behavior
    ///     parameters for a game entity.
    /// </summary>
    /// <typeparam name="TBuilder">The builder type returned by the fluent method, enabling fluent chaining.</typeparam>
    /// <typeparam name="TArgument">The AI configuration type, typically containing behavior parameters or state machine definitions.</typeparam>
    /// <remarks>
    ///     Use this interface to set up pathfinding parameters, decision-making logic,
    ///     FSM (Finite State Machine) configurations, or behavior tree references
    ///     for NPCs and other AI-driven entities.
    /// </remarks>
    public interface IAi<out TBuilder, in TArgument>
    {
        /// <summary>
        ///     Configures AI behavior parameters on the builder.
        /// </summary>
        /// <param name="value">The AI configuration object specifying behavior parameters, state machine, or decision logic.</param>
        /// <returns>The builder instance, enabling fluent chaining.</returns>
        TBuilder Ai(TArgument value);
    }
}